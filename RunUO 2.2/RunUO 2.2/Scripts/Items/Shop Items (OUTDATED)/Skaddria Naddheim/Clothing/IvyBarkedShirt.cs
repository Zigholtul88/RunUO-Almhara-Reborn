using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class IvyBarkedShirt : Shirt
	{
		public override int BasePoisonResistance{ get{ return 20; } }

		[Constructable]
		public IvyBarkedShirt()
		{ 
                        Name = "Ivy Barked Shirt";
                        Hue = 1371;
		}

		public IvyBarkedShirt( Serial serial ) : base( serial )
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

