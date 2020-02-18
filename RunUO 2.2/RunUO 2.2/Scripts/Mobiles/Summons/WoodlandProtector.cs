using System;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of a woodland protector" )]
	public class WoodlandProtector : BaseGuardian
	{
		public Timer	m_Timer;

		[Constructable]
		public WoodlandProtector() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a woodland protector";
			Body = 266;
			BaseSoundID = 0x57B;

			SetStr( 500, 600 );
			SetDex( 250, 320 );
			SetInt( 389, 441 );

			SetMana( 389, 441 );

			SetDamage( 12, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 40, 45 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 25, 35 );

			SetSkill( SkillName.Meditation, 80.0, 90.0 );
			SetSkill( SkillName.EvalInt, 70.0, 80.0 );
			SetSkill( SkillName.Magery, 70.0, 80.0 );
			SetSkill( SkillName.Anatomy, 0 );
			SetSkill( SkillName.MagicResist, 100.0, 120.0 );
			SetSkill( SkillName.Tactics, 70.0, 80.0 );
			SetSkill( SkillName.Wrestling, 70.0, 80.0 );

			Fame = 0;
			Karma = 5000;

			m_Timer = new AutokillTimer(this);
			m_Timer.Start();
		}

		public WoodlandProtector(Serial serial) : base(serial)
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
			private WoodlandProtector m_Owner;

			public AutokillTimer( WoodlandProtector owner ) : base( TimeSpan.FromMinutes(1.0) )
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
