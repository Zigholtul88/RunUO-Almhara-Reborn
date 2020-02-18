using System;
using Server;

namespace Server.Items
{
	public class BeatItLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Beat It", "Angelo Ratchet",

			new BookPageInfo
			(
				"They told him don't you",
				"ever come around here",
				"Don't wanna see your",
				"face, you better",
				"disappear",
				"The fire's in their eyes",
				"and their words are",
				"really clear"
			),
			new BookPageInfo
			(
				"So beat it, just beat it",
				"",
				"You better run, you",
				"better do what you can",
				"Don't wanna see no",
				"blood, don't be a macho",
				"man",
				"You wanna be tough,"
			),
			new BookPageInfo
			(
				"better do what you can",
				"So beat it, but you",
				"wanna be bad",
				"Just beat it, beat it,",
				"beat it, beat it",
				"No one wants to be",
				"defeated",
				"Showin' how funky and"
			),
			new BookPageInfo
			(
				"strong is your fight",
				"It doesn't matter who's",
				"wrong or right",
				"Just beat it, beat it",
				"Just beat it, beat it",
				"Just beat it, beat it",
				"Just beat it, beat it",
				""
			),
			new BookPageInfo
			(
				"They're out to get you,",
				"better leave while you",
				"can",
				"Don't wanna be a boy,",
				"you wanna be a man",
				"You wanna stay alive,",
				"better do what you can",
				"So beat it, just beat it"
			),
			new BookPageInfo
			(
				"You have to show them",
				"that you're really not",
				"scared",
				"You're playin' with your",
				"life, this ain't no",
				"truth or dare",
				"They'll kick you, then",
				"they beat you,"
			),
			new BookPageInfo
			(
				"Then they'll tell you",
				"it's fair",
				"So beat it, but you",
				"wanna be bad",
				"Just beat it, beat it,",
				"beat it, beat it",
				"No one wants to be",
				"defeated"
			),
			new BookPageInfo
			(
				"Showin' how funky and",
				"strong is your fight",
				"It doesn't matter who's",
				"wrong or right",
				"Just beat it, beat it,",
				"beat it, beat it",
				"No one wants to be",
				"defeated"
			),
			new BookPageInfo
			(
				"Showin' how funky and",
				"strong is your fight",
				"It doesn't matter who's",
				"wrong or right",
				"Just beat it, beat it,",
				"beat it, beat it",
				"No one wants to be",
				"defeated"
			),
			new BookPageInfo
			(
				"Showin' how funky and",
				"strong is your fight",
				"It doesn't matter who's",
				"wrong or right",
				"Just beat it, beat",
				"itBeat it, beat it, beat",
				"it",
				"Beat it, beat it, beat"
			),
			new BookPageInfo
			(
				"it, beat it",
				"No one wants to be",
				"defeated",
				"Showin' how funky and",
				"strong is your fight",
				"It doesn't matter who's",
				"wrong or who's right",
				"Just beat it, beat it,"
			),
			new BookPageInfo
			(
				"beat it, beat it",
				"No one wants to be",
				"defeated",
				"Showin' how funky and",
				"strong is your fight",
				"It doesn't matter who's",
				"wrong or right",
				"Just beat it, beat it,"
			),
			new BookPageInfo
			(
				"beat it, beat it",
				"No one wants to be",
				"defeated",
				"Showin' how funky and",
				"strong is your fight",
				"It doesn't matter who's",
				"wrong or right",
				"Just beat it, beat it"
			),
			new BookPageInfo
			(
				"Beat it, beat it, beat",
				"it",
				"Beat it, beat it, beat",
				"it, beat it",
				"No one wants to be",
				"defeated",
				"Showin' how funky and",
				"strong is your fight"
			),
			new BookPageInfo
			(
				"It doesn't matter who's",
				"wrong or who's right",
				"Just beat it, beat it,",
				"beat it, beat it",
				"No one wants to be",
				"defeated",
				"Showin' how funky and",
				"strong is your fight"
			),
			new BookPageInfo
			(
				"It doesn't matter who's",
				"wrong or right",
				"Just beat it, beat it,",
				"beat it, beat it",
				"No one wants to be",
				"defeated",
				"Showin' how funky and",
				"strong is your fight"
			),
			new BookPageInfo
			(
				"It doesn't matter who's",
				"wrong or right",
				"Just beat it, beat it,",
				"beat it, beat it",
				"No one wants to be",
				"defeated",
				"Just beat it, beat it",
				"Beat it, beat it, beat it"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BeatItLyrics() : base( 0xFF4, false )
		{
		}

		public BeatItLyrics( Serial serial ) : base( serial )
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