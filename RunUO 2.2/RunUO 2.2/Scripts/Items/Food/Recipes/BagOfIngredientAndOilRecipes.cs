using System;
using Server;
using Server.Engines.Craft;
using Server.Items;

namespace Server.Items
{
	public class BagOfIngredientAndOilRecipes : Bag
	{
		[Constructable]
		public BagOfIngredientAndOilRecipes()
		{
                        Name = "Bag Of Ingredient and Oil Recipes";
                        Weight = 0.0;
                        Hue = 2364;

			PlaceItemIn( this, 30,  35, new RandomIngredientsRecipe ( 5000 ) ); // SackFlour
			PlaceItemIn( this, 60,  35, new RandomIngredientsRecipe ( 5001 ) ); // BagOfSugar
			PlaceItemIn( this, 90,  35, new RandomIngredientsRecipe ( 5003 ) ); // SweetDough
			PlaceItemIn( this, 30,  68, new RandomIngredientsRecipe ( 5004 ) ); // CocoaButter
			PlaceItemIn( this, 45,  68, new RandomIngredientsRecipe ( 5005 ) ); // CocoaLiquor

			PlaceItemIn( this, 75,  68, new RandomOilsRecipe ( 5101 ) ); // Batter
			PlaceItemIn( this, 90,  68, new RandomOilsRecipe ( 5102 ) ); // Butter
			PlaceItemIn( this, 30, 118, new RandomOilsRecipe ( 5103 ) ); // Cream
			PlaceItemIn( this, 60, 118, new RandomOilsRecipe ( 5104 ) ); // CookingOil
			PlaceItemIn( this, 90, 118, new RandomOilsRecipe ( 5105 ) ); // Vinegar
		}

                private static void PlaceItemIn( Container parent, int x, int y, Item item )
                {
                        parent.AddItem( item );
                        item.Location = new Point3D( x, y, 0 );
                }

		public BagOfIngredientAndOilRecipes( Serial serial ) : base( serial )
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