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
    	public class LavaRegion : DamagingRegion
    	{ 
        	public LavaRegion( XmlElement xml, Map map, Region parent) : base(xml, map, parent)
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
			
            		if ( m.Alive )
            		{
		            	PlayerMobile pm = m as PlayerMobile;
		            	if ( pm.RacialNumber == 4 ) // Yugitashi
                            	{
			    		m.Hits += 1;
			    		m.Stam += 1;
					m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
					m.PlaySound( 0x208 );
	                    		AOS.Damage( m, 0, 0, 0, 0, 0, 0 );
                            	}
		            	else if ( pm.RacialNumber == 5 ) // Keljii
                            	{
					m.Stam -= 40;
					m.Mana -= 50;
					m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
					m.PlaySound( 0x208 );
                			m.SendMessage( "Your fleshy vessel catches fire due to the intense heat radiating from the lava." );
					m.PlaySound( m.Female ? 814 : 1088 );
					m.Say( "*ahhhh!*" );
                			AOS.Damage( m, Utility.Random(30, 50), 0, 100, 0, 0, 0 );
                            	}
			}
			else
			{
				m.Stam -= 20;
				m.Mana -= 25;
				m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x208 );
                		m.SendMessage( "Your fleshy vessel catches fire due to the intense heat radiating from the lava." );
				m.PlaySound( m.Female ? 814 : 1088 );
				m.Say( "*ahhhh!*" );
                		AOS.Damage( m, Utility.Random(15, 25), 0, 100, 0, 0, 0 );
            		}
        	}
    	}
}