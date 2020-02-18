using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.Zento
{
	public class KillObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Kill 10 Deathwatch Beetle Hatchlings and return to Ansella Gryen.";
			}
		}

		public KillObjective()
		{
		}

		public override int MaxProgress{ get{ return 10; } }

		public override void RenderProgress( BaseQuestGump gump )
		{
			if ( !Completed )
			{
				// Deathwatch Beetle Hatchlings killed:
				gump.AddHtmlLocalized( 70, 260, 270, 100, BaseQuestGump.Blue, false, false );
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
			if ( creature is DeathwatchBeetleHatchling )
				CurProgress++;
		}

		public override void OnComplete()
		{
			System.AddObjective( new ReturnObjective() );
		}
	}

	public class ReturnObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Return to Ansella Gryen for your reward.";
			}
		}

		public ReturnObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new EndConversation() );
		}
	}
}