using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Engines.Quests.SweetChildOfMine
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
				return "<I><BASEFONT COLOR=#FFFF00>Debbie ponders to herself at the realization that she's basically been told to piss off.</BASEFONT COLOR></I><BR><BR>I see.<BR><BR>I can only hope you'll stop and consider the path you're currently treading on and rethink your life decisions.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DeclineConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // groans!
			pm.PlaySound( 795 );
		}
	}

	public class AcceptConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>Relieved by your generousity, she informs you of the events that have transpired up to this point.</BASEFONT COLOR></I><BR><BR>While Coven's Landing was being invaded by goblin forces, our business establishment was looted and destroyed.<BR><BR>In fear for our child's life, my husband and I hid her in a beautiful pink metal chest.<BR><BR>But to our dismay, while fighting for our own lives, we were further ambushed by a horde of lizardfolk who ransacked the place, taking the chest along with anything they claimed would be fitting for their lord and master.<BR><BR>Without a moments hesitation, my husband took it upon himself to get her back by any means necessary. Should you return her to us unharmed, we will gladly reward you well beyond our poor wages can afford.<BR><BR>This is the only information he left behind before tracking them down.<BR><BR>He spoke of Iguana Cove, a land where the cold blooded gather and even the trees take root among its vast crevices. The fiends have placed the chest amongst their treasure chests, still unaware of the precious cargo within it.<BR><BR>Please find my husband Gary and help him get my baby back. May Eienyasil, the great divine offer you guidance through these decidant times.";
			}
		}

		public AcceptConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // sigh!
			pm.PlaySound( 816 );

			System.AddObjective( new GoToIguanaCoveObjective() );
		}
	}

	public class DuringGoToIguanaCoveConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Search the lands for the entrance to Iguana Cove.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringGoToIguanaCoveConversation()
		{
		}
	}

	public class TalkToGaryConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You approach a human man trying to break down the door.</BASEFONT COLOR></I><BR><BR>If you don't mind, I'm trying to get through, my child is in there! There's gotta be a key around here somewhere. Check all the crates, barrels and containers you can scavenge through.";			
			}
		}

		public TalkToGaryConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new FindKeyObjective() );
		}
	}

	public class DuringFindKeyConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>Gary looks at you with and is bewildered at your complacency.</BASEFONT COLOR></I><BR><BR>What in the nine hells of Tartarrix are you standing around for!? We need that key or else my kid is gonna wind up as food for these reptilian scoundrels!";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringFindKeyConversation()
		{
		}
	}

	public class HandKeyToGaryConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You hand the key over to Gary but due to sheer insanity, probably from being in this cave for too long, refuses and you suddenly realize the state of his physical and mental state.</BASEFONT COLOR></I>";			
			}
		}

		public HandKeyToGaryConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new RetrieveBabyObjective() );
		}
	}

	public class DuringRetrieveBabyConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "GO!";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringRetrieveBabyConversation()
		{
		}
	}

	public class RelievedGaryConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>Gary looks at you with and immediately grabs the baby from you.</BASEFONT COLOR></I><BR><BR>Oh thank goodness! She barely has a scratch on her.<BR><BR>Tell my wife we'll be home very shortly.";			
			}
		}

		public RelievedGaryConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new ReturnToDebbieObjective() );
		}
	}

	public class DuringReturnToDebbieConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Go on. There's one last thing I need to take of first before we finally leave.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringReturnToDebbieConversation()
		{
		}
	}

	public class EndConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You tell Debbie that the child is no longer in danger thanks to her husband.</BASEFONT COLOR></I><BR><BR>Oh blessings be upon yee.<BR><BR>Here take these. They were given to us from one of the auction lots. However it looks like our journeying days are finally over, so it'll probably be best you hold on to them.<BR><BR>Take care and praise the great divine.";
			}
		}

		public EndConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        Moongate gate = new Moongate( new Point3D( 1629, 1880, 5 ), Map.Malas ); // Skaddria Naddheim Bank
                        gate.Name = "Skaddria Naddheim Bank";
                        gate.MoveToWorld( pm.Location, pm.Map );
                        Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), new TimerCallback( gate.Delete ) );

                        // woohoo!
			pm.PlaySound( 0x5B8 ); // satyrpipe_use_well
			pm.PlaySound( pm.Female ? 783 : 1054 );
                        pm.Say( "Yahoo!" );

			pm.AddToBackpack( new Gold( 3500 ) );
			pm.AddToBackpack( new SkillSlotDeedQuestReward() );
			pm.AddToBackpack( new WeightIncreaseDeed() );

                        pm.Exp += 1000;
                        pm.KillExp += 1000;
                        pm.SendMessage("You've gained 1000 exp.");

                        if (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
                        {
                                Actions.DoLevel(pm, new Setup());
                        }

                        pm.TotalQuestsDone += 1;

			BaseJewel jewel = new RingOfMinorRevigoration();
			if ( Core.AOS )

			BaseRunicTool.ApplyAttributesTo( jewel, 2, 5, 10 );

                        jewel.Attributes.Luck = 200;
                        jewel.LootType = LootType.Blessed;

			pm.AddToBackpack( jewel );

			System.Complete();
		}
	}

	public class RecentlyFinishedConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "We will be forever honored by your eternal generousity. I think that's all we're gonna need for now. Really you've done enough that anymore would only be a hassle on your part. May the great divine watch over you.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public RecentlyFinishedConversation()
		{
		}
	}
}