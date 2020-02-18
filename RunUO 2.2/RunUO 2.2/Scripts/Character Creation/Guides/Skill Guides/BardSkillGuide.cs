using System;
using Server;

namespace Server.Items
{
	public class BardSkillGuide : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Bard Skills", "",

			new BookPageInfo
			(
				"Starting Skills",
				"- Discordance",
				"- Musicianship",
				"- Peacemaking",
				"- Provocation",
				"",
				"",
				""
			),
			new BookPageInfo
			(
				"-Discordance-",
				"Music may soothe the",
				"savage beast, but",
				"playing a few clashing",
				"notes will weaken even",
				"the strongest of",
				"creatures.",
				""
			),
			new BookPageInfo
			(
				"To discord a creature",
				"you:",
				"- Click the blue gem",
				"next to the skill on",
				"your skill list.",
				"- Click on the creature",
				"you wish to discord.",
				""
			),
			new BookPageInfo
			(
				"If successful, your",
				"target will lose a",
				"percentage of its skills",
				"and stats. The",
				"percentage lost is",
				"dependant on your",
				"Discordance skill. For",
				"instance, at 50.0 skill,"
			),
			new BookPageInfo
			(
				"the target loses 10%",
				"from all stats and",
				"skills; and at 100.0",
				"skill the target loses",
				"20% from all stats and",
				"skills. Once the effect",
				"wears off, the target's",
				"skill and stats will"
			),
			new BookPageInfo
			(
				"return to normal. (Does",
				"not affect player",
				"characters.) ",
				"",
				"The base range of all",
				"bard abilities is 8",
				"tiles, with each 15",
				"points of skill in the"
			),
			new BookPageInfo
			(
				"ability being used",
				"increasing this range by",
				"one tile. Bards must be",
				"within this range of the",
				"target to use the",
				"ability. Furthermore,",
				"the bard must remain",
				"within this range or the"
			),
			new BookPageInfo
			(
				"ability's effect ends. ",
				"",
				"Once Discordance has",
				"been used on a target,",
				"the bard must remain",
				"alive, visible, and",
				"within range of the",
				"target or the effect"
			),
			new BookPageInfo
			(
				"ends. Regarding",
				"creatures with “Dragon",
				"AI” (such as daemons,",
				"drakes, hellhounds,",
				"nightmares, and, of",
				"course, dragons): if at",
				"any point the bard moves",
				"while using any barding"
			),
			new BookPageInfo
			(
				"song, that may compel",
				"the creature to retarget",
				"on the moving character.",
				"",
				"Discordance uses the",
				"same success/failure",
				"calcuation formula as",
				"Provocation, so training"
			),
			new BookPageInfo
			(
				"methods are identical in",
				"terms of what creatures",
				"to discord at what",
				"level.",
				"",
				"",
				"-Musicianship-",
				"Strum a lute, bang on a"
			),
			new BookPageInfo
			(
				"drum or rattle a",
				"tambourine. Without a",
				"bit of skill in",
				"Musicianship, you’ll",
				"likely send your",
				"audience screaming away",
				"from, or worse toward",
				"you."
			),
			new BookPageInfo
			(
				"",
				"Musicianship is the core",
				"Bard-themed skill. It is",
				"required for any of the",
				"other Bard-related",
				"skills to even have a",
				"chance of success. A",
				"modest level of"
			),
			new BookPageInfo
			(
				"Musicianship is also",
				"required for a Carpenter",
				"to be able to produce",
				"musical instruments,",
				"which feature a 10%",
				"success bonus over",
				"NPC-purchased musical",
				"instruments."
			),
			new BookPageInfo
			(
				"",
				"While it does little on",
				"it's own aside from",
				"producing either fine",
				"music or fat-fingered",
				"cacophony, it's level is",
				"a key factor when",
				"attempting to perform"
			),
			new BookPageInfo
			(
				"the other Bard skills,",
				"namely Provocation,",
				"Discordance or",
				"Peacemaking in",
				"conjunction with a",
				"target's Barding",
				"Difficulty.",
				""
			),
			new BookPageInfo
			(
				"Luckily for this class",
				"you're already maxed",
				"out, so no need to worry",
				"about pointless grinding",
				"in order to actually be",
				"able to use the",
				"abilities associated",
				"with this class."
			),
			new BookPageInfo
			(
				"",
				"",
				"-Peacemaking-",
				"The Peacemaking skill is",
				"one of the Bard-themed",
				"skills and is sometimes",
				"called Peacing for",
				"short. In a nutshell,"
			),
			new BookPageInfo
			(
				"the soothing music of a",
				"successful attempt",
				"causes those to whom it",
				"is directed to relax and",
				"stop fighting. To",
				"successfully be able to",
				"use this skill also",
				"requires some level of"
			),
			new BookPageInfo
			(
				"Musicianship skill as",
				"well. While a useful",
				"skill for a Bard in it's",
				"own right, it is also",
				"valuable to possess, or",
				"assist other players",
				"with, when it comes to",
				"Animal Taming or"
			),
			new BookPageInfo
			(
				"Treasure Hunting.",
				"",
				"Peacemaking skill has",
				"two different modes,",
				"Area Peacemaking and",
				"Targeted Peacemaking.",
				"",
				"Area Peacemaking"
			),
			new BookPageInfo
			(
				"",
				"Activate the skill via",
				"macro or skill button",
				"and target yourself. If",
				"successful, all",
				"aggression in the area",
				"will cease for a few",
				"moments. Players will"
			),
			new BookPageInfo
			(
				"have to re-attack their",
				"targets.",
				"",
				"Targeted Peacemaking",
				"",
				"Activate the skill via",
				"macro or skill button",
				"and target a creature."
			),
			new BookPageInfo
			(
				"If successful, the",
				"targeted creature will",
				"either remain",
				"non-aggressive or stop",
				"attacking it's target",
				"until a sufficient",
				"attack upon it breaks",
				"the trance or the bard"
			),
			new BookPageInfo
			(
				"loses line of sight for",
				"more than 10 seconds.",
				"",
				"Each time Targeted",
				"Peacemaking is",
				"attempted, a difficulty",
				"check is performed based",
				"on the creature's"
			),
			new BookPageInfo
			(
				"Barding Difficulty",
				"versus the attempting",
				"character's combined",
				"skill in Musicianship",
				"and Peacemaking. To make",
				"it easier on the player",
				"Barding Difficulty has",
				"been expanded to reflect"
			),
			new BookPageInfo
			(
				"on the region of the",
				"targeted creature,",
				"meaning some areas will",
				"vary in terms of",
				"required skill level.",
				"",
				"",
				"-Provocation-"
			),
			new BookPageInfo
			(
				"Using the Provocation",
				"skill, a player has a",
				"chance to make two",
				"creatures fight each",
				"other. It is one of the",
				"most powerful skills in",
				"the game. Beware that if",
				"you fail the monsters"
			),
			new BookPageInfo
			(
				"will look for a new",
				"target, you.",
				"",
				"Provocation is",
				"difficulty-based skill.",
				"Some monsters are much",
				"more difficult to",
				"provoke than others,"
			),
			new BookPageInfo
			(
				"depending on their",
				"Barding Difficulty. Once",
				"two creatures are",
				"fighting each other,",
				"they will continue to do",
				"so until either the",
				"provoking bard leaves",
				"their line of sight or"
			),
			new BookPageInfo
			(
				"one is killed.",
				"",
				"Much like with",
				"Discordance and",
				"Peacemaking, Barding",
				"Difficulty will vary",
				"depending on region."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BardSkillGuide() : base( 0x1C13, false )
		{
			Weight = 0.0;
			LootType = LootType.Blessed;
		}

		public BardSkillGuide( Serial serial ) : base( serial )
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