using System;
using Server;

namespace Server.Items
{
	public class PlayerCommandsBook : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Player Commands", "",

			new BookPageInfo
			(
				"Through these pages are",
				"commands that when",
				"utilized allow for some",
				"nifty features.",
				"",
				"[addtoparty - Makes it",
				"easier to allow any",
				"active player characters"
			),
			new BookPageInfo
			(
				"into your group.",
				"[bandself - If you have",
				"any spare bandages, this",
				"will make applying them",
				"much easier. Also works",
				"with [bs",
				"[bondtime - Shows the",
				"bond time between owned"
			),
			new BookPageInfo
			(
				"pets.",
				"[dump - Moves all items",
				"from one container to",
				"another. Can only be",
				"done with your own",
				"items.",
				"[emote - Shows a list of",
				"all emotes that player"
			),
			new BookPageInfo
			(
				"characters can use for",
				"roleplaying reasons.",
				"[helpme - Shows a help",
				"menu.",
				"[mystats - Shows the",
				"user a list of all",
				"current stats in game."
			),
			new BookPageInfo
			(
				"[hunger - Displays",
				"current hunger levels.",
				"[thrist - Displays",
				"current thirst levels."
			),
			new BookPageInfo
			(
				"[expbar - Displays",
				"current xp gained",
				"along with needed",
				"amount for next level."
			),
			new BookPageInfo
			(
				"[getpet - Allows",
				"players for a small",
				"fee to summon any lost",
				"pets."
			),
			new BookPageInfo
			(
				"[queststotal - ",
				"Displays how many",
				"quests currently have",
				"been finished."
			),
			new BookPageInfo
			(
				"[infravision - ",
				"Grants nightsight to",
				"night elves. Can be",
				"toggled on and off.",
				"Can also be toggled",
				"with [infra"
			),
			new BookPageInfo
			(
				"[fireblood - ",
				"Unique to yugitashi.",
				"Grants permanent hit",
				"fireball to any",
				"targeted weapon."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public PlayerCommandsBook() : base( 0x1C11, false )
		{
			Weight = 0.0;
			LootType = LootType.Blessed;
		}

		public PlayerCommandsBook( Serial serial ) : base( serial )
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