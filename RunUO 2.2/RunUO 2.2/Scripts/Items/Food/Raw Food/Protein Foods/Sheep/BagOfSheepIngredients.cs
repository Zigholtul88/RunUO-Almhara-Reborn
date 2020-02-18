using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfSheepIngredients : Bag
	{
		[Constructable]
		public BagOfSheepIngredients()
		{
			DropItem( new RawLambLeg ( 100 ) );
			DropItem( new RawMuttonRoast ( 100 ) );
			DropItem( new RawMuttonSteak ( 100 ) );
		}

		public BagOfSheepIngredients( Serial serial ) : base( serial )
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