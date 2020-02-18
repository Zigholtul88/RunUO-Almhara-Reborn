using System;
using Server;

namespace Server.Items
{
	public class HammerhillSewersJournal3 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Sewer Journal 3", "Unknown Stranger",

			new BookPageInfo
			(
				"Yes I am apparently not",
				"the only human down",
				"inside these sewers and",
				"just like everything",
				"else around here they",
				"too are also aggressive",
				"and pack quite a",
				"venomous bite. How in"
			),
			new BookPageInfo
			(
				"the fuck am I still",
				"alive? Perhaps that cow",
				"meat might be what's",
				"keeping me from falling",
				"over. Also these hobos",
				"must have gone mental",
				"because they spout such",
				"nonsensical gibberish"
			),
			new BookPageInfo
			(
				"about something",
				"concerning the king of",
				"the rabbit horde. Are",
				"they talking about that",
				"rabbit whose been hiding",
				"inside of a cave right",
				"outside town?"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public HammerhillSewersJournal3() : base( 0xFBE, false )
		{
			Hue = 2101;
		}

		public HammerhillSewersJournal3( Serial serial ) : base( serial )
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