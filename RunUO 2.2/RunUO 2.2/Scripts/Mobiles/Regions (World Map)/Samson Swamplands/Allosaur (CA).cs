using System;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "an allosaur corpse" )]
	public class Allosaur : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Allosaur() : base( AIType.AI_Animal, FightMode.Aggressor, 15, 2, 0.175, 0.350 )
		{
			Name = "an allosaur";
			Body = 295;

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

			Fame = 13000;
			Karma = -13000;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 86.7;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.MedScrolls, 1 );
			AddLoot( LootPack.LowScrolls, 3 );
			AddLoot( LootPack.Gems, 2 );
		}

		public override int GetIdleSound() { return 0x621; } // t_rex_I
		public override int GetAngerSound() { return 0x61E; } // t_rex_A
		public override int GetAttackSound() { return 651; }
		public override int GetHurtSound() { return 652; }
		public override int GetDeathSound() { return 653; }

		public override int Meat{ get{ return 28; } }
		public override int Hides{ get{ return 35; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.SamsonSwamplandsPredator; }
		}

		public Allosaur(Serial serial) : base(serial)
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