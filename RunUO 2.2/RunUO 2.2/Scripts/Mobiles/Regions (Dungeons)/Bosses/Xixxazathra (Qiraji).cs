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
	[CorpseName( "the corpse of Xixxazathra" )]
	public class Xixxazathra : BaseCreature
	{
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 20.0 ); //the delay between talks is 20 seconds
		public DateTime m_NextTalk;

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Xixxazathra() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Xixxazathra";
			Title = "Emissary of Emergence";
			Body = 378;

			SetStr( 596, 620 );
			SetDex( 121, 145 );
			SetInt( 76, 100 );

			SetHits( 3000 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Poison, 30 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, -50 );
			SetResistance( ResistanceType.Cold, 45 );
			SetResistance( ResistanceType.Poison, 45 );
			SetResistance( ResistanceType.Energy, 45 );

			SetSkill( SkillName.MagicResist, 48.9, 69.7 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 177.9, 188.8 );
			SetSkill( SkillName.Wrestling, 188.6, 200.4 );

			Fame = 750000;
			Karma = -750000;

			m_NextAbilityTime = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 2, 5 ) );
		}

		public override int GetIdleSound() { return 0x269; }
		public override int GetAngerSound() { return 0x269; }
		public override int GetAttackSound() { return 0x186; }
		public override int GetHurtSound() { return 0x1BE; } 
		public override int GetDeathSound() { return 0x8E; } 

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 10 ) && InLOS( m ) && m is PlayerMobile && !m.Hidden ) // check if it's time to talk & mobile in range & in los.
			{
                                m.Send( PlayMusic.GetInstance( MusicName.BattleOnStones ) );

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

		private DateTime m_NextAbilityTime;

		public override void OnThink()
		{
			if ( DateTime.Now >= m_NextAbilityTime )
			{
				Mobile combatant = this.Combatant;

				if ( combatant != null && combatant.Map == this.Map && combatant.InRange( this, 12 ) && IsEnemy( combatant ) && !UnderEffect( combatant ) )
				{
					m_NextAbilityTime = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 15 ) );

					if( combatant is BaseCreature )
					{
						BaseCreature bc = (BaseCreature)combatant;

						if( bc.Controlled && bc.ControlMaster != null && !bc.ControlMaster.Deleted && bc.ControlMaster.Alive )
						{
							if ( bc.ControlMaster.Map == this.Map && bc.ControlMaster.InRange( this, 12 ) && !UnderEffect( bc.ControlMaster ) )
							{
								combatant = bc.ControlMaster;
							}
						}
					}

					if( Utility.RandomDouble() < .5 )
					{
						int[][] coord = 
						{
							new int[]{-4,-6}, new int[]{4,-6}, new int[]{0,-8}, new int[]{-5,5}, new int[]{5,5}
						};

						BaseCreature rabid;

						for( int i=0; i<5; i++ )
						{
							switch( i )
							{
								case 0: rabid = new EnragedRabbit( this ); break;
								case 1: rabid = new EnragedHind( this ); break;
								case 2: rabid = new EnragedHart( this ); break;
								case 3: rabid = new EnragedBlackBear( this ); break;
								default: rabid = new EnragedEagle( this ); break;
							}

							rabid.FocusMob = combatant;

							int x = combatant.X + coord[i][0];
							int y = combatant.Y + coord[i][1];

							/*
								Once in a while OSI's dont spawn all 5, and
								I can only attribute this to a bad spawn location
								so I will do this.
							*/

							Point3D loc = new Point3D( x, y,  combatant.Map.GetAverageZ( x, y ));
							if ( combatant.Map.CanSpawnMobile( loc ) )
							{
								rabid.MoveToWorld( loc, combatant.Map ) ;
							}
							else
							{
								rabid.Delete();
							}
						}
                                        this.Say( true, "Arise from your slumber, children of the woodland realm! Aid me and eviserate those whom invoke harm against our home!" );
					}
					else
					{
						this.Say( true, "It is time for my spores to fester upon your mortal flesh!" );
						m_Table[combatant] = Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 10.0 ), new TimerStateCallback( DoEffect ), new object[]{ combatant, 0 } );
					}
				}
			}

			base.OnThink();
		}

		private static Hashtable m_Table = new Hashtable();

		public static bool UnderEffect( Mobile m )
		{
			return m_Table.Contains( m );
		}

		public static void StopEffect( Mobile m, bool message )
		{
			Timer t = (Timer)m_Table[m];

			if ( t != null )
			{
				if ( message )
					m.PublicOverheadMessage( Network.MessageType.Emote, m.SpeechHue, true, "* The open flame begins to scatter away the spores *" );

				t.Stop();
				m_Table.Remove( m );
			}
		}

		public void DoEffect( object state )
		{
			object[] states = (object[])state;

			Mobile m = (Mobile)states[0];
			int count = (int)states[1];

			if ( !m.Alive )
			{
				StopEffect( m, false );
			}
			else
			{
				Torch torch = m.FindItemOnLayer( Layer.TwoHanded ) as Torch;

				if ( torch != null && torch.Burning )
				{
					StopEffect( m, true );
				}
				else
				{
					if ( (count % 4) == 0 )
					{
						m.LocalOverheadMessage( Network.MessageType.Emote, m.SpeechHue, true, "* The spores sting viciously at your flesh! *" );
						m.NonlocalOverheadMessage( Network.MessageType.Emote, m.SpeechHue, true, String.Format( "* {0} is stung viciously by poisonous spores *", m.Name ) );
					}

                                        m.FixedParticles(0x36B0, 1, 14, 0x26BB, 0x3F, 0x7, EffectLayer.Waist);
                                        m.PlaySound(0x229);

					AOS.Damage( m, this, Utility.RandomMinMax( 8, 15 ) - (Core.AOS ? 0 : 10), 0, 0, 0, 100, 0 );

					states[1] = count + 1;

					if ( !m.Alive )
						StopEffect( m, false );
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
                                    m.Say( "Yahoo Watashi Wah Katazae!" );
                                    m.Send( Network.PlayMusic.GetInstance( MusicName.Victory ) );
                                    m.AddToBackpack(new TreasureMap( 2, Map.Malas ) );
			            m.AddToBackpack( new SpecializedForestHartShard() );
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

		public Xixxazathra( Serial serial ) : base( serial )
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