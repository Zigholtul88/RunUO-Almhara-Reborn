using System;
using Server;

namespace Server.Items
{
	public class BlackWidowPitJournal1 : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Day 24", "Tamrin, Journeyman Digger",

			new BookPageInfo
			(
				"Excavating this hivemind",
				"of insanity has proven",
				"to be far more difficult",
				"than we've originally",
				"been lead to believe.",
				"The spiders that inhabit",
				"the Oboru are a lot more",
				"fierce and the variants"
			),
			new BookPageInfo
			(
				"just below the jungle",
				"are a far cry from the",
				"common house widow that",
				"may not be crawling",
				"inside your boot straps.",
				"Normally they're a",
				"solitary species.",
				"However these larger"
			),
			new BookPageInfo
			(
				"kind seem to have grown",
				"in number, have become",
				"more organized through",
				"the use of forming into",
				"various groups. And of",
				"course their venomous",
				"under bite. The less",
				"said for any victims who"
			),
			new BookPageInfo
			(
				"fall prey to them, the",
				"better for my conscious",
				"to never not have to",
				"look upon their",
				"acidified corpses."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public BlackWidowPitJournal1() : base( 0xFF3, false )
		{
		}

		public BlackWidowPitJournal1( Serial serial ) : base( serial )
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