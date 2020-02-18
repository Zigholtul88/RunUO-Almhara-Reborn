using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Quests.LetterDelivery
{
	public class PotionObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Bring Ozzy a lesser yellow potion.";
			}
		}

		public PotionObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new DeliverLetterToCeciliaConversation() );
		}
	}

	public class DeliverLetterToCeciliaObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Deliver the letter over to Cecilia in Elmhaven just northwest of this town.";
			}
		}

		public DeliverLetterToCeciliaObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new TalkToCeciliaConversation() );
		}
	}

	public class GiveLetterToCeciliaObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Hand the sealed letter over to Cecilia.";
			}
		}

		public GiveLetterToCeciliaObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new DeliverLetterToOzzyConversation() );
		}
	}

	public class DeliverLetterToOzzyObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Delivery Cecilia's letter back to Ozzy in Hammerhill.";
			}
		}

		public DeliverLetterToOzzyObjective()
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