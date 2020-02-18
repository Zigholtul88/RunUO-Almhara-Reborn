using System;
using Server;

namespace Server.Items
{
	public class CBookDungeonExplorerVol4 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Dungeon Explorer Vol. 4", "Stone Burrow Mines",

			new BookPageInfo
			(
				"Perhaps the only notable",
				"spot on the Island of",
				"Giants lies the entrance",
				"to Stone Burrow Mines,",
				"an underground shaft",
				"consisting of multiple",
				"islands, surrounded on",
				"all ends by an lingering"
			),
			new BookPageInfo
			(
				"darkness that seems",
				"never ending. Long ago,",
				"many folks from all over",
				"descended unto the",
				"depths of this expansive",
				"cavern due to it being",
				"one of the easiest",
				"sources for dull copper"
			),
			new BookPageInfo
			(
				"ore. Nowadays it has",
				"been over run with",
				"various creatures",
				"itching for a proper",
				"fight, including a",
				"certain mind flayer",
				"whose extremely",
				"versatile in the arts of"
			),
			new BookPageInfo
			(
				"the arcane. Scattered",
				"throughout the dungeon",
				"are locked treasure",
				"chests that require a",
				"skill range of 25-30 to",
				"access depending on the",
				"floor and depending on",
				"luck may house some of"
			),
			new BookPageInfo
			(
				"the denizens most prized",
				"possessions. Even some",
				"of the doors, such as",
				"one of the housing",
				"facilities require at",
				"least a skill level of",
				"25 in order to unlock."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public CBookDungeonExplorerVol4() : base( 0xFEF, false )
		{
		}

		public CBookDungeonExplorerVol4( Serial serial ) : base( serial )
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