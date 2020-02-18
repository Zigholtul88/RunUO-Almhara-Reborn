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
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a turdy corpse" )]	
	public class Turdy : BaseAssholeEnemy
	{
                private readonly Timer m_Timer;

		[Constructable]
		public Turdy() : base( AIType.AI_Animal, FightMode.Closest, 16, 1, 0.175, 0.350 )
		{
			Name = "a turdy";
			Body = 6;
                        Hue = 1;

			SetStr( 12, 17 );
			SetDex( 9, 14 );
			SetInt( 5, 8 );

			SetHits( 500 );
			SetMana( 0 );

			SetDamage( 1 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, -50 );
			SetResistance( ResistanceType.Fire, -50 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, -50 );
			SetResistance( ResistanceType.Energy, -50 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 0.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 120.0 );

			Fame = 10000;
			Karma = -10000;

                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();

			FlyTimer.FlyList.Add( this );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			base.OnMovement( m, oldLocation );

                        if ( m.Alive )
                        {
			        if ( InRange( m.Location, 100 ) && !InRange( oldLocation, 100 ) && !m.Hidden )
			        {
			                RangePerception = 200;
				        this.Combatant = m;
                                }
                        }
                }

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( to is BaseCreature || 
                       to is BaseVendor ||
                       to is BaseGuardian )
				damage *= 9999;
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from is BaseCreature || 
                       from is BaseVendor ||
                       from is BaseGuardian )
				damage = 0; // no melee damage
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

			      from.PlaySound( from.Female ? 792 : 1064 );
			      from.Say( "*farts*" );
			}
                }

		public void OnTick()
		{
			Effects.PlaySound(Location, Map, Utility.RandomList( 0x428,1053,1086,0xA8,0x99,0x3F3,0x462,0xC9,0xCA,0xCB,0xCC,0xD6,0xE5,846,0x21D,0x162,0x163,0x270,1511,1508,1510,1509,456,0xC9,0xCA,0xCB,0x26B,0x5A,0x164,0x187,0x1BA,422,0x388,1320,1354,0x275,0xA3,0xC4,0x64,0x69,0x6E,0x78,0x4D7,0xD9,0x99,0x9E,0x82,0x83,0x84,0x277,0x270,0x273,0x279,0x53D,0x53E,0x53F,0x540,0x541,0x542,0x543,0x544,0x545,0x546,0x547,0x548,0x549,0x54A,0x54B,0x54E,0x54F,0x551,0x552,0x553,0x554,0x555,0x556,0x558,0x55A,0x55B,0x55D,0x55E,0x55F,0x561,0x566,0x568,0x569 ) );
		}

	        public class FlyTimer : Timer 
	        {
		        public const bool Enabled = true;
		        public static List<Turdy> FlyList = new List<Turdy>();

		        public static void Initialize() 
		        {
			        if (Enabled)
				        new FlyTimer().Start();
		        }

		        public FlyTimer() : base(TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 )) 
		        {
			        Priority = TimerPriority.OneSecond;
		        }

		        protected override void OnTick() 
		        {
			        foreach (Turdy turdy in FlyList)
				        turdy.OnTick();
		        }
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
							new CheeseWheelTimer( map, X + x, Y + y ).Start(); //spawn cheese on timers
					}
				}
			}
			return true;
		}

		public Turdy( Serial serial ) : base( serial )
		{
                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();
		}

                public override void OnDelete()
                {
                        this.m_Timer.Stop();

                        base.OnDelete();
                }

		public override int GetIdleSound() { return 0x0D1; }
		public override int GetAngerSound() { return 0x0D2; }
		public override int GetAttackSound() { return 0x0D3; }
		public override int GetHurtSound() { return 0x0D4; }
		public override int GetDeathSound() { return 0x0D5; }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			FlyTimer.FlyList.Add(this);
		}

		private class InternalTimer : Timer
		{
			private Turdy m_Owner;
			private int m_Count = 0;

			public InternalTimer( Turdy owner ) : base( TimeSpan.FromSeconds( 0.1 ), TimeSpan.FromSeconds( 0.1 ) )
			{
				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if ( (m_Count++ & 0x30) == 0 )
				{
					m_Owner.Direction = (Direction)(Utility.Random( 16 ) | 0x80);
				}

				m_Owner.Move( m_Owner.Direction );
			}
		}

//////////////////////////////////////////////////////// Spawn Cheese Wheel ////////////////////////////////////////////////////////
		private class CheeseWheelTimer : Timer
		{
			private Map m_Map;
			private int m_X, m_Y;

			public CheeseWheelTimer( Map map, int x, int y ) : base( TimeSpan.FromSeconds( Utility.RandomDouble() * 60.0 ) )
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

				CheeseWheel c = new CheeseWheel();
				
				c.MoveToWorld( new Point3D( m_X, m_Y, z ), m_Map );

				if ( 0.5 >= Utility.RandomDouble() )
				{
					switch ( Utility.Random( 7 ) )
					{
						case 0: // Fire column
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x3709, 10, 30, 9966 );
						Effects.PlaySound( c, c.Map, 782 ); // female burp

							break;
						}
						case 1: // Explosion
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x36BD, 10, 20, 9502 );
						Effects.PlaySound( c, c.Map, 792 ); // female fart

							break;
						}
						case 2: // Ball of fire
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x36FE, 10, 30, 9961 );
						Effects.PlaySound( c, c.Map, 1064 ); // male fart

							break;
						}
						case 3: // Greater Heal 1
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x375A, 10, 20, 9966 );
						Effects.PlaySound( c, c.Map, 1095 ); // male whistle

							break;
						}
						case 4: // Greater Heal 2
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x37B9, 10, 30, 9502 );
						Effects.PlaySound( c, c.Map, 1053 ); // male burp

							break;
						}
						case 5: // Greater Heal 3
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x376A, 10, 20, 9961 );
						Effects.PlaySound( c, c.Map, 783 ); // female woohoo

							break;
						}
						case 6: // Greater Heal 4
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x37C4, 10, 30, 9502 );
						Effects.PlaySound( c, c.Map, 821 ); // female whistle

							break;
						}
					}
				}
			}
		}
	}
}