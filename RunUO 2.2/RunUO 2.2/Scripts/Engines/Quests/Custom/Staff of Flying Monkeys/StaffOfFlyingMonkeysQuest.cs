using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.StaffOfFlyingMonkeys
{
	public class StaffOfFlyingMonkeysQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( StaffOfFlyingMonkeys.DontOfferConversation ),
				typeof( StaffOfFlyingMonkeys.DeclineConversation ),
				typeof( StaffOfFlyingMonkeys.AcceptConversation ),
				typeof( StaffOfFlyingMonkeys.GoToMongbatCavernsObjective ),
				typeof( StaffOfFlyingMonkeys.DuringGoToMongbatCavernsConversation ),
				typeof( StaffOfFlyingMonkeys.SeekElderObjective ),
				typeof( StaffOfFlyingMonkeys.EscapeObjective ),
				typeof( StaffOfFlyingMonkeys.HandStaffOverConversation ),
				typeof( StaffOfFlyingMonkeys.HandStaffOverObjective ),
				typeof( StaffOfFlyingMonkeys.DuringHandStaffOverConversation ),
				typeof( StaffOfFlyingMonkeys.EndConversation ),
				typeof( StaffOfFlyingMonkeys.RecentlyFinishedConversation )				
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "Staff of Flying Monkeys";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You stumble upon a man fiddling around with an intricate designed dagger. He turns towards you, placing the weapon onto the table before speaking.</BASEFONT COLOR></I><BR><BR>Well top of the evening to you, resident of Skaddria Naddheim. I am Boryan, a collector of rare,unusual trinkets and I was wondering if I could take a moment of your time in order to help me procure a particular staff of, shall you say, mongbat origins.<BR><BR><I><BASEFONT COLOR=#0099FF>Notice: This quest offers +1000 xp upon completion. Proceed?</BASEFONT COLOR></I><BR><BR>";	
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 525600.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15A9; } }

		public StaffOfFlyingMonkeysQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public StaffOfFlyingMonkeysQuest()
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