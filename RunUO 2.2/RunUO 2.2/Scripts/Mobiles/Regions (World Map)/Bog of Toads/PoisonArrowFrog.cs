using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a poison arrow frog corpse" )]
	public class PoisonArrowFrog : BaseCreature
	{
		[Constructable]
		public PoisonArrowFrog() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a poison arrow frog";
			Body = 81;
			Hue = Utility.RandomList( 1276,1287,1266,232,83,1408 );
			BaseSoundID = 0x266;

			SetStr( 46, 70 );
			SetDex( 6, 25 );
			SetInt( 11, 20 );

			SetHits( 56, 78 );
			SetMana( 0 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 6 );

			SetSkill( SkillName.Healing, 45.8, 60.2 );
			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Poisoning, 157.5, 162.6 );
			SetSkill( SkillName.Tactics, 40.1, 60.0 );
			SetSkill( SkillName.Wrestling, 40.1, 60.0 );

			Fame = 350;
			Karma = 0;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 45.5;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 4; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }

		public PoisonArrowFrog(Serial serial) : base(serial)
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
