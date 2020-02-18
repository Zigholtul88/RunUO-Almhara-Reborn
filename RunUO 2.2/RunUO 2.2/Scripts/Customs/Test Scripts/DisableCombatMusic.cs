using System; 
using System.Collections; 
using Server.Commands;
using Server.Factions;
using Server.Items; 
using Server.Misc;
using Server.Mobiles; 
using Server.Network;
using Server.Regions;
using Server.Targeting; 

namespace Server.Scripts.Commands 
{ 
	public class DisableCombatMusic
	{ 
		public static void Initialize()
		{
			EventSink.Login += new LoginEventHandler( OnLogin );
		}

		public static void OnLogin( LoginEventArgs e )
		{
                        Mobile m = e.Mobile;
                        Region rg = e.Mobile.Region;

                        if ( m.Warmode == true )
                        {
                                m.Send( Network.PlayMusic.GetInstance( MusicName.Invalid ) );

                                if ( m.Region.IsPartOf( typeof( Regions.MongbatHideoutBossRegion ) ) )
                                {
                                        if ( m.Region.Name == "Mongbat Hideout Boss Room" )
                                        {
			                        m.Send( StopMusic.Instance );
                                        }
                                }
                        }
		}
	}
}
