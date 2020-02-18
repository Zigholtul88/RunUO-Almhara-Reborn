using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfTools : Bag
	{
		[Constructable]
		public BagOfTools()
		{
			DropItem( new FletcherTools () );
			DropItem( new Hammer () );
			DropItem( new RollingPin () );
			DropItem( new SewingKit () );
			DropItem( new SmithHammer () );
			DropItem( new TinkerTools () );
			DropItem( new Hatchet () );
			DropItem( new Pickaxe () );
		}

		public BagOfTools( Serial serial ) : base( serial )
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