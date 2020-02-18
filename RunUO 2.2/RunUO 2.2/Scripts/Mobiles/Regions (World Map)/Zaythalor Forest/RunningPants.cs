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
	[CorpseName( "a pair of pants" )]
	public class RunningPants : BaseCreature
	{
                private readonly Timer m_Timer;

		[Constructable]
		public RunningPants() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a pair of running pants";
			Body = 430;

			SetStr( 50 );
			SetDex( 10 );
			SetInt( 5 );

			SetMana( 0 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10, 20 );

			SetSkill( SkillName.MagicResist, 9.8 );
			SetSkill( SkillName.Tactics, 7.2 );
			SetSkill( SkillName.Wrestling, 6.1 );

			Fame = 300;
			Karma = -300;

                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 10.0;
		}

		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override int GetIdleSound() { return 1320; } 
		public override int GetAttackSound() { return 1346; }
		public override int GetAngerSound() { return 1354; } 
		public override int GetHurtSound() { return 1344; } 
		public override int GetDeathSound() { return 0x61F; } // wilhelm scream

		public override bool CanRummageCorpses{ get{ return true; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new ShortPants(), from);
                              corpse.AddCarvedItem(new Feather(20), from);

                              from.SendMessage( "You carve up some short pants and feathers." );
                              corpse.Carved = true;
			}
                }

		public RunningPants(Serial serial) : base(serial)
		{
                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();
		}

                public override void OnDelete()
                {
                        this.m_Timer.Stop();

                        base.OnDelete();
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

		private class InternalTimer : Timer
		{
			private RunningPants m_Owner;
			private int m_Count = 0;

			public InternalTimer( RunningPants owner ) : base( TimeSpan.FromSeconds( 0.1 ), TimeSpan.FromSeconds( 0.1 ) )
			{
				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if ( (m_Count++ & 0x999) == 0 )
				{
					m_Owner.Direction = (Direction)(Utility.Random( 5 ) | 0x80);
				}

				m_Owner.Move( m_Owner.Direction );
			}
		}
	}
}