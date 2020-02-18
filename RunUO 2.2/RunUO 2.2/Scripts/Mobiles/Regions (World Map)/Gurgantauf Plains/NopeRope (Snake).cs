using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a nope rope corpse" )]
	public class NopeRope : BaseCreature
	{
		[Constructable]
		public NopeRope() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a nope rope";
			Body = 52;
			Hue = Utility.RandomSnakeHue();
			BaseSoundID = 0xDB;

			SetStr( 23, 31 );
			SetDex( 16, 25 );
			SetInt( 10 );

			SetHits( 30, 38 );
			SetMana( 0 );

			SetDamage( 1, 4 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 16 );
			SetResistance( ResistanceType.Poison, 20 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.Poisoning, 50.3, 69.6 );
			SetSkill( SkillName.MagicResist, 14.8, 19.9 );
			SetSkill( SkillName.Tactics, 20.6, 31.4 );
			SetSkill( SkillName.Wrestling, 23.3, 33.7 );

			Fame = 300;
			Karma = -300;

			VirtualArmor = 16;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 59.1;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }
		public override Poison HitPoison{ get{ return Poison.Lesser; } }

		public override bool DeathAdderCharmable{ get{ return true; } }

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Eggs; } }

		public NopeRope(Serial serial) : base(serial)
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