using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a timber wolf corpse" )]
	[TypeAlias( "Server.Mobiles.Timberwolf" )]
	public class TimberWolf : BaseCreature
	{
		[Constructable]
		public TimberWolf() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a timber wolf";
			Body = 225;
			BaseSoundID = 0xE5;

			SetStr( 56, 79 );
			SetDex( 56, 75 );
			SetInt( 11, 25 );

			SetHits( 68, 96 );
			SetMana( 0 );

			SetDamage( 5, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 18 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 28.2, 42.0 );
			SetSkill( SkillName.Tactics, 30.3, 50.0 );
			SetSkill( SkillName.Wrestling, 44.1, 62.6 );

			Fame = 450;
			Karma = 0;

			VirtualArmor = 18;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 23.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 5; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public TimberWolf(Serial serial) : base(serial)
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