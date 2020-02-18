using System;
using Server.Network;

namespace Server.Items
{
	public class GroundBeef : Item
	{
		[Constructable]
		public GroundBeef() : this( 1 )
		{
		}

		[Constructable]
		public GroundBeef( int amount ) : base( 9908 )
		{
			Weight = 5.0;
			Stackable = true;
                        Amount = amount;
			Hue = 0x21B;
			Name = "Ground Beef";
		}

		public GroundBeef( Serial serial ) : base( serial )
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