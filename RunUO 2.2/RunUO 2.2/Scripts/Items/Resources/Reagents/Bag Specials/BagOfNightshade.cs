using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfNightshade : Bag
	{
		[Constructable]
		public BagOfNightshade() : this( 25 )
		{
		}

		[Constructable]
		public BagOfNightshade( int amount )
		{
			DropItem( new Nightshade   ( amount ) );
		}

		public BagOfNightshade( Serial serial ) : base( serial )
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