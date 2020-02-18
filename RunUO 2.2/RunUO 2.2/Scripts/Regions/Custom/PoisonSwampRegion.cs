using System;
using System.Collections;
using System.Xml;
using Server.Network;

namespace Server.Regions
{
    public class PoisonSwampRegion : DamagingRegion
    { 
        public PoisonSwampRegion( XmlElement xml, Map map, Region parent) : base(xml, map, parent)
        { 
        }

        public override TimeSpan DamageInterval
        {
            get
            {
                return TimeSpan.FromSeconds(25);
            }
        }
        public override void Damage(Mobile m)
        {
            base.Damage(m);
			
            if (m.NetState != null)
            {
		m.Stam -= 5;
		m.Mana -= 15;
                m.FixedParticles(0x36B0, 1, 14, 0x26BB, 0x3F, 0x7, EffectLayer.Waist);
                m.PlaySound(0x229);
                m.SendMessage( "The noxious fumes begin to slowly corrode your outer flesh." ); 
                AOS.Damage(m, Utility.Random(1, 3), 0, 0, 0, 100, 0);
		m.ApplyPoison( m, Poison.Regular );
            }
        }
    }
}