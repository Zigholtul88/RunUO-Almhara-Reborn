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
    public class SpawningClutterDresser2 : LockableContainer
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
        public SpawningClutterDresser2() : base( 0xA53 )
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
                          clothing1.Hue = 90;
                          DropItem( clothing1 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing2 = Loot.RandomClothing( true );
                          clothing2.Hue = 90;
                          DropItem( clothing2 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing3 = Loot.RandomClothing( true );
                          clothing3.Hue = 90;
                          DropItem( clothing3 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing4 = Loot.RandomClothing( true );
                          clothing4.Hue = 90;
                          DropItem( clothing4 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing5 = Loot.RandomClothing( true );
                          clothing5.Hue = 90;
                          DropItem( clothing5 );
                }

/////////////////////////////////////// Clothes 2

 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing6 = Loot.RandomClothing( true );
                          clothing6.Hue = 238;
                          DropItem( clothing6 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing7 = Loot.RandomClothing( true );
                          clothing7.Hue = 238;
                          DropItem( clothing7 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing8 = Loot.RandomClothing( true );
                          clothing8.Hue = 238;
                          DropItem( clothing8 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing9 = Loot.RandomClothing( true );
                          clothing9.Hue = 238;
                          DropItem( clothing9 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing10 = Loot.RandomClothing( true );
                          clothing10.Hue = 238;
                          DropItem( clothing10 );
                }

/////////////////////////////////////// Clothes 3

 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing11 = Loot.RandomClothing( true );
                          clothing11.Hue = 164;
                          DropItem( clothing11 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing12 = Loot.RandomClothing( true );
                          clothing12.Hue = 164;
                          DropItem( clothing12 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing13 = Loot.RandomClothing( true );
                          clothing13.Hue = 164;
                          DropItem( clothing13 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing14 = Loot.RandomClothing( true );
                          clothing14.Hue = 164;
                          DropItem( clothing14 );
                }
 		if ( Utility.RandomDouble() < 0.10 )
                {
			  BaseClothing clothing15 = Loot.RandomClothing( true );
                          clothing15.Hue = 164;
                          DropItem( clothing15 );
                }

/////////////////////////////////////// Rare Items

 		if ( Utility.RandomDouble() < 0.01 )
                {
			  BaseClothing magiccloth1 = Loot.RandomClothing( true );
		          BaseRunicTool.ApplyAttributesTo( magiccloth1, 3, 1, 5 );
                          DropItem( magiccloth1 );
                }
 		if ( Utility.RandomDouble() < 0.01 )
                {
			  BaseClothing magiccloth2 = Loot.RandomClothing( true );
		          BaseRunicTool.ApplyAttributesTo( magiccloth2, 3, 1, 5 );
                          DropItem( magiccloth2 );
                }
 		if ( Utility.RandomDouble() < 0.01 )
                {
			  BaseClothing magiccloth3 = Loot.RandomClothing( true );
		          BaseRunicTool.ApplyAttributesTo( magiccloth3, 3, 1, 5 );
                          DropItem( magiccloth3 );
                }
        }

        public SpawningClutterDresser2( Serial serial ) : base( serial )
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