using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfGinseng : Bag
	{
		[Constructable]
		public BagOfGinseng() : this( 25 )
		{
		}

		[Constructable]
		public BagOfGinseng( int amount )
		{
			DropItem( new Ginseng      ( amount ) );
		}

		public BagOfGinseng( Serial serial ) : base( serial )
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