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
	public class CookingShelf1 : LockableContainer
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
                public CookingShelf1() : base( 0x2D05 )
                {
		      Name = "a cook storage shelf";
		      Movable = true;
		      Weight = 1000.0;

                      TrapPower = 0;
                      Locked = false;

                      RequiredSkill = 0;
                      LockLevel = 0;
                      MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Eating Utensils

 		      if ( Utility.RandomDouble() < 0.08 )
                         DropItem( new KnifeLeft() );
 		      if ( Utility.RandomDouble() < 0.08 )
                         DropItem( new KnifeRight() );
 		      if ( Utility.RandomDouble() < 0.08 )
                         DropItem( new PewterMug() );
 		      if ( Utility.RandomDouble() < 0.08 )
                         DropItem( new Plate() );
 		      if ( Utility.RandomDouble() < 0.08 )
                         DropItem( new SpoonLeft() );
 		      if ( Utility.RandomDouble() < 0.08 )
                         DropItem( new SpoonRight() );

/////////////////////////////////////// Fruits

 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Apple() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Apricot() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Banana() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Bananas() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Blackberry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Blueberry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Cantaloupe() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Cherry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Coconut() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Cranberry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Dates() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Elderberries() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Grapefruit() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Grapes() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Kiwi() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Lemon() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Lemons() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Lime() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Limes() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Mango() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Orange() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Peach() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Pear() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Pineapple() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Plum() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Pomegranate() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Prune() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new RedRaspberry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new BlackRaspberry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new SmallWatermelon() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Strawberries() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Strawberry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Squash() );

/////////////////////////////////////// Meats

 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Bacon() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Sausage() );

/////////////////////////////////////// Vegetables

 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Carrot() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new EarOfCorn() );

/////////////////////////////////////// Misc

 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new CheeseWedge() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new CheeseWheel() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new FrenchBread() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new GreenGourd() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new HoneydewMelon() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new PeachCobbler() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new YellowGourd() );
                }

                public CookingShelf1( Serial serial ) : base( serial )
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

	public class CookingShelf2 : LockableContainer
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
                public CookingShelf2() : base( 0x2D06 )
                {
		      Name = "a cook storage shelf";
		      Movable = true;
		      Weight = 1000.0;

                      TrapPower = 0;
                      Locked = false;

                      RequiredSkill = 0;
                      LockLevel = 0;
                      MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Eating Utensils

 		      if ( Utility.RandomDouble() < 0.08 )
                         DropItem( new KnifeLeft() );
 		      if ( Utility.RandomDouble() < 0.08 )
                         DropItem( new KnifeRight() );
 		      if ( Utility.RandomDouble() < 0.08 )
                         DropItem( new PewterMug() );
 		      if ( Utility.RandomDouble() < 0.08 )
                         DropItem( new Plate() );
 		      if ( Utility.RandomDouble() < 0.08 )
                         DropItem( new SpoonLeft() );
 		      if ( Utility.RandomDouble() < 0.08 )
                         DropItem( new SpoonRight() );

/////////////////////////////////////// Fruits

 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Apple() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Apricot() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Banana() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Bananas() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Blackberry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Blueberry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Cantaloupe() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Cherry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Coconut() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Cranberry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Dates() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Elderberries() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Grapefruit() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Grapes() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Kiwi() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Lemon() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Lemons() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Lime() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Limes() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Mango() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Orange() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Peach() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Pear() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Pineapple() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Plum() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Pomegranate() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Prune() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new RedRaspberry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new BlackRaspberry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new SmallWatermelon() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Strawberries() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Strawberry() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Squash() );

/////////////////////////////////////// Meats

 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Bacon() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Sausage() );

/////////////////////////////////////// Vegetables

 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new Carrot() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new EarOfCorn() );

/////////////////////////////////////// Misc

 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new CheeseWedge() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new CheeseWheel() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new FrenchBread() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new GreenGourd() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new HoneydewMelon() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new PeachCobbler() );
 		      if ( Utility.RandomDouble() < 0.10 )
                         DropItem( new YellowGourd() );
                }

                public CookingShelf2( Serial serial ) : base( serial )
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