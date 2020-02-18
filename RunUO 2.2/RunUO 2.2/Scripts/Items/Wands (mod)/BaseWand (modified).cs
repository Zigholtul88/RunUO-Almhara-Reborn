using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;

namespace Server.Items
{
	public enum WandEffect
	{
		Clumsiness,
		Identification,
		Healing,
		Feeblemindedness,
		Weakness,
		MagicArrow,
		Harming,
		Fireball,
		GreaterHealing,
		Lightning,
                CreateFood,
                NightSight,
		ReactiveArmor,
                Agility,
                Cunning,
                Cure,
                Protection,
                RemoveTrap,
                MagicTrap,
                Strength,
                Bless,
                MagicLock,
                Poison,
                Unlock,
                Telekinesis,
                Teleport,
                WallOfStone, 
                ArchCure,
                ArchProtection, 
                Curse,
                Recall,
                FireField,
                Incognito,
                MindBlast,
                Paralyze,
                PoisonField,
                MagicReflect,
                DispelField,
                BladeSpirits,
                SummonCreature,
                Dispel,
                EnergyBolt,
                Explosion,
                Invisibility,
                Mark,
                MassCurse,
                ParalyzeField,
                Reveal,
                ChainLightning,
                EnergyField,
                FlameStrike,
                GateTravel,
                ManaVampire,
                MassDispel,
                MeteorSwarm,
                Polymorph,
                AirElemental,
                EarthElemental,
                Earthquake,
                EnergyVortex,
                FireElemental, 
                Resurrection,
                SummonDaemon,
                WaterElemental, 
                ManaDraining
                
	}

	public abstract class BaseWand : BaseBashing
	{
		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 100; } }
                
		private WandEffect m_WandEffect;
		private int m_Charges;
                public int MaxCharges{ get{ return 100; } }  // charges added

		public virtual TimeSpan GetUseDelay{ get{ return TimeSpan.FromSeconds( 4.0 ); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public WandEffect Effect
		{
			get{ return m_WandEffect; }
			set{ m_WandEffect = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set{ m_Charges = value; InvalidateProperties(); }
		}

		public BaseWand( WandEffect effect, int minCharges, int maxCharges ) : base( Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ) )
		{
			Weight = 1.0;
			Effect = effect;
			Charges = Utility.RandomMinMax( minCharges, maxCharges );
		}

		public void ConsumeCharge( Mobile from )
		{
			--Charges;

			if ( Charges == 0 )
				from.SendLocalizedMessage( 1019073 ); // This item is out of charges.

			ApplyDelayTo( from );
		}

		public BaseWand( Serial serial ) : base( serial )
		{
		}

		public virtual void ApplyDelayTo( Mobile from )
		{
			from.BeginAction( typeof( BaseWand ) );
			Timer.DelayCall( GetUseDelay, new TimerStateCallback( ReleaseWandLock_Callback ), from );
		}

		public virtual void ReleaseWandLock_Callback( object state )
		{
			((Mobile)state).EndAction( typeof( BaseWand ) );
		}

		public override void OnDoubleClick( Mobile from )
		{
                base.OnDoubleClick( from );
			if ( !from.CanBeginAction( typeof( BaseWand ) ) )
				return;

			if ( Parent == from )
			{
				if ( Charges > 0 )
					OnWandUse( from );
				else
					from.SendLocalizedMessage( 1019073 ); // This item is out of charges.
			}
			else
			{
				from.SendLocalizedMessage( 502641 ); // You must equip this item to use it.
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( (int) m_WandEffect );
			writer.Write( (int) m_Charges );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_WandEffect = (WandEffect)reader.ReadInt();
					m_Charges = (int)reader.ReadInt();

					break;
				}
			}
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			switch ( m_WandEffect )
			{
				case WandEffect.Clumsiness:			list.Add( 1017326, m_Charges.ToString() ); break; // clumsiness charges: ~1_val~
				case WandEffect.Identification:		list.Add( 1017350, m_Charges.ToString() ); break; // identification charges: ~1_val~
				case WandEffect.Healing:			list.Add( 1017329, m_Charges.ToString() ); break; // healing charges: ~1_val~
				case WandEffect.Feeblemindedness:	list.Add( 1017327, m_Charges.ToString() ); break; // feeblemind charges: ~1_val~
				case WandEffect.Weakness:			list.Add( 1017328, m_Charges.ToString() ); break; // weakness charges: ~1_val~
				case WandEffect.MagicArrow:			list.Add( 1060492, m_Charges.ToString() ); break; // magic arrow charges: ~1_val~
				case WandEffect.Harming:			list.Add( 1017334, m_Charges.ToString() ); break; // harm charges: ~1_val~
				case WandEffect.Fireball:			list.Add( 1060487, m_Charges.ToString() ); break; // fireball charges: ~1_val~
				case WandEffect.GreaterHealing:		list.Add( 1017330, m_Charges.ToString() ); break; // greater healing charges: ~1_val~
				case WandEffect.Lightning:			list.Add( 1060491, m_Charges.ToString() ); break; // lightning charges: ~1_val~
				case WandEffect.ManaDraining:		list.Add( 1017339, m_Charges.ToString() ); break; // mana drain charges: ~1_val~
                               //new wands
                                case WandEffect.CreateFood:		list.Add( 1060658, "CreateFood charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.NightSight:		list.Add( 1060658, "NightSight charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.ReactiveArmor:		list.Add( 1060658, "Reactive charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Agility:		list.Add( 1060658, "Agility charges\t{0}", m_Charges.ToString() ); break; 
                                case WandEffect.Cunning:		list.Add( 1060658, "Cunning charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Cure:		        list.Add( 1060658, "Cure charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Protection:		list.Add( 1060658, "Protection charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.RemoveTrap:		list.Add( 1060658, "MagicUNTrap charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.MagicTrap:		list.Add( 1060658, "MagicTrap charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Strength:		list.Add( 1060658, "Strength charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Bless:		        list.Add( 1060658, "Bless charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.MagicLock:		list.Add( 1060658, "MagicLock charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Poison:		        list.Add( 1060658, "Poison charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Telekinesis:		list.Add( 1060658, "Telekinesis charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Teleport:		list.Add( 1060658, "Teleport charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Unlock:		        list.Add( 1060658, "Unlock charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.WallOfStone:		list.Add( 1060658, "WallOfStone charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.ArchCure:		list.Add( 1060658, "ArchCure charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.ArchProtection:		list.Add( 1060658, "ArchProtection charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Curse:		        list.Add( 1060658, "Curse charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Recall:		        list.Add( 1060658, "Recall charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.FireField:		list.Add( 1060658, "FireField charges\t{0}", m_Charges.ToString() ); break; 
                                case WandEffect.Incognito:		list.Add( 1060658, "Incognito charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.MindBlast:		list.Add( 1060658, "MindBlast charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Paralyze:		list.Add( 1060658, "Paralyze charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.PoisonField:		list.Add( 1060658, "PoisonField charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.MagicReflect:		list.Add( 1060658, "MagicReflect charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.DispelField:		list.Add( 1060658, "DispelField charges\t{0}", m_Charges.ToString() ); break; 
                                case WandEffect.SummonCreature:		list.Add( 1060658, "SummonCreature charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.BladeSpirits:		list.Add( 1060658, "BladeSpirits charges\t{0}", m_Charges.ToString() ); break;  
                                case WandEffect.Dispel:		        list.Add( 1060658, "Dispel charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.EnergyBolt:		list.Add( 1060658, "EnergyBolt charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Explosion:		list.Add( 1060658, "Invisibility charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Invisibility:		list.Add( 1060658, "PoisonField charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Mark:		        list.Add( 1060658, "Mark charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.MassCurse:		list.Add( 1060658, "MassCurse charges\t{0}", m_Charges.ToString() ); break; 
                                case WandEffect.ParalyzeField:		list.Add( 1060658, "ParalyzeField charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Reveal:		        list.Add( 1060658, "Reveal charges\t{0}", m_Charges.ToString() ); break;  
                                case WandEffect.ChainLightning:		list.Add( 1060658, "ChainLightning charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.EnergyField:		list.Add( 1060658, "EnergyField charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.FlameStrike:		list.Add( 1060658, "FlameStrike charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.GateTravel:		list.Add( 1060658, "GateTravel charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.ManaVampire:		list.Add( 1060658, "ManaVampire charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.MassDispel:		list.Add( 1060658, "MassDispel charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.MeteorSwarm:		list.Add( 1060658, "MeteorSwarm charges\t{0}", m_Charges.ToString() ); break; 
                                case WandEffect.Polymorph:		list.Add( 1060658, "Polymorph charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.AirElemental:		list.Add( 1060658, "AirElemental charges\t{0}", m_Charges.ToString() ); break;  
                                case WandEffect.EarthElemental:		list.Add( 1060658, "EarthElemental charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Earthquake:		list.Add( 1060658, "Earthquake charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.EnergyVortex:		list.Add( 1060658, "EnergyVortex charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.FireElemental:		list.Add( 1060658, "FireElemental charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.Resurrection:		list.Add( 1060658, "Resurrection charges\t{0}", m_Charges.ToString() ); break;
                                case WandEffect.SummonDaemon:		list.Add( 1060658, "SummonDaemon charges\t{0}", m_Charges.ToString() ); break; 
                                case WandEffect.WaterElemental:		list.Add( 1060658, "WaterElemental charges\t{0}", m_Charges.ToString() ); break;
                           //     case WandEffect.Reveal:		        list.Add( 1060658, "Reveal charges\t{0}", m_Charges.ToString() ); break;                                        

			}
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

			if ( !Identified )
			{
				attrs.Add( new EquipInfoAttribute( 1038000 ) ); // Unidentified
			}
			else
			{
				int num = 0;

				switch ( m_WandEffect )
				{
					case WandEffect.Clumsiness:		 num = 3002011; break;
					case WandEffect.Identification:		 num = 1044063; break;
					case WandEffect.Healing:		 num = 3002014; break;
					case WandEffect.Feeblemindedness:	 num = 3002013; break;
					case WandEffect.Weakness:		 num = 3002018; break;
					case WandEffect.MagicArrow:		 num = 3002015; break;
					case WandEffect.Harming:		 num = 3002022; break;
					case WandEffect.Fireball:		 num = 3002028; break;
					case WandEffect.GreaterHealing:		 num = 3002039; break;
					case WandEffect.Lightning:		 num = 3002040; break;
					case WandEffect.ManaDraining:		 num = 3002041; break;
                                        case WandEffect.CreateFood:		 num = 3002012; break;
                                        case WandEffect.NightSight:		 num = 3002016; break;
                                        case WandEffect.ReactiveArmor:		 num = 3002017; break;
                                        case WandEffect.Agility:		 num = 3002019; break;
                                        case WandEffect.Cunning:		 num = 3002020; break; 
                                        case WandEffect.Cure:		         num = 3002021; break;  
                                        case WandEffect.Protection:		 num = 3002025; break;  
                                        case WandEffect.RemoveTrap:		 num = 3002024; break; 
                                        case WandEffect.MagicTrap:		 num = 3002023; break;  
                                        case WandEffect.Strength:		 num = 3002026; break; 
                                        case WandEffect.Bless:		         num = 3002027; break;
                                        case WandEffect.MagicLock:		 num = 3002029; break;
                                        case WandEffect.Poison:		         num = 3002030; break; 
                                        case WandEffect.Telekinesis:		 num = 3002031; break;  
                                        case WandEffect.Teleport:		 num = 3002032; break;  
                                        case WandEffect.Unlock:		         num = 3002033; break; 
                                        case WandEffect.WallOfStone:		 num = 3002034; break;  
                                        case WandEffect.ArchCure:		 num = 3002035; break;  
                                        case WandEffect.ArchProtection:		 num = 3002036; break;  
                                        case WandEffect.Curse:		         num = 3002037; break;  
                                        case WandEffect.Recall:		         num = 3002042; break; 
                                        case WandEffect.FireField:		 num = 3002038; break; 
                                        case WandEffect.Incognito:		 num = 3002045; break;  
                                        case WandEffect.MindBlast:		 num = 3002047; break;  
                                        case WandEffect.Paralyze:		 num = 3002048; break;  
                                        case WandEffect.PoisonField:		 num = 3002049; break;  
                                        case WandEffect.MagicReflect:		 num = 3002046; break; 
                                        case WandEffect.DispelField:		 num = 3002044; break; 
                                        case WandEffect.SummonCreature:		 num = 3002050; break;   
                                        case WandEffect.BladeSpirits:		 num = 3002043; break; 
                                        case WandEffect.Dispel:		         num = 3002051; break;  
                                        case WandEffect.EnergyBolt:		 num = 3002052; break;  
                                        case WandEffect.Explosion:		 num = 3002053; break;  
                                        case WandEffect.Invisibility:		 num = 3002054; break;  
                                        case WandEffect.Mark:	        	 num = 3002055; break; 
                                        case WandEffect.MassCurse:		 num = 3002056; break; 
                                        case WandEffect.ParalyzeField:		 num = 3002057; break;   
                                        case WandEffect.Reveal:		         num = 3002058; break; 
                                        case WandEffect.ChainLightning:		 num = 3002059; break;  
                                        case WandEffect.EnergyField:		 num = 3002060; break;  
                                        case WandEffect.FlameStrike:		 num = 3002061; break;  
                                        case WandEffect.GateTravel:		 num = 3002062; break;  
                                        case WandEffect.ManaVampire:		 num = 3002063; break; 
                                        case WandEffect.MassDispel:		 num = 3002064; break; 
                                        case WandEffect.MeteorSwarm:		 num = 3002065; break;   
                                        case WandEffect.Polymorph:		 num = 3002066; break; 
                                        case WandEffect.AirElemental:		 num = 3002070; break;  
                                        case WandEffect.EarthElemental:		 num = 3002072; break;  
                                        case WandEffect.Earthquake:		 num = 3002067; break;  
                                        case WandEffect.EnergyVortex:		 num = 3002068; break;  
                                        case WandEffect.FireElemental:	       	 num = 3002073; break; 
                                        case WandEffect.Resurrection:		 num = 3002069; break; 
                                        case WandEffect.SummonDaemon:		 num = 3002071; break;   
                                        case WandEffect.WaterElemental:		 num = 3002074; break;
                                        
				}

				if ( num > 0 )
					attrs.Add( new EquipInfoAttribute( num, m_Charges ) );
			}

			int number;

			if ( Name == null )
			{
				number = 1017085;
			}
			else
			{
				this.LabelTo( from, Name );
				number = 1041000;
			}

			if ( attrs.Count == 0 && Crafter == null && Name != null )
				return;

			EquipmentInfo eqInfo = new EquipmentInfo( number, Crafter, false, (EquipInfoAttribute[])attrs.ToArray( typeof( EquipInfoAttribute ) ) );

			from.Send( new DisplayEquipmentInfo( this, eqInfo ) );
		}

		public void Cast( Spell spell )
		{
			bool m = Movable;

			Movable = false;
			spell.Cast();
			Movable = m;
		}

		public virtual void OnWandUse( Mobile from )
		{
			from.Target = new WandTarget( this );
		}

		public virtual void DoWandTarget( Mobile from, object o )
		{
			if ( Deleted || Charges <= 0 || Parent != from || o is StaticTarget || o is LandTarget )
				return;

			if ( OnWandTarget( from, o ) )
				ConsumeCharge( from );
		}

		public virtual bool OnWandTarget( Mobile from, object o )
		{
			return true;
		}
	}
}