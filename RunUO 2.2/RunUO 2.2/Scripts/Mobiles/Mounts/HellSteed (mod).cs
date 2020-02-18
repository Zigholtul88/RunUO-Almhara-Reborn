using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a hellsteed corpse" )]
	public class HellSteed : BaseMount
	{
		[Constructable] 
		public HellSteed() : this( "a hellsteed" )
		{
		}

		[Constructable]
		public HellSteed( string name ) : base( name, 793, 0x3EBB, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			BaseSoundID = 0xA8;

			SetStr( 142, 171 );
			SetDex( 105, 111 );
			SetInt( 57, 62 );

			SetHits( 175, 225 );

			SetDamage( 1, 3 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 75 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Poison, 100 );

			SetSkill( SkillName.Anatomy, 25.0 );
			SetSkill( SkillName.MagicResist, 41.7, 59.8 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 62.5, 71.4 );

			Fame = 0;
			Karma = 0;

			PackGold( 103, 307 );

			Container pack = new Backpack();

			pack.DropItem( new BatWing( Utility.RandomMinMax( 5, 8 ) ) );
			pack.DropItem( new DaemonBlood( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new GraveDust( Utility.RandomMinMax( 6, 11 ) ) );

			PackItem( pack );
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

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

                public override bool HasBreath{ get{ return true; } }

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 50; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 50; } }

		public override int BreathEffectHue{ get{ return 2412; } }
		public override int BreathEffectItemID{ get{ return 0x36D4; } }
		public override int BreathEffectSound{ get{ return 0x56D; } }
		public override int BreathAngerSound{ get{ return 0xA8; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( 0.25 > Utility.RandomDouble() )
			{
				/* Flurry of Twigs
				 * Start cliloc: 1070850
				 * Effect: Physical resistance -50% for 15 seconds
				 * End cliloc: 1070852
				 * Effect: Type: "3" From: "0x57D4F5B" To: "0x0" ItemId: "0x37B9" ItemIdName: "glow" FromLocation: "(1048 779, 6)" ToLocation: "(1048 779, 6)" Speed: "10" Duration: "5" FixedDirection: "True" Explode: "False"
				 */

				ExpireTimer timer = (ExpireTimer)m_FlurryOfTwigsTable[defender];

				if( timer != null )
				{
					timer.DoExpire();
                                        defender.SendMessage( "The hell steed lands another blow in your weakened state." );
				}
				else
                                        defender.SendMessage( "The hell steed's flurry of twigs has made you more susceptible to fire attacks!" );

		                ResistanceMod mod = new ResistanceMod( ResistanceType.Fire, - 50 );

				defender.FixedEffect( 0x37B9, 10, 5 );
				defender.AddResistanceMod( mod );

				timer = new ExpireTimer( defender, mod, m_FlurryOfTwigsTable, TimeSpan.FromSeconds( 15.0 ) );
				timer.Start();
				m_FlurryOfTwigsTable[defender] = timer;
			}
			else if( 0.05 > Utility.RandomDouble() )
			{
				/* Chlorophyl Blast
				 * Start cliloc: 1070827
				 * Effect: Energy resistance -50% for 15 seconds
				 * End cliloc: 1070829
				 * Effect: Type: "3" From: "0x57D4F5B" To: "0x0" ItemId: "0x37B9" ItemIdName: "glow" FromLocation: "(1048 779, 6)" ToLocation: "(1048 779, 6)" Speed: "10" Duration: "5" FixedDirection: "True" Explode: "False"
				 */

				ExpireTimer timer = (ExpireTimer)m_ChlorophylBlastTable[defender];

				if( timer != null )
				{
					timer.DoExpire();
                                        defender.SendMessage( "The hell steed continues to hinder your energy resistance!" );
				}
				else
                                        defender.SendMessage( "The hell steed's attack has made you more susceptible to energy attacks!" );

		                ResistanceMod mod = new ResistanceMod( ResistanceType.Energy, - 50 );

				defender.FixedEffect( 0x37B9, 10, 5 );
				defender.AddResistanceMod( mod );

				timer = new ExpireTimer( defender, mod, m_ChlorophylBlastTable, TimeSpan.FromSeconds( 15.0 ) );
				timer.Start();
				m_ChlorophylBlastTable[defender] = timer;
			}
		}

		private static Hashtable m_FlurryOfTwigsTable = new Hashtable();
		private static Hashtable m_ChlorophylBlastTable = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private ResistanceMod m_Mod;
			private Hashtable m_Table;

			public ExpireTimer( Mobile m, ResistanceMod mod, Hashtable table, TimeSpan delay ): base( delay )
			{
				m_Mobile = m;
				m_Mod = mod;
				m_Table = table;
				Priority = TimerPriority.TwoFiftyMS;
			}

			public void DoExpire()
			{
				m_Mobile.RemoveResistanceMod( m_Mod );
				Stop();
				m_Table.Remove( m_Mobile );
			}

			protected override void OnTick()
			{
				if( m_Mod.Type == ResistanceType.Physical )
                                        m_Mobile.SendMessage( "Your resistance to fire attacks has returned." );
				else
                                        m_Mobile.SendMessage( "Your resistance to energy attacks has returned." );

				DoExpire();
			}
		}

		public HellSteed( Serial serial ) : base( serial )
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