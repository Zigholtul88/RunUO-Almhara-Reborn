using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a frost gator corpse" )]
	public class FrostGator : BaseCreature
	{
		[Constructable]
		public FrostGator() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a frost gator";
			Body = 0xCA;
			BaseSoundID = 660;
                        Hue = 1153;

			SetStr( 81, 100 );
			SetDex( 48, 64 );
			SetInt( 13, 19 );

			SetHits( 92, 120 );
			SetStam( 92, 130 );
			SetMana( 0 );

			SetDamage( 5, 15 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 100 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 26.9, 35.8 );
			SetSkill( SkillName.Tactics, 42.1, 56.0 );
			SetSkill( SkillName.Wrestling, 48.6, 61.5 );

			Fame = 11600;
			Karma = -11624;

			VirtualArmor = 30;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 47.1;

			PackItem( new SerpentScale( Utility.RandomMinMax( 7, 12 ) ) );
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public FrostGator(Serial serial) : base(serial)
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

			if ( BaseSoundID == 0x5A )
				BaseSoundID = 660;
		}
	}
}