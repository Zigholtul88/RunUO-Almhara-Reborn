using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfStarterScrolls : Bag
	{
		[Constructable]
		public BagOfStarterScrolls()
		{
			DropItem( new ClumsyScroll () );
			DropItem( new FeeblemindScroll () );
			DropItem( new HealScroll () );
			DropItem( new MagicArrowScroll () );
			DropItem( new WeakenScroll () );
		}

		public BagOfStarterScrolls( Serial serial ) : base( serial )
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