using System;
using System.Collections;
using System.Xml;
using Server.Network;

namespace Server.Regions
{
    public class IcyLakeRegion : DamagingRegion
    { 
        public IcyLakeRegion( XmlElement xml, Map map, Region parent) : base(xml, map, parent)
        { 
        }

        public override TimeSpan DamageInterval
        {
            get
            {
                return TimeSpan.FromSeconds(15);
            }
        }
        public override void Damage(Mobile m)
        {
            base.Damage(m);
			
            if (m.NetState != null)
            {
		m.Stam -= 10;
		m.Mana -= 20;
		m.FixedParticles( 0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist );
		m.PlaySound( 0x0FC );
                m.SendMessage( "The icy water chills your blood, slowly freezing you to death." ); 
                AOS.Damage(m, Utility.Random(15, 25), 0, 0, 100, 0, 0);
            }
        }
    }
}