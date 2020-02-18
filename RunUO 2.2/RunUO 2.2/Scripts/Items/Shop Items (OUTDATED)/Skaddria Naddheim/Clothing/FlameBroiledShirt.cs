using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class FlameBroiledShirt : Shirt
	{
		public override int BaseFireResistance{ get{ return 20; } }

		[Constructable]
		public FlameBroiledShirt()
		{ 
                        Name = "Flame Broiled Shirt";
                        Hue = 1281;
		}

		public FlameBroiledShirt( Serial serial ) : base( serial )
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

