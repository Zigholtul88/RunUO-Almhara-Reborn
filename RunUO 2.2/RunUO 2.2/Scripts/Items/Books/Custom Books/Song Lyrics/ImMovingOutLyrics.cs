using System;
using Server;

namespace Server.Items
{
	public class ImMovingOutLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"I'm Moving Out", "The Rogue Brothers",

			new BookPageInfo
			(
				"Tell me what's in a kiss",
				"If your heart's not in",
				"it",
				"We could have wedded",
				"bliss",
				"If we'd only begin it",
				"I'm feeling little low",
				"down"
			),
			new BookPageInfo
			(
				"You know what I'm",
				"talking about",
				"You let the blues move",
				"in",
				"Now I'm moving out",
				"",
				"This old house ain't a",
				"home"
			),
			new BookPageInfo
			(
				"With no love inside it",
				"We set out pretty strong",
				"Now we just can't fight",
				"it",
				"I'm leaving today",
				"I don't want to argue or",
				"shout",
				"You let the blues move"
			),
			new BookPageInfo
			(
				"in",
				"Now I'm moving out",
				"",
				"What's the use in buying",
				"a bar",
				"If you won't buy",
				"hennessy",
				"We used to be two under"
			),
			new BookPageInfo
			(
				"par",
				"Now we can't get on the",
				"green",
				"Tell me where can I go",
				"East or west or north or",
				"due south",
				"You let the blues move",
				"in"
			),
			new BookPageInfo
			(
				"Now I'm moving out",
				"",
				"I don't know where it",
				"went",
				"But it sure went a",
				"flying",
				"Love's like dough that's",
				"been spent"
			),
			new BookPageInfo
			(
				"Now there's no use a",
				"crying",
				"Tell me where can I go",
				"East or west or north or",
				"due south",
				"You let the blues move",
				"in",
				"Now I'm moving out"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public ImMovingOutLyrics() : base( 0xFF4, false )
		{
		}

		public ImMovingOutLyrics( Serial serial ) : base( serial )
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