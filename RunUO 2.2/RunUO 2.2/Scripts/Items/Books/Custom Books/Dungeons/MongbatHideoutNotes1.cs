using System;
using Server;

namespace Server.Items
{
	public class MongbatHideoutNotes1 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"A Home of Our Own", "Wheezie Willow",

			new BookPageInfo
			(
				"Teeheehee! We've done",
				"it! We found ourselves",
				"this unoccupied cave and",
				"have driven out all of",
				"its original inhabits.",
				"For now we're set up",
				"base among the inner",
				"walls, making sure that"
			),
			new BookPageInfo
			(
				"no surface dwellers ever",
				"stumble upon this place",
				"without suffering severe",
				"consequences. However if",
				"that wasn't enough, our",
				"elder and chief was able",
				"to craft himself a nice",
				"little staff capable of"
			),
			new BookPageInfo
			(
				"summoning more of us to",
				"aid among the campaign",
				"trail. Jeepers,",
				"creepers! I wish I had a",
				"staff with the ability",
				"to materialize my own",
				"personal army at my",
				"moments whim."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public MongbatHideoutNotes1() : base( 0xFF3, false )
		{
		}

		public MongbatHideoutNotes1( Serial serial ) : base( serial )
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