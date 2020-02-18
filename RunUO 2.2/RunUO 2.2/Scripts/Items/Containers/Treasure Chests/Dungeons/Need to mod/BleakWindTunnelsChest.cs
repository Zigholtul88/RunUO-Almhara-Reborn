using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Multis;
using Server.Network;
using Server.ContextMenus;
using Server.Engines.PartySystem;

namespace Server.Items
{
        [Flipable( 0xE43, 0xE42 )]
	public class BleakWindTunnelsChest1 : LockableContainer
	{
                public override bool Decays{ get{ return true; } } 

                public override TimeSpan DecayTime{ get{ return TimeSpan.FromMinutes( Utility.Random( 30, 60 ) ); } }

                public override int DefaultGumpID{ get{ return 0x49; } }
                public override int DefaultDropSound{ get{ return 0x42; } }

                public override Rectangle2D Bounds
                {
                      get{ return new Rectangle2D( 18, 105, 144, 73 ); }
                }

                [Constructable]
                public BleakWindTunnelsChest1() : base( 0xE43 )
                {
		      Name = "a treasure chest -50-";
                      Hue = 1151;
		      Movable = true;
		      Weight = 1000.0;

                      TrapPower = 0;
                      Locked = true;

                      RequiredSkill = 50;
                      LockLevel = 50;
                      MaxLockLevel = 80;

/////////////////////////////////// Gold
 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( new Gold( Utility.Random( 20, 300 ) ) );

 		      if ( Utility.RandomDouble() < 0.15 )
		         DropItem( new TurquoiseCustom() );

                      Item GemLoot = Loot.RandomGem();
                         DropItem( GemLoot );

/////////////////////////////////////// Recipe Scrolls
/////////////////////////////////// Ingredients
 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new BagOfSugarRecipe ( 5001 ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new CocoaButterRecipe ( 5004 ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new CocoaLiquorRecipe ( 5005 ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new DoughRecipe ( 5002 ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new SackFlourRecipe ( 5000 ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new SweetDoughRecipe ( 5003 ) );
/////////////////////////////////// Random
 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomBakingRecipe ( Utility.RandomMinMax( 5501, 5550 ) ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomBoilingRecipe ( Utility.RandomMinMax( 5601, 5626 ) ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomIngredientsRecipe ( Utility.RandomMinMax( 5000, 5005 ) ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomOilsRecipe ( Utility.RandomMinMax( 5101, 5105 ) ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomPreparationsRecipe ( Utility.RandomMinMax( 5401, 5435 ) ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomRawMeatPrepRecipe ( Utility.RandomMinMax( 5301, 5342 ) ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomSaucesRecipe ( Utility.RandomMinMax( 5201, 5208 ) ) );
/////////////////////////////////// Misc
 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new HarpyEggSoupRecipe ( 5019 ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new UnbakedQuicheRecipe ( 5019 ) );

/////////////////////////////////////// Supplies

			switch ( Utility.Random( 19 ) )
			{
				case 0: DropItem( new Board(90) ); break;
				case 1: DropItem( new BoltOfCloth(90) ); break;
				case 2: DropItem( new Bottle(90) ); break;
				case 3: DropItem( new CopperWire(90) ); break;
				case 4: DropItem( new Cotton(90) ); break;
				case 5: DropItem( new DarkYarn(90) ); break;
				case 6: DropItem( new Feather(90) ); break;
				case 7: DropItem( new Flax(90) ); break;
				case 8: DropItem( new Gears(90) ); break;
				case 9: DropItem( new GoldWire(90) ); break;
				case 10: DropItem( new IronIngot(90) ); break;
				case 11: DropItem( new IronWire(90) ); break;
				case 12: DropItem( new Leather(90) ); break;
				case 13: DropItem( new LightYarn(90) ); break;
				case 14: DropItem( new Shaft(90) ); break;
				case 15: DropItem( new SilverWire(90) ); break;
				case 16: DropItem( new SpoolOfThread(90) ); break;
				case 17: DropItem( new Springs(90) ); break;
				case 18: DropItem( new Wool(90) ); break;
			}

			switch ( Utility.Random( 5 ) )
			{
				case 0: DropItem( new ArcaneStone(25) ); break;
				case 1: DropItem( new DiamondDust(25) ); break;
				case 2: DropItem( new ElementalDust(25) ); break;
				case 3: DropItem( new SpiderEgg(25) ); break;
				case 4: DropItem( new ThunderStone(25) ); break;
			}

                      Item ReagentLoot = Loot.RandomReagent();
                      ReagentLoot.Amount = 50;
                         DropItem( ReagentLoot );

 		      if ( Utility.RandomDouble() < 0.05 )
		         DropItem( new SackFlour() );

/////////////////////////////////////// Rare Items

 		      if ( Utility.RandomDouble() < 0.01 )
		         DropItem( new DyeTub() );

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
	                       BaseWeapon weapon = Loot.RandomWeapon( true );
			       BaseRunicTool.ApplyAttributesTo( weapon, 2, 5, 10 );
                               weapon.Hue = 1151;
                               weapon.WeaponAttributes.HitHarm = 5;
			       DropItem( weapon );
		        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseArmor armor = Loot.RandomArmor( true );
			       BaseRunicTool.ApplyAttributesTo( armor, 2, 5, 10 );
                               armor.Hue = 1151;
                               armor.ColdBonus = 10;
			       DropItem( armor );
		        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
	                       BaseHat hat = Loot.RandomHat( true ); 
		               BaseRunicTool.ApplyAttributesTo( hat, 2, 5, 10 );
                               hat.Hue = 1151;
                               hat.Resistances.Cold = 10;
		               DropItem( hat );
		        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseClothing clothing = Loot.RandomClothing( true );
		               BaseRunicTool.ApplyAttributesTo( clothing, 2, 5, 10 );
                               clothing.Hue = 1151;
                               clothing.Resistances.Cold = 10;
                               DropItem( clothing );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseShield shield = new MercenaryShield();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( shield, 2, 5, 10 );
                               shield.Hue = 1151;
                               shield.ColdBonus = 10;
                               DropItem( shield );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseJewel bracelet = new SilverBracelet();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( bracelet, 2, 5, 10 );
                               bracelet.Hue = 1151; 
                               bracelet.Resistances.Cold = 10;              
                               DropItem( bracelet );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseJewel earrings = new SilverEarrings();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( earrings, 2, 5, 10 );
                               earrings.Hue = 1151;  
                               earrings.Resistances.Cold = 10;         
                               DropItem( earrings );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseJewel necklace = new SilverNecklace();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( necklace, 2, 5, 10 );
                               necklace.Hue = 1151;
                               necklace.Resistances.Cold = 10;
                               DropItem( necklace );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseJewel ring = new SilverRing();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( ring, 2, 5, 10 );
                               ring.Hue = 1151;
                               ring.Resistances.Cold = 10;
                               DropItem( ring );
                        }
                }

                public BleakWindTunnelsChest1( Serial serial ) : base( serial )
                {
                }

                public override void Serialize( GenericWriter writer )
                {
                    base.Serialize( writer );
                    writer.Write( (int) 1 ); // version
                }

                public override void Deserialize( GenericReader reader )
                {
                    base.Deserialize( reader );
                    int version = reader.ReadInt();
                }
        }

        [Flipable( 0xE43, 0xE42 )]
	public class BleakWindTunnelsChest2 : LockableContainer
	{
                public override bool Decays{ get{ return true; } } 

                public override TimeSpan DecayTime{ get{ return TimeSpan.FromMinutes( Utility.Random( 30, 60 ) ); } }

                public override int DefaultGumpID{ get{ return 0x49; } }
                public override int DefaultDropSound{ get{ return 0x42; } }

                public override Rectangle2D Bounds
                {
                      get{ return new Rectangle2D( 18, 105, 144, 73 ); }
                }

                [Constructable]
                public BleakWindTunnelsChest2() : base( 0xE43 )
                {
		      Name = "a treasure chest -60-";
                      Hue = 1151;
		      Movable = true;
		      Weight = 1000.0;

                      TrapPower = 0;
                      Locked = true;

                      RequiredSkill = 60;
                      LockLevel = 60;
                      MaxLockLevel = 80;

/////////////////////////////////// Gold
 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( new Gold( Utility.Random( 20, 300 ) ) );

 		      if ( Utility.RandomDouble() < 0.15 )
		         DropItem( new TurquoiseCustom() );

                      Item GemLoot = Loot.RandomGem();
                         DropItem( GemLoot );

/////////////////////////////////////// Recipe Scrolls
/////////////////////////////////// Ingredients
 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new BagOfSugarRecipe ( 5001 ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new CocoaButterRecipe ( 5004 ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new CocoaLiquorRecipe ( 5005 ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new DoughRecipe ( 5002 ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new SackFlourRecipe ( 5000 ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new SweetDoughRecipe ( 5003 ) );
/////////////////////////////////// Random
 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomBakingRecipe ( Utility.RandomMinMax( 5501, 5550 ) ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomBoilingRecipe ( Utility.RandomMinMax( 5601, 5626 ) ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomIngredientsRecipe ( Utility.RandomMinMax( 5000, 5005 ) ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomOilsRecipe ( Utility.RandomMinMax( 5101, 5105 ) ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomPreparationsRecipe ( Utility.RandomMinMax( 5401, 5435 ) ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomRawMeatPrepRecipe ( Utility.RandomMinMax( 5301, 5342 ) ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new RandomSaucesRecipe ( Utility.RandomMinMax( 5201, 5208 ) ) );
/////////////////////////////////// Misc
 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new HarpyEggSoupRecipe ( 5019 ) );

 		      if ( Utility.RandomDouble() < 0.10 )
		         DropItem( new UnbakedQuicheRecipe ( 5019 ) );

/////////////////////////////////////// Supplies

			switch ( Utility.Random( 18 ) )
			{
				case 0: DropItem( new Board(100) ); break;
				case 1: DropItem( new BoltOfCloth(100) ); break;
				case 2: DropItem( new Bottle(100) ); break;
				case 3: DropItem( new CopperWire(100) ); break;
				case 4: DropItem( new Cotton(100) ); break;
				case 5: DropItem( new DarkYarn(100) ); break;
				case 6: DropItem( new Feather(100) ); break;
				case 7: DropItem( new Flax(100) ); break;
				case 8: DropItem( new Gears(100) ); break;
				case 9: DropItem( new GoldWire(100) ); break;
				case 10: DropItem( new IronIngot(100) ); break;
				case 11: DropItem( new IronWire(100) ); break;
				case 12: DropItem( new Leather(100) ); break;
				case 13: DropItem( new LightYarn(100) ); break;
				case 14: DropItem( new Shaft(100) ); break;
				case 15: DropItem( new SilverWire(100) ); break;
				case 16: DropItem( new SpoolOfThread(100) ); break;
				case 17: DropItem( new Springs(100) ); break;
				case 18: DropItem( new Wool(100) ); break;
			}

			switch ( Utility.Random( 5 ) )
			{
				case 0: DropItem( new ArcaneStone(35) ); break;
				case 1: DropItem( new DiamondDust(35) ); break;
				case 2: DropItem( new ElementalDust(35) ); break;
				case 3: DropItem( new SpiderEgg(35) ); break;
				case 4: DropItem( new ThunderStone(35) ); break;
			}

                      Item ReagentLoot = Loot.RandomReagent();
                      ReagentLoot.Amount = 50;
                         DropItem( ReagentLoot );

 		      if ( Utility.RandomDouble() < 0.05 )
		         DropItem( new SackFlour() );

/////////////////////////////////////// Rare Items

 		      if ( Utility.RandomDouble() < 0.01 )
		         DropItem( new DyeTub() );

 		        if ( Utility.RandomDouble() < 0.10 )
                        {
	                       BaseWeapon weapon = Loot.RandomWeapon( true );
			       BaseRunicTool.ApplyAttributesTo( weapon, 2, 5, 10 );
                               weapon.Hue = 1151;
                               weapon.WeaponAttributes.HitHarm = 5;
			       DropItem( weapon );
		        }
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			       BaseArmor armor = Loot.RandomArmor( true );
			       BaseRunicTool.ApplyAttributesTo( armor, 2, 5, 10 );
                               armor.Hue = 1151;
                               armor.ColdBonus = 10;
			       DropItem( armor );
		        }
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
	                       BaseHat hat = Loot.RandomHat( true ); 
		               BaseRunicTool.ApplyAttributesTo( hat, 2, 5, 10 );
                               hat.Hue = 1151;
                               hat.Resistances.Cold = 10;
		               DropItem( hat );
		        }
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			       BaseClothing clothing = Loot.RandomClothing( true );
		               BaseRunicTool.ApplyAttributesTo( clothing, 2, 5, 10 );
                               clothing.Hue = 1151;
                               clothing.Resistances.Cold = 10;
                               DropItem( clothing );
                        }
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			       BaseShield shield = new MercenaryShield();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( shield, 2, 5, 10 );
                               shield.Hue = 1151;
                               shield.ColdBonus = 10;
                               DropItem( shield );
                        }
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			       BaseJewel bracelet = new SilverBracelet();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( bracelet, 2, 5, 10 );
                               bracelet.Hue = 1151; 
                               bracelet.Resistances.Cold = 10;              
                               DropItem( bracelet );
                        }
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			       BaseJewel earrings = new SilverEarrings();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( earrings, 2, 5, 10 );
                               earrings.Hue = 1151;  
                               earrings.Resistances.Cold = 10;         
                               DropItem( earrings );
                        }
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			       BaseJewel necklace = new SilverNecklace();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( necklace, 2, 5, 10 );
                               necklace.Hue = 1151;
                               necklace.Resistances.Cold = 10;
                               DropItem( necklace );
                        }
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			       BaseJewel ring = new SilverRing();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( ring, 2, 5, 10 );
                               ring.Hue = 1151;
                               ring.Resistances.Cold = 10;
                               DropItem( ring );
                        }
                }

                public BleakWindTunnelsChest2( Serial serial ) : base( serial )
                {
                }

                public override void Serialize( GenericWriter writer )
                {
                    base.Serialize( writer );
                    writer.Write( (int) 1 ); // version
                }

                public override void Deserialize( GenericReader reader )
                {
                    base.Deserialize( reader );
                    int version = reader.ReadInt();
                }
        }
}