using System;
using Server;

namespace Server.Items
{
	public class BleakwindTunnelsNotes2 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Ice Ice Baby", "Calvin Maxwell",

			new BookPageInfo
			(
				"I approached these",
				"wicked winged females",
				"with pale features,",
				"praying if my stealth",
				"capabilities were up to",
				"snuff. Upon listening to",
				"their little",
				"conversation, they've"
			),
			new BookPageInfo
			(
				"had their eye on Coven's",
				"Landing for quite some",
				"time. Originally they",
				"were driven off from the",
				"settlement after the",
				"locals were able to get",
				"a hold of some much",
				"needed fire weapons."
			),
			new BookPageInfo
			(
				"Yeah pyro-synthetic arms",
				"will definitely do",
				"numbers against any",
				"fiends of the arctic",
				"wastelands. But there's",
				"more to it. According to",
				"rumors, they've been on",
				"the pursuit for someone"
			),
			new BookPageInfo
			(
				"who originally screwed",
				"them over on a trade",
				"arrangement and",
				"supposedly they've",
				"lodged up within the",
				"town perimeters.",
				"",
				"They're breeding an army"
			),
			new BookPageInfo
			(
				"as massive as the eyes",
				"can perceive. And once",
				"they've gotten their",
				"Beelzebug units fully",
				"operational, they'll",
				"soon begin their march",
				"upon the settlement",
				"before unleashing what"
			),
			new BookPageInfo
			(
				"they call the Tundra",
				"Terror onto the",
				"residents. Ensuring that",
				"their deaths won't be",
				"easily discarded as",
				"they'll make for",
				"excellent ice sculptures."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BleakwindTunnelsNotes2() : base( 0xFF3, false )
		{
		}

		public BleakwindTunnelsNotes2( Serial serial ) : base( serial )
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