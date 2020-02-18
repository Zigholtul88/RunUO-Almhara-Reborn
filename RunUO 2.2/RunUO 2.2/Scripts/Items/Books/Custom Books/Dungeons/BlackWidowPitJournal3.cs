using System;
using Server;

namespace Server.Items
{
	public class BlackWidowPitJournal3 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Day 29", "Tamrin, Journeyman Digger",

			new BookPageInfo
			(
				"Yep, I should have known",
				"that more to this",
				"madness awaited us as we",
				"trekked further into the",
				"depths. Plenty of",
				"arachnids to go around,",
				"some even bigger than",
				"before and goodness you"
			),
			new BookPageInfo
			(
				"wanna talk venomous.",
				"Their bites are more",
				"virulent and even more",
				"caustic to where it",
				"matches the acidic ph",
				"levels of piranha",
				"solution. I think we're",
				"done with this place."
			),
			new BookPageInfo
			(
				"The master is not gonna",
				"be too happy upon our",
				"return. I just gotta",
				"remember the code in",
				"order to get past the",
				"high security barriers",
				"or else I'm in deep",
				"trouble."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BlackWidowPitJournal3() : base( 0xFF3, false )
		{
		}

		public BlackWidowPitJournal3( Serial serial ) : base( serial )
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