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
	[CorpseName( "a Star Lake crab corpse" )]
	public class StarLakeCrabAmbusher : BaseCreature
	{
		public Timer	m_Timer;

		[Constructable]
		public StarLakeCrabAmbusher() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
			Name = "a Star Lake crab ambusher";
			Body = 357;
                        Hue = 723;

			SetStr( 63, 81 );
			SetDex( 43, 79 );
			SetInt( 17, 33 );

			SetHits( 75, 85 );
			SetMana( 0 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15 );

			SetSkill( SkillName.MagicResist, 12.1, 22.2 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 450;
			Karma = -450;

                        PackGold( 1, 2 ); 
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor, 2 );
		}

		public override int GetAttackSound() { return 563; } 
		public override int GetIdleSound() { return 1561; } 
		public override int GetAngerSound() { return 1558; } 
		public override int GetHurtSound() { return 1560; } 
		public override int GetDeathSound() { return 1559; }

		public StarLakeCrabAmbusher (Serial serial) : base(serial)
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
			private StarLakeCrabAmbusher m_Owner;

			public AutokillTimer( StarLakeCrabAmbusher owner ) : base( TimeSpan.FromMinutes(5.0) )
			{
				m_Owner = owner;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Owner.Kill();
				Stop();
			}
		}
	}
}
