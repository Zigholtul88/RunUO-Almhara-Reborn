using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfBeefIngredients : Bag
	{
		[Constructable]
		public BagOfBeefIngredients()
		{
			DropItem( new RawBeefPorterhouse ( 100 ) );
			DropItem( new RawBeefPrimeRib ( 100 ) );
			DropItem( new RawBeefRibeye ( 100 ) );
			DropItem( new RawBeefRibs ( 100 ) );
			DropItem( new RawBeefRoast ( 100 ) );
			DropItem( new RawBeefSirloin ( 100 ) );
			DropItem( new RawBeefSlice ( 100 ) );
			DropItem( new RawBeefTBone ( 100 ) );
			DropItem( new RawBeefTenderloin ( 100 ) );
			DropItem( new RawGroundBeef ( 100 ) );
		}

		public BagOfBeefIngredients( Serial serial ) : base( serial )
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