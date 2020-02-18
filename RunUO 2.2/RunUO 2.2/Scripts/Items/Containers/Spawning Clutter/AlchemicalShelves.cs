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
	public class AlchemicalShelf1 : LockableContainer
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
                public AlchemicalShelf1() : base( 0x2D07 )
                {
		      Name = "an alchemist shelf";
		      Movable = true;
		      Weight = 1000.0;

                      TrapPower = 0;
                      Locked = false;

                      RequiredSkill = 0;
                      LockLevel = 0;
                      MaxLockLevel = this.RequiredSkill;

/////////////////////////////////// Potions
 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( Loot.RandomPotion() );

 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( Loot.RandomPotion() );

 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( Loot.RandomPotion() );

 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( Loot.RandomPotion() );

 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( Loot.RandomPotion() );

/////////////////////////////////////// Supplies

                      Item ReagentLoot = Loot.RandomReagent();
                      ReagentLoot.Amount = Utility.RandomMinMax( 15, 25 );
                         DropItem( ReagentLoot );

                      Item ScrollLoot = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                      ScrollLoot.Amount = Utility.Random( 1, 3 );
                         DropItem( ScrollLoot );
                }

                public AlchemicalShelf1( Serial serial ) : base( serial )
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

	public class AlchemicalShelf2 : LockableContainer
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
                public AlchemicalShelf2() : base( 0x2D08 )
                {
		      Name = "an alchemist shelf";
		      Movable = true;
		      Weight = 1000.0;

                      TrapPower = 0;
                      Locked = false;

                      RequiredSkill = 0;
                      LockLevel = 0;
                      MaxLockLevel = this.RequiredSkill;

/////////////////////////////////// Potions
 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( Loot.RandomPotion() );

 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( Loot.RandomPotion() );

 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( Loot.RandomPotion() );

 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( Loot.RandomPotion() );

 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( Loot.RandomPotion() );

/////////////////////////////////////// Supplies

                      Item ReagentLoot = Loot.RandomReagent();
                      ReagentLoot.Amount = Utility.RandomMinMax( 15, 25 );
                         DropItem( ReagentLoot );

                      Item ScrollLoot = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                      ScrollLoot.Amount = Utility.Random( 1, 3 );
                         DropItem( ScrollLoot );
                }

                public AlchemicalShelf2( Serial serial ) : base( serial )
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