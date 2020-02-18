using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.StolenNecklace
{
	public class StolenNecklaceQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( StolenNecklace.DontOfferConversation ),
				typeof( StolenNecklace.DeclineConversation ),
				typeof( StolenNecklace.AcceptConversation ),
				typeof( StolenNecklace.GetStolenNecklaceObjective ),
				typeof( StolenNecklace.ReturnStolenNecklaceObjective ),
				typeof( StolenNecklace.EndConversation ),
				typeof( StolenNecklace.DuringGetStolenNecklaceConversation ),
				typeof( StolenNecklace.MakeRoomObjective )				
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "Stolen Necklace";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You slowly approach an elven woman who appears to be in a depressed state. She takes note of you and begins to speak.</BASEFONT COLOR></I><BR><BR>This just cannot be happening to me. I was returning from a trip from Hammerhill when I was suddenly ambushed by a band of brigands. Before I could react I felt a sharp pinch coming from my neck and soon enough I blacked out. Waking up I found myself within Skaddria Naddheim and soon noticed that not only did the bastards make off with my clothing but a precious necklace that was handed down from my mother.<BR><BR>Are you able to help me in procuring my missing necklace?<BR><BR><I><BASEFONT COLOR=#0099FF>Notice: This quest offers +500 xp upon completion. Proceed?</BASEFONT COLOR></I><BR><BR>";					
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 525600.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15A9; } }

		public StolenNecklaceQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public StolenNecklaceQuest()
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
	
		public static bool HasStolenNecklace( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm == null )
				return false;

			QuestSystem qs = pm.Quest;

			if ( qs is StolenNecklaceQuest )
			{
				if ( qs.IsObjectiveInProgress( typeof( ReturnStolenNecklaceObjective ) ) )
				{
					Container pack = from.Backpack;

					return ( pack == null || pack.FindItemByType( typeof( QuestStolenNecklace ) ) == null );
				}
			}

			return false;
		}
	}
}
