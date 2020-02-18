using System;
using Server;

namespace Server.Items
{
	public class VeterinarySkillGuide : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Veterinary Skills", "",

			new BookPageInfo
			(
				"Starting Skills",
				"- Animal Lore",
				"- Animal Taming",
				"- Healing",
				"- Herding",
				"- Musicianship",
				"- Peacemaking",
				"- Veterinary"
			),
			new BookPageInfo
			(
				"",
				"-Animal Lore-",
				"Animal Lore affects your",
				"ability to control a",
				"tamed creature, and also",
				"improves the amount of",
				"damage you can heal via",
				"the Veterinary skill."
			),
			new BookPageInfo
			(
				"",
				"Using the skill directly",
				"on a tamed creature",
				"shows you a listing of",
				"its stats, resists,",
				"skills and elemental",
				"damage distribution. At",
				"100 skill points you may"
			),
			new BookPageInfo
			(
				"target untamed animals",
				"as well, and at 110 you",
				"may view information",
				"about untamed monsters.",
				"",
				"Animal Lore also counts",
				"towards your total",
				"stable slot limit."
			),
			new BookPageInfo
			(
				"",
				"Training",
				"",
				"Active",
				"Activate the skill via",
				"macro or skill button",
				"and target a creature.",
				"You can gain from"
			),
			new BookPageInfo
			(
				"repeating upon the same",
				"creature.",
				"",
				"Passive",
				"Animal Lore can also be",
				"raised by using the",
				"Animal Taming and",
				"Veterinary skills. Using"
			),
			new BookPageInfo
			(
				"veterinary on a tamed",
				"pet and getting a",
				"passive gain is the",
				"preferred method of",
				"training. Once you get",
				"one passive gain, lock",
				"Veterinary and keep",
				"vetting your pet for"
			),
			new BookPageInfo
			(
				"endless gains.",
				"",
				"",
				"-Animal Taming-",
				"To tame a beast to",
				"accept you as master",
				"requires patience, nerve",
				"and a power of will. The"
			),
			new BookPageInfo
			(
				"rewards of studying",
				"Animal Taming are",
				"considered by some to be",
				"well worth the time",
				"invested. Tamers have",
				"long-been considered",
				"extremely useful and",
				"versatile in fighting"
			),
			new BookPageInfo
			(
				"monsters and, to a",
				"lesser extent, players",
				"as well.",
				"",
				"Your taming skill (along",
				"with Animal Lore)",
				"determines the odds of",
				"taming a given creature"
			),
			new BookPageInfo
			(
				"then controlling it.",
				"It's furthermore",
				"required in order to",
				"bond with certain",
				"creatures, and also",
				"plays a hand in",
				"determining your stable",
				"slot limit."
			),
			new BookPageInfo
			(
				"",
				"In order to tame a",
				"creature you must be",
				"standing within three",
				"tiles of it with no",
				"obstructions, then",
				"target it with the",
				"skill. Once taming has"
			),
			new BookPageInfo
			(
				"begun you may stray",
				"anywhere up to ten tiles",
				"away from the target",
				"though if it loses sight",
				"of you or is injured in",
				"any way the attempt will",
				"cease.",
				""
			),
			new BookPageInfo
			(
				"After a few seconds",
				"you'll be notified of",
				"either your success or",
				"failure.",
				"",
				"While most animals are",
				"non-hostile and can be",
				"tamed at any time, most"
			),
			new BookPageInfo
			(
				"taming attempts against",
				"a monster will instantly",
				"fail. In this case",
				"there's no wait time",
				"before you can try again",
				"so it's best to set a",
				"macro and use this over",
				"and over as fast as you"
			),
			new BookPageInfo
			(
				"can until you",
				"successfully start the",
				"taming process.",
				"",
				"Veterinary is a near",
				"essential skill for",
				"serious tamers in that",
				"it is the only method"
			),
			new BookPageInfo
			(
				"available for",
				"resurrecting dead pets.",
				"",
				"",
				"-Healing-",
				"Healing lets you restore",
				"hit points on yourself",
				"or other players by"
			),
			new BookPageInfo
			(
				"using Bandages. When",
				"combined with the",
				"Anatomy skill, you will",
				"heal more and gain the",
				"abilities to cure Poison",
				"and Resurrect other",
				"players.",
				""
			),
			new BookPageInfo
			(
				"Applying bandages takes",
				"time, and your chances",
				"of success fall as you",
				"take further damage. A",
				"higher Healing skill can",
				"allow you to ignore",
				"outside interference.",
				""
			),
			new BookPageInfo
			(
				"Although similar to the",
				"Veterinary skill,",
				"healing will not allow",
				"you to aid Animals or",
				"Monsters.",
				"",
				"Details",
				"- At 60.0 skill in"
			),
			new BookPageInfo
			(
				"Anatomy and Healing you",
				"will be able to cure",
				"poison.",
				"- At 80.0 skill in",
				"Anatomy and Healing you",
				"will be able to",
				"resurrect dead players.",
				"- As of Publish 71, with"
			),
			new BookPageInfo
			(
				"80 skill or greater in",
				"Healing and Anatomy, at",
				"half the Heal Duration",
				"for self heals, healing",
				"will attempt to remove",
				"poison and bleed",
				"effects. This will",
				"reduce the amount healed"
			),
			new BookPageInfo
			(
				"when the heal is",
				"finished its normal",
				"duration.",
				"- Bleed is treated as",
				"Level 3 Poison.",
				"- Time to heal is based",
				"on your Dexterity. Slip",
				"damage also scales based"
			),
			new BookPageInfo
			(
				"on Dexterity.",
				"",
				"",
				"-Herding-",
				"Herding allows players",
				"to direct the movement",
				"of any tamable creature.",
				"They can either be moved"
			),
			new BookPageInfo
			(
				"to a specific location",
				"or made to follow your",
				"character indefinitely.",
				"Unlike conventional pets",
				"there is no known limit",
				"to the amount of herded",
				"creatures you may have",
				"following you at one"
			),
			new BookPageInfo
			(
				"time, though they won't",
				"travel with you through",
				"moongates.",
				"",
				"Herded monsters may",
				"still decide to attack",
				"nearby characters,",
				"however it is possible"
			),
			new BookPageInfo
			(
				"to herd while remaining",
				"hidden. A stealthing",
				"character can",
				"potentially escort a",
				"very large group of",
				"dangerous monsters",
				"(though their movements",
				"will likely give away"
			),
			new BookPageInfo
			(
				"his location to nearby",
				"players).",
				"",
				"Your chance of success",
				"when giving an order is",
				"equal to that of your",
				"current skill level. The",
				"taming difficulty of"
			),
			new BookPageInfo
			(
				"your target creature has",
				"no effect and there is",
				"no wait time between",
				"attempts.",
				"",
				"Area effect peacemaking",
				"will stop creatures from",
				"following you."
			),
			new BookPageInfo
			(
				"",
				"Use",
				"To use your Herding",
				"skill to herd animals:",
				"- Place a Shepherd's",
				"Crook in your hand, or",
				"your pack.",
				"- Double-click the"
			),
			new BookPageInfo
			(
				"crook.",
				"- Target the animal you",
				"wish to herd.",
				"- Target the location",
				"you wish the animal to",
				"move toward.",
				"- If you target yourself",
				"the animal will follow"
			),
			new BookPageInfo
			(
				"you.",
				"",
				"If successful, the",
				"animal moves in the",
				"direction you intend.",
				"The Herding system",
				"messages are as follows:",
				"- Which animal do you"
			),
			new BookPageInfo
			(
				"wish to heard?",
				"- You don't seem able to",
				"pursuade that to move.",
				"- Click to where you",
				"wish the animal to go.",
				"- The animal walks to",
				"where instructed to.",
				"- The animal begins to"
			),
			new BookPageInfo
			(
				"follow you.",
				"",
				"",
				"-Musicianship-",
				"Strum a lute, bang on a",
				"drum or rattle a",
				"tambourine. Without a",
				"bit of skill in"
			),
			new BookPageInfo
			(
				"Musicianship, you’ll",
				"likely send your",
				"audience screaming away",
				"from, or worse toward",
				"you.",
				"",
				"Musicianship is the core",
				"Bard-themed skill. It is"
			),
			new BookPageInfo
			(
				"required for any of the",
				"other Bard-related",
				"skills to even have a",
				"chance of success. A",
				"modest level of",
				"Musicianship is also",
				"required for a Carpenter",
				"to be able to produce"
			),
			new BookPageInfo
			(
				"musical instruments,",
				"which feature a 10%",
				"success bonus over",
				"NPC-purchased musical",
				"instruments.",
				"",
				"While it does little on",
				"it's own aside from"
			),
			new BookPageInfo
			(
				"producing either fine",
				"music or fat-fingered",
				"cacophony, it's level is",
				"a key factor when",
				"attempting to perform",
				"the other Bard skills,",
				"namely Provocation,",
				"Discordance or"
			),
			new BookPageInfo
			(
				"Peacemaking in",
				"conjunction with a",
				"target's Barding",
				"Difficulty.",
				"",
				"Luckily for this class",
				"you're already maxed",
				"out, so no need to worry"
			),
			new BookPageInfo
			(
				"about pointless grinding",
				"in order to actually be",
				"able to use the",
				"abilities associated",
				"with this class.",
				"",
				"",
				"-Peacemaking-"
			),
			new BookPageInfo
			(
				"The Peacemaking skill is",
				"one of the Bard-themed",
				"skills and is sometimes",
				"called Peacing for",
				"short. In a nutshell,",
				"the soothing music of a",
				"successful attempt",
				"causes those to whom it"
			),
			new BookPageInfo
			(
				"is directed to relax and",
				"stop fighting. To",
				"successfully be able to",
				"use this skill also",
				"requires some level of",
				"Musicianship skill as",
				"well. While a useful",
				"skill for a Bard in it's"
			),
			new BookPageInfo
			(
				"own right, it is also",
				"valuable to possess, or",
				"assist other players",
				"with, when it comes to",
				"Animal Taming or",
				"Treasure Hunting.",
				"",
				"Peacemaking skill has"
			),
			new BookPageInfo
			(
				"two different modes,",
				"Area Peacemaking and",
				"Targeted Peacemaking.",
				"",
				"Area Peacemaking",
				"",
				"Activate the skill via",
				"macro or skill button"
			),
			new BookPageInfo
			(
				"and target yourself. If",
				"successful, all",
				"aggression in the area",
				"will cease for a few",
				"moments. Players will",
				"have to re-attack their",
				"targets.",
				""
			),
			new BookPageInfo
			(
				"Targeted Peacemaking",
				"",
				"Activate the skill via",
				"macro or skill button",
				"and target a creature.",
				"If successful, the",
				"targeted creature will",
				"either remain"
			),
			new BookPageInfo
			(
				"non-aggressive or stop",
				"attacking it's target",
				"until a sufficient",
				"attack upon it breaks",
				"the trance or the bard",
				"loses line of sight for",
				"more than 10 seconds.",
				""
			),
			new BookPageInfo
			(
				"Each time Targeted",
				"Peacemaking is",
				"attempted, a difficulty",
				"check is performed based",
				"on the creature's",
				"Barding Difficulty",
				"versus the attempting",
				"character's combined"
			),
			new BookPageInfo
			(
				"skill in Musicianship",
				"and Peacemaking. To make",
				"it easier on the player",
				"Barding Difficulty has",
				"been expanded to reflect",
				"on the region of the",
				"targeted creature,",
				"meaning some areas will"
			),
			new BookPageInfo
			(
				"vary in terms of",
				"required skill level.",
				"",
				"",
				"-Veterinary-",
				"As ferocious as your",
				"tamed pet may be, at",
				"some point you may find"
			),
			new BookPageInfo
			(
				"yourself in a situation",
				"where a beloved pet is",
				"hurt, poisoned or both.",
				"With an investment in",
				"the Veterinary skill,",
				"you can heal most any",
				"ailment your pet may",
				"face."
			),
			new BookPageInfo
			(
				"",
				"Although creatures can",
				"be sustained to some",
				"extent by magical",
				"spells, a well trained",
				"vet can heal larger",
				"amounts of damage at",
				"greater speed. Like"
			),
			new BookPageInfo
			(
				"Stable Masters, a player",
				"character vet is capable",
				"of resurrecting dead",
				"pets.",
				"",
				"Veterinary also counts",
				"towards your total",
				"stable slot limit."
			),
			new BookPageInfo
			(
				"",
				"Pet Healing",
				"In order to heal",
				"creatures you must use a",
				"pile of Bandages on",
				"them. Your Healing and",
				"Anatomy skills have no",
				"influence here,"
			),
			new BookPageInfo
			(
				"Veterinary and Animal",
				"Lore are used instead.",
				"As these two skills rise",
				"the amount of damage",
				"healed increases as does",
				"your chance to",
				"cure/resurrect if need",
				"be."
			),
			new BookPageInfo
			(
				"- 60 Veterinary and 60",
				"Animal Lore to have a",
				"chance to cure a",
				"creature's Poison. You",
				"must be standing within",
				"two tiles of it.",
				"- 80 Veterinary and 80",
				"Animal Lore to have a"
			),
			new BookPageInfo
			(
				"chance to Resurrect a",
				"bonded pet. You must be",
				"standing directly beside",
				"it."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public VeterinarySkillGuide() : base( 0x1C13, false )
		{
			Weight = 0.0;
			LootType = LootType.Blessed;
		}

		public VeterinarySkillGuide( Serial serial ) : base( serial )
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