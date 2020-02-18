using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfBlackPearl : Bag
	{
		[Constructable]
		public BagOfBlackPearl() : this( 25 )
		{
		}

		[Constructable]
		public BagOfBlackPearl( int amount )
		{
			DropItem( new BlackPearl   ( amount ) );
		}

		public BagOfBlackPearl( Serial serial ) : base( serial )
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