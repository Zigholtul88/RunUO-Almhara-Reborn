using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfComponents : Bag
	{
		[Constructable]
		public BagOfComponents()
		{
			DropItem( new CopperWire ( 50 ) );
			DropItem( new Feather ( 50 ) );
			DropItem( new Gears ( 50 ) );
			DropItem( new GoldWire ( 50 ) );
			DropItem( new IronIngot ( 50 ) );
			DropItem( new IronWire ( 50 ) );
			DropItem( new Leather ( 50 ) );
			DropItem( new Log ( 50 ) );
			DropItem( new Shaft ( 50 ) );
			DropItem( new SilverWire ( 50 ) );
			DropItem( new SpoolOfThread ( 50 ) );
			DropItem( new Springs ( 50 ) );
		}

		public BagOfComponents( Serial serial ) : base( serial )
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