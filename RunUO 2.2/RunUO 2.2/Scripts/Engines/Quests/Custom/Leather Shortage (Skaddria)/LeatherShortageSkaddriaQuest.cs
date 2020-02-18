using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.LeatherShortageSkaddria
{
	public class LeatherShortageSkaddriaQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( LeatherShortageSkaddria.DeclineConversation ),
				typeof( LeatherShortageSkaddria.AcceptConversation ),
				typeof( LeatherShortageSkaddria.GatherLeatherConversation ),
				typeof( LeatherShortageSkaddria.GatherLeatherObjective ),
				typeof( LeatherShortageSkaddria.Reward100Conversation ),
				typeof( LeatherShortageSkaddria.Reward200Conversation ),
				typeof( LeatherShortageSkaddria.Reward300Conversation )
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "Leather Shortage (Skaddria Naddheim)";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "You thought the cobbler's job sucked royally hard. Shit, at least every outfit known to fucking mortal kind looks excellent with a pair of boots. But me, I gotta settle with customers pawning off their leather, mostly from cows and the only item I have to sell is this goddamn taxidermy kit. Which I had to bring the price down, because no one who has just an ounce of some intelligence is going to buy something that's half a million gold that has severe limited use.BR><BR>Say my fellow traveler, could you be of some assistance?<BR><BR>We've been filling up these orders left and right, mostly from Matilda and as a result we've run short on useable leather.";					
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 1444.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15CF; } }

		public LeatherShortageSkaddriaQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public LeatherShortageSkaddriaQuest()
		{
		}

		public override void Accept()
		{
			base.Accept();

			AddConversation( new AcceptConversation() );
		}

		public override void Decline()
		{
			base.Decline();

			AddConversation( new DeclineConversation() );
		}
	}
}
