using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
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
	[CorpseName( "the corpse of Treikanha" )]
	public class Treikanha : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ArmorIgnore;
		}

		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 10.0 ); //the delay between talks is 20 seconds
		public DateTime m_NextTalk;

		[Constructable]
		public Treikanha() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Treikanha";
			Title = "Dweller of Dark Desires";
                        Body = 401;
                        Female = true;
                        Race = Race.Human;
			Hue = Utility.RandomList( 1025, 1027, 1028, 1029, 1035, 1041, 1049, 1051, 1058 );
                        HairItemID = 8252;
			HairHue = Utility.RandomList( 37, 38, 39, 40, 41 );

			SetStr( 148, 157 );
			SetDex( 106, 122 );
			SetInt( 34, 41 );

			SetHits( 4000 );
			SetMana( 100 );

			SetDamage( 15, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.Anatomy, 57.9, 62.4 );
			SetSkill( SkillName.Fencing, 192.7, 198.1 );
			SetSkill( SkillName.MagicResist, 42.1, 59.9 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Poisoning, 57.5, 62.6 );
			SetSkill( SkillName.Tactics, 193.1, 198.6 );

			Fame = 750000;
			Karma = -750000;

			SpearSpinTimer.SpearSpinList.Add( this );

			AmazonianFighterHelmet helm = new AmazonianFighterHelmet();
			helm.Hue = 138;
			helm.Movable = false;
			AddItem( helm );

			AmazonianFighterBustier chest = new AmazonianFighterBustier();
			chest.Hue = 138;
			chest.Movable = false;
			AddItem( chest );

			AmazonianFighterGloves gloves = new AmazonianFighterGloves();
			gloves.Hue = 138;
			gloves.Movable = false;
			AddItem( gloves );

			AmazonianFighterBelt belt = new AmazonianFighterBelt();
			belt.Hue = 138;
			belt.Movable = false;
			AddItem( belt );

			AmazonianFighterBoots boots = new AmazonianFighterBoots();
			boots.Hue = 138;
			boots.Movable = false;
			AddItem( boots );

			PackGold( 53, 186 );

			AddItem( new Spear() );

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Gold( Utility.RandomMinMax( 105, 425 ) ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new FishScale( Utility.RandomMinMax( 5, 9 ) ) );

			if ( 0.05 > Utility.RandomDouble() )
				pack.DropItem( new Peridot() );

			PackItem( pack );
		}

		public override Poison HitPoison{ get{ return Poison.Lesser; } }
		public override int Meat{ get{ return 1; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool ShowFameTitle{ get{ return false; } }

		public override bool HasBreath{ get{ return true; } } // spear throw enabled

		public override double BreathMinDelay{ get{ return 1.0; } }
		public override double BreathMaxDelay{ get{ return 15.0; } }

		public override int BreathPhysicalDamage{ get{ return 100; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x0F63; } }
		public override int BreathEffectSound{ get{ return 0x5D2; } }
		public override int BreathAngerSound{ get{ return 824; } }

		public override int GetIdleSound() { return 794; } //play female giggle
		public override int GetHurtSound() { return 806; } //play female oomph 3
		public override int GetAngerSound() { return 824; } //play female yell
		public override int GetDeathSound() { return 790; } //play female death 3

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 10 ) && InLOS( m ) && m is PlayerMobile && !m.Hidden ) // check if it's time to talk & mobile in range & in los.
			{
                                m.Send( PlayMusic.GetInstance( MusicName.NorthernForestBattleonStones ) );

				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 2 ) )
				{
					case 0: Say("**");
						break;
					case 1: Say("**"); 
						break;
				};
			}
		}

		public void OnTick()
		{
		        SpearSpinAttack();
			this.Animate( 18, 5, 1, true, false, 0 );
			this.FixedParticles( 0x375A, 10, 15, 5037, EffectLayer.Waist );
		}

	        public class SpearSpinTimer : Timer 
	        {
		        public const bool Enabled = true;
		        public static List<Treikanha> SpearSpinList = new List<Treikanha>();

		        public static void Initialize() 
		        {
			        if (Enabled)
				        new SpearSpinTimer().Start();
		        }

		        public SpearSpinTimer() : base(TimeSpan.FromSeconds( 15.0 ), TimeSpan.FromSeconds( 15.0 )) 
		        {
			        Priority = TimerPriority.OneSecond;
		        }

		        protected override void OnTick() 
		        {
			        foreach (Treikanha treikanha in SpearSpinList)
				        treikanha.OnTick();
		        }
	        }

                public void SpearSpinAttack()
                {
                        List<Mobile> list = new List<Mobile>();

                        foreach ( Mobile m in GetMobilesInRange( 3 ) )
                        {
                             if ( !CanBeHarmful ( m ) )
                             continue;

                             if ( m.Player )
                             list.Add ( m );
                        }

                        foreach ( Mobile m in list )
                        {
                               if ( m == this || !CanBeHarmful( m ) )
                               continue;

                               if ( !m.Player && !( m is BaseCreature && ( (BaseCreature)m).ControlMaster.Player) )
                               continue;

                               if ( m.Player && m.Alive )
                               {
		                    m.BoltEffect( 0x480 );
			            m.PlaySound( 0x220 ); // Earthquake

				    AOS.Damage( m, 50, 100, 0, 0, 0, 0 );
		                    m.Stam -= ( Utility.Random( 45, 85 ) ); 
                               }
                        }
                }

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.4 > Utility.RandomDouble() )
			{
				ThrowSpear( from );
			}
		}

		public void ThrowSpear( Mobile to )
		{
			int damage = 25;
			this.MovingEffect( to, 0x0F63, 10, 0, false, false );
			this.DoHarmful( to );
			this.PlaySound( 0x5D2 ); // throwH
			AOS.Damage( to, this, damage, 100, 0, 0, 0, 0 );
		}

		public override void OnGaveMeleeAttack( Mobile defender ) 
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.2 > Utility.RandomDouble() )
			{
				defender.FixedEffect( 0x37B9, 10, 5 );
                                defender.SendMessage( "You are frozen as Treikanha laughs maniacally." );
			        defender.PlaySound( 0x529 ); // tengu_idle03

				defender.Paralyze( TimeSpan.FromSeconds( 5.0 ) );
 			}
		}

                public void PlayVictoryTheme()
                {
                        List<Mobile> list = new List<Mobile>();

                        foreach ( Mobile m in GetMobilesInRange( 40 ) )
                        {
                             if ( !CanBeHarmful ( m ) )
                             continue;

                             if ( m.Player )
                             list.Add ( m );
                        }

                        foreach ( Mobile m in list )
                        {
                             if ( m == this || !CanBeHarmful( m ) )
                             continue;

                             if ( !m.Player && !( m is BaseCreature && ( (BaseCreature)m).ControlMaster.Player) )
                             continue;

                               if ( m.Player && m.Alive )
                               {
                                    m.Say( "Yahoo Watashi Wah Katazae!" );
                                    m.Send( Network.PlayMusic.GetInstance( MusicName.Victory ) );
                                    m.AddToBackpack(new TreasureMap( 2, Map.Malas ) );
			            m.AddToBackpack( new GuardiansDesertBunkerKey() );
                                    DoHarmful( m );
                               }
                        }
                }

		public override bool OnBeforeDeath( ) //what happens before it dies
		{
		        PlayVictoryTheme();

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

		public Treikanha( Serial serial ) : base( serial )
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

			SpearSpinTimer.SpearSpinList.Add(this);
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

				Gold g = new Gold( 800, 1500 );
				
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