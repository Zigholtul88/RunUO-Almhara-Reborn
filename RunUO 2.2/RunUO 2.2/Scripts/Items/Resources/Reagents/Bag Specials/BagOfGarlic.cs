using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfGarlic : Bag
	{
		[Constructable]
		public BagOfGarlic() : this( 25 )
		{
		}

		[Constructable]
		public BagOfGarlic( int amount )
		{
			DropItem( new Garlic       ( amount ) );
		}

		public BagOfGarlic( Serial serial ) : base( serial )
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