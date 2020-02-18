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
    public class TownChestAlchemist : LockableContainer
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
        public TownChestAlchemist() : base( 0xE43 )
        {
		Name = "a metal chest -5-";
		Movable = true;
		Weight = 1000.0;

                Hue = 83;

                TrapPower = 0;
                Locked = true;

                RequiredSkill = 15;
                LockLevel = 15;
                MaxLockLevel = 20;

                // Gold
 		if ( Utility.RandomDouble() < 0.25 )
                DropItem( new Gold( Utility.Random( 1, 25 ) ) );

                // Supplies
 		if ( Utility.RandomDouble() < 0.10 )
                DropItem( new Bottle( Utility.Random( 2, 4 ) ) );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new AgilityPotion() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new LesserCurePotion() );	

 		if ( Utility.RandomDouble() < 0.05 )
		DropItem( new CurePotion() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new LesserExplosionPotion() );	

 		if ( Utility.RandomDouble() < 0.05 )
		DropItem( new ExplosionPotion() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new LesserShatterPotion() );	

 		if ( Utility.RandomDouble() < 0.05 )
		DropItem( new ShatterPotion() );

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new LesserLightningPotion() );	

 		if ( Utility.RandomDouble() < 0.05 )
		DropItem( new LightningPotion() );

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new LesserHealPotion() );	

 		if ( Utility.RandomDouble() < 0.05 )
		DropItem( new HealPotion() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new LesserPoisonPotion() );	

 		if ( Utility.RandomDouble() < 0.05 )
		DropItem( new PoisonPotion() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new NightSightPotion() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new RefreshPotion() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new StrengthPotion() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new LesserManaPotion() );	

 		if ( Utility.RandomDouble() < 0.05 )
		DropItem( new ManaPotion() );	

 		if ( Utility.RandomDouble() < 0.10 )
		DropItem( new MindPotion() );

                Item PotionLoot = Loot.RandomPotion();
                DropItem( PotionLoot );

 		if ( Utility.RandomDouble() < 0.25 )
		DropItem( new MortarPestle() );	
        }

        public TownChestAlchemist( Serial serial ) : base( serial )
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