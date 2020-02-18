using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;

namespace Server.Regions
{
	public class SamsonSwamplandsCaveRegion : LandscapeRegion
	{
		public SamsonSwamplandsCaveRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
		}

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			return false;
		}

		public override void AlterLightLevel( Mobile m, ref int global, ref int personal )
		{
			global = LightCycle.JailLevel;
		}

                public override TimeSpan DamageInterval
                {
                    get
                    {
                        return TimeSpan.FromSeconds(1);
                    }
             }

             public override void Damage( Mobile m )
             {
                  
             base.Damage( m );

             if ( m.Alive )
             {
		   Item item = m.FindItemOnLayer( Layer.OuterTorso );

	           if ( item is GMRobe )
	           {
	                  AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                   }
                   else
                   {
                          // Wind
		          if ( Utility.RandomDouble() < 0.02 )
                          {
                               m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // water drips
		          if ( Utility.RandomDouble() < 0.05 )
                          {
                               m.PlaySound(Utility.RandomList( 0x022,0x023,0x024,0x2D7,0x2D8,0x2D9,0x2DB,0x2DC,0x2DD,0x2DE,0x2DF,0x2E0 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Random noises
		          if ( Utility.RandomDouble() < 0.08 )
                          {
                               m.PlaySound(Utility.RandomList( 0x100,0x101,0x102,0x103,0x21F,0x220,0x221,0x222,0x22F,0x230,0x231,0x242,0x246,0x247,0x26B,0x26C,0x28E,0x2E1,0x3BD,0x457 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }
                    }
               }
          }
     }
}