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
	[CorpseName( "a gryphon scout corpse" )]
	public class GryphonScout : BaseMount
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
		public GryphonScout() : this( "a gryphon scout" )
		{
		}

		[Constructable]
		public GryphonScout( string name ) : base( name, 0x12A, 0x3EB0, AIType.AI_Animal, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x2EE;

			SetStr( 172, 204 );
			SetDex( 113, 128 );
			SetInt( 39, 51 );

			SetHits( 189, 225 );
			SetMana( 0 );

			SetDamage( 9, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Anatomy, 5.1, 17.3 );
			SetSkill( SkillName.Healing, 45.8, 60.2 );
			SetSkill( SkillName.MagicResist, 37.2, 43.1 );
			SetSkill( SkillName.Ninjitsu, 70.0 );
			SetSkill( SkillName.Tactics, 79.8, 99.9 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 1200;
			Karma = 0;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 29.5;

			PackGold( 157, 257 );
		}

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 18; } }
		public override int Feathers{ get{ return 50; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( 0.5 > Utility.RandomDouble() )
			{
				/* Blood Bath
				 * Start cliloc 1070826
				 * Sound: 0x52B
				 * 2-3 blood spots
				 * Damage: 2 hps per second for 30 seconds
				 * End cliloc: 1070824
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if( timer != null )
				{
					timer.DoExpire();
                                        defender.SendMessage( "The gryphon continues inflicting bleeding damage!" );
				}
				else
                                        defender.SendMessage( "The gryphon goes into a rage, inflicting continuous bleeding damage!" );

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
					m_Mobile.Damage( 2, m_From );
				else
					DoExpire();
			}

			protected override void OnTick()
			{
				DrainLife();

				if( ++m_Count >= 30 )
				{
					DoExpire();
                                        m_Mobile.SendMessage( "The blood clouting from the gryphon's peck subsides." );
				}
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new GryphonBeak(), from );
                              corpse.AddCarvedItem(new GryphonClaw( amount ), from );

                              from.SendMessage( "You carve up some gryphon parts." );
                              corpse.Carved = true; 
			}
                }

		public GryphonScout( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}