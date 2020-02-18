using System;
using Server;
using Server.Mobiles;

namespace Server.Engines.Quests.OreShortageElmhaven
{
	public class GatherIngotsObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Gather up 100 ingots which can range from dull copper, shadow iron, copper or bronze and return to Lynis.";					
			}
		}

		public GatherIngotsObjective()
		{
		}		
	}	
}