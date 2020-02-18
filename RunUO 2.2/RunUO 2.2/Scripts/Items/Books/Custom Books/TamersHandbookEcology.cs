using System;
using Server;

namespace Server.Items
{
	public class TamersHandbookEcology : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Tamers Handbook Ecology", "Wilderness",

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
				"Zaythalor Forest",
				"- Bird: 0.0",
				"- Chicken: 0.0",
				"- Grey Squirrel: 0.0",
				"- Mongbat: 0.0 ",
				"- Mountain Goat: 0.0",
				"- Rabbit: 0.0",
				"- Rat: 0.0"
			),
			new BookPageInfo
			(
				"- Green Slime: 1.0",
				"- Black Ant: 5.0",
				"- Forest Bat: 5.5",
				"- Gizzard: 5.5",
				"- Large Frog: 9.1",
				"- Running Pants: 10.0",
				"- Ogumo: 10.5",
				"- Cow: 11.1"
			),
			new BookPageInfo
			(
				"- Pig: 11.1",
				"- Sheep: 11.1",
				"- Young Alligator: 15.0",
				"- Grey Wolf Pup: 15.5",
				"- Eagle: 17.1",
				"- Star Lake Crab: 20.8",
				"- Hind: 23.1",
				"- Timber Wolf: 23.1"
			),
			new BookPageInfo
			(
				"- Giant Iron Beetle:",
				"24.2",
				"- Nephropirok *MOUNT*:",
				"25.5",
				"- Wild Turkey: 27.5",
				"- Lesser Ant Lion: 28.7",
				"- Boar: 29.1",
				"- Horse *MOUNT*: 29.1"
			),
			new BookPageInfo
			(
				"- Great Hart *MOUNT*:",
				"30.0",
				"- Bull: 30.5",
				"- Water Lizard: 34.2",
				"- Black Bear: 35.1",
				"- Cougar: 41.1",
				"",
				"Alytharr Region"
			),
			new BookPageInfo
			(
				"- Sheep: 11.1",
				"- Sand Crab: 20.8",
				"- Beach Beetle: 24.2",
				"- Hill Toad: 28.1",
				"- Boar: 29.1",
				"- Alytharr Grass Snake:",
				"31.5",
				"- Black Bear: 35.1"
			),
			new BookPageInfo
			(
				"- Black Lizard: 36.0",
				"- Alytharr Forest Hart:",
				"39.0",
				"- Wyvern Youngling: 39.9",
				"- Cougar: 41.1",
				"",
				"Autumnwood",
				"- Skittering Hopper:"
			),
			new BookPageInfo
			(
				"-12.9",
				"- Oakwood Snarler Pup:",
				"30.0",
				"- Razorback Raptor: 32.5",
				"",
				"Oboru Jungle",
				"- Yatsukahag: 22.9",
				"- Dai Ogumo: 25.4"
			),
			new BookPageInfo
			(
				"",
				"Harashi Nabi Desert",
				"- Sand Streaker: 8.9",
				"- Desert Ostard: 29.1",
				"- Bullet Ant: 31.2",
				"- Desert Rose: 32.0",
				"- Zebra *MOUNT*: 33.3",
				"- Sand Barracuda: 35.5"
			),
			new BookPageInfo
			(
				"- Giant Turtle *MOUNT*:",
				"36.4",
				"- Feline of Tartarrix:",
				"41.1",
				"- Scorpion: 47.1",
				"- Lion *MOUNT*: 76.6",
				"",
				"Island of Giants"
			),
			new BookPageInfo
			(
				"- Dire Wolf: 45.5",
				"",
				"Glimmerwood",
				"- Parrot: 0.0",
				"- Ridgeback *MOUNT*:",
				"29.1",
				"- Gryphon *MOUNT*: 29.5",
				"- Forest Ostard *MOUNT*:"
			),
			new BookPageInfo
			(
				"29.5",
				"- Savage Ridgeback",
				"*MOUNT*: 35.1",
				"- Ibong Adarna: 60.5",
				"- Ant Lion: 69.9",
				"",
				"Dragon Storm Island",
				"- Drake: 84.3"
			),
			new BookPageInfo
			(
				"- Dragon: 93.9",
				"",
				"Samson Swamplands",
				"- Water Beetle: 37.9",
				"- Grachiosaur: 75.0",
				"- Allosaur: 86.7",
				"- Forest Dragon: 93.9",
				""
			),
			new BookPageInfo
			(
				"Skaddria Naddheim",
				"- Waitoreke: -21.3",
				"- SilverbackGorilla: 0.0",
				"- Cinnamologus: 5.5",
				"- Dobhar-chu: 9.1",
				"- Cha kla: 25.0",
				"- Taniwha: 37.9",
				"- Shachihoko *MOUNT*:"
			),
			new BookPageInfo
			(
				"40.5",
				"- Aspidochelone: 75.0"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public TamersHandbookEcology() : base( 0x1C11, false )
		{
			Weight = 0.1;
                        Hue = 2110;
		}

		public TamersHandbookEcology( Serial serial ) : base( serial )
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