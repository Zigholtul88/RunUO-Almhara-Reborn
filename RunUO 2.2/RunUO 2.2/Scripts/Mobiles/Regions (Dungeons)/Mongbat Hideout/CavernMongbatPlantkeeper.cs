using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a cavern mongbat corpse" )]
	public class CavernMongbatPlantkeeper : BaseCreature
	{
		[Constructable]
		public CavernMongbatPlantkeeper() : base( AIType.AI_Melee, FightMode.Closest, 2, 1, 0.3, 0.6 )
		{
			Name = NameList.RandomName( "mongbat" );
			Title = "the cavern mongbat plant-keeper";
			Body = 39;
			Hue = Utility.RandomList( 1002,1005,1012,1023,1035,1038,1041,1047,1052,1058 );
			BaseSoundID = 422;

			SetStr( 57, 76 );
			SetDex( 46, 60 );
			SetInt( 27, 30 );

			SetHits( 175, 200 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 19 );

			SetSkill( SkillName.MagicResist, 25.9, 30.5 );
			SetSkill( SkillName.Tactics, 40.1, 47.8 );
			SetSkill( SkillName.Wrestling, 47.8, 50.6 );

			Fame = 5500;
			Karma = -5500;

			m_NextAbilityTime = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 2, 5 ) );

			PackGold( 65, 105 );

			PackItem( new GnarledStaff() );

			PackItem( new Engines.Plants.Seed() );
			PackItem( new FishScale( Utility.RandomMinMax( 6, 12 ) ) );
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawRibs(), from );
                              corpse.AddCarvedItem( new Hides(6), from );
                              corpse.AddCarvedItem( new CavernMongbatClaw(), from );

                              from.SendMessage( "You carve up a raw rib, some hides and a mongbat claw." );
                              corpse.Carved = true; 
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
								case 0: rabid = new EnragedDarkRose( this ); break;
								case 1: rabid = new EnragedDesertRose( this ); break;
								case 2: rabid = new EnragedQuagmire( this ); break;
								case 3: rabid = new EnragedSwampVine( this ); break;
								default: rabid = new EnragedSkitteringHopper( this ); break;
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
                                    this.Say( true, "Rejoice men! For tonight we dine in Tartarrix!" );
					}
					else
					{
						this.Say( true, "Pry apart their flesh!" );
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
					m.PublicOverheadMessage( Network.MessageType.Emote, m.SpeechHue, true, "* The open flame begins to scatter away the wasps *" );

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
						m.LocalOverheadMessage( Network.MessageType.Emote, m.SpeechHue, true, "* The wasps sting viciously at your flesh! *" );
						m.NonlocalOverheadMessage( Network.MessageType.Emote, m.SpeechHue, true, String.Format( "* {0} is stung viciously by asshole wasps *", m.Name ) );
					}

					m.FixedParticles( 0x91C, 10, 180, 9539, EffectLayer.Waist );
					m.PlaySound( 0x00E );
					m.PlaySound( 0x1BC );

					AOS.Damage( m, this, Utility.RandomMinMax( 2, 10 ) - (Core.AOS ? 0 : 10), 100, 0, 0, 0, 0 );

					states[1] = count + 1;

					if ( !m.Alive )
						StopEffect( m, false );
				}
			}
		}

		public CavernMongbatPlantkeeper( Serial serial ) : base( serial )
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
	}
}
