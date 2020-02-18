using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.Zento
{
	public class TerribleHatchlingsQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( AcceptConversation ),
				typeof( DirectionConversation ),
				typeof( EndConversation ),
				typeof( KillObjective ),
				typeof( ReturnObjective )
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				// Terrible Hatchlings
				return 1063314;
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "The Deathwatch Beetle Hatchlings have trampled through my fields again, what a nuisance! Please help me get rid of the terrible hatchlings. If you kill 10 of them, you will be rewarded.<BR><BR>The Deathwatch Beetle Hatchlings live in the Harashi Nabi - the desert surrounding this establishment.<BR><BR>Do you accept this challenge?";
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 60.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15CF; } }

		public TerribleHatchlingsQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public TerribleHatchlingsQuest()
		{
		}

		public override void Accept()
		{
			base.Accept();

			AddConversation( new AcceptConversation() );
		}
	}
}