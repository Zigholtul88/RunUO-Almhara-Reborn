using System;
using Server;

namespace Server.Items
{
	public class HammerhillSewersJournal1 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Sewer Journal 1", "Unknown Stranger",

			new BookPageInfo
			(
				"Ever since I have been",
				"branded a criminal of",
				"the state I've been",
				"hiding down within these",
				"sewers. For months now",
				"I've been getting my",
				"daily nutrients from the",
				"local sewer rats that"
			),
			new BookPageInfo
			(
				"roam this place. However",
				"these sewers are not",
				"what they seem to",
				"appear. Shit, how many",
				"times must I use the",
				"term sewer to describe",
				"something? Must be all",
				"the rats I've consumed"
			),
			new BookPageInfo
			(
				"down here. Any way",
				"there's freaking sewer",
				"bovine down here that",
				"are really aggressive,",
				"their bites carrying a",
				"virulent touch to them,",
				"though luckily because I",
				"was in tip top shape the"
			),
			new BookPageInfo
			(
				"effects eventually wore",
				"off. I was thinking",
				"about catching one and",
				"seeing how their meat",
				"tasted, just to see how",
				"sick they were and to my",
				"surprise the steaks",
				"turned out pretty damn"
			),
			new BookPageInfo
			(
				"tasty. Either the folks",
				"of Hammerhill are bloody",
				"stupid or their really",
				"is no difference between",
				"tainted and untainted",
				"meat."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public HammerhillSewersJournal1() : base( 0xFBE, false )
		{
			Hue = 2101;
		}

		public HammerhillSewersJournal1( Serial serial ) : base( serial )
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