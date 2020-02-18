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
    public class OphidianPalaceChest : LockableContainer
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
        public OphidianPalaceChest() : base( 0x2DF1 )
        {
		Name = "a treasure chest -45-";
		Movable = true;
		Weight = 1000.0;

            TrapPower = 0;
            Locked = true;

            RequiredSkill = 45;
            LockLevel = 45;
            MaxLockLevel = 50;

            // Gold
 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Gold( Utility.Random( 125, 450 ) ) );

/////////////////////////////////////// Jewelry

                Item GemLoot = Loot.RandomGem();
                DropItem( GemLoot );

 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Agate() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Beryl() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new ChromeDiopside() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new FireOpal() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new MoonstoneCustom() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Onyx() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Opal() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Pearl() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new TurquoiseCustom() );

 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Bloodstone() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Citrine() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Demantoid() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Jasper() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Lolite() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Lupis() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Peridot() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Tsavorite() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Zircon() );

 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Amber() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Amethyst() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Andalusite() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Chrysoberyl() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Garnet() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Jade() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Mandarin() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Morganite() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Paraiba() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new TigerEye() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Tourmaline() );

 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Alexandrite() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Ametrine() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Kunzite() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Ruby() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Sapphire() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Tanzanite() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Topaz() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Zultanite() );

 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Diamond() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Emerald() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new PinkQuartz() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new StarSapphire() );

/////////////////////////////////////// Supplies

            Item ReagentLoot1 = Loot.RandomReagent();
            ReagentLoot1.Amount = Utility.Random( 25, 35 );
            DropItem( ReagentLoot1 );

            Item ReagentLoot2 = Loot.RandomReagent();
            ReagentLoot2.Amount = Utility.Random( 25, 35 );
            DropItem( ReagentLoot2 );

            Item ReagentLoot3 = Loot.RandomReagent();
            ReagentLoot3.Amount = Utility.Random( 25, 35 );
            DropItem( ReagentLoot3 );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Arrow( Utility.Random( 17, 22 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bolt( Utility.Random( 17, 22 ) ) );

            Item ReagentLoot = Loot.RandomReagent();
            ReagentLoot.Amount = Utility.Random( 17, 22 );
            DropItem( ReagentLoot );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bandage( Utility.Random( 17, 22 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Bedroll() );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bottle( Utility.Random( 17, 22 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Lockpick( Utility.Random( 17, 22 ) ) );

 		if ( Utility.RandomDouble() < 0.20 )
		DropItem( new GreaterCurePotion() );

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new GreaterHealPotion() );

            Item PotionLoot1 = Loot.RandomPotion();
            DropItem( PotionLoot1 );

            Item PotionLoot2 = Loot.RandomPotion();
            DropItem( PotionLoot2 );

            Item PotionLoot3 = Loot.RandomPotion();
            DropItem( PotionLoot3 );

/////////////////////////////////////// Tools

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new FishingPole() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Shovel() );

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Skillet() );	

/////////////////////////////////////// Rare Items

 		if ( Utility.RandomDouble() < 0.01 )
		DropItem( new DyeTub() );

 		if ( Utility.RandomDouble() < 0.01 )
		DropItem( new SuperRod() );	

 		if ( Utility.RandomDouble() < 0.15 )
                {
	            BaseWeapon weapon1 = Loot.RandomWeapon( true );
	            BaseRunicTool.ApplyAttributesTo( weapon1, 5, 30, 35 );

	            DropItem( weapon1 );
		}
 		if ( Utility.RandomDouble() < 0.15 )
                {
	            BaseWeapon weapon2 = Loot.RandomWeapon( true );
	            BaseRunicTool.ApplyAttributesTo( weapon2, 5, 30, 35 );

	            DropItem( weapon2 );
		}
 		if ( Utility.RandomDouble() < 0.15 )
                {
	            BaseWeapon weapon3 = Loot.RandomWeapon( true );
	            BaseRunicTool.ApplyAttributesTo( weapon3, 5, 30, 35 );

	            DropItem( weapon3 );
		}
 		if ( Utility.RandomDouble() < 0.15 )
                {
		    BaseArmor armor1 = Loot.RandomArmor( true );
		    BaseRunicTool.ApplyAttributesTo( armor1, 5, 30, 35 );

		    DropItem( armor1 );
	        }
 		if ( Utility.RandomDouble() < 0.15 )
                {
		    BaseArmor armor2 = Loot.RandomArmor( true );
		    BaseRunicTool.ApplyAttributesTo( armor2, 5, 30, 35 );

		    DropItem( armor2 );
	        }
 		if ( Utility.RandomDouble() < 0.15 )
                {
		    BaseArmor armor3 = Loot.RandomArmor( true );
		    BaseRunicTool.ApplyAttributesTo( armor3, 5, 30, 35 );

		    DropItem( armor3 );
	        }
 		if ( Utility.RandomDouble() < 0.15 )
            {
	            BaseHat hat = Loot.RandomHat( true ); 
			switch ( Utility.Random( 5 ) )
			{
			        case 0: hat = new BearMask(); break;
			        case 1: hat = new DeerMask(); break;
				case 2: hat = new FeatheredHat(); break;
				case 3: hat = new WizardsHat(); break;
				default: hat = new TribalMask(); break;
		        }

				BaseRunicTool.ApplyAttributesTo( hat, 5, 30, 35 );

				DropItem( hat );
			}

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseClothing clothing1 = Loot.RandomClothing( true );
		          BaseRunicTool.ApplyAttributesTo( clothing1, 5, 30, 35 );              

                          DropItem( clothing1 );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseClothing clothing2 = Loot.RandomClothing( true );
		          BaseRunicTool.ApplyAttributesTo( clothing2, 5, 30, 35 );              

                          DropItem( clothing2 );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseShield shield1 = new JewelShield();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( shield1, 5, 30, 35 );

                          DropItem( shield1 );
            }
 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseShield shield2 = new ScarabShield();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( shield2, 4, 25, 35 );

                          DropItem( shield2 );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseJewel bracelet = new GoldBracelet();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( bracelet, 5, 30, 35 );           

                          DropItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseJewel earrings = new SilverEarrings();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( earrings, 5, 30, 35 );  

                          DropItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseJewel necklace = new GoldNecklace();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( necklace, 5, 30, 35 );            

                          DropItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseJewel ring = new SilverRing();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( ring, 5, 30, 35 );         

                          DropItem( ring );
            }

        }

        public OphidianPalaceChest( Serial serial ) : base( serial )
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