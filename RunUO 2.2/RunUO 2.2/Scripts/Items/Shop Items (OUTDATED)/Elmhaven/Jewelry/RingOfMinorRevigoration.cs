using System;
using Server;

namespace Server.Items
{
	public class RingOfMinorRevigoration : BaseRing
	{
		[Constructable]
		public RingOfMinorRevigoration() : base( 0x108a )
		{
                        Name = "Ring Of Minor Revigoration";
			Weight = 0.1;
                        Hue = 2597;

			Attributes.RegenHits = 1;
			Attributes.RegenStam = 1;
			Attributes.RegenMana = 1;
		}

		public RingOfMinorRevigoration( Serial serial ) : base( serial )
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