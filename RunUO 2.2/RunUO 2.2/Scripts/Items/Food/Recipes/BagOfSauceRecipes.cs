using System;
using Server;
using Server.Engines.Craft;
using Server.Items;

namespace Server.Items
{
	public class BagOfSauceRecipes : Bag
	{
		[Constructable]
		public BagOfSauceRecipes()
		{
                        Name = "Bag Of Sauce Recipes";
                        Weight = 0.0;
                        Hue = 2364;

			PlaceItemIn( this, 30,  35, new RandomSaucesRecipe ( 5201 ) ); // BarbecueSauce
			PlaceItemIn( this, 60,  35, new RandomSaucesRecipe ( 5202 ) ); // CheeseSauce
			PlaceItemIn( this, 90,  35, new RandomSaucesRecipe ( 5203 ) ); // EnchiladaSauce
			PlaceItemIn( this, 30,  68, new RandomSaucesRecipe ( 5204 ) ); // Gravy
			PlaceItemIn( this, 45,  68, new RandomSaucesRecipe ( 5205 ) ); // HotSauce

			PlaceItemIn( this, 75,  68, new RandomSaucesRecipe ( 5206 ) ); // SoySauce
			PlaceItemIn( this, 90,  68, new RandomSaucesRecipe ( 5207 ) ); // Teriyaki
			PlaceItemIn( this, 30, 118, new RandomSaucesRecipe ( 5208 ) ); // TomatoSauce
		}

                private static void PlaceItemIn( Container parent, int x, int y, Item item )
                {
                        parent.AddItem( item );
                        item.Location = new Point3D( x, y, 0 );
                }

		public BagOfSauceRecipes( Serial serial ) : base( serial )
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