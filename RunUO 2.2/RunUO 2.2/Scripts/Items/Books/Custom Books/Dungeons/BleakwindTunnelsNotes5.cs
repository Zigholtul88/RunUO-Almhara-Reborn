using System;
using Server;

namespace Server.Items
{
	public class BleakwindTunnelsNotes5 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Message to Frimost", "Mersilde the Ice Maiden",

			new BookPageInfo
			(
				"Yo Frimost. After",
				"talking with the general",
				"I was able to retrieve",
				"the code needed to get",
				"into Azurite Caverns and",
				"yes you were right in",
				"regards to it being",
				"easier to remember when"
			),
			new BookPageInfo
			(
				"we were much younger and",
				"didn't have any",
				"responsibilities towards",
				"keeping our troops in",
				"top fighting spirits. I",
				"was never a big fan for",
				"conquest. But the humans",
				"in Coven's Landing have"
			),
			new BookPageInfo
			(
				"started to drive me up",
				"my skirt to where I've",
				"forsaken my old",
				"principles and decided",
				"to aid in the war",
				"effort. We cannot allow",
				"those minerals to stay",
				"in the hands of mortal"
			),
			new BookPageInfo
			(
				"men. They're simply too",
				"greedy, dangerous and",
				"violent for their own",
				"good use.",
				"",
				"Any way I apologize for",
				"allowing this",
				"conversation to drag on"
			),
			new BookPageInfo
			(
				"for too long. The code",
				"for the caverns is:",
				"shimmering seraphite"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BleakwindTunnelsNotes5() : base( 0xFF3, false )
		{
		}

		public BleakwindTunnelsNotes5( Serial serial ) : base( serial )
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