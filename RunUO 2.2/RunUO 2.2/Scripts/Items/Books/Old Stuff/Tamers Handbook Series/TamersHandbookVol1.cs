using System;
using Server;

namespace Server.Items
{
	public class TamersHandbookVol1 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Tamers Handbook Vol 1", "Zaythalor Region",

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
				"- Chicken: 0.0",
				"- Grey Squirrel: 0.0",
				"- Mongbat: 0.0 ",
				"- Mountain Goat: 0.0",
				"- Rabbit: 0.0"
			),
			new BookPageInfo
			(
				"- Rat: 0.0",
				"- Green Slime: 1.0",
				"- Black Ant: 5.0",
				"- Forest Bat: 5.5",
				"- Gizzard: 5.5",
				"- Faerie Beetle",
				"Collector: 8.8",
				"- Large Frog: 9.1"
			),
			new BookPageInfo
			(
				"- Young Spiderling: 10.5",
				"- Cow: 11.1",
				"- Pig: 11.1",
				"- Sheep: 11.1",
				"- Young Alligator: 15.0",
				"- Grey Wolf Pup: 15.5",
				"- Eagle: 17.1",
				"- Star Lake Crab: 20.8"
			),
			new BookPageInfo
			(
				"- Hind: 23.1",
				"- Timber Wolf: 23.1",
				"- Rhino Beetle: 24.2",
				"- Lesser Ant Lion: 28.7",
				"- Boar: 29.1",
				"- Horse: 29.1",
				"- Great Hart: 30.0"
			),
			new BookPageInfo
			(
				"- Bull: 30.5",
				"- Water Lizard: 34.2",
				"- Black Bear: 35.1",
				"- Faerie Beetle: 37.6",
				"- Cougar: 41.1"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public TamersHandbookVol1() : base( 0xFF0, false )
		{
			Weight = 0.1;
                        Hue = 2110;
		}

		public TamersHandbookVol1( Serial serial ) : base( serial )
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