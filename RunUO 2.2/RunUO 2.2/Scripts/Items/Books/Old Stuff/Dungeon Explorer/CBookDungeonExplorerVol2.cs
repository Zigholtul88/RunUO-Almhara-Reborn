using System;
using Server;

namespace Server.Items
{
	public class CBookDungeonExplorerVol2 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Dungeon Explorer Vol. 2", "Lizard Caverns",

			new BookPageInfo
			(
				"Just northwest of",
				"Hammerhill lies the",
				"entrance to a series of",
				"flooded, mushroom",
				"covered caverns that is",
				"home to a variety of",
				"reptilian creatures that",
				"are hostile to"
			),
			new BookPageInfo
			(
				"outsiders. Originally a",
				"much smaller crawl",
				"space, it has since been",
				"carved into a more",
				"complex setting perfect",
				"for a young covetous",
				"drake. Long after",
				"establing the area as"
			),
			new BookPageInfo
			(
				"home the drake began",
				"recruiting",
				"reinforcements, for",
				"reasons unknown, and",
				"eventually drew the",
				"attention of various",
				"lizardman who now guard",
				"the caverns with extreme"
			),
			new BookPageInfo
			(
				"prejudice. Scattered",
				"throughout the dungeon",
				"are locked treasure",
				"chests that require a",
				"skill range of 15-20 to",
				"access depending on the",
				"floor and depending on",
				"luck may house some of"
			),
			new BookPageInfo
			(
				"the denizens most prized",
				"possessions. Once again",
				"these caverns are as",
				"dark as obsidian so make",
				"sure you have access to",
				"any light source.",
				"Honestly you're better",
				"off having either a"
			),
			new BookPageInfo
			(
				"potion or scroll",
				"containing the Night",
				"Sight spell since its",
				"less hassle compared to",
				"a mere torch."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public CBookDungeonExplorerVol2() : base( 0xFEF, false )
		{
		}

		public CBookDungeonExplorerVol2( Serial serial ) : base( serial )
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