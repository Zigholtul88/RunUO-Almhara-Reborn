using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.SweetChildOfMine
{
	public class SweetChildOfMineQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( SweetChildOfMine.DontOfferConversation ),
				typeof( SweetChildOfMine.DeclineConversation ),
				typeof( SweetChildOfMine.AcceptConversation ),
				typeof( SweetChildOfMine.GoToIguanaCoveObjective ),
				typeof( SweetChildOfMine.DuringGoToIguanaCoveConversation ),
				typeof( SweetChildOfMine.FindHusbandObjective ),
				typeof( SweetChildOfMine.TalkToGaryConversation ),
				typeof( SweetChildOfMine.FindKeyObjective ),
				typeof( SweetChildOfMine.DuringFindKeyConversation ),
				typeof( SweetChildOfMine.ReturnKeyObjective ),
				typeof( SweetChildOfMine.HandKeyToGaryConversation ),
				typeof( SweetChildOfMine.RetrieveBabyObjective ),
				typeof( SweetChildOfMine.DuringRetrieveBabyConversation ),
				typeof( SweetChildOfMine.ReturnBabyObjective ),
				typeof( SweetChildOfMine.RelievedGaryConversation ),
				typeof( SweetChildOfMine.ReturnToDebbieObjective ),
				typeof( SweetChildOfMine.DuringReturnToDebbieConversation ),
				typeof( SweetChildOfMine.EndConversation ),
				typeof( SweetChildOfMine.RecentlyFinishedConversation ),
				typeof( SweetChildOfMine.MakeRoomObjective )				
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "Sweet Child of Mine";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>The mother looks up at you with a very sad look.</BASEFONT COLOR></I><BR><BR>I miss her so much. Please leave me be unless you're willing to help me get her back.<BR><BR><I><BASEFONT COLOR=#0099FF>Notice: This quest offers +1000 xp upon completion. Proceed?</BASEFONT COLOR></I><BR><BR>";
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 525600.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15A9; } }

		public SweetChildOfMineQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public SweetChildOfMineQuest()
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
	
		public static bool HasIguanaCoveKey( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm == null )
				return false;

			QuestSystem qs = pm.Quest;

			if ( qs is SweetChildOfMineQuest )
			{
				if ( qs.IsObjectiveInProgress( typeof( FindKeyObjective ) ) )
				{
					Container pack = from.Backpack;

					return ( pack == null || pack.FindItemByType( typeof( IguanaCoveKey ) ) == null );
				}
			}

			return false;
		}

		public static bool HasBaby( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm == null )
				return false;

			QuestSystem qs = pm.Quest;

			if ( qs is SweetChildOfMineQuest )
			{
				if ( qs.IsObjectiveInProgress( typeof( RetrieveBabyObjective ) ) )
				{
					Container pack = from.Backpack;

					return ( pack == null || pack.FindItemByType( typeof( Baby ) ) == null );
				}
			}

			return false;
		}
	}
}
