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
    public class TownChestRanger : LockableContainer
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
        public TownChestRanger() : base( 0xE43 )
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
		DropItem( new Bow() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Crossbow() );	

 		if ( Utility.RandomDouble() < 0.08 )
		DropItem( new HeavyCrossbow() );	

 		if ( Utility.RandomDouble() < 0.08 )
		DropItem( new CompositeBow() );	

 		if ( Utility.RandomDouble() < 0.08 )
		DropItem( new RepeatingCrossbow() );	

 		if ( Utility.RandomDouble() < 0.08 )
		DropItem( new ElvenCompositeLongbow() );	

 		if ( Utility.RandomDouble() < 0.08 )
		DropItem( new MagicalShortbow() );	

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Arrow( Utility.Random( 50, 100 ) ) );	

 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Bolt( Utility.Random( 50, 100 ) ) );	

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new RangerArms() );

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new RangerChest() );

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new RangerGloves() );

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new RangerGorget() );

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new RangerLegs() );


/////////////////////////////////////// Rare Items

 		if ( Utility.RandomDouble() < 0.25 )
            {
	            BaseWeapon weapon = Loot.RandomWeapon( true );
			switch ( Utility.Random( 4 ) )
			{
				case 0: weapon = new CompositeBow(); break;
				case 1: weapon = new ElvenCompositeLongbow(); break;
				case 2: weapon = new MagicalShortbow(); break;
				default: weapon = new Bow(); break;
			}

			        BaseRunicTool.ApplyAttributesTo( weapon, 5, 10, 15 );

				DropItem( weapon );
			}

 		if ( Utility.RandomDouble() < 0.25 )
            {
	            BaseWeapon crossbow = Loot.RandomWeapon( true );
			switch ( Utility.Random( 3 ) )
			{
				case 0: crossbow = new HeavyCrossbow(); break;
				case 1: crossbow = new RepeatingCrossbow(); break;
				default: crossbow = new Crossbow(); break;
			}

			        BaseRunicTool.ApplyAttributesTo( crossbow, 5, 10, 15 );

				DropItem( crossbow );
			}
        }

        public TownChestRanger( Serial serial ) : base( serial )
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