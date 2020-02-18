using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Engines.Craft;

namespace Server.Items
{
	public delegate void InstrumentPickedCallback( Mobile from, BaseInstrument instrument );

	public enum InstrumentQuality
	{
		Low,
		Regular,
		Exceptional
	}

	public abstract class BaseInstrument : Item, ICraftable, ISlayer
	{
		private int m_WellSound, m_BadlySound;
		private SlayerName m_Slayer, m_Slayer2;
		private InstrumentQuality m_Quality;
		private Mobile m_Crafter;
		private int m_UsesRemaining;

		[CommandProperty( AccessLevel.GameMaster )]
		public int SuccessSound
		{
			get{ return m_WellSound; }
			set{ m_WellSound = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int FailureSound
		{
			get{ return m_BadlySound; }
			set{ m_BadlySound = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public SlayerName Slayer
		{
			get{ return m_Slayer; }
			set{ m_Slayer = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public SlayerName Slayer2
		{
			get{ return m_Slayer2; }
			set{ m_Slayer2 = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public InstrumentQuality Quality
		{
			get{ return m_Quality; }
			set{ UnscaleUses(); m_Quality = value; InvalidateProperties(); ScaleUses(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Crafter
		{
			get{ return m_Crafter; }
			set{ m_Crafter = value; InvalidateProperties(); }
		}

		public virtual int InitMinUses{ get{ return 350; } }
		public virtual int InitMaxUses{ get{ return 450; } }

		public virtual TimeSpan ChargeReplenishRate { get { return TimeSpan.FromMinutes( 5.0 ); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int UsesRemaining
		{
			get{ CheckReplenishUses(); return m_UsesRemaining; }
			set{ m_UsesRemaining = value; InvalidateProperties(); }
		}

		private DateTime m_LastReplenished;

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime LastReplenished
		{
			get { return m_LastReplenished; }
			set { m_LastReplenished = value; CheckReplenishUses(); }
		}

		private bool m_ReplenishesCharges;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool ReplenishesCharges
		{
			get { return m_ReplenishesCharges; }
			set 
			{
				if( value != m_ReplenishesCharges && value )
					m_LastReplenished = DateTime.Now;

				m_ReplenishesCharges = value; 
			}
		}

		public void CheckReplenishUses()
		{
			CheckReplenishUses( true );
		}

		public void CheckReplenishUses( bool invalidate )
		{
			if( !m_ReplenishesCharges || m_UsesRemaining >= InitMaxUses )
				return;

			if( m_LastReplenished + ChargeReplenishRate < DateTime.Now )
			{
				TimeSpan timeDifference = DateTime.Now - m_LastReplenished;

				m_UsesRemaining = Math.Min( m_UsesRemaining + (int)( timeDifference.Ticks / ChargeReplenishRate.Ticks), InitMaxUses );	//How rude of TimeSpan to not allow timespan division.
				m_LastReplenished = DateTime.Now;

				if( invalidate )
					InvalidateProperties();

			}
		}

		public void ScaleUses()
		{
			UsesRemaining = (UsesRemaining * GetUsesScalar()) / 100;
			//InvalidateProperties();
		}

		public void UnscaleUses()
		{
			UsesRemaining = (UsesRemaining * 100) / GetUsesScalar();
		}

		public int GetUsesScalar()
		{
			if ( m_Quality == InstrumentQuality.Exceptional )
				return 200;

			return 100;
		}

		public void ConsumeUse( Mobile from )
		{
			// TODO: Confirm what must happen here?

			if ( UsesRemaining > 1 )
			{
				--UsesRemaining;
			}
			else
			{
				if ( from != null )
					from.SendLocalizedMessage( 502079 ); // The instrument played its last tune.

				Delete();
			}
		}

		private static Hashtable m_Instruments = new Hashtable();

		public static BaseInstrument GetInstrument( Mobile from )
		{
			BaseInstrument item = m_Instruments[from] as BaseInstrument;

			if ( item == null )
				return null;

			if ( item.Parent != from )
			{
				m_Instruments.Remove( from );
				return null;
			}

			return item;
		}

		public static int GetBardRange( Mobile bard, SkillName skill )
		{
			return 8 + (int)(bard.Skills[skill].Value / 15);
		}

		public static void PickInstrument( Mobile from, InstrumentPickedCallback callback )
		{
			BaseInstrument instrument = GetInstrument( from );

			if ( instrument != null )
			{
				if ( callback != null )
					callback( from, instrument );
			}
			else
			{
				from.SendLocalizedMessage( 500617 ); // What instrument shall you play?
				from.BeginTarget( 1, false, TargetFlags.None, new TargetStateCallback( OnPickedInstrument ), callback );
			}
		}

		public static void OnPickedInstrument( Mobile from, object targeted, object state )
		{
			BaseInstrument instrument = targeted as BaseInstrument;

			if ( instrument == null )
			{
				from.SendLocalizedMessage( 500619 ); // That is not a musical instrument.
			}
			else
			{
				SetInstrument( from, instrument );

				InstrumentPickedCallback callback = state as InstrumentPickedCallback;

				if ( callback != null )
					callback( from, instrument );
			}
		}

		public static bool IsMageryCreature( BaseCreature bc )
		{
			return ( bc != null && bc.AI == AIType.AI_Mage && bc.Skills[SkillName.Magery].Base > 5.0 );
		}

		public static bool IsFireBreathingCreature( BaseCreature bc )
		{
			if ( bc == null )
				return false;

			return bc.HasBreath;
		}

		public static bool IsPoisonImmune( BaseCreature bc )
		{
			return ( bc != null && bc.PoisonImmune != null );
		}

		public static int GetPoisonLevel( BaseCreature bc )
		{
			if ( bc == null )
				return 0;

			Poison p = bc.HitPoison;

			if ( p == null )
				return 0;

			return p.Level + 1;
		}

		public static double GetBaseDifficulty( Mobile targ )
		{
			/* Difficulty TODO: Add another 100 points for each of the following abilities:
				- Radiation or Aura Damage (Heat, Cold etc.)
				- Summoning Undead
			*/

                        if(targ is AncientWyrm) return 99.0;
                        if(targ is Balron) return 79.7;
                        if(targ is BloodElemental) return 62.3;
                        if(targ is Daemon) return 63.1;

//////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////// Almhara Malas Map
//////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////// Anywhere 0.0 -------- 30.0

                        if(targ is Bird) return 0.0;
                        if(targ is Boar) return 29.1;
                        if(targ is GreatHart) return 30.0;
                        if(targ is Hind) return 23.1;
                        if(targ is Horse) return 29.1;

/////////////////////////////////////// Alytharr Region 15.0 -------- 35.0

                        if(targ is AlytharrForestHart) return 22.0;
                        if(targ is AlytharrGrassSnake) return 18.0;
                        if(targ is AmazonianSpearFighter) return 35.0;
                        if(targ is BeachBeetle) return 25.0;
                        if(targ is BlackLizard) return 15.0;
                        if(targ is BrigandFemale) return 20.0;
                        if(targ is BrigandMale) return 20.0;
                        if(targ is Centaur) return 30.0;
                        if(targ is HillToad) return 15.0;
                        if(targ is MinorBloodElemental) return 30.0;
                        if(targ is Pixie) return 30.0;
                        if(targ is SandCrab) return 20.0;
                        if(targ is WyvernYoungling) return 35.0;

/////////////////////////////////////// Autumnwood 15.0 -------- 35.0

                        if(targ is AutumnwoodAdventurer) return 35.0;
                        if(targ is AutumnwoodMinotaur) return 25.0;
                        if(targ is Harpy) return 20.0;
                        if(targ is HellSteed) return 25.0;
                        if(targ is MoundOfMaggots) return 15.0;
                        if(targ is OakwoodSnarlerPup) return 15.0;
                        if(targ is OrcBomber) return 20.0;
                        if(targ is OrcBrute) return 35.0;
                        if(targ is OrcCaptain) return 25.0;
                        if(targ is OrcishLord) return 25.0;
                        if(targ is OrcishMage) return 20.0;
                        if(targ is RazorbackRaptor) return 30.0;
                        if(targ is Sahagin) return 20.0;
                        if(targ is SkitteringHopper) return 15.0;
                        if(targ is Turdy) return 15.0;

/////////////////////////////////////// Bog of Toads Pit 15.0 -------- 20.0

                        if(targ is DarkRose) return 20.0;
                        if(targ is PoisonArrowFrog) return 15.0;

/////////////////////////////////////// Dragonstorm Island 50.0 -------- 60.0

                        if(targ is Dragon) return 60.0;
                        if(targ is Drake) return 50.0;

/////////////////////////////////////// Glimmerwood 25.0 -------- 35.0

                        if(targ is AntLion) return 32.6;
                        if(targ is ForestOstard) return 25.0;
                        if(targ is Gryphon) return 30.0;
                        if(targ is Imp) return 35.0;
                        if(targ is Parrot) return 25.0;
                        if(targ is Ridgeback) return 30.0;
                        if(targ is SavageRidgeback) return 35.0;
                        if(targ is Shangyang) return 25.0;

/////////////////////////////////////// Harashi Nabi 30.0 -------- 50.0

                        if(targ is BulletAnt) return 30.0;
                        if(targ is BronzeElemental) return 40.0;
                        if(targ is CharredSprite) return 35.0;
                        if(targ is CliffDiver) return 40.0;
                        if(targ is CopperElemental) return 45.0;
                        if(targ is DeathwatchBeetleHatchling) return 30.0;
                        if(targ is DeathwatchBeetle) return 35.0;
                        if(targ is DesertOstard) return 35.0;
                        if(targ is DesertRose) return 30.0;
                        if(targ is ExodusMinion) return 50.0;
                        if(targ is ExodusOverseer) return 40.0;
                        if(targ is GiantTurtle) return 35.0;
                        if(targ is GoldenElemental) return 50.0;
                        if(targ is HellCat) return 30.0;
                        if(targ is Jubokko) return 30.0;
                        if(targ is Lion) return 50.0;
                        if(targ is Moloch) return 50.0;
                        if(targ is Mummy) return 45.0;
                        if(targ is RevenantLion) return 50.0;
                        if(targ is SandBarracuda) return 40.0;
                        if(targ is SandStreaker) return 35.0;
                        if(targ is Scorpion) return 30.0;
                        if(targ is SpectralArmour) return 40.0;
                        if(targ is Zebra) return 30.0;

/////////////////////////////////////// Island of Giants 20.0 -------- 25.0

                        if(targ is DireWolf) return 20.0;
                        if(targ is Ettin) return 25.0;
                        if(targ is Ogre) return 25.0;
                        if(targ is Troll) return 25.0;

/////////////////////////////////////// Jade Jungle 25.0 -------- 35.0

                        if(targ is CrystallineAnt) return 25.0;
                        if(targ is Gazer) return 35.0;
                        if(targ is JadeSerpent) return 28.0;


/////////////////////////////////////// Oboru Jungle 25.0 -------- 40.0

                        if(targ is DaiOgumo) return 28.0;
                        if(targ is OborunianDrowSpiderTrainer) return 30.0;
                        if(targ is Pookah) return 35.0;
                        if(targ is Tsuchigumo) return 40.0;
                        if(targ is Yatsukahag) return 25.0;

/////////////////////////////////////// Ophidian Palace 50.0 -------- 75.0

                        if(targ is OphidianApprenticeMage) return 50.0;
                        if(targ is OphidianAvenger) return 70.0;
                        if(targ is OphidianEnforcer) return 50.0;
                        if(targ is OphidianJusticar) return 60.0;
                        if(targ is OphidianKnightErrant) return 70.0;
                        if(targ is OphidianMatriarch) return 75.0;
                        if(targ is OphidianShaman) return 55.0;
                        if(targ is OphidianWarrior) return 50.0;
                        if(targ is OphidianZealot) return 60.0;

/////////////////////////////////////// Samson Swamplands 30.0 -------- 60.0

                        if(targ is Allosaur) return 60.0;
                        if(targ is BogCreeper) return 30.0;
                        if(targ is ForestDragon) return 60.0;
                        if(targ is Grachiosaur) return 60.0;
                        if(targ is WaterBeetle) return 35.0;

/////////////////////////////////////// Star Lake Pit 15.0 -------- 20.0

                        if(targ is StarLakeCrab) return 15.0;
                        if(targ is StarLakeCrabAmbusher) return 20.0;

/////////////////////////////////////// Wintergrove 30.0 -------- 50.0

                        if(targ is FrostSpider) return 35.0;
                        if(targ is Gaman) return 30.0;
                        if(targ is IceElemental) return 40.0;
                        if(targ is IceSnake) return 30.0;
                        if(targ is IceWraith) return 40.0;
                        if(targ is LadyOfTheSnow) return 40.0;
                        if(targ is Remorhaz) return 45.0;
                        if(targ is TundraProtector) return 50.0;
                        if(targ is WanderingSnowman) return 40.0;

/////////////////////////////////////// Zaythalor Forest 0.0 -------- 30.0

                        if(targ is Anchimayen) return 15.0;
                        if(targ is BlackAntAmbusher) return 7.0;
                        if(targ is BlackAntZaythalorForest) return 5.0;
                        if(targ is BlackSolenWarrior) return 20.0;
                        if(targ is BlackSolenWorker) return 15.0;
                        if(targ is EvilMage) return 17.0;
                        if(targ is FaerieBeetle) return 37.6;
                        if(targ is FaerieBeetleCollector) return 8.8;
                        if(targ is ForestBat) return 5.5;
                        if(targ is GazerLarva) return 9.0;
                        if(targ is GiantSkeleton) return 15.0;
                        if(targ is Gizzard) return 5.5;
                        if(targ is GreenSlime) return 1.0;
                        if(targ is GreySquirrel) return 0.0;
                        if(targ is GreyWolfPup) return 15.0;
                        if(targ is Gualichu) return 4.5;
                        if(targ is HordeMinion) return 5.0;
                        if(targ is LargeFrog) return 9.1;
                        if(targ is LesserAntLion) return 28.7;
                        if(targ is MadPumpkinSpirit) return 13.0;
                        if(targ is Mongbat) return 0.0;
                        if(targ is Ogumo) return 10.5;
                        if(targ is Orc) return 15.0;
                        if(targ is Rabbit) return 0.0;
                        if(targ is Ratman) return 15.0;
                        if(targ is RhinoBeetle) return 24.2;
                        if(targ is RunningPants) return 10.0;
                        if(targ is StreamingWisp) return 25.0;
                        if(targ is SwampVine) return 12.0;
                        if(targ is Tokoloshe) return 2.0;
                        if(targ is Umkhovu) return 6.0;
                        if(targ is VerdantSprite) return 2.0;
                        if(targ is WanderingCliffStrider) return 15.0;
                        if(targ is WaterLizard) return 8.0;
                        if(targ is Wekufe) return 30.0;
                        if(targ is WildTurkey) return 27.5;
                        if(targ is YoungAlligator) return 15.0;
                        if(targ is ZaythalorAdventurer) return 25.0;

//////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////// Almhara Dungeons Map
//////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////// Black Widow Pit 35.0 -------- 40.0

                        if(targ is DreadSpider) return 35.0;
                        if(targ is GiantBlackWidow) return 30.0;
                        if(targ is PitBloatedWidow) return 40.0;

/////////////////////////////////////// Fungully Grotto Pit 15.0 -------- 20.0

                        if(targ is Corpser) return 15.0;
                        if(targ is Qiraji) return 20.0;

/////////////////////////////////////// Hammerhill Sewers 5.0 -------- 15.0

                        if(targ is GaseousSlime) return 5.0;
                        if(targ is SewerBovine) return 7.0;
                        if(targ is SewerHobo) return 10.0;
                        if(targ is SewerHydra) return 15.0;
                        if(targ is Sewerrat) return 5.0;

/////////////////////////////////////// Iguana Cove 25.0 -------- 50.0

                        if(targ is CavernDrake) return 50.0;
                        if(targ is Lizardman) return 25.0;
                        if(targ is LizardmanGuardian) return 30.0;
                        if(targ is LizardmanRanger) return 35.0;
                        if(targ is LizardmanWizard) return 40.0;
                        if(targ is WaterLizardScout) return 25.0;

/////////////////////////////////////// Mongbat Hideout 10.0 -------- 25.0

                        if(targ is CavernMongbatArcher) return 15.0;
                        if(targ is CavernMongbatBerserker) return 20.0;
                        if(targ is CavernMongbatPlantkeeper) return 15.0;
                        if(targ is CavernMongbatRavager) return 20.0;
                        if(targ is CavernMongbatScout) return 10.0;
                        if(targ is CavernMongbatShaman) return 15.0;

/////////////////////////////////////// Murkmere Dwelling 40.0 -------- 55.0

                        if(targ is AmazonianGuardBreaker) return 55.0;
                        if(targ is Bogling) return 40.0;
                        if(targ is BogThing) return 45.0;
                        if(targ is Quagmire) return 55.0;
                        if(targ is SwampDragon) return 50.0;
                        if(targ is SwampTentacle) return 40.0;
                        if(targ is Treefellow) return 45.0;

/////////////////////////////////////// Stone Burrow Mines 25.0 -------- 45.0

                        if(targ is CavernScorpion) return 25.0;
                        if(targ is Dira) return 35.0;
                        if(targ is DullCopperElemental) return 35.0;
                        if(targ is EarthElemental) return 30.0;
                        if(targ is Sickler) return 40.0;
                        if(targ is SthuoTheMindFlayer) return 45.0;
                        if(targ is StoneBurrowOrcMiner) return 25.0;
                        if(targ is StoneBurrowPatrolUnit) return 35.0;

			double val = (targ.HitsMax * 1.6) + targ.StamMax + targ.ManaMax;

			val += targ.SkillsTotal / 10;

			BaseCreature bc = targ as BaseCreature;

			if ( IsMageryCreature( bc ) )
				val += 100;

			if ( IsFireBreathingCreature( bc ) )
				val += 100;

			if ( IsPoisonImmune( bc ) )
				val += 100;

			if ( targ is VampireBat || targ is VampireBatFamiliar )
				val += 100;

			val += GetPoisonLevel( bc ) * 20;

			if ( val > 700 )
				val = 700 + (int)((val - 700) * (3.0 / 11));

			val /= 10;

			if ( bc != null && bc.IsParagon )
				val += 40.0;

			if ( Core.SE && val > 160.0 )
				val = 160.0;

			return val;
		}

		public double GetDifficultyFor( Mobile targ )
		{
			double val = GetBaseDifficulty( targ );

			if ( m_Quality == InstrumentQuality.Exceptional )
				val -= 10.0;

			if ( m_Slayer != SlayerName.None )
			{
				SlayerEntry entry = SlayerGroup.GetEntryByName( m_Slayer );

				if ( entry != null )
				{
					if ( entry.Slays( targ ) )
						val -= 25.0;
					else if ( entry.Group.OppositionSuperSlays( targ ) )
						val += 25.0;
				}
			}

			if ( m_Slayer2 != SlayerName.None )
			{
				SlayerEntry entry = SlayerGroup.GetEntryByName( m_Slayer2 );

				if ( entry != null )
				{
					if ( entry.Slays( targ ) )
						val -= 25.0;
					else if ( entry.Group.OppositionSuperSlays( targ ) )
						val += 25.0;
				}
			}

			return val;
		}

		public static void SetInstrument( Mobile from, BaseInstrument item )
		{
			m_Instruments[from] = item;
		}

		public BaseInstrument( int itemID, int wellSound, int badlySound ) : base( itemID )
		{
			m_WellSound = wellSound;
			m_BadlySound = badlySound;
			UsesRemaining = Utility.RandomMinMax( InitMinUses, InitMaxUses );
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			int oldUses = m_UsesRemaining;
			CheckReplenishUses( false );

			base.GetProperties( list );

			if ( m_Crafter != null )
				list.Add( 1050043, m_Crafter.Name ); // crafted by ~1_NAME~

			if ( m_Quality == InstrumentQuality.Exceptional )
				list.Add( 1060636 ); // exceptional

			list.Add( 1060584, m_UsesRemaining.ToString() ); // uses remaining: ~1_val~

			if( m_ReplenishesCharges )
				list.Add( 1070928 ); // Replenish Charges

			if( m_Slayer != SlayerName.None )
			{
				SlayerEntry entry = SlayerGroup.GetEntryByName( m_Slayer );
				if( entry != null )
					list.Add( entry.Title );
			}

			if( m_Slayer2 != SlayerName.None )
			{
				SlayerEntry entry = SlayerGroup.GetEntryByName( m_Slayer2 );
				if( entry != null )
					list.Add( entry.Title );
			}

			if( m_UsesRemaining != oldUses )
				Timer.DelayCall( TimeSpan.Zero, new TimerCallback( InvalidateProperties ) );
		}

		public override void OnSingleClick( Mobile from )
		{
			ArrayList attrs = new ArrayList();

			if ( DisplayLootType )
			{
				if ( LootType == LootType.Blessed )
					attrs.Add( new EquipInfoAttribute( 1038021 ) ); // blessed
				else if ( LootType == LootType.Cursed )
					attrs.Add( new EquipInfoAttribute( 1049643 ) ); // cursed
			}

			if ( m_Quality == InstrumentQuality.Exceptional )
				attrs.Add( new EquipInfoAttribute( 1018305 - (int)m_Quality ) );

			if( m_ReplenishesCharges )
				attrs.Add( new EquipInfoAttribute( 1070928 ) ); // Replenish Charges

			// TODO: Must this support item identification?
			if( m_Slayer != SlayerName.None )
			{
				SlayerEntry entry = SlayerGroup.GetEntryByName( m_Slayer );
				if( entry != null )
					attrs.Add( new EquipInfoAttribute( entry.Title ) );
			}

			if( m_Slayer2 != SlayerName.None )
			{
				SlayerEntry entry = SlayerGroup.GetEntryByName( m_Slayer2 );
				if( entry != null )
					attrs.Add( new EquipInfoAttribute( entry.Title ) );
			}

			int number;

			if ( Name == null )
			{
				number = LabelNumber;
			}
			else
			{
				this.LabelTo( from, Name );
				number = 1041000;
			}

			if ( attrs.Count == 0 && Crafter == null && Name != null )
				return;

			EquipmentInfo eqInfo = new EquipmentInfo( number, m_Crafter, false, (EquipInfoAttribute[])attrs.ToArray( typeof( EquipInfoAttribute ) ) );

			from.Send( new DisplayEquipmentInfo( this, eqInfo ) );
		}

		public BaseInstrument( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 3 ); // version

			writer.Write( m_ReplenishesCharges );
			if( m_ReplenishesCharges )
				writer.Write( m_LastReplenished );


			writer.Write( m_Crafter );

			writer.WriteEncodedInt( (int) m_Quality );
			writer.WriteEncodedInt( (int) m_Slayer );
			writer.WriteEncodedInt( (int) m_Slayer2 );

			writer.WriteEncodedInt( (int)UsesRemaining );

			writer.WriteEncodedInt( (int) m_WellSound );
			writer.WriteEncodedInt( (int) m_BadlySound );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 3:
				{
					m_ReplenishesCharges = reader.ReadBool();

					if( m_ReplenishesCharges )
						m_LastReplenished = reader.ReadDateTime();

					goto case 2;
				}
				case 2:
				{
					m_Crafter = reader.ReadMobile();

					m_Quality = (InstrumentQuality)reader.ReadEncodedInt();
					m_Slayer = (SlayerName)reader.ReadEncodedInt();
					m_Slayer2 = (SlayerName)reader.ReadEncodedInt();

					UsesRemaining = reader.ReadEncodedInt();

					m_WellSound = reader.ReadEncodedInt();
					m_BadlySound = reader.ReadEncodedInt();
					
					break;
				}
				case 1:
				{
					m_Crafter = reader.ReadMobile();

					m_Quality = (InstrumentQuality)reader.ReadEncodedInt();
					m_Slayer = (SlayerName)reader.ReadEncodedInt();

					UsesRemaining = reader.ReadEncodedInt();

					m_WellSound = reader.ReadEncodedInt();
					m_BadlySound = reader.ReadEncodedInt();

					break;
				}
				case 0:
				{
					m_WellSound = reader.ReadInt();
					m_BadlySound = reader.ReadInt();
					UsesRemaining = Utility.RandomMinMax( InitMinUses, InitMaxUses );

					break;
				}
			}

			CheckReplenishUses();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( this.Parent != from )
                  {
                        from.SendMessage( "The instrument must be equipped for any serious music playing." ); 
                  }
			else if ( from.BeginAction( typeof( BaseInstrument ) ) )
			{
				SetInstrument( from, this );

				// Delay of 7 second before beign able to play another instrument again
				new InternalTimer( from ).Start();

				if ( CheckMusicianship( from ) )
					PlayInstrumentWell( from );
				else
					PlayInstrumentBadly( from );
			}
			else
			{
				from.SendLocalizedMessage( 500119 ); // You must wait to perform another action
			}
		}

		public static bool CheckMusicianship( Mobile m )
		{
			m.CheckSkill( SkillName.Musicianship, 0.0, 100.0 );

			return ( (m.Skills[SkillName.Musicianship].Value / 100) > Utility.RandomDouble() );
		}

		public void PlayInstrumentWell( Mobile from )
		{
			from.PlaySound( m_WellSound );
		}

		public void PlayInstrumentBadly( Mobile from )
		{
			from.PlaySound( m_BadlySound );
		}

		private class InternalTimer : Timer
		{
			private Mobile m_From;

			public InternalTimer( Mobile from ) : base( TimeSpan.FromSeconds( 6.0 ) )
			{
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				m_From.EndAction( typeof( BaseInstrument ) );
			}
		}
		#region ICraftable Members

		public int OnCraft( int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			Quality = (InstrumentQuality)quality;

			if ( makersMark )
				Crafter = from;

			return quality;
		}

		#endregion
	}
}