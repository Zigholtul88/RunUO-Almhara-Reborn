using System;
using Server;

namespace Server.Items
{
	public class BleakwindTunnelsNotes1 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"A Cold Shoulder", "Calvin Maxwell",

			new BookPageInfo
			(
				"Brrrrrrrrrr! Its really,",
				"really cold in Bleakwind",
				"Tunnels. Of course out",
				"here that's a given.",
				"Even the air around some",
				"of these creatures is",
				"enough to give one a",
				"case of severe"
			),
			new BookPageInfo
			(
				"frostbite. Before I take",
				"residence within this",
				"decently sized cavity,",
				"I'm gonna try and see if",
				"I can't try and gather",
				"up a large enough task",
				"force in order to rid",
				"these tunnels of its"
			),
			new BookPageInfo
			(
				"infestation problem.",
				"Goddamn Spiders! Why'd",
				"they have to be so",
				"abnormally huge like",
				"their Oboru cousins. I",
				"can't even get near them",
				"without extra layers of",
				"clothing due to their"
			),
			new BookPageInfo
			(
				"chilly auras. If that",
				"isn't bad enough, this",
				"place was recently taken",
				"hostage by ethereal",
				"frost demons from",
				"Tartarrix and they",
				"managed to chase me out",
				"of their domain past the"
			),
			new BookPageInfo
			(
				"black gates near the",
				"tail end of this",
				"establishment."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BleakwindTunnelsNotes1() : base( 0xFF3, false )
		{
		}

		public BleakwindTunnelsNotes1( Serial serial ) : base( serial )
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