using System;
using Server.Network;

namespace Server.Items
{
	public class Tortilla : Item
	{
		[Constructable]
		public Tortilla() : base( 0x973 )
		{
			Weight = 0.5;
			Stackable = true;
			Hue = 0x22C;
			Name = "Tortilla";
		}

		public Tortilla( Serial serial ) : base( serial )
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