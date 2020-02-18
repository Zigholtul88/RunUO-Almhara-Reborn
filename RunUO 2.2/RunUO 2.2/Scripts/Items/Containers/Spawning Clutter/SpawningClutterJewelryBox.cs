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
    public class SpawningClutterJewelryBox : LockableContainer
    {
        public override bool Decays{ get{ return true; } } 

        public override TimeSpan DecayTime{ get{ return TimeSpan.FromMinutes( Utility.Random( 30, 60 ) ); } }

        public override int DefaultGumpID{ get{ return 0x44; } }
        public override int DefaultDropSound{ get{ return 0x42; } }

        public override Rectangle2D Bounds
        {
            get{ return new Rectangle2D( 18, 105, 144, 73 ); }
        }

        [Constructable]
        public SpawningClutterJewelryBox() : base( 0x9AA )
        {
		Name = "a jewelry box -50-";
                Hue = 2417;
		Movable = true;
		Weight = 1000.0;

                TrapPower = 0;
                Locked = true;

                RequiredSkill = 50;
                LockLevel = 50;
                MaxLockLevel = 75;

/////////////////////////////////////// Jewelry

 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Agate() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Beryl() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new ChromeDiopside() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new FireOpal() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new MoonstoneCustom() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Onyx() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Opal() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Pearl() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new TurquoiseCustom() );

 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Bloodstone() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Citrine() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Demantoid() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Jasper() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Lolite() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Lupis() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Peridot() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Tsavorite() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Zircon() );

 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Amber() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Amethyst() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Andalusite() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Chrysoberyl() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Garnet() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Jade() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Mandarin() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Morganite() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Paraiba() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new TigerEye() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Tourmaline() );

 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Alexandrite() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Ametrine() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Kunzite() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Ruby() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Sapphire() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Tanzanite() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Topaz() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Zultanite() );

 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Diamond() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new Emerald() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new PinkQuartz() );
 		if ( Utility.RandomDouble() < 0.01 )
            DropItem( new StarSapphire() );

/////////////////////////////////////// Rare Items

 		if ( Utility.RandomDouble() < 0.02 )
            {
			  BaseJewel bracelet = new GoldBracelet();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( bracelet, 3, 1, 5 );              

                DropItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.02 )
            {
			  BaseJewel earrings = new GoldEarrings();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( earrings, 3, 1, 5 );              

                DropItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.02 )
            {
			  BaseJewel necklace = new GoldNecklace();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( necklace, 3, 1, 5 );              

                DropItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.02 )
            {
			  BaseJewel ring = new GoldRing();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( ring, 3, 1, 5 );              

                DropItem( ring );
            }

        }

        public SpawningClutterJewelryBox( Serial serial ) : base( serial )
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