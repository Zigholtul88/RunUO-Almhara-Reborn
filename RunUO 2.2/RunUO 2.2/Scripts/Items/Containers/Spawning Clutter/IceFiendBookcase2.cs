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
    public class IceFiendBookcase2 : LockableContainer
    {
        public override bool Decays{ get{ return true; } } 

        public override TimeSpan DecayTime{ get{ return TimeSpan.FromMinutes( Utility.Random( 30, 60 ) ); } }

        public override int DefaultGumpID{ get{ return 0x4D; } }
        public override int DefaultDropSound{ get{ return 0x42; } }

        public override Rectangle2D Bounds
        {
            get{ return new Rectangle2D( 18, 105, 144, 73 ); }
        }

        [Constructable]
        public IceFiendBookcase2() : base( 0xA98 )
        {
		Name = "a bookcase";
            Hue = 1152;

		Movable = true;
		Weight = 1000.0;

            TrapPower = 0;
            Locked = false;

            RequiredSkill = 0;
            LockLevel = 0;
            MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Books

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new GrammarOfOrcish() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new ArmsAndWeaponsPrimer() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new ChildrenTalesVol2() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new DimensionalTravel() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new EthicalHedonism() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new MyStory() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new DiversityOfOurLand() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new RegardingLlamas() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new TalkingToWisps() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new TamingDragons() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new TheFight() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new RankingsOfTrades() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new WildGirlOfTheForest() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new TreatiseOnAlchemy() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new TamersHandbookVol1() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new TamersHandbookVol2() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new TamersHandbookVol3() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new TamersHandbookVol4() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new TamersHandbookVol5() );
        }

        public IceFiendBookcase2( Serial serial ) : base( serial )
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