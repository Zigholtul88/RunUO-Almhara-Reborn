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
    public class ScholarsBookcase2 : LockableContainer
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
        public ScholarsBookcase2() : base( 0xA98 )
        {
		Name = "a bookcase";
		Movable = true;
		Weight = 1000.0;

            TrapPower = 0;
            Locked = false;

            RequiredSkill = 0;
            LockLevel = 0;
            MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Custom Books

 		if ( Utility.RandomDouble() < 0.07 )
            DropItem( new CreatureCompendiumVol1() );

 		if ( Utility.RandomDouble() < 0.07 )
            DropItem( new RacialSlursVol1() );

 		if ( Utility.RandomDouble() < 0.07 )
            DropItem( new RacialSlursVol2() );

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
            DropItem( new TamersHandbookEcology() );

/////////////////////////////////////// Scrolls

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new ArchCureScroll() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new ArchProtectionScroll() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new BlessScroll() );

 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new EarthquakeScroll() );

 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new ExplosionScroll() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new GreaterHealScroll() );

 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new GreaterHealScroll() );

 		if ( Utility.RandomDouble() < 0.10 )
            DropItem( new LightningScroll() );

 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new NightSightScroll() );

 		if ( Utility.RandomDouble() < 0.05 )
            DropItem( new ParalyzeScroll() );
        }

        public ScholarsBookcase2( Serial serial ) : base( serial )
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