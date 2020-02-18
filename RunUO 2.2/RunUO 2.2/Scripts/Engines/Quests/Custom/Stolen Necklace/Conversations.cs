using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Quests.StolenNecklace
{
	public class DontOfferConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "I may have lost everything but at least I still got my mother's necklace.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DontOfferConversation()
		{
		}
	}

	public class DeclineConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                        return "<I><BASEFONT COLOR=#FFFF00>You decline the offer and the battered elven woman returns to her saddened state.<BR><BR><I><BASEFONT COLOR=#FFFF00>You know, you outta consider doing this quest. Its really fucking easy, I'm telling you. Okay so maybe the brigands might give you a hard time, those bastards can deal some nasty damage. But these quests always offer decent rewards. Just do the damn quest and maybe you might be presented with a strip tease or something<BR><BR><I><BASEFONT COLOR=#FFFF00>What!? You really think this old ass game can even program something like that?";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DeclineConversation()
		{
		}
	}

	public class AcceptConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>The young woman breathes a sigh of relief at your proposal.</BASEFONT COLOR></I><BR><BR>Something tells me that camp located by the road is where the necklace is stashed. I need you to go over there and retrieve it by any means necessary.";  
			}
		}

		public AcceptConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new GetStolenNecklaceObjective() );
		}
	}

	public class EndConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                        return "<I><BASEFONT COLOR=#FFFF00>You approach Raina and hand over the necklace.</BASEFONT COLOR></I><BR><BR>Oh thank the almighty stars, you've done it. Sadly I don't have much I can give you besides this mana potion and whatever scraps of gold I could find.";
			}
		}

		public EndConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // woohoo!
			pm.PlaySound( pm.Female ? 783 : 1054 );
                        pm.Send( Network.PlayMusic.GetInstance( MusicName.Victory ) );
                        pm.Say( "Yahoo!" );

                        pm.Exp += 500;
                        pm.KillExp += 500;
                        pm.SendMessage("You've gained 500 exp.");

                        if (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
                        {
                                Actions.DoLevel(pm, new Setup());
                        }

                        pm.TotalQuestsDone += 1;

			System.Complete();
		}
	}

	public class DuringGetStolenNecklaceConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Were you able to find anything at the Brigand Camp?";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringGetStolenNecklaceConversation()
		{
		}
	}
}