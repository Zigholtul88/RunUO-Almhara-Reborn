using System;
using Server.Network;

namespace Server.Items
{
	public class GroundPork : Item
	{
		[Constructable]
		public GroundPork() : this( 1 )
		{
		}

		[Constructable]
		public GroundPork( int amount ) : base( 9908 )
		{
			Weight = 0.5;
			Stackable = true;
                        Amount = amount;
			Hue = 0x221;
			Name = "Ground Pork";
		}

		public GroundPork( Serial serial ) : base( serial )
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