//Created by Minth, Owner of Arise As The Gods.
//Modded by Zigholtul, Owner of Almhara Reborn.

using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a barghest corpse" )]
	public class Barghest : BaseCreature
	{
		[Constructable]
		public Barghest() : base( AIType.AI_Melee,FightMode.Closest, 8, 1, 0.2, 0.4 )
		{
			Name = "a barghest";
			Body = 360;
			Hue = 0x455;

			SetStr( 395, 455 );
			SetDex( 195, 225 );
			SetInt( 66, 76 );

			SetHits( 476, 525 );
			SetMana( 40 );

			SetDamage( 18, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, -50 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.MagicResist, 39.1, 42.7 );
			SetSkill( SkillName.Tactics, 95.1, 110.0 );
			SetSkill( SkillName.Wrestling, 97.6, 107.5 );

			Fame = 8000;
			Karma = -8000;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.MedScrolls, 5 );
			AddLoot( LootPack.LowScrolls, 7 );
			AddLoot( LootPack.Gems, 3 );
	        }

		public override int Meat { get { return 4; } }
		public override int Hides { get { return 25; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public override int GetIdleSound() { return 0x52C; }
		public override int GetAngerSound() { return 0x52D; }
		public override int GetAttackSound() { return 0x52B; }
		public override int GetHurtSound()  { return 0x52E; } 
		public override int GetDeathSound() { return 0x52A; } 

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( 0.1 > Utility.RandomDouble() )
			{
				/* Blood Bath
				 * Start cliloc 1070826
				 * Sound: 0x52B
				 * 2-3 blood spots
				 * Damage: 15 hps per second for 10 seconds
				 * End cliloc: 1070824
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if( timer != null )
				{
					timer.DoExpire();
					defender.SendLocalizedMessage( 1070825 ); // The creature continues to rage!
				}
				else
					defender.SendLocalizedMessage( 1070826 ); // The creature goes into a rage, inflicting heavy damage!

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
					m_Mobile.Damage( 15, m_From );
				else
					DoExpire();
			}

			protected override void OnTick()
			{
				DrainLife();

				if( ++m_Count >= 10 )
				{
					DoExpire();
					m_Mobile.SendLocalizedMessage( 1070824 ); // The creature's rage subsides.
				}
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( Utility.RandomDouble() < 0.1 )
				Drain( attacker );
		}

		public virtual void Drain( Mobile m )
		{
			int toDrain;

			switch ( Utility.Random( 3 ) )
			{
				case 0:
				{
					Say( 1042156 ); // I can grant life, and I can sap it as easily.
					PlaySound( 0x1E6 );

					toDrain = Utility.RandomMinMax( 3, 6 );
					Hits += toDrain;
					m.Hits -= toDrain;
					break;
				}
				case 1:
				{
					Say( 1042157 ); // You'll go nowhere, unless I deem it should be so.
					PlaySound( 0x1DF );

					toDrain = Utility.RandomMinMax( 10, 25 );
					Stam += toDrain;
					m.Stam -= toDrain;
					break;
				}
				case 2:
				{
					Say( 1042155 ); // Your power is mine to use as I will.
					PlaySound( 0x1F8 );

					toDrain = Utility.RandomMinMax( 15, 25 );
					Mana += toDrain;
					m.Mana -= toDrain;
					break;
				}
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem( new BarghestClaw(), from );
                              corpse.AddCarvedItem( new BarghestTooth( amount ), from );

                              from.SendMessage( "You carve up some barghest parts." );
                              corpse.Carved = true; 
			}
                }

		public Barghest(Serial serial) : base(serial)
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