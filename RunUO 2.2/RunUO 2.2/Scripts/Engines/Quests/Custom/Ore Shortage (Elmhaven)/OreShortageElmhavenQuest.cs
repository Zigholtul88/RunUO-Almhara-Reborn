using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.OreShortageElmhaven
{
	public class OreShortageElmhavenQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( OreShortageElmhaven.DeclineConversation ),
				typeof( OreShortageElmhaven.AcceptConversation ),
				typeof( OreShortageElmhaven.GatherIngotsConversation ),
				typeof( OreShortageElmhaven.GatherIngotsObjective ),
				typeof( OreShortageElmhaven.Reward100Conversation ),
				typeof( OreShortageElmhaven.Reward200Conversation ),
				typeof( OreShortageElmhaven.Reward300Conversation ),
				typeof( OreShortageElmhaven.Reward400Conversation )
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "Ore Shortage (Elmhaven)";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "Say my fellow traveler, could you be of some assistance?<BR><BR>We've been filling up these orders left and right, mostly from Cedric and as a result we've run short on useable ingots.";					
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 1444.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15CF; } }

		public OreShortageElmhavenQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public OreShortageElmhavenQuest()
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
