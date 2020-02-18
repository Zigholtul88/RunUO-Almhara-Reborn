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
    public class ZaythalorFarmHouseTreasureChest : LockableContainer
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
        public ZaythalorFarmHouseTreasureChest() : base( 0xE43 )
        {
		Name = "a treasure chest";
		Movable = true;
		Weight = 1000.0;

            TrapPower = 0;
            Locked = false;

            RequiredSkill = 0;
            LockLevel = 0;
            MaxLockLevel = this.RequiredSkill;

            // Gold
 		if ( Utility.RandomDouble() < 0.25 )
            DropItem( new Gold( Utility.Random( 25, 50 ) ) );

		DropItem( new OneGoldBar() );	

/////////////////////////////////////// Supplies

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Arrow( Utility.Random( 1, 5 ) ) );

            Item ReagentLoot = Loot.RandomReagent();
            ReagentLoot.Amount = Utility.Random( 1, 5 );
            DropItem( ReagentLoot );

 		if ( Utility.RandomDouble() < 0.15 )
            DropItem( new Bandage( Utility.Random( 1, 5 ) ) );

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Bedroll() );	

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Bottle( Utility.Random( 1, 5 ) ) );	

 		if ( Utility.RandomDouble() < 0.20 )
            DropItem( new Lockpick( Utility.Random( 1, 5 ) ) );

            Item PotionLoot = Loot.RandomPotion();
            DropItem( PotionLoot );

/////////////////////////////////////// Tools

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new FishingPole() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Shovel() );

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Skillet() );	

/////////////////////////////////////// Rare Items

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new FineOpalPendant() );

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new TamersHandbookVol2() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new Tanzanite() );	

 		if ( Utility.RandomDouble() < 0.15 )
		DropItem( new CrackedHitFireballGem() );	

 		if ( Utility.RandomDouble() < 0.25 )
            {
	            BaseWeapon weapon = Loot.RandomWeapon( true );
			switch ( Utility.Random( 7 ) )
			{
				case 0: weapon = new Hatchet(); break;
				case 1: weapon = new Bow(); break;
				case 2: weapon = new Club(); break;
				case 3: weapon = new Pitchfork(); break;
				case 4: weapon = new GnarledStaff(); break;
				case 5: weapon = new ShepherdsCrook(); break;
				default: weapon = new Dagger(); break;
			}

			  BaseRunicTool.ApplyAttributesTo( weapon, 3, 10, 15 );
			  weapon.DamageLevel = (WeaponDamageLevel)Utility.Random( 2 );
			  weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random( 2 );
			  weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random( 2 );
                    weapon.Quality = WeaponQuality.Regular;

				DropItem( weapon );
			}
        }

        public ZaythalorFarmHouseTreasureChest( Serial serial ) : base( serial )
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