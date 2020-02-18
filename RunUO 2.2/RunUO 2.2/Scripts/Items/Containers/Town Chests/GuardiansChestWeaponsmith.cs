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
    public class GuardiansChestWeaponsmith : LockableContainer
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
        public GuardiansChestWeaponsmith() : base( 0xE43 )
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

 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new CrescentBlade() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Scepter() );

 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new Scythe() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Arrow( Utility.Random( 25, 30 ) ) );

/////////////////////////////////////// Rare Items

 		if ( Utility.RandomDouble() < 0.15 )
            {
	            BaseWeapon weapon = Loot.RandomWeapon( true );
			switch ( Utility.Random( 11 ) )
			{
				case 0: weapon = new BladedStaff(); break;
				case 1: weapon = new BoneHarvester(); break;
				case 2: weapon = new CompositeBow(); break;
				case 3: weapon = new CrescentBlade(); break;
			      case 4: weapon = new DoubleBladedStaff(); break;
				case 5: weapon = new Lance(); break;
				case 6: weapon = new PaladinSword(); break;
				case 7: weapon = new Pike(); break;
				case 8: weapon = new RepeatingCrossbow(); break;
				case 9: weapon = new Scepter(); break;
				default: weapon = new Scythe(); break;
			}
			      BaseRunicTool.ApplyAttributesTo( weapon, 5, 15, 20 );

				DropItem( weapon );
			}
        }

        public GuardiansChestWeaponsmith( Serial serial ) : base( serial )
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