using System;
using Server;

namespace Server.Items
{
	public class CBookDungeonExplorerVol3 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Dungeon Explorer Vol. 3", "Underground Rat Fortress",

			new BookPageInfo
			(
				"Located far southeast of",
				"Hammerhill lies a small",
				"shrine that leads",
				"directly into an",
				"underground fortress,",
				"heavily populated by",
				"rat-like creatures that",
				"have long since made the"
			),
			new BookPageInfo
			(
				"establishment their",
				"personal dwelling spot.",
				"Be on your guard upon",
				"entering the third floor",
				"as some of the residents",
				"know a thing or two",
				"about hurling magical",
				"projectiles. Though if"
			),
			new BookPageInfo
			(
				"your Taming skill is",
				"adequate you might be",
				"able to tame some of the",
				"four legged beasts that",
				"wander the various",
				"halls. Scattered",
				"throughout the dungeon",
				"are locked treasure"
			),
			new BookPageInfo
			(
				"chests that require a",
				"skill range of 15-20 to",
				"access depending on the",
				"floor and depending on",
				"luck may house some of",
				"the denizens most prized",
				"possessions. Even some",
				"of the doors, such as"
			),
			new BookPageInfo
			(
				"the actual entrance",
				"require at least a skill",
				"level of 15 in order to",
				"unlock."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public CBookDungeonExplorerVol3() : base( 0xFEF, false )
		{
		}

		public CBookDungeonExplorerVol3( Serial serial ) : base( serial )
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