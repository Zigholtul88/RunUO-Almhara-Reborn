using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a wizard rat corpse" )]
	public class WizardRat : BaseCreature
	{
		[Constructable]
		public WizardRat() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a wizard rat";
			Body = 238;
			BaseSoundID = 0xCC;

			SetStr( 15 );
			SetDex( 35 );
			SetInt( 50 );

			SetHits( 85, 95 );
			SetMana( 125, 150 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.EvalInt, 5.5, 15.5 );
			SetSkill( SkillName.Magery, 45.0 );
			SetSkill( SkillName.MagicResist, 11.1, 16.8 );
			SetSkill( SkillName.Tactics, 21.0, 22.2 );
			SetSkill( SkillName.Wrestling, 14.7, 15.1 );

			Fame = 350;
			Karma = -350;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 19.6;

			PackReg( 15 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
			AddLoot( LootPack.LowScrolls );
		}

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Eggs | FoodType.FruitsAndVegies; } }

		public WizardRat(Serial serial) : base(serial)
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