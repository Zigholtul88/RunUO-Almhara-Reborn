using System;
using Server.Network;

namespace Server.Items
{
	public class BarbecueSauce : Item
	{
		[Constructable]
		public BarbecueSauce() : base( 0xEFC )
		{
			Stackable = true;
			Hue = 0x278;
			Name = "Barbecue Sauce";
		}

		public BarbecueSauce( Serial serial ) : base( serial )
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