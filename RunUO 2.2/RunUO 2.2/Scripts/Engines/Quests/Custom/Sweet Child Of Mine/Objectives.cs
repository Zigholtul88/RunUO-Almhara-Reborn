using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Quests.SweetChildOfMine
{
	public class GoToIguanaCoveObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Search the lands for the entrance to Iguana Cove.";
			}
		}

		public GoToIguanaCoveObjective()
		{
		}
		public override void CheckProgress()
		{
			if ( System.From.Map == Map.Tokuno && System.From.InRange( new Point3D( 1382, 268, 18 ), 17 ) )
				Complete();
		}
 
		public override void OnComplete()
		{
			System.AddObjective( new FindHusbandObjective() );
		}
	}

	public class FindHusbandObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Find Gary.";
			}
		}

		public FindHusbandObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new TalkToGaryConversation() );
		}
	}

	public class FindKeyObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Search through any containers scattered about for the missing key.";
			}
		}

		public FindKeyObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddObjective( new ReturnKeyObjective() );
		}
	}

	public class ReturnKeyObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Hand the key over to Gary.";
			}
		}

		public ReturnKeyObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new HandKeyToGaryConversation() );
		}
	}

	public class RetrieveBabyObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Use the key to unlock the door and retrieve the baby from within the chest.";
			}
		}

		public RetrieveBabyObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddObjective( new ReturnBabyObjective() );
		}
	}

	public class ReturnBabyObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Return the baby to Gary.";
			}
		}

		public ReturnBabyObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new RelievedGaryConversation() );
		}
	}

	public class ReturnToDebbieObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Return to Debbie.";	
		        }
		}

		public ReturnToDebbieObjective()
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