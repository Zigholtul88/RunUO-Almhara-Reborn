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
    public class SpawningClutterBag : LockableContainer
    {
        public override bool Decays{ get{ return true; } } 

        public override TimeSpan DecayTime{ get{ return TimeSpan.FromMinutes( Utility.Random( 30, 60 ) ); } }

        public override int DefaultGumpID{ get{ return 0x3D; } }
        public override int DefaultDropSound{ get{ return 0x48; } }

        public override Rectangle2D Bounds
        {
            get{ return new Rectangle2D( 18, 105, 144, 73 ); }
        }

        [Constructable]
        public SpawningClutterBag() : base( 0xE76 )
        {
		Name = "a bag";
		Movable = true;
		Weight = 1000.0;

            TrapPower = 0;
            Locked = false;

            RequiredSkill = 0;
            LockLevel = 0;
            MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Fruits

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Apple() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Banana() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Bananas() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Cantaloupe() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Coconut() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Dates() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Grapes() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Lemon() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Lemons() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Lime() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Limes() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Peach() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Pear() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new SmallWatermelon() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Squash() );


/////////////////////////////////////// Meats

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Bacon() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Sausage() );

/////////////////////////////////////// Vegetables

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Carrot() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new EarOfCorn() );

/////////////////////////////////////// Misc

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new CheeseWedge() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new CheeseWheel() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new FrenchBread() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new GreenGourd() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new HoneydewMelon() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new PeachCobbler() );
 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new YellowGourd() );

        }

        public SpawningClutterBag( Serial serial ) : base( serial )
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