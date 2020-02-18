using System;
using Server;

namespace Server.Items
{
	public class GravityOfLoveLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Gravity of Love", "Elinement",

			new BookPageInfo
			(
				"Turn around and smell",
				"what you don't see",
				"Close your eyes ... it",
				"is so clear",
				"Here's the mirror,",
				"behind there is a screen",
				"On both ways you can get",
				"in"
			),
			new BookPageInfo
			(
				"",
				"Don't think twice before",
				"you listen to your heart",
				"Follow the trace for a",
				"new start",
				"",
				"What you need and",
				"everything you'll feel"
			),
			new BookPageInfo
			(
				"Is just a question of",
				"the deal",
				"In the eye of storm",
				"you'll see a lonely dove",
				"The experience of",
				"survival is the key",
				"To the gravity of love",
				""
			),
			new BookPageInfo
			(
				"Oh fortuna!",
				"Verate luna!",
				"",
				"The path of excess leads",
				"to",
				"The tower of Wisdom",
				"The path of excess leads",
				"to"
			),
			new BookPageInfo
			(
				"The tower of Wisdom",
				"",
				"Try to think about it",
				"...",
				"That's the chance to",
				"live your life and",
				"discover",
				"What it is, what's the"
			),
			new BookPageInfo
			(
				"gravity of love",
				"",
				"Oh fortuna!",
				"Verate luna!",
				"",
				"Look around just people,",
				"can you hear their voice",
				"Find the one who'll"
			),
			new BookPageInfo
			(
				"guide you to the limits",
				"of your choice",
				"",
				"But if you're in the eye",
				"of storm",
				"Just think of the lonely",
				"dove",
				"The experience of"
			),
			new BookPageInfo
			(
				"survival is the key",
				"To the gravity of love",
				"",
				"Oh fortuna!",
				"Verate luna!"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public GravityOfLoveLyrics() : base( 0xFF4, false )
		{
		}

		public GravityOfLoveLyrics( Serial serial ) : base( serial )
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