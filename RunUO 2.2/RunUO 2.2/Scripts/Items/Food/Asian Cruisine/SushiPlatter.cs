using System;
using Server.Network;

namespace Server.Items
{
	public class SushiPlatter : Food
	{
		[Constructable]
		public SushiPlatter() : base( 0x2840 )
		{
                        Stackable = Core.AOS;
			Weight = 3.0;
			FillFactor = 2;
		}

		public SushiPlatter( Serial serial ) : base( serial )
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