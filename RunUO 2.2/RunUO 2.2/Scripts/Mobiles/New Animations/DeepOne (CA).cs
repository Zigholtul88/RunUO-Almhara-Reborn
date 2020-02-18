using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a deep one corpse" )]
	public class DeepOne : BaseCreature
	{
		[Constructable]
		public DeepOne() : base( AIType.AI_Melee, FightMode.Closest, 6, 1, 0.2, 0.4 )
		{
			Name = "a deep one";
			Body = 376;
			BaseSoundID = 0x275;

			SetStr( 144, 179 );
			SetDex( 75, 81 );
			SetInt( 22, 36 );

			SetHits( 175, 200 );

			SetDamage( 5, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.Anatomy, 20.0 );
			SetSkill( SkillName.MagicResist, 35.1, 37.2 );
			SetSkill( SkillName.Tactics, 50.1, 75.0 );
			SetSkill( SkillName.Wrestling, 50.1, 75.0 );

			Fame = 2800;
			Karma = -2800;

			AddItem( new LightSource() );

			PackReg( 1, 5 );

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Gold( Utility.RandomMinMax( 6, 12 ) ) );
			pack.DropItem( Loot.RandomStatue() );
			pack.DropItem( new Pearl() );

			if ( 0.04 > Utility.RandomDouble() )
				pack.DropItem( new TurquoiseCustom() );

			if ( 0.03 > Utility.RandomDouble() )
				pack.DropItem( Loot.RandomGem() );

 		        if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseClothing clothing1 = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing1, 3, 10, 25 );  

                       pack.DropItem( clothing1 );
                  }

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseClothing clothing2 = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing2, 3, 10, 25 );  

                       pack.DropItem( clothing2 );
                  }

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseWeapon weapon = Loot.RandomWeapon( true );
		           BaseRunicTool.ApplyAttributesTo( weapon, 3, 10, 25 );  

                       pack.DropItem( weapon );
                  }

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseJewel necklace = new GoldNecklace();
			     if ( Core.AOS )
		           BaseRunicTool.ApplyAttributesTo( necklace, 2, 10, 15 ); 

                       pack.DropItem( necklace );
                  }

			PackItem( pack );

			switch ( Utility.Random( 3 ))
			{
				case 0: AddItem( Loot.RandomArmor() ); break;
				case 1: AddItem( Loot.RandomClothing() ); break;
				case 2: AddItem( Loot.RandomWeapon() ); break;
			}

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average, 2 );
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawFishSteak( Utility.RandomMinMax( 9, 13 )), from);
                        corpse.AddCarvedItem(new FishScale( Utility.RandomMinMax( 12, 15 )), from);

                        from.SendMessage( "You carve up raw fish steaks and some fish scales." ); 
			}
                }

		public DeepOne( Serial serial ) : base( serial )
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
