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
    public class RatmenFortressBossChest : LockableContainer
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
        public RatmenFortressBossChest() : base( 0x2DF2 )
        {
		Name = "a boss treasure chest -25-";
		Movable = true;
		Weight = 1000.0;

                TrapPower = 0;
                Locked = true;

                RequiredSkill = 25;
                LockLevel = 25;
                MaxLockLevel = 30;

            // Gold
 		if ( Utility.RandomDouble() < 0.50 )
            DropItem( new Gold( Utility.Random( 250, 400 ) ) );

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
            DropItem( new Arrow( Utility.Random( 35, 50 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bolt( Utility.Random( 35, 50 ) ) );

            Item ReagentLoot = Loot.RandomReagent();
            ReagentLoot.Amount = Utility.Random( 35, 40 );
            DropItem( ReagentLoot );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bandage( Utility.Random( 25, 40 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Bedroll() );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bottle( Utility.Random( 15, 25 ) ) );	

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

 		if ( Utility.RandomDouble() < 0.20 )
            {
	            BaseWeapon weapon = Loot.RandomWeapon( true );
			switch ( Utility.Random( 38 ) )
			{
				case 0: weapon = new Hatchet(); break;
				case 1: weapon = new Bow(); break;
				case 2: weapon = new Crossbow(); break;
				case 3: weapon = new Club(); break;
			      case 4: weapon = new Mace(); break;
				case 5: weapon = new Maul(); break;
				case 6: weapon = new Pitchfork(); break;
				case 7: weapon = new ShortSpear(); break;
				case 8: weapon = new GnarledStaff(); break;
				case 9: weapon = new ShepherdsCrook(); break;
				case 10: weapon = new Cutlass(); break;
				case 11: weapon = new Katana(); break;
				case 12: weapon = new Kryss(); break;
				case 13: weapon = new Scimitar(); break;
				case 14: weapon = new AssassinSpike(); break;
				case 15: weapon = new DiamondMace(); break;
				case 16: weapon = new Leafblade(); break;
				case 17: weapon = new MagicalShortbow(); break;
				case 18: weapon = new RadiantScimitar(); break;
				case 19: weapon = new WildStaff(); break;
				case 20: weapon = new Axe(); break;
				case 21: weapon = new ExecutionersAxe(); break;
				case 22: weapon = new Pickaxe(); break;
				case 23: weapon = new TwoHandedAxe(); break;
				case 24: weapon = new WarAxe(); break;
				case 25: weapon = new HeavyCrossbow(); break;
				case 26: weapon = new HammerPick(); break;
				case 27: weapon = new WarMace(); break;
				case 28: weapon = new Spear(); break;
				case 29: weapon = new WarFork(); break;
				case 30: weapon = new BlackStaff(); break;
				case 31: weapon = new QuarterStaff(); break;
				case 32: weapon = new Longsword(); break;
				case 33: weapon = new ElvenCompositeLongbow(); break;
				case 34: weapon = new ElvenMachete(); break;
				case 35: weapon = new ElvenSpellblade(); break;
				case 36: weapon = new RuneBlade(); break;
				default: weapon = new Dagger(); break;
			}

			        BaseRunicTool.ApplyAttributesTo( weapon, 5, 15, 20 );

				DropItem( weapon );
			}

 		if ( Utility.RandomDouble() < 0.20 )
            {
			BaseArmor armor = Loot.RandomArmor( true );
			switch ( Utility.Random( 13 ) )
			{
			        case 0: armor = new FemaleStuddedChest(); break;
			        case 1: armor = new StuddedArms(); break;
				case 2: armor = new StuddedBustierArms(); break;
				case 3: armor = new StuddedGloves(); break;
				case 4: armor = new StuddedGorget(); break;
			        case 5: armor = new ChainCoif(); break;
				case 6: armor = new ChainChest(); break;
				case 7: armor = new ChainLegs(); break;
			        case 8: armor = new RingmailArms(); break;
				case 9: armor = new RingmailChest(); break;
				case 10: armor = new RingmailGloves(); break;
				case 11: armor = new RingmailLegs(); break;
				default: armor = new StuddedChest(); break;
		      }

			        BaseRunicTool.ApplyAttributesTo( armor, 5, 15, 20 );

				DropItem( armor );
			}

 		if ( Utility.RandomDouble() < 0.20 )
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

				BaseRunicTool.ApplyAttributesTo( hat, 5, 15, 20 );

				DropItem( hat );
			}

 		if ( Utility.RandomDouble() < 0.20 )
            {
			  BaseClothing clothing = Loot.RandomClothing( true );
		          BaseRunicTool.ApplyAttributesTo( clothing, 5, 15, 20 );              

                          DropItem( clothing );
            }

 		if ( Utility.RandomDouble() < 0.20 )
            {
			  BaseShield shield = new HeaterShield();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( shield, 5, 15, 20 );              

                          DropItem( shield );
            }

 		if ( Utility.RandomDouble() < 0.20 )
            {
			  BaseJewel bracelet = new SilverBracelet();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( bracelet, 5, 15, 20 );              

                          DropItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.20 )
            {
			  BaseJewel earrings = new SilverEarrings();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( earrings, 5, 15, 20 );              

                          DropItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.20 )
            {
			  BaseJewel necklace = new SilverNecklace();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( necklace, 5, 15, 20 );              

                          DropItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.20 )
            {
			  BaseJewel ring = new SilverRing();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( ring, 5, 15, 20 );              

                          DropItem( ring );
            }

        }

        public RatmenFortressBossChest( Serial serial ) : base( serial )
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