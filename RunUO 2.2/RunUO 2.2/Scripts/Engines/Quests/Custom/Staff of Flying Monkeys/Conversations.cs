using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.StaffOfFlyingMonkeys
{
	public class DontOfferConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "You're currently in the middle of pressing matters of your own. Perhaps whenever you're finished with them, maybe you might be able to help me out.";
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
				return "<I><BASEFONT COLOR=#FFFF00>You decline in helping out and the collector looks at you with grief.</BASEFONT COLOR></I><BR><BR>Why won't you help me? Come on, I promise it'll be worth your time.";
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
				return "<I><BASEFONT COLOR=#FFFF00>You accept in helping out and the collector smiles at your request.</BASEFONT COLOR></I><BR><BR>Ah, blessings onto you fair traveler. Well the staff in question is a strange oddity if rumors are true. It is a staff that possesses the innate ability to conjure up mongbat familiars at will. Now why in Almhara would someone go through the efforts of creating a device for such a silly purpose is beyond my comprehension, but I can admit that I'm intrigued by the whole prospect. Which is why I use your assistance.<BR><BR>Just south-east of Hammerhill is a cave that has recently been taken over by several of those creatures and I believe the elder whose located on the deepest level should have it on his person. I would come along, but I never did take solace in damp and darkened places and plus I always forget to bring myself something to light the way.";
			}
		}

		public AcceptConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new GoToMongbatCavernsObjective() );
		}
	}

	public class DuringGoToMongbatCavernsConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "If I were you I'd stock up on plenty of healing supplies. Those elders pack one heck of a beating.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringGoToMongbatCavernsConversation()
		{
		}
	}

	public class HandStaffOverConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Hide in here while the town guards make quick work of the mongbat horde.";
			}
		}

		public HandStaffOverConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new HandStaffOverObjective() );
		}
	}

	public class DuringHandStaffOverConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Yah know, now that things around seem to have been situated. Mind if I have the staff now?";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringHandStaffOverConversation()
		{
		}
	}

	public class RecentlyFinishedConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "I can't say I'll be needing anymore of your time. Now some of the other people around these parts. Well that's really up to you if you wanna go down those routes.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public RecentlyFinishedConversation()
		{
		}
	}

	public class EndConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>The collector gasps in excitement upon you handing him the staff.</BASEFONT COLOR></I><BR><BR>Wowsers! This is indeed quite a potent piece of tribalistic craftsmanship. Well done on procuring the staff. This will no doubt make for quite the display piece. Now, about your reward, well hopefully this massive sack of gold should do the trick. Also I received this strange gem off of Melanchanth over in Elmhaven for helping him sort out his own collection of worthless trinkets. He said that it was capable of imbuing just about any weapon with a nice fireball effect. Perhaps it might be better served within the palms of your hands.";
			}
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // woohoo!
			pm.PlaySound( 0x5B1 ); // fiddle_use_well
			pm.PlaySound( pm.Female ? 783 : 1054 );
                        pm.Send( Network.PlayMusic.GetInstance( MusicName.Victory ) );
                        pm.Say( "Yahoo!" );

                        pm.Exp += 1000;
                        pm.KillExp += 1000;
                        pm.SendMessage("You've gained 1000 exp.");

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