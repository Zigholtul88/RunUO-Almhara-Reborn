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
	[CorpseName( "the corpse of Nyeenaku" )]
	public class Nyeenakuu : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 10.0 ); //the delay between talks is 20 seconds
		public DateTime m_NextTalk;

		[Constructable]
		public Nyeenakuu() : base( AIType.AI_Melee, FightMode.Closest, 30, 1, 0.175, 0.350 )
		{
			Name = "Nyeenakuu";
			Title = "Visage of the Verite";
			Body = 39;
			Hue = 0x455;
			BaseSoundID = 0x9E;

			SetStr( 197, 218 );
			SetDex( 104, 117 );
			SetInt( 78, 92 );

			SetHits( 1000 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.Anatomy, 50.0 );
			SetSkill( SkillName.Tactics, 150.0 );
			SetSkill( SkillName.Wrestling, 150.0 );

			Fame = 500000;
			Karma = -500000;

                        Flying = true;
			AOETimer.AOEList.Add( this );
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 10 ) && InLOS( m ) && m is PlayerMobile && !m.Hidden ) // check if it's time to talk & mobile in range & in los.
			{
                                m.Send( PlayMusic.GetInstance( MusicName.RoyalCity ) );

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
			if ( !Flying )
                        {
		                JunkAoeAttack();

                                Flying = true;
			        CurrentSpeed = BoostedSpeed;
				Say( "YWARRRGGH!!!!" );
				PlaySound( 0x658 ); // spellPlague
				PlaySound( 0x028 ); // thundr01
				PlaySound( 0x028 ); // thundr01
				PlaySound( 0x4D5 ); // defense mastery

				this.FixedParticles( 0x3735, 1, 30, 0x251F, EffectLayer.Waist );
				this.FixedParticles( 0x3709, 1, 30, 0x455, EffectLayer.Waist );
                        }
		}

	        public class AOETimer : Timer 
	        {
		        public const bool Enabled = true;
		        public static List<Nyeenakuu> AOEList = new List<Nyeenakuu>();

		        public static void Initialize() 
		        {
			        if (Enabled)
				        new AOETimer().Start();
		        }

		        public AOETimer() : base(TimeSpan.FromMinutes( 1.0 ), TimeSpan.FromMinutes( 1.0 )) 
		        {
			        Priority = TimerPriority.OneSecond;
		        }

		        protected override void OnTick() 
		        {
			        foreach (Nyeenakuu nyeenakuu in AOEList)
				        nyeenakuu.OnTick();
		        }
	        }

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( to is BaseCreature ) 
				damage *= 3;
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawRibs(5), from );
                              corpse.AddCarvedItem(new Hides(12), from );
                              corpse.AddCarvedItem(new CavernMongbatClaw(), from );
                              corpse.AddCarvedItem(new TreasureMap(2, Map.Malas ), from );
                              corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 3500, 5000 ) ), from );
                              corpse.AddCarvedItem(new Diamond( Utility.RandomMinMax( 10, 20 ) ), from );
                              corpse.AddCarvedItem(new MongbatHideoutBossChampionChest(), from );

                              from.SendMessage( "You carve up a few raw ribs, hides, a mongbat claw, and somehow a random treasure map along with other junk and what not." );
                              corpse.Carved = true; 
			}
                }

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.5 > Utility.RandomDouble() )
			{
				ThrowJunk( from );
			}

			if ( Flying )
			{
                                Flying = false;
				Say( "NARRRRFFFF!!!" );
				this.FixedParticles( 0, 10, 0, 0x2522, EffectLayer.Waist );
				CurrentSpeed = PassiveSpeed;
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( attacker != null && attacker.Alive && attacker.Weapon is BaseRanged )
			{
			        if ( Flying )
			        {
				     Say( "NARRRRFFFF!!!" );
				     this.FixedParticles( 0, 10, 0, 0x2522, EffectLayer.Waist );
                                     Flying = false;
				     CurrentSpeed = PassiveSpeed;
			        }
			}
			else if ( Flying )
			{
				PlaySound( 0x238 );
				this.FixedParticles( 0x376A, 20, 10, 0x2530, EffectLayer.Waist );
			}
		}

                public override void OnGaveMeleeAttack( Mobile defender )
                {
                        base.OnGaveMeleeAttack( defender );

                        if (0.5 >= Utility.RandomDouble())
		                ThrowJunk( defender );
                }

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( Flying )
				damage = 0; // little melee damage when flying
                }

//////////////////////////////////////////////////// Throw Junk ////////////////////////////////////////////////////

		#region Randomize
		private static int[] m_ItemID = new int[]
		{
3097, 3098, 3215, 3644, 3646, 3647, 3650, 3651, 3365, 3703, 3710, 3715, 3799, 3800, 3823, 3897, 3942, 3944, 4006, 4015, 4016, 4029, 4030, 4170, 4453, 4454, 4457, 4550, 4551, 4555, 4604, 4643, 4963, 4964, 4966, 5030, 5035, 5367, 5369, 11594, 11696, 11739, 15119, 16894, 16895, 17074, 14458, 14459, 14470, 14473, 14474, 14487, 14488, 14493, 14494, 14497, 14498, 14520, 14533
		};

		public static int GetRandomItemID()
		{
			return Utility.RandomList( m_ItemID );
		}

		private DateTime m_NextJunk;
		private int m_Thrown;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextJunk )
			{
				ThrowJunk( combatant );

				m_Thrown++;

				if ( 0.75 >= Utility.RandomDouble() && (m_Thrown % 2) == 1 ) // 75% chance to quickly throw another piece of junk
					m_NextJunk = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
				else
					m_NextJunk = DateTime.Now + TimeSpan.FromSeconds( 15.0 + (10.0 * Utility.RandomDouble()) ); // 15-25 seconds
			}
		}

		public void ThrowJunk( Mobile m )
		{
			this.MovingEffect( m, Utility.RandomList( m_ItemID ), 10, 0, false, false );
			this.DoHarmful( m );
			this.PlaySound( 0x5D2 ); // throwH

			new InternalTimer( m, this ).Start();
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile, m_From;

			public InternalTimer( Mobile m, Mobile from ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				m_Mobile.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
				m_Mobile.PlaySound( 0x307 );

				m_Mobile.PlaySound( 0x11D );
				AOS.Damage( m_Mobile, m_From, Utility.RandomMinMax( 5, 25 ), 100, 0, 0, 0, 0 );
			}
		}
		#endregion

                public void JunkAoeAttack()
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
				    ThrowJunk( m );
                                    DoHarmful( m );

                                    // Flame Strike
				    m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
				    m.PlaySound( 0x208 );

                                    // Explosion
				    m.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
				    m.PlaySound( 0x307 );

		                    m.BoltEffect( 0x480 );

		                    m.Hits -= ( Utility.Random( 25, 35 ) ); 
		                    m.Stam -= ( Utility.Random( 15, 25 ) );
		                    m.Mana -= ( Utility.Random( 15, 25 ) ); 
                               }
                        }
                }

                public void PlayVictoryTheme()
                {
                        List<Mobile> list = new List<Mobile>();

                        foreach ( Mobile m in GetMobilesInRange( 50 ) )
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
			               PlayerMobile pm = m as PlayerMobile;

                                       DoHarmful( m );

                                       pm.Send( Network.PlayMusic.GetInstance( MusicName.Victory ) );
			               pm.AddToBackpack( new AgurastAscensionKey() );

                                       pm.Exp += 5000;
                                       pm.KillExp += 5000;

                                       pm.SendMessage("You've gained 5000 exp.");

                                       if (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
                                       {
                                               Actions.DoLevel(pm, new Setup());
                                       }
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

		public Nyeenakuu( Serial serial ) : base( serial )
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

		     AOETimer.AOEList.Add(this);
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

				Gold g = new Gold( 100, 500 );
				
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
