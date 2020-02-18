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
    public class TownChestArtisanGuild : LockableContainer
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
        public TownChestArtisanGuild() : base( 0xE43 )
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
            DropItem( new Gold( Utility.Random( 1, 50 ) ) );

            // Supplies

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new PaintsAndBrush() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new SledgeHammer() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new SmithHammer() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new Tongs() );	

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Lockpick( Utility.Random( 3, 5 ) ) );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new TinkerTools() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new MalletAndChisel() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new StatueEast2() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new StatueSouth() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new StatueSouthEast() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new StatueWest() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new StatueNorth() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new StatueEast() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new BustEast() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new BustSouth() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new BearMask() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new DeerMask() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new OrcHelm() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new TribalMask() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new HornedTribalMask() );
        }

        public TownChestArtisanGuild( Serial serial ) : base( serial )
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