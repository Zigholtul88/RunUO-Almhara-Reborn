using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a dusk rat corpse" )]
	public class DuskRat : BaseCreature
	{
		[Constructable]
		public DuskRat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dusk rat";
			Body = 0xD7;
			BaseSoundID = 0x188;

			SetStr( 32, 70 );
			SetDex( 46, 65 );
			SetInt( 16, 29 );

			SetHits( 52, 78 );
			SetMana( 0 );

			SetDamage( 4, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 18 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Poison, 25 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 25.1, 30.0 );
			SetSkill( SkillName.Tactics, 27.0, 43.9 );
			SetSkill( SkillName.Wrestling, 37.0, 42.8 );

			Fame = 300;
			Karma = -300;

			VirtualArmor = 18;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 29.1;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 6; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies | FoodType.Eggs; } }

		public DuskRat(Serial serial) : base(serial)
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