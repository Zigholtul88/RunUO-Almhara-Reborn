using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public class FarmableCorn : FarmableCrop
	{
		public static int GetCropID()
		{
			return 3197;
		}

		public override Item GetCropObject()
		{
			EarOfCorn earofcorn = new EarOfCorn();

			earofcorn.ItemID = Utility.Random( 3201, 2 );

			return earofcorn;
		}

		public override int GetPickedID()
		{
			return 3198;
		}

		[Constructable]
		public FarmableCorn() : base( GetCropID() )
		{
		}

		public FarmableCorn( Serial serial ) : base( serial )
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