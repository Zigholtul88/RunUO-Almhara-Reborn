using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a phoenix corpse" )]
	public class Phoenix : BaseCreature
	{
		[Constructable]
		public Phoenix() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a phoenix";
			Body = 832;
			BaseSoundID = 0x8F;

			SetStr( 504, 700 );
			SetDex( 202, 300 );
			SetInt( 504, 700 );

			SetHits( 680, 766 );
			SetMana( 1500, 1800 );

			SetDamage( 25 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 50 );

			SetResistance( ResistanceType.Physical, 60 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.EvalInt, 90.2, 100.0 );
			SetSkill( SkillName.Magery, 90.2, 100.0 );
			SetSkill( SkillName.Meditation, 75.1, 100.0 );
			SetSkill( SkillName.MagicResist, 86.0, 135.0 );
			SetSkill( SkillName.Tactics, 80.1, 90.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 0;
			Karma = 50000;

			Tamable = true;
			ControlSlots = 5;
			MinTameSkill = 105.0;

			PackGold( 86, 97 );

			PackItem( new FireOpal( 3 ) );

			switch ( Utility.Random( 4 ))
			{
				case 0: PackItem( new CharredBraceletOfThePhoenix() ); break;
				case 1: PackItem( new CharredEarringsOfThePhoenix() ); break;
				case 2: PackItem( new CharredNecklaceOfThePhoenix() ); break;
				case 3: PackItem( new CharredRingOfThePhoenix() ); break;
			}

			switch ( Utility.Random( 7 ))
			{
				case 0: PackItem( new PhoenixNorseHelm() ); break;
				case 1: PackItem( new PhoenixRingmailGloves() ); break;
				case 2: PackItem( new PhoenixRingmailLeggings() ); break;
				case 3: PackItem( new PhoenixRingmailSleeves() ); break;
				case 4: PackItem( new PhoenixRingmailTunic() ); break;
				case 6: PackItem( new PhoenixStuddedLeatherGorget() ); break;
			}

			PackItem( new CharredFeather( Utility.RandomMinMax( 50, 95 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 5 );
			AddLoot( LootPack.Rich );
		}

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Feathers{ get{ return 36; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }

		public Phoenix( Serial serial ) : base( serial )
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