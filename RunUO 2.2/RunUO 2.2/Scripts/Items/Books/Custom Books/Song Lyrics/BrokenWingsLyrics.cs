using System;
using Server;

namespace Server.Items
{
	public class BrokenWingsLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Broken Wings", "Miestro M.",

			new BookPageInfo
			(
				"Baby, don't understand",
				"Why we can't just live",
				"long to each other's",
				"hands",
				"This time might be the",
				"last, I fear",
				"Unless I make it all too",
				"clear"
			),
			new BookPageInfo
			(
				"I need you so, ohhhh...",
				"",
				"Take these broken wings",
				"And learn to fly again,",
				"learn to listen free",
				"When we hear the voices",
				"sing",
				"The book of love will"
			),
			new BookPageInfo
			(
				"open up and let us in",
				"Take these broken",
				"wings...",
				"",
				"Baby, I think too nice",
				"We can take what is",
				"wrong and make it right",
				"Baby, it's all I know"
			),
			new BookPageInfo
			(
				"That you're half of the",
				"flesh and blood that",
				"makes me whole",
				"I need you so, ohhhh...",
				"",
				"So take these broken",
				"wings",
				"And learn to fly again,"
			),
			new BookPageInfo
			(
				"learn to listen free",
				"When we hear the voices",
				"sing",
				"The book of love will",
				"open up and let us in",
				"Yeah, let us in",
				"Let us in!",
				""
			),
			new BookPageInfo
			(
				"Baby, it's all I know",
				"That you're half of the",
				"flesh and blood that",
				"makes me whole",
				"Yeah, yeah, yeah...",
				"Yeah, yeah!",
				"",
				"So take these broken"
			),
			new BookPageInfo
			(
				"wings",
				"And learn to fly again,",
				"learn to listen free",
				"When we hear the voices",
				"sing",
				"The book of love will",
				"open up and let us in",
				"Take these broken wings"
			),
			new BookPageInfo
			(
				"You've got to learn to",
				"fly, learn to listen and",
				"love so free",
				"When we hear the voices",
				"sing",
				"The book of love will",
				"open up for us and let",
				"us in"
			),
			new BookPageInfo
			(
				"",
				"Yeah, yeah!",
				"Ooooooh, yeah!"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BrokenWingsLyrics() : base( 0xFF4, false )
		{
		}

		public BrokenWingsLyrics( Serial serial ) : base( serial )
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