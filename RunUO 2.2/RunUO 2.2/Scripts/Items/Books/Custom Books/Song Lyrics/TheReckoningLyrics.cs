using System;
using Server;

namespace Server.Items
{
	public class TheReckoningLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"The Reckoning", "Iced Earth",

			new BookPageInfo
			(
				"Destiny's called us",
				"It's the reckoning",
				"This time it's for blood",
				"Don't tread on me",
				"Revenge is not justice",
				"It's the reckoning",
				"This time it's for blood",
				"Don't tread on me"
			),
			new BookPageInfo
			(
				"",
				"You went too far this",
				"time",
				"For this heinous crime",
				"You will know defeat",
				"Begging on your knees",
				"",
				"One by one you'll fall"
			),
			new BookPageInfo
			(
				"Your back's against the",
				"wall",
				"Nowhere to turn",
				"You're sure to burn",
				"",
				"Destiny's called us",
				"It's the reckoning",
				"This time it's for blood"
			),
			new BookPageInfo
			(
				"Don't tread on me",
				"",
				"The hour's close at hand",
				"We'll make our final",
				"stand",
				"Justice shall be done",
				"Nowhere to run",
				""
			),
			new BookPageInfo
			(
				"True evil broods in you",
				"You're just a",
				"brainwashed fool",
				"The coward kills then",
				"hides",
				"Spewing forth his lies",
				"",
				"Revenge is not justice"
			),
			new BookPageInfo
			(
				"It's the reckoning",
				"This time it's for blood",
				"Don't tread on me",
				"",
				"Born of destruction,",
				"bred in agony",
				"Is this my salvation?",
				"From these ashes, I am"
			),
			new BookPageInfo
			(
				"your devastation",
				"",
				"If it was up to me",
				"Eye for an eye I'd seek",
				"But the high road we",
				"will take",
				"Lady Justice is at stake",
				""
			),
			new BookPageInfo
			(
				"The judgement has been",
				"made",
				"In blood it shall be",
				"paid",
				"Death knows what to do",
				"The horseman comes from",
				"you",
				""
			),
			new BookPageInfo
			(
				"Destiny's called us",
				"It's the reckoning",
				"This time it's for blood",
				"Don't tread on me",
				"Revenge is not justice",
				"It's the reckoning",
				"This time it's for blood",
				"Don't tread on me"
			),
			new BookPageInfo
			(
				"",
				"Destiny's called us",
				"It's the reckoning",
				"This time it's for blood",
				"Don't tread on me",
				"Revenge is not justice",
				"It's the reckoning",
				"This time it's for blood"
			),
			new BookPageInfo
			(
				"Don't tread on me"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public TheReckoningLyrics() : base( 0xFF4, false )
		{
		}

		public TheReckoningLyrics( Serial serial ) : base( serial )
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