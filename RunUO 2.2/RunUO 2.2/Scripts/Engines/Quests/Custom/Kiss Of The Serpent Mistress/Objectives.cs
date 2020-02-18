using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.KissOfTheSerpentMistress
{
	public class SlayCalcifinaObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Head on over to Caravan Cove in the Autumnwood, slay Calcifina the Enslaver and retrieve her yumi.";
			}
		}

		public override void RenderProgress( BaseQuestGump gump )
		{
			if ( !Completed )
			{
				// Calcifina killed:
				gump.AddHtmlLocalized( 70, 260, 270, 100, BaseQuestGump.Blue, false, false );

				gump.AddLabel( 70, 280, 0x64, "0" );
				gump.AddLabel( 100, 280, 0x64, "/" );
				gump.AddLabel( 130, 280, 0x64, "1" );
			}
			else
			{
				base.RenderProgress( gump );
			}
		}

		public SlayCalcifinaObjective()
		{
		}

		public override void OnKill( BaseCreature creature, Container corpse )
		{
			if ( creature is CalcifinaTheEnslaver )
				Complete();
		}

		public override void OnComplete()
		{
			System.AddObjective( new ObtainBowAndJournalObjective() );
		}
	}

	public class ObtainBowAndJournalObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Retrieve the Serpent Striker and return to the surface. Search the castle to see if there's anything else of importance.";
			}
		}

		public ObtainBowAndJournalObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddObjective( new ReturnJournalObjective() );
		}
	}

	public class ReturnJournalObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "You've procured the journal. Return to Quill Razorwind.";
			}
		}

		public ReturnJournalObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddObjective( new ReturnBowObjective() );
		}
	}

	public class ReturnBowObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "With that out of the way, now would be a good opportunity to hand the Serpent Striker over.";
			}
		}

		public ReturnBowObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new EndConversation() );
		}
	}
}