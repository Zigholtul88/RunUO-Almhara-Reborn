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

	public class AndThanksForAllTheFish : MLQuest
	{
		public AndThanksForAllTheFish()
		{
			Activated = true;
			Title = "And Thanks For All The Fish";
			OneTimeOnly = true;
			Description = "I'm surrounded by cowards. We were robbed by a group of sand barracuda, they took all they could and killed most of those who tried to stop them. I did what I could, but if everybody helped we would've overpowered them easily. Hero, please get rid of those vulgar beings. You are fully capable to handle those beings. Try to kill all those who stand in your way, we don't need their filth in our lands.";
			RefusalMessage = "Oh come on! There's no telling what those sand barracuda are up too.";
			InProgressMessage = "I hope you're not looking for a big reward, but we'll still be able to reward you with somethind decent. I'm looking forward to your return, hero. Good luck.";
			CompletionNotice = "You have slain enough sand barracuda. Return to Hormell Jenkins over at Red Dagger Keep";
			CompletionMessage = "Finally! Never thought I would live to see this day. Here take this reward. I won't be needing it any time soon.";

			Objectives.Add( new KillObjective( 15, new Type[] { typeof( SandBarracuda ) }, "sand barracuda" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class DiversUpDeezNuts : MLQuest
	{
		public DiversUpDeezNuts()
		{
			Activated = true;
			Title = "Divers Up Deez Nuts";
			OneTimeOnly = true;
			Description = "Yo bitch ass neegah! I need yo help. Why won't deez mutherfuckas leave us alone? I ain't got nuttin to give, yet dae be coming back for more. Homie, please, I begs of you, get rid of those goddamn cliff divers or else I'm gonna have to choke a leaf-bitter. Pale ass, bitch ass ljosalfar. You ain't need to kill all of them. Just enough to fuck 'em over. What's say you, dawg? Yah feel me?";
			RefusalMessage = "Hey, hold up. I ain't gonna play dat. Now you get your ass back over here and help a homie out.";
			InProgressMessage = "Yo dawg, I appreciate it. I'll make sure to reward yah once you return.";
			CompletionNotice = "You have slain enough cliff divers. Return to Kenichi McCreary over at Red Dagger Keep";
			CompletionMessage = "Yo dawg, thanks for helping a homie out! I suppose I better give you this.";

			Objectives.Add( new KillObjective( 15, new Type[] { typeof( CliffDiver ) }, "cliff divers" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class DownWithTheSickness : MLQuest
	{
		public DownWithTheSickness()
		{
			Activated = true;
			Title = "Down With The Sickness";
			OneTimeOnly = true;
			Description = "Please, traveler. Your help would be much apprecited. My husband has fallen ill, he won't wake up no matter what I do. I believe we need to make him drink tea brewed from silverherb, but they only grow in the Farron Glades and I cannot leave my husband's side. Please, hero, gather a handful of silverherb as quick as you can. I wish I had something better to reward you with, but what I have ain't too bad either.";
			RefusalMessage = "Well that's just fucking fantastic! Leave my husband to wallow in his miserable state.";
			InProgressMessage = "You can reach the Farron Glades by passing through Cairn Forlorn in the Glimmerwood. That is if you have the fortress key. Luckily you can buy it. But I'm not exactly sure who sells it.";
			CompletionNotice = "You have procured enough silver herbs. Return to Sanyalonde over at Red Dagger Keep";
			CompletionMessage = "Oh bless you fellow adventurer for everything you've done so far. Take this reward as compensation.";

			Objectives.Add( new CollectObjective( 20, typeof( SilverHerb ), "silver herb" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class EggselentEndeavors : MLQuest
	{
		public EggselentEndeavors()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Eggselent Endeavors";
			Description = "Please excuse me, adventurer. I could really use your assistance. I'm all out of eggs. I know this is a silly thing to ask of you, but I need you to go out and collect me more eggs. Not just any eggs though, I need eggs of the pigmy crane of salazar. They're the perfect size for what I have planned, it's going to be amazing. Fortunately I have enough left to reward you well if you decide to help me.";
			RefusalMessage = "That's okay, I'm sure someone with more wit and cunning than either of us will come along eventually.";
			InProgressMessage = "The Pygmy Crane of Salazar currently resides over at Lake Mbuntu over in the Harashi Nabi.";
			CompletionNotice = "You have procured enough pygmy crane eggs. Return to Wiynoa over at Red Dagger Keep";
			CompletionMessage = "Sanctum Stercore, the crazy bastard actually did it. Take this reward and do whatever with it that your heart desires.";

			Objectives.Add( new CollectObjective( 10, typeof( PygmyCraneEggs ), "pygmy crane eggs" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class ElementalMyDearPatsee : MLQuest
	{
		public ElementalMyDearPatsee()
		{
			Activated = true;
			Title = "Elemental My Dear Patsee";
			OneTimeOnly = true;
			Description = "Pardon me, champion. Hear me out for a minute. The outer city have come under attack, I'm sure we'll be next to receive a beating by those brutes, but you might be able to stop those beastly beings. I won't be able to join you, but I have full confidence in you. I know you'll succeed. Be careful hero, don't underestimate those beings. You can kill as many of them as you wish, destroy all of them if you want, curse those lowlives.";
			RefusalMessage = "Fine, I'll find someone else who can complete the deed.";
			InProgressMessage = "Should you succeed I will be able to repay you handsomely, it'll be worth your troubles. Safe journey, hero. We believe in you.";
			CompletionNotice = "You have slain enough elementals. Return to Pedro Valentine over at Red Dagger Keep";
			CompletionMessage = "That should be the last of those elementals. Or at least the ones that were causing trouble. Here's your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( BronzeElemental ) }, "bronze elementals" ) );
			Objectives.Add( new KillObjective( 10, new Type[] { typeof( CopperElemental ) }, "copper elementals" ) );
			Objectives.Add( new KillObjective( 10, new Type[] { typeof( GoldenElemental ) }, "golden elementals" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class FireStarter : MLQuest
	{
		public FireStarter()
		{
			Activated = true;
			Title = "Fire Starter";
			OneTimeOnly = true;
			Description = "Pardon me, hero. I'm glad you're here. I'm sick and tired of living in fear. Fear of being robbed, fear of being killed and fear of any harm being done to those I love by those vicious lowlifes. Hero, please get rid of those dastardly charred sprites. Unfortunately I cannot join you, but I have faith in you, I know you'll succeed. Be warry hero, they're stronger than they look those faeries. You can take out as many of them as you like, the less of those lowlives there are in this world, the better.";
			RefusalMessage = "Alright, fine then. Doesn't look like you'd be much use anyway.";
			InProgressMessage = "I hope you're not looking for a big reward, but we'll still be able to reward you with somethind decent. I hope you return swiftly hero, we believe in you.";
			CompletionNotice = "You have slain enough charred sprites. Return to Alan Smith over at Red Dagger Keep";
			CompletionMessage = "Hopefully the activity of those charred sprites will die down now. Allow me to reward you on a job well done.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( CharredSprite ) }, "charred sprites" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class JubokkoJamberee : MLQuest
	{
		public JubokkoJamberee()
		{
			Activated = true;
			Title = "Jubokko Jamberee";
			OneTimeOnly = true;
			Description = "Great Caesars Scott, I need your help. Justice demands retribution and I will not take no for an answer. A group of jubokko killed some of my sheep and they've been nothing but trouble for the entire region. We will not allow them to go quietly in the night. I suppose it wouldn't trouble you if you could deal a good dent on their growing numbers? Your deeds will be spoken of throughout Red Dagger Keep.";
			RefusalMessage = "Inconceivable! I will not take no for an answer.";
			InProgressMessage = "I'm happy to say I'll be able to reward you handsomely for your troubles. You best get going, there's no time to waste. We're counting on you.";
			CompletionNotice = "You have slain enough jubokko. Return to Courtney Tripp over at Red Dagger Keep";
			CompletionMessage = "Thank you for helping me get rid of these accursed plants! Take this reward as a gratitude of generousity.";

			Objectives.Add( new KillObjective( 15, new Type[] { typeof( Jubokko ) }, "jubokko" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class OverwhelmingOdds : MLQuest
	{
		public OverwhelmingOdds()
		{
			Activated = true;
			Title = "Overwhelming Odds";
			OneTimeOnly = true;
			Description = "You there, traveler from Skaddria. Please, help me out. We're completely overwhelmed. The sand krakens have gotten more aggressive lately and more and more injured come into our hospital in search of aid, but we're running low in supplies. None of us can afford to leave the injured to seek out more supplies, so we need you to do so. Please gather Peaceblossom, sea urchin needles, petrified amber and glimmerwood honey. Do this, and I shall credit you where credit is due.";
			RefusalMessage = "That's okay, I'm sure someone with more courage than either of us will come along eventually.";
			InProgressMessage = "Peaceblossom can be found in Farron Glades. Sea Urchn Needles can be found in Seaspray Solitude. Petrified Amber can be found in Oboru Jungle. Glimmerwood Honey can be found in the Glimmerwood.";
			CompletionNotice = "You have procured enough items. Return to Nyaedulheen over at Red Dagger Keep";
			CompletionMessage = "Praise be to the Elysstian gods. You came back in one piece. I'll just take those off of your hands and send you on your way bearing a reward worthy of your efforts.";

			Objectives.Add( new CollectObjective( 10, typeof( PeaceBlossom ), "peace blossom" ) );
			Objectives.Add( new CollectObjective( 5, typeof( SeaUrchinNeedles ), "sea urchin needles" ) );
			Objectives.Add( new CollectObjective( 8, typeof( PetrifiedAmber ), "petrified amber" ) );
			Objectives.Add( new CollectObjective( 12, typeof( GlimmerwoodHoney ), "glimmerwood honey" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class RedDawn : MLQuest
	{
		public RedDawn()
		{
			Activated = true;
			Title = "Red Dawn";
			OneTimeOnly = true;
			Description = "Pardon me, hero. You're a sight for sore eyes. They're burning down everything! Everything.. everything is turning to ashes.. My family.. they even... Hero, I need you to avenge my family and get rid of those vile stingers. I don't think you'll have much troubles dealing with those redbark scorpions. You can kill as many of them as you wish, destroy all of them if you want, curse those lowlives.";
			RefusalMessage = "I see. Well I guess you're on your own then.";
			InProgressMessage = "I hope you're not looking for a big reward, but we'll still be able to reward you with somethind decent. Please succeed hero, we believe in you.";
			CompletionNotice = "You have slain enough redbark scorpions. Return to Tabitha Crainlad over at Red Dagger Keep";
			CompletionMessage = "Woot, woot! That should be the last of those ugly fucking reds.";

			Objectives.Add( new KillObjective( 15, new Type[] { typeof( RedbarkScorpion ) }, "red bark scorpions" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class SchittySchittyBangBang : MLQuest
	{
		public SchittySchittyBangBang()
		{
			Activated = true;
			Title = "Schitty Schitty Bang Bang";
			OneTimeOnly = true;
			Description = "Please excuse me, traveler. I need your help. Fifty years it has been, half a century since we secured our lands and we could live in peace. But now they're back and they're stronger than ever. Hero, we'll need your help to get rid of the spectral armour. My duties prevent me from going with you, but I doubt I'd be needed anyway. They'll be no match for you, those dwarves. If you can, kill as many of them as possible. We want to live in peace and safety..... and especially not having to deal with their constant rattling.";
			RefusalMessage = "Please, pretty please. They're really annoying.";
			InProgressMessage = "I hope you're not looking for a big reward, but we'll still be able to reward you with somethind decent. I'm looking forward to your return, hero. Good luck.";
			CompletionNotice = "You have slain enough spectral armours. Return to Irene Doland over at Red Dagger Keep";
			CompletionMessage = "Yay! Now I can finally rest easily without that constant banging. Here, you can have this.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( SpectralArmour ) }, "spectral armours" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class Them : MLQuest
	{
		public Them()
		{
			Activated = true;
			Title = "Them";
			OneTimeOnly = true;
			Description = "Oui! Excuse me, mate. Would you lend yee a hand with a particular task at hand? Years have passed since the bullet ants settled within the Harashi Nabi and its starting to get really out of hand. There's too many of them which has resulted in the area becoming quite hazardous towards those who wander too close to them. I need for you to clear out a few of their numbers by all means necessary.";
			RefusalMessage = "Please, we gotta stop those bullet ants before things get even more hectic.";
			InProgressMessage = "It pains me to say I won't be able to reward you with a lot, but I'll do my best to make it worth your while. I'm looking forward to your return, guardian. Good luck.";
			CompletionNotice = "You have slain enough bullet ants. Return to Carol Branston over at Red Dagger Keep";
			CompletionMessage = "I appreciate all you've done so far. Please, allow me to compensate you on a job well done.";

			Objectives.Add( new KillObjective( 20, new Type[] { typeof( BulletAnt ) }, "bullet ants" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	#endregion

	#region Mobiles

	[QuesterName( "Hormell Jenkins (Red Dagger Keep)" )]
	public class HormellJenkins : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074209, // Hey, could you help me out with something?
				1074222 // Could I trouble you for some assistance?
			) );
		}

		[Constructable]
		public HormellJenkins(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Hormell Jenkins - (And Thanks For All The Fish)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33822;
                        HairItemID = 8260;
                        HairHue = 1116;
                        FacialHairItemID = 8269;
                        FacialHairHue = 1116;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Shirt(768) );
			AddItem( new HalfApron(753) );
			AddItem( new ShortPants(463) );
			AddItem( new HeavyBoots(993) );
		}

		public HormellJenkins( Serial serial ): base( serial )
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

	[QuesterName( "Kenichi McCreary (Red Dagger Keep)" )]
	public class KenichiMcCreary : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074209, // Hey, could you help me out with something?
				1074222 // Could I trouble you for some assistance?
			) );
		}

		[Constructable]
		public KenichiMcCreary(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Kenichi McCreary - (Divers Up Deez Nuts)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33798;
                        HairItemID = 8251;
                        HairHue = 1148;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new FancyShirt(603) );
			AddItem( new LongPants(603) );
			AddItem( new Shoes(993) );
		}

		public KenichiMcCreary( Serial serial ): base( serial )
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

	[QuesterName( "Sanyalonde (Red Dagger Keep)" )]
	public class Sanyalonde : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074209, // Hey, could you help me out with something?
				1074222 // Could I trouble you for some assistance?
			) );
		}

		[Constructable]
		public Sanyalonde(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Sanyalonde - (Down With The Sickness)";
			Title = "the grieving wife";
			Race = Race.Human;
			BodyValue = 401;
			Female = true;
			Hue = 33770;
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new LightBoots( 0x901 ) );
			AddItem( new RegalCloak( 0x756 ) );
			AddItem( new Skirt( 0x28C ) );
			AddItem( new Shirt( 0x28C ) );

			Item item;

			item = new LeafArms();
			item.Hue = 0x28C;
			AddItem( item );
		}

		public Sanyalonde( Serial serial ): base( serial )
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

	[QuesterName( "Wiynoa (Red Dagger Keep)" )]
	public class Wiynoa : BaseCreature
	{
		public override bool InitialInnocent{ get{ return true; } }
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
		public Wiynoa(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Wiynoa - (Eggselent Endeavors)";
			Body = 0x15;
			Hue = 2966;
			BaseSoundID = 644;

			Female = true;
			InitStats( 69, 69, 69 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );
		}

		public Wiynoa( Serial serial ): base( serial )
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

	[QuesterName( "Pedro Valentine (Red Dagger Keep)" )]
	public class PedroValentine : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074209, // Hey, could you help me out with something?
				1074222 // Could I trouble you for some assistance?
			) );
		}

		[Constructable]
		public PedroValentine(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Pedro Valentine - (Elemental My Dear Patsee)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33824;
                        HairItemID = 8264;
                        HairHue = 1149;
                        FacialHairItemID = 8255;
                        FacialHairHue = 1149;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ShortBoots(868) );
			AddItem( new ReinassancePants(648) );

			StuddedChest chest = new StuddedChest();
			chest.Movable = true;
                        chest.Hue = 2419;
			AddItem( chest );

			StuddedGloves gloves = new StuddedGloves();
			gloves.Movable = true;
                        gloves.Hue = 2419;
			AddItem( gloves );
		}

		public PedroValentine( Serial serial ): base( serial )
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

	[QuesterName( "Alan Smith (Red Dagger Keep)" )]
	public class AlanSmith : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074209, // Hey, could you help me out with something?
				1074222 // Could I trouble you for some assistance?
			) );
		}

		[Constructable]
		public AlanSmith(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Alan Smith - (Fire Starter)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33800;
                        HairItemID = 8253;
                        HairHue = 1122;
                        FacialHairItemID = 8256;
                        FacialHairHue = 1122;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Doublet(366) );
			AddItem( new ReinassancePants(377) );
			AddItem( new ShortBoots(391) );
		}

		public AlanSmith( Serial serial ): base( serial )
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

	[QuesterName( "Courtney Tripp (Red Dagger Keep)" )]
	public class CourtneyTripp : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074209, // Hey, could you help me out with something?
				1074222 // Could I trouble you for some assistance?
			) );
		}

		[Constructable]
		public CourtneyTripp(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Courtney Tripp - (Jubokko Jamberee)";
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
                        Hue = 1017;
                        HairItemID = 12241;
                        HairHue = 2423;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ReinassanceShirt(0) );
			AddItem( new BodySash(0) );
			AddItem( new LeatherPants(0) );
			AddItem( new HeavyBoots(0) );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 1013;
			gloves.Movable = true;
			AddItem( gloves );
		}

		public CourtneyTripp( Serial serial ): base( serial )
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

	[QuesterName( "Nyaedulheen (Red Dagger Keep)" )]
	public class Nyaedulheen : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074197, // Pardon me, but if you could spare some time I’d greatly appreciate it.
				1074204 // Greetings seeker.  I have an urgent matter for you, if you are willing.
			) );
		}

		[Constructable]
		public Nyaedulheen(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Nyaedulheen - (Overwhelming Odds)";
			Title = "the troubled healer";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Sandals() );
			AddItem( new NocturnalDress() );
			AddItem( new GemmedCirclet() );
		}

		public Nyaedulheen( Serial serial ): base( serial )
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

	[QuesterName( "Tabitha Crainlad (Red Dagger Keep)" )]
	public class TabithaCrainlad : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074209, // Hey, could you help me out with something?
				1074222 // Could I trouble you for some assistance?
			) );
		}

		[Constructable]
		public TabithaCrainlad(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Tabitha Crainlad - (Red Dawn)";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33825;
                        HairItemID = 8252;
                        HairHue = 81;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Bandana(568) );
			AddItem( new Cloak(568) );
			AddItem( new Doublet(568) );
			AddItem( new FormalDress(353) );
			AddItem( new ShortBoots(353) );
		}

		public TabithaCrainlad( Serial serial ): base( serial )
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

	[QuesterName( "Irene Doland (Red Dagger Keep)" )]
	public class IreneDoland : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074209, // Hey, could you help me out with something?
				1074222 // Could I trouble you for some assistance?
			) );
		}

		[Constructable]
		public IreneDoland(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Irene Doland - (Schitty Schitty Bang Bang)";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33791;
                        HairItemID = 8252;
                        HairHue = 44;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new WideBrimHat(563) );
			AddItem( new FormalDress(663) );
			AddItem( new Shoes(563) );
		}

		public IreneDoland( Serial serial ): base( serial )
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

	[QuesterName( "Carol Branston (Red Dagger Keep)" )]
	public class CarolBranston : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074209, // Hey, could you help me out with something?
				1074222 // Could I trouble you for some assistance?
			) );
		}

		[Constructable]
		public CarolBranston(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Carol Branston - (Them)";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33805;
                        HairItemID = 8263;
                        HairHue = 1141;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Cloak(973) );
			AddItem( new FancyShirt(813) );
			AddItem( new Skirt(813) );
			AddItem( new LightBoots(973) );
		}

		public CarolBranston( Serial serial ): base( serial )
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