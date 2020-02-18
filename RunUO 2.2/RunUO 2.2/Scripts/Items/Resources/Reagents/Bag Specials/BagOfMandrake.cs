using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfMandrake : Bag
	{
		[Constructable]
		public BagOfMandrake() : this( 25 )
		{
		}

		[Constructable]
		public BagOfMandrake( int amount )
		{
			DropItem( new MandrakeRoot ( amount ) );
		}

		public BagOfMandrake( Serial serial ) : base( serial )
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