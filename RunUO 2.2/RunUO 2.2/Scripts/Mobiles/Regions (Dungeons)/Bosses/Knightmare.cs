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
	[CorpseName( "the corpse of Knightmare" )]
	public class Knightmare : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 10.0 ); //the delay between talks is 20 seconds
		public DateTime m_NextTalk;

		[Constructable]
		public Knightmare() : base( AIType.AI_Melee, FightMode.Closest, 6, 1, 0.175, 0.350 )
		{
                        Name = "Knightmare";
			Title = "Whispers of the Wind";
			Body = 178;
			Hue = 1391;
			BaseSoundID = 0xA8;

			SetStr( 421, 557 );
			SetDex( 108, 115 );
			SetInt( 111, 139 );

			SetHits( 2150 );

			SetDamage( 8, 18 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 25 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.MagicResist, 48.9, 69.7 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 177.9, 188.8 );
			SetSkill( SkillName.Wrestling, 188.6, 200.4 );

			Fame = 750000;
			Karma = -750000; 
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 10 ) && InLOS( m ) && m is PlayerMobile && !m.Hidden ) // check if it's time to talk & mobile in range & in los.
			{
                                m.Send( PlayMusic.GetInstance( MusicName.PrimevalLich ) );

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

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawRibs( 5 ), from );
                              corpse.AddCarvedItem( new BarbedHides( 200 ), from );
                              corpse.AddCarvedItem( new PookahEye(), from );
                              corpse.AddCarvedItem(new TreasureMap( 2, Map.Malas ), from );
                              corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 2500, 5000 ) ), from );
                              corpse.AddCarvedItem(new Diamond( Utility.RandomMinMax( 20, 25 ) ), from );

                              from.SendMessage( "You carve up 5 ribs, some barbed hides, a pookah eye, and somehow a random treasure map along with other junk and what not." ); 
                              corpse.Carved = true;
			}
                }

		public override bool HasBreath{ get{ return true; } } // energy bolt enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x379F; } }
		public override int BreathEffectSound{ get{ return 0x20A; } }
		public override int BreathAngerSound{ get{ return 0xA8; } }

	        public override void OnDamagedBySpell( Mobile attacker )
	        {
		        base.OnDamagedBySpell( attacker );

                        if ( 0.3 >= Utility.RandomDouble() )
                        this.Lightning();
	        }

                public override void OnGaveMeleeAttack( Mobile defender )
                {
                        base.OnGaveMeleeAttack( defender );

                        if ( 0.3 >= Utility.RandomDouble() )
                        this.Lightning();
                }

                public override void OnGotMeleeAttack( Mobile attacker )
	        {
		        base.OnGotMeleeAttack( attacker );

		        if ( 0.3 >= Utility.RandomDouble() )
                        this.Lightning();
	        }

                public void Lightning()
                {
                        Map map = this.Map;

                        if ( map == null )
                            return;

                        ArrayList targets = new ArrayList();

                        foreach ( Mobile m in this.GetMobilesInRange( 15 ) )
                        {
                                 if ( m == this || !this.CanBeHarmful( m ) )
                                 continue;

                                 if ( m is BaseCreature && ( ( ( BaseCreature )m ).Controlled || ( ( BaseCreature )m ).Summoned || ( ( BaseCreature )m ).Team != this.Team ) )
                                      targets.Add( m );
                                 else if ( m.Player )
                                      targets.Add( m );
                        }

                        this.PlaySound( 528 );

                        for ( int i = 0; i < targets.Count; ++i )
                        {
                                Mobile m = ( Mobile )targets[i];

                                this.DoHarmful( m );

                                AOS.Damage( m, Utility.RandomMinMax( 35, 55 ), 0, 0, 0, 0, 100 );

		                m.FixedParticles( 0x37C4, 10, 15, 1272, 0x496, 0, EffectLayer.Waist );

		                m.BoltEffect( 0x480 );

                                if ( m.Alive && m.Body.IsHuman && !m.Mounted )
                                    m.Animate( 20, 7, 1, true, false, 0 ); // take hit
                        }
                }

		private Timer m_SoundTimer;
		private bool m_HasTeleportedAway;

		public override void OnCombatantChange()
		{
			base.OnCombatantChange();

			if ( Hidden && Combatant != null )
				Combatant = null;
		}

		public virtual void SendTrackingSound()
		{
			if ( Hidden )
			{
				Effects.PlaySound( this.Location, this.Map, 0x2C8 );
				Combatant = null;
			}
			else
			{
				Frozen = false;

				if ( m_SoundTimer != null )
					m_SoundTimer.Stop();

				m_SoundTimer = null;
			}
		}

		public override void OnThink()
		{
			if ( !m_HasTeleportedAway && Hits < (HitsMax / 2) )
			{
				Map map = this.Map;

				if ( map != null )
				{
					// try 10 times to find a teleport spot
					for ( int i = 0; i < 10; ++i )
					{
						int x = X + (Utility.RandomMinMax( 5, 10 ) * (Utility.RandomBool() ? 1 : -1));
						int y = Y + (Utility.RandomMinMax( 5, 10 ) * (Utility.RandomBool() ? 1 : -1));
						int z = Z;

						if ( !map.CanFit( x, y, z, 16, false, false ) )
							continue;

						Point3D from = this.Location;
						Point3D to = new Point3D( x, y, z );

						if ( !InLOS( to ) )
							continue;

						this.Location = to;
						this.ProcessDelta();
						this.Hidden = false;
						this.Combatant = null;

						Effects.SendLocationParticles( EffectItem.Create( from, map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
						Effects.SendLocationParticles( EffectItem.Create(   to, map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 5023 );

						Effects.PlaySound( to, map, 0x1FE );

						m_HasTeleportedAway = true;
						m_SoundTimer = Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 2.5 ), new TimerCallback( SendTrackingSound ) );

						Frozen = true;

						break;
					}
				}
			}

			base.OnThink();
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
                                    m.Say( "Yahoo Watashi Wah Katazae!" );
                                    m.Send( Network.PlayMusic.GetInstance( MusicName.Victory ) );
                                    m.AddToBackpack(new TreasureMap(1, Map.Malas ) );
			            m.AddToBackpack( new PassageOfLostSoulsKey() );
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

		public Knightmare( Serial serial ) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
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

				Gold g = new Gold( 500, 1000 );
				
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