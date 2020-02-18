using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class ShortPantsOfStrength : ShortPants
	{
		[Constructable]
		public ShortPantsOfStrength()
		{ 
                        Name = "Short Pants of Strength";
			Attributes.BonusStr = 5;
		}

		public ShortPantsOfStrength( Serial serial ) : base( serial )
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

