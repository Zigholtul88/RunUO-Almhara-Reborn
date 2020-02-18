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

	public class FightingSpiritPartOne : MLQuest
	{
		public override Type NextQuest { get { return typeof( FightingSpiritPartTwo ); } }

		public FightingSpiritPartOne()
		{
			Activated = true;
			Title = "Fighting Spirit Part 1";
			Description = "Greetings young adventurer. I am here to help you test your combat skills. I see you are prepared to begin your combat training. So let us begin.<BR><BR>Please know, that you will be tested against some very tough creatures. However, should you prevail, you shall be rewarded with some items to help you begin your journey through this life within Almhara.<BR><BR>You will be tested against some various creatures, and they will only increase in difficulty with each new task.<BR><BR>To begin, slay for me a Diseased Rat and you shall be rewarded, as well as given additional instructions to further your training.<BR><BR>I wish you well in your quest.<BR><BR>Now go young adventurer, and slay a Diseased Rat!";
			RefusalMessage = "I understand you having second thoughts. Very well. Return to me when you are ready for your training!";
			CompletionNotice = "You have slain the diseased rat. Return to Lothar over in Skaddria Naddheim.";
			CompletionMessage = "Well done young adventurer!";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( DiseasedRat ) }, "Diseased Rat" ) );
		}
	}

	public class FightingSpiritPartTwo : MLQuest
	{
		public override Type NextQuest { get { return typeof( FightingSpiritPartThree ); } }
		public override bool IsChainTriggered { get { return true; } }

		public FightingSpiritPartTwo()
		{
			Activated = true;
			Title = "Fighting Spirit Part 2";
			Description = "Next I require you to slay a Blood Bat.<BR><BR>Beware! This creature will be slightly more difficult than the last.<BR><BR>Now go young adventurer!";
			RefusalMessage = "I understand you having second thoughts. Very well. Return to me when you are ready for your training!";
			CompletionNotice = "You have slain the blood bat. Return to Lothar over in Skaddria Naddheim.";
			CompletionMessage = "Well done young adventurer!";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( BloodBat ) }, "Blood Bat" ) );
		}
	}

	public class FightingSpiritPartThree : MLQuest
	{
		public override Type NextQuest { get { return typeof( FightingSpiritPartFour ); } }
		public override bool IsChainTriggered { get { return true; } }

		public FightingSpiritPartThree()
		{
			Activated = true;
			Title = "Fighting Spirit Part 3";
			Description = "Next I require you to slay a Vile Toad.<BR><BR>Beware! This creature will be slightly more difficult than the last.<BR><BR>Now go young adventurer!";
			RefusalMessage = "I understand you having second thoughts. Very well. Return to me when you are ready for your training!";
			CompletionNotice = "You have slain the vile toad. Return to Lothar over in Skaddria Naddheim.";
			CompletionMessage = "Well done young adventurer!";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( VileToad ) }, "Vile Toad" ) );
		}
	}

	public class FightingSpiritPartFour : MLQuest
	{
		public override Type NextQuest { get { return typeof( FightingSpiritPartFive ); } }
		public override bool IsChainTriggered { get { return true; } }

		public FightingSpiritPartFour()
		{
			Activated = true;
			Title = "Fighting Spirit Part 4";
			Description = "Next I require you to slay an Albino Serpent.<BR><BR>Beware! This creature will be slightly more difficult than the last.<BR><BR>Now go young adventurer!";
			RefusalMessage = "I understand you having second thoughts. Very well. Return to me when you are ready for your training!";
			CompletionNotice = "You have slain the albino serpent. Return to Lothar over in Skaddria Naddheim.";
			CompletionMessage = "Well done young adventurer!";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( AlbinoSerpent ) }, "Albino Serpent" ) );
		}
	}

	public class FightingSpiritPartFive : MLQuest
	{
		public override Type NextQuest { get { return typeof( FightingSpiritPartSix ); } }
		public override bool IsChainTriggered { get { return true; } }

		public FightingSpiritPartFive()
		{
			Activated = true;
			Title = "Fighting Spirit Part 5";
			Description = "Next I require you to slay an enraged bear.<BR><BR>Beware! This creature will be slightly more difficult than the last.<BR><BR>Now go young adventurer!";
			RefusalMessage = "I understand you having second thoughts. Very well. Return to me when you are ready for your training!";
			CompletionNotice = "You have slain the enraged bear. Return to Lothar over in Skaddria Naddheim.";
			CompletionMessage = "Well done young adventurer!";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( EnragedBear ) }, "Enraged Bear" ) );
		}
	}

	public class FightingSpiritPartSix : MLQuest
	{
		public override Type NextQuest { get { return typeof( FightingSpiritPartSeven ); } }
		public override bool IsChainTriggered { get { return true; } }

		public FightingSpiritPartSix()
		{
			Activated = true;
			Title = "Fighting Spirit Part 6";
			Description = "Next I require you to slay a dark harpy.<BR><BR>Beware! This creature will be slightly more difficult than the last.<BR><BR>Now go young adventurer!";
			RefusalMessage = "I understand you having second thoughts. Very well. Return to me when you are ready for your training!";
			CompletionNotice = "You have slain the dark harpy. Return to Lothar over in Skaddria Naddheim.";
			CompletionMessage = "Well done young adventurer!";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( DarkHarpy ) }, "Dark Harpy" ) );
		}
	}

	public class FightingSpiritPartSeven : MLQuest
	{
		public override Type NextQuest { get { return typeof( FightingSpiritPartEight ); } }
		public override bool IsChainTriggered { get { return true; } }

		public FightingSpiritPartSeven()
		{
			Activated = true;
			Title = "Fighting Spirit Part 7";
			Description = "Next I require you to slay a ratman named Ikitari.<BR><BR>Beware! This creature will be slightly more difficult than the last.<BR><BR>Now go young adventurer!";
			RefusalMessage = "I understand you having second thoughts. Very well. Return to me when you are ready for your training!";
			CompletionNotice = "You have slain Ikitari. Return to Lothar over in Skaddria Naddheim.";
			CompletionMessage = "Well done young adventurer!";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( Ikitari ) }, "Ikitari" ) );
		}
	}

	public class FightingSpiritPartEight : MLQuest
	{
		public override Type NextQuest { get { return typeof( FightingSpiritPartNine ); } }
		public override bool IsChainTriggered { get { return true; } }

		public FightingSpiritPartEight()
		{
			Activated = true;
			Title = "Fighting Spirit Part 8";
			Description = "Next I require you to slay a lizardman named Shezothin.<BR><BR>Beware! This creature will be slightly more difficult than the last.<BR><BR>Now go young adventurer!";
			RefusalMessage = "I understand you having second thoughts. Very well. Return to me when you are ready for your training!";
			CompletionNotice = "You have slain Shezothin. Return to Lothar over in Skaddria Naddheim.";
			CompletionMessage = "Well done young adventurer!";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( Shezothin ) }, "Shezothin" ) );
		}
	}

	public class FightingSpiritPartNine : MLQuest
	{
		public override Type NextQuest { get { return typeof( FightingSpiritPartTen ); } }
		public override bool IsChainTriggered { get { return true; } }

		public FightingSpiritPartNine()
		{
			Activated = true;
			Title = "Fighting Spirit Part 9";
			Description = "Next I require you to slay a dreaded bone knight named Moruli.<BR><BR>Beware! This creature will be slightly more difficult than the last.<BR><BR>Now go young adventurer!";
			RefusalMessage = "I understand you having second thoughts. Very well. Return to me when you are ready for your training!";
			CompletionNotice = "You have slain Moruli. Return to Lothar over in Skaddria Naddheim.";
			CompletionMessage = "Well done young adventurer!";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( Moruli ) }, "Moruli" ) );
		}
	}

	public class FightingSpiritPartTen : MLQuest
	{
		public override Type NextQuest { get { return typeof( FightingSpiritPartEleven ); } }
		public override bool IsChainTriggered { get { return true; } }

		public FightingSpiritPartTen()
		{
			Activated = true;
			Title = "Fighting Spirit Part 10";
			Description = "Next I require you to slay an orc lord named Argolan.<BR><BR>Beware! This creature will be slightly more difficult than the last.<BR><BR>Now go young adventurer!";
			RefusalMessage = "I understand you having second thoughts. Very well. Return to me when you are ready for your training!";
			CompletionNotice = "You have slain Argolan. Return to Lothar over in Skaddria Naddheim.";
			CompletionMessage = "Well done young adventurer!";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( Argolan ) }, "Argolan" ) );
		}
	}

	public class FightingSpiritPartEleven : MLQuest
	{
		public override bool IsChainTriggered { get { return true; } }

		public FightingSpiritPartEleven()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Fighting Spirit Final Chapter";
			Description = "There is but one final task that I can ask of you. I ask that you slay a murderous savage named Grianthiam.<BR><BR>Beware! This creature will be more difficult than any you have faced thus far.<BR><BR>Should you succeed, I will reward you with your apprentice gear along with a bank check in order to help you get started in the world.<BR><BR>Now go young adventurer!";
			CompletionNotice = "You have slain Grianthiam. Return to Lothar over in Skaddria Naddheim.";
			CompletionMessage = "Well done young adventurer! Take this Apprentice Attire and goodie bag as a reward for your efforts.<BR><BR>You have completed your combat training with complete success. Now you must find your own way in this world, for I can test you no further.<BR><BR>Now go young adventurer, and bring hope to the citizens of Almhara!";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( Grianthiam ) }, "Grianthiam" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( new ItemReward( "Apprentice Bracelet", typeof( ApprenticeBracelet ) ) );
			Rewards.Add( new ItemReward( "Apprentice Cap", typeof( ApprenticeCap ) ) );
			Rewards.Add( new ItemReward( "Apprentice Earrings", typeof( ApprenticeEarrings ) ) );
			Rewards.Add( new ItemReward( "Apprentice Gloves", typeof( ApprenticeGloves ) ) );
			Rewards.Add( new ItemReward( "Apprentice Gorget", typeof( ApprenticeGorget ) ) );
			Rewards.Add( new ItemReward( "Apprentice Legs", typeof( ApprenticeLegs ) ) );
			Rewards.Add( new ItemReward( "Apprentice Ring", typeof( ApprenticeRing ) ) );
			Rewards.Add( new ItemReward( "Apprentice Sleeves", typeof( ApprenticeSleeves ) ) );
			Rewards.Add( new ItemReward( "Apprentice Tunic", typeof( ApprenticeTunic ) ) );
		}
	}

	#endregion

	#region Mobiles

	[QuesterName( "Lothar" )]
	public class Lothar : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		[Constructable]
		public Lothar(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Lothar - (Fighting Spirit)";
			Title = "the Youth Trainer";
			BodyValue = 400;
			Direction = Direction.South;
			CantWalk = true;
			Race = Race.Human;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new Server.Items.Boots() );
			AddItem( new Server.Items.Cloak(113) );
			AddItem( new Server.Items.CloseHelm() );
			AddItem( new Server.Items.PlateGorget() );
			AddItem( new Server.Items.PlateGloves() );
			AddItem( new Server.Items.PlateArms() );
			AddItem( new Server.Items.PlateLegs() );
			AddItem( new Server.Items.PlateChest() );
			AddItem( new Server.Items.OrderShield() );
			AddItem( new Server.Items.PaladinSword() );
		}

		public Lothar( Serial serial ): base( serial )
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
