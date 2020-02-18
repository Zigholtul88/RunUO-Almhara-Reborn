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
	public class IslandTartarrixSFXRegion : LandscapeRegion
	{
		public IslandTartarrixSFXRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
		}

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			return true;
		}

                public override TimeSpan DamageInterval
                {
                    get
                    {
                        return TimeSpan.FromSeconds(1);
                    }
             }

             public override void OnEnter( Mobile m )
             {
        	    m.SendMessage("You have entered the Island of Tartarrix.");

                    base.OnEnter( m );
             }

             public override void OnExit( Mobile m )
             {
        	    m.SendMessage("You have left the Island of Tartarrix.");

                    base.OnExit( m );
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
                          m.PlaySound(Utility.RandomList( 0x307,0x308 ) );
                   }
                   else
                   {
                          // Wind
		          if ( Utility.RandomDouble() < 0.25 )
                          {
                               m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Wind
		          if ( Utility.RandomDouble() < 0.15 )
                          {
                               m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Wind
		          if ( Utility.RandomDouble() < 0.08 )
                          {
                               m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Wind
		          if ( Utility.RandomDouble() < 0.05 )
                          {
                               m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }
                    }
               }
          }
     }
}