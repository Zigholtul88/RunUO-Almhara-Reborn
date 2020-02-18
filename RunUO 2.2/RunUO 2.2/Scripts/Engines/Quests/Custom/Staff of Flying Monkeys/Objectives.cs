using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.Engines.Quests.StaffOfFlyingMonkeys
{
	public class GoToMongbatCavernsObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Look for the cave entrance surrounded by mongbats. That should be your next destination.";
			}
		}

		public GoToMongbatCavernsObjective()
		{
		}

		public override void CheckProgress()
		{
			if ( System.From.Map == Map.Tokuno && System.From.InRange( new Point3D( 589, 24, 18 ), 20 ) )
				Complete();
		}

		public override void OnComplete()
		{
			System.AddObjective( new SeekElderObjective() );
		}
	}

	public class SeekElderObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Seek out the elder. Kill him. Then be prepared to run for your life.";
			}
		}

		public SeekElderObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddObjective( new EscapeObjective() );
		}
	}

	public class EscapeObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Escape Mongbat Hideout and reach Boryan. Whatever you do, make sure you have the staff in your backpack and not equipped or you will fail.";
			}
		}

		public EscapeObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new HandStaffOverConversation() );
		}
	}

	public class HandStaffOverObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
				return "Hand the staff over to Boryan................. whenever you're ready of course.";
			}
		}

		public HandStaffOverObjective()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation( new EndConversation() );
		}
	}	
}