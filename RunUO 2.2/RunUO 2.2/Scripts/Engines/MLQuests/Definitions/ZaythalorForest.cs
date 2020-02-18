using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.ContextMenus;
using Server.Engines.BulkOrders;
using Server.Engines.MLQuests.Objectives;
using Server.Engines.MLQuests.Rewards;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Engines.MLQuests.Definitions
{
	#region Quests

	public class Birdemic : MLQuest
	{
		public Birdemic()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Birdemic";
			Description = "You've probably alreadly noticed that I haven't attacked you yet. As a matter of fact I just so happen to be quite different from my brethren. Throughout my years I've come to grow rather appreciative towards the elves and humans. They only attack us in retaliation because like most monsters we're the ones that are the aggressive types. Now that I've gotten that out of the way, I could sure use your help. Have you ever noticed how heavily populated this region is when it comes to birds? They don't do anything, they make for terrible pets and they don't sell for very much. That's why I wanna hire you to help dispose of these wretched avian pests. Do we have a deal?";
			RefusalMessage = "Great, well that's just fucking chips and cream.";
			InProgressMessage = "Groovy, that's what I'm talking about. I'm sure you're aware of the variety of birds that plague these lands. I'm talking wrens, chickadees, plovers, you name it. Search the entire island and get rid of as many of these feathered bastards as you possibly can. Now if you excuse me I must get some rest, for I need to make several trips starting tomorrow. I'll awaken whenever you've completed your objective.";
			CompletionNotice = "Congratulations you've slaughtered 30 of the most innocent creatures to ever roam this world. Return to Vas Gharn, if you can still remember where he's located.";
			CompletionMessage = "Say no more, I knew you can do it. You have done everyone a great favor by cutting down the overpopulation of the various avian species. Though I hate to tell you this but birds have a nasty habit of respawning in large numbers so I'm sorry for wasting your time. But hey I can make it up to you. You like money? Gems? Random equipment? Here you go. Really you outta be grateful. I just payed a random stranger to go out and dispose of creatures that nobody ever pays attention to.";

			Objectives.Add( new KillObjective( 30, new Type[] { typeof( Bird ) }, "bird" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class EggCollector : MLQuest
	{
		public EggCollector()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Egg Collector";
			Description = "You've seen them, haven't you? Those bluish beetles gathering around the waterside, all the while protecting their precious eggs. I say, perhaps you might be able to procure some for me. I could use them for certain experiments. That's right, at least ten eggs should be all I need for my experiment.";
			RefusalMessage = "Oh you slimy little bastard. I'll have you know that my father is in the top 10 percent of elite lawyers throughout the lands of Almhara and when he finds out about this transgression he's going to sue the pants off you.";
			InProgressMessage = "Are those beetles still kicking your ass? All I can say is to keep trying and don't give up. Though if you wanted to cheat the system and you have a few hundred gold on your person then you could try searching the lands for any of the Scarlet Sisters. I heard that one who specializes in magic resist is hidden behind a locked stone door which requires a decent amount of lockpicking.";
			CompletionNotice = "Make sure you've collected ten beetle eggs, then return to Sabrina.";
			CompletionMessage = "Now that's what I'm talking about. In case you're wondering what experiment I had in mind concerning these eggs then its quite simple really. I want to see if I can make a salad out of them. Any way I have your reward right here.";

			Objectives.Add( new CollectObjective( 10, typeof( FaerieBeetleEgg ), "faerie beetle eggs" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class Insecticide : MLQuest
	{
		public Insecticide()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Insecticide";
			Description = "Well look who we have here, a newcomer to this parts. Listen I could use your help and while I would normally take care of the situation myself I am sadly still recovering from a broken arm injury. That being said, Zaythalor Forest has become infested with swarms of black ants and they are ruining the ecosystem. I need for you to go out and clear out as many of those invaders as you possibly can. Can you help me out with this?";
			RefusalMessage = "I see someone doesn't respect nature, fine then. Don't blame me if those ants eventually make their way into your home and do all sorts of unspeakable things to it.";
			InProgressMessage = "Ah now that's determination. Very well, I suppose you better get going now before the situation worsens.";
			CompletionNotice = "Well congratz, you've killed enough black ants. Ain't you so special for killing one of the weakest enemies in the game? Whatever, head back to David.";
			CompletionMessage = "Well since you put it like that, it was a most triumphant victory. Sadly I cannot say the same for your reward, unless you consider gold and gems as compensation.";

			Objectives.Add( new KillObjective( 20, new Type[] { typeof( BlackAntZaythalorForest ) }, "black ant" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class MolassesGreed : MLQuest
	{
		public MolassesGreed()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Molasses Greed";
			Description = "Oh me, Oh my. That evil Balzan Marcos has stolen my order list. Oh what am i going to do it was such an important order. Oh me, Oh my. Oh sorry I forgot you were there I need you to try and get my order list back, If you get it back I shall give you a wonderful reward. Please go and get it I really need it back, Please help me.";
			RefusalMessage = "Oh come on dude! Help a sister out, will ya!";
			InProgressMessage = "Thanks mate. Now lets see here. Oh I almost forgot, I heard a rumor that that evil villian is living in the ruins near Hammerhill. Good Luck, you'll need it.";
			CompletionNotice = "Return the order list to Feron.";
			CompletionMessage = "Neato! Allow me to present to you your reward before you leave.";

			Objectives.Add( new CollectObjective( 1, typeof( OrderList ), "Feron's Order List" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class StarLakeInfestation : MLQuest
	{
		public StarLakeInfestation()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Star Lake Infestation";
			Description = "Well howdy there kiddo, might I reckon you new to these here parts? My name is Travis Crabtree and as you can no doubt tell I make my daily rountine in fishing up all sorts of strange and sometimes valuable things. You know stuff.......... but mostly fish. However one of my usual spots over in Star Lake has seemed to have become over run with those goddamn crabs and it makes catching anything quite difficult. Can you help out an old man down on his luck?";
			RefusalMessage = "Ah cheese and crackers! Well I suppose you have other chores you need to tend to. I'll be here if you ever change your mind.";
			InProgressMessage = "Just you know that by partaking in this endeavor you have made what remains of my last years all the more bearable. Now getting into the lake can prove to be rather tricky but if you inspect the area closely you should be able to find an entrance. Once inside you should be able to easily spot the lake and its somewhat overpopulated number of crabs. Mate, all I can tell you is that even though they are still crabs they can still put up quite a fightin. Don't let their appearance fool you, those claws can be mighty painful.";
			CompletionNotice = "You manage to clear out a good number of crabs but they still keep coming. You're gonna have to return to Travis Crabtree over in Hammerhill and inform him of what's going on.";
			CompletionMessage = "Well its certainly something that nature wanted, so I guess I cannot complain. I suppose I'll have to find another fishing spot, perhaps even further away from this crazy settlement. Speaking of which I'm unable to provide much of a reward other than this bag full of stuff I fished up on one of my previous trips. Go ahead and take it.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( StarLakeCrab ) }, "star lake crab" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class ThinningOutTheHerd : MLQuest
	{
		public ThinningOutTheHerd()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Thinning Out The Herd";
			Description = "Me, almighty Fluffy Snapper no like deer. Deer eat up all the food, we don't like it. You head into forest and kill deer.";
			RefusalMessage = "Me, omega Fluffy Snapper am saddened by this news. Me say children outta destroy you, but they too lazy and they poop a lot.";
			InProgressMessage = "Me, big daddy Fluffy Snapper am pleased by your offer. Me say that you outta fulfill your part of the bargain. Go into forest and kill as many deer to your heart's content. Me king pimpin Fluffy Snapper need not remind you. If you can't figure it out then me guess you dumber than sack of gizzard poop.";
			CompletionNotice = "Return to Fluffy Snapper over in the Rabbit Cave and hopefully he won't do something stupid.";
			CompletionMessage = "Me emperor Fluffy Snapper am sorry for the big mess, me completely gorged out on carrots. Take reward and don't come back.";

			Objectives.Add( new KillObjective( 18, new Type[] { typeof( Hind ) }, "hind" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	public class ThoseBlueBastards : MLQuest
	{
		public ThoseBlueBastards()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Those Blue Bastards";
			Description = "Those good for nothing blue bastards. They must really have a number with my chickens. Have you ever experienced the foul breath of a wild gizzard? Because let me tell you, those mothers are about as fierce as that of giant ogumos and you know how much I despise them hairy legged buggers. Either way, if you're not preoccupied with other tasks, then maybe you might be able to assist in driving back their numbers?";
			RefusalMessage = "I suppose another time would be more suitable.";
			InProgressMessage = "Oh dagnabit, I scared the poor little chicklets. Any how, I need for you to scroop through Zaythalor and proceed towards showing those blue-balled feather brains a good lickin with a 2x4. Or, you can just do them in with a hearty helping of a decent cleave and a half.";
			CompletionNotice = "You've slain enough gizzards for now. Return to Ruffus over at Popplewell Ranch.";
			CompletionMessage = "Well I'll be a captured maiden surrounded by an antlion coven, I can't believe it. Actually I can now that I think about it. Either way I don't think they will be bothering my chickens for a good while. So as a reward, allow me to offer to you this gold and whatever I managed to find lying about the house.";

			Objectives.Add( new KillObjective( 10, new Type[] { typeof( Gizzard ) }, "gizzard" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.SmallBagOfTreasure );
		}
	}

	#endregion

	#region Mobiles

	[QuesterName( "VasGharn (Zaythalor Forest)" )]
	public class VasGharn : BaseCreature
	{
		public override bool InitialInnocent{ get{ return true; } }
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
		public VasGharn(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "VasGharn - (Birdemic)";
      			Body = 53;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );
		}

		public VasGharn( Serial serial ): base( serial )
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

	[QuesterName( "SabrinaTheFortuneTeller (Zaythalor Forest)" )]
	public class SabrinaTheFortuneTeller : BaseCreature
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
		public SabrinaTheFortuneTeller(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Sabrina the fortune teller - (Egg Collector)";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33822;
                        HairItemID = 8252;
                        HairHue = 1109;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 80.0, 100.0 );
			SetSkill( SkillName.Tactics, 70.0, 100.0 );
			SetSkill( SkillName.Wrestling, 85.5, 100.0 );

			AddItem( new CitizenDress( 823 ) );
			AddItem( new Cloak( 733 ) );
			AddItem( new ShortBoots( 838 ) );
		}

		public SabrinaTheFortuneTeller( Serial serial ): base( serial )
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

	[QuesterName( "DavidTheForestExpert (Zaythalor Forest)" )]
	public class DavidTheForestExpert : BaseCreature
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
		public DavidTheForestExpert(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "David Cranshaw the forest expert - (Insecticide)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33784;
                        HairItemID = 8253;
                        HairHue = 1116;
                        FacialHairItemID = 8267;
                        FacialHairHue = 1116;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 64.0, 100.0 );
			SetSkill( SkillName.Fencing, 36.0, 68.0 );
			SetSkill( SkillName.TasteID, 36.0, 68.0 );
			SetSkill( SkillName.Cooking, 36.0, 68.0 );
			SetSkill( SkillName.Tactics, 64.0, 100.0 );

			AddItem( new DeerMask() );
			AddItem( new BodySash( 743 ) );
			AddItem( new FancyShirt( 643 ) );
			AddItem( new ShortPants( 853 ) );
			AddItem( new LightBoots( 993 ) );

			Dagger weapon = new Dagger();
			weapon.Movable = true; 
			AddItem( weapon );
		}

		public DavidTheForestExpert( Serial serial ): base( serial )
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

	[QuesterName( "Feron (Zaythalor Forest)" )]
	public class Feron : BaseCreature
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
		public Feron(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Feron the worried smithy - (Molasses Greed)";
			CantWalk = true;
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 0x83F8;
                        HairItemID = 0;
                        HairHue = 0;	

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.ArmsLore, 65.0, 88.0 );
			SetSkill( SkillName.Blacksmith, 90.0, 100.0 );
			SetSkill( SkillName.Macing, 36.0, 68.0 );
			SetSkill( SkillName.Parry, 36.0, 68.0 );

			AddItem( new SmithHammer() );

			RingmailChest chest = new RingmailChest();
			chest.Hue = 2412;
			chest.Movable = true;
			AddItem( chest );

			AddItem( new FullApron() );
			AddItem( new LongPants() );
			AddItem( new ThighBoots() );
		}

                public override void OnSpeech(SpeechEventArgs e)
                {
                    if ((e.Speech.ToLower() == "repair"))
                    {
                        BeginRepair (e.Mobile);
                    }
                    else
                    {
                        base.OnSpeech(e);
                    }

                }
                public void BeginRepair(Mobile from)
                {
                    if (Deleted || !from.CheckAlive())
                        return;

                    SayTo(from, "What do you want me to repair?");

                    from.Target = new RepairTarget(this);

                }

                private class RepairTarget : Target
                {
                    private Feron m_Blacksmith;

                    public RepairTarget(Feron blacksmith): base(12, false, TargetFlags.None)
                    {
                        m_Blacksmith = blacksmith;
                    }

                    protected override void OnTarget(Mobile from, object targeted)
                    {
                        if (targeted is BaseWeapon)
                        {
                            BaseWeapon bw = targeted as BaseWeapon;
                            Container pack = from.Backpack;
                            int toConsume = 0;
                            toConsume = (bw.MaxHitPoints - bw.HitPoints) * 3; //Adjuct price here by changing 3 to whatever you want.

                            if (toConsume == 0)
                            {
                                m_Blacksmith.SayTo(from, "That weapon is not damaged.");
                            }
                            else if ((bw.HitPoints < bw.MaxHitPoints) && (pack.ConsumeTotal(typeof(Gold), toConsume)))
                            {
			        Item a = from.Backpack.FindItemByType( typeof( Gold ) );
			        if ( a != null )

				a.Consume( toConsume );

                                bw.HitPoints = bw.MaxHitPoints;
                                m_Blacksmith.SayTo(from, "Here is your weapon.");
                                from.SendMessage(String.Format("You pay {0}gp.", toConsume));
                                Effects.PlaySound(from.Location, from.Map, 0x2A);
                            }
                            else
                            {
                                m_Blacksmith.SayTo(from, "It will cost you {0}gp to have your weapon repaired.", toConsume);
                                from.SendMessage("You do not have enough gold.");
                            }
                        }

                        if (targeted is BaseArmor)
                        {
                            BaseArmor ba = targeted as BaseArmor;
                            Container pack = from.Backpack;
                            int toConsume = 0;
                            toConsume = (ba.MaxHitPoints - ba.HitPoints) * 3; //Adjuct price here by changing 3 to whatever you want.

                            if ((toConsume == 0) && (ba.Resource == CraftResource.Iron || ba.Resource == CraftResource.DullCopper || ba.Resource == CraftResource.ShadowIron || ba.Resource == CraftResource.Copper || ba.Resource == CraftResource.Bronze || ba.Resource == CraftResource.Gold || ba.Resource == CraftResource.Agapite || ba.Resource == CraftResource.Verite || ba.Resource == CraftResource.Valorite))
                            {
                                m_Blacksmith.SayTo(from, "That armor is not damaged.");
                            }
                            else if (ba.Resource == CraftResource.RegularLeather || ba.Resource == CraftResource.SpinedLeather || ba.Resource == CraftResource.HornedLeather || ba.Resource == CraftResource.BarbedLeather)
                            {
                                m_Blacksmith.SayTo(from, "I cannot repair that.");
                            }
                            else if ((ba.HitPoints < ba.MaxHitPoints) && (pack.ConsumeTotal(typeof(Gold), toConsume) && (ba.Resource == CraftResource.Iron || ba.Resource == CraftResource.DullCopper || ba.Resource == CraftResource.ShadowIron || ba.Resource == CraftResource.Copper || ba.Resource == CraftResource.Bronze || ba.Resource == CraftResource.Gold || ba.Resource == CraftResource.Agapite || ba.Resource == CraftResource.Verite || ba.Resource == CraftResource.Valorite)))
                            {
			        Item a = from.Backpack.FindItemByType( typeof( Gold ) );
			        if ( a != null )

				a.Consume( toConsume );

                                ba.HitPoints = ba.MaxHitPoints;
                                m_Blacksmith.SayTo(from, "Here is your armor.");
                                from.SendMessage(String.Format("You pay {0}gp.", toConsume));
                                Effects.PlaySound(from.Location, from.Map, 0x2A);
                            }
                            else
                            {
                                m_Blacksmith.SayTo(from, "It will cost you {0}gp to have your armor repaired.", toConsume);
                                from.SendMessage("You do not have enough gold.");
                            }                    
                        }
                    }
                }

		public Feron( Serial serial ): base( serial )
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

	[QuesterName( "TravisCrabtreeTheFisherman (Zaythalor Forest)" )]
	public class TravisCrabtreeTheFisherman : BaseCreature
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
		public TravisCrabtreeTheFisherman(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Travis Crabtree the fisherman - (Star Lake Infestation)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33791;
                        HairItemID = 8251;
                        HairHue = 1133;
                        FacialHairItemID = 8257;
                        FacialHairHue = 1133;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 64.0, 100.0 );
			SetSkill( SkillName.Fishing, 64.0, 100.0 );
			SetSkill( SkillName.TasteID, 36.0, 68.0 );
			SetSkill( SkillName.Cooking, 36.0, 68.0 );
			SetSkill( SkillName.Tactics, 64.0, 100.0 );

			AddItem( new FishingPole() );

			AddItem( new Shirt( 838 ) );
			AddItem( new ShortPants( 898 ) );
			AddItem( new HeavyBoots( 978 ) );
		}

		public TravisCrabtreeTheFisherman( Serial serial ): base( serial )
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

	[QuesterName( "FluffySnapper (Zaythalor Forest)" )]
	public class FluffySnapper : BaseCreature
	{
		public override bool InitialInnocent{ get{ return true; } }
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
		public FluffySnapper(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Fluffy Snapper - (Thinning Out The Herd)";
			Body = 205;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.TasteID, 36.0, 68.0 );
		}

		public FluffySnapper( Serial serial ): base( serial )
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

	[QuesterName( "RuffusWeinstein (Zaythalor Forest)" )]
	public class RuffusWeinstein : BaseCreature
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
		public RuffusWeinstein(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Ruffus Weinstein the farmer - (Those Blue Bastards)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33807;
                        HairItemID = 8260;
                        HairHue = 1154;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 64.0, 100.0 );
			SetSkill( SkillName.Fishing, 64.0, 100.0 );
			SetSkill( SkillName.TasteID, 36.0, 68.0 );
			SetSkill( SkillName.Cooking, 36.0, 68.0 );
			SetSkill( SkillName.Tactics, 64.0, 100.0 );

			AddItem( new BodySash( 780 ) );
			AddItem( new Shirt( 888 ) );
			AddItem( new ShortPants( 793 ) );
			AddItem( new ShortBoots( 780 ) );

			SkinningKnife weapon = new SkinningKnife();
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );
		}

		public RuffusWeinstein( Serial serial ): base( serial )
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