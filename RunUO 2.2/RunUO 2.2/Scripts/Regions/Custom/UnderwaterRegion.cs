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
    	public class UnderwaterRegion : DamagingRegion
    	{ 
        	public UnderwaterRegion( XmlElement xml, Map map, Region parent) : base(xml, map, parent)
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

        		if ( m.Alive )
        		{
		  		Item item = m.FindItemOnLayer( Layer.Neck );

	          		if ( item is BreathingApparatus )
	          		{
	          	    		AOS.Damage( m, 0, 0, 0, 0, 0, 0 );
                  		}

		  		PlayerMobile pm = m as PlayerMobile;
		  		if ( pm.RacialNumber == 5 ) // Keljii
                  		{   
			    		m.Hits += 1;
			    		m.Stam += 1;
	                    		AOS.Damage( m, 0, 0, 0, 0, 0, 0 );
                  		}
                  		else
                  		{
		            		if ( Utility.RandomDouble() < 0.05 )
                            		{
			    			m.Stam -= 5;
			    			m.Mana -= 50;
			    			m.PlaySound( 868 ); 
			    			m.FixedParticles( 0x3709, 1, 30, 9965, 5, 7, EffectLayer.Waist );
           		    			m.FixedParticles( 0x376A, 1, 30, 9502, 5, 3, EffectLayer.Waist );
			    			m.SendMessage("You feel your lungs fill up with water, Can't Breathe!!!");
			    			m.PlaySound( m.Female ? 793 : 1065 );
			    			m.Say( "*gasp!*" );
                            			AOS.Damage( m, Utility.Random(15, 25), 0, 0, 100, 0, 0 );
					}
				}
			}
		}
	}
}

