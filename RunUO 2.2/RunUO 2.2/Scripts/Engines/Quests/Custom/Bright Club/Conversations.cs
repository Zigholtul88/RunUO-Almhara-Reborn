using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Engines.Quests.BrightClub
{
	public class DeclineConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You decline the request.</BASEFONT COLOR></I><BR><BR>Please I insist! I don't know how long I'm able to keep the lights from going out completely!";
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
				return "<I><BASEFONT COLOR=#FFFF00>You accept the request.</BASEFONT COLOR></I><BR><BR>Thanks mate. Now where were we, ah yes.<BR><BR>This is not just an ordinary Travel Book. I have been able to alter the Light Enhancing Crystals to work within the pages to provide a way of travel. Though I have yet to find a way to make the amount of uses indefinate.<BR><BR>In any case, please bring me back a Light Enhancing Crystal. I will be more than happy to reward your efforts.";
			}
		}

		public AcceptConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new KillGolemObjective() );
		}
	}

	public class DirectionConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Crystal Golems hit hard so heed with caution!";
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
				return "<I><BASEFONT COLOR=#FFFF00>*You hand him the crystal*.</BASEFONT COLOR></I><BR><BR>Thank you for bringing me a Light Enhancing Crystal. Many sailors thank you! I hope you find your reward useful.";
			}
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // woohoo!
			pm.PlaySound( 0x5B1 ); // fiddle_use_well
			pm.PlaySound( pm.Female ? 783 : 1054 );
                        pm.Say( "Yahoo!" );

                        pm.Exp += 2000;
                        pm.KillExp += 2000;
                        pm.SendMessage("You've gained 2000 exp.");

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