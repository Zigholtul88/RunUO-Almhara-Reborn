using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a maggoty corpse" )]
	public class MoundOfMaggots : BaseCreature
	{
		[Constructable]
		public MoundOfMaggots() : base( AIType.AI_Melee, FightMode.Closest, 2, 1, 0.2, 0.4 )
		{
			Name = "a mound of maggots";
			Body = 136;
			BaseSoundID = 898;

			SetStr( 61, 70 );
			SetDex( 61, 70 );
			SetInt( 10 );

			SetHits( 50, 75 );
			SetMana( 0 );

			SetDamage( 3, 9 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Poison, 50 );

			SetResistance( ResistanceType.Physical, 25 );
			SetResistance( ResistanceType.Fire, -25 );
			SetResistance( ResistanceType.Poison, 100 );

			SetSkill( SkillName.Tactics, 50.0 );
			SetSkill( SkillName.Wrestling, 50.1, 60.0 );

			Fame = 1000;
			Karma = -1000;

			switch ( Utility.Random( 9 ))
			{
				case 0: PackItem( new Agate() ); break;
				case 1: PackItem( new Beryl() ); break;
				case 2: PackItem( new ChromeDiopside() ); break;
				case 3: PackItem( new FireOpal() ); break;
				case 4: PackItem( new MoonstoneCustom() ); break;
				case 5: PackItem( new Onyx() ); break;
				case 6: PackItem( new Opal() ); break;
				case 7: PackItem( new Pearl() ); break;
				case 8: PackItem( new TurquoiseCustom() ); break;
			}
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Regular; } }

		public override bool IsEnemy( Mobile m )
		{
		   BaseEquipableLight lightsource = m.FindItemOnLayer( Layer.TwoHanded ) as BaseEquipableLight;

	           if ( lightsource != null && lightsource.Burning )
				return false;

			return base.IsEnemy( m );
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
						if ( weapon1 is BaseEquipableLight )
						{
							damage *= 100;
						}
						else if ( weapon1 is BaseAxe )
						{
							damage = 0;
						}
						else if ( weapon1 is BaseBashing )
						{
							damage = 0;
						}
						else if ( weapon1 is BaseKnife )
						{
							damage = 0;
						}
						else if ( weapon1 is BasePoleArm )
						{
							damage = 0;
						}
						else if ( weapon1 is BaseRanged )
						{
							damage = 0;
						}
						else if ( weapon1 is BaseSpear )
						{
							damage = 0;
						}
						else if ( weapon1 is BaseStaff )
						{
							damage = 0;
						}
						else if ( weapon1 is BaseSword )
						{
							damage = 0;
						}
                                                else
                                                {
							damage = 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseEquipableLight )
						{
							damage *= 100;
						}
						else if ( weapon2 is BaseAxe )
						{
							damage = 0;
						}
						else if ( weapon2 is BaseBashing )
						{
							damage = 0;
						}
						else if ( weapon2 is BaseKnife )
						{
							damage = 0;
						}
						else if ( weapon2 is BasePoleArm )
						{
							damage = 0;
						}
						else if ( weapon2 is BaseRanged )
						{
							damage = 0;
						}
						else if ( weapon2 is BaseSpear )
						{
							damage = 0;
						}
						else if ( weapon2 is BaseStaff )
						{
							damage = 0;
						}
						else if ( weapon2 is BaseSword )
						{
							damage = 0;
						}
                                                else
                                                {
							damage = 0;
                                                }
					}
				}
			}
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( 0.15 > Utility.RandomDouble() )
			{
				/* Blood Bath
				 * Start cliloc 1070826
				 * Sound: 0x52B
				 * 2-3 blood spots
				 * Damage: 1 hps per second for 600 seconds
				 * End cliloc: 1070824
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if( timer != null )
				{
					timer.DoExpire();
                                        defender.SendMessage( "The mound of maggot continues inflicting bleeding damage!" );
				}
				else
                                        defender.SendMessage( "The mound of maggot goes into a rage, inflicting continuous bleeding damage!" );

				timer = new ExpireTimer( defender, this );
				timer.Start();
				m_Table[defender] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private Mobile m_From;
			private int m_Count;

			public ExpireTimer( Mobile m, Mobile from ): base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			public void DoExpire()
			{
				Stop();
				m_Table.Remove( m_Mobile );
			}

			public void DrainLife()
			{
				if( m_Mobile.Alive )
					m_Mobile.Damage( 1, m_From );
				else
					DoExpire();
			}

			protected override void OnTick()
			{
				DrainLife();

				if( ++m_Count >= 600 )
				{
					DoExpire();
                                        m_Mobile.SendMessage( "The blood clouting from the mound of maggot's bite subsides." );
				}
			}
		}

		public MoundOfMaggots( Serial serial ) : base( serial )
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