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
       public class SunnysideResortRegion : DamagingRegion
       {
                public SunnysideResortRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	        {
	        }

                public override void OnEnter( Mobile m )
                {
        	       m.SendMessage("You have entered Sunnyside Resort.");
                }

                public override void OnExit( Mobile m )
                {
        	       m.SendMessage("You have left Sunnyside Resort.");
                }

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			return true;
		}

		public override bool AllowHarmful( Mobile from, Mobile target )
		{
			if ( from.AccessLevel == AccessLevel.Player )
        	                from.SendMessage("You cannot commit violence in this area.");

			return ( from.AccessLevel > AccessLevel.Player );
		}

                public override TimeSpan DamageInterval
                {
                    	get
                    	{
                        	return TimeSpan.FromSeconds(1);
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
	                  		AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                   		}
                   		else
                   		{
                          		// Wind
		          		if ( Utility.RandomDouble() < 0.02 )
                          		{
                               			m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                       			AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          		}

		            		if ( Utility.RandomDouble() < 0.002 )
                            		{
                                		m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         		AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            		}
                    		}
               		}
          	}
     	}
}