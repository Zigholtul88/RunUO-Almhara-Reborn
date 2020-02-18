using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfTamersHandbooks : Bag
	{
		[Constructable]
		public BagOfTamersHandbooks()
		{
			DropItem( new TamersHandbookVol1 () );
			DropItem( new TamersHandbookVol2 () );
			DropItem( new TamersHandbookVol3 () );
			DropItem( new TamersHandbookVol4 () );
			DropItem( new TamersHandbookVol5 () );
		}

		public BagOfTamersHandbooks( Serial serial ) : base( serial )
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