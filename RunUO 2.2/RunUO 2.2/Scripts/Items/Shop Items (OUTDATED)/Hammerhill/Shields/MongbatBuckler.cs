using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class MongbatBuckler : AmmoniteShield
	{
		public override int BasePhysicalResistance{ get{ return 10; } }

		[Constructable]
		public MongbatBuckler() 
		{
			Name = "Mongbat Buckler";
			Hue = 1036;
		}

		public MongbatBuckler( Serial serial ) : base( serial )
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