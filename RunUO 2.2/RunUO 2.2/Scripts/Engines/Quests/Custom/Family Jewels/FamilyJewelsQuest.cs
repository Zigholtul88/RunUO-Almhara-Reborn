using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.FamilyJewels
{
	public class FamilyJewelsQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( FamilyJewels.DeclineConversation ),
				typeof( FamilyJewels.AcceptConversation ),
				typeof( FamilyJewels.SeekUncleJohnObjective ),
				typeof( FamilyJewels.DuringSeekUncleJohnConversation ),
				typeof( FamilyJewels.UncleJohnConversation ),
				typeof( FamilyJewels.ObtainGreenCarrotObjective ),
				typeof( FamilyJewels.DuringObtainGreenCarrotConversation ),
				typeof( FamilyJewels.UncleJohn2Conversation ),
				typeof( FamilyJewels.SeekGrandpaTamObjective ),
				typeof( FamilyJewels.DuringSeekGrandpaTamConversation ),
				typeof( FamilyJewels.GrandpaTamConversation ),
				typeof( FamilyJewels.ObtainGoldenEggObjective ),
				typeof( FamilyJewels.DuringObtainGoldenEggConversation ),
				typeof( FamilyJewels.GrandpaTam2Conversation ),
				typeof( FamilyJewels.SeekAuntieJuneObjective ),
				typeof( FamilyJewels.DuringSeekAuntieJuneConversation ),
				typeof( FamilyJewels.AuntieJuneConversation ),
				typeof( FamilyJewels.ObtainBlueAppleObjective ),
				typeof( FamilyJewels.DuringObtainBlueAppleConversation ),
				typeof( FamilyJewels.AuntieJune2Conversation ),
				typeof( FamilyJewels.ReturnToArrianaObjective ),
				typeof( FamilyJewels.DuringReturnToArrianaConversation ),
				typeof( FamilyJewels.EndConversation )
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "Family Jewels!";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>*Arriana opens the conversation with a legend about her lineage.*</BASEFONT COLOR></I><BR><BR>I was once told by my mother that our family had possessed a heirloom of magical powers. Rumor has it, that when the age of Inquisitors was upon us, and all magic was being destroyed, that my family broke it down into parts and spread it amongst our relatives. But alas, I have no idea where the pieces have gone. My good traveler, will you help me re-unite the pieces so i may restore this heirloom once again? I know from Diary entries that the pieces were dispersed among three of our ancestors...<BR><BR>Individually, these items are common and mean nothing. But if thou art honerable enough to bring the joined pieces to me, I shall restore it with the instructions left to me, and make you a duplicate for your troubles.<BR><BR>To help you with this I will give you my jewelry box to rejoin the pieces, just double click on it with the pieces in your sack and they will join to become one.<BR><BR><I><BASEFONT COLOR=#0099FF>Notice: This quest offers +2000 xp upon completion. Proceed?</BASEFONT COLOR></I><BR><BR>";	
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 525600.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15CF; } }

		public FamilyJewelsQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public FamilyJewelsQuest()
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