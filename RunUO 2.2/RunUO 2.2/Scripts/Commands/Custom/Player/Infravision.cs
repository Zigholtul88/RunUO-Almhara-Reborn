using System;
using System.Collections;
using Server;
using Server.Commands;
using Server.Mobiles;
using Server.Network;

namespace Server.Scripts.Commands 
{ 
	public class Infravision 
        { 
        	public static void Initialize() 
             	{ 
              		CommandSystem.Register( "infravision", AccessLevel.Player, new CommandEventHandler( Infravision_OnCommand ) );
              		CommandSystem.Register( "infra", AccessLevel.Player, new CommandEventHandler( Infravision_OnCommand ) );
             	}

             	public static void Infravision_OnCommand( CommandEventArgs e ) 
             	{
               		Mobile m = e.Mobile;

               		if ( CanUse( m ) )
               			InitInfravision( m );
               		else
               			return;
             	}

              	public static bool CanUse( Mobile m )
              	{
			PlayerMobile player = m as PlayerMobile;

                 	if ( player.RacialNumber == 3 ) // Svartalfar
                 		return true;
                 	else
                 		return false;
              	}

              	public static void InitInfravision( Mobile m )
              	{
			PlayerMobile player = m as PlayerMobile;

                 	if ( player.Infravision )
                 	{
                   		player.Infravision = false;
                   		m.LightLevel = 0;
                   		m.CheckLightLevels( true );
                   		m.SendMessage( "Your eyes return to their normal stage." );
                   		return;
                 	}
                 	else
                 	{
                   		player.Infravision = true;
                   		m.LightLevel = 25;
                   		m.SendMessage( "Your eyes begin to tingle with ultraviolet light." );
                   		m.FixedParticles( 0x376A, 9, 32, 5007, EffectLayer.Waist );
                   		m.PlaySound( 0x1E3 );
                   		return;
                 	}
		}
	}
}
