using System;
using System.Collections;
using Server;
using Server.Commands;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Scripts.Commands 
{ 
	public class PetLore 
        { 
        	public static void Initialize() 
             	{ 
              		CommandSystem.Register( "petlore", AccessLevel.Player, new CommandEventHandler( PetLore_OnCommand ) );
              		CommandSystem.Register( "pet lore", AccessLevel.Player, new CommandEventHandler( PetLore_OnCommand ) );
             	}

		[Usage( "PetLore" )]
		[Description( "Shows the player the creature's taming requirements." )]
		public static void PetLore_OnCommand( CommandEventArgs e )
		{
               		Mobile from = e.Mobile;

			from.SendMessage( "Target an animal to see its taming requirements." );
			from.Target = new PetLoreInternalTarget();
		}

		private class PetLoreInternalTarget : Target
		{
			public PetLoreInternalTarget() : base( 8, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is PlayerMobile )
				{
					PlayerMobile pm = from as PlayerMobile;

					from.SendMessage( "This ability cannot be used on player mobiles." );
					return;
				}

				if ( targeted is Item )
				{
					from.SendMessage( "This ability cannot be used on items." );
					return;
				}

				if ( targeted is BaseCreature )
				{
					BaseCreature c = (BaseCreature)targeted;

					if ( c.Tamable )
					{
						from.SendMessage( "This creature's control slots is: {0}", c.ControlSlots );
						from.SendMessage( "This creature's tame skill is: {0}", c.MinTameSkill );
					}
					else
					{
						from.SendMessage( "This creature is not tamable." );
					}
				}
                                else
				{
					from.SendMessage( "This ability can only be used on tamable creatures." );
				}
			}
		}
	}
}