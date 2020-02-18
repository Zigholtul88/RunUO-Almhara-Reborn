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

	public class AFlagForHammerhill : MLQuest
	{
		public AFlagForHammerhill()
		{
			Activated = true;
			Title = "A Flag for Hammerhill";
			Description = "Please kind Traveler,  could you assist me? I am nothing but a poor banner crafter for Hammerhill and I have run out of Worm Silk to finish making the banners. Can you help me. If you  bring me 12 Worm Silk, I will reward you with one of my banners.";
			RefusalMessage = "I suppose another there's always another time and day.";
			InProgressMessage = "You can find these Silk Worms around some of the farm areas, as they are good for plants, but if you attack them, they are a little pesky! When you kill the Silk Worm, use a knife and carve into the worm goo to get the Worm Silk.";
			CompletionNotice = "You have collected enough silk. Return to Ralph in Hammerhill for your reward.";
			CompletionMessage = "Thank you so much for helping me out. Take this banner as a sign of my appreciation. If you collect more silk, please feel free to drop it off! I can always use the resources.";

			Objectives.Add( new CollectObjective( 12, typeof( WormSilk ), "worm silk" ) );

			Rewards.Add( ItemReward.BannerBag );
		}
	}

	public class DeadManWalking : MLQuest
	{
		public DeadManWalking()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Dead Man Walking";
			Description = "Why?  I ask you why?  They walk around after they're put in the ground.  It's just wrong in so many ways. Put them to proper rest, I beg you.  I'll find some way to pay you for the kindness. Just kill five gualichu and five umkhovu over in Zaythalor Graveyard.";
			RefusalMessage = "Well, okay. But if you decide you are up for it after all, c'mon back and see me.";
			InProgressMessage = "*sniff* *sniff* You know what that smell is? That's the smell of you not finishing your task!";
			CompletionMessage = "Jillery Jipperru! Not bad for this go-around. Take your reward and if you excuse me, I got get back to church.";
			CompletionNotice = "You have slain the required undead. Return to Cloorne in Hammerhill for your reward.";

			Objectives.Add( new KillObjective( 5, new Type[] { typeof( Umkhovu ) }, "umkhovus" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( Gualichu ) }, "gualichus" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1000 );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
		}
	}

	public class DragonsDogma : MLQuest
	{
		public DragonsDogma()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Dragons Dogma";
			Description = "'Scuse me, adventurer. Your skills are required. Black Dragons have crept up in our lands. Reports of attacks are trickling in slowly, but we cannot afford to sit back idly. This could get out of control very quickly. Hero, seek them out and deal with those ugly creatures. I'm in no state to fight, but I know you'll manage without me. Tread carefully hero, only a fool would underestimate these creatures. You don't have to kill them all, just make sure they'll never return or at the very least not trouble Zaythalor Forest any longer.";
			RefusalMessage = "That's okay, I'm sure someone else could better manage the task at hand.";
			InProgressMessage = "I wish I had something better to reward you with, but what I have ain't too bad either. For justice and honor!";
			CompletionMessage = "Alright you did it. Allow me to reward you handsomely for your efforts in stopping those bastards.";
			CompletionNotice = "You have slain the required black dragons. Return to Landy in Hammerhill for your reward.";

			Objectives.Add( new KillObjective( 3, new Type[] { typeof( BlackDragon ) }, "black dragons" ) );

			Rewards.Add( new ItemReward( "Child's Wallet", typeof( ChildsWallet ) ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class FeeshTendees : MLQuest
	{
		public FeeshTendees()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Feesh Tendees";
			Description = "Dee udder dae I caot a yuge feesh. Et wuz enomus. And bi enomus I meen et wuz dae beegist feesh I've eva seen. It wuz probly duh beegist feesh anybody had eva and will eva cee. Uhfortunatly, afta I maniged to catch it, duh feesh goat awae. Et took muh feeshing raud wit et and I reely need et bak. Ey'd go and git et miiself, but et's undawater and E'm pritty shure dat feesh has a vindata aginst mi nawh. Wood u mind gitting et 4 mi?";
			RefusalMessage = "Whut dae foulk boodie! I cereailusly need mii feeshing roud bak!";
			InProgressMessage = "Tank u wry muc. Last teim I member bean wuz down by dae feeshing ponds ova en dee Aahtehmwood were sum stoopid sahagen jumped mii and tuuk mii feeshing roud. Gahd-damet, I whant mii feeshing roud bak.";
			CompletionNotice = "U haev retreeved da feeshing roud. Reeturn et 2 Cottoneye Job.";
			CompletionMessage = "Tank yeu wry muc. I appriciate evryting u've dun so farr. Howsa boot I rewauld you 4 all dee trobles.";

			Objectives.Add( new CollectObjective( 1, typeof( StupidFishingRod ), "stupid fishing rod" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class IndustriousAsAnAntLion : MLQuest
	{
		public IndustriousAsAnAntLion()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1073665; // Industrious as an Ant Lion
			Description = 1073704; // Ants are industrious and Lions are noble so who'd think an Ant Lion would be such a problem? The Ant Lion's have been causing mindless destruction in these parts. I suppose it's just how ants are. But I need you to help eliminate the infestation. Would you be willing to help for a bit of reward?
			RefusalMessage = 1073733; // Perhaps you'll change your mind and return at some point.
			InProgressMessage = 1073745; // Please, rid us of the Ant Lion infestation.

			Objectives.Add( new KillObjective( 12, new Type[] { typeof( LesserAntLion ) }, "lesser ant lions" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class ItsAGhastlyJob : MLQuest
	{
		public ItsAGhastlyJob()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "It's a Ghastly Job";
			Description = "Why? I ask you why? They walk around after they're put in the ground. It's just wrong in so many ways. Put them to proper rest, I beg you. I'll find some way to pay you for the kindness. Just kill twelve anchimayens.";
			RefusalMessage = "Well, okay. But if you decide you are up for it after all, c'mon back and see me.";
			InProgressMessage = "You're not quite done yet. There's still a few anchimayai running about!";
			CompletionMessage = "*sigh* That should be enough for a proper send off. Here ya go kiddo, you've earned it.";
			CompletionNotice = "You have slain enough anchimayai. Return to Tillanil in Hammerhill for your reward.";

			Objectives.Add( new KillObjective( 12, new Type[] { typeof( Anchimayen ) }, "anchimayai" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1000 );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
		}
	}

	public class LizardLinguistics : MLQuest
	{
		public LizardLinguistics()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "scitsiugniL draziL";
			Description = ".meht ot egamad hguone od lliw slliks ruoy erus m'I ,esruoc fo dedeen eb t'now lla meht gnilliK .sdrazil retaw eht htiw gnilaed nehw yltfiws tca ,oreH .yawyna pleh ym deen d'uoy tbuod I tuB .tonnac I yletanutrofnu tub ,nioj uoy dluoc I depoh dah I .sdrazil retaw ytsan esoht llik ot uoy deen I ,oreH .meht fo nezod a tuoba era ereht tub ,wef a ylno denoitnem stroper ehT .gnorw erew stroper eht diarfa m'I tub ,sdnal ruo ot taerht tnecer a htiw laed ot deredro neeb ev'I .ereh er'uoy dalg m'I .oreh ,esaelP";
			RefusalMessage = ".hctib a fo noS";
			InProgressMessage = ".uoy ni eveileb eW .oreh ,yenruoj efaS .selbuort ruoy htrow eb ll'ti ,ylemosdnah uoy yaper ot elba eb lliw I deeccus uoy dluohS";
			CompletionMessage = ".raf os enod ev'uoy gnihtyreve rof uoy etasnepmoc ot em wollA .ffo ti llup dluoc uoy wenk I ,sdog eht yB";
			CompletionNotice = ".drawer ruoy rof llihremmaH ni naM sdrawkcaB eht ot nruteR .sdrazil retaw hguone nials evah uoY";

			Objectives.Add( new KillObjective( 12, new Type[] { typeof( WaterLizard ) }, "sdrazil retaw" ) );

			Rewards.Add( ItemReward.deeDnoitelpmoCtseuQLM );
			Rewards.Add( ItemReward.BackwardsMLExperienceCheck1500 );
			Rewards.Add( ItemReward.erusaerTfOgaBegraL );
		}
	}

	public class MongbatMenace : MLQuest
	{
		public MongbatMenace()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Mongbat Menace!";
			Description = "I imagine you don't know about the mongbats. Well you may think you do, but I know more than just about anyone. You see they come in two varieties ... those on the surface...... and those found in a certain location. Either way, they're a menace. Exterminate five of each variety in Mongbat Hideout and I'll pay you an honest wage.";
			RefusalMessage = "Okay bobby-joe-larry-frank. I'll get someone else if I have to.";
			InProgressMessage = "You're not quite finished. And we damn well know it.";
			CompletionMessage = "Good job man-girl-thingymabob. Here's a hefty reward reward after going reverse gaia of the apes on their asses.";
			CompletionNotice = "You have slain enough mongbats on the list. Return to Unoelil in Hammerhill for your reward.";

			Objectives.Add( new KillObjective( 5, new Type[] { typeof( CavernMongbatArcher ) }, "cavern mongbat archers" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( CavernMongbatBerserker ) }, "cavern mongbat berserkers" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( CavernMongbatPlantkeeper ) }, "cavern mongbat plantkeepers" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( CavernMongbatRavager ) }, "cavern mongbat ravagers" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( CavernMongbatScout ) }, "cavern mongbat scouts" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( CavernMongbatShaman ) }, "cavern mongbat shamans" ) );

			Rewards.Add( new ItemReward( "Mage's Pouch", typeof( MagesPouch ) ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class RollTheBones : MLQuest
	{
		public RollTheBones()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Roll the Bones";
			Description = "Why? I ask you why? They walk around after they're put in the ground. It's just wrong in so many ways. Put them to proper rest, I beg you. I'll find some way to pay you for the kindness. Just kill eight gualichai.";
			RefusalMessage = "Well, okay. But if you decide you are up for it after all, c'mon back and see me.";
			InProgressMessage = "Sorry mate, but there's still running loose over in Zaythalor Graveyard.";
			CompletionMessage = "Oh rightio! Here's your reward.";
			CompletionNotice = "You have slain enough gualichai. Return to Cillitha in Hammerhill for your reward.";

			Objectives.Add( new KillObjective( 8, new Type[] { typeof( Gualichu ) }, "gualichai" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1000 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class SewerInAHalfShell : MLQuest
	{
		public SewerInAHalfShell()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Sewer In A Half Shell";
			Description = "Can't say I have much time to chat, but I'll fill you in on the details. Over the past week or so, people have been disappearing down in the sewers. Supposedly some sort of hydra has been stalking the place and has since then its accumulated a small cultish following consisting of blighted bovine, flatulating slime bubbles, and homeless gits drunk off of bum light. Yeah its pretty frigging crazy and I need to get the heck out of here before I'm next. That is, unless you want deal with the menace at hand.";
			RefusalMessage = "Right, well I'm getting out of here. You should probably do the same thing while you still have time.";
			InProgressMessage = "Don't say I didn't try to warn you ahead of time.";
			CompletionMessage = "Sweet, you made it back. Unfortunately we can't quite save any of those who're still succumbed to the sewers stench, but luckily that should be it for anyone else disappearing after this point. Looks like I'll be staying here in Hammerhill until I decide exactly where I would like to settle down. Perhaps I could book a few nights over at the local inn for the time being. As for your reward, take whatever you see fit. Godspeed on your travels and may the light of Eienyasil watch over you in times of turmoil and despair.";
			CompletionNotice = "You have slain the sewer hydra. Return to Trisha over in Hammerhill for your reward.";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( SewerHydra ) }, "sewer hydra" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	#endregion

	#region Mobiles

	[QuesterName( "Ralph (Hammerhill)" )]
	public class Ralph : BaseCreature
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
		public Ralph(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Ralph - (A Flag for Hammerhill)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 0x83F8;
			HairItemID = 0x203B;  
                        HairHue = 1175;	
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new FancyPants( 32 ) ); 
			AddItem( new ShortBoots( 32 ) );
			AddItem( new FancyShirt() );
			AddItem( new Bonnet( 32 ) );
		}

		public Ralph( Serial serial ): base( serial )
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

	[QuesterName( "Cloorne (Hammerhill)" )]
	public class Cloorne : BaseCreature
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
		public Cloorne(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Cloorne - (Dead Man Walking)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenBoots( 0x3B2 ) );
			AddItem( new RadiantScimitar() );
			AddItem( new WingedHelm() );

			Item item;

			item = new WoodlandLegs();
			item.Hue = 0x74A;
			AddItem( item );

			item = new HideChest();
			item.Hue = 0x726;
			AddItem( item );

			item = new LeafArms();
			item.Hue = 0x73E;
			AddItem( item );
		}

		public Cloorne( Serial serial ): base( serial )
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

	[QuesterName( "Landy (Hammerhill)" )]
	public class Landy : BaseCreature
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
		public Landy(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Landy - (Dragons Dogma)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Sandals( Utility.RandomYellowHue() ) );
			AddItem( new ShortPants( Utility.RandomYellowHue() ) );
			AddItem( new Tunic( Utility.RandomYellowHue() ) );

			Item gloves = new LeafGloves();
			gloves.Hue = Utility.RandomYellowHue();
			AddItem( gloves );
		}

		public Landy( Serial serial ): base( serial )
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

	[QuesterName( "Olla (Hammerhill)" )]
	public class Olla : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074187, // Want a job?
				1074185 // Hey you! Want to help me out?
			) );
		}

		[Constructable]
		public Olla(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Olla - (Industrious as an Ant Lion)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenBoots() );
			AddItem( new LongPants( 0x3B3 ) );
			AddItem( new SmithHammer() );
			AddItem( new FullApron( 0x1BB ) );
			AddItem( new ElvenShirt() );
		}

		public Olla( Serial serial ): base( serial )
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

	[QuesterName( "Tillanil (Hammerhill)" )]
	public class Tillanil : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074187, // Want a job?
				1074222 // Could I trouble you for some assistance?
			) );
		}

		[Constructable]
		public Tillanil(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Tillanil - (It's a Ghastly Job)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Sandals( 0x1BB ) );
			AddItem( new Tunic( 0x759 ) );
			AddItem( new ShortPants( 0x21 ) );
		}

		public Tillanil( Serial serial ): base( serial )
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

	[QuesterName( "BackwardsMan (Hammerhill)" )]
	public class BackwardsMan : BaseCreature
	{
		public override bool InitialInnocent{ get{ return true; } }
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return false; } }

		[Constructable]
		public BackwardsMan(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Backwards Man - (scitsiugniL draziL)";
			BodyValue = 430;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 69, 69, 69 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );
		}

		public BackwardsMan( Serial serial ): base( serial )
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

	[QuesterName( "Unoelil (Hammerhill)" )]
	public class Unoelil : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074186, // Come here, I have a task.
				1074209 // Hey, could you help me out with something?
			) );
		}

		[Constructable]
		public Unoelil(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Unoelil - (Mongbat Menace)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenBoots( 0x1BB ) );
			AddItem( new ShortPants( 0x1BB ) );
			AddItem( new Tunic( 0x64D ) );
		}

		public Unoelil( Serial serial ): base( serial )
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

	[QuesterName( "Cillitha (Hammerhill)" )]
	public class Cillitha : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074223, // Have you done it yet?  Oh, I haven’t told you, have I?
				1074213 // Hey buddy.  Looking for work?
			) );
		}

		[Constructable]
		public Cillitha(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Cillitha - (Roll the Bones)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenBoots( 0x901 ) );
			AddItem( new ElvenShirt( 0x731 ) );
			AddItem( new LeafLegs() );
		}

		public Cillitha( Serial serial ): base( serial )
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

	[QuesterName( "Trisha (Hammerhill)" )]
	public class Trisha : BaseCreature
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
		public Trisha(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Trisha - (Sewer In A Half Shell)";
			Race = Race.Human;
			BodyValue = 0x191;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new LightBoots( 0x3B2 ) );
			AddItem( new MedievalLongDress() );

			Item item;

			item = new SilverBracelet();
			item.Hue = 1102;
			AddItem( item );

			item = new SilverNecklace();
			item.Hue = 1102;
			AddItem( item );

			item = new SilverEarrings();
			item.Hue = 1102;
			AddItem( item );
		}

		public Trisha( Serial serial ): base( serial )
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

	[QuesterName( "Ahie (Hammerhill)" )]
	public class Ahie : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074206, // Excuse me please traveler, might I have a little of your time?
				1074203 // Hello friend. I realize you are busy but if you would be willing to render me a service I can assure you that you will be judiciously renumerated.
			) );
		}

		[Constructable]
		public Ahie(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Ahie - (The Perils of Farming)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Boots( 0x901 ) );
			AddItem( new Skirt( 0x1C ) );
			AddItem( new Cloak( 0x62 ) );
			AddItem( new FancyShirt( 0x738 ) );
		}

		public Ahie( Serial serial ): base( serial )
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

	[QuesterName( "CottoneyeJob (Hammerhill)" )]
	public class CottoneyeJob : BaseCreature
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
		public CottoneyeJob(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Cottoneye Job - (Feesh Tendees)";
			Direction = Direction.East;
			CantWalk = true;
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33770;
			HairItemID = 8251;  
                        HairHue = 1102;	
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 80.0, 100.0 );
			SetSkill( SkillName.Fishing, 70.0, 100.0 );
			SetSkill( SkillName.Wrestling, 85.5, 100.0 );

			AddItem( new Shirt( Utility.RandomRedHue() ) );
			AddItem( new LongPants( Utility.RandomBlueHue() ) );
			AddItem( new BodySash( Utility.RandomGreenHue() ) );
			AddItem( new HeavyBoots( Utility.RandomGreenHue() ) );
		}

		public CottoneyeJob( Serial serial ): base( serial )
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