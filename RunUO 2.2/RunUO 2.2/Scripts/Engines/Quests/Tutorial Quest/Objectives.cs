using System;
using Server;
using Server.Mobiles;

namespace Server.Engines.Quests.AlmharaTutorial
{
	public class GoToBankObjective : QuestObjective
	{
		public override object Message
		{
			get
			{
                                return "Once you've settled on your race, head through one of the moongates, then proceed to the nearest bank to begin the next step.";
			}
		}

		public GoToBankObjective()
		{
		}

		public override void CheckProgress()
		{
			if ( System.From.Map == Map.Malas && System.From.InRange( new Point3D( 1622, 1866, 20 ), 13 ) )
				Complete();
		}

		public override void OnComplete()
		{
			PlayerMobile pm = System.From;

                        // hey!
			pm.PlaySound( 1069 );

			System.AddObjective( new GoUpToBankerObjective() );
		}
	}

	public class GoUpToBankerObjective : QuestObjective
	{
		private static readonly Point3D m_ChairLocation = new Point3D( 1637, 1870, 10 );

		private static readonly Map m_ChairMap = Map.Malas;

		private DateTime m_Begin;

		public override object Message
		{
			get
			{
                                return "You've arrived at the bank. Go inside, sit in one of the chairs at the counter next to the staircase and a banker should get to you shortly.";
			}
		}

		public GoUpToBankerObjective()
		{
			m_Begin = DateTime.MaxValue;
		}

		public override void CheckProgress()
		{
			PlayerMobile pm = System.From;

			if ( pm.Map == m_ChairMap && pm.Location == m_ChairLocation )
			{
				if ( m_Begin == DateTime.MaxValue )
				{
					m_Begin = DateTime.Now;
                                        // *sigh!*
			                pm.PlaySound( pm.Female ? 816 : 1090 );
				}
				else if ( DateTime.Now - m_Begin >= TimeSpan.FromSeconds( 10.0 ) )
				{
					Complete();
				}
			}
			else if ( m_Begin != DateTime.MaxValue )
			{
				m_Begin = DateTime.MaxValue;
			        pm.SendMessage( "You must remain seated in the chair. Patience is a virtue my friend." );
                                // *ahh-choo!*
			        pm.PlaySound( pm.Female ? 817 : 1091 );
                                // *farts*
			        pm.PlaySound( pm.Female ? 792 : 1064 );
			}
		}

		public override void OnComplete()
		{
			PlayerMobile pm = System.From;

                        // *slaps*
			pm.PlaySound( 948 );

			System.AddConversation( new BankInformationConversation() );
		}
	}
}