using System;
using Server;

namespace Server.Items
{
	public class BleakwindTunnelsNotes3 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Operation Tundra Terror", "Agalierept",

			new BookPageInfo
			(
				"Before we can fully",
				"entrust our faith into",
				"operation Tundra Terror",
				"with these Beelzebug",
				"units, we will need the",
				"required arcanic ritual",
				"plans from Azurite",
				"Caverns. Otherwise"
			),
			new BookPageInfo
			(
				"they'll be about as",
				"useless as those stupid",
				"blue chickens.",
				"",
				"Actually I can't say",
				"that about the",
				"Beelzebug. They aren't",
				"nearly as fast as those"
			),
			new BookPageInfo
			(
				"feathered fudgers, but",
				"even as is they still",
				"pack quite a vicious",
				"punch and they're fully",
				"armed to the teeth.",
				"However once we get",
				"those plans, these units",
				"will become more durable"
			),
			new BookPageInfo
			(
				"than they've ever been",
				"in quite some time.",
				"Worthy enough to lead",
				"the assault upon Coven's",
				"Landing so that we can",
				"get back at the man",
				"whose been troubling us",
				"for far too long. And"
			),
			new BookPageInfo
			(
				"quite personally, Mr.",
				"Conductor. I'm offended",
				"by that bastard for not",
				"keep his word in the",
				"bargain when it came to",
				"dealing with such sought",
				"after shimmering",
				"seraphitite. Extremely"
			),
			new BookPageInfo
			(
				"rare minerals when",
				"crafted into weapons are",
				"capable of felling most",
				"warriors with just a",
				"single swipe.",
				"",
				"I swear the next time I",
				"encounter him, the"
			),
			new BookPageInfo
			(
				"meeting will be his",
				"final day among the",
				"Almharian land dwellers.",
				"Soon my disloyal patron.",
				"You will be terminated",
				"with extreme prejudice."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BleakwindTunnelsNotes3() : base( 0xFF3, false )
		{
		}

		public BleakwindTunnelsNotes3( Serial serial ) : base( serial )
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