using System;
using Server;

namespace Server.Items
{
	public class DownWithTheSicknessLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Down With The Sickness", "Mick Cleese",

			new BookPageInfo
			(
				"Do you feel that? Oh,",
				"shit.",
				"",
				"Wah-ah-ah-ah",
				"Wah-ah-ah-ah",
				"",
				"Get up, come on get down",
				"with the sickness"
			),
			new BookPageInfo
			(
				"Get up, come on get down",
				"with the sickness",
				"Get up, come on get down",
				"with the sickness",
				"Open up your hate and",
				"let it flow into me",
				"",
				"Get up, come on get down"
			),
			new BookPageInfo
			(
				"with the sickness",
				"You mother, get up, come",
				"on get down with the",
				"sickness",
				"You fucker, get up, come",
				"on get down with the",
				"sickness",
				"Madness is the gift that"
			),
			new BookPageInfo
			(
				"has been given to me",
				"",
				"I can see inside you the",
				"sickness is rising",
				"It seems that all that",
				"was good has died",
				"Oh no, the world is a",
				"scary place"
			),
			new BookPageInfo
			(
				"Now that you've woken up",
				"the demon in me, in me",
				"",
				"Wah-ah-ah...",
				"Get up, come on get down",
				"with the sickness",
				"You mother, get up, come",
				"on get down with the"
			),
			new BookPageInfo
			(
				"sickness",
				"You fucker, get up, come",
				"on get down with the",
				"sickness",
				"Open up your hate and",
				"let it flow into me",
				"",
				"Why can't you just buck"
			),
			new BookPageInfo
			(
				"up and die?",
				"Get down with the",
				"sickness",
				"Fuck you, I don't need",
				"this shit",
				"Get down with the",
				"sickness",
				"You stupid, sadistic,"
			),
			new BookPageInfo
			(
				"abusive fucking whore",
				"Get down with the",
				"sickness",
				"Here it comes",
				"Get ready to die",
				"",
				"Get ready to...die"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public DownWithTheSicknessLyrics() : base( 0xFF4, false )
		{
		}

		public DownWithTheSicknessLyrics( Serial serial ) : base( serial )
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