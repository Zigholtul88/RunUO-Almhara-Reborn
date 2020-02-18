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
    public class TownChestButcher : LockableContainer
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
        public TownChestButcher() : base( 0xE43 )
        {
		Name = "a metal chest -5-";
		Movable = true;
		Weight = 1000.0;

                Hue = 83;

            TrapPower = 0;
            Locked = true;

            RequiredSkill = 5;
            LockLevel = 5;
            MaxLockLevel = 10;

            // Gold
 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Gold( Utility.Random( 1, 25 ) ) );

            // Supplies	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Cleaver() );	

 		if ( Utility.RandomDouble() < 0.20 )
		DropItem( new SlabOfBacon() );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bacon( Utility.Random( 15, 25 ) ) );

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new RawFishSteak( Utility.Random( 15, 30 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new FishSteak( Utility.Random( 15, 30 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new CookedBird( Utility.Random( 15, 25 ) ) );

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new RawBird( Utility.Random( 15, 30 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Ham( Utility.Random( 20, 25 ) ) );

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new RawLambLeg( Utility.Random( 15, 30 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Ribs( Utility.Random( 10, 20 ) ) );

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new RawRibs( Utility.Random( 15, 30 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Sausage( Utility.Random( 20, 25 ) ) );

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new RawChickenLeg( Utility.Random( 15, 30 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new ChickenLeg( Utility.Random( 15, 30 ) ) );
        }

        public TownChestButcher( Serial serial ) : base( serial )
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