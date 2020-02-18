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
    public class IngredientBag : LockableContainer
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
        public IngredientBag() : base( 0xE76 )
        {
		Name = "a bag";
		Movable = true;
		Weight = 1000.0;

            TrapPower = 0;
            Locked = false;

            RequiredSkill = 0;
            LockLevel = 0;
            MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Ingredients

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new ArcaneStone( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new BlackGear( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new BeetleEgg( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Bonemeal( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new BronzeGear( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new CharredFeather( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new CrimsonGear( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new DiamondDust( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new DragonScale( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new ElementalDust( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new FishScale( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new LichDust( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new Nirnroot( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new SerpentScale( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new ShadowEssence( Utility.Random( 15, 35 ) ) );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new SpiderEgg( Utility.Random( 15, 35 ) ) );
        }

        public IngredientBag( Serial serial ) : base( serial )
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