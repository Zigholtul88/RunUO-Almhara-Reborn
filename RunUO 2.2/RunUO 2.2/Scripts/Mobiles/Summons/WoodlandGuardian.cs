using System;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of a woodland guardian" )]
	public class WoodlandGuardian : BaseGuardian
	{
		public Timer	m_Timer;

		[Constructable]
		public WoodlandGuardian() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a woodland guardian";
			Body = 271;
			BaseSoundID = 0x586;

			SetStr( 450, 650 );
			SetDex( 200, 350 );
			SetInt( 126, 235 );

			SetDamage( 12, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 40, 45 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 25, 35 );

			SetSkill( SkillName.Anatomy, 95.1, 115.0 );
			SetSkill( SkillName.Archery, 95.1, 100.0 );
			SetSkill( SkillName.MagicResist, 50.3, 80.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 95.1, 100.0 );

			Fame = 0;
			Karma = 5000;

			AddItem( new Bow() );
			PackItem( new Arrow( Utility.RandomMinMax( 80, 90 ) ) ); 

			m_Timer = new AutokillTimer(this);
			m_Timer.Start();
		}

		public WoodlandGuardian (Serial serial) : base(serial)
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
			private WoodlandGuardian m_Owner;

			public AutokillTimer( WoodlandGuardian owner ) : base( TimeSpan.FromMinutes(1.0) )
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
