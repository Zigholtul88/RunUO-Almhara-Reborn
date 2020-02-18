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
    public class QuestGoodieBag : LockableContainer
    {
        public override int DefaultGumpID{ get{ return 0x3D; } }
        public override int DefaultDropSound{ get{ return 0x48; } }

        public override Rectangle2D Bounds
        {
            get{ return new Rectangle2D( 18, 105, 144, 73 ); }
        }

        [Constructable]
        public QuestGoodieBag() : base( 0xE76 )
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

            DropItem( new Gold( Utility.Random( 100, 500 ) ) );

/////////////////////////////////////// Potions

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new HealPotion() );

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

/////////////////////////////////////// Dyes and Dye Tubs

 		if ( Utility.RandomDouble() < 0.05 )
		DropItem( new Dyes() );	

 		if ( Utility.RandomDouble() < 0.04 )
		DropItem( new DyeTub() );	

 		if ( Utility.RandomDouble() < 0.03 )
		DropItem( new LeatherDyeTub() );	

/////////////////////////////////////// Alteration Gems

 		if ( Utility.RandomDouble() < 0.03 )
		DropItem( new CrackedStrBonusGem() );	

 		if ( Utility.RandomDouble() < 0.03 )
		DropItem( new CrackedDexBonusGem() );	

 		if ( Utility.RandomDouble() < 0.03 )
		DropItem( new CrackedIntBonusGem() );

/////////////////////////////////////// Rares

 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new SunGlasses() );
        }

        public QuestGoodieBag( Serial serial ) : base( serial )
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