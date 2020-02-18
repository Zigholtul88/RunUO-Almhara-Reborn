using System;
using Server;

namespace Server.Items
{
	public class FineOpalPendant : BaseNecklace
	{
		[Constructable]
		public FineOpalPendant() : base( 0x1085 )
		{
                        Name = "Fine Opal Pendant";
			Weight = 0.1;
			Hue = 1187;

			Attributes.BonusHits = 35;
		}

		public FineOpalPendant( Serial serial ) : base( serial )
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