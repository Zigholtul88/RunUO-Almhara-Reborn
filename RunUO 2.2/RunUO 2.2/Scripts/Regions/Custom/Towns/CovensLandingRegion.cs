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
        public class CovensLandingRegion : TownRegion
        {
                public CovensLandingRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	        {
	        }

                public override void OnEnter( Mobile m )
                {
        	       m.SendMessage("You have entered Coven's Landing.");

                       base.OnEnter( m );
                }

                public override void OnExit( Mobile m )
                {
        	       m.SendMessage("You have left Coven's Landing.");

                       base.OnExit( m );
                }   

                public static void Initialize() 
                { 
                       EventSink.Login += new LoginEventHandler( CovensLanding_OnLogin );
                }

                public static void CovensLanding_OnLogin( LoginEventArgs e ) 
                {
		       PlayerMobile m = e.Mobile as PlayerMobile;

                       if ( m.Region.Name == "Coven's Landing" )
                            m.Send( Network.PlayMusic.GetInstance( MusicName.CovensLanding ) );
                }   
        }
}