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
    public class TownChestInn : LockableContainer
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
        public TownChestInn() : base( 0xE43 )
        {
		Name = "a metal chest -25-";
		Movable = true;
		Weight = 1000.0;

                Hue = 83;

                TrapPower = 0;
                Locked = true;

                RequiredSkill = 25;
                LockLevel = 25;
                MaxLockLevel = 30;

                // Gold
 		if ( Utility.RandomDouble() < 0.25 )
                DropItem( new Gold( Utility.Random( 1, 25 ) ) );

                // Supplies	
 		if ( Utility.RandomDouble() < 0.25 )
		DropItem( new Candle() );	

 		if ( Utility.RandomDouble() < 0.20 )
		DropItem( new Torch() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new Lantern() );

                // Components
 		if ( Utility.RandomDouble() < 0.15 )
                DropItem( new Beeswax( Utility.Random( 1, 25 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
                DropItem( new IronIngot( Utility.Random( 1, 25 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
                DropItem( new SpoolOfThread( Utility.Random( 1, 25 ) ) );

                // Rares	
 		if ( Utility.RandomDouble() < 0.02 )
		DropItem( new BlueCandle() );

 		if ( Utility.RandomDouble() < 0.02 )
		DropItem( new GreenCandle() );

 		if ( Utility.RandomDouble() < 0.02 )
		DropItem( new WhiteCandle() );

 		if ( Utility.RandomDouble() < 0.01 )
		DropItem( new HolyCandle() );
        }

        public TownChestInn( Serial serial ) : base( serial )
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