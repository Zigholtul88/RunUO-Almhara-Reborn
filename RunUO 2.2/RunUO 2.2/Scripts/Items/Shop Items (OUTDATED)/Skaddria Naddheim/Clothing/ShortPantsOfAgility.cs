using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class ShortPantsOfAgility : ShortPants
	{
		[Constructable]
		public ShortPantsOfAgility()
		{ 
                        Name = "Short Pants of Agility";
			Attributes.BonusDex = 5;
		}

		public ShortPantsOfAgility( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}

