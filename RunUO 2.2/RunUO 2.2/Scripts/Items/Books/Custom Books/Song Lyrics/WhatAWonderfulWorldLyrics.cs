using System;
using Server;

namespace Server.Items
{
	public class WhatAWonderfulWorldLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"What A Wonderful World", "Louie Strongarm",

			new BookPageInfo
			(
				"I see trees of green,",
				"red roses too",
				"I see them bloom for me",
				"and you",
				"And I think to myself",
				"what a wonderful world.",
				"",
				"I see skies of blue and"
			),
			new BookPageInfo
			(
				"clouds of white",
				"The bright blessed day,",
				"the dark sacred night",
				"And I think to myself",
				"what a wonderful world.",
				"",
				"The colors of the",
				"rainbow so pretty in the"
			),
			new BookPageInfo
			(
				"sky",
				"Are also on the faces of",
				"people going by",
				"I see friends shaking",
				"hands saying how do you",
				"do",
				"They're really saying I",
				"love you."
			),
			new BookPageInfo
			(
				"",
				"I hear babies cry, I",
				"watch them grow",
				"They'll learn much more",
				"than I'll never know",
				"And I think to myself",
				"what a wonderful world",
				"Yes I think to myself"
			),
			new BookPageInfo
			(
				"what a wonderful world."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public WhatAWonderfulWorldLyrics() : base( 0xFF4, false )
		{
		}

		public WhatAWonderfulWorldLyrics( Serial serial ) : base( serial )
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