using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a mongbat corpse" )]
	public class GreaterMongbat : BaseCreature
	{
		[Constructable]
		public GreaterMongbat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a greater mongbat";
			Body = 39;
			BaseSoundID = 422;

			SetStr( 56, 80 );
			SetDex( 61, 80 );
			SetInt( 26, 50 );

			SetHits( 68, 96 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20 );

			SetSkill( SkillName.MagicResist, 15.1, 29.4 );
			SetSkill( SkillName.Tactics, 35.6, 49.9 );
			SetSkill( SkillName.Wrestling, 24.8, 38.5 );

			Fame = 150;
			Karma = -150;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 71.1;

			PackGold( 1, 4 );

			PackItem( new FishScale( Utility.RandomMinMax( 3, 9 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 6; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public GreaterMongbat( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
