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
	[CorpseName( "the corpse of Silk" )]
	public class Silk : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 3 ) )
			{
				default:
				case 0: return WeaponAbility.DoubleStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}

		[Constructable]
		public Silk() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			IsParagon = true;

			Name = "Silk";
			Body =  0x9D;
			BaseSoundID = 0x388;
			Hue = 0x47E;

			SetStr( 300 );
			SetDex( 150 );
			SetInt( 100 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, -50 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 70 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.MagicResist, 80.1, 95.0 );
			SetSkill( SkillName.Ninjitsu, 120.0 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 1800;
			Karma = -1800;

			m_NextAbilityTime = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 2, 5 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 5 );
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from != null && from != this )
			{
				if ( from is PlayerMobile )
				{
					PlayerMobile p_PlayerMobile = from as PlayerMobile;
					Item weapon1 = p_PlayerMobile.FindItemOnLayer( Layer.OneHanded );
					Item weapon2 = p_PlayerMobile.FindItemOnLayer( Layer.TwoHanded );

					if ( weapon1 != null )
					{
						if ( weapon1 is BaseBashing )
						{
							damage *= 2;
						}
						else if ( weapon1 is BaseStaff )
						{
							damage *= 4;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseBashing )
						{
							damage *= 2;
						}
						else if ( weapon2 is BaseStaff )
						{
							damage *= 4;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
				}
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

		public Silk( Serial serial ) : base( serial )
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
	}
}
