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
	[CorpseName( "a rotting corpse" )]
	public class SummonedZombie : BaseCreature
	{
		public Timer	m_Timer;

		[Constructable]
		public SummonedZombie() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a summoned zombie";
			Body = 3;
			BaseSoundID = 471;

			SetStr( 47, 68 );
			SetDex( 34, 48 );
			SetInt( 26, 38 );

			SetHits( 56, 84 );

			SetDamage( 3, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 18 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 5 );

			SetSkill( SkillName.MagicResist, 23.3, 37.5 );
			SetSkill( SkillName.Tactics, 37.4, 49.9 );
			SetSkill( SkillName.Wrestling, 39.3, 52.1 );

			Fame = 600;
			Karma = -600;
			
			VirtualArmor = 18;

			m_Timer = new AutokillTimer(this);
			m_Timer.Start();
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

		public SummonedZombie (Serial serial) : base(serial)
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
			private SummonedZombie m_Owner;

			public AutokillTimer( SummonedZombie owner ) : base( TimeSpan.FromMinutes(1.0) )
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

