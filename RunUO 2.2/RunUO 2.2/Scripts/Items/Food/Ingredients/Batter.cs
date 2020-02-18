using System;
using Server.Network;

namespace Server.Items
{
	public class Batter : Item
	{
		[Constructable]
		public Batter() : base( 0xE23 )
		{
			Weight = 0.5;
			Stackable = true;
			Hue = 0x227;
			Name = "Batter";
		}

		public Batter( Serial serial ) : base( serial )
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