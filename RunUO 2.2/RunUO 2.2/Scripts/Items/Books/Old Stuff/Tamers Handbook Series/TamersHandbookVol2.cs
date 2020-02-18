using System;
using Server;

namespace Server.Items
{
	public class TamersHandbookVol2 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Tamers Handbook Vol 2", "Alytharr Region",

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
				"- Bird: 0.0",
				"- Rabbit: 0.0",
				"- Sheep: 11.1",
				"- Sand Crab: 20.8",
				"- Beach Beetle: 24.2",
				"- Hill Toad: 28.1"
			),
			new BookPageInfo
			(
				"- Boar: 29.1",
				"- Alytharr Grass Snake:",
				"31.5",
				"- Black Bear: 35.1",
				"- Black Lizard: 36.0",
				"- Alytharr Forest Hart:",
				"39.0",
				"- Wyvern Youngling: 39.9"
			),
			new BookPageInfo
			(
				"- Cougar: 41.1"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public TamersHandbookVol2() : base( 0xFF0, false )
		{
			Weight = 0.1;
                        Hue = 2110;
		}

		public TamersHandbookVol2( Serial serial ) : base( serial )
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