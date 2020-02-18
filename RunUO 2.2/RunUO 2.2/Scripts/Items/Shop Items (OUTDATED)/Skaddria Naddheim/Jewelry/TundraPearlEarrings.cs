using System;
using Server;

namespace Server.Items
{
	public class TundraPearlEarrings : BaseEarrings
	{
		[Constructable]
		public TundraPearlEarrings() : base( 0x1087 )
		{
                        Name = "Tundra Pearl Earrings";
                        Hue = 1151;
			Weight = 0.1;

			Resistances.Cold = 5;
		}

		public TundraPearlEarrings( Serial serial ) : base( serial )
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