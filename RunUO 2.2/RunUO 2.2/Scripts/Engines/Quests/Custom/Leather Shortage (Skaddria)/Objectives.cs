using System;
using Server;
using Server.Mobiles;

namespace Server.Engines.Quests.LeatherShortageSkaddria
{
	public class GatherLeatherObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Gather up 100 leather stripes which can range from spined, horned, or barbed and return to Nathan.";					
			}
		}

		public GatherLeatherObjective()
		{
		}		
	}	
}