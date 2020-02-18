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
	[CorpseName( "a parrot corpse" )]	
	public class Parrot : BaseCreature
	{
		[Constructable]
		public Parrot() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "parrot" );
			Title = "parrot";
			Body = 831;	

			SetStr( 12, 17 );
			SetDex( 9, 14 );
			SetInt( 5, 8 );

			SetHits( 15, 30 );
			SetMana( 100 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.MagicResist, 2.3, 2.7 );
			SetSkill( SkillName.Ninjitsu, 50.0 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 180;
			Karma = -180;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 0.0;

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new Apple() ); break;
				case 1: PackItem( new Banana() ); break;
				case 2: PackItem( new Grapes() ); break;
				case 3: PackItem( new Lemon() ); break;
				case 4: PackItem( new Lime() ); break;
				case 5: PackItem( new Pear() ); break;
			}
		}

		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 25; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.GlimmerwoodPredator; }
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( 0.5 > Utility.RandomDouble() )
			{
				/* Blood Bath
				 * Start cliloc 1070826
				 * Sound: 0x52B
				 * 2-3 blood spots
				 * Damage: 2 hps per second for 10 seconds
				 * End cliloc: 1070824
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if( timer != null )
				{
					timer.DoExpire();
                                        defender.SendMessage( "The parrot continues inflicting bleeding damage!" );
				}
				else
                                        defender.SendMessage( "The parrot goes into a rage, inflicting continuous bleeding damage!" );

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

				if( ++m_Count >= 10 )
				{
					DoExpire();
                                        m_Mobile.SendMessage( "The blood clouting from the parrot's bite subsides." );
				}
			}
		}

		public Parrot( Serial serial ) : base( serial )
		{
		}

		public override int GetIdleSound() { return 0x0BF; }
		public override int GetAngerSound() { return 0x0C0; }
		public override int GetAttackSound() { return 0x0C2; }
		public override int GetHurtSound() { return 0x0C3; }
		public override int GetDeathSound() { return 0x0C1; }

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