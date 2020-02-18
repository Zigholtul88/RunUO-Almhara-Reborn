using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfSpiderSilk : Bag
	{
		[Constructable]
		public BagOfSpiderSilk() : this( 25 )
		{
		}

		[Constructable]
		public BagOfSpiderSilk( int amount )
		{
			DropItem( new SpidersSilk  ( amount ) );
		}

		public BagOfSpiderSilk( Serial serial ) : base( serial )
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