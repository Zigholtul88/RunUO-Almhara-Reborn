using System;
using Server;

namespace Server.Items
{
	public class SunlightLivingLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Sunlight Living", "Hynie Hymn",

			new BookPageInfo
			(
				"I'm so happy!",
				"AHA! Happy go lucky me!",
				"",
				"I just go my way,",
				"living everyday!",
				"",
				"I don't worry!",
				"Worrying don't agree,"
			),
			new BookPageInfo
			(
				"Things that bother you,",
				"never bother me!",
				"",
				"Things that bother you,",
				"never bother me!",
				"I feel happy and fine!",
				"AHA!",
				""
			),
			new BookPageInfo
			(
				"Living in the sunlight,",
				"loving in the moonlight",
				"Having a wonderful time!",
				"",
				"Haven't got a lot,",
				"I don't need a lot",
				"Coffee's only a dime",
				""
			),
			new BookPageInfo
			(
				"Living in the sunlight,",
				"loving in the moonlight,",
				"having a wonderful time!",
				"",
				"Just take it from me,",
				"I'm just as free as any",
				"daughter.",
				"I do what I like,"
			),
			new BookPageInfo
			(
				"just what I like,",
				"and how I love it!",
				"",
				"I'm right here to stay",
				"When I'm old and gray,",
				"I'll be right in my",
				"prime!",
				""
			),
			new BookPageInfo
			(
				"Living in the sunlight,",
				"loving in the moonlight,",
				"having a wonderful time!",
				"",
				"Hum hum hum hum hum hum",
				"hum hum hum hum hum hum",
				"dodododo dodododo",
				"do do dodo do"
			),
			new BookPageInfo
			(
				"",
				"Just take it from me,",
				"I'm just as free as any",
				"daughter.",
				"I do what I like,",
				"just what I like,",
				"and how I love it!",
				""
			),
			new BookPageInfo
			(
				"I'm right here to stay,",
				"When I'm old and gray,",
				"I'll be right in my",
				"prime,",
				"Living in the sunlight,",
				"loving in the moonlight,",
				"Having a wonderful time!"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public SunlightLivingLyrics() : base( 0xFF4, false )
		{
		}

		public SunlightLivingLyrics( Serial serial ) : base( serial )
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