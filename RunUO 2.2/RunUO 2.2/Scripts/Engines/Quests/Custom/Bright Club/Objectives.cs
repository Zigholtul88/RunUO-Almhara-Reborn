using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.BrightClub
{
	public class KillGolemObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Head to Jade Jungle and slay a crystal golem in order to retrieve its crystal.";
			}
		}

		public KillGolemObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddObjective( new ReturnToLighthouseObjective() );
		}
	}

	public class ReturnToLighthouseObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Return the crystal to the lighthouse keeper.";
			}
		}

		public ReturnToLighthouseObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new EndConversation() );
		}
	}
}