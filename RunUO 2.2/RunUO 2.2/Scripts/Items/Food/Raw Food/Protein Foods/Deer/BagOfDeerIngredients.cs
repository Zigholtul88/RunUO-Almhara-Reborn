using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfDeerIngredients : Bag
	{
		[Constructable]
		public BagOfDeerIngredients()
		{
			DropItem( new RawGroundVenison ( 100 ) );
			DropItem( new RawVenisonRoast ( 100 ) );
			DropItem( new RawVenisonSlice ( 100 ) );
			DropItem( new RawVenisonSteak ( 100 ) );
		}

		public BagOfDeerIngredients( Serial serial ) : base( serial )
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