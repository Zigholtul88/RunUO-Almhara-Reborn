using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class WindStitchedShirt : Shirt
	{
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		[Constructable]
		public WindStitchedShirt()
		{ 
                        Name = "Wind Stitched Shirt";
                        Hue = 991;
		}

		public WindStitchedShirt( Serial serial ) : base( serial )
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

