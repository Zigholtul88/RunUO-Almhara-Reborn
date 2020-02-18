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
	[CorpseName( "the corpse of Khalahandra" )]
	public class Khalahandra : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Lizardman; } }

		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 20.0 ); //the delay between talks is 20 seconds
		public DateTime m_NextTalk;

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Khalahandra() : base( AIType.AI_Mage, FightMode.Closest, 30, 1, 0.175, 0.350 )
		{
			Name = "Khalahandra";
			Title = "Avarice of Anger";
			Body = 87;
			BaseSoundID = 644;
			Hue = 86;

			SetStr( 439, 489 );
			SetDex( 109 );
			SetInt( 375, 441 );

			SetHits( 2000 );
			SetMana( 1050, 1215 );

			SetDamage( 11, 13 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 5 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.EvalInt, 75.6, 88.9 );
			SetSkill( SkillName.Magery, 93.5, 99.8 );
			SetSkill( SkillName.Meditation, 58.9, 69.5 );
			SetSkill( SkillName.MagicResist, 93.7, 98.2 );
			SetSkill( SkillName.Tactics, 60.3, 67.1 );
			SetSkill( SkillName.Wrestling, 66.8, 67.6 );

			Fame = 750000;
			Karma = -750000;
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 5 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.5 > Utility.RandomDouble() )
			{
				ShootLightningArrow( from );
				Animate( 31, 5, 1, true, false, 0 );
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

                        if ( 0.5 >= Utility.RandomDouble() )
                        {
			        ShootLightningArrow( attacker );
				Animate( 31, 5, 1, true, false, 0 );
                        }
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

                        if ( 0.5 >= Utility.RandomDouble() )
                        {
			        ShootLightningArrow( defender );
				Animate( 31, 5, 1, true, false, 0 );
                        }
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 10 ) && InLOS( m ) && m is PlayerMobile && !m.Hidden ) // check if it's time to talk & mobile in range & in los.
			{
                                m.Send( PlayMusic.GetInstance( MusicName.StygianDragon ) );

				ShootLightningArrow( m );

			        RangePerception = 300;
			        CurrentSpeed = BoostedSpeed;
				this.Combatant = m;

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

//////////////////////////////////////////////////// Shoot Lightning Arrow ////////////////////////////////////////////////////

		#region Randomize
		private static int[] m_ItemID = new int[]
		{
                        8902
		};

		public static int GetRandomItemID()
		{
			return Utility.RandomList( m_ItemID );
		}

		private DateTime m_NextLightningArrow;
		private int m_Thrown;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextLightningArrow )
			{
				ShootLightningArrow( combatant );

				m_Thrown++;

				if ( 0.75 >= Utility.RandomDouble() && (m_Thrown % 2) == 1 ) // 75% chance to quickly shoot another lightning arrow
					m_NextLightningArrow = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
				else
					m_NextLightningArrow = DateTime.Now + TimeSpan.FromSeconds( 15.0 + (10.0 * Utility.RandomDouble()) ); // 15-25 seconds
			}
		}

		public void ShootLightningArrow( Mobile m )
		{
			this.MovingEffect( m, Utility.RandomList( m_ItemID ), 10, 0, false, false );
			this.DoHarmful( m );
			this.PlaySound( 0x20A ); // energy bolt

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
		                m_Mobile.BoltEffect( 0x480 );
				m_Mobile.PlaySound( 0x5CE ); // lightning strike
		                m_Mobile.Hits -= ( Utility.Random( 15, 25 ) );
			}
		}
		#endregion

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawRibs(2), from );
                              corpse.AddCarvedItem(new SerpentScale( Utility.RandomMinMax( 200, 300 )), from );
                              corpse.AddCarvedItem(new OphidianEye(), from);
                              corpse.AddCarvedItem(new TreasureMap(2, Map.Malas ), from );
                              corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 2500, 5000 ) ), from );
                              corpse.AddCarvedItem(new Diamond( Utility.RandomMinMax( 20, 25 ) ), from );

                              from.SendMessage( "You carve up a few raw ribs, hides, an ophidian eye, and somehow a random treasure map along with other junk and what not." );
                              corpse.Carved = true; 
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
                                    m.AddToBackpack(new TreasureMap( 1, Map.Malas ) );
			            m.AddToBackpack( new WhisperingHollowDungeonKey() );
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

		public Khalahandra( Serial serial ) : base( serial )
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

				Gold g = new Gold( 200, 500 );
				
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