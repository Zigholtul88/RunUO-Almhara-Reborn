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
    public class SpawningClutterBarrel : LockableContainer
    {
        public override bool Decays{ get{ return true; } } 

        public override TimeSpan DecayTime{ get{ return TimeSpan.FromMinutes( Utility.Random( 30, 60 ) ); } }

        public override int DefaultGumpID{ get{ return 0x3E; } }
        public override int DefaultDropSound{ get{ return 0x42; } }

        public override Rectangle2D Bounds
        {
            get{ return new Rectangle2D( 18, 105, 144, 73 ); }
        }

        [Constructable]
        public SpawningClutterBarrel() : base( 0xE77 )
        {
		Name = "a barrel";
		Movable = true;
		Weight = 1000.0;

            TrapPower = 0;
            Locked = false;

            RequiredSkill = 0;
            LockLevel = 0;
            MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Dishes

 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new DirtyFrypan() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new DirtyPan() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new DirtyKettle() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new DirtyPot() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new DirtyRoundPot() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new DirtySmallPot() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new DirtySmallRoundPot() );

/////////////////////////////////////// Eating Utensils

 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new KnifeLeft() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new KnifeRight() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new PewterMug() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new Plate() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new SpoonLeft() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new SpoonRight() );

/////////////////////////////////////// Supplies

            Item ReagentLoot = Loot.RandomReagent();
            ReagentLoot.Amount = Utility.Random( 1, 5 );
            DropItem( ReagentLoot );

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

 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new Rope() );

/////////////////////////////////////// Rare Items

 		if ( Utility.RandomDouble() < 0.01 )
            {
			  BaseJewel bracelet = new GoldBracelet();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( bracelet, 1, 1, 5 );              

                DropItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.01 )
            {
			  BaseJewel earrings = new GoldEarrings();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( earrings, 1, 1, 5 );              

                DropItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.01 )
            {
			  BaseJewel necklace = new GoldNecklace();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( necklace, 1, 1, 5 );              

                DropItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.01 )
            {
			  BaseJewel ring = new GoldRing();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( ring, 1, 1, 5 );              

                DropItem( ring );
            }

        }

        public SpawningClutterBarrel( Serial serial ) : base( serial )
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