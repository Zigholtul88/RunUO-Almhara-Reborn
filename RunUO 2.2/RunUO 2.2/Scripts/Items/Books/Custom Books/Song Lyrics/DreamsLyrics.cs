using System;
using Server;

namespace Server.Items
{
	public class DreamsLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Dreams", "Vahn Draylon",

			new BookPageInfo
			(
				"World turns black and",
				"white",
				"Pictures in an empty",
				"room",
				"Your love starts fallin'",
				"down",
				"Better change your tune",
				""
			),
			new BookPageInfo
			(
				"Yeah, you reach for the",
				"golden ring",
				"Reach for the sky",
				"Baby, just spread your",
				"wings",
				"",
				"And get higher and",
				"higher"
			),
			new BookPageInfo
			(
				"Straight up we'll climb",
				"We'll get higher and",
				"higher",
				"Leave it all behind",
				"",
				"Run, run, run away",
				"Like a train runnin' off",
				"the track"
			),
			new BookPageInfo
			(
				"Got the truth bein' left",
				"behind",
				"Falls between the cracks",
				"",
				"Standin' on broken",
				"dreams",
				"Never losin' sight, ah",
				"Well, just spread your"
			),
			new BookPageInfo
			(
				"wings",
				"",
				"We'll get higher and",
				"higher",
				"Straight up we'll climb",
				"We'll get higher and",
				"higher",
				"Leave it all behind"
			),
			new BookPageInfo
			(
				"",
				"So baby, dry your eyes",
				"Save all the tears",
				"you've cried",
				"Oh, that's what dreams",
				"are made of",
				"'Cause we belong in a",
				"world that must be"
			),
			new BookPageInfo
			(
				"strong",
				"Oh, that's what dreams",
				"are made of",
				"",
				"Yeah, we'll get higher",
				"and higher",
				"Straight up we'll climb",
				"Higher and higher, leave"
			),
			new BookPageInfo
			(
				"it all behind",
				"Oh, we'll get higher and",
				"higher",
				"Who knows what we'll",
				"find?",
				"",
				"So baby, dry your eyes",
				"Save all the tears"
			),
			new BookPageInfo
			(
				"you've cried",
				"Oh, that's what dreams",
				"are made of",
				"Oh baby, we belong in a",
				"world that must be",
				"strong",
				"Oh, that's what dreams",
				"are made of"
			),
			new BookPageInfo
			(
				"",
				"And in the end, on",
				"dreams we will depend",
				"'Cause that's what love",
				"is made of"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public DreamsLyrics() : base( 0xFF4, false )
		{
		}

		public DreamsLyrics( Serial serial ) : base( serial )
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