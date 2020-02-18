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

	public class Arachnophobia : MLQuest
	{
		public Arachnophobia()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Arachnophobia";
			Description = "I've seen them hiding in their webs among the woods. Glassy eyes, spindly legs, poisonous fangs. Monsters, I say! Deadly horrors, these black widows. Someone must exterminate the abominations! If only I could find a worthy hero for such a task, then I could give them this considerable reward."; 
			RefusalMessage = "I hope you'll reconsider. Until then, farwell."; 
			InProgressMessage = "You've got a good start, but to stop the black-eyed fiends, you need to kill a dozen. You can find them over in Black Widow Pit. But for the love of Eienyasil be careful. Take a few cure potions just in case.";
			CompletionMessage = "Way to go fellow Almharian. That should put the scare back into those creepy-crawlies. EKK! WHAT WAS THAT! Oh, it was the wind. *cough* Where were we again, oh right. You like money, correct?";
			CompletionNotice = "You have slain the required black widows. Return to Alelle over in Tiki Tsundara for your reward.";

			Objectives.Add( new KillObjective( 12, new Type[] { typeof( GiantBlackWidow ) }, "giant black widows" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class SisterAct : MLQuest
	{
		public SisterAct()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Sister Act";
	                Description = "Spiders! Why did it have to be spiders! And not just any spiders. We're talking giant black widows laying dormant underneath the Oboru Jungle. They're lead by two sisters, Lady Lissith and Lady Sabrix. There's been rumors floating around that the two sisters were originally part of a traveling expedition into the pit for reasons even I don't quite remember. Regardless of the details, it was a stupid move wandering that deep into the caverns and low and behold they fell one by one to the ravenous creepy crawlies. Except for the sisters. Nah, the Arachnid Aerials had big plans in mind for those two. Gone is their memories of being human, now resulting in them cultivating ways of striking back at the surface dwellers for disturbing their eternal slumber. I need for you to go down there and put a stop to both of them before they start wrecking havoc upon not only the jungle, but to everything and everyone that lives on the Zaythalor continent. Is this something you can muster up the courage for.";
			RefusalMessage = "I figured you wouldn't be cut out for it. Can't say I blame you though. Arachniphobia is nothing to scoff at.";
			InProgressMessage = "If I were you, I'd pack a ton of high quality cure potions. These spiders do not mess around when it comes to dishing out the hurt juice.";
			CompletionMessage = "No way! You actually did it! By the great divine, I cannot believe this. Those scars all over your body are definitive proof that you've conquered those spiders and now that the sisters are gone, hopefully that'll be the end of anyone attempting to go through those caverns again. Here, this reward should be enough to satisfy you for everything you've done this evening.";
			CompletionNotice = "You have slain Lissith and Sabrix. Return to Roberto Sinatra over at Tiki Tsundara for your reward.";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( LadyLissith ) }, "Lady Lissith" ) );
			Objectives.Add( new KillObjective( 1, new Type[] { typeof( LadySabrix ) }, "Lady Sabrix" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class TarantulaTerror : MLQuest
	{
		public TarantulaTerror()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Tarantula Terror";
			Description = "Please excuse me, adventurer. I need you to intervene. We're winning the war, but it has come at a great cost. We're low on capable fighters to deal with the last remnants of our enemies, but we must rid the Oboru of all enemies. Hero, go out there and deal with those wretched yatsukahags. I cannot join you, for I have other tasks to attend to, but I know you don't need me anyway. Be strong and swift when fighting the yatsukahags. There's no need to kill all of them, just put the fear in them.";
			RefusalMessage = "The Oboru grows more perilious with each passing minute without your aid. Please I beg of you.";
			InProgressMessage = "It pains me to say I won't be able to reward you with a lot, but I'll do my best to make it worth your while. I'm looking forward to your return, hero. Good luck.";
			CompletionMessage = "By the gods, I knew you could pull it off. Allow me to compensate you for everything you've done so far.";
			CompletionNotice = "You have slain enough yatsukahags. Return to Keturah Chambers in Tiki Tsundara for your reward.";

			Objectives.Add( new KillObjective( 8, new Type[] { typeof( Yatsukahag ) }, "yatsukahags" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
		}
	}

	public class TPForMyBunghole : MLQuest
	{
		public TPForMyBunghole()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "TP For My Bunghole";
			Description = "I AM THE GREAT CORNHOLIO! I NEED TP FOR MY BUNGHOLE! BOW DOWN TO THE ALMIGHTY CORNHOLIO!";
			RefusalMessage = "ARE YOU THREATENING ME? MY BUNGHOLE WILL REIGN SUPREME! TACO SUPREME!";
			InProgressMessage = "UMMMMMMMM OKAY!";
			CompletionMessage = "HEH HEH HEH! UHHHHHHHHH THANKS! MY BUNGHOLE! ITS A GREAT BUNGHOLE!";
			CompletionNotice = "You have collected enough tee pee. Return to The Great Cornholio over at Tiki Tsundara for your reward.";

			Objectives.Add( new CollectObjective( 1, typeof( TeePee ), "tee pee" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	#endregion

	#region Mobiles

	[QuesterName( "Alelle (Tiki Tsundara)" )]
	public class Alelle : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074220, // May I call you friend?  I have a favor to beg of you.
				1074222 // Could I trouble you for some assistance?
			) );
		}

		[Constructable]
		public Alelle(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Alelle - (Arachnophobia)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new ElvenBoots( 0x1BB ) );

			Item item;

			item = new FemaleLeafChest();
			item.Hue = 0x3A;
			AddItem( item );

			item = new LeafLegs();
			item.Hue = 0x74C;
			AddItem( item );

			item = new LeafGloves();
			item.Hue = 0x1BB;
			AddItem( item );
		}

		public Alelle( Serial serial ): base( serial )
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

	[QuesterName( "RobertoSinatra (Tiki Tsundara)" )]
	public class RobertoSinatra : BaseCreature
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
		public RobertoSinatra(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Roberto Sinatra - (Sister Act)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33788;
                        HairItemID = 8252;
                        HairHue = 1109;
                        FacialHairItemID = 8255;
                        FacialHairHue = 1109;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Tactics, 60.0, 80.0 );

			AddItem( new Boots() );

			Item item;

			item = new RingmailArms();
			AddItem( item );

			item = new RingmailChest();
			AddItem( item );

			item = new RingmailGloves();
			AddItem( item );

			item = new RingmailLegs();
			AddItem( item );
		}

		public RobertoSinatra( Serial serial ): base( serial )
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

	[QuesterName( "KeturahChambers (Tiki Tsundara)" )]
	public class KeturahChambers : BaseCreature
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
		public KeturahChambers(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Keturah Chambers - (Tarantula Terror)";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33825;
                        HairItemID = 8261;
                        HairHue = 1102;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Tactics, 60.0, 80.0 );

			AddItem( new Bandana(918) );
			AddItem( new FancyShirt(918) );
			AddItem( new ShortPants(918) );
			AddItem( new ThighBoots(903) );

			Item item;

			item = new WoodenKiteShield();
			AddItem( item );
		}

		public KeturahChambers( Serial serial ): base( serial )
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

	[QuesterName( "TheGreatCornholio (Tiki Tsundara)" )]
	public class TheGreatCornholio : BaseCreature
	{
		public override bool InitialInnocent{ get{ return true; } }
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return false; } }

		[Constructable]
		public TheGreatCornholio(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "The Great Cornholio - (TP For My Bunghole)";
			BodyValue = 430;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 69, 69, 69 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );
		}

		public TheGreatCornholio( Serial serial ): base( serial )
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
