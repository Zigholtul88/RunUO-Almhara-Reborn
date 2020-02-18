using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfWeaponsForSvartalfarWarriors : Bag
	{
		[Constructable]
		public BagOfWeaponsForSvartalfarWarriors()
		{
			DropItem( new Club () );
			DropItem( new Hatchet () );
			DropItem( new EbonyPristineStaff () );
			DropItem( new EbonyRapier () );
			DropItem( new EbonyScimitar () );
		}

		public BagOfWeaponsForSvartalfarWarriors( Serial serial ) : base( serial )
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