using System;
using Server;

namespace Server.Items
{
	public class HammerhillSewersJournal2 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Sewer Journal 2", "Unknown Stranger",

			new BookPageInfo
			(
				"So apparently the folks",
				"of Hammerhill are even",
				"more batshit crazy than",
				"I previously expected,",
				"because not only do they",
				"toss into the sewers",
				"their diseased ridden",
				"cows but now there's"
			),
			new BookPageInfo
			(
				"these slimes that spread",
				"all sorts of noxious",
				"gases and yes they also",
				"inflict poison. I",
				"managed to snag one",
				"inside of a bear trap.",
				"Don't tell me how I was",
				"able to pull off that"
			),
			new BookPageInfo
			(
				"maneuver. All I know is",
				"that it worked and the",
				"damn thing was",
				"screaming, actually it",
				"was expelling tons upon",
				"tons of flatulent",
				"noises. Yes these slimes",
				"like to constantly fart"
			),
			new BookPageInfo
			(
				"up the area. I have to",
				"wonder what else is",
				"lurking down these",
				"sewers."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public HammerhillSewersJournal2() : base( 0xFBE, false )
		{
			Hue = 2101;
		}

		public HammerhillSewersJournal2( Serial serial ) : base( serial )
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