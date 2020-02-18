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
    public class TownChestBlacksmith : LockableContainer
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
        public TownChestBlacksmith() : base( 0xE43 )
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

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new SmithHammer() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Tongs() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new SledgeHammer() );	

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new IronOre( Utility.Random( 25, 50 ) ) );	

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new IronIngot( Utility.Random( 50, 100 ) ) );	

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new DullCopperIngot( Utility.Random( 35, 50 ) ) );	

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new ShadowIronIngot( Utility.Random( 30, 45 ) ) );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new IronWire() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new SilverWire() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new GoldWire() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new CopperWire() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new HorseShoes() );	

 		if ( Utility.RandomDouble() < 0.20 )
		DropItem( new ForgedMetal() );

 		if ( Utility.RandomDouble() < 0.15 )
            {
			  BaseShield shield = new HeaterShield();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( shield, 5, 15, 20 );              

                DropItem( shield );
            }
        }

        public TownChestBlacksmith( Serial serial ) : base( serial )
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