using System;
using Server;

namespace Server.Items
{
	public class BlowMeAwayLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Blow Me Away", "Breaking Bottlecaps",

			new BookPageInfo
			(
				"They fall in line",
				"One at a time",
				"Ready to play",
				"(I can't see them",
				"anyway)",
				"",
				"No time to lose",
				"We've got to move"
			),
			new BookPageInfo
			(
				"Steady the helm",
				"(I am losing sight",
				"again)",
				"",
				"Fire your guns",
				"It's time to roll",
				"Blow me away",
				"(I will stay, unless I"
			),
			new BookPageInfo
			(
				"may)",
				"After the fall",
				"We'll shake it off",
				"Show me the way",
				"",
				"Only the strongest will",
				"survive",
				"Lead me to heaven when"
			),
			new BookPageInfo
			(
				"we die",
				"I am the shadow on the",
				"wall",
				"I'll be the one to save",
				"us all",
				"",
				"There's nothing left",
				"So save your breath"
			),
			new BookPageInfo
			(
				"Lying awake",
				"(Caught inside this",
				"tidal wave)",
				"",
				"Your cover's blown",
				"No where to go",
				"Only your fate",
				"(Loaded I will walk"
			),
			new BookPageInfo
			(
				"alone)",
				"",
				"Fire your guns",
				"It's time to roll",
				"Blow me away",
				"(I will stay, unless I",
				"may)",
				"After the fall"
			),
			new BookPageInfo
			(
				"We'll shake it off",
				"Show me the way",
				"",
				"Only the strongest will",
				"survive",
				"Lead me to heaven when",
				"we die",
				"I am the shadow on the"
			),
			new BookPageInfo
			(
				"wall",
				"I'll be the one to save",
				"us all",
				"",
				"Wanted it back",
				"(Don't fight me now)",
				"",
				"Only the strongest will"
			),
			new BookPageInfo
			(
				"survive",
				"Lead me to heaven when",
				"we die",
				"I am the shadow on the",
				"wall",
				"I'll be the one to save",
				"us all"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BlowMeAwayLyrics() : base( 0xFF4, false )
		{
		}

		public BlowMeAwayLyrics( Serial serial ) : base( serial )
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