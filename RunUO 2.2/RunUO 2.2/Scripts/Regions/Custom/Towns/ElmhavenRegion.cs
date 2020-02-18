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
        public class ElmhavenRegion : TownRegion
        {
                public ElmhavenRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	        {
	        }

                public override void OnEnter( Mobile m )
                {
        	       m.SendMessage("You have entered Elmhaven.");
                       m.Send( Network.PlayMusic.GetInstance( MusicName.Elmhaven ) );

                       base.OnEnter( m );
                }

                public override void OnExit( Mobile m )
                {
        	       m.SendMessage("You have left Elmhaven.");

                       base.OnExit( m );
                } 

                public static void Initialize() 
                { 
                       EventSink.Login += new LoginEventHandler( Elmhaven_OnLogin );
                }

                public static void Elmhaven_OnLogin( LoginEventArgs e ) 
                {
		       PlayerMobile m = e.Mobile as PlayerMobile;

                       if ( m.Region.Name == "Elmhaven" )
                            m.Send( Network.PlayMusic.GetInstance( MusicName.Elmhaven ) );
                }
        }
}