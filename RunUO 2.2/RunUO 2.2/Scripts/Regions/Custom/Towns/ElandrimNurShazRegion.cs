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
        public class ElandrimNurShazRegion : TownRegion
        {
                public ElandrimNurShazRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	        {
	        }

                public override void OnEnter( Mobile m )
                {
        	       m.SendMessage("You have entered Elandrim Nur Shaz.");

                       base.OnEnter( m );
                }

                public override void OnExit( Mobile m )
                {
        	       m.SendMessage("You have left Elandrim Nur Shaz.");

                       base.OnExit( m );
                }      

                public static void Initialize() 
                { 
                       EventSink.Login += new LoginEventHandler( ElandrimNurShaz_OnLogin );
                }

                public static void ElandrimNurShaz_OnLogin( LoginEventArgs e ) 
                {
		       PlayerMobile m = e.Mobile as PlayerMobile;

                       if ( m.Region.Name == "Elandrim Nur Shaz" )
                            m.Send( Network.PlayMusic.GetInstance( MusicName.Elandrim ) );
                }
        }
}