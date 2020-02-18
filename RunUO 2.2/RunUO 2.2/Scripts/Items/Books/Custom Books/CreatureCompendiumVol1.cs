using System;
using Server;

namespace Server.Items
{
	public class CreatureCompendiumVol1 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Creature Compendium Vol 1", "Alhania",

			new BookPageInfo
			(
				"Creature Compendium –",
				"Faboilep",
				"",
				"Description: Draped from",
				"head to toe with hair",
				"ranging from various",
				"pinks, blues and other",
				"assortments of colors."
			),
			new BookPageInfo
			(
				"These creatures almost",
				"seems like your typical",
				"nymph variety if it",
				"wasn't for their many",
				"features comparable to",
				"that of lopine specimens",
				"such as similar long",
				"ears, whiskers and hind"
			),
			new BookPageInfo
			(
				"legs. Despite wearing",
				"little to no clothing, a",
				"factor hearkening to",
				"their wild roots. They",
				"do like to adorn",
				"themselves with various",
				"flora and fauna,",
				"sometimes even"
			),
			new BookPageInfo
			(
				"fashioning a miniature",
				"vest from giant",
				"faboidaea petals.",
				"",
				"Unique Powers/Traits:",
				"Faboileps aren't very",
				"capable in combat, so",
				"most of the time they"
			),
			new BookPageInfo
			(
				"tend to flee when the",
				"first signs of danger",
				"rears its ugly head.",
				"Even despite their",
				"chubby aesthetic,",
				"they're able to leap",
				"short distances, most of",
				"the time escaping up"
			),
			new BookPageInfo
			(
				"towards the tallest tree",
				"in the forest. However",
				"there are instances",
				"where escape for her",
				"proves to be difficult,",
				"if outright impossible.",
				"If stressed out to the",
				"point where she ends up"
			),
			new BookPageInfo
			(
				"either cornered or",
				"trapped against her",
				"will, that is when her",
				"primitive instincts",
				"spring to fruition.",
				"",
				"Much akin to rabbits,",
				"when under high amounts"
			),
			new BookPageInfo
			(
				"of stress they tend to",
				"let out a rattling",
				"scream that signals",
				"others of its kind to",
				"her location. Now expand",
				"that exact same scream",
				"to a magnitude so",
				"devastating that it will"
			),
			new BookPageInfo
			(
				"easily rupture eardrums",
				"and cause heads to",
				"explode and you got a",
				"creature full of hidden",
				"potential."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public CreatureCompendiumVol1() : base( 0xFF0, false )
		{
		}

		public CreatureCompendiumVol1( Serial serial ) : base( serial )
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