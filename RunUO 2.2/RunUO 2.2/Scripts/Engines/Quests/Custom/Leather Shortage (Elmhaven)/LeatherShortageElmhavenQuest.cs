using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.LeatherShortageElmhaven
{
	public class LeatherShortageElmhavenQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( LeatherShortageElmhaven.DeclineConversation ),
				typeof( LeatherShortageElmhaven.AcceptConversation ),
				typeof( LeatherShortageElmhaven.GatherLeatherConversation ),
				typeof( LeatherShortageElmhaven.GatherLeatherObjective ),
				typeof( LeatherShortageElmhaven.Reward100Conversation ),
				typeof( LeatherShortageElmhaven.Reward200Conversation ),
				typeof( LeatherShortageElmhaven.Reward300Conversation )
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "Leather Shortage (Elmhaven)";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "Ahh a new face, we don't often get many visitors here. Too busy checking out the other merchants around here. I'm afraid I only have this taxidermy kit that will allow you to mount certain heads of various animals onto your wall.<BR><BR>Say my fellow traveler, could you be of some assistance?<BR><BR>We've been filling up these orders left and right, mostly from Matilda and as a result we've run short on useable leather.";					
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 1444.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15CF; } }

		public LeatherShortageElmhavenQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public LeatherShortageElmhavenQuest()
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
