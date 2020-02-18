using System;
using Server.Items;

namespace Server.Engines.Craft
{
        public enum PreparationsRecipes

        {
               #region Custom Recipes

               #region Ingredients Recipes 5000 - 5100
               SackFlour = 5000,
               BagOfSugar = 5001,
        
               Dough = 5002,
        
               SweetDough = 5003,
        
               CocoaButter = 5004,
               CocoaLiquor = 5005,
         
               #endregion
 
       
               #region Oils Recipes 5101- 5200
        
               Batter = 5101,
        
               Butter = 5102,
        
               Cream =  5103,
        
               CookingOil = 5104,
               Vinegar = 5105,
        
               #endregion
   
     
               #region Sauces Recipes 5201 - 5300
        
               BarbecueSauce = 5201,
        
               CheeseSauce = 5202,
        
               EnchiladaSauce = 5203,
        
               Gravy = 5204,
        
               HotSauce = 5205,
        
               SoySauce = 5206,
        
               Teriyaki = 5207,
        
               TomatoSauce = 5208,
        
               #endregion
    

               #region Preparations Recipes 5401 - 5500
               PastaNoodles = 5401,
               PeanutButter = 5402,
               FruitJam = 5403,
               Tortilla = 5404,
               WoodPulp = 5405,
               GreenTea = 5406,
               WasabiClumps = 5407,
               SushiRolls = 5408,
               SushiPlatter = 5409,
               TribalPaint = 5410,
               EggBomb = 5411,
               DriedOnions = 5412,
               DriedHerbs = 5413,
               BasketOfHerbsFarm = 5414,
               CakeMix = 5415,
               CookieMix = 5416,
               ChocolateMix = 5417,
               AsianVegMix = 5418,
               MixedVegetables = 5419,
               PizzaCrust = 5420,
               WaffleMix = 5421,
               BowlCornFlakes = 5422,
               BowlRiceKrisps = 5423,
               FruitBasket = 5424,
               Tofu = 5425,
               ParrotWafer = 5426,
               PieMix = 5427,
               UnbakedQuiche = 5428,
               UnbakedMeatPie = 5429,
               UncookedSausagePizza = 5430,
               UncookedCheesePizza = 5431,
               UnbakedFruitPie = 5432,
               UnbakedPeachCobbler = 5433,
               UnbakedApplePie = 5434,
               UnbakedPumpkinPie = 5435,
               #endregion

               #region Begin Barbecue Recipes 5701 - 5800
               #endregion
               #region Dinners Recipes 5801 - 5900
               #endregion
               #region Begin Chocolatiering Recipes 5901 - 5999
               #endregion
               #endregion
        }

	public class DefPreparations : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Cooking;	}
		}

		public override string GumpTitleString
		{
			get { return "<basefont color=#FFFFFF><CENTER>Preparations MENU</CENTER></basefont>"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefPreparations();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefPreparations() : base( 1, 1, 1.25 )// base( 1, 1, 1.5 )
		{
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !BaseTool.CheckAccessible( tool, from ) )
				return 1044263; // The tool must be on your person to use.

			return 0;
		}

		public override void PlayCraftEffect( Mobile from )
		{
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
		{
			if ( toolBroken )
				from.SendLocalizedMessage( 1044038 ); // You have worn out your tool

			if ( failed )
			{
				if ( lostMaterial )
					return 1044043; // You failed to create the item, and some of your materials are lost.
				else
					return 1044157; // You failed to create the item, but no materials were lost.
			}
			else
			{
				if ( quality == 0 )
					return 502785; // You were barely able to make this item.  It's quality is below average.
				else if ( makersMark && quality == 2 )
					return 1044156; // You create an exceptional quality item and affix your maker's mark.
				else if ( quality == 2 )
					return 1044155; // You create an exceptional quality item.
				else				
					return 1044154; // You create the item.
			}
		}

		public override void InitCraftList()
		{
			int index = -1;

			/* Begin Ingredients */
			index = AddCraft( typeof( SackFlour ), 1044495, 1024153, 0.0, 100.0, typeof( WheatSheaf ), 1044489, 2, 1044490 );
			SetNeedMill( index, true );

                        index = AddCraft(typeof( BagOfSugar ), 1044495, "Bag of Sugar", 0.0, 100.0, typeof( Sugarcane ), "Sugarcane", 20, "You don't have enough sugarcane.");
			SetNeedMill( index, true );

			index = AddCraft( typeof( Dough ), 1044495, 1024157, 0.0, 100.0, typeof( SackFlour ), 1044468, 1, 1044253 );
			AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );

			index = AddCraft( typeof( SweetDough ), 1044495, 1041340, 0.0, 100.0, typeof( Dough ), 1044469, 1, 1044253 );
			AddRes( index, typeof( JarHoney ), 1044472, 1, 1044253 );

			index = AddCraft( typeof( CakeMix ), 1044495, 1041002, 0.0, 100.0, typeof( SackFlour ), 1044468, 1, 1044253 );
			AddRes( index, typeof( SweetDough ), 1044475, 1, 1044253 );

			index = AddCraft( typeof( CookieMix ), 1044495, 1024159, 0.0, 100.0, typeof( JarHoney ), 1044472, 1, 1044253 );
			AddRes( index, typeof( SweetDough ), 1044475, 1, 1044253 );

			index = AddCraft( typeof( CocoaButter ), 1044495, 1079998, 0.0, 100.0, typeof( CocoaPulp ), 1080530, 1, 1044253 );
			SetNeedOven( index, true );

			index = AddCraft( typeof( CocoaLiquor ), 1044495, 1079999, 0.0, 100.0, typeof( CocoaPulp ), 1080530, 1, 1044253 );
			AddRes( index, typeof( EmptyPewterBowl ), 1025629, 1, 1044253 );
			SetNeedOven( index, true );
			/* End Ingredients */

                        #region Oils
                        index = AddCraft( typeof( Batter ), "Oils", "Batter", 20.0, 100.0, typeof( Dough ), 1044469, 1, 1044253 );
                        AddRes( index, typeof( Eggs ), "Eggs", 1, 1044253 );
                        AddRes( index, typeof( JarHoney ), 1044472, 1, 1044253 );
                        SetNeedHeat( index, true );

                        index = AddCraft( typeof( Butter ), "Oils", "Butter", 20.0, 100.0, typeof( Cream ), "Cream", 1, 1044253 );
                        SetNeedHeat( index, true );

                        index = AddCraft( typeof( Cream ), "Oils", "Cream", 20.0, 100.0, typeof( BaseBeverage ), "Milk", 1, 1044253 );
                        SetNeedHeat( index, true );

                        index = AddCraft( typeof( CookingOil ), "Oils", "Cooking Oil", 25.0, 100.0, typeof( Peanut ), "Peanut", 10, 1044253 );
                        SetNeedHeat( index, true );

                        index = AddCraft( typeof( Vinegar ), "Oils", "Vinegar", 25.0, 100.0, typeof( Apple ), "apples", 5, 1044253 );
                        AddRes( index, typeof( BottleOfWine ), "Wine", 1, 1044253 );
                        SetNeedHeat( index, true );
                        #endregion

                        #region Sauces
                        index = AddCraft( typeof( BarbecueSauce ), "Sauces", "Barbecue Sauce", 25.0, 100.0, typeof( Tomato ), "Tomato", 1, 1044253 );
                        AddRes( index, typeof( JarHoney ), "Honey", 1, 1044253 );
                        AddRes( index, typeof( BasketOfHerbsFarm ), "Herbs", 1, 1044253 );
                        SetNeedHeat( index, true );

                        index = AddCraft( typeof( EnchiladaSauce ), "Sauces", "Enchilada Sauce", 25.0, 100.0, typeof( Tomato ), "Tomato", 1, 1044253 );
                        AddRes( index, typeof( ChiliPepper ), "Chili Pepper", 1, 1044253 );
                        AddRes( index, typeof( BasketOfHerbsFarm ), "Herbs", 1, 1044253 );
                        SetNeedHeat( index, true );

                        index = AddCraft( typeof( Gravy ), "Sauces", "Gravy", 25.0, 100.0, typeof( Dough ), 1044469, 2, 1044253 );
                        AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );
                        AddRes( index, typeof( BasketOfHerbsFarm ), "Herbs", 1, 1044253 );
                        SetNeedHeat( index, true );

                        index = AddCraft( typeof( HotSauce ), "Sauces", "Hot Sauce", 25.0, 100.0, typeof( Tomato ), "Tomato", 2, 1044253 );
                        AddRes( index, typeof( ChiliPepper ), "Chili Pepper", 3, 1044253 );
                        AddRes( index, typeof( BasketOfHerbsFarm ), "Herbs", 1, 1044253 );
                        SetNeedHeat( index, true );

                        index = AddCraft( typeof( SoySauce ), "Sauces", "Soy Sauce", 25.0, 100.0, typeof( BagOfSoy ), "Bag of Soy", 1, 1044253 );
                        AddRes( index, typeof( BagOfSugar ), "Bag of Sugar", 1, 1044253 );
                        AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );
                        SetNeedHeat( index, true );

                        index = AddCraft( typeof( Teriyaki ), "Sauces", "Teriyaki", 25.0, 100.0, typeof( SoySauce ), "Soy Sauce", 1, 1044253 );
                        AddRes( index, typeof( BottleOfWine ), "Bottle of Wine", 1, 1044253 );
                        AddRes( index, typeof( JarHoney ), "Honey", 1, 1044253 );
                        SetNeedHeat( index, true );

                        index = AddCraft( typeof( TomatoSauce ), "Sauces", "Tomato Sauce", 25.0, 100.0, typeof( Tomato ), "Tomato", 3, 1044253 );
                        AddRes( index, typeof( BasketOfHerbsFarm ), "Herbs", 1, 1044253 );
                        SetNeedHeat( index, true );
                        #endregion

			/* Begin Preparations */
                        index = AddCraft(typeof(PastaNoodles), 1044496, "Pasta Noodles", 50.0, 100.0, typeof(SackFlour), "Sack of Flour", 1, 1044253);
                        AddRes(index, typeof(Eggs), "eggs", 5, 1044253);

                        index = AddCraft(typeof(PeanutButter), 1044496, "Peanut Butter", 55.0, 100.0, typeof(Peanut), "Peanuts", 30, 1044253);
                        AddRecipe(index, (int)PreparationsRecipes.PeanutButter);

                        index = AddCraft(typeof(FruitJam), 1044496, "Fruit Jam", 55.0, 100.0, typeof(FruitBasket), "Fruit Basket", 1, 1044253);
                        AddRes(index, typeof(BagOfSugar), "Bag of Sugar", 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(Tortilla), 1044496, "Tortilla", 55.0, 100.0, typeof(BagOfCornmeal), "Bag of Cornmeal", 1, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedOven(index, true);

                     

                        index = AddCraft(typeof(GreenTea), 1044496, 1030315, 80.0, 120.0, typeof(GreenTeaBasket), 1030316, 1, 1044253);
                
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);               
                        SetNeedOven(index, true);

                

                        index = AddCraft(typeof(WasabiClumps), 1044496, 1029451, 70.0, 120.0, typeof(BaseBeverage), 1046458, 1, 1044253);
                
                        AddRes(index, typeof(WoodenBowlOfPeas), 1025633, 3, 1044253);

                        index = AddCraft(typeof(SushiRolls), 1044496, 1030303, 90.0, 120.0, typeof(BaseBeverage), 1046458, 1, 1044253);

                        AddRes(index, typeof(RawFishSteak), 1044476, 10, 1044253);

                        index = AddCraft(typeof(SushiPlatter), 1044496, 1030305, 90.0, 120.0, typeof(BaseBeverage), 1046458, 1, 1044253);
                
                        AddRes(index, typeof(RawFishSteak), 1044476, 10, 1044253); 

                        index = AddCraft(typeof(TribalPaint), 1044496, 1040000, Core.ML ? 55.0 : 80.0, Core.ML ? 105.0 : 80.0, typeof(SackFlour), 1044468, 1, 1044253);
            
                        AddRes(index, typeof(TribalBerry), 1046460, 1, 1044253);

                        index = AddCraft(typeof(EggBomb), 1044496, 1030249, 90.0, 120.0, typeof(Eggs), 1044477, 1, 1044253);
                
                        AddRes(index, typeof(SackFlour), 1044468, 3, 1044253);

                        index = AddCraft(typeof(DriedOnions), 1044496, "Dried Onions", 60.0, 100.0, typeof(Onion), "Onions", 5, 1044253);

                        index = AddCraft(typeof(DriedHerbs), 1044496, "Dried Herbs", 60.0, 100.0, typeof(Garlic), "Garlic", 2, 1044253);
                        AddRes(index, typeof(Ginseng), "Ginseng", 2, 1044253);
                        AddRes(index, typeof(TanGinger), "Tan Ginger", 2, "You need more tan ginger");

                        index = AddCraft(typeof(BasketOfHerbsFarm), 1044496, "Basket of Herbs", 60.0, 100.0, typeof(DriedHerbs), "Dried Herbs", 1, 1044253);
                        AddRes(index, typeof(DriedOnions), "Dried Onions", 1, 1044253);

                        index = AddCraft(typeof(CakeMix), 1044496, 1041002, 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
                        AddRes(index, typeof(CookingOil), "Cooking Oil", 1, 1044253);
                        AddRes(index, typeof(BagOfSugar), "Bag of Sugar", 1, 1044253);

                        index = AddCraft(typeof(CookieMix), 1044496, 1024159, 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
                        AddRes(index, typeof(Butter), "Butter", 1, 1044253);
                        AddRes(index, typeof(JarHoney), "Honey", 1, 1044253);

                        index = AddCraft(typeof(ChocolateMix), 1044496, "Chocolate Mix", 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
                        AddRes(index, typeof(BagOfCocoa), "Bag of Cocoa", 1, 1044253);
                        AddRes(index, typeof(BagOfSugar), "Bag of Sugar", 1, 1044253);

                        index = AddCraft(typeof(AsianVegMix), 1044496, "Asian Vegetable Mix", 60.0, 100.0, typeof(Cabbage), "Cabbage", 1, 1044253);
                        AddRes(index, typeof(Onion), "Onion", 1, 1044253);
                        AddRes(index, typeof(RedMushroom), "Red Mushroom", 1, "You need a Red Mushroom");
                        AddRes(index, typeof(Carrot), "Carrot", 1, 1044253);

                        index = AddCraft(typeof(MixedVegetables), 1044496, "Mixed Vegetables", 60.0, 100.0, typeof(Potato), "Potato", 2, 1044253);
                        AddRes(index, typeof(Carrot), "Carrot", 1, 1044253);
                        AddRes(index, typeof(Celery), "Celery", 1, 1044253);
                        AddRes(index, typeof(Onion), "Onion", 1, 1044253);

                        index = AddCraft(typeof(PizzaCrust), 1044496, "Pizza Crust", 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);

                        index = AddCraft(typeof(WaffleMix), 1044496, "Waffle Mix", 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
                        AddRes(index, typeof(Eggs), "Eggs", 2, 1044253);
                        AddRes(index, typeof(CookingOil), "Cooking Oil", 1, 1044253);

                        index = AddCraft(typeof(BowlCornFlakes), 1044497, "Bowl of Corn Flakes", 60.0, 100.0, typeof(BagOfCornmeal), "Bag of Cornmeal", 1, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);

                        index = AddCraft(typeof(BowlRiceKrisps), 1044497, "Bowl of Rice Krisps", 60.0, 100.0, typeof(BagOfRicemeal), "Bag of Ricemeal", 1, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);

                        index = AddCraft(typeof(FruitBasket), 1044497, "Fruit Basket", 60.0, 100.0, typeof(Apple), "Apple", 5, 1044253);
                        AddRes(index, typeof(Peach), "Peach", 5, 1044253);
                        AddRes(index, typeof(Pear), "Pear", 5, 1044253);
                        AddRes(index, typeof(Cherry), "Cherries", 5, 1044253);

                        index = AddCraft(typeof(Tofu), 1044497, "Tofu", 60.0, 100.0, typeof(BagOfSoy), "Bag of Soy", 1, 1044253);

                        index = AddCraft(typeof(PieMix), 1044496, "Pie Mix", 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
                        AddRes(index, typeof(Butter), "Butter", 1, 1044253);

			// TODO: This must also support chicken and lamb legs
                        index = AddCraft(typeof(UnbakedQuiche), 1044496, 1041339, 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
            
                        AddRes(index, typeof(Eggs), 1044477, 1, 1044253);           

                        index = AddCraft(typeof(UnbakedMeatPie), 1044496, 1041338, 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
            
                        AddRes(index, typeof(RawRibs), 1044482, 1, 1044253);          

                        index = AddCraft(typeof(UncookedSausagePizza), 1044496, 1041337, 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
            
                        AddRes(index, typeof(Sausage), 1044483, 1, 1044253);            

                        index = AddCraft(typeof(UncookedCheesePizza), 1044496, 1041341, 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
            
                        AddRes(index, typeof(CheeseWheel), 1044486, 1, 1044253);          

                        index = AddCraft(typeof(UnbakedFruitPie), 1044496, 1041334, 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
            
                        AddRes(index, typeof(Pear), 1044481, 1, 1044253);          

                        index = AddCraft(typeof(UnbakedPeachCobbler), 1044496, 1041335, 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
            
                        AddRes(index, typeof(Peach), 1044480, 1, 1044253);            

                        index = AddCraft(typeof(UnbakedApplePie), 1044496, 1041336, 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
            
                        AddRes(index, typeof(Apple), 1044479, 1, 1044253);          

                        index = AddCraft(typeof(UnbakedPumpkinPie), 1044496, 1041342, 60.0, 100.0, typeof(Dough), 1044469, 1, 1044253);
            
                        AddRes(index, typeof(Pumpkin), 1044484, 1, 1044253);

			index = AddCraft( typeof( EggBomb ), 1044496, 1030249, 90.0, 120.0, typeof( Eggs ), 1044477, 1, 1044253 );
			AddRes( index, typeof( SackFlour ), 1044468, 3, 1044253 );
			/* End Preparations */

			/* Begin Special Meats */
			index = AddCraft( typeof( FlavoredBeetleCollectorPrimeCut ), "Special Meats", "Flavored Beetle Collector Prime Cut", 8.8, 100.0, typeof( FaerieBeetleCollectorMeat ), "Fae-Beetle Collector Meat", 1, 1044253 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( FlavoredBeetlePrimeCut ), "Special Meats", "Flavored Beetle Prime Cut", 37.6, 100.0, typeof( FaerieBeetleMeat ), "Faerie Beetle Meat", 1, 1044253 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( GizzardRibs ), "Special Meats", "Gizzard Ribs", 5.5, 100.0, typeof( RawGizzardRibs ), "Raw Gizzard Ribs", 1, 1044253 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( PrimedWaterLizardMeat ), "Special Meats", "Primed Water Lizard Meat", 8.0, 100.0, typeof( WaterLizardMeat ), "Water Lizard Meat", 1, 1044253 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( PristineSewerBeef ), "Special Meats", "Pristine Sewer Beef", 7.0, 100.0, typeof( SewerBeef ), "Sewer Beef", 1, 1044253 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( SmokedDireWolfLeg ), "Special Meats", "Smoked Dire Wolf Leg", 20.0, 100.0, typeof( RawDireWolfLeg ), "Raw Dire Wolf Leg", 1, 1044253 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( SmokedForestBatRibs ), "Special Meats", "Smoked Forest Bat Ribs", 5.5, 100.0, typeof( RawForestBatRibs ), "Raw Forest Bat Ribs", 1, 1044253 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( SmokedGreyWolfLeg ), "Special Meats", "Smoked Grey Wolf Leg", 15.0, 100.0, typeof( RawGreyWolfLeg ), "Raw Grey Wolf Leg", 1, 1044253 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( SmokedSandCrabMeat ), "Special Meats", "Smoked Sand Crab Meat", 20.0, 100.0, typeof( SandCrabMeat ), "Sand Crab Meat", 1, 1044253 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( TurkeyLeg ), "Special Meats", "Turkey Leg", 27.5, 100.0, typeof( RawTurkeyLeg ), "Raw Turkey Leg", 1, 1044253 );
			SetNeedHeat( index, true );
			/* End Special Meats */
		}
	}
}