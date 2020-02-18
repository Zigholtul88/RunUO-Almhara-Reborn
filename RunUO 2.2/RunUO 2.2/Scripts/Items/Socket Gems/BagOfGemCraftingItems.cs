using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfGemCraftingItems : Bag
	{
		[Constructable]
		public BagOfGemCraftingItems() : this( 50 )
		{
		}

		[Constructable]
		public BagOfGemCraftingItems( int amount )
		{
			DropItem( new ArcaneStone      ( amount ) );
			DropItem( new BeetleEgg        ( amount ) );
			DropItem( new BlackGear        ( amount ) );
			DropItem( new Bonemeal         ( amount ) );
			DropItem( new BronzeGear       ( amount ) );
			DropItem( new CharredFeather   ( amount ) );
			DropItem( new CrimsonGear      ( amount ) );
			DropItem( new DiamondDust      ( amount ) );
			DropItem( new DragonScale      ( amount ) );
			DropItem( new ElementalDust    ( amount ) );
			DropItem( new FishScale        ( amount ) );
			DropItem( new LichDust         ( amount ) );
			DropItem( new Nirnroot         ( amount ) );
			DropItem( new SerpentScale     ( amount ) );
			DropItem( new ShadowEssence    ( amount ) );
			DropItem( new SpiderEgg        ( amount ) );
		}

		public BagOfGemCraftingItems( Serial serial ) : base( serial )
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