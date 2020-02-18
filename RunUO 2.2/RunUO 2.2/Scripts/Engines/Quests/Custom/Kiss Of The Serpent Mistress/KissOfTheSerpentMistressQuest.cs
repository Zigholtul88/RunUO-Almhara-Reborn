using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.KissOfTheSerpentMistress
{
	public class KissOfTheSerpentMistressQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( KissOfTheSerpentMistress.DeclineConversation ),
				typeof( KissOfTheSerpentMistress.AcceptConversation ),
				typeof( KissOfTheSerpentMistress.StoryConversation ),
				typeof( KissOfTheSerpentMistress.SlayCalcifinaObjective ),
				typeof( KissOfTheSerpentMistress.ObtainBowAndJournalObjective ),
				typeof( KissOfTheSerpentMistress.ReturnJournalObjective ),
				typeof( KissOfTheSerpentMistress.CalcifinasJournalConversation ),
				typeof( KissOfTheSerpentMistress.ReturnBowObjective ),
				typeof( KissOfTheSerpentMistress.EndConversation ),
				typeof( KissOfTheSerpentMistress.DuringSlayCalcifinaConversation )
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "Kiss of the Serpent Mistress";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>Standing before you is a ravishing green haired elven woman who appears to be flexing the string of her longbow. She pauses to take note of your presence, then promptly speaks.</BASEFONT COLOR></I><BR><BR>Mark my words young adventurer from Hammerhill. The task I have in store for you may prove to be quite the challenge. I would suggest that you get better with your skills before even attempting this one. Though I could be wrong on this one. What is your response?<BR><BR><I><BASEFONT COLOR=#0099FF>Notice: This quest offers +2000 xp upon completion. Proceed?</BASEFONT COLOR></I><BR><BR>";			
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromHours( 525600.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15A9; } }

		public KissOfTheSerpentMistressQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public KissOfTheSerpentMistressQuest()
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

		public static bool HasCalcifinasJournal( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm == null )
				return false;

			QuestSystem qs = pm.Quest;

			if ( qs is KissOfTheSerpentMistressQuest )
			{
				if ( qs.IsObjectiveInProgress( typeof( ReturnJournalObjective ) ) )
				{
					Container pack = from.Backpack;

					return ( pack == null || pack.FindItemByType( typeof( CalcifinasJournal ) ) == null );
				}
			}

			return false;
		}
	}
}
