using System;
using Server;

namespace Server.Items
{
	public class GreenBonnet : Bonnet
	{
		[Constructable]
		public GreenBonnet()
		{
                        Name = "Green Bonnet";
                        Hue = 67;

			Attributes.BonusHits = 25;
		}

		public GreenBonnet( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
