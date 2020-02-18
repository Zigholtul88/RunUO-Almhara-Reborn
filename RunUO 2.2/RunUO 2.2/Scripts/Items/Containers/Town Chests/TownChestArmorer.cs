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
    public class TownChestArmorer : LockableContainer
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
        public TownChestArmorer() : base( 0xE43 )
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

 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new ChainCoif() );
 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new ChainChest() );
 		if ( Utility.RandomDouble() < 0.06 )
            DropItem( new ChainLegs() );

 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new Bascinet() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new CloseHelm() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new NorseHelm() );
 		if ( Utility.RandomDouble() < 0.06 )
            DropItem( new PlateArms() );
 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new PlateChest() );
 		if ( Utility.RandomDouble() < 0.07 )
            DropItem( new PlateGloves() );
 		if ( Utility.RandomDouble() < 0.07 )
            DropItem( new PlateGorget() );
 		if ( Utility.RandomDouble() < 0.08 )
            DropItem( new PlateHelm() );
 		if ( Utility.RandomDouble() < 0.06 )
            DropItem( new PlateLegs() );

 		if ( Utility.RandomDouble() < 0.06 )
            DropItem( new RingmailArms() );
 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new RingmailChest() );
 		if ( Utility.RandomDouble() < 0.07 )
            DropItem( new RingmailGloves() );
 		if ( Utility.RandomDouble() < 0.06 )
            DropItem( new RingmailLegs() );

 		if ( Utility.RandomDouble() < 0.07 )
            DropItem( new BronzeShield() );
 		if ( Utility.RandomDouble() < 0.07 )
            DropItem( new Buckler() );
 		if ( Utility.RandomDouble() < 0.07 )
            DropItem( new HeaterShield() );
 		if ( Utility.RandomDouble() < 0.07 )
            DropItem( new MetalKiteShield() );
 		if ( Utility.RandomDouble() < 0.07 )
            DropItem( new MetalShield() );
 		if ( Utility.RandomDouble() < 0.07 )
            DropItem( new WoodenKiteShield() );
 		if ( Utility.RandomDouble() < 0.07 )
            DropItem( new WoodenShield() );

 		if ( Utility.RandomDouble() < 0.15 )
            {
			BaseArmor armor = Loot.RandomArmor( true );
			switch ( Utility.Random( 13 ) )
			{
			        case 0: armor = new FemaleStuddedChest(); break;
			        case 1: armor = new StuddedArms(); break;
				case 2: armor = new StuddedBustierArms(); break;
				case 3: armor = new StuddedGloves(); break;
				case 4: armor = new StuddedGorget(); break;
			        case 5: armor = new ChainCoif(); break;
				case 6: armor = new ChainChest(); break;
				case 7: armor = new ChainLegs(); break;
			        case 8: armor = new RingmailArms(); break;
				case 9: armor = new RingmailChest(); break;
				case 10: armor = new RingmailGloves(); break;
				case 11: armor = new RingmailLegs(); break;
				default: armor = new StuddedChest(); break;
		        }
			        BaseRunicTool.ApplyAttributesTo( armor, 5, 15, 20 );

				DropItem( armor );
			}
        }

        public TownChestArmorer( Serial serial ) : base( serial )
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