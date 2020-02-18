using System;
using Server;

namespace Server.Items
{
	public class BigIronLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Big Iron", "Marty Swallowtail",

			new BookPageInfo
			(
				"To the town of Alp",
				"Sierra, rode a stranger",
				"one fine day.",
				"Hardly spoke to folks",
				"around him, didn't have",
				"too much to say.",
				"",
				"No one dared to ask his"
			),
			new BookPageInfo
			(
				"business, no one dared",
				"to make a slip.",
				"For the stranger there",
				"amongst them, had a big",
				"iron on his hip.",
				"Big iron on his hip.",
				"",
				"It was early in the"
			),
			new BookPageInfo
			(
				"morning, when he rode",
				"into the town.",
				"He came riding from the",
				"south side, slowly",
				"lookin' all around.",
				"",
				"He's an outlaw loose and",
				"running, came the"
			),
			new BookPageInfo
			(
				"whisper from each lip.",
				"And he's here to do some",
				"business, with the big",
				"iron on his hip.",
				"Big iron on his hip.",
				"",
				"In this town there lived",
				"an outlaw, by the name"
			),
			new BookPageInfo
			(
				"of Lexus Red.",
				"Many men had tried to",
				"take him and that many",
				"men were dead.",
				"",
				"He was vicious and a",
				"killer, though a youth",
				"of twenty-four."
			),
			new BookPageInfo
			(
				"And the notches on his",
				"grip, numbered one and",
				"nineteen more.",
				"One and nineteen more.",
				"",
				"Now the stranger started",
				"talking, made it plain",
				"to folks around;"
			),
			new BookPageInfo
			(
				"Was an Hammerhill",
				"Ranger, wouldn't be too",
				"long in town.",
				"",
				"He came here to take an",
				"outlaw back, alive, or",
				"maybe dead.",
				"And he said it didn't"
			),
			new BookPageInfo
			(
				"matter; he was after",
				"Lexus Red.",
				"After Lexus Red.",
				"",
				"Wasn't long before the",
				"story was relayed to",
				"Lexus Red.",
				"But the outlaw didn't"
			),
			new BookPageInfo
			(
				"worry; men that tried",
				"before were dead.",
				"",
				"Twenty men had tried to",
				"take him; twenty men had",
				"made a slip.",
				"Twenty-one would be the",
				"Ranger; with the big"
			),
			new BookPageInfo
			(
				"iron on his hip.",
				"Big iron on his hip.",
				"",
				"The morning passed so",
				"quickly, it was time for",
				"them to meet.",
				"It was twenty past",
				"eleven, when they walked"
			),
			new BookPageInfo
			(
				"out in the street.",
				"",
				"Folks were watching from",
				"their windows;",
				"every-body held their",
				"breath.",
				"They knew this handsome",
				"Ranger, was about to"
			),
			new BookPageInfo
			(
				"meet his death.",
				"About to meet his death.",
				"",
				"There was forty feet",
				"between them, when they",
				"stopped to make their",
				"play.",
				"And the swiftness of the"
			),
			new BookPageInfo
			(
				"Ranger, is still talked",
				"about today.",
				"",
				"Lexus Red had not",
				"cleared leather, when an",
				"arrow fairly ripped.",
				"And the Ranger’s aim was",
				"deadly, with the big"
			),
			new BookPageInfo
			(
				"iron on his hip.",
				"Big iron on his hip.",
				"",
				"It was over in a moment,",
				"and the folks had",
				"gathered round.",
				"There before them lay",
				"the body of the outlaw,"
			),
			new BookPageInfo
			(
				"on the ground.",
				"",
				"Oh, he might have gone",
				"on living, but he made",
				"one fatal slip.",
				"When he tried to match",
				"the Ranger, with the big",
				"iron on his hip."
			),
			new BookPageInfo
			(
				"Big iron on his hip.",
				"",
				"Big iron. Big iron.",
				"",
				"When he tried to match",
				"the Ranger, with the big",
				"iron on his hip.",
				""
			),
			new BookPageInfo
			(
				"Big iron on his hip."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BigIronLyrics() : base( 0xFF4, false )
		{
		}

		public BigIronLyrics( Serial serial ) : base( serial )
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