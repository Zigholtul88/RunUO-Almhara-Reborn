using System;
using Server;

namespace Server.Items
{
	public class TheyDontCareAboutUsLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"They Dont Care About Us", "Angelo Ratchet",

			new BookPageInfo
			(
				"Skin head, dead head",
				"Everybody gone bad",
				"Situation, aggravation",
				"Everybody allegation",
				"In the suite, on the",
				"news",
				"Everybody dog food",
				"Bang bang, shot dead"
			),
			new BookPageInfo
			(
				"Everybody's gone mad",
				"",
				"All I wanna say is that",
				"They don't really care",
				"about us",
				"All I wanna say is that",
				"They don't really care",
				"about us"
			),
			new BookPageInfo
			(
				"",
				"Beat me, hate me",
				"You can never break me",
				"Will me, thrill me",
				"You can never kill me",
				"Do me, Sue me",
				"Everybody do me",
				"Kick me, blight me"
			),
			new BookPageInfo
			(
				"Don't you black or white",
				"me",
				"",
				"All I wanna say is that",
				"They don't really care",
				"about us",
				"All I wanna say is that",
				"They don't really care"
			),
			new BookPageInfo
			(
				"about us",
				"",
				"Tell me what has become",
				"of my life",
				"I have a wife and two",
				"children who love me",
				"I am the victim of",
				"police brutality, now"
			),
			new BookPageInfo
			(
				"I'm tired of bein' the",
				"victim of hate",
				"You're rapin' me of my",
				"pride",
				"Oh, for God's sake",
				"I look to heaven to",
				"fulfill its prophecy...",
				"Set me free"
			),
			new BookPageInfo
			(
				"",
				"Skin head, dead head",
				"Everybody gone bad",
				"trepidation, speculation",
				"Everybody allegation",
				"In the suite, on the",
				"news",
				"Everybody dog food"
			),
			new BookPageInfo
			(
				"black man, black male",
				"Throw your brother in",
				"jail",
				"",
				"All I wanna say is that",
				"They don't really care",
				"about us",
				"All I wanna say is that"
			),
			new BookPageInfo
			(
				"They don't really care",
				"about us",
				"",
				"Tell me what has become",
				"of my rights",
				"Am I invisible because",
				"you ignore me?",
				"Your proclamation"
			),
			new BookPageInfo
			(
				"promised me free",
				"liberty, now",
				"I'm tired of bein' the",
				"victim of shame",
				"They're throwing me in a",
				"class with a bad name",
				"I can't believe this is",
				"the land from which I"
			),
			new BookPageInfo
			(
				"came",
				"You know I do really",
				"hate to say it",
				"The government don't",
				"wanna see",
				"But if Elohain was",
				"livin'",
				"He wouldn't let this be,"
			),
			new BookPageInfo
			(
				"no, no",
				"",
				"Skin head, dead head",
				"Everybody gone bad",
				"Situation, speculation",
				"Everybody litigation",
				"Beat me, bash me",
				"You can never trash me"
			),
			new BookPageInfo
			(
				"Hit me, kick me",
				"You can never get me",
				"",
				"All I wanna say is that",
				"They don't really care",
				"about us",
				"All I wanna say is that",
				"They don't really care"
			),
			new BookPageInfo
			(
				"about us",
				"",
				"Some things in life they",
				"just don't wanna see",
				"But if Eienyasil was",
				"livin'",
				"She wouldn't let this be",
				""
			),
			new BookPageInfo
			(
				"Skin head, dead head",
				"Everybody gone bad",
				"Situation, segregation",
				"Everybody allegation",
				"In the suite, on the",
				"news",
				"Everybody dog food",
				"Kick me, Break me"
			),
			new BookPageInfo
			(
				"Don't you wrong or right",
				"me",
				"",
				"All I wanna say is that",
				"They don't really care",
				"about us",
				"All I wanna say is that",
				"They don't really care"
			),
			new BookPageInfo
			(
				"about us",
				"",
				"All I wanna say is that",
				"They don't really care",
				"about us",
				"All I wanna say is that",
				"They don't really care",
				"about us"
			),
			new BookPageInfo
			(
				"",
				"All I wanna say is that",
				"They don't really care",
				"about us",
				"All I wanna say is that",
				"They don't really care",
				"about us"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public TheyDontCareAboutUsLyrics() : base( 0xFF4, false )
		{
		}

		public TheyDontCareAboutUsLyrics( Serial serial ) : base( serial )
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