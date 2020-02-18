using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a gorilla corpse" )]
	public class Gorilla : BaseCreature
	{
		[Constructable]
		public Gorilla() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a gorilla";
			Body = 0x1D;
			BaseSoundID = 0x9E;

			SetStr( 65, 88 );
			SetDex( 36, 55 );
			SetInt( 36, 81 );

			SetHits( 76, 102 );
			SetMana( 0 );

			SetDamage( 4, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 10 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 45.2, 59.3 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 450;
			Karma = 0;

			VirtualArmor = 20;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 0.0;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 6; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public Gorilla(Serial serial) : base(serial)
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