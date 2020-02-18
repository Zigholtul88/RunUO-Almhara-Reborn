using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfSulfurousAsh : Bag
	{
		[Constructable]
		public BagOfSulfurousAsh() : this( 25 )
		{
		}

		[Constructable]
		public BagOfSulfurousAsh( int amount )
		{
			DropItem( new SulfurousAsh ( amount ) );
		}

		public BagOfSulfurousAsh( Serial serial ) : base( serial )
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