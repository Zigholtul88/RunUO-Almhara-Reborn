using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an abyssal knight corpse" )]
	public class AbyssalKnight : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return Utility.RandomBool() ? WeaponAbility.ConcussionBlow : WeaponAbility.CrushingBlow;
		}

		[Constructable]
		public AbyssalKnight() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an abyssal knight";
			Body = 311;

			SetStr( 250 );
			SetDex( 100 );
			SetInt( 100 );

			SetHits( 2000 );

			SetDamage( 20, 30 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Cold, 40 );

			SetResistance( ResistanceType.Physical, 70 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 70 );
			SetResistance( ResistanceType.Poison, 70 );
			SetResistance( ResistanceType.Energy, 70 );

			SetSkill( SkillName.Chivalry, 120.0 );
			SetSkill( SkillName.DetectHidden, 80.0 );
			SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.Magery, 100.0 );
			SetSkill( SkillName.Meditation, 100.0 );
			SetSkill( SkillName.MagicResist, 80.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 45000;
			Karma = -45000;

                        if (Utility.RandomDouble() < 0.4 )
                                PackItem(new TreasureMap(2, Map.Malas ) );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 2 );
		}

		public override int GetIdleSound() { return 0x2CE; }
		public override int GetAttackSound() { return 0x2C8; }
		public override int GetHurtSound() { return 0x2D1; }
		public override int GetDeathSound() { return 0x2C1; }

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public AbyssalKnight( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}