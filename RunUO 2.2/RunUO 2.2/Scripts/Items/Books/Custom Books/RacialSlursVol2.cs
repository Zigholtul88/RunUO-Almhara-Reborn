using System;
using Server;

namespace Server.Items
{
	public class RacialSlursVol2 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Racial Slurs Vol 2", "Jiff Jiff",

			new BookPageInfo
			(
				"Svartálfar Racial Slurs",
				"",
				"Ace of Spades",
				"+ Self-explanatory,",
				"though sometimes used as",
				"a sexual quip from",
				"ljosalfar partners.",
				"Bai Tou"
			),
			new BookPageInfo
			(
				"+ Keljii insult towards",
				"svartalfar immigrants",
				"normally known for their",
				"white hair.",
				"Boot Polished Tree Bat",
				"+ A derogatory",
				"expression towards",
				"svartalfar in regards to"
			),
			new BookPageInfo
			(
				"their obsidian hued",
				"complexion. ",
				"Cricket",
				"+ Derogatory insult",
				"labeled at svartalfar",
				"musicians.",
				"Fahim",
				"+ Yugitashi use this"
			),
			new BookPageInfo
			(
				"term to describe loud",
				"and rude svartalfar.",
				"Hakui",
				"+ Keljii insult",
				"describing svartalfar",
				"who've been left in the",
				"oven for too long.",
				"Inky"
			),
			new BookPageInfo
			(
				"+ Self-explanatory",
				"Lunar Eclipse",
				"+ Normally tend to be",
				"the night owls that they",
				"are. Biologically sound",
				"considering svartalfar",
				"have trouble with their",
				"eyes adjusting to"
			),
			new BookPageInfo
			(
				"sunlight.",
				"Marshmellow Merry",
				"+ Used as an insult for",
				"svartaltar women who try",
				"to fit in among their",
				"lighter skinned",
				"counterparts.",
				"Midnight Shift"
			),
			new BookPageInfo
			(
				"+ Quip towards members",
				"whom tend to be sexually",
				"active during that",
				"particular time.",
				"Phantasmaphilia",
				"+ Svartalfar who engage",
				"in constant sex with",
				"ljosalfars."
			),
			new BookPageInfo
			(
				"Porch Widow",
				"+ Historical context in",
				"that svartalfar were",
				"stereotyped as being",
				"invasive much like black",
				"widows after a few too",
				"many drinks.",
				"Raven"
			),
			new BookPageInfo
			(
				"+ Lambasted towards",
				"members who never learn",
				"to shut their traps once",
				"in a while.",
				"Shoe Polished",
				"+ Self-explanatory",
				"Silk Strand",
				"+ A derogatory"
			),
			new BookPageInfo
			(
				"expression towards",
				"svartalfar in regards to",
				"their white colored hair."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public RacialSlursVol2() : base( 0xFF2, false )
		{
		}

		public RacialSlursVol2( Serial serial ) : base( serial )
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