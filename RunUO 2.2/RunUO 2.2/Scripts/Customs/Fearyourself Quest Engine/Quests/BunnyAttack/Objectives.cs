/*
LoggedQuestSystem with two example quests
Copyright (C) 2006 BEYLER Jean Christophe

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/

/*
 * Objective file :
 * 	- KillBunniesObjective :
 * 		Tells the player to kill the bunnies
 *
 * 	- ReturnAfterKillsObjective :
 * 		Gets a reward for the player
 * 	
 */

using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Engines.Quests;

namespace Server.Fearyourself.Quests.BunnyAttack
{
    public class KillBunniesObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Kill the bunnies";
			}
		}

		public override int MaxProgress{ get{ return 5; } }

		public KillBunniesObjective()
		{
		}

		public override void RenderProgress( BaseQuestGump gump )
		{
			if ( !Completed )
			{
				gump.AddHtml( 70, 260, 270, 100, 
						"Number of rabbits killed :", false, false );
				gump.AddLabel( 70, 280, 0x64, CurProgress.ToString() );
				gump.AddLabel( 100, 280, 0x64, "/" );
				gump.AddLabel( 130, 280, 0x64, MaxProgress.ToString() );
			}
			else
			{
				base.RenderProgress( gump );
			}
		}

		public override void OnKill( BaseCreature creature, Container corpse )
		{
			if ( creature is BobsRabbit)
				CurProgress++;
		}

		public override void OnComplete()
		{
            System.AddConversation(new GenericConversation(
                "After a lot of sweat, you finally got rid of those bunnies ! <br>"
                + "Go back to Bob to get your reward!"
                )
            );
			System.AddObjective( new ReturnAfterKillsObjective() );
		}
	}

	public class ReturnAfterKillsObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "You've killed all the bunnies, go back to Bob";
			}
		}

		public ReturnAfterKillsObjective()
		{
		}

		public override void OnComplete()
		{
            System.Complete();
		}
    }
}
