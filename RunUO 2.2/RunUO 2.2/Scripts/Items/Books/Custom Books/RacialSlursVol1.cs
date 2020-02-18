using System;
using Server;

namespace Server.Items
{
	public class RacialSlursVol1 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Racial Slurs Vol 1", "Jiff Jiff",

			new BookPageInfo
			(
				"Ljósálfar Racial Slurs",
				"",
				"Albino Peltonen",
				"+ Directed towards those",
				"with pale skin, golden",
				"hair and a",
				"predisposition for",
				"mouthing lots and lots"
			),
			new BookPageInfo
			(
				"of popsickles.",
				"Chatter Chips",
				"+ Insult towards lighter",
				"skinned individuals with",
				"more extroverted",
				"personalites.",
				"Fruit Tosser",
				"+ Derogatory insult"
			),
			new BookPageInfo
			(
				"towards gay members of",
				"their species taking it",
				"in the apple.",
				"Gai-ko",
				"+ Keljii insult towards",
				"ljosalfar foreigners.",
				"Galleta",
				"+ Female members who"
			),
			new BookPageInfo
			(
				"date svartalfar men are",
				"sometimes referred to",
				"this in a loving manner.",
				"Leaf Biter",
				"+ Stereotypes ljosalfar",
				"as being primary vegan",
				"dietricians.",
				"Orange Festival"
			),
			new BookPageInfo
			(
				"+ Red haired ljosalfar",
				"have a lot of fur down",
				"there.",
				"Paddypus",
				"+ Stereotypes certain",
				"ljosalfar constantly",
				"getting into fist fights",
				"once diplomacy has worn"
			),
			new BookPageInfo
			(
				"out its welcome."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public RacialSlursVol1() : base( 0xFF2, false )
		{
		}

		public RacialSlursVol1( Serial serial ) : base( serial )
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