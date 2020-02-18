using System;
using Server;

namespace Server.Items
{
	public class HumblingRiverLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"The Humbling River", "Purify",

			new BookPageInfo
			(
				"Nature, nurture heaven",
				"and home",
				"Sum of all, and by them,",
				"driven",
				"To conquer every",
				"mountain shown",
				"But I've never crossed",
				"the river"
			),
			new BookPageInfo
			(
				"",
				"Braved the forests,",
				"braved the stone",
				"Braved the icy winds and",
				"fire",
				"Braved and beat them on",
				"my own",
				"Yet I'm helpless by the"
			),
			new BookPageInfo
			(
				"river",
				"",
				"Angel, angel, what have",
				"I done?",
				"I've faced the quakes,",
				"the wind, the fire",
				"I've conquered country,",
				"crown, and throne"
			),
			new BookPageInfo
			(
				"Why can't I cross this",
				"river?",
				"",
				"Angel, angel, what have",
				"I done?",
				"I've faced the quakes,",
				"the wind, the fire",
				"I've conquered country,"
			),
			new BookPageInfo
			(
				"crown, and throne",
				"Why can't I cross this",
				"river?",
				"",
				"Pay no mind to the",
				"battles you've won",
				"It'll take a lot more",
				"than rage and muscle"
			),
			new BookPageInfo
			(
				"Open your heart and",
				"hands, my son",
				"Or you'll never make it",
				"over the river",
				"",
				"It'll take a lot more",
				"than words and guns",
				"A whole lot more than"
			),
			new BookPageInfo
			(
				"riches and muscle",
				"The hands of the many",
				"must join as one",
				"And together we'll cross",
				"the river",
				"",
				"It'll take a lot more",
				"than words and guns"
			),
			new BookPageInfo
			(
				"A whole lot more than",
				"riches and muscle",
				"The hands of the many",
				"must join as one",
				"And together we'll cross",
				"the river",
				"",
				"(Nature, nurture heaven"
			),
			new BookPageInfo
			(
				"and home)",
				"It'll take a lot more",
				"than words and guns",
				"(Sum of all, and by",
				"them, driven)",
				"A whole lot more than",
				"riches and muscle",
				"(To conquer every"
			),
			new BookPageInfo
			(
				"mountain shown)",
				"The hands of the many",
				"must join as one",
				"And together we'll cross",
				"the river",
				"",
				"(Braved the forests,",
				"braved the stone)"
			),
			new BookPageInfo
			(
				"It'll take a lot more",
				"than words and guns",
				"(Braved the icy winds",
				"and fire)",
				"A whole lot more than",
				"riches and muscle",
				"(Braved and beat them on",
				"my own)"
			),
			new BookPageInfo
			(
				"The hands of the many",
				"must join as one",
				"And together we'll cross",
				"the river",
				"",
				"And together we'll cross",
				"the river",
				"And together we'll cross"
			),
			new BookPageInfo
			(
				"the river",
				"",
				"Nature, nurture heaven",
				"and home",
				"And together we'll cross",
				"the river",
				"And together we'll cross",
				"the river"
			),
			new BookPageInfo
			(
				"",
				"Nature, nurture heaven",
				"and home",
				"And together we'll cross",
				"the river",
				"And together we'll cross",
				"the river"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public HumblingRiverLyrics() : base( 0xFF4, false )
		{
		}

		public HumblingRiverLyrics( Serial serial ) : base( serial )
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