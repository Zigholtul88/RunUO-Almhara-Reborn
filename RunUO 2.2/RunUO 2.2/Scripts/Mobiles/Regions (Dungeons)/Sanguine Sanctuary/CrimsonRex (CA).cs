using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a crimson rex corpse" )]
	public class CrimsonRex : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public CrimsonRex() : base( AIType.AI_Animal, FightMode.Closest, 15, 2, 0.175, 0.350 )
		{
			Name = "a crimson rex";
			Body = 295;
			Hue = 0x648;

			SetStr( 644, 719 );
			SetDex( 152, 179 );
			SetInt( 52, 61 );

			SetHits( 721, 836 );

			SetDamage( 15, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 15 );

			SetSkill( SkillName.MagicResist, 26.9, 35.8 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 91.0, 93.2 );

			Fame = 45000;
			Karma = -45000;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.MedScrolls, 1 );
			AddLoot( LootPack.LowScrolls, 3 );
			AddLoot( LootPack.Gems, 2 );
		}

		public override int GetIdleSound() { return 650; }
		public override int GetAngerSound() { return 649; }
		public override int GetAttackSound() { return 651; }
		public override int GetHurtSound() { return 652; }
		public override int GetDeathSound() { return 653; }

		public override int Meat{ get{ return 28; } }
		public override int Hides{ get{ return 35; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public CrimsonRex(Serial serial) : base(serial)
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