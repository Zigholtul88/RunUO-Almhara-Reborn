using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public class FarmableDesertEmerald : FarmableCrop
	{
		public static int GetCropID()
		{
			return 8712;
		}

		public override Item GetCropObject()
		{
			DesertEmerald desertemerald = new DesertEmerald();

			desertemerald.ItemID = 3856;

                  desertemerald.Hue = 2611;

			return desertemerald;
		}

		public override int GetPickedID()
		{
			return 8762;
		}

		[Constructable]
		public FarmableDesertEmerald() : base( GetCropID() )
		{
			Hue = 2611;
		}

		public FarmableDesertEmerald( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}