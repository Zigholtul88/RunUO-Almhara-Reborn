using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Quests.LetterDelivery
{
	public class DontOfferConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Mate you've already helped with everything I've need. I need to get some rest.";
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
                        return "<I><BASEFONT COLOR=#FFFF00>You decline the offer and the young man starts to get pissed off.</BASEFONT COLOR></I><BR><BR>Seriously you aren't going to help me? For fuck sakes this town is a huge mess because of those goddamn fire elementals, my arm is still burnt almost to the point where I can start snacking on it like a 2 star course meal, and because I'm stuck here I won't be able to see my girlfriend over in Elmhaven. I hope you're happy with yourself you pathetic piece of mongbat manure.";
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
				return "<I><BASEFONT COLOR=#FFFF00>The young man smiles at your offer.</BASEFONT COLOR></I><BR><BR>Thanks pal, I appreciate it. You should be able to get one over at Haree Potters here in town.";  
			}
		}

		public AcceptConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new PotionObjective() );
		}
	}

	public class DeliverLetterToCeciliaConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                        return "<I><BASEFONT COLOR=#FFFF00>You hand the potion over to Ozzy and he begins to gulp down the entire bottle. After a few moments he begins to stretch out his arms feeling confident only to suddenly sigh in disbelief.</BASEFONT COLOR></I><BR><BR>Damn, that potion barely helped much. Well thanks for helping out but there's one more favor I need for you to do.<BR><BR><I><BASEFONT COLOR=#FFFF00>Ozzy hands you a letter sealed with an insignia in the shape of a fancy flower.</BASEFONT COLOR></I><BR><BR>Take this letter to Cecilia whose currently living in Elmhaven just west of here. Just take the dirt road and whatever you do don't go into the camp. I heard that the people there are not too friendly and they will act without hostily. Any way just tell Cecilia that I'm doing alright."; 			
                  }
		}

		public DeliverLetterToCeciliaConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new DeliverLetterToCeciliaObjective() );
		}
	}

	public class TalkToCeciliaConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                        return "<I><BASEFONT COLOR=#FFFF00>Upon arriving at the inn you notice a striking young elven lass with long braided hair.</BASEFONT COLOR></I><BR><BR>Have you heard from my beloved Ozzy yet?"; 			
			}
		}

		public TalkToCeciliaConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new GiveLetterToCeciliaObjective() );
		}
	}

	public class DeliverLetterToOzzyConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                        return "<I><BASEFONT COLOR=#FFFF00>You hand the sealed letter over to Cecilia and after opening it up using a small golden dagger begins to silently read it out to herself. After finishing the letter she lets out a sigh of relief.</BASEFONT COLOR></I><BR><BR>Damn, Oh thank the heavens above my dear old Ozzy is safe and well. So the battle over Hammerhill was indeed intense. Well I appreciate everything you've done so far young adventurer. I shall offer you a small reward before I present to you your next task.<BR><BR><I><BASEFONT COLOR=#FFFF00>Cecilia hands to you a different sealed letter.</BASEFONT COLOR></I><BR><BR>Please delivery this letter to Ozzy back in Hammerhill.";
			}
		}

		public DeliverLetterToOzzyConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new DeliverLetterToOzzyObjective() );
		}
	}

	public class EndConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                        return "<I><BASEFONT COLOR=#FFFF00>You tell Ozzy that Cecilia is doing alright back in Elmhaven. You then reach into your backpack for the letter and hand it over. Ozzy begins to read it over and slightly sheds a tear before leaping up for joy only to suddenly realize that he's still somewhat paralyzed due to his injuries.</BASEFONT COLOR></I><BR><BR>Goodness when will the pain ever go away? By the way I wanna thank you for everything you've done so far. Its quite a relief to hear that things are going smooth so far. As a token of my appreciate I shall present to you a small reward.<BR><BR><I><BASEFONT COLOR=#FFFF00>Ozzy reaches into his pockets and hands you a decent amount of gold.</BASEFONT COLOR></I><BR><BR>I'm sorry it isn't much but sadly its all I have. Wait just a moment I still have this.<BR><BR><I><BASEFONT COLOR=#FFFF00>Ozzy reaches even further into his pockets and produces a small gem.</BASEFONT COLOR></I><BR><BRTake this fire opal to the jeweler who's currently at the inn and they'll exchange it for gold. Now I must get some further rest until my injuries have begun to completely heal up";
			}
		}

		public EndConversation()
		{
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
	}

	public class DuringPotionConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "You can find the Magician's Corner just south of here. Its not hard to spot.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringPotionConversation()
		{
		}
	}

	public class DuringLetterToCeciliaConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Adventurer what are you waiting for? Hurry up and deliver that letter to Cecilia and please be respectful and not read it. Its kinda personal.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringLetterToCeciliaConversation()
		{
		}
	}

	public class DuringLetterToOzzyConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Well mate, have you heard from her? Has she given you anything?";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringLetterToOzzyConversation()
		{
		}
	}
}