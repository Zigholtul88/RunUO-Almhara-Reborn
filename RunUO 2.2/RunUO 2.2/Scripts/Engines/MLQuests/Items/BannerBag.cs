using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Items;

namespace Server.Engines.MLQuests.Items
{
        public class BannerBag : LockableContainer
        {
                public override int DefaultGumpID{ get{ return 0x3D; } }
                public override int DefaultDropSound{ get{ return 0x48; } }

                public override Rectangle2D Bounds
                {
                       get{ return new Rectangle2D( 18, 105, 144, 73 ); }
                }

                [Constructable]
                public BannerBag() : base( 0xE76 )
                {
		        Name = "a bag with a random banner";
		        Movable = true;
		        Weight = 1.0;

                        TrapPower = 0;
                        Locked = false;

                        RequiredSkill = 0;
                        LockLevel = 0;
                        MaxLockLevel = this.RequiredSkill;

         		if( Utility.Random( 100 ) < 100 ) 
			switch ( Utility.Random( 4 ) )
			{
				case 0: DropItem( new Banner1() ); break;
				case 1: DropItem( new Banner2() ); break;
				case 2: DropItem( new Banner3() ); break;
				case 3: DropItem( new Banner4() ); break;
			}
                }

                public BannerBag( Serial serial ) : base( serial )
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