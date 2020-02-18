using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfPorkIngredients : Bag
	{
		[Constructable]
		public BagOfPorkIngredients()
		{
			DropItem( new PorkHock ( 100 ) );
			DropItem( new RawBacon ( 100 ) );
			DropItem( new RawBaconSlab ( 100 ) );
			DropItem( new RawGroundPork ( 100 ) );
			DropItem( new RawHam ( 100 ) );
			DropItem( new RawHamSlices ( 100 ) );
			DropItem( new RawPigHead ( 100 ) );
			DropItem( new RawPorkChop ( 100 ) );
			DropItem( new RawPorkRoast ( 100 ) );
			DropItem( new RawPorkSlice ( 100 ) );
			DropItem( new RawSpareRibs ( 100 ) );
			DropItem( new RawTrotters ( 100 ) );
		}

		public BagOfPorkIngredients( Serial serial ) : base( serial )
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