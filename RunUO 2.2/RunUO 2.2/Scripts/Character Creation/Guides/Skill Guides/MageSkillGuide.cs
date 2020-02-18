using System;
using Server;

namespace Server.Items
{
	public class MageSkillGuide : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Mage Skills", "",

			new BookPageInfo
			(
				"Starting Skills",
				"- Alchemy",
				"- Evaluating Int",
				"- Inscription",
				"- Magery",
				"- Meditation",
				"",
				""
			),
			new BookPageInfo
			(
				"-Alchemy-",
				"Alchemists in Ultima",
				"Online do not turn lead",
				"into gold; instead, they",
				"create magic potions",
				"using materials called",
				"reagents that can easily",
				"be bought from vendors"
			),
			new BookPageInfo
			(
				"or found inside various",
				"barrels, crates and",
				"other containers. High",
				"level Alchemists can",
				"learn Glassblowing.",
				"",
				"As your skill improves",
				"you gain a Enhance"
			),
			new BookPageInfo
			(
				"Potions bonus of 10% for",
				"every 33 skill points",
				"achieved (30% at GM).",
				"This is on top of any",
				"bonus given by your",
				"equipment and hence not",
				"subject to your",
				"equipment cap (granting"
			),
			new BookPageInfo
			(
				"you a maximum benefit of",
				"80%).",
				"",
				"Trained alchemists can",
				"identify the contents of",
				"Potion Kegs by removing",
				"a potion from them. Once",
				"checked in this way, the"
			),
			new BookPageInfo
			(
				"potion type becomes",
				"visible to all players.",
				"",
				"",
				"-Evaluating Int-",
				"Evaluating Intelligence",
				"can be used to determine",
				"the amount of Mana an"
			),
			new BookPageInfo
			(
				"opponent has left. It",
				"also affects various",
				"Magery spells, altering",
				"spell damage (similar to",
				"how Tactics increases",
				"damage dealt in standard",
				"combat) or the",
				"effectiveness/duration"
			),
			new BookPageInfo
			(
				"of a spell. It also has",
				"a role in defense when",
				"coupled with Anatomy.",
				"",
				"Using",
				"Evaluating Intelligence",
				"has three uses: showing",
				"information about a"
			),
			new BookPageInfo
			(
				"target, spell damage",
				"calculation and a",
				"defensive mechanism.",
				"",
				"Reading Mana Level",
				"When using the skill and",
				"targeting a creature or",
				"player, it will give you"
			),
			new BookPageInfo
			(
				"the percentage of",
				"remaining mana the",
				"target has. Furthermore,",
				"an estimate of their",
				"overall intelligence is",
				"given.",
				"",
				"Spell Damage"
			),
			new BookPageInfo
			(
				"Evaluating Intelligence",
				"is mostly used for its",
				"ability to increase the",
				"damage and effectiveness",
				"of Magery spells. When",
				"you cast a spell, the",
				"potential damage is",
				"calculated based on"
			),
			new BookPageInfo
			(
				"several factors, such as",
				"the spell, its circle,",
				"your ability, etc. (call",
				"this base damage). The",
				"damage then gets scaled",
				"based on the mage’s",
				"Evaluate Intelligence.",
				"Evaluate Intelligence"
			),
			new BookPageInfo
			(
				"has a factor of between",
				"1 (0 Eval Int) and 4.6",
				"(120 Eval Int). See the",
				"discussion at Spell",
				"Damage Increase. There",
				"are 3 formulas: direct",
				"damage spells, positive",
				"buff (bless, strength,"
			),
			new BookPageInfo
			(
				"etc.) spells and",
				"negative 'buff' (weaken,",
				"feeble mind, curse,",
				"etc.) spells. (Summons,",
				"Resurrection, Mind Blast",
				"and Poison are not",
				"affected by Evaluate",
				"Intelligence.)"
			),
			new BookPageInfo
			(
				"",
				"- Direct Damage Formula:",
				"total damage = ( base",
				"damage * ( 3 *",
				"Evaluating Intelligence",
				"/ 100 + 1 )",
				"- Positive 'buff' Spell",
				"Formula: Final Positive"
			),
			new BookPageInfo
			(
				"Stat = Base Stat * ( 1 +",
				"( 1 + Evaluating",
				"Intelligence / 10 ) /",
				"100 )",
				"- Negative 'buff' Spell",
				"Formula: Final Negative",
				"Stat = Base Stat * ( 1 -",
				"( 8 + ( ( Caster's"
			),
			new BookPageInfo
			(
				"Evaluate Intelligence -",
				"Target's Resist Spells )",
				"/ 10 ) ) / 100 )",
				"",
				"Example of the damage",
				"factor done for direct",
				"damage spells at various",
				"Evaluate Intelligence"
			),
			new BookPageInfo
			(
				"values:",
				"",
				"- Eval int = 0, damage",
				"done is the base (factor",
				"of 1)",
				"- Eval int = 33.4,",
				"damage done is",
				"approximately doubled"
			),
			new BookPageInfo
			(
				"(factor of 2.002)",
				"- Eval int = 66.7,",
				"damage done is",
				"approximately tripled",
				"(factor of 3.001)",
				"- Eval int = 100, damage",
				"done is quadrupled",
				"(factor of 4)"
			),
			new BookPageInfo
			(
				"- Eval int = 120, damage",
				"done is a little over 4",
				"1/2 (factor of 4.6)",
				"",
				"Example of a positive",
				"'buff' spell: Suppose",
				"the caster has 100 Eval",
				"Int. The target has 110"
			),
			new BookPageInfo
			(
				"strength. Cast",
				"'Strength'.",
				"",
				"- Final Positive Stat =",
				"110 * ( 1 + ( 1 + ( 100",
				"/ 10 ) ) / 100 ) )",
				"- Final Positive Stat =",
				"110 * 1.11 = 122"
			),
			new BookPageInfo
			(
				"resulting temporary",
				"strength (any decimal is",
				"dropped)",
				"",
				"Example of a negative",
				"'buff' spell: Suppose",
				"the caster has 100 Eval",
				"Int. The target has 50"
			),
			new BookPageInfo
			(
				"Resisting Spells. Cast",
				"'Weaken'. Target has 100",
				"Strength.",
				"",
				"- Final Negative Stat =",
				"100 * ( 1 - ( 8 + ( (",
				"100 - 50 ) / 10 ) ) /",
				"100 )"
			),
			new BookPageInfo
			(
				"- Total negative buff =",
				"100 * ( .87 ) = 87",
				"resulting temporary",
				"strength",
				"",
				"Defensive Ability",
				"",
				"When combined with"
			),
			new BookPageInfo
			(
				"Anatomy, these two",
				"skills can be used to",
				"replace Wrestling or",
				"other melee skills for",
				"defense. Anatomy and",
				"Evaluate Intelligence",
				"need to add up to 220 to",
				"have the equivalent of"
			),
			new BookPageInfo
			(
				"120 melee defensive",
				"ability. The result of",
				"the following formula is",
				"capped at 120, so having",
				"120 in both skills does",
				"not give a greater",
				"benefit.",
				""
			),
			new BookPageInfo
			(
				"- Formula: ( Evaluating",
				"Intelligence + Anatomy +",
				"20 ) / 2",
				"",
				"Training and Tips",
				"",
				"Active",
				"Activate the skill by"
			),
			new BookPageInfo
			(
				"macro or skill button",
				"and target a creature or",
				"player. If you don't get",
				"a gain, find a new",
				"target. If you do get a",
				"gain you can use that",
				"target and all",
				"proceeding ones again to"
			),
			new BookPageInfo
			(
				"try and gain.",
				"",
				"Passive",
				"Each cast of a Magery",
				"spell has a chance to",
				"gain. Training magery",
				"skill to the desired",
				"level while having"
			),
			new BookPageInfo
			(
				"Evaluate Intelligence",
				"raise passively is the",
				"preferred method. Once",
				"Magery is done training,",
				"repeatedly casting",
				"Reactive Armor is the",
				"most effective means.",
				"Wear a suit with 40%"
			),
			new BookPageInfo
			(
				"Lower Mana Cost and as",
				"much Mana Regeneration",
				"as you can. Such passive",
				"gains of Evaluate",
				"Intelligence can occur",
				"even when casting a",
				"magery spell fails",
				"(fizzles) and with"
			),
			new BookPageInfo
			(
				"magery spells which are",
				"not influenced by",
				"Evaluate Intelligence",
				"(for example Mind",
				"Blast). If the goal is",
				"to raise Resisting",
				"Spells while completing",
				"Evaluate Intelligence,"
			),
			new BookPageInfo
			(
				"then casting Weaken,",
				"Clumsy or Feeblemind on",
				"yourself are good",
				"choices, these will",
				"raise both skills. You",
				"may wish to set and lock",
				"your magery at 0 while",
				"training eval."
			),
			new BookPageInfo
			(
				"",
				"",
				"-Inscription-",
				"In order to copy a spell",
				"to Scroll form, you need",
				"to be carrying a",
				"spellbook which already",
				"contains that spell."
			),
			new BookPageInfo
			(
				"When a scribe crafts a",
				"spellbook there is a",
				"chance it will get up to",
				"3 magical properties.",
				"These properties can be",
				"Faster Casting, Faster",
				"Cast Recovery, Lower",
				"Mana Cost, Lower Reagent"
			),
			new BookPageInfo
			(
				"Cost, Mana Increase,",
				"Mana Regeneration, Spell",
				"Damage Increase,",
				"Intelligence Bonus and",
				"some mage related",
				"Skills(Magery, Eval.",
				"Int., Meditation and",
				"Resist). All the"
			),
			new BookPageInfo
			(
				"properties can be up to",
				"80% of the intensity",
				"range they normally",
				"spawn in. The amount and",
				"intensity of the",
				"properties on a",
				"spellbook depends on",
				"your Magery skill. At 80"
			),
			new BookPageInfo
			(
				"Magery you can get 1",
				"property, at 90 Magery",
				"you can get 2 properties",
				"and at 100 Magery you",
				"can get 3 properties. At",
				"110 and 120 Magery you",
				"can still only get 3",
				"properties, but you will"
			),
			new BookPageInfo
			(
				"have a higher chance of",
				"getting them.",
				"",
				"A GM Scribe gains a +10%",
				"Spell Damage Increase to",
				"any Magery spells cast",
				"and an additional 5%",
				"bonus to Casting Focus"
			),
			new BookPageInfo
			(
				"which can exceed the",
				"item cap.",
				"",
				"Caster's inscription",
				"skill also affects",
				"following spells:",
				"- Protection: Allows you",
				"to cast spells without"
			),
			new BookPageInfo
			(
				"being interrupted.",
				"  Lowers physical",
				"resistance 15% -",
				"(Inscription/20). At GM",
				"inscription, Physical",
				"lowers 10%. ",
				"  Lowers resist magic",
				"skill 35% -"
			),
			new BookPageInfo
			(
				"(Inscription/20). At GM",
				"Inscription, Resist",
				"lowers 30%",
				"  Increases spell",
				"casting delay. (",
				"Inscription has no",
				"effect here )",
				"- Reactive Armor:"
			),
			new BookPageInfo
			(
				"Increases Physical",
				"Resistance ( +15% +",
				"Inscription/20 ) ,",
				"decreases elemental",
				"resistances (-5% each).",
				"    With 0 Inscription",
				"(+15 , -5 , -5 , -5 ,-5)",
				"    At GM Inscription"
			),
			new BookPageInfo
			(
				"(+20 , -5 ,-5 , -5 , -5)",
				"",
				"- Magic Reflection:",
				"Decreases Physical",
				"Resistance ( -20% +",
				"Inscription/20 ),",
				"increases elemental",
				"resistances ( +10%"
			),
			new BookPageInfo
			(
				"each).",
				"    With 0 Inscription",
				"(-20 , +10 , +10 , +10 ,",
				"+10 and -5 max physical",
				"resist)",
				"    At GM Inscription",
				"(-15 , +10 , +10 , +10 ,",
				"+10 and -5 max physical"
			),
			new BookPageInfo
			(
				"resist)",
				"",
				"It should be noted that",
				"the Jack of All Trades",
				"for humans works as if",
				"they had 20 Inscription",
				"skill points.",
				""
			),
			new BookPageInfo
			(
				"",
				"-Magery-",
				"Throw a fireball here, a",
				"lightning bolt there,",
				"and add a summoned",
				"daemon for good measure.",
				"Those who study the",
				"magical arts within"
			),
			new BookPageInfo
			(
				"Almhara may not be adept",
				"with a sword and shield,",
				"but few can surpass the",
				"power of a learned mage.",
				"",
				"Spells",
				"There are eight circles",
				"of eight spells, each"
			),
			new BookPageInfo
			(
				"circle taking more",
				"skill, mana and time to",
				"cast than the previous",
				"circle. The casting time",
				"of a spell is determined",
				"by the circle number.",
				"The formula is 0.25 +",
				"spell circle * 0.25"
			),
			new BookPageInfo
			(
				"seconds. ",
				"",
				"",
				"-Meditation-",
				"Mana, the powerful",
				"substance used in",
				"casting spells from",
				"scrolls or spellbooks,"
			),
			new BookPageInfo
			(
				"as well as in the",
				"practice of Inscription,",
				"is as rich as gold to",
				"any who use its power on",
				"a daily basis. The",
				"Meditation skill allows",
				"your character to",
				"increase the rate at"
			),
			new BookPageInfo
			(
				"which they regenerate",
				"mana.",
				"",
				"Although simply having",
				"some ability in",
				"meditation is enough to",
				"improve your",
				"regenerative rate, you"
			),
			new BookPageInfo
			(
				"may also invoke the",
				"skill directly. If",
				"successful at active",
				"meditation then your",
				"overall regeneration",
				"rate will double, that",
				"is until you perform ANY",
				"action other then"
			),
			new BookPageInfo
			(
				"party/guild chat or are",
				"attacked. An invis'ed or",
				"hidden character will be",
				"revealed if he or she",
				"actively meditates.",
				"",
				"A character receives",
				"neither passive nor"
			),
			new BookPageInfo
			(
				"active Meditation",
				"bonuses while wearing",
				"non-medable armor unless",
				"it has Mage Armor as an",
				"item property. Many",
				"warriors instead take up",
				"the Focus skill, which",
				"has similar effects to"
			),
			new BookPageInfo
			(
				"Meditation but no",
				"armor-based limitations.",
				"Formulas",
				"",
				"A character's mana",
				"regeneration is governed",
				"by the skills of",
				"Meditation and Focus,"
			),
			new BookPageInfo
			(
				"the Intelligence stat,",
				"and any Mana",
				"Regeneration items that",
				"are equiped.",
				"",
				"The following Mana",
				"Regeneration formulas",
				"illustrate the rate of"
			),
			new BookPageInfo
			(
				"regeneration from",
				"Meditation and",
				"Intelligence. For a full",
				"discussion of the",
				"subject, however, please",
				"see the main article on",
				"Mana Regeneration.",
				"- Rate from Med & Int ="
			),
			new BookPageInfo
			(
				"2 + (Meditation * 3 +",
				"Intelligence) / 40",
				"If you have a skill of",
				"100 or better in",
				"Meditation you get a 10%",
				"bonus, making the GM+",
				"formula:",
				"- GM Rate from Med & Int"
			),
			new BookPageInfo
			(
				"= 2 + (1.1 * (Meditation",
				"* 3 + Intelligence) /",
				"40)",
				"",
				"Training",
				"",
				"Active",
				"Each time the Meditation"
			),
			new BookPageInfo
			(
				"skill is activated via",
				"macro or skill button",
				"you have a chance to",
				"gain.",
				"",
				"Passive",
				"Each time 1 mana is",
				"regenerated Meditation"
			),
			new BookPageInfo
			(
				"has a chance to gain. It",
				"is most effective to",
				"keep your mana",
				"constantly below maximum",
				"if you are actively",
				"trying to train",
				"Meditation."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public MageSkillGuide() : base( 0x1C13, false )
		{
			Weight = 0.0;
			LootType = LootType.Blessed;
		}

		public MageSkillGuide( Serial serial ) : base( serial )
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