using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.OreShortageSkaddria
{
	public class OreShortageSkaddriaQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( OreShortageSkaddria.DeclineConversation ),
				typeof( OreShortageSkaddria.AcceptConversation ),
				typeof( OreShortageSkaddria.GatherIngotsConversation ),
				typeof( OreShortageSkaddria.GatherIngotsObjective ),
				typeof( OreShortageSkaddria.Reward100Conversation ),
				typeof( OreShortageSkaddria.Reward200Conversation ),
				typeof( OreShortageSkaddria.Reward300Conversation ),
				typeof( OreShortageSkaddria.Reward400Conversation )
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "Ore Shortage (Skaddria Naddheim)";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "Seriously matey, you really need me to explain things to you. Are you stupid? Well maybe you are for talking to me. That's what everyone around here seems to think. Very well, here's the run down of everything you need to know.<BR><BR>First off, you're going to need ore, lots and lots of ore and the only way to do that is by picking up either a pickaxe or shovel and head over to the nearest rock and start digging. No you cannot purchase ingots from us because we're not allowed to sell them, its business protocol. Now depending on your Mining skill you will most likely end up with little or no ore to compensate how many times you've worn out your tool.<BR><BR>Now you got all this ore but you're unable to carry it all. Well I would suggest picking up a pack horse or two from the rancher that lives over by the farm just before you start heading for any mining spots. There's a pass over by the zoo that makes for an excellent place. But don't venture too close to the farm or else the ratmen will get you and last time I checked, horses don't make for competent fighters, so be careful.<BR><BR>That's everything you need to know. I cannot possibly dumb this information down any further.<BR><BR>Say my fellow traveler, could you be of some assistance?<BR><BR>We've been filling up these orders left and right, mostly from Cedric and as a result we've run short on useable ingots.";					
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 1444.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15CF; } }

		public OreShortageSkaddriaQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public OreShortageSkaddriaQuest()
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
