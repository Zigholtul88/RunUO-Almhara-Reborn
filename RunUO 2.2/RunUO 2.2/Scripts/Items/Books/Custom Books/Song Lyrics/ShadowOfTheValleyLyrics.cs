using System;
using Server;

namespace Server.Items
{
	public class ShadowOfTheValleyLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Shadow of the Valley", "Lost Isle Swing Carole",

			new BookPageInfo
			(
				"In the shadow of the",
				"valley",
				"I would like to settle",
				"down",
				"Wide open space",
				"Wind on my face",
				"",
				"A distant horizon"
			),
			new BookPageInfo
			(
				"The moon on the crest",
				"In the shadow of the",
				"valley",
				"That I love best",
				"",
				"You have always waited",
				"for me",
				"And you always will be"
			),
			new BookPageInfo
			(
				"there",
				"Sage brush and pine",
				"Old friends of mine",
				"",
				"A little bit further",
				"I will find my rest",
				"In the shadow of the",
				"valley"
			),
			new BookPageInfo
			(
				"That I love best",
				"",
				"I have wandered many",
				"places",
				"But they're all the same",
				"to me",
				"Nowhere I've found",
				"To settle down"
			),
			new BookPageInfo
			(
				"",
				"A little bit further",
				"I'll find my rest",
				"In the shadow of the",
				"valley",
				"That I love best",
				"",
				"In the shadow of the"
			),
			new BookPageInfo
			(
				"valley",
				"That I love best"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public ShadowOfTheValleyLyrics() : base( 0xFF4, false )
		{
		}

		public ShadowOfTheValleyLyrics( Serial serial ) : base( serial )
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