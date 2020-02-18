using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Quests.KissOfTheSerpentMistress
{
	public class DeclineConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                        return "<I><BASEFONT COLOR=#FFFF00>You decide to wuss out of this one like the gizzard you are and Quill looks onward with total displeasure.<BR><BR><I><BASEFONT COLOR=#FFFF00>Well that settles it. I was indeed correct about your minimal fighting prowess. Perhaps this task is better suited for another time.";
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
				return "<I><BASEFONT COLOR=#FFFF00>You respond with a slight quip and Quill becomes envious towards you.</BASEFONT COLOR></I><BR><BR>Brilliant! I must say that I am indeed impressed with your confidence. Right, let me fill you in on the details.";  
			}
		}

		public AcceptConversation()
		{
		}

		public override void OnRead()
		{
			System.AddConversation( new StoryConversation() );
		}
	}

	public class StoryConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Chances are you might have heard of the Enslaver, whose currently residing over in what used to be Caravan Cove. Which of course has been taken over by various forces, all lead by the might and ferocity of Calcifina. Now here's part of the story that the locals never informed you of. Before she was ruling over them, she was originally my lover and quite the looker I must add. She was one of the few people out there that understood me in a way and several conversations later we decided to settle down together and open up this shop.<BR><BR>When our five year anniversary came around I decided to commemorate my love for her by fashioning together a unique bow. I figured it would be meaningful considering she's the reason why I wanted to become more skilled with archery. However everything changed that fateful night during a trip into Caravan Cove. Upon arrival we were quickly ambushed by orc swarms and before I could react I was knocked unconscious. I later woke up inside of a jail cell and standing outside was Calcifina, now been turned into a gorgon. She then spoke of how several orc forces needed a new leader to rule over this establishment and how she would make the perfect one.<BR><BR>But that's not even the whole story. She then proceeds into breaking me down emotionally about how we were never meant to be together and that our relationship was a complete lie. First I felt anger, then sadness started to settle in. Before I could scream out to her in protest I began to feel dizzy and it was then that I noticed the blow dart that hit my neck. I passed out yet again, this time to the sound of sinister laughter from a nearby orc. When I woke up I was surprised to find myself back inside of this building, only this time my lower body was completely paralyzed.<BR><BR>As time went on I eventually did manage to recover but I could never forget that moment of complete betrayal. I gave my entire life for her and she throws it all away like it was nothing. I never thought I would say this but I need you to do for me this one favor. Go into Caravan Cove over in the Autumnwood and take out Calcifina. Once finished, procure the bow from her corpse, and bring it to me.";				
			}
		}

		public StoryConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new SlayCalcifinaObjective() );
		}
	}

	public class CalcifinasJournalConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You approach Quill and hand her the journal. She begins to read over it, tears cascading down her face at the final outcome of her only soul mate.</BASEFONT COLOR></I><BR><BR>Gloria! My dear sweet love. Oh why must this happen to us? Never again will I bare witness to your elegant splendor and your tender finess.";  
			}
		}

		public CalcifinasJournalConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new ReturnBowObjective() );
		}
	}

	public class EndConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>Feeling some amount of guilt within your inner conscious, you hand the bow over to Quill.</BASEFONT COLOR></I><BR><BR>Blessings be onto you fellow traveler.<BR><BR><I><BASEFONT COLOR=#FFFF00>Quill then closes her attention onto the bow, deeply recalling all the plesant memories with Gloria.</BASEFONT COLOR></I><BR><BR>This bow was supposed to commemorate our five years of being together. Through perilous trials and smoldering hardships, we have demonstrated to the world our everlasting love for one another and how nothing would have separated us. Even unto the white blossom gardens of deaths doorsteps I would have stayed by your side.<BR><BR>Forgive me, my love. For this is something I can no longer possess, as it deserves an appropriate owner.<BR><BR><I><BASEFONT COLOR=#FFFF00>Focusing together her energy, Quill begins to insert some odd looking gems onto the bow before handing it over to you.</BASEFONT COLOR></I><BR><BR>I'm terribly sorry. But Gloria would have rather the bow be used by someone whose more adept at archery, and I am not worthy of such an honor. That being said, I was able to further enhance the bow after procuring enough crafting ingredients. Besides that bow is more suitable for someone such as yourself.<BR><BR>As for me, the only thing I can do is simply learn how to move on with my life.";
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
	}

	public class DuringSlayCalcifinaConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                        return "<I><BASEFONT COLOR=#FFFF00>You look over towards Quill.<BR><BR><I><BASEFONT COLOR=#FFFF00>Be careful.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringSlayCalcifinaConversation()
		{
		}
	}
}