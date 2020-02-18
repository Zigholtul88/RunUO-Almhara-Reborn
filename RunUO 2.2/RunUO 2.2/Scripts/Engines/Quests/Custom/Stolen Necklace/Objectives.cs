using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Quests.StolenNecklace
{
	public class GetStolenNecklaceObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Head towards Brigand Camp and retrieve the necklace. Be sure to search through every container you stumble across.";
			}
		}

		public GetStolenNecklaceObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddObjective( new ReturnStolenNecklaceObjective() );
		}
	}

	public class ReturnStolenNecklaceObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "You search the entire bookcase and managed to procure a shiny necklace. Return to Raina Gollemere in Elmhaven.";	
		      }
		}

		public ReturnStolenNecklaceObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new EndConversation() );
		}
	}

	public class MakeRoomObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "You must make room in your inventory in order to complete the trade.";
			}
		}

		public MakeRoomObjective()
		{
		}		
	}	
}