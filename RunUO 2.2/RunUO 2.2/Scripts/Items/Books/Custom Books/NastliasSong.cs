using System;
using Server;

namespace Server.Items
{
	public class NastliasSong : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Nastlias Song", "Nastlia Kensley",

			new BookPageInfo
			(
				"(These Words To Mend",
				"Your Mind)",
				"",
				"Come unto me child,",
				"oh burdened one.",
				"Lay upon my arms,",
				"for the night has just",
				"begun."
			),
			new BookPageInfo
			(
				"Look into me darling,",
				"and see that you will",
				"find.",
				"As I sing to you,",
				"these words to mend your",
				"mind.",
				"",
				"Cleanse away your"
			),
			new BookPageInfo
			(
				"saddened tears,",
				"and store away despair.",
				"Push aside your deepest",
				"doubts,",
				"you should no longer",
				"bear.",
				"Throw away your caustic",
				"thoughts,"
			),
			new BookPageInfo
			(
				"and rid yourself of",
				"blight.",
				"Leave behind your",
				"bitterness,",
				"for there is hope in",
				"sight.",
				"",
				"Come unto me child,"
			),
			new BookPageInfo
			(
				"oh burdened one.",
				"Lay upon my arms,",
				"for the night has just",
				"begun.",
				"Look into me darling,",
				"and see that you will",
				"find.",
				"As I sing to you,"
			),
			new BookPageInfo
			(
				"these words to mend your",
				"mind.",
				"",
				"Lend to me your weary",
				"heart,",
				"and store away all",
				"sorrow.",
				"The night is very young"
			),
			new BookPageInfo
			(
				"at hand,",
				"therefore a bright",
				"tomorrow.",
				"Put aside your tragedy,",
				"so you must not regret.",
				"Beyond the dark there",
				"lies a truth,",
				"a truth you'll not"
			),
			new BookPageInfo
			(
				"regret.",
				"",
				"You must never settle",
				"down,",
				"do not give up on your",
				"life.",
				"Nor you shouldn't allow",
				"temptation,"
			),
			new BookPageInfo
			(
				"from causing you more",
				"strife.",
				"Cast aside your war torn",
				"past,",
				"remove yourself from",
				"fright.",
				"Unbind the chains that",
				"cause you fear,"
			),
			new BookPageInfo
			(
				"and look into heaven's",
				"light.",
				"And see within your",
				"honest eyes,",
				"the one that you adore.",
				"Will always remain by",
				"your side,",
				"forever now....... and"
			),
			new BookPageInfo
			(
				"forever more.",
				"",
				"Come unto me child,",
				"and try to get some",
				"rest.",
				"Lay upon my arms,",
				"and ease away distress.",
				"Listen to me darling,"
			),
			new BookPageInfo
			(
				"while you try to unwind.",
				"As I sing to you,",
				"these words espoused in",
				"kind.",
				"As I sing to you,",
				".......these words to",
				"mend your mind."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public NastliasSong() : base( 0x1C11, false )
		{
                        Name = "These Words To Mend Your Mind";
			Hue = 372;
		}

		public NastliasSong( Serial serial ) : base( serial )
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