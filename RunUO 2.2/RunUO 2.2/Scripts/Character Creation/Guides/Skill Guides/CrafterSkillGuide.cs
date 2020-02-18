using System;
using Server;

namespace Server.Items
{
	public class CrafterSkillGuide : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Crafter Skills", "",

			new BookPageInfo
			(
				"Starting Skills",
				"- Blacksmithy",
				"- Carpentry",
				"- Cooking",
				"- Fletching",
				"- Mining",
				"- Tailoring",
				"- Tinkering"
			),
			new BookPageInfo
			(
				"",
				"-Blacksmithy-",
				"Whether sweating over a",
				"fiery forge to create a",
				"masterpiece or hammering",
				"dents and polishing",
				"scratches from a favored",
				"piece of plate mail, the"
			),
			new BookPageInfo
			(
				"blacksmith of Britannia",
				"is a skilled craftsman",
				"who often finds his or",
				"her services in high",
				"demand.",
				"",
				"The skill of Blacksmithy",
				"involves: smelting metal"
			),
			new BookPageInfo
			(
				"items and ores; crafting",
				"arms and armaments;",
				"enhancing certain metal",
				"items; and repairing",
				"applicable items.",
				"",
				"There is a special",
				"collection of Bulk Order"
			),
			new BookPageInfo
			(
				"Deeds available for",
				"Smiths to fill out.",
				"Returning these provides",
				"special mining tools and",
				"other items as rewards.",
				"For the Smith in",
				"training, these can help",
				"speed the time it takes"
			),
			new BookPageInfo
			(
				"to acquire more ingots -",
				"For advanced players,",
				"Runic Hammers may be",
				"earned.",
				"",
				"Smelting",
				"The process for smelting",
				"ores and recycling metal"
			),
			new BookPageInfo
			(
				"items into their",
				"constituent ingots",
				"differs.",
				"",
				"Ores",
				"- Stand near a forge.",
				"- Double-click the ore",
				"pile you wish to smelt"
			),
			new BookPageInfo
			(
				"into ingots.",
				"- Target the forge.",
				"",
				"Metal Items",
				"The manual, or old",
				"school, method of",
				"smelting, or recycling,",
				"metal items into their"
			),
			new BookPageInfo
			(
				"constituent ingots",
				"involves:",
				"",
				"- Double-click a smith’s",
				"hammer, tongs, or",
				"sledgehammer that is",
				"located in your",
				"backpack."
			),
			new BookPageInfo
			(
				"- A menu will appear.",
				"- Select the Smelt Item",
				"button in the lower",
				"left-hand corner.",
				"- Target the item you",
				"wish to melt into",
				"ingots. (If smelting",
				"self-crafted items, will"
			),
			new BookPageInfo
			(
				"yield half of ingots",
				"used to create the",
				"item.)",
				"",
				"Crafting",
				"To create an item using",
				"the Blacksmithy skill:",
				""
			),
			new BookPageInfo
			(
				"- Stand near a forge and",
				"anvil (either, alone is",
				"insufficient).",
				"- Double-click a smith’s",
				"hammer, tongs, or",
				"sledgehammer that is",
				"located in your",
				"backpack."
			),
			new BookPageInfo
			(
				"- A menu will appear",
				"displaying the different",
				"categories of items you",
				"can craft.",
				"- Select a category and",
				"click on the button next",
				"to the item you wish to",
				"craft."
			),
			new BookPageInfo
			(
				"",
				"If successful, the",
				"crafted item will appear",
				"in your backpack. If",
				"successful and lucky,",
				"the crafted item will be",
				"exceptional. A",
				"Blacksmith can opt to"
			),
			new BookPageInfo
			(
				"include his or her",
				"maker’s mark on such",
				"exceptional items. The",
				"crafting menu contains a",
				"toggle in the lower",
				"right-hand corner to",
				"turn the maker’s mark",
				"option on or off."
			),
			new BookPageInfo
			(
				"",
				"A blacksmith may",
				"increase his or her",
				"chances by using an",
				"Ancient Hammer.",
				"",
				"",
				"-Carpentry-"
			),
			new BookPageInfo
			(
				"Masters of the saw, the",
				"plane and the level,",
				"carpenters spend long",
				"hours crafting some of",
				"the finest furniture and",
				"goods that decorate the",
				"lands within Almhara.",
				""
			),
			new BookPageInfo
			(
				"As your skill improves",
				"your crafting options",
				"expands and you'll be",
				"able to create items out",
				"of special forms of",
				"Lumber. With the proper",
				"research, a Grand Master",
				"may learn the secrets of"
			),
			new BookPageInfo
			(
				"Masonry.",
				"",
				"Tools",
				"Carpenter's tools come",
				"in all shapes and sizes.",
				"However, it is less the",
				"tool than the skill of",
				"the craftsman, and no"
			),
			new BookPageInfo
			(
				"one tool provides",
				"benefits over the",
				"others. They can be",
				"bought from a Carpenter",
				"or Tinker NPC Vendor or",
				"crafted using the",
				"Tinkering skill.",
				""
			),
			new BookPageInfo
			(
				"These tools are:",
				"Dovetail Saw, Draw",
				"Knife, Froe, Hammer,",
				"Inshave, Jointing Plane,",
				"Moulding Planes, Nails,",
				"Saw, Scorp, Smoothing",
				"Plane",
				""
			),
			new BookPageInfo
			(
				"Lumber is a basic",
				"necessity for any item",
				"created using the",
				"Carpentry skill. It is",
				"gathered by using the",
				"Lumberjacking skill.",
				"",
				"Wood comes in two"
			),
			new BookPageInfo
			(
				"varieties: Logs and",
				"Boards. Each type of",
				"wood requires a certain",
				"level of Carpentry or",
				"Lumberjacking skill to",
				"render from logs into",
				"much lighter boards.",
				""
			),
			new BookPageInfo
			(
				"How to Use",
				"- Double clicking on any",
				"of the Carpenter's tools",
				"will display the",
				"Carpentry Menu.",
				"- To Change the type of",
				"wood to use:",
				"1. Click the '*Wood'"
			),
			new BookPageInfo
			(
				"button.",
				"2. Select the type of",
				"wood you wish to use.",
				"- Note: You must have",
				"the type of wood you",
				"wish to use in your bag.",
				"",
				"To Create an Item:"
			),
			new BookPageInfo
			(
				"1. Follow the steps",
				"above to select the type",
				"of wood you wish to make",
				"the item out of.",
				"2. Select the Category",
				"of the item you wish to",
				"create.",
				"3. Press the Arrow next"
			),
			new BookPageInfo
			(
				"to the item you wish to",
				"create.",
				"- Note: Clicking the",
				"scroll to the right of",
				"the item will bring up",
				"the requirements for",
				"that item.",
				""
			),
			new BookPageInfo
			(
				"To Repair an Item:",
				"",
				"1. Click the 'Repair",
				"Item' button.",
				"2. When the target",
				"cursor appears, select",
				"the item you wish to",
				"repair."
			),
			new BookPageInfo
			(
				"",
				"",
				"-Cooking-",
				"The art of Cooking is",
				"used to create different",
				"types of foods and has",
				"become more useful since",
				"this server operates"
			),
			new BookPageInfo
			(
				"with a functioning",
				"hunger and thirst system",
				"much akin to the older",
				"titles of this mmo.",
				"",
				"While most food",
				"officially grants no",
				"benefits other then a"
			),
			new BookPageInfo
			(
				"small Stamina boost when",
				"eaten and perhaps",
				"holding back starvation",
				"and eventually death,",
				"Egg Bombs and Enchanted",
				"Apples can be of great",
				"value in PvP situations.",
				"Savage Kin Paint can"
			),
			new BookPageInfo
			(
				"also be used to prevent",
				"morph spells being used",
				"on those who apply it",
				"especially helpful",
				"against enemy combatants",
				"that utilize such",
				"abilities.",
				""
			),
			new BookPageInfo
			(
				"Chefs will often find",
				"that they need an Oven",
				"nearby to create their",
				"masterpieces, though in",
				"some cases a simple",
				"Heating Stand will",
				"suffice. The serious",
				"cook will also install a"
			),
			new BookPageInfo
			(
				"Flour Mill and Water",
				"Trough in his or her",
				"home, and perhaps even",
				"hire an NPC Barkeep",
				"Vendor.",
				"",
				"Tools",
				"There are a few items"
			),
			new BookPageInfo
			(
				"available with which to",
				"practice your culinary",
				"skill. Despite their",
				"names and appearances,",
				"each is equally suitable",
				"for the preparation of",
				"any dish.",
				""
			),
			new BookPageInfo
			(
				"- Rolling Pin",
				"- Skillet",
				"- Flour Sifter",
				"",
				"",
				"-Fletching-",
				"Fletchers create bows",
				"and arrows for use by"
			),
			new BookPageInfo
			(
				"Archers, using Wood,",
				"Feathers as well as",
				"various working",
				"materials. Because they",
				"also deal with Boards,",
				"the Lumberjacking and",
				"Carpentry skills",
				"complement Fletching"
			),
			new BookPageInfo
			(
				"well. ",
				"",
				"",
				"",
				"-Mining-",
				"Seams of ore lie buried",
				"in the mines, mountains",
				"and caves within the"
			),
			new BookPageInfo
			(
				"Almharian realm. The",
				"skilled miner seeks out",
				"these veins to harvest",
				"ore, which can then be",
				"smelted to ingots for",
				"use in crafting items",
				"with the Blacksmithy or",
				"Tinkering skills."
			),
			new BookPageInfo
			(
				"",
				"In order to mine you",
				"must use a Pickaxe or",
				"Shovel on a cave floor",
				"or mountainside tile.",
				"Ore may then be smelted",
				"by using it on a Forge",
				"or Fire Beetle. Be"
			),
			new BookPageInfo
			(
				"warned - If you fail to",
				"smelt you will lose 50%",
				"of the contents of your",
				"ore pile!",
				"",
				"The mining skill is also",
				"useful when practising",
				"the creation of"
			),
			new BookPageInfo
			(
				"smeltable items (which",
				"can be recycled back",
				"into usable Ingots, with",
				"the amount of ingots",
				"returned based on the",
				"Mining skill). It",
				"furthermore gives a",
				"bonus to Treasure"
			),
			new BookPageInfo
			(
				"Hunters looking for",
				"Treasure Chests",
				"underground. You cannot",
				"mine while mounted.",
				"",
				"As your skill improves,",
				"you become capable of",
				"mining and smelting more"
			),
			new BookPageInfo
			(
				"obscure forms of ore:",
				"",
				"- 0+ Iron Ore",
				"- 65+ Dull Copper Ore",
				"- 70+ Shadow Iron Ore",
				"- 75+ Copper Ore",
				"- 80+ Bronze Ore",
				"- 85+ Golden Ore"
			),
			new BookPageInfo
			(
				"- 90+ Agapite Ore",
				"- 95+ Verite Ore",
				"- 99+ Valorite Ore",
				"",
				"A GM Miner, after the",
				"proper research, may",
				"also extract High",
				"Quality Granite and Sand"
			),
			new BookPageInfo
			(
				"for use by the more",
				"experienced crafters.",
				"When you have read the",
				"High Quality Granite",
				"book, you can click on",
				"your pickaxe and set it",
				"to mine both stone and",
				"ore. When you have read"
			),
			new BookPageInfo
			(
				"the High Quality Sand",
				"book, instead of mining",
				"only in rock, you can",
				"also mine the beaches",
				"and deserts within",
				"Almhara (or any random",
				"sand tiles available to",
				"you)."
			),
			new BookPageInfo
			(
				"",
				"Although your Mining",
				"skill cannot advance",
				"past 100 points through",
				"training, Mining Gloves",
				"may be worn to take your",
				"skill to an absolute",
				"maximum of 105. Mining"
			),
			new BookPageInfo
			(
				"is the only skill that",
				"can be advanced in this",
				"way without the use of a",
				"Power Scroll.",
				"",
				"Human characters will",
				"have a chance to get",
				"extra ore with each dig,"
			),
			new BookPageInfo
			(
				"while Elves have an",
				"increased chance of",
				"harvesting special ore",
				"types from colored veins",
				"(as opposed to finding",
				"colored veins).",
				"",
				"Whenever an ore vein"
			),
			new BookPageInfo
			(
				"refreshes after being",
				"harvested from, there is",
				"a slight chance it will",
				"change resource type.",
				"For example, a",
				"mountainside that",
				"yielded Valorite today",
				"might give plain iron"
			),
			new BookPageInfo
			(
				"tomorrow, and vice",
				"versa. Your level of",
				"skill does not determine",
				"your chance of finding a",
				"colored vein, it only",
				"determines whether you",
				"can extract the colored",
				"ore."
			),
			new BookPageInfo
			(
				"",
				"A Gargoyle's Pickaxe",
				"and/or Prospector's Tool",
				"can be used to",
				"potentially advance an",
				"ore vein's level by up",
				"to two types (e.g.,",
				"Agapite to Valorite)."
			),
			new BookPageInfo
			(
				"",
				"Special Resources",
				"At high Mining skill",
				"levels you have the",
				"chance to randomly",
				"retrieve one of the",
				"following resources: ",
				"- Blue Diamond"
			),
			new BookPageInfo
			(
				"- Dark Sapphire",
				"- Ecru Citrine",
				"- Fire Ruby",
				"- Perfect Emerald",
				"- Turquoise",
				"",
				"Tips and Tricks",
				"- There is no way to"
			),
			new BookPageInfo
			(
				"increase your mining",
				"above grandmaster 100",
				"skill unless you are",
				"using Mining Gloves",
				"which add a +5 to your",
				"total skill. Mining",
				"Power Scrolls do not",
				"exist."
			),
			new BookPageInfo
			(
				"- Tinkering is a very",
				"good combination with",
				"your mining skill. You",
				"can use it to create",
				"more pickaxes and",
				"shovels with the ingots",
				"you collect. This way",
				"you can stay out with"
			),
			new BookPageInfo
			(
				"your pack mule for",
				"longer periods of time.",
				"- When smelting richer",
				"types of ore material",
				"that you can't always",
				"work with successfully",
				"(eg, Agapite, Verite, or",
				"Valorite), it's best to"
			),
			new BookPageInfo
			(
				"divide all of the",
				"material in piles of",
				"two. That way if you",
				"fail to smelt the ore",
				"(hence wasting half the",
				"pile), you only lose one",
				"ore rather than, say,",
				"fifteen ore from a nice"
			),
			new BookPageInfo
			(
				"pile of thirty in that",
				"type.",
				"- To mine High Quality",
				"Granite or Sand, you",
				"must travel to the",
				"Elmhaven city and buy",
				"'tutorial books' from",
				"Timothy the stonecrafter"
			),
			new BookPageInfo
			(
				"that reside there. The",
				"books can only be read",
				"by GM Miners.",
				"- Although the type of",
				"ore a vein gives will",
				"change over time, the",
				"percentage of coloured",
				"ore it'll give on"
			),
			new BookPageInfo
			(
				"average (of any colour)",
				"does not change. That is",
				"to say, if you clean out",
				"a Dull Copper node and",
				"get 70% coloured ore",
				"from it, you'll likely",
				"get the same percentage",
				"if it ever flips around"
			),
			new BookPageInfo
			(
				"to Valorite.",
				"",
				"",
				"-Tailoring-",
				"Ever have one of those",
				"mornings where you just",
				"couldn’t bear to put on",
				"the same tunic yet"
			),
			new BookPageInfo
			(
				"again? With skill in",
				"Tailoring, you can make",
				"clothing of all styles,",
				"colors and patterns, and",
				"show off your taste in",
				"fashion!",
				"",
				"While many items created"
			),
			new BookPageInfo
			(
				"by Tailors are of Cloth,",
				"as your skill improves",
				"you may be able to",
				"create armor out of",
				"exotic forms of Leather",
				"or even Bones.",
				"",
				"There is a special"
			),
			new BookPageInfo
			(
				"collection of Bulk Order",
				"Deeds available for",
				"Tailors to fill out.",
				"Returning these provides",
				"specially colored cloth",
				"and other items as",
				"rewards. For the Tailor",
				"in training, this extra"
			),
			new BookPageInfo
			(
				"cloth can be used to",
				"fill yet more BODs,",
				"extending the amount of",
				"time before you need to",
				"go and collect more",
				"resources to work with.",
				"For advanced players,",
				"Runic Sewing Kits may be"
			),
			new BookPageInfo
			(
				"earned. Experienced",
				"Tailors can create",
				"Arcane Clothing which",
				"stores charges of magic",
				"power, allowing the",
				"wearer to cast spells",
				"without reagents.",
				""
			),
			new BookPageInfo
			(
				"",
				"-Tinkering-",
				"Tinkering is the skill",
				"that could be considered",
				"central to all",
				"creativity in Ultima",
				"Online - The ability to",
				"fashion tools for use"
			),
			new BookPageInfo
			(
				"with the other trades",
				"makes it a good starting",
				"point for any",
				"up-and-coming crafter.",
				"For example, it allows a",
				"miner to create more",
				"Shovels as he works.",
				"These tools often do not"
			),
			new BookPageInfo
			(
				"require high levels of",
				"skill to create, so not",
				"all crafters need to be",
				"Grand Master tinkerers",
				"to get an advantage -",
				"Though Exceptionally",
				"crafted tools do last",
				"longer..."
			),
			new BookPageInfo
			(
				"",
				"With enough skill, your",
				"characters may even",
				"assemble obedient Golems",
				"and other steamwork",
				"creatures to do their",
				"bidding in battle. While",
				"not often used in real"
			),
			new BookPageInfo
			(
				"combat situations, their",
				"extreme poison",
				"resistance makes them",
				"prized by fighters",
				"wishing to train their",
				"combat skills.",
				"",
				"Usually Tinkers work"
			),
			new BookPageInfo
			(
				"with ingots, though on",
				"occasion they create",
				"items out of wood as",
				"well."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public CrafterSkillGuide() : base( 0x1C13, false )
		{
			Weight = 0.0;
			LootType = LootType.Blessed;
		}

		public CrafterSkillGuide( Serial serial ) : base( serial )
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