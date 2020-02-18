using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a feline of color corpse" )]
	public class FelineOfColor : BaseCreature
	{
		[Constructable]
		public FelineOfColor() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a feline of color";
			Body = 63;
			BaseSoundID = 0x73;

			SetStr( 56, 80 );
			SetDex( 66, 85 );
			SetInt( 26, 47 );

			SetHits( 68, 96 );
			SetMana( 0 );

			SetDamage( 4, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 16 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 5 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 17.7, 62.8 );
			SetSkill( SkillName.Tactics, 45.3, 59.3 );
			SetSkill( SkillName.Wrestling, 49.9, 62.8 );

			Fame = 450;
			Karma = 0;

			VirtualArmor = 16;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 41.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 10; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public FelineOfColor(Serial serial) : base(serial)
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