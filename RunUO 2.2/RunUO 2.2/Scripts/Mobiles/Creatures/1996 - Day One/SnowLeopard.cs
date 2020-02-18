using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a leopard corpse" )]
	[TypeAlias( "Server.Mobiles.Snowleopard" )]
	public class SnowLeopard : BaseCreature
	{
		[Constructable]
		public SnowLeopard() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a snow leopard";
			Body = Utility.RandomList( 64, 65 );
			BaseSoundID = 0x73;

			SetStr( 56, 80 );
			SetDex( 67, 85 );
			SetInt( 27, 50 );

			SetHits( 68, 96 );
			SetMana( 0 );

			SetDamage( 3, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 24 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 25.2, 34.8 );
			SetSkill( SkillName.Tactics, 45.6, 59.8 );
			SetSkill( SkillName.Wrestling, 44.1, 52.7 );

			Fame = 450;
			Karma = 0;

			VirtualArmor = 24;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 53.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 8; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public SnowLeopard(Serial serial) : base(serial)
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