using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class ShortPantsOfProtection : ShortPants
	{
		[Constructable]
		public ShortPantsOfProtection()
		{ 
                        Name = "Short Pants of Protection";
			Attributes.BonusInt = 5;
		}

		public ShortPantsOfProtection( Serial serial ) : base( serial )
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

