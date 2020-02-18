using System;
using Server;

namespace Server.Items
{
	public class ReleaseTheSandKraken : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Release The Sand Kraken", "Tooty Phucking Fruity",

			new BookPageInfo
			(
				"To all my fellow",
				"Almharians who wish to",
				"traverse the Harashi",
				"Nabi desert would",
				"remember to keep their",
				"eyes focused upon the",
				"sands should things",
				"start to get weary. For"
			),
			new BookPageInfo
			(
				"the past two decades",
				"reports began springing",
				"up from all walks of",
				"life pertaining to these",
				"mysterious underground",
				"cephalods and how ever",
				"since the incident over",
				"from the southern reach"
			),
			new BookPageInfo
			(
				"of the desert it has",
				"become apparent that",
				"these creatures have",
				"awakened from their",
				"slumber after millions",
				"of years dormant since",
				"the late Pre-Cromajinek",
				"era where manta rays the"
			),
			new BookPageInfo
			(
				"size of skyscrapers",
				"originally roamed with",
				"little to no predators.",
				"If you spot a sand",
				"kraken pursuing your",
				"scent, keep venturing",
				"westward and you'll",
				"eventually reach Red"
			),
			new BookPageInfo
			(
				"Dagger Keep where",
				"trained guards will",
				"easily dispatch the",
				"troublesome beasts. Do",
				"not. I repeat, DO NOT",
				"ascend beyond the",
				"northern hemisphere.",
				"There lies the home of"
			),
			new BookPageInfo
			(
				"the vile ophidians and",
				"they don't particularly",
				"take kindly to any",
				"outsiders who barge in",
				"uninvited and whatever",
				"you do. Stay away from",
				"the southern reach or",
				"else you'll be"
			),
			new BookPageInfo
			(
				"confronted by felines of",
				"Tartarrix, molochs, and",
				"abandoned clockwork",
				"constructs capable of",
				"resisting all forms of",
				"physical attacks. Plus",
				"that's where the tomb of",
				"Amul Seketsi lies and"
			),
			new BookPageInfo
			(
				"elysstia forbid you ever",
				"step foot into that",
				"death trap."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public ReleaseTheSandKraken() : base( 0xFF0, false )
		{
			Hue = 665;
		}

		public ReleaseTheSandKraken( Serial serial ) : base( serial )
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