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
    public class GrizzlyBearCavernsTreasureChest : LockableContainer
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
        public GrizzlyBearCavernsTreasureChest() : base( 0xE43 )
        {
		Name = "a treasure chest";
		Movable = true;
		Weight = 1000.0;

            TrapPower = 0;
            Locked = false;

            RequiredSkill = 0;
            LockLevel = 0;
            MaxLockLevel = this.RequiredSkill;

            // Gold
 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Gold( Utility.Random( 50, 100 ) ) );

		DropItem( new OneGoldBar() );	

/////////////////////////////////////// Supplies

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Arrow( Utility.Random( 10, 15 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Bolt( Utility.Random( 10, 15 ) ) );

            Item ReagentLoot = Loot.RandomReagent();
            ReagentLoot.Amount = Utility.Random( 10, 15 );
            DropItem( ReagentLoot );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Bandage( Utility.Random( 1, 5 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Bedroll() );	

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Bottle( Utility.Random( 1, 5 ) ) );	

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Lockpick( Utility.Random( 5, 10 ) ) );

            Item PotionLoot = Loot.RandomPotion();
            DropItem( PotionLoot );

/////////////////////////////////////// Tools

 		if ( Utility.RandomDouble() < 0.25 )
		DropItem( new FishingPole() );	

 		if ( Utility.RandomDouble() < 0.25 )
		DropItem( new Shovel() );

 		if ( Utility.RandomDouble() < 0.25 )
		DropItem( new Skillet() );	

/////////////////////////////////////// Rare Items

 		if ( Utility.RandomDouble() < 0.25 )
		DropItem( new HoodedShroudOfShadows() );

 		if ( Utility.RandomDouble() < 0.25 )
		DropItem( new BearMask() );	

 		if ( Utility.RandomDouble() < 0.25 )
		DropItem( new MagicArrowWand() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new RunicDullCopper() );	
        }

        public GrizzlyBearCavernsTreasureChest( Serial serial ) : base( serial )
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