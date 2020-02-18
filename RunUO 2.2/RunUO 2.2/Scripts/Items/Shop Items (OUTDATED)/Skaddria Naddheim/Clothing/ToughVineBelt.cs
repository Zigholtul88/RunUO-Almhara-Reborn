using System;
using Server;

namespace Server.Items
{
	public class ToughVineBelt : WoodlandBelt
	{
		[Constructable]
		public ToughVineBelt()
		{
                        Name = "Tough Vine Belt";
                        Hue = 66;

			Attributes.BonusStr = 2;
		}

		public ToughVineBelt( Serial serial ) : base( serial )
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
