using System;
using Server;

namespace Server.Items
{
	public class BlackWidowPitJournal2 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Day 27", "Tamrin, Journeyman Digger",

			new BookPageInfo
			(
				"Damn it, we've lost",
				"another man to those",
				"accursed widows. We just",
				"cannot take a break.",
				"There's just too many",
				"that live beneath the",
				"underbelly of these",
				"harsh jungles. However"
			),
			new BookPageInfo
			(
				"we seemed to have lucked",
				"out apparently after",
				"stumbling upon a",
				"passageway even further",
				"into the depths of god",
				"knows where. By the",
				"heavens above, is there",
				"no escape from these"
			),
			new BookPageInfo
			(
				"spiders? I don't wanna",
				"know whatever else is",
				"lurking down those steps."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BlackWidowPitJournal2() : base( 0xFF3, false )
		{
		}

		public BlackWidowPitJournal2( Serial serial ) : base( serial )
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