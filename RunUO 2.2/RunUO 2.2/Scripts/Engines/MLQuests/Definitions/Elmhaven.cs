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

	public class ABigJob : MLQuest
	{
		public ABigJob()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "A Big Job";
			Description = "It's a big job but you look to be just the adventurer to do it! I'm so glad you came by ... I'm paying well for the death of five ogres and five ettins.";
			RefusalMessage = "Well, okay. But if you decide you are up for it after all, c'mon back and see me.";
			InProgressMessage = "You're gonna have to slay a few more giants if you wanna be compensated!";
			CompletionMessage = "Well done, friend. I knew you were capable of driving those bastards back. Take your reward as compensation. Thank you for your service.";
			CompletionNotice = "You have slain the required giants. Return to Alejaha in Elmhaven for your reward.";

			Objectives.Add( new KillObjective( 5, new Type[] { typeof( Ogre ) }, "ogres" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( Ettin ) }, "ettins" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
		}
	}

	public class ChampionHunt1 : MLQuest
	{
		public ChampionHunt1()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Champion Hunt 1";
			Description = "Before we begin I just need to remind you that this undertaking requires those who are moderately skilled in their fighting prowess. The Champion Hunt is a one per week event where players gather from around the world and seek out certain named monsters in order to conquer them. In addition to being very tough these champions also possess abilities not normally associated with their own kin. This particular challenge requires you to hunt down three champions. There's Kluckidile the gizzard, located somewhere withing Zaythalor Forest. Shadow Walker the pookah, located within the crystalline clusterfuck that is the Glimmerwood. Finally there's Taurion the minotaur located throughout the Autumnwood. The only advice I can give you is that despite their tough exterior these monsters possess little to no cold resistance.";
			RefusalMessage = "Perhaps its for the best you don't tackle this event for right now, at least until you're at a stronger level.";
			InProgressMessage = "Do not return to me until you've completed your objectives. Again these creatures stand little chance against the power of ice.";
			CompletionNotice = "You have slain all 3 champions. Return to Fharlune in Elmhaven to claim your reward.";
			CompletionMessage = "Ha, those champions may have proved to be worthy foes, but they were still no match against your might and bravery. I shall now bestow to you a decent bounty along with my prized bow. The journey involved in the systematic genocide of these feared beasts has only just begun. Seek out other champion hunters so they may task you with new objectives and bountiful loot.";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( Kluckidile ) }, "Kluckidile" ) );
			Objectives.Add( new KillObjective( 1, new Type[] { typeof( ShadowWalker ) }, "Shadow Walker" ) );
			Objectives.Add( new KillObjective( 1, new Type[] { typeof( Taurion ) }, "Taurion" ) );

			Rewards.Add( new ItemReward( "Gem Storage Pouch", typeof( GemStoragePouch ) ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.FharlunesBow );
		}
	}

	public class ClakkTrapp : MLQuest
	{
		public ClakkTrapp()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Clakk Trapp";
			Description = "Shalom, yah wee zittle shekelberg. Oui suppose yah couldn't allow me to fill yous in awn a few details in regards to a certain wee faerie beetle who'sa been causing a bit of a fuss around deez parts. Her name iz Clikk Clakk and she'sa a bit of a clap trap. Dat suneofabitch owes me gold after skipping out of her last mortage and I need for you to teach her a lesson. That meshuggeneh menace iz out of her friggin mind I say. Oy vey. If she's nout gunna pays up then wallop her tuchis. Nobody messes with Schlomo Shmattenstein.";
			RefusalMessage = "This is a shande upon all that's good and decent in this wurld.";
			InProgressMessage = "I'd love to schmooze, but I gotta shlep on over to the coffee shop over in Skaddria Naddheim for my 10 percent discount on........ hey wait a minute. That's for tomorrow. Got my schedule all mixed up.";
			CompletionMessage = "Sorry my goyim, I've been noshin on this chicken drumstick before I heard footsteps. As an honorable mensch I shall part ways with some of my belongings along with a few extra goodies. Now if you 'cuse me, I've gotsa meet up with my mishpocheh for the 5 'o clock bar mitzvah meteor shower. My bubbe's been egging me on about my previous failed marriage. Speaking of which, thanks for putting a dent on Clikk Clakk. Lord knows it'd be a shande if she continued to live another day without paying back me gold.";
			CompletionNotice = "Oy vey, you've slain Clikk Clakk. Return to Schlomo Shamttenstein over in Elmhaven for your reward ya putz.";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( ClikkClakk ) }, "Clikk Clakk" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
		}
	}

	public class CrabCatchers : MLQuest
	{
		public CrabCatchers()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Crab Catchers";
			Description = "I wish I could be more hospitable, but I'm a bit distracted. It seems I'm having a crab problem and I just don't know what to do. I've had attacks on my small flock of sheep lately. I was hoping that building a fence would solve the problem, but it hasn't helped at all. Then, one day when I was just about to step outside, I saw the culprits. A group of Sand Crabs was dragging away a sheep carcass. There's no way I can fight those ferocious crustaeceans off on my own. If you could thin the population a bit, they would probably leave the area. I'll tell you what. Kill six of the things, bring me their mandibles as proof, and I'll reward you well. Please, you're my only hope.";
			RefusalMessage = "Ah that sucks. I hope you reconsider next time you stop by.";
			InProgressMessage = "Damn crabs... going to run me out of Elmhaven at this rate. I don't know where those crabs came from, or why they picked my place to attack, but you must drive them away.";
			CompletionMessage = "I can't believe it. You actually did it! Well, I hope this will eventually drive them away. There may be a few stragglers, but I think this should do it. Now, how about that reward I promised? It's nice to go back to tending sheep without having to look over my shoulder.";
			CompletionNotice = "You have collected enough sand crab mandibles. Return to Diana McThornbody over in Elmhaven for your reward.";

			Objectives.Add( new CollectObjective( 6, typeof( SandCrabMandible ), "sand crab mandibles" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class ForkedTongues : MLQuest
	{
		public ForkedTongues()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Forked Tongues";
			Description = "You can't trust them, you know. Lizardmen I mean. They have forked tongues ... and you know what that means. Exterminate ten of them and I'll reward you.";
			RefusalMessage = "Please, please, it won't take that long.";
			InProgressMessage = "That's nice and all, but you still need to go after a few more before we can come to an final agreement.";
			CompletionMessage = "Thank you dude-lady-otherkin I appreciate what you've done. Here you go. You deserve it.";
			CompletionNotice = "You have slain enough lizardmen. Return to Lohn in Elmhaven for your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( Lizardman ) }, "lizardmen" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
		}
	}

	public class ImpishDelights : MLQuest
	{
		public ImpishDelights()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Impish Delights";
			Description = "Imps! Do you hear me? Imps! They're everywhere! They're in everything! Oh, don't be fooled by their size - they vicious little devils! Half-sized evil incarnate, they are! Somebody needs to send them back to where they came from, if you know what I mean.";
			RefusalMessage = "I hope you'll reconsider. Until then, farwell.";
			InProgressMessage = "Don't let the little devils scare you! You kill 4 imps - then we'll talk reward.";
			CompletionMessage = "Oui, goody goody goody! I suppose I won't be needing these anymore.";
			CompletionNotice = "You have slain enough imps. Return to Athailon in Elmhaven for your reward.";

			Objectives.Add( new KillObjective( 4, new Type[] { typeof( Imp ) }, "imps" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1000 );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
		}
	}

	public class JadeJungleJems : MLQuest
	{
		public JadeJungleJems()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Jade Jungle Jems";
			Description = "I see you've taken notice of the blue print, well its rather simple. Basically what I want to do is create a set of armor that helps in resisting poison damage, but it requires going into the Glimmerwood and hunting down the jade serpents that roam the area. I suppose it wouldn't be too much trouble if you could go in my stead?";
			RefusalMessage = "Oh come on, I could use the assistance. Oh fine then I suppose some other time would be best. Though I must say that by doing this for me I am promising you a nifty set of armor in exchange.";
			InProgressMessage = "Woot, woot, now that's what I'm talking about. Now where was I, oh yeah. Proceed into Jade Jungle and I believe I'll require at least 13 Serpentine Jades in order to complete this ringmail suit. Now I suppose there's no time like the present, so I would suggest that you get going. I've heard that the jade serpents, despite how most snakes embrace warm areas, these ones apparently don't take well to the element of fire.";
			CompletionNotice = "You have collected enough Serpentine Jade. Return to Filkien over in Elmhaven.";
			CompletionMessage = "There you are mate, some ringmail with added poison resistance. If you want me to make another one for you then come back tomorrow because right now I gotta tend to other business.";

			Objectives.Add( new CollectObjective( 13, typeof( SerpentineJade ), "serpentine jade" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SerpentineJadeRingmailGloves );
			Rewards.Add( ItemReward.SerpentineJadeRingmailLeggings );
			Rewards.Add( ItemReward.SerpentineJadeRingmailSleeves );
			Rewards.Add( ItemReward.SerpentineJadeRingmailTunic );
		}
	}

	public class LagartoLunancy : MLQuest
	{
		public LagartoLunancy()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Lagarto Lunancy";
			Description = "Por favor, heroe. Me alegro de que estes aqui. Me han ordenado lidiar con una amenaza reciente a nuestras tierras, pero me temo que los informes estaban equivocados. Los informes mencionan solo unos pocos, pero hay una docena de ellos. Heroe, necesito que matar a esos horribles hombres lagarto mas en Caleta Iguana. Esperaba que pudieras unirte, pero desafortunadamente no puedo. Pero dudo que necesites mi ayuda de todos modos. Heroe, actuar rapidamente cuando se trata con los hombres lagarto. Matarlos a todos no sera necesario, por supuesto, estoy seguro de que tus habilidades les haran suficiente dano.";
			RefusalMessage = "Hijo de puta.";
			InProgressMessage = "Si tienes exito podre pagarte generosamente, valdra la pena tus problemas. Buen viaje, heroe. Creemos en ti.";
			CompletionMessage = "Por los dioses, sabia que podias lograrlo. Permitame compensarle por todo lo que ha hecho hasta ahora.";
			CompletionNotice = "Que han matado a suficientes hombres lagarto. Regresa a Diego Martinez en Elmhaven por tu recompensa.";

			Objectives.Add( new KillObjective( 12, new Type[] { typeof( Lizardman ) }, "hombres lagarto" ) );

			Rewards.Add( ItemReward.SpanishMLQuestCompletionDeed );
			Rewards.Add( ItemReward.SpanishMLExperienceCheck1500 );
			Rewards.Add( ItemReward.GranBolsaDeBillones );
		}
	}

	public class OrcishElite : MLQuest
	{
		public OrcishElite()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Orcish Elite";
			Description = "Foul brutes! No one loves an orc, but some of them are worse than the rest. Their Captains and their Bombers, for instance, they're the worst of the lot. Kill a few of those, and the rest are just a rabble. Exterminate a few of them and you'll make the world a sunnier place, don't you know.";
			RefusalMessage = "I hope you'll reconsider. Until then, farwell.";
			InProgressMessage = "The only good orc is a dead orc - and 4 dead Captains and 6 dead Bombers is even better!"; 
			CompletionMessage = "Well would you look at that. I suppose I won't be needing this amount of dead weight. I got enough to last me for a good while.";
			CompletionNotice = "You have slain enough orcs on the list. Return to Sleen in Elmhaven for your reward.";

			Objectives.Add( new KillObjective( 6, new Type[] { typeof( OrcBomber ) }, "orc bombers" ) );
			Objectives.Add( new KillObjective( 4, new Type[] { typeof( OrcCaptain ) }, "orc captain" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class PuddleOfMud : MLQuest
	{
		public PuddleOfMud()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Puddle Of Mud";
			Description = "Please....... this is nothing to scoff at. Lurking about the wastelands dwells an oozing monstrocity that goes by the name Puddles. He's a particularly odd rascal among the green slimes and he's been nothing but trouble. I thought I could scare him off by leaving a bowl of cheese out during the night hours, but heaven forbid that's all he wanted. Now he's craving the taste of mortal flesh and I can't have him scaring off the Elmhaven residents. Explorer, I implore you to seek out this trouble maker and put a stop to his wild shenanigans before things around here start to grow more dire.";
			RefusalMessage = "Alright, I'll find someone else who can be more of an assistance.";
			InProgressMessage = "You must not let your guard down. This charlaton has a tendency of going after equipment more than its living targets.";
			CompletionMessage = "Then it is settled. I don't know what I could have done without you. Hopefully now that Puddles is gone, the tourism around these parts can start to slowly build back up. Take this bag along with these essentials, you have my upmost blessing. Take heed and bare your seed.";
			CompletionNotice = "You have slain Puddles. Return to Daryl Mclancaster over in Elmhaven for your reward.";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( Puddles ) }, "Puddles" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class RhinoRhombet : MLQuest
	{
		public RhinoRhombet()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Rhino Rhombet";
			Description = "Shut it, ya dobber. Au my bad, I'sa been acting like a bampot. Have yah 'eard of Rhinox? He's gallus, but a bit glaikit. A complete walloper whose nothing more than a hackit old bint. That jobbie is gunna be the death of me. Aye I'm working tae 5, scunnert wae it neebs and he's a sleekit basturt who needs a fair wallop or else that's gien me the boak.";
			RefusalMessage = "Aye, nae danger neebs, catch yo the morn.";
			InProgressMessage = "Wit even is your voice, ya weegie.";
			CompletionMessage = "Yaldi, I've neva been such a happy lil quine. Aye, here's yer ward. Take et. Soarri bout the tenner in that lecky. Wat dit minute. You're not related to me are you. Wit even is your voice, ya teuchter diddy.";
			CompletionNotice = "Yaldi, you've slain Rhinox. Return to Maevlan over awn Elmhaven yer mawkit.";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( Rhinox ) }, "Rhinox" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class SpiderwickChronicles : MLQuest
	{
		public SpiderwickChronicles()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Spiderwick Chronicles";
			Description = "Well hello there. Say, I noticed you could use a new cloak. I would be able to craft one for you using specialized silk obtained from a particular arachnid located within the Oboru Jungle, but I ran out of it. So I am going to require your help in procuring some. Do we have a deal?";
			RefusalMessage = "So you refuse to help me out. Perhaps its best saved for another time.";
			InProgressMessage = "Good, well then I suppose you may want to get going now. This cloak will require at least 12 strains of Oboru Spider Silk in order to complete. Now if you excuse me I need to work on this tunic for Cedric or else he's gonna tan my hide.";
			CompletionNotice = "You have collected enough brown silk. Return to Gilmona over in Elmhaven for your reward.";
			CompletionMessage = "Alrighty then, that's all finished. I suppose you have the.......... Oh! Now that's what I'm talking about. Right then, let me get started on this cloak for you. There, now its finished.";

			Objectives.Add( new CollectObjective( 12, typeof( OboruSpiderSilk ), "oboru spider silk" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.SpidersilkCloakOfProtection );
		}
	}

	public class TheGravefindersRepose : MLQuest
	{
		public TheGravefindersRepose()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "The Gravefinder's Repose";
			Description = "Thank goodness someone that can help is here. I don't know how to make this request any simpler, but to put it bluntly, Raelynn the Gravefinder must die. A few months ago, that witch of a Necromancer decided to inhabit Zaythalor Graveyard just south-east of this inn. I don't know what she does in there, frankly, I don't want to know. However, I do know that after she arrived, the woods at night became unsafe. I've seen undead of all types walking in the dark woods near the cave entrance. Now, this area's getting a bad reputation and my business has waned. Every day, it seems the number of undead increase. If someone can get into the graveyard and kill Raelynn, maybe we can stem the tide. Her death pays a handsome bounty. I hope you'll take advantage of the opportunity.";
			RefusalMessage = "Its unfortunate how selfish one can be during troubling times.";
			InProgressMessage = "Raelynn will finally get what's coming to her.";
			CompletionMessage = "I could use some good news right about now. I assume you've dealt with Raelynn appropriately. I realize it's in poor taste to celebrate anyone's demise, but Raelynn was evil through-and-through. You've done the right thing. I believe we had a contract. Here's my part. Thank you for saving my business, I won't forget it.";
			CompletionNotice = "You have slain Raelynn. Return to Audric over in Hammerhill for your reward.";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( Raelynn ) }, "Raelynn" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class TrollingForTrolls : MLQuest
	{
		public TrollingForTrolls()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Trolling for Trolls";
			Description = "They may not be bright, but they're incredibly destructive. Kill off ten trolls and I'll consider it a favor done for me.";
			RefusalMessage = "*sigh* Not again.";
			InProgressMessage = "You're not quite done yet. Just keep running around on the Island of Giants and they should eventually come to you.";
			CompletionMessage = "Yeah you did alright. Allow me to compensate you because lord knows there's hundreds of other people who'll probably do the same thing in my place.";
			CompletionNotice = "You have slain enough trolls. Return to Tyeelor in Elmhaven for your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( Troll ) }, "trolls" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class VollieBall : MLQuest
	{
		public VollieBall()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Vollie Ball";
			Description = "Arg, I'm so cheesed off. Nuthing more that codswallop. Say you look dishy if a bit daft. I wager its a tad fluke you were out and about looking for a bit of coin and you and you seemed somewhat snookered by what I have in store. I wouldn't take the biscuit if I was you. I here over on the beach that good ol Vollie is back in town and he's been squiffy after downing a few pints of Irish Spirit and has been causing quite a bit of a ruckus. Poor old chap hasn't been the same after doing a stretch in porridge after having hanky panky with some of the town locals without their permission. I'll haggle you a deal. Bludgeon that moppet and I'll provide the dosh. Easy peasy. What's say you?";
			RefusalMessage = "Sweet merciless bogard. I am completely gutted by your refusal to take upon my offer. Away with you, ya barmy arsehole.";
			InProgressMessage = "All right, we got a deal. Now smack that wee little dingleberry and drive his arse back into the bogs where he belongs.";
			CompletionMessage = "Either you're full of beans or you had a bit of a fluke. Very well, brave sir or madam. It is my honor to bestow to you these trinkets of considerable value. Though at this rate, its a bit nowt given what you've probably been up to. Hey now, don't be taking the biscuit. Consider yourself fortunate you've come this far. I suppose I better stop wafflin and see you on the way out. Toodle pip.";
			CompletionNotice = "Gallivanting with pride, you have slain Vollie. Return to Candice Crumpet over in Elmhaven for your reward. Her majesty will be most honored.";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( Vollie ) }, "Vollie" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	#endregion

	#region Mobiles

	[QuesterName( "Alejaha (Elmhaven)" )]
	public class Alejaha : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public Alejaha(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Alejaha - (A Big Job)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Sandals( Utility.RandomYellowHue() ) );
			AddItem( new ElvenShirt( Utility.RandomYellowHue() ) );
			AddItem( new GemmedCirclet() );
			AddItem( new Cloak( Utility.RandomYellowHue() ) );

			if ( Utility.RandomBool() )
				AddItem( new Kilt( 0x387 ) );
			else
				AddItem( new Skirt( 0x387 ) );
		}

		public Alejaha( Serial serial ): base( serial )
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

	[QuesterName( "FharluneCrimsonleaf (Elmhaven)" )]
	public class FharluneCrimsonleaf : BaseCreature
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
		public FharluneCrimsonleaf(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Fharlune Crimsonleaf - (Champion Hunt #1)";
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
                        Hue = 2405;
                        HairItemID = 12241;
                        HairHue = 81;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 100.0 );
			SetSkill( SkillName.Archery, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			PackItem( new Arrow( Utility.RandomMinMax( 50, 80 ) ) ); 

			StuddedBustierArms bustier = new StuddedBustierArms(); 
			bustier.Hue = 1160; 
			bustier.Movable = true; 
			AddItem( bustier ); 

			StuddedGloves gloves = new StuddedGloves(); 
			gloves.Hue = 1160; 
			gloves.Movable = true; 
			AddItem( gloves ); 

			RegalCloak cloak = new RegalCloak(); 
			cloak.Hue = 1162; 
			cloak.Movable = true; 
			AddItem( cloak ); 

			WoodlandBelt belt = new WoodlandBelt(); 
			belt.Hue = 1160; 
			belt.Movable = true; 
		        AddItem( belt ); 

			ThighBoots boots = new ThighBoots(); 
			boots.Hue = 1160; 
			boots.Movable = true; 
			AddItem( boots ); 
		}

		public FharluneCrimsonleaf( Serial serial ): base( serial )
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

	[QuesterName( "SchlomoShmattenstein (Elmhaven)" )]
	public class SchlomoShmattenstein : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074200, // Thank goodness you are here, there’s no time to lose.
				1074206 // Excuse me please traveler, might I have a little of your time?
			) );
		}

		[Constructable]
		public SchlomoShmattenstein(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Schlomo Shmattenstein - (Clakk Trapp)";
			Race = Race.Human;
			BodyValue = 0x190;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Tactics, 60.0, 80.0 );

			AddItem( new Bandana() );
                        AddItem( new Sandals() );
                        AddItem( new ShortPants() );
                        AddItem( new HalfApron(0x8AB) );
                        AddItem( new Doublet() );
		}

		public SchlomoShmattenstein( Serial serial ): base( serial )
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

	[QuesterName( "DianaMcThornbody (Elmhaven)" )]
	public class DianaMcThornbody : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074211, // I could use some help.
				1074218 // Hey!  I want to talk to you, now.
			) );
		}

		[Constructable]
		public DianaMcThornbody(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Diana McThornbody - (Crab Catchers)";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33784;
                        HairItemID = 8265;
                        HairHue = 41;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Tactics, 60.0, 80.0 );

			AddItem( new ThighBoots( 933 ) );

			Item item;

			item = new FemalePlateChest();
			AddItem( item );

			item = new LeatherSkirt();
			item.Hue = 1102;
			AddItem( item );

			item = new SilverEarrings();
			item.Hue = 933;
			AddItem( item );
		}

		public DianaMcThornbody( Serial serial ): base( serial )
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

	[QuesterName( "Lohn (Elmhaven)" )]
	public class Lohn : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074187, // Want a job?
				1074209 // Hey, could you help me out with something?
			) );
		}

		[Constructable]
		public Lohn(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Lohn - (Forked Tongues)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Shoes( 0x901 ) );
			AddItem( new LongPants( 0x359 ) );
			AddItem( new SmithHammer() );
			AddItem( new GemmedCirclet() );

			Item item;

			item = new LeafChest();
			item.Hue = 0x359;
			AddItem( item );
		}

		public Lohn( Serial serial ): base( serial )
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

	[QuesterName( "Athailon (Elmhaven)" )]
	public class Athailon : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074187, // Want a job?
				1074209 // Hey, could you help me out with something?
			) );
		}

		[Constructable]
		public Athailon(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Athailon - (Impish Delights)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new ElvenBoots( 0x901 ) );
			AddItem( new WoodlandBelt() );
			AddItem( new DiamondMace() );

			Item item;

			item = new WoodlandLegs();
			item.Hue = 0x3B2;
			AddItem( item );

			item = new FemalePlateChest();
			item.Hue = 0x3B2;
			AddItem( item );

			item = new WoodlandArms();
			item.Hue = 0x3B2;
			AddItem( item );

			item = new WingedHelm();
			item.Hue = 0x3B2;
			AddItem( item );
		}

		public Athailon( Serial serial ): base( serial )
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

	[QuesterName( "Filkien (Elmhaven)" )]
	public class Filkien : BaseCreature
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
		public Filkien(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Filkien - (Jade Jungle Jems)";
                 	Body = 605;
                        Female = false;
                        Race = Race.Elf;
                        Hue = 1024;
                        HairItemID = 12237;
                        HairHue = 16;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.ItemID, 64.0, 100.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			AddItem( new Cloak( 928 ) );
			AddItem( new FancyShirt( 723 ) );
			AddItem( new LongPants( 818 ) );
			AddItem( new Shoes( 803 ) );
		}

		public Filkien( Serial serial ): base( serial )
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

	[QuesterName( "DiegoMartinez (Elmhaven)" )]
	public class DiegoMartinez : BaseCreature
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
		public DiegoMartinez(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Diego Martinez - (Lagarto Lunancy)";
			Race = Race.Human;
			BodyValue = 400;
			Female = false;
                        Hue = 33809;
                        HairItemID = 8265;
                        HairHue = 1167;
                        FacialHairItemID = 8257;
                        FacialHairHue = 1167;
			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.ArmsLore, 64.0, 100.0 );

			Item item;

			item = new FancyTunic();
			AddItem( item );

			item = new FancyPants();
			AddItem( item );

			item = new PlateGloves();
			AddItem( item );

			item = new PlateGorget();
			AddItem( item );

			item = new HighBoots();
			AddItem( item );
		}

		public DiegoMartinez( Serial serial ): base( serial )
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

	[QuesterName( "Sleen (Elmhaven)" )]
	public class Sleen : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074200, // Thank goodness you are here, there’s no time to lose.
				1074206 // Excuse me please traveler, might I have a little of your time?
			) );
		}

		[Constructable]
		public Sleen(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Sleen - (Orcish Elite)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenBoots( 0x901 ) );
			AddItem( new SmithHammer() );
			AddItem( new Cloak( 0x75A ) );
			AddItem( new ElvenShirt() );
		}

		public Sleen( Serial serial ): base( serial )
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

	[QuesterName( "DarylMclancaster (Elmhaven)" )]
	public class DarylMclancaster : BaseCreature
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
		public DarylMclancaster(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Daryl Mclancaster - (Puddle Of Mud)";
			Race = Race.Human;
			BodyValue = 0x190;
			Female = false;
                        Hue = 0x83FF;			
                        HairItemID = 0x2044;
                        HairHue = 0x1;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

                        AddItem( new HeavyBoots( 0x901 ) );
                        AddItem( new Kilt( 0x901 ) );
                        AddItem( new Shirt( 0x901 ) );
                        AddItem( new Cap( 0x3B2 ) );
                        AddItem( new HalfApron( 0x28 ) );
		}

		public DarylMclancaster( Serial serial ): base( serial )
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

	[QuesterName( "Maevlan (Elmhaven)" )]
	public class Maevlan : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074185, // Hey you! Want to help me out?
				1074186 //Come here, I have a task.
			) );
		}

		[Constructable]
		public Maevlan(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Maevlan - (Rhino Rhombet)";
			Race = Race.Human;
			BodyValue = 0x191;
			Female = true;
                        Hue = 33825;
                        HairItemID = 8261;
                        HairHue = 43;
			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

                        AddItem( new LightBoots( 0x75B ) );
                        AddItem( new Tunic( 0x4BF ) );
                        AddItem( new Skirt( 0x8FD ) );
		}

		public Maevlan( Serial serial ): base( serial )
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

	[QuesterName( "Gilmona (Elmhaven)" )]
	public class Gilmona : BaseCreature
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
		public Gilmona(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Gilmona - (Spiderwick Chronicles)";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33807;
                        HairItemID = 8265;
                        HairHue = 1148;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 59.5, 68.7 );
			SetSkill( SkillName.Herding, 60.0, 83.0 );
			SetSkill( SkillName.Tailoring, 61.0, 100.0 );
			SetSkill( SkillName.Tracking, 60.0, 83.0 );

			AddItem( new NobleDress( 638 ) );
			AddItem( new Shoes( 728 ) );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 2430;
			gloves.Movable = true;
			AddItem( gloves );
		}

		public Gilmona( Serial serial ): base( serial )
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

	[QuesterName( "Audric (Hammerhill)" )]
	public class Audric : BaseCreature
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
		public Audric(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Audric - (The Gravefinder's Repose)";
			Race = Race.Human;
			BodyValue = 400;
			Female = false;
                        Hue = 33809;
                        HairItemID = 8260;
                        HairHue = 1102;
                        FacialHairItemID = 8257;
                        FacialHairHue = 1102;
			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.ArmsLore, 64.0, 100.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			Item item;

			item = new PlateArms();
			AddItem( item );

			item = new PlateChest();
			AddItem( item );

			item = new PlateGloves();
			AddItem( item );

			item = new PlateGorget();
			AddItem( item );

			item = new PlateLegs();
			AddItem( item );
		}

		public Audric( Serial serial ): base( serial )
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

	[QuesterName( "Tyeelor (Elmhaven)" )]
	public class Tyeelor : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074200, // Thank goodness you are here, there’s no time to lose.
				1074206 // Excuse me please traveler, might I have a little of your time?
			) );
		}

		[Constructable]
		public Tyeelor(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Tyeelor - (Trolling for Trolls)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new ElvenBoots( 0x1BB ) );

			Item item;

			item = new WoodlandLegs();
			item.Hue = 0x236;
			AddItem( item );

			item = new WoodlandChest();
			item.Hue = 0x236;
			AddItem( item );

			item = new WoodlandArms();
			item.Hue = 0x236;
			AddItem( item );

			item = new VultureHelm();
			item.Hue = 0x236;
			AddItem( item );

			item = new WoodlandBelt();
			item.Hue = 0x236;
			AddItem( item );
		}

		public Tyeelor( Serial serial ): base( serial )
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

	[QuesterName( "CandiceCrumpet (Elmhaven)" )]
	public class CandiceCrumpet : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074185, // Hey you! Want to help me out?
				1074186 //Come here, I have a task.
			) );
		}

		[Constructable]
		public CandiceCrumpet(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Candice Crumpet - (Vollie Ball)";
			Race = Race.Human;
			BodyValue = 0x191;
			Female = true;
			Hue = Race.RandomSkinHue();
			Utility.AssignRandomHair( this, true );

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

                        AddItem( new LightBoots() );
                        AddItem( new FancyDress( 0x8FD ) );
		}

		public CandiceCrumpet( Serial serial ): base( serial )
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
