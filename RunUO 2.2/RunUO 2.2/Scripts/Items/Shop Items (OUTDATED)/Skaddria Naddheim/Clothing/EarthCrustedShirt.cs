using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class EarthCrustedShirt : Shirt
	{
		public override int BasePhysicalResistance{ get{ return 20; } }

		[Constructable]
		public EarthCrustedShirt()
		{ 
                        Name = "Earth Crusted Shirt";
                        Hue = 1181;
		}

		public EarthCrustedShirt( Serial serial ) : base( serial )
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

