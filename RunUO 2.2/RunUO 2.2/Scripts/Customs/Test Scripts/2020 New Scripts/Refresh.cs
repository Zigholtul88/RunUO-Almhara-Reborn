/*----------------*/
/*--- Scripted ---*/
/*--- By: JBob ---*/
/*----------------*/
using System;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Commands;
using Server.Network;

namespace Server.Commands
{
	public class Refresh
	{
		public static void Initialize()
		{
			CommandSystem.Register( "Refresh", AccessLevel.Seer, new CommandEventHandler( Refresh_OnCommand ) );
		}

		private class RefreshTarget : Target
		{
			public RefreshTarget( Mobile m ) : base( -1, true, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object o )
			{
				Mobile m;
				
				if ( o is Mobile )
				{
					m = (Mobile)o;
					m.Hits = m.HitsMax;
					m.Stam = m.StamMax;
					m.Mana = m.ManaMax;
				}
				else
					from.SendMessage( "That can not be Refreshed." );
			}
		}
		
		[Usage( "Refresh" )]
		[Description( "Restores the targeted Mobile's Hits, Mana, and Stamina." )]
		private static void Refresh_OnCommand( CommandEventArgs e )
		{
			e.Mobile.Target = new RefreshTarget( e.Mobile );
		}		
	}
}
