using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Engines.Quests.HaldursBait
{
	public class DeclineConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You decline the request.</BASEFONT COLOR></I><BR><BR>Alright then. Just come on back whenever you change your mind.";
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
				return "<I><BASEFONT COLOR=#FFFF00>You accept the request and James hands you an empty jar.</BASEFONT COLOR></I><BR><BR>If you get me enough fertile dirt and worms to fill this jar, you can have my old fishing pole. I wouldn't need this old thing if I had some bait. You will have to go find the dirt, I think black ants will give you some if you ask kindly, hehe. If not just kill em' and take it!";
			}
		}

		public AcceptConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			pm.AddToBackpack( new WormJarEmpty() );

			System.AddObjective( new GetBaitObjective() );
		}
	}

	public class DirectionConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "You can find some worms off of those decaying corpses in the graveyard. Use fire if necessary and watch out for any other random encounters.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DirectionConversation()
		{
		}
	}

	public class EndConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>Haldur carefully inspects the jar.</BASEFONT COLOR></I><BR><BR>Thanks alot youngster! You can have this old pole here. I won't be needing it anymore. Darn thing never caught nothin' but old boots anyhow. I wish ye better luck with it. Happy to see another fisherman around. Just not enough fisherman anymore. Oh! By the way, if you come back I have a few more of them poles you could have, for the price of worms, of course!";
			}
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // woohoo!
			pm.PlaySound( 0x5B1 ); // fiddle_use_well
			pm.PlaySound( pm.Female ? 783 : 1054 );
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

		public EndConversation()
		{
		}
	}
}