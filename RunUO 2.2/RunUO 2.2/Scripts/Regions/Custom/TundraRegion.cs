using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;
using AMT = Server.Items.ArmorMaterialType;

namespace Server.Regions
{
    public class TundraRegion : DamagingRegion
    { 
        public TundraRegion( XmlElement xml, Map map, Region parent) : base(xml, map, parent)
        { 
        }

        public override TimeSpan DamageInterval
        {
            get
            {
                return TimeSpan.FromSeconds(30);
            }
        }
        public override void Damage( Mobile m )
        {
                  
        base.Damage(m );

        if (m.Alive)
        {
		  Item item = m.FindItemOnLayer( Layer.OuterTorso );

	          if ( item is BaseOuterTorso )
	          {

	                    AOS.Damage(m, 0, 0, 0, 100, 0, 0 );
                  }
                  else
                  {
			    m.Stam -= 10;
			    m.Mana -= 20;
			    m.FixedParticles( 0x37CC, 1, 40, 97, 3, 9917, EffectLayer.Waist );
           		    m.FixedParticles( 0x374A, 1, 15, 9502, 97, 3, (EffectLayer)255 );
			    m.PlaySound( 20 );
			    m.SendMessage("You feel as if your skin is freezing!!!");
			    m.PlaySound( m.Female ? 811 : 1085 );
			    m.Say( "*oooh!*" );
                            AOS.Damage(m, Utility.Random(5, 15), 0, 0, 100, 0, 0);
                  }
             }
        }
   }
}

