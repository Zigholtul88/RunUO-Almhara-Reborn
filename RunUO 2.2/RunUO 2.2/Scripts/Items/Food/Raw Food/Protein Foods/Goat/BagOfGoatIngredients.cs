using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfGoatIngredients : Bag
	{
		[Constructable]
		public BagOfGoatIngredients()
		{
			DropItem( new RawGoatRoast ( 100 ) );
			DropItem( new RawGoatSteak ( 100 ) );
		}

		public BagOfGoatIngredients( Serial serial ) : base( serial )
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