using System;
using Server.Network;

namespace Server.Items
{
	public class BagOfCoffee : Item
	{
		[Constructable]
                public BagOfCoffee() : base( 0x1045 )
		{
			Name = "bag of coffee";
			Stackable = true;
			Weight = 5.0;
			Hue = 0x46A;
		}

		public BagOfCoffee( Serial serial ) : base( serial )
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