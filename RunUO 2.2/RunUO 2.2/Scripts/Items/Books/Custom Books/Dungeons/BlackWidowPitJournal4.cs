using System;
using Server;

namespace Server.Items
{
	public class BlackWidowPitJournal4 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Day 29", "Tamrin, Journeyman Digger",

			new BookPageInfo
			(
				"Right, I just remembered",
				"the code in order to get",
				"back back to the",
				"Sorcerors Den. The",
				"password is: nimaku"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BlackWidowPitJournal4() : base( 0xFF3, false )
		{
		}

		public BlackWidowPitJournal4( Serial serial ) : base( serial )
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