using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Fourth;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a blood elemental corpse" )]
	public class MinorBloodElemental : BaseCreature
	{
		[Constructable]
		public MinorBloodElemental () : base( AIType.AI_Mage, FightMode.Closest, 5, 1, 0.2, 0.4 )
		{
			Name = "a minor blood elemental";
			Body = 159;
			BaseSoundID = 278;

			SetStr( 93, 148 );
			SetDex( 68, 79 );
			SetInt( 32, 43 );

			SetHits( 275, 300 );
			SetMana( 135, 165 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Poison, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 18 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.EvalInt, 40.3, 42.2 );
			SetSkill( SkillName.Magery, 45.0, 50.0 );
			SetSkill( SkillName.Meditation, 15.4, 24.7 );
			SetSkill( SkillName.MagicResist, 29.1, 32.6 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 2500;
			Karma = -2500;

			m_NextAbilityTime = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 2, 5 ) );

			if ( 0.04 > Utility.RandomDouble() )
				PackItem( new Bloodstone() );
		}

		public override bool HasBreath{ get{ return true; } } // magic arrow enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 100; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x36E4; } }
		public override int BreathEffectSound{ get{ return 0x1E5; } }
		public override int BreathAngerSound{ get{ return 0x5DC; } } //play bloodworm_A

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.05 > Utility.RandomDouble() )
			{
				/* Rune Corruption
				 * Start cliloc: 1070846 "The creature magically corrupts your armor!"
				 * Effect: All resistances -70 (lowest 0) for 5 seconds
				 * End ASCII: "The corruption of your armor has worn off"
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if ( timer != null )
				{
					timer.DoExpire();
					defender.SendLocalizedMessage( 1070845 ); // The creature continues to corrupt your armor!
				}
				else
					defender.SendLocalizedMessage( 1070846 ); // The creature magically corrupts your armor!

				List<ResistanceMod> mods = new List<ResistanceMod>();

				if ( Core.ML )
				{
					if ( defender.PhysicalResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Physical, -(defender.PhysicalResistance / 2) ) );

					if ( defender.FireResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Fire, -(defender.FireResistance / 2) ) );

					if ( defender.ColdResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Cold, -(defender.ColdResistance / 2) ) );

					if ( defender.PoisonResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Poison, -(defender.PoisonResistance / 2) ) );

					if ( defender.EnergyResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Energy, -(defender.EnergyResistance / 2) ) );
				}
				else
				{
					if ( defender.PhysicalResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Physical, (defender.PhysicalResistance > 70) ? -70 : -defender.PhysicalResistance ) );

					if ( defender.FireResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Fire, (defender.FireResistance > 70) ? -70 : -defender.FireResistance ) );

					if ( defender.ColdResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Cold, (defender.ColdResistance > 70) ? -70 : -defender.ColdResistance ) );

					if ( defender.PoisonResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Poison, (defender.PoisonResistance > 70) ? -70 : -defender.PoisonResistance ) );

					if ( defender.EnergyResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Energy, (defender.EnergyResistance > 70) ? -70 : -defender.EnergyResistance ) );
				}

				for ( int i = 0; i < mods.Count; ++i )
					defender.AddResistanceMod( mods[i] );

				defender.FixedEffect( 0x37B9, 10, 5 );

				timer = new ExpireTimer( defender, mods, TimeSpan.FromSeconds( 5.0 ) );
				timer.Start();
				m_Table[defender] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private List<ResistanceMod> m_Mods;

			public ExpireTimer( Mobile m, List<ResistanceMod> mods, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
				m_Mods = mods;
				Priority = TimerPriority.TwoFiftyMS;
			}

			public void DoExpire()
			{
				for ( int i = 0; i < m_Mods.Count; ++i )
					m_Mobile.RemoveResistanceMod( m_Mods[i] );

				Stop();
				m_Table.Remove( m_Mobile );
			}

			protected override void OnTick()
			{
				m_Mobile.SendMessage( "The corruption of your armor has worn off" );
				DoExpire();
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem( new Gold( Utility.RandomMinMax( 527, 1512 ) ), from );
                              corpse.AddCarvedItem( new MinorBloodVial( amount ), from );
                              corpse.AddCarvedItem( new ElementalDust( Utility.RandomMinMax( 2, 5 ) ), from );

                              from.SendMessage( "You carve up some elemental dust and also discover a vial of blood." ); 
                              corpse.Carved = true;
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.AlytharrPredator; }
		}

		public override bool IsEnemy( Mobile m )
		{
		        PlayerMobile pm = m as PlayerMobile;

			if ( m is PlayerMobile && m.SkillsTotal >= 5000 )
				return false;

                        if ( m is PlayerVendor || m is TownCrier || m is BaseSpecialCreature )
				return false;

			if ( m is BaseCreature )
			{
				BaseCreature c = (BaseCreature)m;

				if( c.Controlled || c.FightMode == FightMode.Aggressor || c.FightMode == FightMode.Closest || c.FightMode == FightMode.None )

					return false;
			}

			return true;
		}

		private DateTime m_NextAbilityTime;

		private void DoAreaLeech()
		{
			m_NextAbilityTime += TimeSpan.FromSeconds( 2.5 );

			this.Say( true, "Beware, mortals!  You have provoked my wrath!" );
			this.FixedParticles( 0x376A, 10, 10, 9537, 33, 0, EffectLayer.Waist );

			Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerCallback( DoAreaLeech_Finish ) );
		}

		private void DoAreaLeech_Finish()
		{
			ArrayList list = new ArrayList();

			foreach ( Mobile m in this.GetMobilesInRange( 3 ) )
			{
				if ( this.CanBeHarmful( m ) && this.IsEnemy( m ) )
					list.Add( m );
			}

			if ( list.Count == 0 )
			{
				this.Say( true, "Bah! You have escaped my grasp this time, mortal!" );
			}
			else
			{
				double scalar;

				if ( list.Count == 1 )
					scalar = 0.75;
				else if ( list.Count == 2 )
					scalar = 0.50;
				else
					scalar = 0.25;

				for ( int i = 0; i < list.Count; ++i )
				{
					Mobile m = (Mobile)list[i];

					int damage = (int)(m.Hits * scalar);

					damage += Utility.RandomMinMax( -5, 5 );

					if ( damage < 1 )
						damage = 1;

					m.MovingParticles( this, 0x36F4, 1, 0, false, false, 32, 0, 9535,    1, 0, (EffectLayer)255, 0x100 );
					m.MovingParticles( this, 0x0001, 1, 0, false,  true, 32, 0, 9535, 9536, 0, (EffectLayer)255, 0 );

					this.DoHarmful( m );
					this.Hits += AOS.Damage( m, this, damage, 100, 0, 0, 0, 0 );
				}

				this.Say( true, "If I cannot cleanse thy soul, I will destroy it!" );
			}
		}

		private void DoFocusedLeech( Mobile combatant, string message )
		{
			this.Say( true, message );

			Timer.DelayCall( TimeSpan.FromSeconds( 0.5 ), new TimerStateCallback( DoFocusedLeech_Stage1 ), combatant );
		}

		private void DoFocusedLeech_Stage1( object state )
		{
			Mobile combatant = (Mobile)state;

			if ( this.CanBeHarmful( combatant ) )
			{
				this.MovingParticles( combatant, 0x36FA, 1, 0, false, false, 1108, 0, 9533, 1,    0, (EffectLayer)255, 0x100 );
				this.MovingParticles( combatant, 0x0001, 1, 0, false,  true, 1108, 0, 9533, 9534, 0, (EffectLayer)255, 0 );
				this.PlaySound( 0x1FB );

				Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( DoFocusedLeech_Stage2 ), combatant );
			}
		}

		private void DoFocusedLeech_Stage2( object state )
		{
			Mobile combatant = (Mobile)state;

			if ( this.CanBeHarmful( combatant ) )
			{
				combatant.MovingParticles( this, 0x36F4, 1, 0, false, false, 32, 0, 9535, 1,    0, (EffectLayer)255, 0x100 );
				combatant.MovingParticles( this, 0x0001, 1, 0, false,  true, 32, 0, 9535, 9536, 0, (EffectLayer)255, 0 );

				this.PlaySound( 0x209 );
				this.DoHarmful( combatant );
				this.Hits += AOS.Damage( combatant, this, Utility.RandomMinMax( 5, 10 ) - (Core.AOS ? 0 : 10), 100, 0, 0, 0, 0 );
			}
		}

		public override void OnThink()
		{
			if ( DateTime.Now >= m_NextAbilityTime )
			{
				Mobile combatant = this.Combatant;

				if ( combatant != null && combatant.Map == this.Map && combatant.InRange( this, 12 ) )
				{
					m_NextAbilityTime = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 15 ) );

					int ability = Utility.Random( 4 );

					switch ( ability )
					{
						case 0: DoFocusedLeech( combatant, "Thine essence will fill my withering body with strength!" ); break;
						case 1: DoFocusedLeech( combatant, "I rebuke thee, worm, and cleanse thy vile spirit of its tainted blood!" ); break;
						case 2: DoFocusedLeech( combatant, "I devour your life's essence to strengthen my resolve!" ); break;
						case 3: DoAreaLeech(); break;
							// TODO: Resurrect ability
					}
				}
			}

			base.OnThink();
		}

		public override bool OnBeforeDeath( ) //what happens before it dies
		{
			Map map = this.Map; //set variable map to hold the current map

			if ( map != null ) //if the map isn't null (anti crash check) continue
			{
				for ( int x = -8; x <= 8; ++x ) //for 8x8 location
				{
					for ( int y = -8; y <= 8; ++y )
					{
						double dist = Math.Sqrt(x*x+y*y);

						if ( dist <= 8 )
							new GoldTimer( map, X + x, Y + y ).Start(); //spawn gold on timers
					}
				}
			}
			return true;
		}

		public MinorBloodElemental( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		private class GoldTimer : Timer
		{
			private Map m_Map;
			private int m_X, m_Y;

			public GoldTimer( Map map, int x, int y ) : base( TimeSpan.FromSeconds( Utility.RandomDouble() * 10.0 ) )
			{
				m_Map = map;
				m_X = x;
				m_Y = y;
			}

			protected override void OnTick()
			{
				int z = m_Map.GetAverageZ( m_X, m_Y );
				bool canFit = m_Map.CanFit( m_X, m_Y, z, 6, false, false );

				for ( int i = -3; !canFit && i <= 3; ++i )
				{
					canFit = m_Map.CanFit( m_X, m_Y, z + i, 6, false, false );

					if ( canFit )
						z += i;
				}

				if ( !canFit )
					return;

				Gold g = new Gold();

				g.MoveToWorld( new Point3D( m_X, m_Y, z ), m_Map );

				if ( 0.5 >= Utility.RandomDouble() )
				{
					switch ( Utility.Random( 7 ) )
					{
						case 0: // Fire column
						{
						Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x3709, 10, 30, 9966 );
						Effects.PlaySound( g, g.Map, 0x64C ); // cleansingWinds

							break;
						}
						case 1: // Explosion
						{
						Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36BD, 10, 20, 9502 );
						Effects.PlaySound( g, g.Map, 0x5C9 ); // giftofrenewal

							break;
						}
						case 2: // Ball of fire
						{
						Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36FE, 10, 30, 9961 );

							break;
						}
						case 3: // Greater Heal 1
						{
						Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x375A, 10, 20, 9966 );
						Effects.PlaySound( g, g.Map, 0x5C8 ); // etherealvoyage

							break;
						}
						case 4: // Greater Heal 2
						{
						Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x37B9, 10, 30, 9502 );
						Effects.PlaySound( g, g.Map, 0x5C6 ); // essenceofwind
							break;
						}
						case 5: // Greater Heal 3
						{
						Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x376A, 10, 20, 9961 );

							break;
						}
						case 6: // Greater Heal 4
						{
						Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x37C4, 10, 30, 9502 );

							break;
						}
					}
				}
			}
		}
	}
}
