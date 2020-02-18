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
    public class AlfredsKillsObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Kill the rats";
			}
		}

		public override int MaxProgress{ get{ return 5; } }

        public AlfredsKillsObjective()
		{
		}

		public override void RenderProgress( BaseQuestGump gump )
		{
			if ( !Completed )
			{
				gump.AddHtml( 70, 260, 270, 100, 
						"Number of rats killed :", false, false );
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
			if ( creature is AlfredsRat)
				CurProgress++;
		}

		public override void OnComplete()
		{
            System.AddConversation(new GenericConversation(
                "After a lot of sweat, you finally got rid of those rats ! <br>"
                + "Go back to Alfred to get your reward!"
                )
            );
            System.AddObjective(new AlfredsReturnAfterKillsObjective());
		}
	}

	public class AlfredsReturnAfterKillsObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "You've killed all the rats, go back to Alfred";
			}
		}

        public AlfredsReturnAfterKillsObjective()
		{
		}

		public override void OnComplete()
		{
            System.AddConversation(new GenericConversation(
                "Alfred looks at you and laughs a little :"+
                "Your quest is over but I'll put a good word to Brian about you" +
                "He'll have gold for you, if you're nice...\"" + 
                "As you leave Alfred, you can't believe he's making you go see Brian..."
                )
            );
            System.Complete();
		}
    }
}
