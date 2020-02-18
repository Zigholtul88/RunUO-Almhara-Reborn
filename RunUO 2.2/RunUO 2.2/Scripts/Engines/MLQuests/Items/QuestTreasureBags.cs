using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Items;

namespace Server.Engines.MLQuests.Items
{
        public class SmallBagOfTreasure : LockableContainer
        {
                public override int DefaultGumpID{ get{ return 0x3D; } }
                public override int DefaultDropSound{ get{ return 0x48; } }

                public override Rectangle2D Bounds
                {
                       get{ return new Rectangle2D( 18, 105, 144, 73 ); }
                }

                [Constructable]
                public SmallBagOfTreasure() : base( 0xE76 )
                {
		        Name = "a goodie bag";
		        Movable = true;
		        Weight = 1.0;

                        TrapPower = 0;
                        Locked = false;

                        RequiredSkill = 0;
                        LockLevel = 0;
                        MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Gold
                        DropItem( new Gold( Utility.Random( 100, 200 ) ) );

/////////////////////////////////////// Gems
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
                }

                public SmallBagOfTreasure( Serial serial ) : base( serial )
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

        public class MediumBagOfTreasure : LockableContainer
        {
                public override int DefaultGumpID{ get{ return 0x3D; } }
                public override int DefaultDropSound{ get{ return 0x48; } }

                public override Rectangle2D Bounds
                {
                       get{ return new Rectangle2D( 18, 105, 144, 73 ); }
                }

                [Constructable]
                public MediumBagOfTreasure() : base( 0xE76 )
                {
		        Name = "a goodie bag";
		        Movable = true;
		        Weight = 1.0;

                        TrapPower = 0;
                        Locked = false;

                        RequiredSkill = 0;
                        LockLevel = 0;
                        MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Gold
                        DropItem( new Gold( Utility.Random( 200, 300 ) ) );

/////////////////////////////////////// Gems
 		        if ( Utility.RandomDouble() < 0.10 )
                             DropItem( new Agate() );
 		        if ( Utility.RandomDouble() < 0.10 )
                             DropItem( new Beryl() );
 		        if ( Utility.RandomDouble() < 0.10 )
                             DropItem( new ChromeDiopside() );
 		        if ( Utility.RandomDouble() < 0.10 )
                             DropItem( new FireOpal() );
 		        if ( Utility.RandomDouble() < 0.10 )
                             DropItem( new MoonstoneCustom() );
 		        if ( Utility.RandomDouble() < 0.10 )
                             DropItem( new Onyx() );
 		        if ( Utility.RandomDouble() < 0.10 )
                             DropItem( new Opal() );
 		        if ( Utility.RandomDouble() < 0.10 )
                             DropItem( new Pearl() );
 		        if ( Utility.RandomDouble() < 0.10 )
                             DropItem( new TurquoiseCustom() );
                }

                public MediumBagOfTreasure( Serial serial ) : base( serial )
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

        public class LargeBagOfTreasure : LockableContainer
        {
                public override int DefaultGumpID{ get{ return 0x3D; } }
                public override int DefaultDropSound{ get{ return 0x48; } }

                public override Rectangle2D Bounds
                {
                       get{ return new Rectangle2D( 18, 105, 144, 73 ); }
                }

                [Constructable]
                public LargeBagOfTreasure() : base( 0xE76 )
                {
		        Name = "a goodie bag";
		        Movable = true;
		        Weight = 1.0;

                        TrapPower = 0;
                        Locked = false;

                        RequiredSkill = 0;
                        LockLevel = 0;
                        MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Gold
                        DropItem( new Gold( Utility.Random( 350, 500 ) ) );

/////////////////////////////////////// Gems
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Agate() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Beryl() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new ChromeDiopside() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new FireOpal() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new MoonstoneCustom() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Onyx() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Opal() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Pearl() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new TurquoiseCustom() );
                }

                public LargeBagOfTreasure( Serial serial ) : base( serial )
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

/////////////////////////////// Spanish Bag of Treasure
        public class GranBolsaDeBillones : LockableContainer
        {
                public override int DefaultGumpID{ get{ return 0x3D; } }
                public override int DefaultDropSound{ get{ return 0x48; } }

                public override Rectangle2D Bounds
                {
                       get{ return new Rectangle2D( 18, 105, 144, 73 ); }
                }

                [Constructable]
                public GranBolsaDeBillones() : base( 0xE76 )
                {
		        Name = "una bolsa de regalos";
		        Movable = true;
		        Weight = 1.0;

                        TrapPower = 0;
                        Locked = false;

                        RequiredSkill = 0;
                        LockLevel = 0;
                        MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Gold
                        DropItem( new Gold( Utility.Random( 500, 1000 ) ) );

/////////////////////////////////////// Gems
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Agate() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Beryl() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new ChromeDiopside() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new FireOpal() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new MoonstoneCustom() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Onyx() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Opal() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Pearl() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new TurquoiseCustom() );
                }

                public GranBolsaDeBillones( Serial serial ) : base( serial )
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

/////////////////////////////// Backwards Bag of Treasure
        public class erusaerTfOgaBegraL : LockableContainer
        {
                public override int DefaultGumpID{ get{ return 0x3D; } }
                public override int DefaultDropSound{ get{ return 0x48; } }

                public override Rectangle2D Bounds
                {
                       get{ return new Rectangle2D( 18, 105, 144, 73 ); }
                }

                [Constructable]
                public erusaerTfOgaBegraL() : base( 0xE76 )
                {
		        Name = "gab eidoog a";
		        Movable = true;
		        Weight = 1.0;

                        TrapPower = 0;
                        Locked = false;

                        RequiredSkill = 0;
                        LockLevel = 0;
                        MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Gold
                        DropItem( new Gold( Utility.Random( 250, 500 ) ) );

/////////////////////////////////////// Gems
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Agate() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Beryl() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new ChromeDiopside() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new FireOpal() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new MoonstoneCustom() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Onyx() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Opal() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new Pearl() );
 		        if ( Utility.RandomDouble() < 0.15 )
                             DropItem( new TurquoiseCustom() );
                }

                public erusaerTfOgaBegraL( Serial serial ) : base( serial )
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