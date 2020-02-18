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
    public class AmazonTreeSettlementTreasureChest : LockableContainer
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
        public AmazonTreeSettlementTreasureChest() : base( 0xE43 )
        {
		Name = "a treasure chest -10-";
		Movable = true;
		Weight = 1000.0;

            TrapPower = 0;
            Locked = true;

            RequiredSkill = 10;
            LockLevel = 10;
            MaxLockLevel = 15;

            // Gold
 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Gold( Utility.Random( 15, 200 ) ) );

/////////////////////////////////////// Supplies

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Arrow( Utility.Random( 2, 6 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Bolt( Utility.Random( 2, 6 ) ) );

            Item ReagentLoot = Loot.RandomReagent();
            ReagentLoot.Amount = Utility.Random( 2, 6 );
            DropItem( ReagentLoot );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Bandage( Utility.Random( 2, 6 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new Bedroll() );	

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Bottle( Utility.Random( 2, 6 ) ) );	

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Lockpick( Utility.Random( 2, 6 ) ) );

            Item PotionLoot = Loot.RandomPotion();
            DropItem( PotionLoot );

/////////////////////////////////////// Tools

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new FishingPole() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new Shovel() );

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new Skillet() );	

/////////////////////////////////////// Rare Items

 		if ( Utility.RandomDouble() < 0.01 )
		DropItem( new DyeTub() );

	 	if ( Utility.RandomDouble() < 0.05 )
		DropItem( new AmazonianFighterBelt() );	
	 	if ( Utility.RandomDouble() < 0.05 )
		DropItem( new AmazonianFighterBoots() );	
	 	if ( Utility.RandomDouble() < 0.05 )
		DropItem( new AmazonianFighterBustier() );	
	 	if ( Utility.RandomDouble() < 0.05 )
		DropItem( new AmazonianFighterGloves() );	
	 	if ( Utility.RandomDouble() < 0.05 )
		DropItem( new AmazonianFighterHelmet() );	

 		if ( Utility.RandomDouble() < 0.10 )
            {
	            BaseWeapon weapon = Loot.RandomWeapon( true );
			switch ( Utility.Random( 21 ) )
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
				default: weapon = new Dagger(); break;
			}

			  BaseRunicTool.ApplyAttributesTo( weapon, 2, 10, 15 );
			  weapon.DamageLevel = (WeaponDamageLevel)Utility.Random( 2 );
			  weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random( 2 );
			  weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random( 2 );
                    weapon.Quality = WeaponQuality.Regular;

				DropItem( weapon );
			}

 		if ( Utility.RandomDouble() < 0.10 )
            {
			BaseArmor armor = Loot.RandomArmor( true );
			switch ( Utility.Random( 10 ) )
			{
			      case 0: armor = new FemaleLeatherChest(); break;
			      case 1: armor = new LeatherBustierArms(); break;
				case 2: armor = new LeatherArms(); break;
				case 3: armor = new LeatherCap(); break;
				case 4: armor = new LeatherGloves(); break;
				case 5: armor = new LeatherGorget(); break;
				case 6: armor = new LeatherLegs(); break;
				case 7: armor = new LeatherShorts(); break;
				case 8: armor = new LeatherSkirt(); break;
				default: armor = new LeatherChest(); break;
		      }

			  BaseRunicTool.ApplyAttributesTo( armor, 3, 10, 15 );
			  armor.ProtectionLevel = (ArmorProtectionLevel)Utility.Random( 3 );
			  armor.Durability = (ArmorDurabilityLevel)Utility.Random( 3 );
                    armor.Quality = ArmorQuality.Regular;

				DropItem( armor );
			}

 		if ( Utility.RandomDouble() < 0.10 )
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

				BaseRunicTool.ApplyAttributesTo( hat, 3, 10, 15 );

				DropItem( hat );
			}

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseClothing clothing = Loot.RandomClothing( true );
		          BaseRunicTool.ApplyAttributesTo( clothing, 3, 10, 15 );              

                          DropItem( clothing );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseShield shield = new MetalShield();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( shield, 3, 10, 15 );              

                DropItem( shield );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel bracelet = new GoldBracelet();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( bracelet, 3, 10, 15 );              

                DropItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel earrings = new GoldEarrings();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( earrings, 3, 10, 15 );              

                DropItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel necklace = new GoldNecklace();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( necklace, 3, 10, 15 );              

                DropItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel ring = new GoldRing();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( ring, 3, 10, 15 );              

                DropItem( ring );
            }

        }

        public AmazonTreeSettlementTreasureChest( Serial serial ) : base( serial )
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