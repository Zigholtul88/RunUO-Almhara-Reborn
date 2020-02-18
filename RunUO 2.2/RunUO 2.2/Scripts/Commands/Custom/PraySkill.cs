//
// Brought to you by Mark01970 of the RunUO forums
// The Unexpected Shard - A private invitation only shard
//

using System; 
using System.Collections; 
using Server.Commands;
using Server.Factions;
using Server.Items; 
using Server.Targeting; 
using Server.Misc;
using Server.Mobiles; 
using Server.Network;

namespace Server.Scripts.Commands 
{ 
	public class PraySkill
	{ 
		public static void Initialize() 
		{ 
			CommandSystem.Register( "pray", AccessLevel.Player, new CommandEventHandler( PraySkill_OnCommand ) ); 
		}    
      
		[Usage( "pray skill" )] 
		[Description( "Pray to the Gods!" )] 

		public static void PraySkill_OnCommand( CommandEventArgs e ) 
		{ 
			e.Mobile.SendMessage( "You begin praying to the Gods for help..." );
			if (e.Mobile.Karma < 500) { e.Mobile.SendMessage( "You lack the Karma to plead with the Gods!" ); }
			else if ( !(e.Mobile.Alive) )
			{
				e.Mobile.SendMessage( "The Gods grant you the gift of life at the cost of Karma and Strength!" );
				e.Mobile.Karma = e.Mobile.Karma - 100;
				e.Mobile.SendMessage( "You lost 100 Karma." );
				e.Mobile.Str = e.Mobile.Str-1;
				if (e.Mobile.Str < 20) { e.Mobile.Str = 20; }
				e.Mobile.Resurrect();				
			}
			else { e.Mobile.SendMessage( "How can you accept the gift of life when you are already alive!" ); }
		}
	}
}
