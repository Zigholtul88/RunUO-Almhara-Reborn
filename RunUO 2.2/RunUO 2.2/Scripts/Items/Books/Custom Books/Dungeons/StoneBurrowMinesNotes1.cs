using System;
using Server;

namespace Server.Items
{
	public class StoneBurrowMinesNotes1 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Mining Excavation", "Arni Drillhorn",

			new BookPageInfo
			(
				"If you're reading this",
				"notice, be assure that",
				"we're continuing our",
				"excavation through Stone",
				"Burrow Mines. The folks",
				"over in Elmhaven are",
				"running short on",
				"precious ore and most of"
			),
			new BookPageInfo
			(
				"the miners there have",
				"seemed to gone mad due",
				"to them being under mind",
				"control from an eldritch",
				"mindflayer named Sthuo",
				"whose taken residence",
				"here in the mines. We've",
				"sent down a few of our"
			),
			new BookPageInfo
			(
				"soldiers but they",
				"haven't returned.",
				"Doesn't help that this",
				"place was already",
				"claimed by Sthuo and his",
				"orc expedition. Those",
				"orcs aren't as stupid as",
				"some of their cousins."
			),
			new BookPageInfo
			(
				"These guys are master",
				"tinkerers and scattered",
				"throughout the mines are",
				"patrol robots that put",
				"up quite a nasty fight",
				"despite being made out",
				"of various rusted gears,",
				"power crystals, and"
			),
			new BookPageInfo
			(
				"their own individual",
				"construction kits.",
				"Perhaps our journey",
				"through the mines won't",
				"seem so frivolous if I",
				"decide to send a search",
				"party, along with myself",
				"so that we can see what"
			),
			new BookPageInfo
			(
				"in Tartarrix is taking",
				"our men and women so",
				"long to get back to us."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public StoneBurrowMinesNotes1() : base( 0xFF3, false )
		{
		}

		public StoneBurrowMinesNotes1( Serial serial ) : base( serial )
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