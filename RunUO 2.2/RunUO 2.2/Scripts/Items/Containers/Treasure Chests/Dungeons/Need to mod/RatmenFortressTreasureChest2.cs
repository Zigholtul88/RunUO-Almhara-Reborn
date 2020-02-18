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
    public class RatmenFortressTreasureChest2 : LockableContainer
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
        public RatmenFortressTreasureChest2() : base( 0xE43 )
        {
		Name = "a treasure chest -20-";
		Movable = true;
		Weight = 1000.0;

            TrapPower = 0;
            Locked = true;

            RequiredSkill = 20;
            LockLevel = 20;
            MaxLockLevel = 25;

            // Gold
 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Gold( Utility.Random( 30, 350 ) ) );

/////////////////////////////////////// Supplies

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Arrow( Utility.Random( 10, 14 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bolt( Utility.Random( 10, 14 ) ) );

            Item ReagentLoot = Loot.RandomReagent();
            ReagentLoot.Amount = Utility.Random( 10, 14 );
            DropItem( ReagentLoot );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bandage( Utility.Random( 10, 14 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Bedroll() );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bottle( Utility.Random( 10, 14 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Lockpick( Utility.Random( 10, 14 ) ) );

            Item PotionLoot = Loot.RandomPotion();
            DropItem( PotionLoot );

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

			        BaseRunicTool.ApplyAttributesTo( weapon, 4, 15, 20 );

				DropItem( weapon );
			}

 		if ( Utility.RandomDouble() < 0.15 )
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

			        BaseRunicTool.ApplyAttributesTo( armor, 4, 15, 20 );

				DropItem( armor );
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

				BaseRunicTool.ApplyAttributesTo( hat, 4, 15, 20 );

				DropItem( hat );
			}

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseClothing clothing = Loot.RandomClothing( true );
		          BaseRunicTool.ApplyAttributesTo( clothing, 4, 15, 20 );              

                          DropItem( clothing );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseShield shield = new HeaterShield();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( shield, 4, 15, 20 );              

                          DropItem( shield );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseJewel bracelet = new SilverBracelet();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( bracelet, 4, 15, 20 );              

                          DropItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseJewel earrings = new SilverEarrings();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( earrings, 4, 15, 20 );              

                          DropItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseJewel necklace = new SilverNecklace();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( necklace, 4, 15, 20 );              

                          DropItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseJewel ring = new SilverRing();
			  if ( Core.AOS )
		          BaseRunicTool.ApplyAttributesTo( ring, 4, 15, 20 );              

                          DropItem( ring );
            }

        }

        public RatmenFortressTreasureChest2( Serial serial ) : base( serial )
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