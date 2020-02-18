using System;
using Server;

namespace Server.Items
{
	public class ThroughFireAndFlamesLyrics : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Through Fire and Flames", "Dragonriders",

			new BookPageInfo
			(
				"On a cold winter",
				"morning, in the time",
				"before the light",
				"In flames of death's",
				"eternal reign we ride",
				"towards the fight",
				"When the darkness has",
				"fallen down, and the"
			),
			new BookPageInfo
			(
				"times are tough all",
				"right",
				"The sound of evil",
				"laughter falls around",
				"the world tonight",
				"",
				"Fighting hard, fighting",
				"on for the steel,"
			),
			new BookPageInfo
			(
				"through the wastelands",
				"evermore",
				"The scattered souls will",
				"feel the hell bodies",
				"wasted on the shores",
				"On the blackest plains",
				"in hell's domain, we",
				"watch them as we go"
			),
			new BookPageInfo
			(
				"In fire and pain, and",
				"once again we know",
				"",
				"So now we fly ever free",
				"We're free before the",
				"thunderstorm",
				"On towards the",
				"wilderness our quest"
			),
			new BookPageInfo
			(
				"carries on",
				"Far beyond the sundown,",
				"far beyond the moonlight",
				"Deep inside our hearts",
				"and all our souls",
				"",
				"So far away we wait for",
				"the day"
			),
			new BookPageInfo
			(
				"For the light source so",
				"wasted and gone",
				"We feel the pain of a",
				"lifetime lost in a",
				"thousand days",
				"Through the fire and the",
				"flames we carry on",
				""
			),
			new BookPageInfo
			(
				"As the red day is",
				"dawning",
				"And the lightning cracks",
				"the sky",
				"They'll raise their",
				"hands to the heavens",
				"above",
				"With resentment in their"
			),
			new BookPageInfo
			(
				"eyes",
				"Running back from the",
				"mid-morning light",
				"There's a burning in my",
				"heart",
				"We're banished from a",
				"time in a fallen land",
				"To a life beyond the"
			),
			new BookPageInfo
			(
				"stars",
				"",
				"In your darkest dreams",
				"see to believe",
				"Our destiny is time",
				"And endlessly we'll all",
				"be free tonight",
				""
			),
			new BookPageInfo
			(
				"And on the wings of a",
				"dream, so far beyond",
				"reality",
				"All alone in",
				"desperation, now the",
				"time has gone",
				"Lost inside you'll never",
				"find, lost within my own"
			),
			new BookPageInfo
			(
				"mind",
				"Day after day this",
				"misery must go on",
				"",
				"So far away we wait for",
				"the day",
				"For the light source so",
				"wasted and gone"
			),
			new BookPageInfo
			(
				"We feel the pain of a",
				"lifetime lost in a",
				"thousand days",
				"Through the fire and the",
				"flames we carry on",
				"",
				"Now here we stand with",
				"their blood on our hands"
			),
			new BookPageInfo
			(
				"We fought so hard now",
				"can we understand",
				"I'll break the seal of",
				"this curse if I possibly",
				"can",
				"For freedom of every man",
				"",
				"So far away we wait for"
			),
			new BookPageInfo
			(
				"the day",
				"For the light source so",
				"wasted and gone",
				"We feel the pain of a",
				"lifetime lost in a",
				"thousand days",
				"Through the fire and the",
				"flames we carry on"
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public ThroughFireAndFlamesLyrics() : base( 0xFF4, false )
		{
		}

		public ThroughFireAndFlamesLyrics( Serial serial ) : base( serial )
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