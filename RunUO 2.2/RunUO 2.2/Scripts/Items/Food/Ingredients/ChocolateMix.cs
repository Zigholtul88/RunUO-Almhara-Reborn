using System;
using Server.Network;

namespace Server.Items
{
	public class ChocolateMix : Item
	{
		[Constructable]
		public ChocolateMix() : base( 0xE23 )
		{
			Weight = 0.5;
			Stackable = true;
			Hue = 0x414;
			Name = "Chocolate Mix";
		}

		public ChocolateMix( Serial serial ) : base( serial )
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