using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.HaldursBait
{
	public class GetBaitObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Gather 10 worms from decaying corpses over in Zaythalor Graveyard.";
			}
		}

		public GetBaitObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new EndConversation() );
		}
	}
}