using System;
using Server;

namespace Server.Items
{
	public class ListenToTheWindLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Listen To The Wind", "Honeydew Hailey",

			new BookPageInfo
			(
				"Time is a river that",
				"flows endlessly",
				"And a life is a whisper,",
				"a kiss in a dream",
				"",
				"Shadows dance behind the",
				"firelight",
				"And all the spirits of"
			),
			new BookPageInfo
			(
				"the night remind us:",
				"We are not alone",
				"",
				"Tomorrow: a sun soon",
				"rising",
				"And yesterday is there",
				"beside us",
				"And it's never far away"
			),
			new BookPageInfo
			(
				"",
				"If you listen to the",
				"wind you can hear me",
				"again",
				"Even when I'm gone you",
				"can still hear the song",
				"High up in the trees as",
				"it moves through the"
			),
			new BookPageInfo
			(
				"leaves",
				"Listen to the wind,",
				"there's no end to my...",
				"",
				"Love is forever a circle",
				"unbroken",
				"The seasons keep",
				"changing; it always"
			),
			new BookPageInfo
			(
				"remains",
				"",
				"Spring will melt the",
				"snows of winter",
				"And the summer gives us",
				"days of light",
				"So long till autumn",
				"makes them fade"
			),
			new BookPageInfo
			(
				"",
				"Remember the sound of",
				"laughter",
				"We ran together through",
				"the meadows",
				"Still we thought our",
				"hearts could break",
				""
			),
			new BookPageInfo
			(
				"If you listen to the",
				"wind, you can hear me",
				"again",
				"Even when I'm gone you",
				"can still hear the song",
				"High up in the trees as",
				"it moves through the",
				"leaves"
			),
			new BookPageInfo
			(
				"Listen to the wind and",
				"I'll send you my love",
				"",
				"Listen to the wind where",
				"the sky meets the land",
				"I'm not really gone I've",
				"been here all along",
				"High up in the trees in"
			),
			new BookPageInfo
			(
				"the sound of the leaves",
				"Listen to the wind",
				"there's no end to my...",
				"",
				"Time is a river that",
				"flows to the sea",
				"And a life is a whisper,",
				"a kiss in a dream."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public ListenToTheWindLyrics() : base( 0xFF4, false )
		{
		}

		public ListenToTheWindLyrics( Serial serial ) : base( serial )
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