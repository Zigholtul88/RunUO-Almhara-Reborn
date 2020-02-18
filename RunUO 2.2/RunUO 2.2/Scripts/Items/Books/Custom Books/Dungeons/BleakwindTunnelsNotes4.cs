using System;
using Server;

namespace Server.Items
{
	public class BleakwindTunnelsNotes4 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Shipping Orders", "Frimost",

			new BookPageInfo
			(
				"Hey boss, whenever you",
				"get this notice. We've",
				"just got word that the",
				"arcanic ritual plans for",
				"the Beelzebug units from",
				"Azurite Caverns are",
				"packed and ready to be",
				"shipped. I decided to"
			),
			new BookPageInfo
			(
				"make a quick stop over",
				"there, but had to turn",
				"back due to cramps in my",
				"legs and unfortunately",
				"forgetting the password",
				"needed to proceed beyond",
				"the barriers.",
				""
			),
			new BookPageInfo
			(
				"Yeah I managed to forget",
				"how to access the",
				"caverns. Which is odd",
				"because originally the",
				"code was easier to",
				"memorize during my",
				"youth. I suppose even",
				"among us fiendish folk,"
			),
			new BookPageInfo
			(
				"old age has a tendency",
				"of numbing the senses",
				"down to almost infantile",
				"levels of inadequacy."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BleakwindTunnelsNotes4() : base( 0xFF3, false )
		{
		}

		public BleakwindTunnelsNotes4( Serial serial ) : base( serial )
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