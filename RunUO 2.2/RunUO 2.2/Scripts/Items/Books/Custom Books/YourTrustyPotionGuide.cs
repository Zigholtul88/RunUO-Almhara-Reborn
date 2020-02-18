using System;
using Server;

namespace Server.Items
{
	public class YourTrustyPotionGuide : BaseBook
	{
		public static readonly BookContent Content = new BookContent
		(
			"Your Trusty Potion Guide", "",

			new BookPageInfo
			(
				"By using this guide you",
				"have begun to realize",
				"just how bloody useful",
				"potions are. The",
				"following will help in",
				"identifying all the",
				"various potions you'll",
				"normally find at an"
			),
			new BookPageInfo
			(
				"alchemist",
				"- Blue: Raises Dexterity",
				"by 10 points for 5",
				"minutes.",
				"- Orange: Has a 15% to",
				"75% chance of removing",
				"the poison status up to",
				"greater being the"
			),
			new BookPageInfo
			(
				"highest level.",
				"- Purple: Deals 40 to 50",
				"damage on a successful",
				"hit. If you hold onto it",
				"for too long you're",
				"gonna have a bad time.",
				"- Yellow: Heals 40 to 50",
				"points of damage. Will"
			),
			new BookPageInfo
			(
				"not work on undead.",
				"Believe us, we tried.",
				"- Green: Applies lesser",
				"poison to a weapon. Do",
				"not consume unless",
				"suicide is your only",
				"escape. Man that was",
				"tasteless."
			),
			new BookPageInfo
			(
				"- Red: Restores up to",
				"25% stamina.",
				"- White: Raises Strength",
				"by 10 points for 5",
				"minutes.",
				"- Sky Blue: Restores up",
				"to 25 points of mana. ",
				"- Teal: Raises"
			),
			new BookPageInfo
			(
				"Intelligence by 10",
				"points for 5 minutes.",
				"",
				"Bare in mind that this",
				"list only counts for the",
				"weakest potions. An",
				"alchemist with",
				"considerable skill can"
			),
			new BookPageInfo
			(
				"create potions of a",
				"higher quality. Of",
				"course like you didn't",
				"already know about that."
			)
		);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public YourTrustyPotionGuide() : base( 0xFBD, false )
		{
			Weight = 1.0;
		}

		public YourTrustyPotionGuide( Serial serial ) : base( serial )
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