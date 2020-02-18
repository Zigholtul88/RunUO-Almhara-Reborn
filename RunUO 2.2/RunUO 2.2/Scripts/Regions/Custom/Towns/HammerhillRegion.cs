using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Engines.Quests;
using Server.Engines.Quests.StaffOfFlyingMonkeys;
using Server.Engines.Quests.StolenNecklace;

namespace Server.Regions
{
        public class HammerhillRegion : TownRegion
        {
                public HammerhillRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	        {
	        }

                public override void OnEnter( Mobile m )
                {
                        if ( m.Player && m.Alive )
                        {
		                PlayerMobile player = m as PlayerMobile;
		                QuestSystem qs = player.Quest;

		                if ( qs is StaffOfFlyingMonkeysQuest )
		                {
                                        if ( qs.IsObjectiveInProgress( typeof( EscapeObjective ) ) )
			                {
                                                m.Send( Network.PlayMusic.GetInstance( MusicName.Medieval ) );
	                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                        }
                                        else
                                        {
                                                m.Send( Network.PlayMusic.GetInstance( MusicName.Hammerhill ) );
	                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                        }
                                }
		                else if ( qs is StolenNecklaceQuest )
		                {
                                        if ( qs.IsObjectiveInProgress( typeof( ReturnStolenNecklaceObjective ) ) )
			                {
                                                m.Send( Network.PlayMusic.GetInstance( MusicName.StygianAbyss ) );
	                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                        }
                                        else
                                        {
                                                m.Send( Network.PlayMusic.GetInstance( MusicName.Hammerhill ) );
	                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                        }
                                }
                                else
			        {
                                        m.Send( Network.PlayMusic.GetInstance( MusicName.Hammerhill ) );
	                                AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                }
                        }

                        base.OnEnter( m );
                }

                public static void Initialize() 
                { 
                       EventSink.Login += new LoginEventHandler( Hammerhill_OnLogin );
                }

                public static void Hammerhill_OnLogin( LoginEventArgs e ) 
                {
		       PlayerMobile m = e.Mobile as PlayerMobile;

                       if ( m.Region.Name == "Hammerhill" )
                            m.Send( Network.PlayMusic.GetInstance( MusicName.Hammerhill ) );
                }
        }
}