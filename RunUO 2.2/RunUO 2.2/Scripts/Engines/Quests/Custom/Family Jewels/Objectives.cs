using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Quests.FamilyJewels
{
	public class SeekUncleJohnObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Seek out Uncle John who chances are is more than likely over at Sabrina's Farm in Zaythalor Forest.";
			}
		}

		public SeekUncleJohnObjective()
		{
		}
 
		public override void OnComplete()
		{
			System.AddConversation( new UncleJohnConversation() );
		}
	}

	public class ObtainGreenCarrotObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Slay a savage bunny in order to obtain a green carrot. Be quick or else it will eventually escape to safety.";
			}
		}

		public ObtainGreenCarrotObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new UncleJohn2Conversation() );
		}
	}

	public class SeekGrandpaTamObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Seek out Grandpa Tam over in Elmhaven.";
			}
		}

		public SeekGrandpaTamObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new GrandpaTamConversation() );
		}
	}

	public class ObtainGoldenEggObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Check out the farm. One of the chickens has the golden egg. To obtain it, double-click and it'll drop onto the ground.";
			}
		}

		public ObtainGoldenEggObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new GrandpaTam2Conversation() );
		}
	}

	public class SeekAuntieJuneObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Seek out Auntie June whose somewhere beyond Old Plunderer's Haven.";
			}
		}

		public SeekAuntieJuneObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new AuntieJuneConversation() );
		}
	}

	public class ObtainBlueAppleObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Scout the area for any blue apples that can easily be lifted.";
			}
		}

		public ObtainBlueAppleObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new AuntieJune2Conversation() );
		}
	}

	public class ReturnToArrianaObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Use the jewelry box to combine the 3 components and return the finished product to Arriana.";	
		        }
		}

		public ReturnToArrianaObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new EndConversation() );
		}
	}	
}