using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfCookingIngredients : Bag
	{
		[Constructable]
		public BagOfCookingIngredients()
		{
			DropItem( new FaerieBeetleCollectorMeat ( 100 ) );
			DropItem( new FaerieBeetleMeat ( 100 ) );
			DropItem( new RawDireWolfLeg ( 100 ) );
			DropItem( new RawForestBatRibs ( 100 ) );
			DropItem( new RawGizzardRibs ( 100 ) );
			DropItem( new RawGreyWolfLeg ( 100 ) );
			DropItem( new RawTurkeyLeg ( 100 ) );
			DropItem( new SandCrabMeat ( 100 ) );
			DropItem( new SewerBeef ( 100 ) );
			DropItem( new WaterLizardMeat ( 100 ) );
		}

		public BagOfCookingIngredients( Serial serial ) : base( serial )
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