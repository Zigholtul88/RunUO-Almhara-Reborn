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
    public class AlytharrBeachHouseChest : LockableContainer
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
        public AlytharrBeachHouseChest() : base( 0xE43 )
        {
		Name = "a treasure chest -40-";
		Movable = true;
		Weight = 1000.0;

                TrapPower = 0;
                Locked = true;

                RequiredSkill = 40;
                LockLevel = 40;
                MaxLockLevel = 45;

            // Gold
 		if ( Utility.RandomDouble() < 0.50 )
            DropItem( new Gold( Utility.Random( 300, 450 ) ) );

/////////////////////////////////////// Jewelry

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

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Arrow( Utility.Random( 50, 75 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bolt( Utility.Random( 50, 75 ) ) );

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
            DropItem( new Bandage( Utility.Random( 40, 80 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Bedroll() );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bottle( Utility.Random( 25, 45 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Lockpick( Utility.Random( 15, 25 ) ) );

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

 		if ( Utility.RandomDouble() < 0.15 )
            {
	            BaseWeapon weapon = Loot.RandomWeapon( true );
			switch ( Utility.Random( 12 ) )
			{
				case 0: weapon = new OrnateAxe(); break;
				case 1: weapon = new AssassinSpike(); break;
				case 2: weapon = new DiamondMace(); break;
				case 3: weapon = new Leafblade(); break;
				case 4: weapon = new MagicalShortbow(); break;
				case 5: weapon = new RadiantScimitar(); break;
				case 6: weapon = new WildStaff(); break;
				case 7: weapon = new ElvenCompositeLongbow(); break;
				case 8: weapon = new ElvenMachete(); break;
				case 9: weapon = new ElvenSpellblade(); break;
				case 10: weapon = new RuneBlade(); break;
				default: weapon = new WarCleaver(); break;
			}

			        BaseRunicTool.ApplyAttributesTo( weapon, 4, 30, 35 );

				DropItem( weapon );
			}

 		if ( Utility.RandomDouble() < 0.15 )
            {
			BaseArmor armor = Loot.RandomArmor( true );
			switch ( Utility.Random( 7 ) )
			{
			        case 0: armor = new FemaleLeafChest(); break;
			        case 1: armor = new LeafArms(); break;
				case 2: armor = new LeafChest(); break;
				case 3: armor = new LeafGorget(); break;
				case 4: armor = new LeafLegs(); break;
			        case 5: armor = new LeafTonlet(); break;
				default: armor = new LeafGloves(); break;
		      }

			        BaseRunicTool.ApplyAttributesTo( armor, 4, 30, 35 );

				DropItem( armor );
			}

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseClothing clothing = Loot.RandomClothing( true );
		          BaseRunicTool.ApplyAttributesTo( clothing, 4, 22, 25 );              

                          DropItem( clothing );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseJewel bracelet = new GoldBracelet();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( bracelet, 5, 5, 10 );              

                          DropItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseJewel earrings = new GoldEarrings();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( earrings, 5, 5, 10 );              

                          DropItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseJewel necklace = new GoldNecklace();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( necklace, 5, 5, 10 );              

                          DropItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseJewel ring = new GoldRing();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( ring, 5, 5, 10 );              

                          DropItem( ring );
            }

        }

        public AlytharrBeachHouseChest( Serial serial ) : base( serial )
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