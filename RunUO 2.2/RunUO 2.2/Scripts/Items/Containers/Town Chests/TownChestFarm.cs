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
    public class TownChestFarm : LockableContainer
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
        public TownChestFarm() : base( 0xE43 )
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
		DropItem( new Shirt() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new ShortPants() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new Skirt() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new PlainDress() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Cap() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Sandals() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new GnarledStaff() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new Pitchfork() );	

 		if ( Utility.RandomDouble() < 0.25 )
		DropItem( new Bag() );	

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Kindling( Utility.Random( 1, 3 ) ) );	

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new Lettuce( Utility.Random( 1, 3 ) ) );	

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new Onion( Utility.Random( 1, 3 ) ) );	

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new Turnip( Utility.Random( 1, 3 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Ham( Utility.Random( 1, 3 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bacon( Utility.Random( 1, 3 ) ) );	

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new RawLambLeg( Utility.Random( 1, 3 ) ) );	

 		if ( Utility.RandomDouble() < 0.20 )
		DropItem( new SheafOfHay() );	

 		if ( Utility.RandomDouble() < 0.10 )
            {
	                BaseWeapon weapon = Loot.RandomWeapon( true );
			switch ( Utility.Random( 2 ) )
			{
				case 0: weapon = new GnarledStaff(); break;
				default: weapon = new Pitchfork(); break;
			}
			        BaseRunicTool.ApplyAttributesTo( weapon, 2, 10, 15 );

				DropItem( weapon );
			}
        }

        public TownChestFarm( Serial serial ) : base( serial )
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