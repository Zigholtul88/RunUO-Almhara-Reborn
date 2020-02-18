using System;
using Server;

namespace Server.Items
{
	public class JingleJangleJingleLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Jingle Jangle Jingle", "Kwi Kaiser",

			new BookPageInfo
			(
				"Yippie yay",
				"There'll be no weddin'",
				"bells for today",
				"",
				"'Cause I got spurs that",
				"jingle, jangle, jingle",
				"Jingle, jangle",
				"As I go ridin' merrily"
			),
			new BookPageInfo
			(
				"along",
				"Jingle, jangle",
				"And they sing, 'Oh,",
				"ain't you glad you're",
				"single?'",
				"Jingle, jangle",
				"And that song ain't so",
				"very far from wrong"
			),
			new BookPageInfo
			(
				"Jingle, jangle",
				"",
				"Oh, Lillie Belle",
				"Oh, Lillie Belle",
				"Oh, Lillie Belle",
				"Oh, Lillie Belle",
				"Though I may have done",
				"some foolin'"
			),
			new BookPageInfo
			(
				"This is why I never fell",
				"",
				"'Cause I got spurs that",
				"jingle, jangle, jingle",
				"Jingle, jangle",
				"As I go ridin' merrily",
				"along",
				"Jingle, jangle"
			),
			new BookPageInfo
			(
				"And they sing, 'Oh,",
				"ain't you glad you're",
				"single?'",
				"Jingle, jangle",
				"And that song ain't so",
				"very far from wrong",
				"Jingle, jangle",
				""
			),
			new BookPageInfo
			(
				"Oh, I got spurs that",
				"jingle, jangle, jingle",
				"I got spurs that jingle,",
				"jangle, jingle",
				"As I go ridin' merrily",
				"along",
				"As I go ridin' merrily",
				"along"
			),
			new BookPageInfo
			(
				"And they sing, 'Oh,",
				"ain't you glad you're",
				"single?'",
				"And they sing, 'Oh,",
				"ain't you glad you're",
				"single?'",
				"And that song ain't so",
				"very far from wrong"
			),
			new BookPageInfo
			(
				"And that song ain't so",
				"very far from wrong",
				"",
				"Oh, Lillie Belle",
				"Oh, Lillie Belle",
				"Though I may have done",
				"some foolin'",
				"This is why I never fell"
			),
			new BookPageInfo
			(
				"Why I never fell",
				"",
				"'Cause I got spurs that",
				"jingle, jangle, jingle",
				"I got spurs that jingle,",
				"jangle, jingle",
				"As I go ridin' merrily",
				"along"
			),
			new BookPageInfo
			(
				"As I go ridin' merrily",
				"along",
				"And they sing, 'Oh,",
				"ain't you glad you're",
				"single?'",
				"And they sing, 'Oh,",
				"ain't you glad you're",
				"single?'"
			),
			new BookPageInfo
			(
				"And that song ain't so",
				"very far from wrong",
				"And that song ain't so",
				"very far from wrong"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public JingleJangleJingleLyrics() : base( 0xFF4, false )
		{
		}

		public JingleJangleJingleLyrics( Serial serial ) : base( serial )
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