using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.HaldursBait
{
	public class HaldursBaitQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( HaldursBait.DeclineConversation ),
				typeof( HaldursBait.AcceptConversation ),
				typeof( HaldursBait.GetBaitObjective ),
				typeof( HaldursBait.DirectionConversation ),
				typeof( HaldursBait.EndConversation )
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "Haldur's Bait!";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>*Haldur looks to you with a gleam in his eye*.</BASEFONT COLOR></I><BR><BR>Hi there stranger! You know, worms are the best bait. Get an old fisherman some worms, would ye?I hear you can get worms from decaying corpses over at the cemetery next to Hammerhill.<BR><BR><I><BASEFONT COLOR=#0099FF>Notice: This quest offers +500 xp upon completion. Proceed?</BASEFONT COLOR></I><BR><BR>";
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 525600.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15CF; } }

		public HaldursBaitQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public HaldursBaitQuest()
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