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
	#region Quest

	public class EnchantedShovel : MLQuest
	{
		public EnchantedShovel()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Enchanted Shovel";
			Description = "Oh thank the Elysstian gods, perhaps you might be able to aid me with this uncertain predicament. My late husband, bless his troubled soul, was a miner who had quite the connected relationship when it came to his brother, an over the top mage who was renown for taking everyday commodities and trying to convert them into something that would last longer than their original lifespan. About two years ago, they both started assembly on a particular shovel that was said to be indestructible, at least believing to possess over infinite uses before finally crumbling. However on one fateful night, my husband, after just finding himself a nice cache of verite ore fell victim to a rock slide that instantly did him in. When I got to the scene of the crime, I noticed that the three components to his work were suddenly missing and a letter had been left behind. A letter involving a gang of outcasts from Coven's Landing who've had a long and detailed history when it came to causing trouble among the locals. Unfortunately because of those hooligans, my husband's work was never able to be completed. If you have it within the eternal depths of your heart, then I would be gracious if you could seek them out and finally put an end to their mischief. Do this and I will charge the shovel and I've even go ahead and allow you to have it, just because I honestly wouldn't know what to make of such a device.";
			RefusalMessage = "Oh come on! As if my week couldn't have possibly gotten worse!";
			InProgressMessage = "I don't believe it. You're willing to go through with this? Are you sure? I honestly don't know where I could start. Hold on, give me a few moments to try and clear my head. One of them was a Ratman whose currently hiding out in some underground caverns inhabited by mongbats. The second member was one of the lizardfolk said to be stalking the Stoneburrow Mines. And the final member is said to be lurking somewhere in Fortress Calcifina. I wish you, among many other things the best of luck.";
			CompletionNotice = "You have collected all three components. Return to Therasa and she will construct the new shovel for you.";
			CompletionMessage = "There isn't enough gratitude in the world for what you've accomplished. You've managed to succeed in bringing to fruition my husband's final project and I honestly don't know what I can do to repay you for what must have been quite the ardous trek across fierce territory. Allow me to assemble that shovel. Okay now I recall. Goodness it has been a while since we've previously encountered one another. I'll just simply go ahead and allow you to instead keep that shovel. I figured it was only fitting given how you were able to avenge the desecration of my husband's remains and now hopefully we won't have to bare any more of those misfits.";

			Objectives.Add( new CollectObjective( 1, typeof( EnchantedShovelArm ), "enchanted shovel arm" ) );
			Objectives.Add( new CollectObjective( 1, typeof( EnchantedShovelHandle ), "enchanted shovel handle" ) );
			Objectives.Add( new CollectObjective( 1, typeof( EnchantedShovelHead ), "enchanted shovel head" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.MagicEnchantedShovel );
		}
	}

	#endregion

	#region Mobiles

	[QuesterName( "Therasa (Alytharr Region)" )]
	public class Therasa : BaseCreature
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
		public Therasa(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Therasa the Miner's Wife - (Enchanted Shovel)";
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
			CantWalk = true;
                        Hue = 2403;
                        HairItemID = 12225;
                        HairHue = 1319;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 59.5, 68.7 );
			SetSkill( SkillName.Alchemy, 64.0, 100.0 );
			SetSkill( SkillName.Herding, 60.0, 83.0 );
			SetSkill( SkillName.Tailoring, 61.0, 100.0 );
			SetSkill( SkillName.Tracking, 60.0, 83.0 );

			AddItem( new NobleDress( 1172 ) );
			AddItem( new Sandals( 1172 ) );
		}

		public Therasa( Serial serial ): base( serial )
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