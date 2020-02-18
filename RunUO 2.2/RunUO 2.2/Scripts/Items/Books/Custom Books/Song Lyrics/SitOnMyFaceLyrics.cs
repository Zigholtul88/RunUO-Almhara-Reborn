using System;
using Server;

namespace Server.Items
{
	public class SitOnMyFaceLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Sit On My Face", "Jaunty Anaconda",

			new BookPageInfo
			(
				"Sit on my face and tell",
				"me that you love me",
				"I'll sit on your face",
				"and tell you I love you",
				"too",
				"I love to hear you",
				"oralize",
				"When I'm between your"
			),
			new BookPageInfo
			(
				"thighs",
				"You blow me away",
				"",
				"Sit on my face and let",
				"my lips embrace you",
				"I'll sit on your face",
				"and then I'll love you",
				"truly"
			),
			new BookPageInfo
			(
				"Life can be fine if we",
				"both sixty nine",
				"If we sit on our faces",
				"in all sorts of places",
				"And play till we're",
				"blown away"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public SitOnMyFaceLyrics() : base( 0xFF4, false )
		{
		}

		public SitOnMyFaceLyrics( Serial serial ) : base( serial )
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