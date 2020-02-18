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
    public class TownChestWeaponsmith : LockableContainer
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
        public TownChestWeaponsmith() : base( 0xE43 )
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

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Axe() );

 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new DoubleAxe() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new LargeBattleAxe() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Mace() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Maul() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new WarMace() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new ShortSpear() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Spear() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Longsword() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Scimitar() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Arrow( Utility.Random( 25, 30 ) ) );

/////////////////////////////////////// Rare Items

 		if ( Utility.RandomDouble() < 0.15 )
            {
	            BaseWeapon weapon = Loot.RandomWeapon( true );
			switch ( Utility.Random( 38 ) )
			{
				case 0: weapon = new Hatchet(); break;
				case 1: weapon = new Bow(); break;
				case 2: weapon = new Crossbow(); break;
				case 3: weapon = new Club(); break;
			        case 4: weapon = new Mace(); break;
				case 5: weapon = new Maul(); break;
				case 6: weapon = new Pitchfork(); break;
				case 7: weapon = new ShortSpear(); break;
				case 8: weapon = new GnarledStaff(); break;
				case 9: weapon = new ShepherdsCrook(); break;
				case 10: weapon = new Cutlass(); break;
				case 11: weapon = new Katana(); break;
				case 12: weapon = new Kryss(); break;
				case 13: weapon = new Scimitar(); break;
				case 14: weapon = new AssassinSpike(); break;
				case 15: weapon = new DiamondMace(); break;
				case 16: weapon = new Leafblade(); break;
				case 17: weapon = new MagicalShortbow(); break;
				case 18: weapon = new RadiantScimitar(); break;
				case 19: weapon = new WildStaff(); break;
				case 20: weapon = new Axe(); break;
				case 21: weapon = new ExecutionersAxe(); break;
				case 22: weapon = new Pickaxe(); break;
				case 23: weapon = new TwoHandedAxe(); break;
				case 24: weapon = new WarAxe(); break;
				case 25: weapon = new HeavyCrossbow(); break;
				case 26: weapon = new HammerPick(); break;
				case 27: weapon = new WarMace(); break;
				case 28: weapon = new Spear(); break;
				case 29: weapon = new WarFork(); break;
				case 30: weapon = new BlackStaff(); break;
				case 31: weapon = new QuarterStaff(); break;
				case 32: weapon = new Longsword(); break;
				case 33: weapon = new ElvenCompositeLongbow(); break;
				case 34: weapon = new ElvenMachete(); break;
				case 35: weapon = new ElvenSpellblade(); break;
				case 36: weapon = new RuneBlade(); break;
				default: weapon = new Dagger(); break;
			}
			        BaseRunicTool.ApplyAttributesTo( weapon, 5, 15, 20 );

				DropItem( weapon );
			}
        }

        public TownChestWeaponsmith( Serial serial ) : base( serial )
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