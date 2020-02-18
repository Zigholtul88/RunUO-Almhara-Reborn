using System;
using Server;

namespace Server.Items
{
	public class RogueSkillGuide : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Rogue Skills", "",

			new BookPageInfo
			(
				"Starting Skills",
				"- Fencing",
				"- Hiding",
				"- Poisoning",
				"- Snooping",
				"- Stealing",
				"- Stealth",
				""
			),
			new BookPageInfo
			(
				"-Fencing-",
				"Fencing weapons are used",
				"to stab'n'jab opponents,",
				"allowing the user to",
				"quickly attack while at",
				"the same time",
				"maintaining a defense.",
				"It is the best melee"
			),
			new BookPageInfo
			(
				"class available for use",
				"with Poisoning.",
				"",
				"",
				"-Hiding-",
				"Danger may lurk behind",
				"every tree, deep in",
				"darkened dungeons, or"
			),
			new BookPageInfo
			(
				"simply in the intentions",
				"of the rogue walking",
				"behind you. With",
				"sufficient skill in",
				"Hiding, you can",
				"disappear into the",
				"shadows whenever",
				"necessary."
			),
			new BookPageInfo
			(
				"",
				"The chance of hiding",
				"successfully is directly",
				"equal to that of the",
				"Hiding skill. Characters",
				"may not hide close to",
				"creatures that are",
				"actively hostile towards"
			),
			new BookPageInfo
			(
				"them, although at higher",
				"levels of Hiding the",
				"distance between the",
				"character and the",
				"monster may be lessened.",
				"At GM Hiding, a",
				"character may hide in",
				"plain sight of a hostile"
			),
			new BookPageInfo
			(
				"monster or other player",
				"only 8 tiles away.",
				"Having creatures neutral",
				"nearby to a character",
				"has no effect on the",
				"chances of concealment,",
				"just hostile ones.",
				""
			),
			new BookPageInfo
			(
				"Like the Detecting",
				"Hidden skill, Hiding is",
				"always successful within",
				"a player's own house.",
				"Although this has not",
				"always been the case,",
				"skill gain will be just",
				"as quick as anywhere"
			),
			new BookPageInfo
			(
				"else.",
				"",
				"A proficient Snooper can",
				"peer into the packs of",
				"other players while",
				"remaining hidden, and",
				"the art of Ninjitsu also",
				"relies somewhat on the"
			),
			new BookPageInfo
			(
				"ability to remain",
				"unseen. The Stealth",
				"skill furthermore allows",
				"characters to move while",
				"out of sight. The Smoke",
				"Bomb let a ninja hide",
				"while still in combat.",
				""
			),
			new BookPageInfo
			(
				"Unlike the Invisibility",
				"spell, the effect of",
				"hiding does not wear off",
				"and leaves a character",
				"safe until they perform",
				"another action.",
				"Equipping items, looting",
				"one's own corpse or"
			),
			new BookPageInfo
			(
				"moving objects around in",
				"their backpack will not",
				"reveal a character, nor",
				"will the use of the",
				"guild/party chat.",
				"",
				"Be warned that when",
				"successfully hiding"
			),
			new BookPageInfo
			(
				"while under the",
				"attentions of powerful",
				"magic-using monsters,",
				"they will stop in their",
				"tracks and cast Reveal",
				"on the character's last",
				"seen location. While",
				"they are occupied in"
			),
			new BookPageInfo
			(
				"this process it is wise",
				"to consider moving away",
				"from that location.",
				"",
				"",
				"-Poisoning-",
				"Subtler than an impaling",
				"sword, poisoning food"
			),
			new BookPageInfo
			(
				"and drink has long been",
				"a method of choice for",
				"the discerning assassin.",
				"For those with a flair",
				"for the dramatic, Poison",
				"can be applied to the",
				"blade of a weapon to",
				"swiftly bring an enemy"
			),
			new BookPageInfo
			(
				"to defeat in battle.",
				"",
				"Along with the ability",
				"to poison weapons and",
				"food, higher levels of",
				"this skill improve the",
				"effectiveness of the",
				"Poison and Poison Field"
			),
			new BookPageInfo
			(
				"spells. Poisoning skill",
				"also grants a natural",
				"poison resistance which",
				"is 20% of the player's",
				"poisoning skill.",
				"",
				"Poisoning takes the",
				"place of Tactics in"
			),
			new BookPageInfo
			(
				"determining the",
				"probability to perform",
				"poison Special Moves -",
				"These are Infectious",
				"Strike and Serpent",
				"Arrow. However, you must",
				"have a weapon skill of",
				"at least 70 to activate"
			),
			new BookPageInfo
			(
				"primary move weapons and",
				"at least 90 to activate",
				"secondary move weapons.",
				"The item property of",
				"Mage Weapon does not act",
				"as a substitute for a",
				"weapon skill when it",
				"comes to special moves."
			),
			new BookPageInfo
			(
				"",
				"Previously, a weapon",
				"that had been poisoned",
				"could be used by anyone",
				"and would have a chance",
				"to poison a target with",
				"each hit.",
				""
			),
			new BookPageInfo
			(
				"Weapons",
				"Standard weapons with",
				"the Infectious",
				"Strike/Serpent Arrow",
				"moves can be used to",
				"inflict Poison.",
				"",
				"Prior to the"
			),
			new BookPageInfo
			(
				"introduction of these",
				"Special Moves, poison",
				"could be applied to most",
				"any weapon and inflicted",
				"by simply hitting your",
				"targets with it. Weapons",
				"coated this way would",
				"lose Durability as the"
			),
			new BookPageInfo
			(
				"poison corroded them,",
				"but could be cleaned",
				"with an Oil Cloth.",
				"",
				"Now days, only",
				"Infectious Strike",
				"weapons, Shuriken and",
				"Fukiya Darts can still"
			),
			new BookPageInfo
			(
				"be poisoned in the",
				"original manner, and",
				"corrosion is no longer",
				"in effect. The Serpent",
				"Arrow move requires no",
				"actual poison (either on",
				"the weapon or in your",
				"pack) but requires high"
			),
			new BookPageInfo
			(
				"levels of Dexterity to",
				"be effective.",
				"",
				"Throwing a",
				"Shuriken/Fukiya Dart",
				"will apply the poison",
				"regardless of your skill",
				"level. To use other"
			),
			new BookPageInfo
			(
				"weapons that have been",
				"poisoned, you must",
				"specifically activate",
				"the Infectious Strike",
				"move.",
				"",
				"Having a high enough",
				"level of Poisoning skill"
			),
			new BookPageInfo
			(
				"can allow you to inflict",
				"a level of poison higher",
				"then that on the weapon.",
				"",
				"",
				"-Snooping-",
				"By and large, Snooping",
				"is considered a"
			),
			new BookPageInfo
			(
				"prerequsite for the",
				"Stealing skill. A",
				"character only can steal",
				"random items from other",
				"characters, NPCs, or",
				"pack animals unless they",
				"possess the Snooping",
				"skill. Like the Hiding"
			),
			new BookPageInfo
			(
				"skill, Snooping can be",
				"practiced to its own",
				"end, i.e. just to be",
				"able to see what others",
				"are toting around",
				"Almhara. However unlike",
				"Hiding, it is typically",
				"looked upon as"
			),
			new BookPageInfo
			(
				"aggressive act.",
				"",
				"You cannot be Guard",
				"Wacked for Snooping nor",
				"will you be flagged as a",
				"criminal. Snooping will",
				"lower your karma. You",
				"might consider the use"
			),
			new BookPageInfo
			(
				"of the Stealth skill as",
				"most players will not",
				"let you get close to",
				"them if they suspect ill",
				"intentions.",
				"",
				"Use",
				"Snooping only allows you"
			),
			new BookPageInfo
			(
				"to see into other packs:",
				"- the backpack of",
				"another character",
				"- Pack Horses;",
				"- Pack Llamas; and",
				"- NPC backpacks.",
				"",
				"While standing no more"
			),
			new BookPageInfo
			(
				"then a single tile away",
				"double click the pack.",
				"If successful, you will",
				"be able to see the",
				"contents in the same way",
				"as you see your own",
				"backpack.",
				""
			),
			new BookPageInfo
			(
				"Whether you succeed or",
				"not, there is a chance",
				"you will be noticed,",
				"wherein nearby players",
				"will receive a message",
				"concerning your action,",
				"and if hidden, a chance",
				"of being revealed. Your"
			),
			new BookPageInfo
			(
				"chances of success",
				"increase with higher",
				"levels of the Snooping",
				"skill, while your",
				"chances of being",
				"detected decreases.",
				"",
				"Snooping is an essential"
			),
			new BookPageInfo
			(
				"skill for the aspiring",
				"thief in that once you",
				"can see into a pack you",
				"may target a specific",
				"item to Steal. Without",
				"the use of Snooping you",
				"can only blindly target",
				"the characters"
			),
			new BookPageInfo
			(
				"themselves and hope that",
				"the random item you grab",
				"will be of some value.",
				"",
				"",
				"-Stealing-",
				"Pickpockets, brigands",
				"and thieves often prefer"
			),
			new BookPageInfo
			(
				"to live life in the",
				"shadows of Britannia,",
				"stealthily earning a",
				"living off the pockets",
				"and chests of others. A",
				"skilled thief can steal",
				"from Monsters, chests,",
				"NPCs and other players."
			),
			new BookPageInfo
			(
				"",
				"Attempting to steal an",
				"item will reveal you if",
				"you are Hidden or",
				"Invisible. It is",
				"typically considered",
				"wise to Stealth over to",
				"your target beforehand,"
			),
			new BookPageInfo
			(
				"then (if your mark is",
				"another character), use",
				"the Snooping skill to",
				"better pinpoint the item",
				"you're after. You must",
				"have both hands free to",
				"steal and will need to",
				"wait ten seconds before"
			),
			new BookPageInfo
			(
				"you can use another",
				"skill.",
				"",
				"To steal from other",
				"players, one must join",
				"the Thieves Guild.",
				"",
				"You may not take items"
			),
			new BookPageInfo
			(
				"that weigh more then",
				"your skill level divided",
				"by 10, nor items that",
				"are Blessed or Insured.",
				"Attempting to steal",
				"directly from another",
				"player (as opposed to",
				"Snooping them first and"
			),
			new BookPageInfo
			(
				"selecting a specific",
				"item) will result in a",
				"random item being",
				"chosen, which may weigh",
				"too much or be",
				"Blessed/Insured",
				"(resulting in automatic",
				"failure)."
			),
			new BookPageInfo
			(
				"",
				"Attempting to steal from",
				"another player, whether",
				"the item is taken or",
				"not, may make you a",
				"Criminal. The chances of",
				"this decreases as your",
				"skill rises, but the"
			),
			new BookPageInfo
			(
				"more characters",
				"(including NPCs) are",
				"nearby, the more likely",
				"you'll be 'caught in the",
				"act'. Assuming you are",
				"not seen, you will",
				"retain your Blue status.",
				""
			),
			new BookPageInfo
			(
				"Joining the Thieves",
				"Guild",
				"In order to steal from",
				"other players, a",
				"character must join the",
				"Thieves Guild. To do",
				"this, one must find a",
				"Thief Guild Master,"
			),
			new BookPageInfo
			(
				"which are found hidden",
				"away in random areas",
				"around the world map.",
				"Once located, a",
				"character can join the",
				"guild by saying: '(NPC",
				"Name) join'. If the",
				"character is at least 48"
			),
			new BookPageInfo
			(
				"in-game hours old and",
				"has at least 60 Stealing",
				"skill, 500 gold pieces",
				"will be requested as",
				"payment to join. The",
				"payment must then be",
				"dragged onto them to",
				"complete the joining"
			),
			new BookPageInfo
			(
				"process. If the",
				"character has not met",
				"the skill and age",
				"requirements, they will",
				"be refused membership in",
				"the Thieves Guild until",
				"they meet the",
				"requirements. Being a"
			),
			new BookPageInfo
			(
				"member of the Thieves",
				"Guild also allows a",
				"player to buy and use a",
				"disguise kit.",
				"",
				"Note: While attacking an",
				"'Innocent' (blue) member",
				"of the Thieves Guild is"
			),
			new BookPageInfo
			(
				"considered a criminal",
				"act, players in the",
				"Thieves Guild cannot",
				"give Murder Counts and",
				"are freely lootable if",
				"killed.",
				"",
				""
			),
			new BookPageInfo
			(
				"-Stealth-",
				"Stealth is a skill in",
				"Ultima Online that by",
				"default is categorized",
				"under 'Thievery' for",
				"obvious reasons.",
				"",
				"Stealth allows a"
			),
			new BookPageInfo
			(
				"character to move",
				"silently while",
				"maintaining",
				"invisibility, but it",
				"becomes much easier to",
				"detect such a character",
				"compared to Hiding.",
				""
			),
			new BookPageInfo
			(
				"This skill also counts",
				"towards your ability to",
				"perform Special Moves.",
				"",
				"A character must have at",
				"least 30.0 in Hiding to",
				"be able to use Stealth.",
				"Otherwise, the message"
			),
			new BookPageInfo
			(
				"'You are not hidden well",
				"enough. Become better at",
				"hiding.' will display.",
				"",
				"It has been suggested by",
				"some players that you",
				"will not fail stealth",
				"checks with 60.0 Stealth"
			),
			new BookPageInfo
			(
				"and while wearing",
				"medable armor, though",
				"this might not cover the",
				"effect of passive (as",
				"well as active) detect",
				"hidden skill of the",
				"players around the",
				"stealther."
			),
			new BookPageInfo
			(
				"",
				"Use",
				"To perform Stealth:",
				"- The character must",
				"have at least 30.0",
				"Hiding.",
				"- Dismount any pet;",
				"Stealth cannot be used"
			),
			new BookPageInfo
			(
				"while riding.",
				"- Enter Hiding state,",
				"either through Hiding,",
				"Invisibility, a potion,",
				"etc.",
				"- Activate the Stealth",
				"skill. If successful, a",
				"message will appear"
			),
			new BookPageInfo
			(
				"stating 'You begin to",
				"move silently.' and the",
				"character will remain",
				"grey while moving. No",
				"footstep sound will",
				"play.",
				"- Take a walking step",
				"(not running.) At 25.0"
			),
			new BookPageInfo
			(
				"Stealth or higher, the",
				"effect will activate",
				"automatically when a",
				"character attempts to",
				"walk while hidden.",
				"- Every 5 levels of",
				"Stealth increases the",
				"distance a character may"
			),
			new BookPageInfo
			(
				"walk before a skill",
				"check (e.g. 80 Stealth =",
				"16 safe steps per",
				"successful skill check.)",
				"",
				"Note that performing any",
				"action that would cancel",
				"hidden state will also"
			),
			new BookPageInfo
			(
				"cancel stealth state,",
				"other than moving of",
				"course.",
				"",
				"Running while in stealth",
				"state will halve the",
				"number of safe steps and",
				"will -always- fail the"
			),
			new BookPageInfo
			(
				"stealth check afterward.",
				"",
				"Stealthing is more",
				"difficult when wearing",
				"heavier armor, which is",
				"also a factor in",
				"training. To stealth",
				"successfully once it has"
			),
			new BookPageInfo
			(
				"been trained, don't wear",
				"anything heavier than",
				"Leather Armor or Mage",
				"Armor."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public RogueSkillGuide() : base( 0x1C13, false )
		{
			Weight = 0.0;
			LootType = LootType.Blessed;
		}

		public RogueSkillGuide( Serial serial ) : base( serial )
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