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
    public class SpawningClutterDresser5 : LockableContainer
    {
        public override bool Decays{ get{ return true; } } 

        public override TimeSpan DecayTime{ get{ return TimeSpan.FromMinutes( Utility.Random( 30, 60 ) ); } }

        public override int DefaultGumpID{ get{ return 0x4F; } }
        public override int DefaultDropSound{ get{ return 0x42; } }

        public override Rectangle2D Bounds
        {
            get{ return new Rectangle2D( 18, 105, 144, 73 ); }
        }

        [Constructable]
        public SpawningClutterDresser5() : base( 0xA4F )
        {
		Name = "a dresser";
		Movable = true;
		Weight = 1000.0;

                TrapPower = 0;
                Locked = false;

                RequiredSkill = 0;
                LockLevel = 0;
                MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Clothes 1

 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing1 = Loot.RandomClothing( true );
                          clothing1.Hue = Utility.RandomBirdHue();
                          DropItem( clothing1 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing2 = Loot.RandomClothing( true );
                          clothing2.Hue = Utility.RandomBirdHue();
                          DropItem( clothing2 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing3 = Loot.RandomClothing( true );
                          clothing3.Hue = Utility.RandomBirdHue();
                          DropItem( clothing3 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing4 = Loot.RandomClothing( true );
                          clothing4.Hue = Utility.RandomBirdHue();
                          DropItem( clothing4 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing5 = Loot.RandomClothing( true );
                          clothing5.Hue = Utility.RandomBirdHue();
                          DropItem( clothing5 );
                }

/////////////////////////////////////// Clothes 2

 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing6 = Loot.RandomClothing( true );
                          clothing6.Hue = Utility.RandomBlueHue();
                          DropItem( clothing6 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing7 = Loot.RandomClothing( true );
                          clothing7.Hue = Utility.RandomBlueHue();
                          DropItem( clothing7 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing8 = Loot.RandomClothing( true );
                          clothing8.Hue = Utility.RandomBlueHue();
                          DropItem( clothing8 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing9 = Loot.RandomClothing( true );
                          clothing9.Hue = Utility.RandomBlueHue();
                          DropItem( clothing9 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing10 = Loot.RandomClothing( true );
                          clothing10.Hue = Utility.RandomBlueHue();
                          DropItem( clothing10 );
                }

/////////////////////////////////////// Clothes 3

 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing11 = Loot.RandomClothing( true );
                          clothing11.Hue = Utility.RandomNondyedHue();
                          DropItem( clothing11 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing12 = Loot.RandomClothing( true );
                          clothing12.Hue = Utility.RandomNondyedHue();
                          DropItem( clothing12 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing13 = Loot.RandomClothing( true );
                          clothing13.Hue = Utility.RandomNondyedHue();
                          DropItem( clothing13 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing14 = Loot.RandomClothing( true );
                          clothing14.Hue = Utility.RandomNondyedHue();
                          DropItem( clothing14 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing15 = Loot.RandomClothing( true );
                          clothing15.Hue = Utility.RandomNondyedHue();
                          DropItem( clothing15 );
                }

/////////////////////////////////////// Rare Items

 		if ( Utility.RandomDouble() < 0.01 )
                {
			  BaseClothing magiccloth1 = Loot.RandomClothing( true );
		          BaseRunicTool.ApplyAttributesTo( magiccloth1, 3, 1, 5 );
                          magiccloth1.Hue = Utility.RandomPinkHue();
                          DropItem( magiccloth1 );
                }
 		if ( Utility.RandomDouble() < 0.01 )
                {
			  BaseClothing magiccloth2 = Loot.RandomClothing( true );
		          BaseRunicTool.ApplyAttributesTo( magiccloth2, 3, 1, 5 );
                          magiccloth2.Hue = Utility.RandomPinkHue();
                          DropItem( magiccloth2 );
                }
 		if ( Utility.RandomDouble() < 0.01 )
                {
			  BaseClothing magiccloth3 = Loot.RandomClothing( true );
		          BaseRunicTool.ApplyAttributesTo( magiccloth3, 3, 1, 5 );
                          magiccloth3.Hue = Utility.RandomPinkHue();
                          DropItem( magiccloth3 );
                }
        }

        public SpawningClutterDresser5( Serial serial ) : base( serial )
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