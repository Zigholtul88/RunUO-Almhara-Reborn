using System;
using Server;

namespace Server.Items
{
	public class MongbatHideoutNotes2 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Wasp Stings by the Number", "Wheezie Willow",

			new BookPageInfo
			(
				"Blasted that old rugged",
				"bastard! He dun gone and",
				"hire a few plant keepers",
				"to tend to the ferns",
				"around the caves which",
				"was originally my job.",
				"That was my only good",
				"use around these parts"
			),
			new BookPageInfo
			(
				"and now I'm broke for",
				"highwater. Doesn't help",
				"that if you manage to",
				"tick them off they tend",
				"to swarm you with",
				"vicious wasps and just",
				"like the elder, even",
				"they have their own"
			),
			new BookPageInfo
			(
				"personal army. I should",
				"have carried a torch."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public MongbatHideoutNotes2() : base( 0xFF3, false )
		{
		}

		public MongbatHideoutNotes2( Serial serial ) : base( serial )
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