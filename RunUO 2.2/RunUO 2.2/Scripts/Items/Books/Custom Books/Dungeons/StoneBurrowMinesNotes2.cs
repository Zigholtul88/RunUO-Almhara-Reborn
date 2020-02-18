using System;
using Server;

namespace Server.Items
{
	public class StoneBurrowMinesNotes2 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Scissormen", "Arni Drillhorn",

			new BookPageInfo
			(
				"We were able to make",
				"it through the",
				"android assault. Now we",
				"just gotta make it past",
				"the earth elementals,",
				"diraie, and these gangly",
				"looking creatures known",
				"as sicklers. Wanna try"
			),
			new BookPageInfo
			(
				"and guess why they're",
				"called that? Believe me,",
				"you'll find out soon",
				"enough."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public StoneBurrowMinesNotes2() : base( 0xFF3, false )
		{
		}

		public StoneBurrowMinesNotes2( Serial serial ) : base( serial )
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