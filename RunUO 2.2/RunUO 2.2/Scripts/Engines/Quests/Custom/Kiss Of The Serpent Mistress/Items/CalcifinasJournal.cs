using System;
using Server;

namespace Server.Items
{
	public class CalcifinasJournal : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Calcifina's Journal", "",

			new BookPageInfo
			(
				"I can never forgive",
				"myself for letting you",
				"down nor should you ever",
				"feel sympathetic towards",
				"what I've done. What I",
				"said concerning the",
				"orc forces needing a",
				"new leader turned out to"
			),
			new BookPageInfo
			(
				"be a complete lie. That",
				"wasn't me who really",
				"said those words to you",
				"but instead some",
				"creature who took on my",
				"disguise in order to",
				"trick you. Turns out the",
				"real Calcifina was a"
			),
			new BookPageInfo
			(
				"doppelganger who was",
				"well known throughout",
				"Caravan Cove for",
				"being able to easily",
				"fool others for her",
				"nefarious schemes. Not",
				"only was she a master",
				"trickster but she was"
			),
			new BookPageInfo
			(
				"able to perfectly mimic",
				"both appearance and",
				"voice of those whom she",
				"had a grudge towards.",
				"Everyday with her around",
				"usually meant that",
				"torment and betrayal",
				"were not far away. After"
			),
			new BookPageInfo
			(
				"she was kicked out from",
				"town she though up of a",
				"way to get back at them.",
				"She then managed to",
				"convince hoards of",
				"orcs and eventually",
				"took the place by brute",
				"force. Some people were"
			),
			new BookPageInfo
			(
				"able to escape but those",
				"unfortunate to stay",
				"behind were killed off",
				"within mere moments. If",
				"you're wondering what",
				"ever became of me then",
				"sad to say I'm no longer",
				"part of this world. I"
			),
			new BookPageInfo
			(
				"was met with a swift",
				"execution and my body",
				"disposed of, but for",
				"some reason my spirit",
				"still lingers on. If",
				"only I could get this",
				"journal to you some way",
				"or another. Perhaps one"
			),
			new BookPageInfo
			(
				"day we can spend the",
				"afterlife embracing each",
				"other with open arms.",
				"Your eternal love,",
				"Gloria Razorwind."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public CalcifinasJournal() : base( 0xFF3, false )
		{
			LootType = LootType.Blessed;
		}

		public CalcifinasJournal( Serial serial ) : base( serial )
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