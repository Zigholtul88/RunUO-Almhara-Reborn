using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class GraniteKiteShield : MetalKiteShield
	{
		public override int BasePhysicalResistance{ get{ return 8; } }
		public override int BasePoisonResistance{ get{ return 4; } }
		public override int BaseEnergyResistance{ get{ return 6; } }

		[Constructable]
		public GraniteKiteShield() 
		{
			Name = "Granite Kite Shield";
                        Hue = 2410;
		}

		public GraniteKiteShield( Serial serial ) : base( serial )
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