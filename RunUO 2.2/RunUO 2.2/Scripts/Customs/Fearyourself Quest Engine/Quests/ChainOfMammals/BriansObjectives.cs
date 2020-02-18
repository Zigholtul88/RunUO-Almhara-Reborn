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

namespace Server.Fearyourself.Quests.ChainOfMammals
{
    public class BriansKillsObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Kill the JackRabbits";
			}
		}

		public override int MaxProgress{ get{ return 4; } }

        public BriansKillsObjective()
		{
		}

		public override void RenderProgress( BaseQuestGump gump )
		{
			if ( !Completed )
			{
				gump.AddHtml( 70, 260, 270, 100, 
						"Number of JackRabbits killed :", false, false );
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
			if ( creature is BriansJackRabbit)
				CurProgress++;
		}

		public override void OnComplete()
		{
            System.AddConversation(new GenericConversation(
                "After a lot of sweat, you finally got rid of those JackRabbits ! <br>"
                + "Go see Charlie now, with a little bit of luck, this will be finished..."
                )
            );
            System.AddObjective(new BriansReturnAfterKillsObjective());
		}
	}

	public class BriansReturnAfterKillsObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "You've killed all the JackRabbits, go back to Charlie";
			}
		}

        public BriansReturnAfterKillsObjective()
		{
		}

		public override void OnComplete()
		{
            System.Complete();
		}
    }
}
