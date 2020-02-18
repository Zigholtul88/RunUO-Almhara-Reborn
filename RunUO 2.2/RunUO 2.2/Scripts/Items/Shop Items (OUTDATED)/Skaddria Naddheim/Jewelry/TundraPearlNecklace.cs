using System;
using Server;

namespace Server.Items
{
	public class TundraPearlNecklace : BaseNecklace
	{
		[Constructable]
		public TundraPearlNecklace() : base( 0x1085 )
		{
                        Name = "Tundra Pearl Necklace";
                        Hue = 1151;
			Weight = 0.1;

			Resistances.Cold = 5;
		}

		public TundraPearlNecklace( Serial serial ) : base( serial )
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