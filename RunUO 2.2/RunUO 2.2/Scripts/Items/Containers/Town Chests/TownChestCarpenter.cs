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
    public class TownChestCarpenter : LockableContainer
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
        public TownChestCarpenter() : base( 0xE43 )
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
		DropItem( new ChiselsNorth() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new ChiselsWest() );	

 		if ( Utility.RandomDouble() < 0.20 )
		DropItem( new DovetailSaw() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Hammer() );	

 		if ( Utility.RandomDouble() < 0.25 )
		DropItem( new MouldingPlane() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Nails() );	

 		if ( Utility.RandomDouble() < 0.20 )
		DropItem( new JointingPlane() );	

 		if ( Utility.RandomDouble() < 0.20 )
		DropItem( new SmoothingPlane() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Saw() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new DrawKnife() );	

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Log( Utility.Random( 55, 75 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Froe() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Inshave() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Scorp() );	
        }

        public TownChestCarpenter( Serial serial ) : base( serial )
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