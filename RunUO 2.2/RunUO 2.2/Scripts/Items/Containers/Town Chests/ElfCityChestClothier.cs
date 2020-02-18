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
    public class ElfCityChestClothier : LockableContainer
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
        public ElfCityChestClothier() : base( 0x2DF2 )
        {
		Name = "a metal chest -5-";
                Hue = 663;
		Movable = true;
		Weight = 1000.0;

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
	            BaseClothing clothing = Loot.RandomClothing( true ); 
			switch ( Utility.Random( 7 ) )
			{
			      case 0: clothing = new ElvenDarkShirt(); break;
			      case 1: clothing = new ElvenPants(); break;
				case 2: clothing = new ElvenRobe(); break;
				case 3: clothing = new ElvenShirt(); break;
				case 4: clothing = new FemaleElvenRobe(); break;
				case 5: clothing = new WoodlandBelt(); break;
				default: clothing = new ElvenBoots(); break;
		        }

				BaseRunicTool.ApplyAttributesTo( clothing, 3, 15, 20 );

				DropItem( clothing );
			}
        }

        public ElfCityChestClothier( Serial serial ) : base( serial )
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