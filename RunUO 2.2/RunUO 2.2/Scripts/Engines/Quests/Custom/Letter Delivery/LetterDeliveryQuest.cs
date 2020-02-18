using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.LetterDelivery
{
	public class LetterDeliveryQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( LetterDelivery.DontOfferConversation ),
				typeof( LetterDelivery.DeclineConversation ),
				typeof( LetterDelivery.AcceptConversation ),
				typeof( LetterDelivery.PotionObjective ),
				typeof( LetterDelivery.DuringPotionConversation ),
				typeof( LetterDelivery.DeliverLetterToCeciliaConversation ),
				typeof( LetterDelivery.DeliverLetterToCeciliaObjective ),
				typeof( LetterDelivery.DuringLetterToCeciliaConversation ),
				typeof( LetterDelivery.TalkToCeciliaConversation ),
				typeof( LetterDelivery.GiveLetterToCeciliaObjective ),
				typeof( LetterDelivery.DeliverLetterToOzzyConversation ),
				typeof( LetterDelivery.DeliverLetterToOzzyObjective ),
				typeof( LetterDelivery.DuringLetterToOzzyConversation ),
				typeof( LetterDelivery.EndConversation ),
				typeof( LetterDelivery.MakeRoomObjective )				
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "Letter Delivery";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You notice a young man sitting right next to the bed. He turns towards you and promptly speaks.</BASEFONT COLOR></I><BR><BR>I see you've noticed the damage around here. This small community was just not too long ago attacked by a band of evil mages that were seeking some stone believed to possess divine power. Me and a few other men tried as we could to drive them back but they came accompanied by ferocious looking fire elementals and let me tell you they are not to be triffled with. Eventually we did overcome the invading army but at the cost of a severely burnt left arm and several broken bones. Its gonna be a while before I can recover so can you help out with a small favor?<BR><BR>Perhaps I may be able to speed up the recovery process if you're able to fetch for me a healing potion. I can barely move my muscles.<BR><BR><I><BASEFONT COLOR=#0099FF>Notice: This quest offers +500 xp upon completion. Proceed?</BASEFONT COLOR></I><BR><BR>";  		
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 525600.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15A9; } }

		public LetterDeliveryQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public LetterDeliveryQuest()
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