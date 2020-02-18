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

	public class TheGhostOfStoneBurrowMines : MLQuest
	{
		public override Type NextQuest { get { return typeof( SaveHisDad ); } }

		public TheGhostOfStoneBurrowMines()
		{
			Activated = true;
			Title = "The Ghost of Stone Burrow Mines"; // A Ghost of Covetous
			Description = "What? Oh, you startled me! Sorry, I'm a little jumpy. My master Griswolt learned that a ghost has recently taken up residence in Stone Burrow Mines. He sent me to capture it, but I . . . well, it terrified me, to be perfectly honest. If you think yourself courageous enough, I'll give you my Spirit Bottle, and you can try to capture it yourself. I'm certain my master would reward you richly for such service.";
			RefusalMessage = "That's okay, I'm sure someone with more courage than either of us will come along eventually.";
			InProgressMessage = "You can easily reach Stone Burrow Mines via a hidden moongate located deep within the Autumnwood.";
			CompletionMessage = "(As you try to use the Spirit Bottle, the ghost snatches it out of your hand and smashes it on the rocks) Please, don't be frightened. I need your help!";
			CompletionNotice = CompletionNoticeShort;

			Objectives.Add( new DeliverObjective( typeof( SpiritBottle ), 1, "Spirit Bottle", typeof( Frederic ) ) );
		}
	}

	public class SaveHisDad : MLQuest
	{
		public override Type NextQuest { get { return typeof( AFathersGratitude ); } }
		public override bool IsChainTriggered { get { return true; } }

		public SaveHisDad()
		{
			Activated = true;
			Title = 1075337; // Save His Dad
			Description = "My father, Andros, is a smith in Elmhaven. Last week his forge overturned and he was splashed by molten steel. He was horribly burned, and we feared he would die. An alchemist over at Hammerhill promised to make a bandage that could heal him, but he needed the silk of a dread spider. I came here to get some, but I was careless, and succumbed to their poison. Please, won’t you help my father?";
			RefusalMessage = "Oh . . . that’s your decision . . . OooOoooOOoo . . .";
			InProgressMessage = "Thank you! Deliver it to Leon the Alchemist in Hammerhill.";
			CompletionMessage = "How may I help thee? You have the silk of a dread spider? Of course I can make you a bandage, but what happened to Frederic?";
			CompletionNotice = CompletionNoticeShort;

			Objectives.Add( new DeliverObjective( typeof( DreadSpiderSilk ), 1, "Dread Spider Silk", typeof( Leon ) ) );
		}
	}

	public class AFathersGratitude : MLQuest
	{
		public override bool IsChainTriggered { get { return true; } }

		public AFathersGratitude()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1075343; // A Father’s Gratitude
			Description = "That is simply terrible. First Andros, and now his son. Well, let’s make sure Frederic’s sacrifice wasn’t in vain. Will you take the bandages to his father? You can probably deliver them faster than I can, can’t you?";
			RefusalMessage = "Well I’m sorry to hear you say that. Without your help, I don’t know if I can get these to Andros quickly enough to help him.";
			InProgressMessage = "I don’t know how much longer Andros will survive. You’d better get this to him as quick as you can. Every second counts!";
			CompletionMessage = "Sorry, I’m not accepting commissions at the moment. What? You have the bandage I need from Leon? Thank you so much! But why didn’t my son bring this to me himself? . . . Oh, no! You can't be serious! *sag* My Freddie, my son! Thank you for carrying out his last wish. Here -- This was part of my savings, to give to him when he became a journeyman. I want you to have it.";
			CompletionNotice = CompletionNoticeShort;

			Objectives.Add( new DeliverObjective( typeof( AlchemistsBandage ), 1, "Alchemist's Bandage", typeof( Andros ) ) );

			Rewards.Add( new ItemReward( 1075345, typeof( AndrosGratitude ) ) ); // Andros’ Gratitude
			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
		}
	}

	#endregion

	#region Mobiles

	public class Ben : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		[Constructable]
		public Ben(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Ben - (The Ghost Of Stone Burrow Mines)";
			Title = "the Apprentice Necromancer";
			BodyValue = 0x190;
			Hue = 0x83FD;
			HairItemID = 0x2048;
			HairHue = 0x463;
			FacialHairItemID = 0x204C;
			FacialHairHue = 0x463;

			InitStats( 100, 100, 25 );

			AddItem( new Backpack() );
			AddItem( new Shoes( 0x901 ) );
			AddItem( new LongPants( 0x1BB ) );
			AddItem( new FancyShirt( 0x756 ) );
		}

		public Ben( Serial serial ): base( serial )
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

	[QuesterName( "The Ghost of Frederic Smithson" )]
	public class Frederic : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		[Constructable]
		public Frederic(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "The Ghost of Frederic Smithson";
			BodyValue = 0x1A;
			Hue = 0x455;
			Frozen = true;

			InitStats( 100, 100, 25 );
		}

		public Frederic( Serial serial ): base( serial )
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

	public class Leon : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		[Constructable]
		public Leon(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Leon";
			Title = "the Alchemist";
			Race = Race.Human;
			BodyValue = 0x190;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new Backpack() );
			AddItem( new Shoes( 0x901 ) );
			AddItem( new Robe( 0x657 ) );
		}

		public Leon( Serial serial ): base( serial )
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

	public class Andros : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		[Constructable]
		public Andros(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Andros";
			Title = "the Blacksmith";
			BodyValue = 0x190;
			Hue = 0x8409;
			FacialHairItemID = 0x2041;
			FacialHairHue = 0x45E;
			HairItemID = 0x2049;
			HairHue = 0x45E;

			InitStats( 100, 100, 25 );

			AddItem( new Backpack() );
			AddItem( new Boots( 0x901 ) );
			AddItem( new FancyShirt( 0x60B ) );
			AddItem( new LongPants( 0x1BB ) );
			AddItem( new FullApron( 0x901 ) );
			AddItem( new SmithHammer() );
		}

		public Andros( Serial serial ): base( serial )
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
