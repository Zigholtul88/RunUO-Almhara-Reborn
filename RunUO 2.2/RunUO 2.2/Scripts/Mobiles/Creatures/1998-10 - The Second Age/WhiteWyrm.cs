using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a white wyrm corpse" )]
	public class WhiteWyrm : BaseCreature
	{
		[Constructable]
		public WhiteWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a white wyrm";
			Body = 180;

			BaseSoundID = 362;

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 866, 912 );
			SetMana( 772, 850 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Cold, 50 );

			SetResistance( ResistanceType.Physical, 64 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 80 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			Tamable = true;
			ControlSlots = 5;
			MinTameSkill = 96.3;

			PackGold( 82, 93 );

			switch ( Utility.Random( 8 ))
			{
				case 0: PackItem( new Amethyst() ); break;
				case 1: PackItem( new Chrysoberyl() ); break;
				case 2: PackItem( new Paraiba() ); break;
				case 3: PackItem( new TigerEye() ); break;
				case 4: PackItem( new Ruby() ); break;
				case 5: PackItem( new Sapphire() ); break;
				case 6: PackItem( new Topaz() ); break;
				case 7: PackItem( new Emerald() ); break;
			}

			PackItem( new DragonScale( Utility.RandomMinMax( 26, 32 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new ChainLightningScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
		}

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.White; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public WhiteWyrm( Serial serial ) : base( serial )
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

			if ( Core.AOS && Body == 49 )
				Body = 180;
		}
	}
}