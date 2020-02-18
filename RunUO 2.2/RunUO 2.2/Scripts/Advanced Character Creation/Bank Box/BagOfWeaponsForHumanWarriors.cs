using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfWeaponsForHumanWarriors : Bag
	{
		[Constructable]
		public BagOfWeaponsForHumanWarriors()
		{
			DropItem( new Club () );
			DropItem( new CrystalStaff () );
			DropItem( new Hatchet () );
			DropItem( new Katana () );
			DropItem( new Kryss () );
		}

		public BagOfWeaponsForHumanWarriors( Serial serial ) : base( serial )
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