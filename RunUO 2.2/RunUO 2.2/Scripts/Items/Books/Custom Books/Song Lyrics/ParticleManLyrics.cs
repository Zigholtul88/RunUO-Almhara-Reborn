using System;
using Server;

namespace Server.Items
{
	public class ParticleManLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Particle Man", "They Might Be Titans",

			new BookPageInfo
			(
				"Particle man, particle",
				"man",
				"Doing the things a",
				"particle can",
				"What's he like? It's not",
				"important",
				"Particle man",
				""
			),
			new BookPageInfo
			(
				"Is he a dot, or is he a",
				"speck?",
				"When he's underwater",
				"does he get wet?",
				"Or does the water get",
				"him instead?",
				"Nobody knows, Particle",
				"man"
			),
			new BookPageInfo
			(
				"",
				"Triangle man, Triangle",
				"man",
				"Triangle man hates",
				"particle man",
				"They have a fight,",
				"Triangle wins",
				"Triangle man"
			),
			new BookPageInfo
			(
				"",
				"Universe man, Universe",
				"man",
				"Size of the entire",
				"universe man",
				"Usually kind to smaller",
				"man",
				"Universe man"
			),
			new BookPageInfo
			(
				"",
				"He's got a watch with a",
				"minute hand,",
				"Millennium hand and an",
				"eon hand",
				"When they meet it's a",
				"happy land",
				"Powerful man, universe"
			),
			new BookPageInfo
			(
				"man",
				"",
				"Person man, person man",
				"Hit on the head with a",
				"frying pan",
				"Lives his life in a",
				"garbage can",
				"Person man"
			),
			new BookPageInfo
			(
				"",
				"Is he depressed or is he",
				"a mess?",
				"Does he feel totally",
				"worthless?",
				"Who came up with person",
				"man?",
				"Degraded man, person man"
			),
			new BookPageInfo
			(
				"",
				"Triangle man, triangle",
				"man",
				"Triangle man hates",
				"person man",
				"They have a fight,",
				"triangle wins",
				"Triangle man"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public ParticleManLyrics() : base( 0xFF4, false )
		{
		}

		public ParticleManLyrics( Serial serial ) : base( serial )
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