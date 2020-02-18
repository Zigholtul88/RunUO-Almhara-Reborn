using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfWeaponsForLjosalfarWarriors : Bag
	{
		[Constructable]
		public BagOfWeaponsForLjosalfarWarriors()
		{
			DropItem( new Club () );
			DropItem( new Hatchet () );
			DropItem( new Leafblade () );
			DropItem( new PristineStaff () );
			DropItem( new RadiantScimitar () );
		}

		public BagOfWeaponsForLjosalfarWarriors( Serial serial ) : base( serial )
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