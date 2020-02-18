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

	public class MonsterParty : MLQuest
	{
		public MonsterParty()
		{
			Activated = true;
			Title = "Monster Party";
			OneTimeOnly = true;
			Description = "Forgive me, traveler. I need a favor of you. As you can see, Cactus Hub has come under heavy attack from the inhabitants of the Harashi Nabi. So we need you to stop those hideous monsters. I offer you my assistance, but there's no way in hell I wanna risk getting gobbled up by some stinky sand kraken. Be strong and swift when fighting the monsters. There's no need to kill all of them, just put the fear in them.";
			RefusalMessage = "Fine, I guess I'll just drink my sorrows away or something.";
			InProgressMessage = "I have little possessions left, but I'll reward you with what I have. Safe journey, hero. We believe in you.";
			CompletionNotice = "You have slain enough monsters. Return to Chester Benedict over at Cactus Hub";
			CompletionMessage = "Hmm, I've noticed things have died down here a bit. Congratulations on a job well job. Hopefully this place will become more active with mortals sometimes in the near future.";

			Objectives.Add( new KillObjective( 5, new Type[] { typeof( CharredSprite ) }, "charred sprites" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( CliffDiver ) }, "cliff divers" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( Jubokko ) }, "jubokko" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( RedbarkScorpion ) }, "redbark scorpions" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( SandBarracuda ) }, "sand barracudas" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	public class SnakesRattleAndRoll : MLQuest
	{
		public SnakesRattleAndRoll()
		{
			Activated = true;
			Title = "Snakes, Rattle And Roll";
			OneTimeOnly = true;
			Description = "Scuse me, traveler. Your assistance is required. We managed to push back the Ophidians and all who remain are hiding in the temples. We need you to infiltrate the temples and get rid of their barricades so our troops can move in. Kill any who stand in your way. There will be no place to hide for those vile serpents. I'm in no state to fight, but I know you'll manage without me. You are fully capable to handle those serpents. If you can, kill as many of them as possible. We want to live in peace and safety.";
			RefusalMessage = "What? You're kidding me!";
			InProgressMessage = "Should you succeed I will be able to repay you handsomely, it'll be worth your troubles. Justice will prevail hero and today you are our justice.";
			CompletionNotice = "You have slain enough ophidians. Return to ??? over at Cactus Hub";
			CompletionMessage = "Praise be to Eienyasil, you finally did it. That outta show them whose boss around here.";

			Objectives.Add( new KillObjective( 5, new Type[] { typeof( OphidianApprenticeMage ) }, "ophidian apprentice magi" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( OphidianEnforcer ) }, "ophidian enforcers" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( OphidianWarrior ) }, "ophidian warriors" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( OphidianJusticar ) }, "ophidian justicars" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( OphidianShaman ) }, "ophidian shamans" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( OphidianAvenger ) }, "ophidian avengers" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( OphidianKnightErrant) }, "ophidian knight-errants" ) );
			Objectives.Add( new KillObjective( 5, new Type[] { typeof( OphidianZealot ) }, "ophidian zealots" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.MLExperienceCheck2000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	#endregion

	#region Mobiles

	[QuesterName( "Chester Benedict (Cactus Hub)" )]
	public class ChesterBenedict : BaseCreature
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
		public ChesterBenedict(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Chester Benedict - (Monster Party)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33821;
                        HairItemID = 0;
                        HairHue = 0;
                        FacialHairItemID = 8268;
                        FacialHairHue = 1116;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new FancyRobe(148) );
			AddItem( new HeavyBoots(653) );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Movable = true;
			AddItem( gloves );

			CrystalStaff weapon = new CrystalStaff();
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );
		}

		public ChesterBenedict( Serial serial ): base( serial )
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

	[QuesterName( "Adrianna Torchwood (Cactus Hub)" )]
	public class AdriannaTorchwood : BaseCreature
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
		public AdriannaTorchwood(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Adrianna Torchwood - (Snakes Rattle And Roll)";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33785;
                        HairItemID = 8262;
                        HairHue = 1108;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new FeatheredHat(773) );
			AddItem( new VictorianDress(773) );
			AddItem( new HeavyBoots(778) );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 2130;
			gloves.Movable = true;
			AddItem( gloves );
		}

		public AdriannaTorchwood( Serial serial ): base( serial )
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