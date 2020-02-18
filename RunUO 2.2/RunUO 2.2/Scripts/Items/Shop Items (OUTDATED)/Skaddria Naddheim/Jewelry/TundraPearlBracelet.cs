using System;
using Server;

namespace Server.Items
{
	public class TundraPearlBracelet : BaseBracelet
	{
		[Constructable]
		public TundraPearlBracelet() : base( 0x1086 )
		{
                        Name = "Tundra Pearl Bracelet";
                        Hue = 1151;
			Weight = 0.1;

			Resistances.Cold = 5;
		}

		public TundraPearlBracelet( Serial serial ) : base( serial )
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