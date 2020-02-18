using System;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Engines.MLQuests.Objectives;
using Server.Engines.MLQuests.Rewards;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Engines.MLQuests.Definitions
{
	#region Quests

	public class AFineFeast : MLQuest
	{
		public AFineFeast()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "A Fine Feast";
			Description = "Mmm, I do love mutton!  It's slaughtering time again and my usual hirelings haven't turned up.  I've arranged for a butcher to come by and cut everything up but the basic sheep killing part I haven't gotten worked out yet.  Are you up for the task?";
			RefusalMessage = "Well, okay. But if you decide you are up for it after all, c'mon back and see me.";
			InProgressMessage = "You're gonna have to slay a few more sheep if you wanna be compensated!";
			CompletionMessage = "Woot baby. I knew you could do it. Of course I suppose you weren't keen on doing this for free. Alright, I'll cough up the dough and send you on your way.";
			CompletionNotice = "You have slain the required sheep. Return to Aulan in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( Sheep ) }, "sheep" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class AHeroInTheMaking : MLQuest
	{
		public AHeroInTheMaking()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "A Hero in the Making";
			Description = "Are you new around here? Well, nevermind that. You look ready for adventure, I can see the gleam of glory in your eyes! Nothing is more valiant, more noble, more praiseworthy than mongbat slaying.";
			RefusalMessage = "Quite monkey-ing around and help me out.";
			InProgressMessage = "Yeah! You're gonna need to slay a few more mongbats before I can properly reward you.";
			CompletionMessage = "I'll be damned. You actually did it. Then again.......... um where was I. Oh yes. Rightio! Please accept this reward as compensation for going out of your way towards accomplishing this task.";
			CompletionNotice = "You have slain the required mongbats. Return to Brinnae in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( Mongbat ) }, "mongbats" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class BakersDelight : MLQuest
	{
		public BakersDelight()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Bakers Delight";
			Description = "Please, traveler. Please, help me out. My family is coming over in 2 days and I want to make them my secret recipe pie, unfortunately I need a few more ingredients to make it. I need you to get me some flour, a couple of eggs, some elderberries, half a dozen strawberries and a bag of sugar. Oh this cake is going to be amazing! You can have a piece if you'd like. Fortunately I have enough left to reward you well if you decide to help me.";
			RefusalMessage = "That's okay, I suppose I can find someone else who'll help me gather those ingredients.";
			InProgressMessage = "You can pretty much find all the ingredients from bakers, cooks, ranchers and farmers.";
			CompletionMessage = "I'm afraid there's not much I can reward you with, but I think I can still make it worth the amount of trouble you've gone through in order to procure these items.";
			CompletionNotice = "You have gathered the right ingredient amount. Return to Aniel in Skaddria Naddheim for your reward.";

			Objectives.Add( new CollectObjective( 1, typeof( SackFlour ), "sack flour" ) );
			Objectives.Add( new CollectObjective( 2, typeof( Eggs ), "eggs" ) );
			Objectives.Add( new CollectObjective( 5, typeof( Elderberries ), "elderberries" ) );
			Objectives.Add( new CollectObjective( 6, typeof( Strawberry ), "strawberry" ) );
			Objectives.Add( new CollectObjective( 1, typeof( BagOfSugar ), "bag of sugar" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class BaroqueORama : MLQuest
	{
		public BaroqueORama()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Baroque O Rama";
			Description = "Salutations! I'm terribly sorry if my attention is elsewhere, but business around here has really picked up lately. My sister. It started with her promotion efforts, trekking across the lands with the expeditionary force, taking with her some of our hats. To my utter surprise, they become quite a hit among the ljosalfar people and soon enough more and more people have taken to wearing them to social gatherings. Especially during the annual Lugnasa that's tradition for the folks here in Skaddria Naddheim. Seriously I am flattered, and quite flabergasted all within the same breath! As a means of helping out my sister, I began taking special orders. My inflow of requests from various patrons is bursting to the brim, some of them truly outrageous and truly contagious. Don't suppose I'd be able to convince you to gather some of the materials needed for these festive hats. Will you?";
			RefusalMessage = "FUCK.........YOU!!!!!!";
			InProgressMessage = "Thank you for agreeing to help. Let's see, which order to work on first? This one shouldn't be too bad, although it's certainly not something I would wear. I'll never understand the bizarre trends sweeping Skaddria Naddheim, but they're good for business. Oh, dear, I'm rambling again. Anyway, the materials I need for this one are carapace from a faerie beetle collector and the wings of a verdant sprite. It's best if you don't ask what kind of headgear will result.";
			CompletionNotice = "You have collected enough materials. Return to Melanaha over in Skaddria Naddheim for your reward.";
			CompletionMessage = "They're perfect! Thanks you so very, very much for fetching these items. Allow me to aquaint you with some spare offerings to compensate you for your efforts. Don't forget to tip the spit bucket on the way out and be sure to check out our inventory from time to time!";

			Objectives.Add( new CollectObjective( 1, typeof( FaerieBeetleCarapace ), "faerie beetle carapace" ) );
			Objectives.Add( new CollectObjective( 1, typeof( VerdantSpriteWings ), "verdant sprite wings" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class BirdsOfAFeather : MLQuest
	{
		public BirdsOfAFeather()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Birds of a Feather";
			Description = "Yo dawg, I bet you can't kill ... ten harpies! I bet they're too much for you. You may as well confess you aren't up to snuff. Can't blame you, at this level you're probably don't have the skills or proper equipment needed to take out these bitch ass birds.";
			RefusalMessage = "Hahahaha! I knew you couldn't cut it! Get the fuck outta my face!";
			InProgressMessage = "Neegah, I know you ain't done! Get your ass back to work!";
			CompletionMessage = "Sheeeeeeeeeeeeeet! I gotta reward you now, don't I? Fuck!";
			CompletionNotice = "You have slain the required harpies. Return to Cailla in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( Harpy ) }, "harpies" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class BullfightingSortOf : MLQuest
	{
		public BullfightingSortOf()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Bullfighting ... Sort Of";
			Description = "You there! Yes, you.  Listen, I've got a little problem on my hands, but a brave, bold hero like yourself should find it a snap to solve.  Bottom line -- we need some of the bulls in the area culled.  You're welcome to any meat or hides, and of course, I'll give you a nice reward.";
			RefusalMessage = "Well, okay. But if you decide you are up for it after all, c'mon back and see me.";
			InProgressMessage = "You're gonna need to slaughter a few more bulls before I can compensate you!";
			CompletionMessage = "Well I'll be a son of a gun. Allow me to pass down some coinage for everything you've done so far.";
			CompletionNotice = "You have slain the required bulls. Return to Clehin in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( Bull ) }, "bulls" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
		}
	}

	public class CoconutCacophony : MLQuest
	{
		public CoconutCacophony()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Coconut Cacophony";
			Description = "'Excuse me, traveler. You've come at the right time. I need more coconuts, a whole lot more. They're amazing, I don't think there's anything you can't use a coconut for. You can eat their flesh, drink their juice, use them for lotions, use them for medicines, they can enhance beauty and much more. Please, gather me as much coconuts as you can find, I think I just came up with an amazing business idea.";
			RefusalMessage = "That's okay, I'm sure someone with more courage than either of us will come along eventually.";
			InProgressMessage = "I cannot thank you enough for your help, I'll make sure to reward you greatly once you return.";
			CompletionMessage = "Yay coconuts! Allow me to reward you for your efforts.";
			CompletionNotice = "You have gathered the appropriate amount of coconuts. Return to Tholef in Skaddria Naddheim for your reward.";

			Objectives.Add( new CollectObjective( 25, typeof( Coconut ), "coconut" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class CreepyCrawlies : MLQuest
	{
		public CreepyCrawlies()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Creepy Crawlies";
			Description = "Disgusting!  The way they scuttle on those hairy legs just makes me want to gag. I hate ogumo!  Rid the world of 5 and I'll find something nice to give you in thanks.";
			RefusalMessage = "Well, okay. But if you decide you are up for it after all, c'mon back and see me.";
			InProgressMessage = "EKK! WHAT WAS THAT! Oh, it was you. Um, you're not quite there at the moment. But we'll both know after the task at hand is finished.";
			CompletionMessage = "Mate I cannot congratulate you for getting rid of those furry nopes. Allow me to reward you. After all, you've helped out quite a lot.";
			CompletionNotice = "You have slain the required ogumos. Return to Rebinil in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 5, new Type[] { typeof( Ogumo ) }, "ogumos" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class EvilEye : MLQuest
	{
		public EvilEye()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Evil Eye";
			Description = "Kind traveler, hear my plea. You know of the evil orbs? The wrathful eyes? Some call them gazer larva? They must be a nest nearby, for they are tormenting us poor folk. We need to drive back their numbers. But we are not strong enough to face such horrors ourselves, we need a true hero.";
			RefusalMessage = "I hope you'll reconsider. Until then, farwell.";
			InProgressMessage = "Have you annihilated 5 Gazer Larvas yet, kind traveler?";
			CompletionMessage = "Yay you did it! Allow me to reward you for your efforts.";
			CompletionNotice = "You have slain the required gazer larva. Return to Mielan in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 5, new Type[] { typeof( GazerLarva ) }, "gazer larvas" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class FiftyShadesOfBlue : MLQuest
	{
		public FiftyShadesOfBlue()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Fifty Shades of Blue";
			Description = "Pardon me, hero. Please, help me out. There's this girl I like and I mean really like. I want to impress her, but I don't know how. Do you have any ideas? I know she likes flowers, especially the ivory rose, but it's rare and I haven't managed to find a single one yet. They're supposed to grow in Samson Swamplands nearby, but I'm beginning to think they're just a myth. Could you give the marsh one last look? It would mean the world to me! I had hoped I'd be able to reward you handsomely, but unfortunately I don't have a lot left.";
			RefusalMessage = "No No No! I really need those roses! You have no idea how much she means to me!";
			InProgressMessage = "Between you and me. If you really wanna put a permanent stop to those bog creepers, give 'em a good lickin. Literally. They'll go down in a heartbeat. Can't really say the same in regards to the allosaurai.";
			CompletionMessage = "Oh, thank you thank you thank you! Bethany my dear, prepare to meet your knight in shining armor. Here's your reward for having to dealing with those goddamn bog creepers.";
			CompletionNotice = "You have collected enough ivory roses. Return to Aluniol in Skaddria Naddheim for your reward.";

			Objectives.Add( new CollectObjective( 8, typeof( IvoryRose ), "ivory rose" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class FilthyPests : MLQuest
	{
		public FilthyPests()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Filthy Pests!";
			Description = "They're everywhere I tell you! They crawl over the rooftops, they scurry in the bushes. Disgusting critters. Say ... I don't suppose you're up for some grey squirrel killing? Grey squirrels now, not any other kind of squeaker will do.";
			RefusalMessage = "Oh come on! I beg of yah! PLEEEEEEEEEEAAAAASSSSSEEEEE!";
			InProgressMessage = "You can find them of course scattering about within Zaythalor Forest.";
			CompletionMessage = "By the gods, champ you did it. Here's your reward. Finally won't have to put up with any stupid rats. For the time being at least.";
			CompletionNotice = "You have slain enough grey squirrels. Return to Salaenih in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( GreySquirrel ) }, "grey squirrels" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class ForcedMigration : MLQuest
	{
		public ForcedMigration()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Forced Migration";
			Description = "Chirp chirp ... tweet chirp.  Tra la la. Bloody birds and their ass-blasted noise. Those sons of bitches, I've tried everything but they just won't stop that infernal clamor and I'm seconds away from chucking an explosion potion here and there in order to put a stop to all this ruckus. Return me to eternal silence and I'll make it worth your while.";
			RefusalMessage = "Ah bullshit! You gotta be kidding me?";
			InProgressMessage = "Blah Blah Blah! You ain't done and you bloody well know it!";
			CompletionMessage = "Yeah Yeah! I knew you had it in that rustic vessel of yours. Thank fucking Eienyasil because if you didn't I was planning on burning this whole city down to cinders. Yeah I know its a bit extreme. But you know us Ljosalfar and how we have sensitive ears. Not easy being among the daylight folk. I feel I was better off as a different race. Oh crud, I'm been rambling on and on that the reward I have for you isn't gonna compensate for how much time I've wasted on your services.";
			CompletionNotice = "You have slain enough birds. Return to Saril in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( Bird ) }, "birds" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class HartAttack : MLQuest
	{
		public HartAttack()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Hart Attack";
			Description = "Hey buddy. I'm in need of your assistance. I need more antlers, a whole lot more. You see, I use antlers in all of my decorating and I just build a new addition to my house, so I will have to do a whole lot of decorating. There are plenty of great harts in the forests around us, please gather their antlers for me. The deer meat will fill up my stocks nicely as well, wouldn't want to waste anything now, would we. I wish I could pay you far more than I can, but what I can pay isn't less than what's fair either.";
			RefusalMessage = "Fine, I'll get someone else to do it for me.";
			InProgressMessage = "You can find them pretty much in every forest. However you're more than likely gonna have to trigger them to approach you since normally they aren't standing around out in the open.";
			CompletionMessage = "Aha, see right there. Now that's chaos theory.";
			CompletionNotice = "You have collected enough deer parts. Return to Bolaevin in Skaddria Naddheim for your reward.";

			Objectives.Add( new CollectObjective( 12, typeof( RawGroundVenison ), "raw ground venison" ) );
			Objectives.Add( new CollectObjective( 12, typeof( RawVenisonRoast ), "raw venison roast" ) );
			Objectives.Add( new CollectObjective( 12, typeof( RawVenisonSteak ), "raw venison steak" ) );
			Objectives.Add( new CollectObjective( 12, typeof( DeerAntlers ), "deer antlers" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class KingOfFaerieBeetles : MLQuest
	{
		public KingOfFaerieBeetles()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "King of Faerie Beetles";
			Description = "A pity really.  With the balance of nature awry, we have no choice but to accept the responsibility of making it all right. It's all a part of the circle of life, after all. So, yes, the faerie beetle collectors are running rampant. There are far too many in the region. Will you shoulder your obligations as a more intelligent life form?";
			RefusalMessage = "Well, okay. But if you decide you are up for it after all, c'mon back and see me.";
			InProgressMessage = "What! By the gods mate, you ain't finished. You need to kill 10 faerie beetle collectors. You can find them over in Zaythalor Forest.";
			CompletionMessage = "Well would you look at that. I suppose I won't be needing these anymore.";
			CompletionNotice = "You have slain enough faerie beetle collectors. Return to Braen in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( FaerieBeetleCollector ) }, "faerie beetle collectors" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class NoGoodFishStealing : MLQuest
	{
		public NoGoodFishStealing()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "No Good, Fish Stealing ...";
			Description = "Mighty creatures they are, aye. Fierce and strong, can't blame 'em for wanting to feed themselves an' all. Blame or no, they're eating all the fish up, so they got to go. Lend a hand?";
			RefusalMessage = "Alright I suppose.";
			InProgressMessage = "NO! NO! NO! You ain't done yet!";
			CompletionMessage = "Way to go dood-bro-doodetteretto or doodetteretta or well....... just dood I guess. Here's a nice reward for all your troubles.";
			CompletionNotice = "You have slain enough water lizards. Return to Daelas in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( WaterLizard ) }, "water lizards" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class Overpopulation : MLQuest
	{
		public Overpopulation()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Overpopulation";
			Description = "I just can't bear it any longer. Sure, it's my job to thin the deer out so they don't overeat the area and starve themselves come winter time. Sure, I know we killed off the predators that would do this naturally so now we have to make up for it. But they're so graceful and innocent. I just can't do it. Will you?";
			RefusalMessage = "Well, okay. But if you decide you are up for it after all, c'mon back and see me.";
			InProgressMessage = "Um, yeah! There's still a few deer running loose. You can find them in most areas. Zaythalor Forest and the Autumnwood are your best bets.";
			CompletionMessage = "Thank goodness. You've done it. Allow me to reward you for all your troubles.";
			CompletionNotice = "You have slain enough hinds. Return to Jusae in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( Hind ) }, "hinds" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class Squishy : MLQuest
	{
		public Squishy()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Squishy";
			Description = "Have you ever seen what a green slime can do to good gear?  Well, it's not pretty, let me tell you!  If you take on my task to destroy twelve of them, bear that in mind. They'll corrode your equipment faster than anything.";
			RefusalMessage = "Well, okay I suppose.";
			InProgressMessage = "Hmm, I don't think you're quite done yet. You can find them scattered throughout Zaythalor Forest.";
			CompletionMessage = "Well would you look at that. Wait you're telling me these particular slime couldn't do that much damage to your gear? I'll be. Either you got lucky or I must have mistaken them for a different variety. Other than that, here's your reward after all you've gone through.";
			CompletionNotice = "You have slain enough green slimes. Return to Ciala in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 12, new Type[] { typeof( GreenSlime ) }, "green slimes" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class ThePerilsOfFarming : MLQuest
	{
		public ThePerilsOfFarming()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "The Perils of Farming";
			Description = "I should be trimming back the vegetation here, but something nasty has taken root. Viscious vines I can't go near. If there's any hope of getting things under control, some one's going to need to destroy a few of those Swamp Vines. Someone strong and fast and tough.";
			RefusalMessage = "Perhaps you'll change your mind and return at some point.";
			InProgressMessage = "How are farmers supposed to work with these Swamp Vines around?";
			CompletionMessage = "Getter-er-done! That's what I wanted to hear. I suppose I ain't gonna be need this no more.";
			CompletionNotice = "You have slain enough swamp vines. Return to Braen in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( SwampVine ) }, "swamp vines" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1000 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class TheyllEatAnything : MLQuest
	{
		public TheyllEatAnything()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "They'll Eat Anything";
			Description = "Pork is the fruit of the land! You can barbeque it, boil it, bake it, sautee it. There's pork kebabs, pork creole, pork gumbo, pan fried, deep fried, stir fried. There's apple pork, peppered pork, pork soup, pork salad, pork and potatoes, pork burger, pork sandwich, pork stew, pork chops, pork loins, shredded pork. So, lets get some piggies butchered!";
			RefusalMessage = "Come on its not that much.";
			InProgressMessage = "Oink Oink! You ain't done yet.";
			CompletionMessage = "Well that's enough of those stupid guards. Um, I mean pigs. No, really actual pigs. The kind that go oink oink. Speaking of bacon bits. This bag of good should do the trick.";
			CompletionNotice = "You have slain enough pigs. Return to Olaeni in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 20, new Type[] { typeof( Pig ) }, "pigs" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class TheyreBreedingLikeRabbits : MLQuest
	{
		public TheyreBreedingLikeRabbits()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "They're Breeding Like Rabbits";
			Description = "Aaaahhhh! They're everywhere! Aaaaahhh!  Ahem. Actually, friend, how do you feel about rabbits? Well, we're being overrun by them. We're finding fuzzy bunnies everywhere. Aaaaahhh!";
			RefusalMessage = "Alright. Fine.................................. S**T!";
			InProgressMessage = "EKK! Oh your not a rabbit. But you still gotta go after a few.";
			CompletionMessage = "Well would you look at that. I guess I won't need this anymore.";
			CompletionNotice = "You have slain enough rabbits. Return to Tamm in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 15, new Type[] { typeof( Rabbit ) }, "rabbits" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class ThinningTheHerd : MLQuest
	{
		public ThinningTheHerd()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Thinning the Herd";
			Description = "Psst! Hey ... psst! Listen, I need some help here but it's gotta be hush hush. I don't want THEM to know I'm onto them. They watch me. I've seen them, but they don't know that I know what I know. You know? Anyway, I need you to scare them off by killing a few of them. That'll send a clear message that I won't suffer goats watching me!";
			RefusalMessage = "Bah Humbug!";
			InProgressMessage = "You're not quite done yet. Get back to work!";
			CompletionMessage = "Oh you did it. Well I guess I gotta reward you or else you'll kick my ass. Here you go.";
			CompletionNotice = "You have slain enough goats. Return to Thallary in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 15, new Type[] { typeof( Goat ) }, "goats" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class VoraciousPlants : MLQuest
	{
		public VoraciousPlants()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Voracious Plants";
			Description = "I bet you can't tangle with those nasty plants ... say eighteen swamp vines! I bet they're too much for you. You may as well confess you can't ...";
			RefusalMessage = "Hahahaha! I knew it! Its too much for you. Teeheehee!";
			InProgressMessage = "Kek, you ain't done yet!";
			CompletionMessage = "Kewl! You want these? You can have 'em.";
			CompletionNotice = "You have slain enough swamp vines. Return to Vilo in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 18, new Type[] { typeof( SwampVine ) }, "swamp vines" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class WildBoarCull : MLQuest
	{
		public WildBoarCull()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Wild Boar Cull";
			Description = "A pity really. With the balance of nature awry, we have no choice but to accept the responsibility of making it all right. It's all a part of the circle of life, after all. So, yes, the boars are running rampant. There are far too many in the region. Will you shoulder your obligations as a higher life form?";
			RefusalMessage = "Well, okay. But if you decide you are up for it after all, c'mon back and see me.";
			InProgressMessage = "Buddy you're gonna need to slay a few more boars if you want that reward.";
			CompletionMessage = "Neato! You deserve this after all you've done so far.";
			CompletionNotice = "You have slain enough boars. Return to Waelian in Skaddria Naddheim for your reward.";

			Objectives.Add( new KillObjective( 16, new Type[] { typeof( Boar ) }, "boars" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
		}
	}

	#endregion

	#region Mobiles

	[QuesterName( "Aulan (Skaddria Naddheim)" )]
	public class Aulan : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public Aulan(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Aulan - (A Fine Feast)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			Item item;

			item = new ElvenBoots();
			item.Hue = Utility.RandomYellowHue();
			AddItem( item );

			AddItem( new ElvenPants( Utility.RandomGreenHue() ) );
			AddItem( new Cloak( Utility.RandomGreenHue() ) );
			AddItem( new Circlet() );

			item = new HideChest();
			item.Hue = Utility.RandomYellowHue();
			AddItem( item );

			item = new HideGloves();
			item.Hue = Utility.RandomYellowHue();
			AddItem( item );
		}

		public Aulan( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Brinnae (Skaddria Naddheim)" )]
	public class Brinnae : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		[Constructable]
		public Brinnae(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Brinnae - (A Hero in the Making)";
			Title = "the wise";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new ElvenBoots() );
			AddItem( new FemaleLeafChest() );
			AddItem( new LeafArms() );
			AddItem( new HidePants() );
			AddItem( new ElvenCompositeLongbow() );
		}

		public Brinnae( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Aniel (Skaddria Naddheim)" )]
	public class Aniel : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074220, // May I call you friend?  I have a favor to beg of you.
				1074222 // Could I trouble you for some assistance?
			) );
		}

		[Constructable]
		public Aniel(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Aniel - (Bakers Delight)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenPants( 0x901 ) );
			AddItem( new LeafChest() );
			AddItem( new HalfApron( Utility.RandomYellowHue() ) );
			AddItem( new ElvenBoots( 0x901 ) );
		}

		public Aniel( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Melanaha (Skaddria Naddheim)" )]
	public class Melanaha : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074207, // Good day to you friend! Allow me to offer you a fabulous opportunity!  Thrills and adventure await!
				1074209 // Hey, could you help me out with something?
			) );
		}

		[Constructable]
		public Melanaha(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Melanaha - (Baroque O Rama)";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33784;
                        HairItemID = 8252;
                        HairHue = 1109;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 59.5, 68.7 );
			SetSkill( SkillName.Alchemy, 64.0, 100.0 );
			SetSkill( SkillName.Herding, 60.0, 83.0 );
			SetSkill( SkillName.Tailoring, 61.0, 100.0 );
			SetSkill( SkillName.Tracking, 60.0, 83.0 );

			AddItem( new BaroqueMask( 93 ) );
			AddItem( new RegalCloak( 313 ) );
			AddItem( new TheaterDress( 168 ) );
			AddItem( new Obi( 238 ) );
			AddItem( new LightBoots( 23 ) );
		}

		public Melanaha( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Cailla (Skaddria Naddheim)" )]
	public class Cailla : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074187, // Want a job?
				1074210 // Hi.  Looking for something to do?
			) );
		}

		[Constructable]
		public Cailla(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Cailla - (Birds of a Feather)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenBoots() );
			AddItem( new HidePants() );
			AddItem( new HidePauldrons() );
			AddItem( new HideGloves() );
			AddItem( new WoodlandBelt() );
			AddItem( new RavenHelm() );
			AddItem( new HideFemaleChest() );
			AddItem( new MagicalShortbow() );
		}

		public Cailla( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Clehin (Skaddria Naddheim)" )]
	public class Clehin : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074211, // I could use some help.
				1074186 // Come here, I have a task.
			) );
		}

		[Constructable]
		public Clehin(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Clehin - (Bullfighting ... Sort Of)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenBoots() );
			AddItem( new ElvenShirt() );
			AddItem( new LeafTonlet() );
		}

		public Clehin( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Tholef (Skaddria Naddheim)" )]
	public class Tholef : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074209, // Hey, could you help me out with something?
				1074184 // Come here, I have work for you.
			) );
		}

		[Constructable]
		public Tholef(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Tholef - (Coconut Cacophony)";
			Title = "the grape tender";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Sandals( 0x901 ) );
			AddItem( new FullApron( 0x756 ) );
			AddItem( new ShortPants( 0x28C ) );
			AddItem( new Shirt( 0x28C ) );

			Item item;

			item = new LeafArms();
			item.Hue = 0x28C;
			AddItem( item );
		}

		public Tholef( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Rebinil (Skaddria Naddheim)" )]
	public class Rebinil : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		[Constructable]
		public Rebinil(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Rebinil - (Creepy Crawlies)";
			Title = "the healer";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new Sandals( 0x715 ) );
			AddItem( new ElvenRobe( 0x742 ) );
			AddItem( new RoyalCirclet() );
		}

		public Rebinil( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Mielan (Skaddria Naddheim)" )]
	public class Mielan : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074219, // Hello there, can I have a moment of your time?
				1074223 // Have you done it yet?  Oh, I haven’t told you, have I?
			) );
		}

		[Constructable]
		public Mielan(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Mielan - (Evil Eye)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenBoots( 0x901 ) );
			AddItem( new ElvenShirt( 0x56 ) );
			AddItem( new GemmedCirclet() );
			AddItem( new ElvenPants( 0x901 ) );
		}

		public Mielan( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Aluniol (Skaddria Naddheim)" )]
	public class Aluniol : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		[Constructable]
		public Aluniol(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Aluniol - (Fifty Shades of Blue)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new ElvenBoots( 0x1BB ) );
			AddItem( new ElvenRobe( 0x47E ) );
			AddItem( new WildStaff() );
		}

		public Aluniol( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Salaenih (Skaddria Naddheim)" )]
	public class Salaenih : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074207, // Good day to you friend! Allow me to offer you a fabulous opportunity!  Thrills and adventure await!
				1074209 // Hey, could you help me out with something?
			) );
		}

		[Constructable]
		public Salaenih(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Salaenih - (Filthy Pests)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenBoots() );
			AddItem( new WarCleaver() );

			Item item;

			item = new WoodlandBelt();
			item.Hue = 0x597;
			AddItem( item );

			item = new VultureHelm();
			item.Hue = 0x1BB;
			AddItem( item );

			item = new WoodlandLegs();
			item.Hue = 0x1BB;
			AddItem( item );

			item = new WoodlandChest();
			item.Hue = 0x1BB;
			AddItem( item );

			item = new WoodlandArms();
			item.Hue = 0x1BB;
			AddItem( item );
		}

		public Salaenih( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Saril (Skaddria Naddheim)" )]
	public class Saril : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074186, // Come here, I have a task.
				1074183 // You there! I have a job for you.
			) );
		}

		[Constructable]
		public Saril(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Saril - (Forced Migration)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenBoots() );
			AddItem( new WoodlandLegs() );
			AddItem( new WoodlandArms() );
			AddItem( new WoodlandBelt() );
			AddItem( new WingedHelm() );
			AddItem( new FemalePlateChest() );
			AddItem( new RadiantScimitar() );
		}

		public Saril( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Bolaevin (Skaddria Naddheim)" )]
	public class Bolaevin : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074186, // Come here, I have a task.
				1074183 // You there! I have a job for you.
			) );
		}

		[Constructable]
		public Bolaevin(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Bolaevin - (Hart Attack)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new ElvenBoots( 0x3B2 ) );
			AddItem( new RoyalCirclet() );
			AddItem( new LeafChest() );
			AddItem( new LeafArms() );

			Item item;

			item = new LeafLegs();
			item.Hue = 0x1BB;
			AddItem( item );
		}

		public Bolaevin( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Braen (Skaddria Naddheim)" )]
	public class Braen : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public Braen(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Braen - (King of Faerie Beetles)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Sandals( 0x714 ) );
			AddItem( new ElvenRobe( 0x64A ) );
			AddItem( new MagicWand() );
		}

		public Braen( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Daelas (Skaddria Naddheim)" )]
	public class Daelas : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, 1074187 ); // Want a job?
		}

		[Constructable]
		public Daelas(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Daelas - (No Good, Fish Stealing ...)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new ElvenBoots( 0x901 ) );
			AddItem( new ElvenPants( 0x8AB) );

			Item item;

			item = new LeafChest();
			item.Hue = 0x8B0;
			AddItem( item );

			item = new LeafGloves();
			item.Hue = 0x1BB;
			AddItem( item );
		}

		public Daelas( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Jusae (Skaddria Naddheim)" )]
	public class Jusae : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074210, // Hi.  Looking for something to do?
				1074213 // Hey buddy.  Looking for work?
			) );
		}

		[Constructable]
		public Jusae(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Jusae - (Overpopulation)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Sandals( 0x901 ) );
			AddItem( new ShortPants( 0x661 ) );
			AddItem( new MagicalShortbow() );

			Item item;

			item = new HideChest();
			item.Hue = 0x27B;
			AddItem( item );

			item = new HidePauldrons();
			item.Hue = 0x27E;
			AddItem( item );
		}

		public Jusae( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Ciala (Skaddria Naddheim)" )]
	public class Ciala : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074206, // Excuse me please traveler, might I have a little of your time?
				1074186 // Come here, I have a task.
			) );
		}

		[Constructable]
		public Ciala(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Ciala - (Squishy)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Skirt( Utility.RandomBlueHue() ) );
			AddItem( new ElvenShirt( Utility.RandomYellowHue() ) );
			AddItem( new RoyalCirclet() );

			if ( Utility.RandomBool() )
				AddItem( new Boots( Utility.RandomYellowHue() ) );
			else
				AddItem( new ThighBoots( Utility.RandomYellowHue() ) );
		}

		public Ciala( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Olaeni (Skaddria Naddheim)" )]
	public class Olaeni : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		[Constructable]
		public Olaeni(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Olaeni - (They'll Eat Anything)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new Shoes( 0x75A ) );
			AddItem( new ElvenRobe( 0x13 ) );
			AddItem( new MagicWand() );
			AddItem( new GemmedCirclet() );
		}

		public Olaeni( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Tamm (Skaddria Naddheim)" )]
	public class Tamm : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074213, // Hey buddy.  Looking for work?
				1074187 // Want a job?
			) );
		}

		[Constructable]
		public Tamm(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Tamm - (They're Breeding Like Rabbits)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenBoots() );
			AddItem( new HidePants() );
			AddItem( new HidePauldrons() );
			AddItem( new WingedHelm() );
			AddItem( new HideChest() );
			AddItem( new ElvenCompositeLongbow() );
		}

		public Tamm( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Thallary (Skaddria Naddheim)" )]
	public class Thallary : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074221, // Greetings!  I have a small task for you good traveler.
				1074212 // *yawn* You busy?
			) );
		}

		[Constructable]
		public Thallary(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Thallary - (Thinning the Herd)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Sandals( 0x901 ) );
			AddItem( new LongPants( 0x72E ) );
			AddItem( new Cloak( 0x3B3 ) );
			AddItem( new FancyShirt( 0x13 ) );
		}

		public Thallary( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Vilo (Skaddria Naddheim)" )]
	public class Vilo : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074210, // Hi.  Looking for something to do?
				1074220 // May I call you friend?  I have a favor to beg of you.
			) );
		}

		[Constructable]
		public Vilo(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Vilo - (Voracious Plants)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenBoots( 0x901 ) );
			AddItem( new OrnateAxe() );
			AddItem( new WoodlandBelt( 0x592 ) );
			AddItem( new VultureHelm() );
			AddItem( new WoodlandLegs() );
			AddItem( new WoodlandChest() );
			AddItem( new WoodlandArms() );
			AddItem( new WoodlandGorget() );
		}

		public Vilo( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	[QuesterName( "Waelian (Skaddria Naddheim)" )]
	public class Waelian : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074221, // Greetings!  I have a small task for you good traveler.
				1074201 // Waste not a minute! There’s work to be done.
			) );
		}

		[Constructable]
		public Waelian(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Waelian - (Wild Boar Cull)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Shoes( 0x901 ) );
			AddItem( new SmithHammer() );
			AddItem( new LongPants( 0x340 ) );
			AddItem( new GemmedCirclet() );

			Item item;

			item = new LeafChest();
			item.Hue = 0x344;
			AddItem( item );
		}

		public Waelian( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	#endregion
}
