using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a llama corpse" )]
	public class Llama : BaseCreature
	{
		[Constructable]
		public Llama() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a llama";
			Body = 0xDC;
			BaseSoundID = 0x3F3;

			SetStr( 25, 48 );
			SetDex( 37, 55 );
			SetInt( 16, 30 );

			SetHits( 30, 54 );
			SetMana( 0 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 16 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 15.5, 20.0 );
			SetSkill( SkillName.Tactics, 19.6, 28.1 );
			SetSkill( SkillName.Wrestling, 21.6, 28.3 );

			Fame = 300;
			Karma = 0;

			VirtualArmor = 16;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 35.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public Llama(Serial serial) : base(serial)
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