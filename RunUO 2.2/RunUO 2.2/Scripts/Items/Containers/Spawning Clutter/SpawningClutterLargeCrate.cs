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
    [Flipable( 0xE3D, 0xE3C )]
    public class SpawningClutterLargeCrate : LockableContainer
    {
        public override bool Decays{ get{ return true; } } 

        public override TimeSpan DecayTime{ get{ return TimeSpan.FromMinutes( Utility.Random( 30, 60 ) ); } }

        public override int DefaultGumpID{ get{ return 0x44; } }
        public override int DefaultDropSound{ get{ return 0x42; } }

        public override Rectangle2D Bounds
        {
            get{ return new Rectangle2D( 18, 105, 144, 73 ); }
        }

        [Constructable]
        public SpawningClutterLargeCrate() : base( 0xE3D )
        {
		Name = "a large crate";
		Movable = true;
		Weight = 1000.0;

            TrapPower = 0;
            Locked = false;

            RequiredSkill = 0;
            LockLevel = 0;
            MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Dishes

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new DirtyFrypan() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new DirtyPan() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new DirtyKettle() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new DirtyPot() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new DirtyRoundPot() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new DirtySmallPot() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new DirtySmallRoundPot() );

/////////////////////////////////////// Eating Utensils

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new KnifeLeft() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new KnifeRight() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new PewterMug() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Plate() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new SpoonLeft() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new SpoonRight() );

/////////////////////////////////////// Supplies

            Item ReagentLoot = Loot.RandomReagent();
            ReagentLoot.Amount = Utility.Random( 1, 5 );
            DropItem( ReagentLoot );

 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new BoltOfCloth( Utility.Random( 1, 5 ) ) );

 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Arrow( Utility.Random( 1, 5 ) ) );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Bolt( Utility.Random( 1, 5 ) ) );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Bandage( Utility.Random( 1, 5 ) ) );

 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new IronIngot( Utility.Random( 1, 5 ) ) );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Leather( Utility.Random( 1, 5 ) ) );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Log( Utility.Random( 1, 5 ) ) );

 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new CopperWire( Utility.Random( 1, 5 ) ) );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Feather( Utility.Random( 1, 5 ) ) );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Gears( Utility.Random( 1, 5 ) ) );

 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new GoldWire( Utility.Random( 1, 5 ) ) );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new IronWire( Utility.Random( 1, 5 ) ) );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Shaft( Utility.Random( 1, 5 ) ) );

 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new SilverWire( Utility.Random( 1, 5 ) ) );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new SpoolOfThread( Utility.Random( 1, 5 ) ) );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Springs( Utility.Random( 1, 5 ) ) );

/////////////////////////////////////// Tools

 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Hammer() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Lockpick( Utility.Random( 1, 5 ) ) );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new Shovel() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new SmithHammer() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Tongs() );

/////////////////////////////////////// Misc

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Rope() );

/////////////////////////////////////// Rare Items

 		if ( Utility.RandomDouble() < 0.01 )
            {
			  BaseJewel bracelet = new SilverBracelet();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( bracelet, 1, 1, 5 );              

                DropItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.01 )
            {
			  BaseJewel earrings = new SilverEarrings();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( earrings, 1, 1, 5 );              

                DropItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.01 )
            {
			  BaseJewel necklace = new SilverNecklace();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( necklace, 1, 1, 5 );              

                DropItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.01 )
            {
			  BaseJewel ring = new SilverRing();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( ring, 1, 1, 5 );              

                DropItem( ring );
            }

        }

        public SpawningClutterLargeCrate( Serial serial ) : base( serial )
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