using System;
using Server;

namespace Server.Items
{
	public class MongbatHideoutNotes3 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Hindsight Hijinks", "Wheezie Willow",

			new BookPageInfo
			(
				"Oh yeah, you should have",
				"heard this bullshit",
				"early. Somehow there's",
				"this obsessed collector",
				"of odd trinkets who has",
				"his sights on the",
				"elder's staff.",
				""
			),
			new BookPageInfo
			(
				"How the fuck did he find",
				"that information?"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public MongbatHideoutNotes3() : base( 0xFF3, false )
		{
		}

		public MongbatHideoutNotes3( Serial serial ) : base( serial )
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