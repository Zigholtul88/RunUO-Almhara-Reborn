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
    public class TownChestJeweler : LockableContainer
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
        public TownChestJeweler() : base( 0xE43 )
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
            DropItem( new Gold( Utility.Random( 1, 25 ) ) );

            // Supplies	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new GoldRing() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new GoldBracelet() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new GoldEarrings() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new GoldNecklace() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new GoldBeadNecklace() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new Necklace() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new Beads() );	

            // Gems

 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new Agate() );
 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new Beryl() );
 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new ChromeDiopside() );
 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new FireOpal() );
 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new MoonstoneCustom() );
 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new Onyx() );
 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new Opal() );
 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new Pearl() );
 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new TurquoiseCustom() );

 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Bloodstone() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Citrine() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Demantoid() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Jasper() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Lolite() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Lupis() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Peridot() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Tsavorite() );
 		if ( Utility.RandomDouble() < 0.04 )
            DropItem( new Zircon() );

 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Amber() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Amethyst() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Andalusite() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Chrysoberyl() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Garnet() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Jade() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Mandarin() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Morganite() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Paraiba() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new TigerEye() );
 		if ( Utility.RandomDouble() < 0.03 )
            DropItem( new Tourmaline() );

 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Alexandrite() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Ametrine() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Kunzite() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Ruby() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Sapphire() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Tanzanite() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Topaz() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Zultanite() );

 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Diamond() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new Emerald() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new PinkQuartz() );
 		if ( Utility.RandomDouble() < 0.02 )
            DropItem( new StarSapphire() );

/////////////////////////////////////// Rare Items

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel bracelet = new SilverBracelet();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( bracelet, 3, 15, 20 );              

                DropItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel earrings = new SilverEarrings();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( earrings, 3, 15, 20 );              

                DropItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel necklace = new SilverNecklace();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( necklace, 3, 15, 20 );              

                DropItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel ring = new SilverRing();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( ring, 3, 15, 20 );              

                DropItem( ring );
            }

        }

        public TownChestJeweler( Serial serial ) : base( serial )
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