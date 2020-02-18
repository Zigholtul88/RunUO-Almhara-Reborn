using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.BrightClub
{
	public class BrightClubQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( BrightClub.DeclineConversation ),
				typeof( BrightClub.AcceptConversation ),
				typeof( BrightClub.KillGolemObjective ),
				typeof( BrightClub.ReturnToLighthouseObjective ),
				typeof( BrightClub.DirectionConversation ),
				typeof( BrightClub.EndConversation )
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "Bright Club!";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>*The Lighthouse Keeper looks at you intently.*</BASEFONT COLOR></I><BR><BR>I see you have come to help me with my dimming light. I am unable to keep watch over this lighthouse and find the time to seek out more Light Enhancing Crystals.<BR><BR>There is a creature that carries these crystals. It is thought that it wanders somewhere within the Jade Jungle. He was last encountered next to a pile of cloths. I worry what became of the poor soul that wore them.<BR><BR>If you can bring me a light enhancing crystal, I will reward you with a Travel Book.<BR><BR>I<BR><BR>Can you help me?<BR><BR><I><BASEFONT COLOR=#0099FF>Notice: This quest offers +2000 xp upon completion. Proceed?</BASEFONT COLOR></I><BR><BR>";
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 525600.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15CF; } }

		public BrightClubQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public BrightClubQuest()
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