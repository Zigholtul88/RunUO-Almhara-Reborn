using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Misc;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a myconid corpse" )]
	public class Myconid : BaseCreature
	{
		[Constructable]
		public Myconid() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a myconid";
			Body = 137;
			BaseSoundID = 0x451;

			SetStr( 136, 155 );
			SetDex( 68, 83 );
			SetInt( 26, 40 );

			SetHits( 215, 347 );
			SetMana( 0 );

			SetDamage( 1, 4 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.MagicResist, 42.2, 54.7 );
			SetSkill( SkillName.Tactics, 76.4, 81.8 );
			SetSkill( SkillName.Wrestling, 59.9, 69.9 );

			Fame = 6500;
			Karma = -6500;

			m_NextAbilityTime = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 2, 5 ) );

                        PackGold( 205, 307 ); 

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Carrot( Utility.RandomMinMax( 3, 5 ) ) );
			pack.DropItem( new FertileDirt( Utility.RandomMinMax( 7, 16 ) ) );

			if ( 0.05 > Utility.RandomDouble() )
				pack.DropItem( Loot.RandomShield() );

			if ( 0.05 > Utility.RandomDouble() )
				pack.DropItem( Loot.RandomPotion() );

			if ( 0.05 > Utility.RandomDouble() )
				pack.DropItem( Loot.RandomGem() );

			PackItem( pack );
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool CanRummageCorpses{ get{ return true; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new Nirnroot( Utility.RandomMinMax( 5, 11 ) ), from );

                              from.SendMessage( "You carve up some nirnroot." ); 
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

		public Myconid( Serial serial ) : base( serial )
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