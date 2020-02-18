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
	public class OboruJungleSFXRegion : LandscapeRegion
	{
		public OboruJungleSFXRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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
                        return TimeSpan.FromSeconds(5);
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
	                  AOS.Damage(m, 0, 0, 0, 100, 0, 0 );
                   }
                   else
                   {
                          // Jungle noises
		          if ( Utility.RandomDouble() < 0.08 )
                          {
                               m.PlaySound(Utility.RandomList( 0x003,0x004,0x005,0x2B3,0x2B4,0x2B5 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Bird chirps
		          if ( Utility.RandomDouble() < 0.02 )
                          {
                               m.PlaySound(Utility.RandomList( 0x094,0x095,0x096,0x097,0x0D1,0x0D2 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Cricket noises
		          if ( Utility.RandomDouble() < 0.03 )
                          {
                               m.PlaySound(Utility.RandomList( 0x00A,0x00B ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }
                    }
               }
          }
     }
}