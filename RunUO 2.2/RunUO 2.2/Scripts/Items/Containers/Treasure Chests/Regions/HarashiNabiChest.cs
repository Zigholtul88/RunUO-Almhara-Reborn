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
	public class HarashiNabiChest : LockableContainer
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
                public HarashiNabiChest() : base( 0xE43 )
                {
		      Name = "a treasure chest -40-";
		      Movable = true;
		      Weight = 1000.0;

                      TrapPower = 0;
                      Locked = true;

                      RequiredSkill = 40;
                      LockLevel = 40;
                      MaxLockLevel = 50;

/////////////////////////////////////// Supplies

			switch ( Utility.Random( 19 ) )
			{
				case 0: DropItem( new Board(50) ); break;
				case 1: DropItem( new BoltOfCloth(50) ); break;
				case 2: DropItem( new Bottle(50) ); break;
				case 3: DropItem( new CopperWire(50) ); break;
				case 4: DropItem( new Cotton(50) ); break;
				case 5: DropItem( new DarkYarn(50) ); break;
				case 6: DropItem( new Feather(50) ); break;
				case 7: DropItem( new Flax(50) ); break;
				case 8: DropItem( new Gears(50) ); break;
				case 9: DropItem( new GoldWire(50) ); break;
				case 10: DropItem( new IronIngot(50) ); break;
				case 11: DropItem( new IronWire(50) ); break;
				case 12: DropItem( new Leather(50) ); break;
				case 13: DropItem( new LightYarn(50) ); break;
				case 14: DropItem( new Shaft(50) ); break;
				case 15: DropItem( new SilverWire(50) ); break;
				case 16: DropItem( new SpoolOfThread(50) ); break;
				case 17: DropItem( new Springs(50) ); break;
				case 18: DropItem( new Wool(50) ); break;
			}

                      Item ReagentLoot = Loot.RandomReagent();
                      ReagentLoot.Amount = Utility.RandomMinMax( 1, 40 );
                         DropItem( ReagentLoot );

 		      if ( Utility.RandomDouble() < 0.05 )
		         DropItem( new SackFlour() );

/////////////////////////////////////// Tools

			switch ( Utility.Random( 16 ) )
			{
				case 0: DropItem( new FishingPole() ); break;
				case 1: DropItem( new FletcherTools() ); break;
				case 2: DropItem( new FlourSifter() ); break;
				case 3: DropItem( new Hammer() ); break;
				case 4: DropItem( new MortarPestle() ); break;
				case 5: DropItem( new RollingPin() ); break;
				case 6: DropItem( new Saw() ); break;
				case 7: DropItem( new Scissors() ); break;
				case 8: DropItem( new ScribesPen() ); break;
				case 9: DropItem( new SewingKit() ); break;
				case 10: DropItem( new Shovel() ); break;
				case 11: DropItem( new Skillet() ); break;
				case 12: DropItem( new SledgeHammer() ); break;
				case 13: DropItem( new SmithHammer() ); break;
				case 14: DropItem( new TinkerTools() ); break;
				case 15: DropItem( new Tongs() ); break;
			}

/////////////////////////////////////// Rare Items

 		      if ( Utility.RandomDouble() < 0.01 )
		         DropItem( new DyeTub() );
                }

                public HarashiNabiChest( Serial serial ) : base( serial )
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