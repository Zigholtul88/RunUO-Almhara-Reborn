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
        public class RedDaggerKeepRegion : TownRegion
        {
                public RedDaggerKeepRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	        {
	        }

                public override void OnEnter( Mobile m )
                {
        	        m.SendMessage("You have entered Red Dagger Keep.");
                        m.Send( Network.PlayMusic.GetInstance( MusicName.RedDaggerKeep ) );

                        base.OnEnter( m );
                }

                public override void OnExit( Mobile m )
                {
        	        m.SendMessage("You have left Red Dagger Keep.");

                        base.OnExit( m );
                }

                public static void Initialize() 
                { 
                       EventSink.Login += new LoginEventHandler( RedDaggerKeep_OnLogin );
                }

                public static void RedDaggerKeep_OnLogin( LoginEventArgs e ) 
                {
		       PlayerMobile m = e.Mobile as PlayerMobile;

                       if ( m.Region.Name == "Red Dagger Keep" )
                            m.Send( Network.PlayMusic.GetInstance( MusicName.RedDaggerKeep ) );
                }  
        }
}