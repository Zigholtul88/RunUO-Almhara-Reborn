using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a hammerhead shark corpse" )]
	public class HammerheadShark : BaseMount
	{
		[Constructable]
		public HammerheadShark() : base( "a hammerhead shark", 0x11C, 0x3E92, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a hammerhead shark";

			SetStr( 124, 142 );
			SetDex( 73, 83 );
			SetInt( 97, 110 );

			SetHits( 220, 254 );

			SetDamage( 8, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 15.1, 18.8 );
			SetSkill( SkillName.Tactics, 73.5, 84.6 );
			SetSkill( SkillName.Wrestling, 71.2, 82.8 );

			Fame = 14000;
			Karma = -14000;

			CanSwim = true;
			CantWalk = false;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 35.5;

                        PackGold( 13, 19 );
		}

		public override int Meat { get { return 1; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			        BaseShield shield = new MetalKiteShield();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( shield, 5, 25, 30 ); 

                                PackItem( shield );
                        }

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			        BaseClothing clothing = Loot.RandomClothing( true );
		                BaseRunicTool.ApplyAttributesTo( clothing, 3, 15, 20 );  

                                PackItem( clothing );
                        }

                        if ( Utility.RandomDouble() < 0.05 )
                        {
                                BaseJewel jewel1 = new GoldEarrings();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( jewel1, 3, 15, 20 ); 

                                PackItem( jewel1 );
		        }

                        if ( Utility.RandomDouble() < 0.05 )
                        {
                                BaseJewel jewel2 = new GoldNecklace();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( jewel2, 3, 15, 20 ); 

                                PackItem( jewel2 );
		        }

                        if ( Utility.RandomDouble() < 0.05 )
                        {
                                BaseJewel jewel3 = new GoldRing();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( jewel3, 3, 15, 20 ); 

                                PackItem( jewel3 );
		        }
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public HammerheadShark( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}