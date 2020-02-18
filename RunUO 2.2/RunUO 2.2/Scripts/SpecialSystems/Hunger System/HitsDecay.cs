//////////////////////////////////////////////////////////////////////////////////////////
// Script written by GM Jubal for Ebonspire a player run Shard http://ebonspire.com
// Reduces hit increase based on thirst without making any changes to the regenrates.cs
// file.  Changes to that file may cause problem upon world load with your current mobiles
// scripts.  This is a much safer way to add this functionality.
////////////////////////////////////////////////////////////////////////////////////////////
using System;
using Server.Network;
using Server;

namespace Server.Misc
{
	// Create the timer that monitors the current state of hunger
	public class HitsDecayTimer : Timer
	{
		public static void Initialize()
		{
			new HitsDecayTimer().Start();
		}
		// Based on the same timespan used in RegenRates.cs
		public HitsDecayTimer() : base( TimeSpan.FromSeconds( 11 ), TimeSpan.FromSeconds( 11 ) )
		{
			Priority = TimerPriority.OneSecond;
		}
		
		protected override void OnTick()
		{
			HitsDecay();
		}
		// Check the NetState and call the decaying function
		public static void HitsDecay()
		{
			foreach ( NetState state in NetState.Instances )
			{
				HitsDecaying( state.Mobile );
			}
		}

		// Check hunger level if below the value set take away 1 hit
		public static void HitsDecaying( Mobile m )
		{
			if ( m != null && m.Hunger < 25 && m.Hits > 200 )
			{
				switch (m.Hunger)
				{
					case 4: m.Hits -= 25; break;
					case 3: m.Hits -= 50; break;
					case 2: m.Hits -= 75; break;
					case 1: m.Hits -= 100; break;
					case 0:
					{
						m.Hits -= 200;
						m.SendMessage( "You are starving to death!" );
						break;
					}
				}
			}
		}
	}
}
