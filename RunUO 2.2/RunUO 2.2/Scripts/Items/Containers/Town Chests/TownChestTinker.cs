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
    public class TownChestTinker : LockableContainer
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
        public TownChestTinker() : base( 0xE43 )
        {
		Name = "a metal chest -20-";
		Movable = true;
		Weight = 1000.0;

                Hue = 83;

            TrapPower = 0;
            Locked = true;

            RequiredSkill = 20;
            LockLevel = 20;
            MaxLockLevel = 25;

            // Gold
 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Gold( Utility.Random( 1, 50 ) ) );

            // Supplies	

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Lockpick( Utility.Random( 3, 5 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new KeyRing() );

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new KeyRing() );

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new Clock() );	

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new ClockParts( Utility.Random( 5, 15 ) ) );	

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new AxleGears( Utility.Random( 5, 15 ) ) );	

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Gears( Utility.Random( 5, 15 ) ) );		

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Hinge( Utility.Random( 5, 15 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Sextant() );	

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new SextantParts( Utility.Random( 5, 15 ) ) );	

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Axle( Utility.Random( 5, 15 ) ) );

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Springs( Utility.Random( 5, 15 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new TinkerTools() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Key() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new BlackGear( Utility.Random( 5, 15 ) ) );	

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new BronzeGear( Utility.Random( 5, 15 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new ArcaneStone( Utility.Random( 5, 15 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new ArcaneStone( Utility.Random( 5, 10 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new ArcaneStone( Utility.Random( 5, 15 ) ) );
        }

        public TownChestTinker( Serial serial ) : base( serial )
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