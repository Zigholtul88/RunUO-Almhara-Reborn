using System;
using Server;

namespace Server.Items
{
	public class WarriorSkillGuide : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Warrior Skills", "",

			new BookPageInfo
			(
				"Starting Skills",
				"- Anatomy",
				"- Fencing",
				"- Healing",
				"- Macing",
				"- Swordsmanship",
				"- Tactics",
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
				"-Fencing-",
				"Fencing weapons are used",
				"to stab'n'jab opponents,",
				"allowing the user to"
			),
			new BookPageInfo
			(
				"quickly attack while at",
				"the same time",
				"maintaining a defense.",
				"It is the best melee",
				"class available for use",
				"with Poisoning.",
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
				"-Mace Fighting-"
			),
			new BookPageInfo
			(
				"Mace Fighting is a skill",
				"that allows a practioner",
				"to use the Mace class of",
				"weapons. As with other",
				"offensive skills, a mace",
				"fighter is able to use",
				"the primary special move",
				"with Macing skill at 70"
			),
			new BookPageInfo
			(
				"and Tactics skill at 30",
				"and the secondary",
				"special move with Macing",
				"skill at 90 and Tactics",
				"skill at 60. A macer's",
				"professional title is",
				"Armsman.",
				""
			),
			new BookPageInfo
			(
				"In PvP combat, mace",
				"weapons are valued",
				"because they always",
				"damage an opponent's",
				"armor when a hit is",
				"scored. Such weapons",
				"also do a small amount",
				"of additional damage to"
			),
			new BookPageInfo
			(
				"a target's Stamina when",
				"hit.",
				"",
				"Weapons",
				"Simply put, mace class",
				"weapons are designed to",
				"crush (or at least",
				"bruise) your opponents."
			),
			new BookPageInfo
			(
				"Sometimes spikes are",
				"added in order to cause",
				"additional flesh wounds.",
				"",
				"They deal an extra hit",
				"to the stamina level of",
				"targets, while also",
				"lowering the durability"
			),
			new BookPageInfo
			(
				"of their armor at an",
				"accelerated rate.",
				"",
				"Note that as the",
				"Tinkering skill has no",
				"Runic Tools, the items",
				"it produces are seldom",
				"used as primary weapons"
			),
			new BookPageInfo
			(
				"in combat.",
				"",
				"Poisoning cannot be used",
				"with mace fighting.",
				"",
				"",
				"-Swordsmanship-",
				"The fine art of"
			),
			new BookPageInfo
			(
				"Swordsmanship is a skill",
				"to be admired. Employing",
				"neither the",
				"wallop-on-the-head",
				"approach of the mace",
				"fighter, nor the",
				"pinging, poking thrust",
				"of the fencer, the"
			),
			new BookPageInfo
			(
				"swordsman knows the",
				"near-silent whistle of",
				"polished metal slicing",
				"the air — and other,",
				"less vaporous things…",
				"",
				"The benefit from",
				"increased levels of"
			),
			new BookPageInfo
			(
				"swordsmanship is a",
				"greater chance to hit",
				"your target. Other melee",
				"factors, like damage and",
				"swing speed, are",
				"governed by other",
				"statistics, in this",
				"instance strength and"
			),
			new BookPageInfo
			(
				"dexterity, respectively.",
				"This skill also counts",
				"towards your ability to",
				"perform Special Moves.",
				"",
				"Weapons",
				"The standard sword class",
				"of weapons are primarily"
			),
			new BookPageInfo
			(
				"designed to chop and",
				"slice opponents.",
				"",
				"Another exclusive bonus",
				"to Swordsmen is the Axe",
				"weapon class. These add",
				"an additional Damage",
				"Increase bonus dependant"
			),
			new BookPageInfo
			(
				"on your character's",
				"Lumberjacking skill.",
				"",
				"Note that as the",
				"Tinkering skill has no",
				"Runic Tools, the items",
				"it produces are seldom",
				"used as primary weapons"
			),
			new BookPageInfo
			(
				"in combat. On the other",
				"hand, the only swords",
				"which may be used with",
				"the Poisoning skill are",
				"created by Tinkers (the",
				"Butcher Knife and the",
				"Cleaver). ",
				""
			),
			new BookPageInfo
			(
				"",
				"-Tactics-",
				"Your level of Tactics",
				"determines how much of",
				"your Base Damage you are",
				"capable of inflicting on",
				"opponents. The",
				"percentage is equal to"
			),
			new BookPageInfo
			(
				"your skill plus + 50%",
				"(for example, at 120",
				"skill points you will",
				"deal 170% of your base",
				"damage, while a fighter",
				"with no skill will only",
				"deal 50%).",
				""
			),
			new BookPageInfo
			(
				"Instead of using Tactics",
				"to determine their spell",
				"damage levels, mages",
				"instead use the",
				"Evaluating Intelligence",
				"skill.",
				"",
				"This skill is necessary"
			),
			new BookPageInfo
			(
				"to perform most Special",
				"Moves. It does not count",
				"toward lowering their",
				"stamina requirements,",
				"however.",
				"",
				"Training",
				"Tactics can be gained"
			),
			new BookPageInfo
			(
				"anytime an opponent is",
				"hit with a weapon or",
				"fist. Once training of",
				"either Fencing, Mace",
				"Fighting, Swordsmanship,",
				"Archery or Wrestling is",
				"completed, Tactics will",
				"usually be very close or"
			),
			new BookPageInfo
			(
				"at the level you want.",
				"To finish training just",
				"keep fighting as you",
				"were."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public WarriorSkillGuide() : base( 0x1C13, false )
		{
			Weight = 0.0;
			LootType = LootType.Blessed;
		}

		public WarriorSkillGuide( Serial serial ) : base( serial )
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