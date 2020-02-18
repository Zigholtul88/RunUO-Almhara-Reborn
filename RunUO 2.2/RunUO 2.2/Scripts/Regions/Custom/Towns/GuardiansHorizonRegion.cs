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
        public class GuardiansHorizonRegion : TownRegion
        {
                public GuardiansHorizonRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	        {
	        }

                public override void OnEnter( Mobile m )
                {
        	       m.SendMessage("You have entered Guardian's Horizon.");

                       base.OnEnter( m );
                }

                public override void OnExit( Mobile m )
                {
        	       m.SendMessage("You have left Guardian's Horizon.");

                       base.OnExit( m );
                }      

                public static void Initialize() 
                { 
                       EventSink.Login += new LoginEventHandler( GuardiansHorizon_OnLogin );
                }

                public static void GuardiansHorizon_OnLogin( LoginEventArgs e ) 
                {
		       PlayerMobile m = e.Mobile as PlayerMobile;

                       if ( m.Region.Name == "Guardians Horizon" )
                            m.Send( Network.PlayMusic.GetInstance( MusicName.GuardiansHorizon ) );
                } 
        }
}