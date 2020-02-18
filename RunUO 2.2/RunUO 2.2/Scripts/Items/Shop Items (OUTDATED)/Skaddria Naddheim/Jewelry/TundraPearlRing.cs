using System;
using Server;

namespace Server.Items
{
	public class TundraPearlRing : BaseRing
	{
		[Constructable]
		public TundraPearlRing() : base( 0x108a )
		{
                        Name = "Tundra Pearl Ring";
                        Hue = 1151;
			Weight = 0.1;

			Resistances.Cold = 5;
		}

		public TundraPearlRing( Serial serial ) : base( serial )
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