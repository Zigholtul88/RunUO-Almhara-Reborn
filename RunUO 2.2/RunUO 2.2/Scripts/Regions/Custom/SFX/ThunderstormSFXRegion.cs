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
    public class ThunderstormSFXRegion : DamagingRegion
    { 
        public ThunderstormSFXRegion( XmlElement xml, Map map, Region parent) : base(xml, map, parent)
        { 
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
                  
        base.Damage(m );

        if (m.Alive)
        {
		  Item item = m.FindItemOnLayer( Layer.OuterTorso );

	          if ( item is GMRobe )
	          {
	                    AOS.Damage(m, 0, 0, 0, 0, 0, 0 );

		            if ( Utility.RandomDouble() < 0.15 )
                            m.PlaySound(Utility.RandomList( 0x307,0x308 ) );
                  }
                  else
                  {
                            // Wind
		            if ( Utility.RandomDouble() < 0.09 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Thunderstorm
		            if ( Utility.RandomDouble() < 0.06 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x028,0x029,0x206 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Lightning Strike
		            if ( Utility.RandomDouble() < 0.01 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x5CE ) );
		                 m.BoltEffect( 0x480 );
                                 AOS.Damage(m, Utility.RandomMinMax(12, 35), 0, 0, 0, 0, 100);
                            }
                    }
               }
          }
     }
}

