using System;
using Server;

namespace Server.Items
{
	public class RideIntoTheSunsetLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Ride Into The Sunset", "Lost Isle Swing Carole",

			new BookPageInfo
			(
				"I've wrangled, and I've",
				"rambled, and I've",
				"rodeoed around.",
				"I've never once thought",
				"about settling down.",
				"But darlin', the moment",
				"that I laid eyes on you,",
				"I knew my ramblin' days"
			),
			new BookPageInfo
			(
				"were through.",
				"",
				"Made up my mind a long",
				"time ago.",
				"When the right man came",
				"along, somehow I'd know.",
				"Heart as true, eyes as",
				"blue, and his smile as"
			),
			new BookPageInfo
			(
				"white, as a Western sky.",
				"",
				"Let's ride into the",
				"sunset together,",
				"Stirrup to stirrup, side",
				"by side.",
				"When the day is through,",
				"I'll be here with you."
			),
			new BookPageInfo
			(
				"Into the sunset we will",
				"ride.",
				"",
				"I'll be your cowgirl,",
				"you'll be my cowboy.",
				"You'll be my Dale, I'll",
				"be your Roy.",
				"When the day is done,"
			),
			new BookPageInfo
			(
				"homeward we'll be",
				"winding.",
				"Like a movie with a",
				"happy ending.",
				"",
				"Let's ride into the",
				"sunset together,",
				"Stirrup to stirrup, side"
			),
			new BookPageInfo
			(
				"by side.",
				"When the day is through,",
				"I'll be here with you.",
				"Into the sunset we will",
				"ride."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public RideIntoTheSunsetLyrics() : base( 0xFF4, false )
		{
		}

		public RideIntoTheSunsetLyrics( Serial serial ) : base( serial )
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