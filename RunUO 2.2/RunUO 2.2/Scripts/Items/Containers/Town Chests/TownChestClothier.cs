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
    public class TownChestClothier : LockableContainer
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
        public TownChestClothier() : base( 0xE43 )
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

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new Cotton( Utility.Random( 25, 50 ) ) );	

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new Wool( Utility.Random( 25, 50 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new DarkYarn( Utility.Random( 25, 50 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new LightYarn( Utility.Random( 25, 50 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new LightYarnUnraveled( Utility.Random( 25, 50 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new SpoolOfThread( Utility.Random( 25, 50 ) ) );	

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new BoltOfCloth( Utility.Random( 20, 45 ) ) );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new Dyes() );	

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Leather( Utility.Random( 15, 35 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
            {
	            BaseHat hat = Loot.RandomHat( true ); 
			switch ( Utility.Random( 5 ) )
			{
			        case 0: hat = new Bandana(); break;
			        case 1: hat = new Bonnet(); break;
				case 2: hat = new FeatheredHat(); break;
				case 3: hat = new FloppyHat(); break;
				default: hat = new TricorneHat(); break;
		        }

				BaseRunicTool.ApplyAttributesTo( hat, 3, 15, 20 );

				DropItem( hat );
			}

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseClothing clothing = Loot.RandomClothing( true );
		          BaseRunicTool.ApplyAttributesTo( clothing, 3, 15, 20 );              

                          DropItem( clothing );
            }

        }

        public TownChestClothier( Serial serial ) : base( serial )
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