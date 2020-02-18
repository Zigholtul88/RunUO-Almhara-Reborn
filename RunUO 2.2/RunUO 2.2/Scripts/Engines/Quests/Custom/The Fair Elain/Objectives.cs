using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.TheFairElain
{
	public class SeekVacarJamesObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Find Vacar James whose currently at the library.";
			}
		}

		public SeekVacarJamesObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new VacarJamesConversation() );
		}
	}

	public class SeekErikSullivanObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Find Erik Sullivan whose down by the waterfalls where the sharks lie.";
			}
		}

		public SeekErikSullivanObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new ErikSullivanConversation() );
		}
	}

	public class SeekAndoraObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Find Andora whose currently patrolling in Zaythalor Forest.";
			}
		}

		public SeekAndoraObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new AndoraConversation() );
		}
	}

	public class SeekAcarasObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Search Zaythalor Forest for Acaras.";
			}
		}

		public SeekAcarasObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new AcarasConversation() );
		}
	}

	public class BringAcarasRobeObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Bring Acaras a robe. Just an ordinary robe will do.";
			}
		}

		public BringAcarasRobeObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new AcarasEndConversation() );
		}
	}

	public class BringRingToAndoraObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Take the ring over to Andora the ranger.";
			}
		}

		public BringRingToAndoraObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new AndorasEndConversation() );
		}
	}

	public class BringBookToVacarObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Take the book to Vacar James. After that's done return the letter to either Erik or Alecsander.";
			}
		}

		public BringBookToVacarObjective()
		{
		}
	}
}