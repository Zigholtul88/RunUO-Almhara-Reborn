using System;
using Server;

namespace Server.Items
{
	public class RangerSkillGuide : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Ranger Skills", "",

			new BookPageInfo
			(
				"Starting Skills",
				"- Anatomy",
				"- Archery",
				"- Fletching",
				"- Healing",
				"- Tactics",
				"",
				""
			),
			new BookPageInfo
			(
				"-Anatomy-",
				"Anatomy can be used in",
				"three ways:",
				"",
				"1. Passively increases",
				"the combat damage you",
				"deal.",
				"2. Passively adds amount"
			),
			new BookPageInfo
			(
				"healed to yourself,",
				"NPC's, or other players.",
				"3. Actively check the",
				"Dexterity and Strength",
				"of another player,",
				"animal, or monster.",
				"",
				"It formally belonged in"
			),
			new BookPageInfo
			(
				"the Useless Skill group",
				"until it was linked to",
				"Healing and Damage",
				"Bonuses.",
				"",
				"You will also receive a",
				"bonus to the Evasion",
				"ability if your Anatomy"
			),
			new BookPageInfo
			(
				"is 100.0 or better.",
				"",
				"Damage Increase",
				"- Damage Increase is",
				"added to your Damage",
				"Calculations.",
				"- The Damage Bonus % =",
				"anatomy / 2 (+ 5% if"
			),
			new BookPageInfo
			(
				"anatomy at 100.0 or",
				"higher)",
				"",
				"Healing",
				"- Anatomy adds to the",
				"amount you can heal.",
				"- The Healing Bonus % =",
				"anatomy / 6 "
			),
			new BookPageInfo
			(
				"",
				"To Cure poisonings with",
				"Bandages you need 60",
				"anatomy, and to",
				"Resurrect you need 80.",
				"",
				"Training",
				""
			),
			new BookPageInfo
			(
				"- Active",
				"Activate the skill via",
				"macro or skill button",
				"and target a creature",
				"other than yourself.",
				"",
				"- Passive",
				"Each time you hit a"
			),
			new BookPageInfo
			(
				"creature with a weapon",
				"or fists you have a",
				"chance to gain Anatomy.",
				"This is the preferred",
				"method of training the",
				"skill, requiring less",
				"effort and time. You can",
				"also gain anatomy"
			),
			new BookPageInfo
			(
				"passively when using the",
				"Healing skill.",
				"",
				"",
				"-Archery-",
				"",
				"Weapons",
				"There are two main types"
			),
			new BookPageInfo
			(
				"of weapons available to",
				"practitioners of",
				"Archery, bows and",
				"crossbows. The former",
				"require a good supply of",
				"Arrows on hand, while",
				"the more technical",
				"crossbows fire smaller"
			),
			new BookPageInfo
			(
				"Bolts at enemies. All of",
				"these can be crafted by",
				"Bowyers.",
				"",
				"Bows are typically",
				"slightly faster to fire",
				"then crossbows and also",
				"usually offer a larger"
			),
			new BookPageInfo
			(
				"attacking radius. On the",
				"other hand, crossbows",
				"often pack more punch",
				"per bolt and so might be",
				"the better choice for a",
				"lengthy battle.",
				"",
				"The Elven Composite"
			),
			new BookPageInfo
			(
				"Longbow is the only",
				"Archery class weapon",
				"that can be used with",
				"Poisoning (via Serpent",
				"Arrow).",
				"",
				"While not technically a",
				"weapon, it's worth"
			),
			new BookPageInfo
			(
				"mentioning that any",
				"archer worth his or her",
				"salt will be carrying a",
				"Quiver with them.",
				"",
				"All Archery weapons are",
				"Two-Handed Weapons,",
				"unless they have the"
			),
			new BookPageInfo
			(
				"Balanced property. For",
				"this reason, when",
				"crafting with Runic",
				"Tools, you might",
				"consider the Lightweight",
				"Shortbow.",
				"",
				""
			),
			new BookPageInfo
			(
				"-Healing-",
				"Healing lets you restore",
				"hit points on yourself",
				"or other players by",
				"using Bandages. When",
				"combined with the",
				"Anatomy skill, you will",
				"heal more and gain the"
			),
			new BookPageInfo
			(
				"abilities to cure Poison",
				"and Resurrect other",
				"players.",
				"",
				"Applying bandages takes",
				"time, and your chances",
				"of success fall as you",
				"take further damage. A"
			),
			new BookPageInfo
			(
				"higher Healing skill can",
				"allow you to ignore",
				"outside interference.",
				"",
				"Although similar to the",
				"Veterinary skill,",
				"healing will not allow",
				"you to aid Animals or"
			),
			new BookPageInfo
			(
				"Monsters.",
				"",
				"Details",
				"- At 60.0 skill in",
				"Anatomy and Healing you",
				"will be able to cure",
				"poison.",
				"- At 80.0 skill in"
			),
			new BookPageInfo
			(
				"Anatomy and Healing you",
				"will be able to",
				"resurrect dead players.",
				"- As of Publish 71, with",
				"80 skill or greater in",
				"Healing and Anatomy, at",
				"half the Heal Duration",
				"for self heals, healing"
			),
			new BookPageInfo
			(
				"will attempt to remove",
				"poison and bleed",
				"effects. This will",
				"reduce the amount healed",
				"when the heal is",
				"finished its normal",
				"duration.",
				"- Bleed is treated as"
			),
			new BookPageInfo
			(
				"Level 3 Poison.",
				"- Time to heal is based",
				"on your Dexterity. Slip",
				"damage also scales based",
				"on Dexterity.",
				"",
				"",
				"-Tactics-"
			),
			new BookPageInfo
			(
				"Your level of Tactics",
				"determines how much of",
				"your Base Damage you are",
				"capable of inflicting on",
				"opponents. The",
				"percentage is equal to",
				"your skill plus + 50%",
				"(for example, at 120"
			),
			new BookPageInfo
			(
				"skill points you will",
				"deal 170% of your base",
				"damage, while a fighter",
				"with no skill will only",
				"deal 50%).",
				"",
				"Instead of using Tactics",
				"to determine their spell"
			),
			new BookPageInfo
			(
				"damage levels, mages",
				"instead use the",
				"Evaluating Intelligence",
				"skill.",
				"",
				"This skill is necessary",
				"to perform most Special",
				"Moves. It does not count"
			),
			new BookPageInfo
			(
				"toward lowering their",
				"stamina requirements,",
				"however.",
				"",
				"Training",
				"Tactics can be gained",
				"anytime an opponent is",
				"hit with a weapon or"
			),
			new BookPageInfo
			(
				"fist. Once training of",
				"either Fencing, Mace",
				"Fighting, Swordsmanship,",
				"Archery or Wrestling is",
				"completed, Tactics will",
				"usually be very close or",
				"at the level you want.",
				"To finish training just"
			),
			new BookPageInfo
			(
				"keep fighting as you",
				"were."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public RangerSkillGuide() : base( 0x1C13, false )
		{
			Weight = 0.0;
			LootType = LootType.Blessed;
		}

		public RangerSkillGuide( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}
	}
}