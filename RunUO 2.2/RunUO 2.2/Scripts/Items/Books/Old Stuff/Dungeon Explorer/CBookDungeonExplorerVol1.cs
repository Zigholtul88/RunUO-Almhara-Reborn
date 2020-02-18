using System;
using Server;

namespace Server.Items
{
	public class CBookDungeonExplorerVol1 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Dungeon Explorer Vol. 1", "Mongbat Caverns",

			new BookPageInfo
			(
				"Located just southeast",
				"of Hammerhill lies the",
				"entrance to an",
				"underground cavern",
				"that's populated with",
				"all sorts of vicious",
				"creatures known as",
				"Mongbats and all their"
			),
			new BookPageInfo
			(
				"variants. This is an",
				"ideal dungeon for the",
				"young adventurer mostly",
				"due to the popular",
				"notion that the Mongbat",
				"is indeed a coward that",
				"will flee combat after",
				"sustaining enough damage"
			),
			new BookPageInfo
			(
				"but in all honesty that",
				"affects basically every",
				"monster in this world.",
				"Before you venture deep",
				"into the caverns be sure",
				"to either bring a torch",
				"or have access to",
				"anything nightsight"
			),
			new BookPageInfo
			(
				"related or else you",
				"won't be seeing much.",
				"Scattered throughout the",
				"dungeon are locked",
				"treasure chests that",
				"require a skill range of",
				"5-10 to access depending",
				"on the floor and"
			),
			new BookPageInfo
			(
				"depending on luck may",
				"house some of the",
				"denizens most prized",
				"possessions."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public CBookDungeonExplorerVol1() : base( 0xFEF, false )
		{
		}

		public CBookDungeonExplorerVol1( Serial serial ) : base( serial )
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