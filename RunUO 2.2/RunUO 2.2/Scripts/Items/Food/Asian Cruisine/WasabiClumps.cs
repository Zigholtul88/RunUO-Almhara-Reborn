using System;
using Server.Network;

namespace Server.Items
{
	public class WasabiClumps : Food
	{
		[Constructable]
		public WasabiClumps() : base( 0x24EB )
		{
			Stackable = false;
			Weight = 1.0;
			FillFactor = 2;
		}

		public WasabiClumps( Serial serial ) : base( serial )
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