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
        public class DawnguardCathedralRegion : TownRegion
        {
                public DawnguardCathedralRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	        {
	        }

                public override void OnEnter( Mobile m )
                {
        	       m.SendMessage("You have entered Dawnguard Cathedral.");
                       m.Send( Network.PlayMusic.GetInstance( MusicName.LBCastle ) );

                       base.OnEnter( m );
                }

                public override void OnExit( Mobile m )
                {
        	       m.SendMessage("You have left Dawnguard Cathedral.");

                       base.OnExit( m );
                } 

                public static void Initialize() 
                { 
                       EventSink.Login += new LoginEventHandler( DawnguardCathedral_OnLogin );
                }

                public static void DawnguardCathedral_OnLogin( LoginEventArgs e ) 
                {
		       PlayerMobile m = e.Mobile as PlayerMobile;

                       if ( m.Region.Name == "Dawnguard Cathedral" )
                            m.Send( Network.PlayMusic.GetInstance( MusicName.LBCastle ) );
                }        
        }
}