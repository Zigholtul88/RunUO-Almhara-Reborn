using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a skeletal corpse" )]
	public class SummonedSkeletalMage : BaseCreature
	{
		public Timer	m_Timer;

		[Constructable]
		public SummonedSkeletalMage() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a summoned skeletal mage";
			Body = 148;
			BaseSoundID = 451;

			SetStr( 77, 98 );
			SetDex( 58, 75 );
			SetInt( 186, 209 );

			SetHits( 92, 120 );
			SetMana( 186, 209 );

			SetDamage( 3, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 38 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.Magery, 66.9, 73.9 );
			SetSkill( SkillName.MagicResist, 56.7, 69.9 );
			SetSkill( SkillName.Tactics, 45.9, 60.0 );
			SetSkill( SkillName.Wrestling, 51.3, 57.6 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 38;

			m_Timer = new AutokillTimer(this);
			m_Timer.Start();
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from != null && from != this )
			{
				if (from is PlayerMobile)
				{
					PlayerMobile p_PlayerMobile = from as PlayerMobile;
					Item weapon1 = p_PlayerMobile.FindItemOnLayer( Layer.OneHanded );
					Item weapon2 = p_PlayerMobile.FindItemOnLayer( Layer.TwoHanded );

					if (weapon1 != null)
					{
						if (weapon1 is BaseBashing )
						{
							damage += 1;
						}
                                    else
                                    {
							damage = 5;
							from.SendMessage("Your weapon deals little damage to the skeletal mage's durable bones.");
                                    }
					}

					else if (weapon2 != null)
					{
						if (weapon2 is BaseBashing )
						{
							damage += 1;
						}
                                    else
                                    {
							damage = 5;
							from.SendMessage("Your weapon deals little damage to the skeletal mage's durable bones.");
                                    }
					}
				}
			}
		}

		public SummonedSkeletalMage(Serial serial) : base(serial)
		{
			m_Timer = new AutokillTimer(this);
			m_Timer.Start();
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

		private class AutokillTimer : Timer
		{
			private SummonedSkeletalMage m_Owner;

			public AutokillTimer( SummonedSkeletalMage owner ) : base( TimeSpan.FromMinutes(1.0) )
			{
				m_Owner = owner;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Owner.Delete();
				Stop();
			}
		}
	}
}
