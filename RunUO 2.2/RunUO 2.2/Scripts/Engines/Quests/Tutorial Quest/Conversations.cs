using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.AlmharaTutorial
{
	public class DeclineConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You decline the offer.</BASEFONT COLOR></I><BR><BR>Hey! That's alright! It looks like you already know the ropes!";
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
                                return "I'd figure you wouldn't say no to my request. Besides its information that'll really help out in the long run.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public AcceptConversation()
		{
		}

		public override void OnRead()
		{
			System.AddConversation( new GoToBankConversation() );
		}
	}

	public class GoToBankConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                                return "You're first objective will inform you on how the banking system operates within these realms. Once you've picked a race, if you're not happy with being a human or have selected a race not......... ummmm shall we say not appropriate for our setting, you can then choose one of several classes by heading through any of the moongates.<BR><BR>Regardless of what class you start out as your journey will immediately begin within the bustling reaches of Skaddria Naddheim. A settlement that has just about everything you'll need before truely heading out into the world.<BR><BR>Now, I don't think I need to remind you of what you need to do. Relax, mate! If it feels like you're hearing voices calling out to you, its just the telepathy working its wonderous magic.<BR><BR>Now get going. I'll instruct you further after you've chosen your class.";
			}

		}

		public override bool Logged{ get{ return false; } }

		public GoToBankConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new GoToBankObjective() );
		}
	}

	public class RadarConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                                return "Since you're leaving this area, you should learn about the Radar Map.<BR><BR>The Radar Map (or Overhead View) can be opened by pressing <I><BASEFONT COLOR=#0099FF>ALT-R</BASEFONT COLOR></I> on your keyboard. It shows your immediate surroundings from a bird's eye view.<BR><BR>Pressing <I><BASEFONT COLOR=#0099FF>ALT-R</BASEFONT COLOR></I> twice, will enlarge the Radar Map a little. Use the Radar Map often as you travel throughout the world to familiarize yourself with your surroundings.<BR><BR>Now get to the bank.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public RadarConversation()
		{
		}
	}

	public class BankInformationConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                            return "Let me tell you a bit about the banks in this world.<BR><BR>Anything that you place into any bank box, can be retrieved from any other bank box in the land. For instance, if you place an item into a bank box in, lets say here in Skaddria Naddheim, it can be retrieved from your bank box in Coven's Landing, Red Dagger Keep, or any other city and settlement that has its own bank.<BR><BR>Bank boxes are very secure. So secure, in fact, that no one can ever get into your bank box except for yourself. Security is hard to come by these days, but you can trust in the banking system that the Almharian realms has to offer! We shall not let you down!<BR><BR>I hope to be seeing much more of you as your riches grow! May your bank box overflow with the spoils of your adventures.<BR><BR>Farewell adventurer, you are now free to explore the world on your own.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public BankInformationConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // hey!
			pm.PlaySound( 1069 );

			System.AddConversation( new HowToMoveStuffAroundConversation() );
		}
	}

	public class HowToMoveStuffAroundConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
return "Testing! Testing! 1,2,3............ This is Tex calling in...........Great I got your attention. Now would be a good time to learn how to move items around.<BR><BR>To begin, select any item from either your paperdoll, backpack, or bankbox. Then <I><BASEFONT COLOR=#0099FF>single-click and drag</BASEFONT COLOR></I> the item over to your desired location. This can apply to either dumping the item on the ground to adding it to your backpack, or in the case of say clothing, weapons and others equippables to your paperdoll which will show up on your character model.<BR><BR>Now most items can be interacted with upon <I><BASEFONT COLOR=#0099FF>double-clicking</BASEFONT COLOR></I> them. Which based on the item can culminate into various results from say using a potion for different effects to using a bladed weapon to carve up corpses to even being able to read notes, books and other things worth interacting. Though be wary that not everything should be approached from this manner. Believe me you may find that out the hard way.<BR><BR>Another useful tip is being able to easily locate items sprinkled throughout the world map, and to do that just mash <I><BASEFONT COLOR=#0099FF>Shift+Ctrl</BASEFONT COLOR></I> and it'll make finding stuff lying about much, much less tedious and stressful on your part.<BR><BR>Now its time of me to tell you about needing to keep yourself well fed and fully hydrated.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public HowToMoveStuffAroundConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // *burp*
			pm.PlaySound( 1053 );

			System.AddConversation( new YouGottaEatConversation() );
		}
	}

	public class YouGottaEatConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                                return "You may have noticed some food and a pitcher of water from within your inventory. Well that's just something to help you out should thirst or hunger settles in. Whenever either of those things come about, using any of the forementioned items located on your person and you'll stave off both those ailments.<BR><BR>You can purchase food, water and other drinkables from various vendors. For food, many farms located throughout the world have crops full of veggies for anyone to take and the same can be said for any random consumables when found in other locations.<BR><BR>For your pitcher if you're looking to refill it, you can find water troughs lying about that upon using your pitcher and targeting the trough, it will automatically refill the pitcher to max capacity.<BR><BR>Now before we really let you set off upon the world, I'll inform on the next four topics: Vendors, Quest NPCs, Combat, and Environmental Hazards.<BR><BR>Lets begin.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public YouGottaEatConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // *hiccup*
			pm.PlaySound( 1070 );

			System.AddConversation( new VendorsConversation() );
		}
	}

	public class VendorsConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                                return "<BR><BR><I><BASEFONT COLOR=#0099FF>Vendors</BASEFONT COLOR></I><BR><BR>Throughout many towns, cities and other settlements are vendors where upon single-clicking their character model will bring up a list of options to either buy, sell or perhaps gain some useful insight into how they go about their evening or learn a bit about the world we currently inhabit.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public VendorsConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // ah!
			pm.PlaySound( 1049 );

			System.AddConversation( new QuestNPCsConversation() );
		}
	}

	public class QuestNPCsConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                                return "<BR><BR><I><BASEFONT COLOR=#0099FF>Quest NPCs</BASEFONT COLOR></I><BR><BR>Chances are you'll more than likely stumble upon a few as you go about your daily travels. What with there names being highlighted in yellow. Many of them are repeatable, though there are a few that can only be completed 1 time, and once you've started those particular types, if you decide to quit during the process you won't be able to restart it.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public QuestNPCsConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // *yells*
			pm.PlaySound( 1098 );

			System.AddConversation( new CombatConversation() );
		}
	}

	public class CombatConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
return "<BR><BR><I><BASEFONT COLOR=#0099FF>Combat</BASEFONT COLOR></I><BR><BR>This may or may not apply if you prefer a more pacifist route. But should you ever need to protect yourself, or if you've selected one of the many combat efficient classes, then allow me to further explain how it works.<BR><BR>If the targets name either highlights gray or red, it means that you're free to attack them without suffering any dire consequences from local authority.<BR><BR>From there if you prefer to engage the target with either sword, axe, or bow, upon your paperdoll toggle the warmode icon to highlight red and you'll go into a combat stance where upon double-clicking the target and depending on both your weapon and range you'll immediately begin attacking your target and they will fight back.<BR><BR>For spellcasters who'd rather use distance as an advantage, open your spellbook, select the spell, click+drag the icon onto your user interface, double-click the icon, and target your opponent. Depending on the spell this could result in many different effects, but either way it'll not only take up mana, but your reagents in the process. Which are required if you plan on fully sacrificing your efforts for such pursuits.";
			}

		}

		public override bool Logged{ get{ return false; } }

		public CombatConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // *gasp!*
			pm.PlaySound( 1065 );

			System.AddConversation( new EnvironmentalHazardsConversation() );
		}
	}

	public class EnvironmentalHazardsConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                                return "<BR><BR><I><BASEFONT COLOR=#0099FF>Environmental Hazards</BASEFONT COLOR></I><BR><BR>Before I forget, this is something I should really let you in on just so you don't accidently wander too far off into any dangerous regions.<BR><BR>No, I'm not joking.<BR><BR>There are indeed certain locations that without the proper equipment will result in total chaos. Or at least those could be said for some areas, which require wearing some outer piece of clothing like say a robe or trenchcoat for the Wintergrove region or a breathing apparatus for Seapray Solitude or any underwater environments.<BR><BR>However I can't say the same for any poisonous bogs or any active lava pools. Especially the lava pools. You don't wanna go anywhere near them.<BR><BR>Seriously they'll set you ablaze in no time. Just like on your miserable planet.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public EnvironmentalHazardsConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // yeah!
			pm.PlaySound( 1097 );

			System.AddConversation( new EndConversation() );
		}
	}

	public class EndConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
                                return "That should be everything you need to know.<BR><BR>Remember you got books located in your backpack that teach you just about everything you need to know about the class you've selected, what your starting skills are and how to actually use those skills.<BR><BR>Farewell and good luck on what's hoping to be one of many adventures to come your way.";
			}
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // woohoo!
			pm.PlaySound( pm.Female ? 783 : 1054 );
                        pm.Say( "Yahoo!" );

                        pm.Exp += 300;
                        pm.KillExp += 300;

                        if (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
                        {
                                Actions.DoLevel(pm, new Setup());
                                pm.Exp += 200;
                                pm.KillExp += 200;
                        }

                        pm.SendMessage("You've gained 200 exp.");

			pm.AddToBackpack( new Gold( 2000 ) );

			pm.AddToBackpack( new SkillSlotDeedQuestReward() );
			pm.AddToBackpack( new WeightIncreaseDeed() );

			System.Complete();
		}

		public EndConversation()
		{
		}
	}
}