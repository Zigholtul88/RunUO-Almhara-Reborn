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
    public class OceanSFXRegion : DamagingRegion
    { 
        public OceanSFXRegion( XmlElement xml, Map map, Region parent) : base(xml, map, parent)
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

	                    AOS.Damage(m, 0, 0, 0, 100, 0, 0 );
                  }
                  else
                  {
	                    AOS.Damage(m, 0, 0, 0, 0, 0, 0 );

		            if ( Utility.RandomDouble() < 0.50 )
                            m.PlaySound(Utility.RandomList( 0x010,0x011,0x012,0x025,0x026 ) );
                  }
             }
        }
   }
}

