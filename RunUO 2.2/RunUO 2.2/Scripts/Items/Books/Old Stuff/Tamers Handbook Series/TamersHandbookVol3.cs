using System;
using Server;

namespace Server.Items
{
	public class TamersHandbookVol3 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Tamers Handbook Vol 3", "Autum Wood",

			new BookPageInfo
			(
				"By purchasing this",
				"manual you have",
				"basically made pursuing",
				"the art of taming a",
				"slight bit easier. Which",
				"is a good thing",
				"considering its normally",
				"quite a daunting task."
			),
			new BookPageInfo
			(
				"Detailed below is a list",
				"of all the creatures",
				"that are scattered",
				"throughout the region",
				"that are tameable and it",
				"has been organized based",
				"off of skill level.",
				""
			),
			new BookPageInfo
			(
				"Creatures by Taming",
				"Order",
				"- Rat: 0.0",
				"- Hind: 23.1",
				"- Boar: 29.1",
				"- Great Hart: 30.0",
				"- Oakwood Snarler Pup:",
				"30.0"
			),
			new BookPageInfo
			(
				"- Razorback Raptor: 32.5",
				"- Black Bear: 35.1"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public TamersHandbookVol3() : base( 0xFF0, false )
		{
			Weight = 0.1;
                        Hue = 2110;
		}

		public TamersHandbookVol3( Serial serial ) : base( serial )
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