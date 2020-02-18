using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class ShimmeringHeaterShieldOfAquaticElegance : HeaterShield
	{
		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 10; } }

		[Constructable]
		public ShimmeringHeaterShieldOfAquaticElegance() 
		{
			Name = "Shimmering Heater Shield Of Aquatic Elegance";
			Hue = 1173;
		}

		public ShimmeringHeaterShieldOfAquaticElegance( Serial serial ) : base( serial )
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