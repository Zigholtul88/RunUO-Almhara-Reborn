using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a grey wolf pup corpse" )]
	[TypeAlias( "Server.Mobiles.Greywolf" )]
	public class GreyWolfPup : BaseCreature
	{
		[Constructable]
		public GreyWolfPup() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a grey wolf pup";
			Body = Utility.RandomList( 25, 27 );
			BaseSoundID = 0xE5;

			SetStr( 40, 43 );
			SetDex( 34, 49 );
			SetInt( 6, 12 );

			SetMana( 100 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 8 );
			SetResistance( ResistanceType.Fire, 2 );
			SetResistance( ResistanceType.Poison, 7 );

			SetSkill( SkillName.MagicResist, 5.9, 7.8 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 100;
			Karma = -100;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 15.0;

			PackGold( 26, 58 );
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
						if ( weapon1 is BaseAxe )
						{
							damage *= 4;
						}
						else if ( weapon1 is BasePoleArm )
						{
							damage *= 4;
						}
						else if ( weapon1 is BaseSword )
						{
							damage *= 2;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseAxe )
						{
							damage *= 4;
						}
						else if ( weapon2 is BasePoleArm )
						{
							damage *= 4;
						}
						else if ( weapon2 is BaseSword )
						{
							damage *= 2;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
				}
			}
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( 0.5 > Utility.RandomDouble() )
			{
				/* Blood Bath
				 * Start cliloc 1070826
				 * Sound: 0x52B
				 * 2-3 blood spots
				 * Damage: 1 hps per second for 30 seconds
				 * End cliloc: 1070824
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if( timer != null )
				{
					timer.DoExpire();
                                        defender.SendMessage( "The grey wolf pup continues inflicting bleeding damage!" );
				}
				else
                                        defender.SendMessage( "The grey wolf pup goes into a rage, inflicting continuous bleeding damage!" );

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

				if( ++m_Count >= 30 )
				{
					DoExpire();
                                        m_Mobile.SendMessage( "The blood clouting from the grey wolf pup's bite subsides." );
				}
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new RawRibs( amount ), from );
                              corpse.AddCarvedItem(new Hides(2), from);
                              corpse.AddCarvedItem(new RawGreyWolfLeg(), from);

                              from.SendMessage( "You carve up a raw rib, hides, and a raw wolf leg." );
                              corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.ZaythalorPredator; }
		}

		public GreyWolfPup(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}