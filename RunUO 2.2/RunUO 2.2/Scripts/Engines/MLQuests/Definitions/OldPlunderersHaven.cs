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

	public class NiggaSpareMeSomePots : MLQuest
	{
		public NiggaSpareMeSomePots()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Nigga, Spare Me Some Pots";
			Description = "Excuse me, help a sista out won't ya. So you see we're totally overwhelmed. You feel me dawg? We've been under constant attack by those dang pumpkin spirits and my friends could use some first aid. I can't leave my post so what I need for you to do is seek out the following supplies. Healing potions, cure potions, mana potions and strength potions. 10 of each will do and I'll only need the lesser variety. Nothing more, nothing less.";
			RefusalMessage = "MOTHER FUCKA!";
			InProgressMessage = "Aight! That's what I'm talking about. Buy them, find them, I don't give a fuck what it takes. Peace out mah nigga.";
			CompletionMessage = "Oui, lil' g dun gone out and got 'em. Yah smell what I'm cooking? That's right, its your reward.";
			CompletionNotice = "You have collected enough potions on the list. Return to Siarra in Old Plunderers Haven for your reward.";

			Objectives.Add( new CollectObjective( 10, typeof( LesserHealPotion ), "lesser yellow potion" ) );
			Objectives.Add( new CollectObjective( 10, typeof( LesserCurePotion ), "lesser orange potion" ) );
			Objectives.Add( new CollectObjective( 10, typeof( LesserManaPotion ), "lesser sky blue potion" ) );
			Objectives.Add( new CollectObjective( 10, typeof( StrengthPotion ), "white potion" ) );

			Rewards.Add( new ItemReward( "Potion Storage Pouch", typeof( PotionStoragePouch ) ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class TerrorFromTheDeep : MLQuest
	{
		public TerrorFromTheDeep()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Terror From The Deep";
			Description = "Oh, sorry if I appear a bit distracted at this moment. It seems that lurking deep with the Nimaku Lava Basin over in the Zaythalor region is home to the legendary void terror. A being described as a hideous multi-headed silhouette of pure darkness with a vicious temperament and a foul, sulfurous stench emminating around its visage. This creature has been been nothing but trouble within the Almharian realm. Just about everyone whose gone after the beast has met with an untimely end due to its raw power, along with help from its minions If that wasn't enough, to make matters worse the underground lair is home to a now dormant volcano, though the active lava flows are prone to catching unwary travelers on fire should they wander too close to them. I'd help you slay this abomination if I was any good with a sword. Unfortunately this is where you come into play, providing you're capable of felling this terror from the deep.";
			RefusalMessage = "I'm sorry to hear that. I suppose I better get back to work before winter comes.";
			InProgressMessage = "Despite being underground and surrounded by molten rock, the beast is repressed by fire spells and other related forms of offense.";
			CompletionMessage = "I'll be. You've made it back alive. How did the fight go? Did it put up much of a challenge or were you the one who was more of a challenge to the void terror. Now how about that reward that I completely forget to mention beforehand. I'm surprised you actually went along with the mission without being told ahead of time as to how you were gonna get compensated. My apologies for not briefing you in the beginning. Either way we can all rest easily knowing that the void terror was finally given its final slumber.";
			CompletionNotice = "You have slain the void terror. Return to Fynly Bristleback over in Old Plunderers Haven for your reward.";

			Objectives.Add( new KillObjective( 1, new Type[] { typeof( VoidTerror ) }, "void terror" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class ThisIsNotHalloween : MLQuest
	{
		public ThisIsNotHalloween()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "This Is Not Halloween";
			Description = "Oh where are my manners, it is so good to see a new face around here. We've been trying to retake what was originally Plunder's Haven, but the goblin forces are still far too many. That being said I was wondering if you could help with another pressing matter concerning the growing number of mad pumpkin spirits throughout the region.";
			RefusalMessage = "Very well, I see you have yet to come out of your training wheels.";
			InProgressMessage = "Ah, now that's what I wanted to hear. So it turns out that those spirits are widely believed by region locals to be remants of a band of circus performers. Honestly I could care less of their origins. What I'm really after is their shadow pumpkin essence, which I could use for an experiment. What's that? You're telling me this is yet another time someone has boasted about some random experiment? Well if you want to know the specific details then its for a certain drink, which with the right ingredients I'm hoping to eventually patent one of these days. Wait a minute, why am I wasting both our times with this useless banter? You need to get going.";
			CompletionNotice = "You have collected enough essence. Return to Vargas over at Old Plunderer's Haven for your reward.";
			CompletionMessage = "Sweet silverfish crackers, you got them. I knew I could count on you and I've even managed to take care of the remainder of my errands. Speaking of which, while I was cleaning out some containers I stumbled upon these dragon scales that I'm sure could come in handy. So here, go ahead and take them, along with the rest of your reward.";

			Objectives.Add( new CollectObjective( 4, typeof( ShadowPumpkinEssence ), "shadow pumpkin essence" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class WanderingStrider : MLQuest
	{
		public WanderingStrider()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Wandering Strider";
			Description = "I bet you can't kill ... ten wandering cliff striders!  I bet they're too much for you.  You may as well confess you can't ...";
			RefusalMessage = "Hahahaha! I knew it!";
			InProgressMessage = "Yeah, no. You see. I need you to slay ten of them. Nothing more, nothing less.";
			CompletionMessage = "Wow that was quick. These items should do you pretty well.";
			CompletionNotice = "You have slain enough wandering cliff striders. Return to Acob in Old Plunderers Haven for your reward.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( WanderingCliffStrider ) }, "wandering cliff striders" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1000 );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
		}
	}

	public class WildTurkeys : MLQuest
	{
		public WildTurkeys()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Wild Turkeys";
			Description = "Oh nevermind, you don't look capable of my task afterall.  Haha! What was I thinking - you could never handle killing wild turkeys. It'd be suicide. What? I don't know, I don't want to be responsible ... well okay if you're really sure?";
			RefusalMessage = "Probably the wiser course of action.";
			InProgressMessage = "You still need to kill those wild turkeys, remember?";
			CompletionMessage = "Sanctum Stercore! You were actually able to handle those tough sobs. Here, take these with you. If you see anyone else that could use the assistance, be sure to help them out.";
			CompletionNotice = "You have slain enough wild turkeys. Return to Abbein in Old Plunderers Haven for your reward.";

			Objectives.Add( new KillObjective( 12, new Type[] { typeof( WildTurkey ) }, "wild turkeys" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
		}
	}

	#endregion

	#region Mobiles

	[QuesterName( "Siarra (Old Plunderers Haven)" )]
	public class Siarra : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, 1074206 ); // Excuse me please traveler, might I have a little of your time?
		}

		[Constructable]
		public Siarra(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Siarra - (Nigga, Spare Me Some Pots)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Sandals( 0x1BB ) );
			AddItem( new ElvenShirt() );
			AddItem( new LeafTonlet() );
			AddItem( new GemmedCirclet() );
		}

		public Siarra( Serial serial ): base( serial )
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

	[QuesterName( "FynlyBristleback (Old Plunderers Haven)" )]
	public class FynlyBristleback : BaseCreature
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
		public FynlyBristleback(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Fynly Bristleback - (Terror From The Deep)";
                 	Body = 605;
                        Female = false;
                        Race = Race.Elf;
                        Hue = 1023;
                        HairItemID = 12241;
                        HairHue = 2213;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new Boots() );

			Item item;

			item = new LeafArms();
			AddItem( item );

			item = new LeafChest();
			AddItem( item );

			item = new LeafGloves();
			AddItem( item );

			item = new LeafGorget();
			AddItem( item );

			item = new LeafLegs();
			AddItem( item );
		}

		public FynlyBristleback( Serial serial ): base( serial )
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

	[QuesterName( "VargasTheMerchant (Old Plunderers Haven)" )]
	public class VargasTheMerchant : BaseCreature
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
		public VargasTheMerchant(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Vargas The Merchant - (This Is Not Halloween)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33821;
                        HairItemID = 8253;
                        HairHue = 1108;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 80.0, 100.0 );
			SetSkill( SkillName.Tactics, 70.0, 100.0 );
			SetSkill( SkillName.TasteID, 36.0, 68.0 );
			SetSkill( SkillName.Wrestling, 85.5, 100.0 );

			AddItem( new ClothNinjaJacket( 868 ) );
			AddItem( new TattsukeHakama( 873 ) );
			AddItem( new ShortBoots( 933 ) );
		}

		public VargasTheMerchant( Serial serial ): base( serial )
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

	[QuesterName( "Acob (Old Plunderers Haven)" )]
	public class Acob : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, 1074197 ); // Pardon me, but if you could spare some time I’d greatly appreciate it.
		}

		[Constructable]
		public Acob(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Acob - (Wandering Strider)";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new ElvenBoots( 0x714 ) );
			AddItem( new ElvenShirt( Utility.RandomBlueHue() ) );
			AddItem( new HidePants() );
		}

		public Acob( Serial serial ): base( serial )
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

	[QuesterName( "Abbein (Old Plunderers Haven)" )]
	public class Abbein : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, 1074197 ); // Pardon me, but if you could spare some time I’d greatly appreciate it.
		}

		[Constructable]
		public Abbein(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Abbein - (Wild Turkeys)";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new ElvenBoots( 0x72C ) );
			AddItem( new ElvenRobe( 0x8B0 ) );
			AddItem( new RoyalCirclet() );
		}

		public Abbein( Serial serial ): base( serial )
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