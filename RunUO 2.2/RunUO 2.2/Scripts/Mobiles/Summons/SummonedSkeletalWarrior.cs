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
	public class SummonedSkeletalWarrior : BaseCreature
	{
		public Timer	m_Timer;

		[Constructable]
		public SummonedSkeletalWarrior() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a summoned skeletal warrior";
			Body = 57;
			BaseSoundID = 451;

			SetStr( 202, 248 );
			SetDex( 74, 95 );
			SetInt( 39, 60 );

			SetHits( 236, 300 );

			SetDamage( 8, 18 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 85.1, 100.0 );
			SetSkill( SkillName.Wrestling, 85.1, 95.0 );

			Fame = 3000;
			Karma = -3000;
			
			VirtualArmor = 40;

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
							from.SendMessage("Your weapon deals little damage to the skeletal warrior's durable bones.");
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
							from.SendMessage("Your weapon deals little damage to the skeletal warrior's durable bones.");
                                    }
					}
				}
			}
		}

		public SummonedSkeletalWarrior (Serial serial) : base(serial)
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
			private SummonedSkeletalWarrior m_Owner;

			public AutokillTimer( SummonedSkeletalWarrior owner ) : base( TimeSpan.FromMinutes(1.0) )
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
