using System;
using System.Collections;
using System.Xml;
using Server.Network;

namespace Server.Regions
{
    public class TriggerBossMusicRegion : DamagingRegion
    { 
        public TriggerBossMusicRegion( XmlElement xml, Map map, Region parent) : base(xml, map, parent)
        { 
        }

        public override TimeSpan DamageInterval
        {
            get
            {
                return TimeSpan.FromSeconds(5);
            }
        }
        public override void Damage(Mobile m)
        {
            base.Damage(m);
			
            if (m.NetState != null)
            {
	        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
            }
        }
    }
}