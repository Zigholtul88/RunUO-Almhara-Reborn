using System;
using Server.Items;

namespace Server.Engines.Craft
{
        public enum BakingRecipes

        {
               #region Custom Recipes
    
               #region Raw Meat Prep Recipes 5301 - 5400
               VenisonSteak = 5301,
               VenisonJerky = 5302,
               VenisonRoast = 5303,
               BeefPorterhouse = 5304,
               BeefPrimeRib = 5305,
               BeefRibeye = 5306,
               BeefRibs = 5307,
               BeefRoast = 5308,
               BeefSirloin = 5309,
               BeefJerky = 5310,
               BeefTBone = 5311,
               BeefTenderloin = 5312,
               GroundBeef = 5313,
               GoatSteak = 5314,
               GoatRoast = 5315,
               RawGroundPork = 5317,
               Bacon = 5318,
               BaconSlab = 5319,
               Ham = 5320,
               HamSlices = 5321,
               PigHead = 5322,
               PorkChop = 5323,
               PorkRoast = 5324,
               PorkSpareRibs = 5325,
               Trotters = 5326,
               Sausage = 5327,
               MuttonSteak = 5328,
               MuttonRoast = 5329,
               LambLeg = 5330,
               GroundPork = 5331,
               RoastChicken = 5332,
               ChickenLeg = 5333,
               RoastTurkey = 5334,
               TurkeyLeg = 5335,
               TurkeyPlatter = 5336,
               SlicedTurkey = 5337,
               RoastDuck = 5338,
               DuckLeg = 5339,
               CookedBird = 5340,
               Ribs = 5341,
               CookedSteak = 5342,
        
               #endregion

               #region Baking Recipes 5501 - 5600
               BreadLoaf = 5501,
               GarlicBread = 5502,
               BananaBread = 5503,
               PumpkinBread = 5504,
               CornBread = 5505,
               Cookies = 5506,
               AlmondCookies = 5507,
               ChocChipCookies = 5508,
               GingerSnaps = 5509,
               OatmealCookies = 5510,
               PeanutButterCookies = 5511,
               PumpkinCookies = 5512,
               Cake = 5513,
               BananaCake = 5514,
               CarrotCake = 5515,
               ChocolateCake = 5516,
               CoconutCake = 5517,
               LemonCake = 5518,
               Muffins = 5519,
               BlueberryMuffins = 5520,
               PumpkinMuffins = 5521,
               SausagePizza = 5522,
               CheesePizza = 5523,
               HamPineapplePizza = 5524,
               MushroomOnionPizza = 5525,
               SausOnionMushPizza = 5526,
               TacoPizza = 5527,
               VeggiePizza = 5528,
               Quiche = 5529,
               MeatPie = 5530,
               FruitPie = 5531,
               PeachCobbler = 5532,
               ApplePie = 5533,
               PumpkinPie = 5534,
               BlueberryPie = 5535,
               CherryPie = 5536,
               KeyLimePie = 5537,
               LemonMerenguePie = 5538,
               BlackberryCobbler = 5539,
               ShepherdsPie = 5540,
               TurkeyPie = 5541,
               ChickenPie = 5542,
               BeefPie = 5543,
               Brownies = 5544,
               ChocSunflowerSeeds = 5545,
               RiceKrispTreat = 5546,
               BowlOatmeal = 5547,
               Popcorn = 5548,
               Pancakes = 5549,
               Waffles = 5550,
               #endregion

               #region Boiling Recipes 5601 - 5700
               ChickenNoodleSoup = 5601,
               TomatoRice = 5602,
               BowlOfStew = 5603,
               TomatoSoup = 5604,
               HarpyEggSoup = 5605,
               BowlBeets = 5606,
               BowlBroccoli = 5607,
               BowlCauliflower = 5608,
               BowlGreenBeans = 5609,
               BowlRice = 5610,
               BowlSpinach = 5611,
               BowlTurnips = 5612,
               BowlMashedPotatos = 5613,
               BowlCookedVeggies = 5614,
               WoodenBowlCabbage = 5615,
               WoodenBowlCarrot = 5616,
               WoodenBowlCorn = 5617,
               WoodenBowlLettuce = 5618,
               WoodenBowlPea = 5619,
               PewterBowlOfPotatos = 5620,
               CornOnCob = 5621,
               Hotdog = 5622,
               MisoSoup = 5623,
               WhiteMisoSoup =5624,
               RedMisoSoup = 5625,
               AwaseMisoSoup = 5626
               #endregion

               #region Begin Barbecue Recipes 5701 - 5800
               #endregion
               #region Dinners Recipes 5801 - 5900
               #endregion
               #region Begin Chocolatiering Recipes 5901 - 5999
               #endregion
               #endregion
        }

	public class DefBaking : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Cooking;	}
		}

		public override string GumpTitleString
		{
			get { return "<basefont color=#FFFFFF><CENTER>Baking MENU</CENTER></basefont>"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefBaking();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefBaking() : base( 1, 1, 1.25 )// base( 1, 1, 1.5 )
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

                        #region Raw Meat Prep

                        #region Game Meats

                        #region Deer
                        index = AddCraft(typeof(VenisonSteak), "Raw Meat Prep", "Venison Steak", 25.0, 100.0, typeof(RawVenisonSteak), "Raw Venison Steak", 1, "You need more Raw Venison Steak");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(VenisonJerky), "Raw Meat Prep", "Venison Jerky", 25.0, 100.0, typeof(RawVenisonSlice), "Raw Venison Slice", 1, "You need more Raw Venison Slice");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(VenisonRoast), "Raw Meat Prep", "Venison Roast", 25.0, 100.0, typeof(RawVenisonRoast), "Raw Venison Roast", 1, "You need more Raw Venison Roast");
                        SetNeedHeat(index, true);
                        #endregion

                        #endregion

                        #region Lean Ground Meats

                        #region Beef
                        index = AddCraft(typeof(BeefPorterhouse), "Raw Meat Prep", "Beef Porterhouse", 30.0, 100.0, typeof(RawBeefPorterhouse), "Raw Beef Porterhouse", 1, "You need more Raw Beef Porterhouse");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(BeefPrimeRib), "Raw Meat Prep", "Beef Prime Rib", 30.0, 100.0, typeof(RawBeefPrimeRib), "Raw Beef Prime Rib", 1, "You need more Raw Beef Prime Rib");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(BeefRibeye), "Raw Meat Prep", "Beef Ribeye", 30.0, 100.0, typeof(RawBeefRibeye), "Raw Beef Ribeye", 1, "You need more Raw Beef Ribeye");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(BeefRibs), "Raw Meat Prep", "Beef Ribs", 30.0, 100.0, typeof(RawBeefRibs), "Raw Beef Ribs", 1, "You need more Raw Beef Ribs");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(BeefRoast), "Raw Meat Prep", "Beef Roast", 30.0, 100.0, typeof(RawBeefRoast), "Raw Beef Roast", 1, "You need more Raw Beef Roast");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(BeefSirloin), "Raw Meat Prep", "Beef Sirloin", 30.0, 100.0, typeof(RawBeefSirloin), "Raw Beef Sirloin", 1, "You need more Raw Beef Sirloin");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(BeefJerky), "Raw Meat Prep", "Beef Jerky", 30.0, 100.0, typeof(RawBeefSlice), "Raw Beef Slice", 1, "You need more Raw Beef Slices");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(BeefTBone), "Raw Meat Prep", "Beef T-Bone", 30.0, 100.0, typeof(RawBeefTBone), "Raw Beef T-Bone", 1, "You need more Raw Beef T-Bone");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(BeefTenderloin), "Raw Meat Prep", "Beef Tenderloin", 30.0, 100.0, typeof(RawBeefTenderloin), "Raw Beef Tenderloin", 1, "You need more Raw Raw Beef Tenderloin");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(GroundBeef), 1044496, "Ground Beef", 30.0, 100.0, typeof(BeefHock), "Beef Hock", 1, 1044253);
                        #endregion

                        #region Goat
                        index = AddCraft(typeof(GoatSteak), "Raw Meat Prep", "Goat Steak", 35.0, 100.0, typeof(RawGoatSteak), "Raw Goat Steak", 1, "You need more Raw Goat Steak");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(GoatRoast), "Raw Meat Prep", "Goat Roast", 35.0, 100.0, typeof(RawGoatRoast), "Raw Goat Roast", 1, "You need more Raw Goat Roast");
                        SetNeedHeat(index, true);
                        #endregion

                        #region Pork
                        index = AddCraft(typeof(RawGroundPork), "Raw Meat Prep", "Raw Ground Pork", 40.0, 100.0, typeof(PorkHock), "Pork Hock", 1, "You need more Pork Hock");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(Bacon), "Raw Meat Prep", "Bacon", 40.0, 100.0, typeof(RawBacon), "Raw Bacon", 1, "You need more Raw Bacon");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(BaconSlab), "Raw Meat Prep", "Bacon Slab", 40.0, 100.0, typeof(RawBaconSlab), "Raw Bacon Slab", 1, "You need more Raw Bacon Slab");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(Ham), "Raw Meat Prep", "Ham", 40.0, 100.0, typeof(RawHam), "Raw Ham", 1, "You need more Raw Ham");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(HamSlices), "Raw Meat Prep", "Ham Slices", 40.0, 100.0, typeof(RawHamSlices), "Raw Ham Slices", 1, "You need more Raw Ham Slices");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(PigHead), "Raw Meat Prep", "Pig Head", 40.0, 100.0, typeof(RawPigHead), "Raw Pig Head", 1, "You need more Raw Pig Head");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(PorkChop), "Raw Meat Prep", "Pork Chop", 40.0, 100.0, typeof(RawPorkChop), "Raw Pork Chop", 1, "You need more Raw Pork Chop");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(PorkRoast), "Raw Meat Prep", "Pork Roast", 40.0, 100.0, typeof(RawPorkRoast), "Raw Pork Roast", 1, "You need more Raw Pork Roast");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(PorkSpareRibs), "Raw Meat Prep", "Pork Spare Ribs", 40.0, 100.0, typeof(RawSpareRibs), "Raw Spare Ribs", 1, "You need more Raw Spare Ribs");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(Trotters), "Raw Meat Prep", "Trotters", 40.0, 100.0, typeof(RawTrotters), "Raw Trotters", 1, "You need more Raw Trotters");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(Sausage), "Raw Meat Prep", "Sausage", 40.0, 100.0, typeof(RawPorkSlice), "Raw Pork Slice", 1, "You need more Raw Pork Slice");
                        SetNeedHeat(index, true);
                        #endregion

                        #region Sheep
                        index = AddCraft(typeof(MuttonSteak), "Raw Meat Prep", "Mutton Steak", 40.0, 100.0, typeof(RawMuttonSteak), "Raw Mutton Steak", 1, "You need more Raw Mutton Steak");
                        SetNeedHeat(index, true);

                        index = AddCraft(typeof(MuttonRoast), "Raw Meat Prep", "Mutton Roast", 40.0, 100.0, typeof(RawMuttonRoast), "Raw Mutton Roast", 1, "You need more Raw Mutton Roast");
                        SetNeedHeat(index, true);

                        index = AddCraft( typeof( LambLeg ), "Raw Meat Prep", "Lamb Leg", 40.0, 100.0, typeof( RawLambLeg ), 1044478, 1, 1044253 );
                        SetNeedHeat( index, true );
                        SetUseAllRes( index, true );
                        #endregion
                        #endregion

                        #region Poultry

                        #region Chicken
                        index = AddCraft( typeof( RoastChicken ), "Raw Meat Prep", "Roast Chicken", 40.0, 100.0, typeof( RawChicken ), "Raw Chicken", 1, "You need more Raw Chicken" );
                        SetNeedHeat( index, true );

                        index = AddCraft( typeof( ChickenLeg ), "Raw Meat Prep", "Chicken Leg", 40.0, 100.0, typeof( RawChickenLeg ), 1044473, 1, 1044253 );
                        SetNeedHeat( index, true );
                        SetUseAllRes( index, true );
                        #endregion

                        #region Turkey
                        index = AddCraft( typeof( RoastTurkey ), "Raw Meat Prep", "Roast Turkey", 45.0, 100.0, typeof( RawTurkey ), "Raw Turkey", 1, "You need more Raw Turkey" );
                        SetNeedHeat( index, true );

                        index = AddCraft( typeof( TurkeyLeg ), "Raw Meat Prep", "Turkey Leg", 45.0, 100.0, typeof( RawTurkeyLeg ), "Raw Turkey Leg", 1, "You need more Raw Turkey Leg" );
                        SetNeedHeat( index, true );

                        index = AddCraft(typeof( TurkeyPlatter ), "Raw Meat Prep", "Turkey Platter", 45.0, 100.0, typeof( RawTurkey ), "Raw Chicken", 1, "You need more Raw Turkey" );
                        AddRes( index, typeof( FoodPlate ), "Plate", 1, "You need a plate!" );
                        SetNeedHeat( index, true );

                        index = AddCraft(typeof( SlicedTurkey ), "Raw Meat Prep", "Sliced Turkey", 45.0, 100.0, typeof( TurkeyHock ), "Turkey Hock", 1, 1044253 );

                        #endregion

                        #region Duck
                        index = AddCraft( typeof( RoastDuck ), "Raw Meat Prep", "Roast Duck", 45.0, 100.0, typeof( RawChicken ), "Raw Chicken", 1, "You need more Raw Chicken" );
                        SetNeedHeat( index, true );

                        index = AddCraft( typeof( DuckLeg ), "Raw Meat Prep", "Duck Leg", 45.0, 100.0, typeof( RawDuckLeg ), "Raw Duck Leg", 1, "You need more Raw Duck Legs" );
                        SetNeedHeat( index, true );
                        #endregion

                        #region Bird
                        index = AddCraft(typeof( CookedBird ), "Raw Meat Prep", "Cooked Bird", 45.0, 100.0, typeof( RawBird ), 1044470, 1, 1044253 );
                        SetNeedHeat( index, true );
                        SetUseAllRes( index, true );
                        #endregion

                        #endregion

                        #region Misc Meats
                        index = AddCraft( typeof( Ribs ), "Raw Meat Prep", "Ribs", 50.0, 100.0, typeof( RawRibs ), 1044485, 1, 1044253 );
                        SetNeedHeat( index, true );
                        SetUseAllRes( index, true );

                        index = AddCraft( typeof( CookedSteak ), "Raw Meat Prep", "Cooked Steak", 50.0, 100.0, typeof( RawSteak ), "Raw Steak", 1, "You need more Raw Steak" );
                        SetNeedHeat( index, true );
                        #endregion

                        #endregion

                        #region Baking
			index = AddCraft( typeof( BreadLoaf ), 1044497, 1024156, 0.0, 100.0, typeof( Dough ), 1044469, 1, 1044253 );
			SetNeedOven( index, true );

                        index = AddCraft(typeof(GarlicBread), 1044497, "Garlic Bread", 70.0, 100.0, typeof(BreadLoaf), 1024156, 1, 1044253);
                        AddRes(index, typeof(Butter), "Butter", 1, 1044253);
                        AddRes(index, typeof(Garlic), "Garlic", 2, 1044253);
                        AddRes(index, typeof(BasketOfHerbsFarm), "Herbs", 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(BananaBread), 1044497, "Banana Bread", 70.0, 100.0, typeof(SweetDough), "Sweet Dough", 1, 1044253);
                        AddRes(index, typeof(Banana), "Banana", 6, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(PumpkinBread), 1044497, "Pumpkin Bread", 70.0, 100.0, typeof(SweetDough), "Sweet Dough", 1, 1044253);
                        AddRes(index, typeof(Pumpkin), "Pumpkin", 3, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(CornBread), 1044497, "Corn Bread", 70.0, 100.0, typeof(BagOfCornmeal), "Bag of Cornmeal", 1, 1044253);
                        AddRes(index, typeof(Batter), "Batter", 1, 1044253);
                        AddRes(index, typeof(BagOfSugar), "Bag of Sugar", 1, 1044253);
                        SetNeedOven(index, true);

            

			index = AddCraft( typeof( Cookies ), 1044497, 1025643, 70.0, 100.0, typeof( CookieMix ), 1044474, 1, 1044253 );
			SetNeedOven( index, true );

                        index = AddCraft(typeof(AlmondCookies), 1044497, "Almond Cookies", 70.0, 100.0, typeof(CookieMix), "Cookie Mix", 1, 1044253);
                        AddRes(index, typeof(Almond), "Almond", 12, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(ChocChipCookies), 1044497, "Chocolate Chip Cookies", 70.0, 100.0, typeof(CookieMix), "Cookie Mix", 1, 1044253);
                        AddRes(index, typeof(BagOfCocoa), "Bag of Cocoa", 1, "YUou need a bag of cocoa");
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(GingerSnaps), 1044497, "Ginger Snaps", 70.0, 100.0, typeof(CookieMix), "Cookie Mix", 1, 1044253);
                        AddRes(index, typeof(TanGinger), "Tan Ginger", 12, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(OatmealCookies), 1044497, "Oatmeal Cookies", 70.0, 100.0, typeof(CookieMix), "Cookie Mix", 1, 1044253);
                        AddRes(index, typeof(BagOfOats), "Bag of Oats", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(PeanutButterCookies), 1044497, "Peanut Butter Cookies", 70.0, 100.0, typeof(CookieMix), "Cookie Mix", 1, 1044253);
                        AddRes(index, typeof(PeanutButter), "Peanut Butter", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(PumpkinCookies), 1044497, "Pumpkin Cookies", 70.0, 100.0, typeof(CookieMix), "Cookie Mix", 1, 1044253);
                        AddRes(index, typeof(Pumpkin), "Pumpkin", 6, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

            

			index = AddCraft( typeof( Cake ), 1044497, 1022537, 70.0, 100.0, typeof( CakeMix ), 1044471, 1, 1044253 );
			SetNeedOven( index, true );

                        index = AddCraft(typeof(BananaCake), 1044497, "Banana Cake", 70.0, 100.0, typeof(CakeMix), 1044471, 1, 1044253);
                        AddRes(index, typeof(Banana), "Banana", 4, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(CarrotCake), 1044497, "Carrot Cake", 70.0, 100.0, typeof(CakeMix), 1044471, 1, 1044253);
                        AddRes(index, typeof(Carrot), "Carrot", 6, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(ChocolateCake), 1044497, "Chocolate Cake", 70.0, 100.0, typeof(CakeMix), 1044471, 1, 1044253);
                        AddRes(index, typeof(BagOfCocoa), "Bag of Cocoa", 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(CoconutCake), 1044497, "Coconut Cake", 70.0, 100.0, typeof(CakeMix), 1044471, 1, 1044253);
                        AddRes(index, typeof(Coconut), "Coconut", 2, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(LemonCake), 1044497, "Lemon Cake", 70.0, 100.0, typeof(CakeMix), 1044471, 1, 1044253);
                        AddRes(index, typeof(Lemon), "Lemon", 4, 1044253);
                        SetNeedOven(index, true);

            

			index = AddCraft( typeof( Muffins ), 1044497, 1022539, 70.0, 100.0, typeof( SweetDough ), 1044475, 1, 1044253 );
			SetNeedOven( index, true );

                        index = AddCraft(typeof(BlueberryMuffins), 1044497, "Blueberry Muffins", 70.0, 100.0, typeof(SweetDough), "Sweet Dough", 1, 1044253);
                        AddRes(index, typeof(Blueberry), "Blueberry", 6, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(PumpkinMuffins), 1044497, "Pumpkin Muffins", 70.0, 100.0, typeof(SweetDough), "Sweet Dough", 1, 1044253);
                        AddRes(index, typeof(Pumpkin), "Pumpkin", 2, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(SausagePizza), 1044497, 1044517, 70.0, 100.0, typeof(UncookedSausagePizza), 1044520, 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(CheesePizza), 1044497, 1044516, 70.0, 100.0, typeof(UncookedCheesePizza), 1044521, 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(HamPineapplePizza), 1044497, "Ham and Pineapple Pizza", 70.0, 100.0, typeof(UncookedPizza), "Uncooked Pizza", 1, 1044253);
                        AddRes(index, typeof(RawHamSlices), "Raw Ham Slices", 1, 1044253);
                        AddRes(index, typeof(Pineapple), "Pineapple", 2, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(MushroomOnionPizza), 1044497, "Mushroom and Onion Pizza", 70.0, 100.0, typeof(UncookedPizza), "Uncooked Pizza", 1, 1044253);
                        AddRes(index, typeof(TanMushroom), "Tan Mushrooms", 3, 1044253);
                        AddRes(index, typeof(Onion), "Onion", 3, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(SausOnionMushPizza), 1044497, "Sausage Onion and Mushroom Pizza", 70.0, 100.0, typeof(UncookedPizza), "Uncooked Pizza", 1, 1044253);
                        AddRes(index, typeof(Sausage), "Sausage", 2, 1044253);
                        AddRes(index, typeof(Onion), "Onion", 2, 1044253);
                        AddRes(index, typeof(RedMushroom), "Red Mushrooms", 2, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(TacoPizza), 1044497, "Taco Pizza", 70.0, 100.0, typeof(UncookedPizza), "Uncooked Pizza", 1, 1044253);
                        AddRes(index, typeof(GroundBeef), "Ground Beef", 1, 1044253);
                        AddRes(index, typeof(CheeseWheel), "CheeseWheel", 1, 1044253);
                        AddRes(index, typeof(EnchiladaSauce), "Enchilada Sauce", 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(VeggiePizza), 1044497, "Vegetable Pizza", 70.0, 100.0, typeof(UncookedPizza), "Uncooked Pizza", 1, 1044253);
                        AddRes(index, typeof(MixedVegetables), "Mixed Vegetables", 1, 1044523);
                        SetNeedOven(index, true);

            

                        index = AddCraft(typeof(Quiche), 1044497, 1041345, 70.0, 100.0, typeof(UnbakedQuiche), 1044518, 1, 1044253);
                        SetNeedOven(index, true);

            

                        index = AddCraft(typeof(MeatPie), 1044497, 1041347, 70.0, 100.0, typeof(UnbakedMeatPie), 1044519, 1, 1044253);
                        SetNeedOven(index, true);

            

                        index = AddCraft(typeof(FruitPie), 1044497, 1041346, 70.0, 100.0, typeof(UnbakedFruitPie), 1044522, 1, 1044253);          
                        SetNeedOven(index, true);

     
       
                        index = AddCraft(typeof(PeachCobbler), 1044497, 1041344, 70.0, 100.0, typeof(UnbakedPeachCobbler), 1044523, 1, 1044253);          
                        SetNeedOven(index, true);

            

                        index = AddCraft(typeof(ApplePie), 1044497, 1041343, 70.0, 100.0, typeof(UnbakedApplePie), 1044524, 1, 1044253);           
                        SetNeedOven(index, true);

            

                        index = AddCraft(typeof(PumpkinPie), 1044497, 1041348, 70.0, 100.0, typeof(UnbakedPumpkinPie), 1046461, 1, 1044253);          
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(BlueberryPie), 1044497, "Blueberry Pie", 70.0, 100.0, typeof(PieMix), "Pie Mix", 1, 1044253);
                        AddRes(index, typeof(Blueberry), "Blueberry", 8, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(CherryPie), 1044497, "Cherry Pie", 70.0, 100.0, typeof(PieMix), "Pie Mix", 1, 1044253);
                        AddRes(index, typeof(Cherry), "Cherry", 8, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(KeyLimePie), 1044497, "Key Lime Pie", 70.0, 100.0, typeof(PieMix), "Pie Mix", 1, 1044253);
                        AddRes(index, typeof(Lime), "Lime", 12, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(LemonMerenguePie), 1044497, "Lemon Merengue Pie", 70.0, 100.0, typeof(PieMix), "Pie Mix", 1, 1044253);
                        AddRes(index, typeof(Lemon), "Lemon", 12, 1044253);
                        AddRes(index, typeof(Cream), "Cream", 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(BlackberryCobbler), 1044497, "Blackberry Cobbler", 70.0, 100.0, typeof(PieMix), "Pie Mix", 1, 1044253);
                        AddRes(index, typeof(Blackberry), "Blackberry", 10, 1044253);
                        AddRes(index, typeof(JarHoney), "Honey", 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(ShepherdsPie), 1044497, "Shepherds Pie", 70.0, 100.0, typeof(PieMix), "Pie Mix", 1, 1044253);
                        AddRes(index, typeof(GroundBeef), "Ground Beef", 1, 1044253);
                        AddRes(index, typeof(BowlMashedPotatos), "Bowl of Mashed Potatos", 1, 1044253);
                        AddRes(index, typeof(Corn), "Corn", 2, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(TurkeyPie), 1044497, "Turkey Pie", 70.0, 100.0, typeof(PieMix), "Pie Mix", 1, 1044253);
                        AddRes(index, typeof(SlicedTurkey), "Sliced Turkey", 2, 1044253);
                        AddRes(index, typeof(MixedVegetables), "Mixed Vegetables", 1, 1044253);
                        AddRes(index, typeof(Gravy), "Gravy", 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(ChickenPie), 1044497, "Chicken Pie", 70.0, 100.0, typeof(RawChicken), "Raw Chicken", 1, 1044253);
                        AddRes(index, typeof(PieMix), "Pie Mix", 1, 1044253);
                        AddRes(index, typeof(MixedVegetables), "Mixed Vegetables", 1, 1044253);
                        AddRes(index, typeof(Gravy), "Gravy", 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(BeefPie), 1044497, "Beef Pie", 70.0, 100.0, typeof(GroundBeef), "Ground Beef", 1, 1044253);
                        AddRes(index, typeof(PieMix), "Pie Mix", 1, 1044253);
                        AddRes(index, typeof(MixedVegetables), "Mixed Vegetables", 1, 1044253);
                        AddRes(index, typeof(Gravy), "Gravy", 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(Brownies), 1044497, "Brownies", 70.0, 100.0, typeof(ChocolateMix), "Chocolate Mix", 1, 1044253);
                        AddRes(index, typeof(Eggs), "Eggs", 2, 1044253);
                        AddRes(index, typeof(CookingOil), "Cooking Oil", 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(ChocSunflowerSeeds), 1044497, "Chocolate Sunflower Seeds", 70.0, 100.0, typeof(EdibleSun), "Sunflower Seeds", 1, 1044253);
                        AddRes(index, typeof(BagOfCocoa), "Bag of Cocoa", 1, "you need a bag oc cocoa");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(RiceKrispTreat), 1044497, "RiceKrispTreat", 70.0, 100.0, typeof(BowlRiceKrisps), "Bowl Of Rice Krips", 1, 1044253);
                        AddRes(index, typeof(Butter), "Butter", 1, 1044253);
                        AddRes(index, typeof(BagOfSugar), "Bag of Sugar", 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(BowlOatmeal), 1044497, "Bowl of Oatmeal", 70.0, 100.0, typeof(BagOfOats), "Bag of Oats", 1, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        AddRes(index, typeof(JarHoney), "Honey", 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(Pancakes), 1044497, "Pancakes", 70.0, 100.0, typeof(Batter), "Batter", 1, 1044253);
                        AddRes(index, typeof(JarHoney), "Honey", 1, 1044253);
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(Waffles), 1044497, "Waffles", 70.0, 100.0, typeof(WaffleMix), "Waffle Mix", 1, 1044253);
                        AddRes(index, typeof(JarHoney), "Honey", 1, 1044253);
                        SetNeedOven(index, true);
                        #endregion

                        #region Boiling
                        index = AddCraft(typeof(ChickenNoodleSoup), "Boiling", "Chicken Noodle Soup", 80.0, 100.0, typeof(RoastChicken), 1153506, 1, 1044253);
                        AddRes(index, typeof(PastaNoodles), "Pasta Noodles", 1, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(TomatoRice), "Boiling", "Tomato and Rice", 80.0, 100.0, typeof(Tomato), "Tomato", 3, 1044253);
                        AddRes(index, typeof(BowlRice), "Bowl of Rice", 1, 1044253);
                        AddRes(index, typeof(BasketOfHerbsFarm), "Herbs", 1, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(BowlOfStew), "Boiling", "Beef Stew", 80.0, 100.0, typeof(GroundBeef), "Ground Beef", 1, 1044253);
                        AddRes(index, typeof(Gravy), "Gravy", 1, 1044253);
                        AddRes(index, typeof(BowlCookedVeggies), "Cooked Bowl of Vegetables", 1, 1044253);
                        AddRes(index, typeof(BasketOfHerbsFarm), "Herbs", 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(TomatoSoup), "Boiling", "Tomato Soup", 80.0, 100.0, typeof(Tomato), "Tomato", 5, 1044253);
                        AddRes(index, typeof(BasketOfHerbsFarm), "Herbs", 1, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(HarpyEggSoup), "Boiling", "Harpy Egg Soup", 80.0, 100.0, typeof(HarpyEggs), "Harpy Eggs", 5, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(BowlBeets), "Boiling", "Bowl of Beets", 80.0, 100.0, typeof(Beet), "Beet", 4, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(BowlBroccoli), "Boiling", "Bowl of Broccoli", 80.0, 100.0, typeof(Broccoli), "Broccoli", 4, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(BowlCauliflower), "Boiling", "Bowl of Cauliflower", 80.0, 100.0, typeof(Cauliflower), "Cauliflower", 4, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(BowlGreenBeans), "Boiling", "Bowl of Green Beans", 80.0, 100.0, typeof(GreenBean), "Green Beans", 20, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        AddRes(index, typeof(Bacon), "Bacon", 3, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(BowlRice), "Boiling", "Bowl of Rice", 80.0, 100.0, typeof(BagOfRicemeal), "Bag of Rice", 1, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(BowlSpinach), "Boiling", "Bowl of Spinach", 80.0, 100.0, typeof(Spinach), "Spinach", 8, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        AddRes(index, typeof(Vinegar), "Vinegar", 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(BowlTurnips), "Boiling", "Bowl of Turnips", 80.0, 100.0, typeof(Turnip), "Turnip", 4, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(BowlMashedPotatos), "Boiling", "Bowl of Mashed Potatos", 80.0, 100.0, typeof(Potato), "Potato", 5, 1044253);
                        AddRes(index, typeof(Butter), "Butter", 1, 1044253);
                        AddRes(index, typeof(BaseBeverage), "Milk", 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(BowlCookedVeggies), "Boiling", "Cooked Bowl of Vegetables", 80.0, 100.0, typeof(MixedVegetables), "Mixed Vegetables", 1, 1044253);
                        AddRes(index, typeof(SoySauce), "Soy Sauce", 1, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(WoodenBowlCabbage), "Boiling", "Bowl of Cabbage", 80.0, 100.0, typeof(Cabbage), "Cabbage", 2, 1044253);
                        AddRes(index, typeof(Vinegar), "Vinegar", 1, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(WoodenBowlCarrot), "Boiling", "Bowl of Carrots", 80.0, 100.0, typeof(Carrot), "Carrot", 12, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(WoodenBowlCorn), "Boiling", "Bowl of Corn", 80.0, 100.0, typeof(Corn), "Corn", 3, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(WoodenBowlLettuce), "Boiling", "Bowl of Lettuce", 80.0, 100.0, typeof(Lettuce), "Lettuce", 2, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(WoodenBowlPea), "Boiling", "Bowl of Peas", 80.0, 100.0, typeof(Peas), "Peas", 20, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(PewterBowlOfPotatos), "Boiling", "Bowl of Potatos", 80.0, 100.0, typeof(Potato), "Potato", 5, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(CornOnCob), "Boiling", "Corn on the Cob", 80.0, 100.0, typeof(Corn), "Corn", 1, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        SetNeedCauldron(index, true);

                        index = AddCraft(typeof(Hotdog), "Boiling", "Hotdog", 80.0, 100.0, typeof(GroundPork), "Ground Pork", 1, 1044253);
                        AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
                        AddRes(index, typeof(BreadLoaf), "Bread", 1, 1044253);
                        SetNeedCauldron(index, true);

			index = AddCraft( typeof( MisoSoup ), "Boiling", "Miso Soup", 60.0, 110.0, typeof( RawFishSteak ), 1044476, 1, 1044253 );
			AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );
                        SetNeedCauldron(index, true);

			index = AddCraft( typeof( WhiteMisoSoup ), "Boiling", "White Miso Soup", 60.0, 110.0, typeof( RawFishSteak ), 1044476, 1, 1044253 );
			AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );
                        SetNeedCauldron(index, true);

			index = AddCraft( typeof( RedMisoSoup ), "Boiling", "Red Miso Soup", 60.0, 110.0, typeof( RawFishSteak ), 1044476, 1, 1044253 );
			AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );
                        SetNeedCauldron(index, true);

			index = AddCraft( typeof( AwaseMisoSoup ), "Boiling", "Awase Miso Soup", 60.0, 110.0, typeof( RawFishSteak ), 1044476, 1, 1044253 );
			AddRes( index, typeof( BaseBeverage ), 1046458, 1, 1044253 );
                        SetNeedCauldron(index, true);
                        #endregion

			/* Begin Barbecue */
			index = AddCraft( typeof( FishSteak ), 1044498, 1022427, 0.0, 100.0, typeof( RawFishSteak ), 1044476, 1, 1044253 );
			SetNeedHeat( index, true );
			SetUseAllRes( index, true );

			index = AddCraft( typeof( FriedEggs ), 1044498, 1022486, 0.0, 100.0, typeof( Eggs ), 1044477, 1, 1044253 );
			SetNeedHeat( index, true );
			SetUseAllRes( index, true );
			/* End Barbecue */

                        #region Dinners
                        index = AddCraft(typeof(ChickenParmesian), "Dinners", "Chicken Parmesian", 100.0, 100.0, typeof(RawBird), "Raw Bird", 1, 1044253);
                        AddRes(index, typeof(TomatoSauce), "Tomato Sauce", 1, 1044253);
                        AddRes(index, typeof(CheeseWheel), "Cheese Wheel", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(CheeseEnchilada), "Dinners", "Cheese Enchilada", 100.0, 100.0, typeof(CheeseWheel), "Cheese Wheel", 1, 1044253);
                        AddRes(index, typeof(Tortilla), "Tortilla", 1, 1044253);
                        AddRes(index, typeof(EnchiladaSauce), "Enchilada Sauce", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(ChickenEnchilada), "Dinners", "Chicken Enchilada", 100.0, 100.0, typeof(RawBird), "Raw Bird", 1, 1044253);
                        AddRes(index, typeof(Tortilla), "Tortilla", 1, 1044253);
                        AddRes(index, typeof(EnchiladaSauce), "Enchilada Sauce", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(Lasagna), "Dinners", "Lasagna", 100.0, 100.0, typeof(PastaNoodles), "Pasta Noodles", 3, 1044253);
                        AddRes(index, typeof(GroundBeef), "Ground Beef", 1, 1044253);
                        AddRes(index, typeof(CheeseWheel), "Cheese Wheel", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(LemonChicken), "Dinners", "Lemon Chicken", 100.0, 100.0, typeof(RawBird), "Raw Bird", 1, 1044253);
                        AddRes(index, typeof(Lemon), "Lemon", 1, 1044253);
                        AddRes(index, typeof(BasketOfHerbsFarm), "Herbs", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(OrangeChicken), "Dinners", "Orange Chicken", 100.0, 100.0, typeof(RawBird), "Raw Bird", 1, 1044253);
                        AddRes(index, typeof(Orange), "Orange", 1, 1044253);
                        AddRes(index, typeof(BasketOfHerbsFarm), "Herbs", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(VealParmesian), "Dinners", "Veal Parmesian", 100.0, 100.0, typeof(RawLambLeg), "Raw Lamb Leg", 2, 1044253);
                        AddRes(index, typeof(TomatoSauce), "Tomato Sauce", 1, 1044253);
                        AddRes(index, typeof(CheeseWheel), "Cheese Wheel", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(BeefBBQRibs), "Dinners", "Beef Barbecue Ribs", 100.0, 100.0, typeof(RawRibs), "Raw Ribs", 1, 1044253);
                        AddRes(index, typeof(BarbecueSauce), "Barbecue Sauce", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(BeefBroccoli), "Dinners", "Beef and Broccoli", 100.0, 100.0, typeof(GroundBeef), "Ground Beef", 1, 1044253);
                        AddRes(index, typeof(Broccoli), "Broccoli", 4, 1044253);
                        AddRes(index, typeof(SoySauce), "Soy Sauce", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(ChoChoBeef), "Dinners", "Cho Cho Beef", 100.0, 100.0, typeof(GroundBeef), "Ground Beef", 1, 1044253);
                        AddRes(index, typeof(Teriyaki), "Teriyaki", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(BeefSnowpeas), "Dinners", "Beef and Snow Peas", 100.0, 100.0, typeof(GroundBeef), "Ground Beef", 1, 1044253);
                        AddRes(index, typeof(SnowPeas), "Snow Peas", 4, 1044253);
                        AddRes(index, typeof(SoySauce), "Soy Sauce", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(Hamburger), "Dinners", "Hamburger", 100.0, 100.0, typeof(GroundBeef), "Ground Beef", 1, 1044253);
                        AddRes(index, typeof(BreadLoaf), "Bread", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(BeefLoMein), "Dinners", "Beef Lo Mein", 100.0, 100.0, typeof(GroundBeef), "Ground Beef", 1, 1044253);
                        AddRes(index, typeof(BowlCookedVeggies), "Cooked Mixed Vegetables", 1, 1044253);
                        AddRes(index, typeof(PastaNoodles), "Pasta Noodles", 2, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(BeefStirfry), "Dinners", "Beef Stirfry", 100.0, 100.0, typeof(GroundBeef), "Ground Beef", 1, 1044253);
                        AddRes(index, typeof(BowlCookedVeggies), "Cooked Mixed Vegetables", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(ChickenStirfry), "Dinners", "Chicken Stirfry", 100.0, 100.0, typeof(RawBird), "Raw Bird", 1, 1044253);
                        AddRes(index, typeof(BowlCookedVeggies), "Cooked Mixed Vegetables", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(MooShuPork), "Dinners", "Moo Shu Pork", 100.0, 100.0, typeof(GroundPork), "Ground Pork", 1, 1044253);
                        AddRes(index, typeof(BowlCookedVeggies), "Cooked Mixed Vegetables", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(MoPoTofu), "Dinners", "Mo Po Tofu", 100.0, 100.0, typeof(Tofu), "Tofu", 1, 1044253);
                        AddRes(index, typeof(BowlCookedVeggies), "Cooked Mixed Vegetables", 1, 1044253);
                        AddRes(index, typeof(ChiliPepper), "Chili Pepper", 3, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(PorkStirfry), "Dinners", "Pork Stirfry", 100.0, 100.0, typeof(GroundPork), "Ground Pork", 1, 1044253);
                        AddRes(index, typeof(BowlCookedVeggies), "Cooked Mixed Vegetables", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(SweetSourChicken), "Dinners", "Sweet and Sour Chicken", 100.0, 100.0, typeof(RawBird), "Raw Bird", 1, 1044253);
                        AddRes(index, typeof(JarHoney), "Honey", 1, 1044253);
                        AddRes(index, typeof(SoySauce), "SoySauce", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(SweetSourPork), "Dinners", "Sweet and Sour Pork", 100.0, 100.0, typeof(GroundPork), "Ground Pork", 1, 1044253);
                        AddRes(index, typeof(JarHoney), "Honey", 1, 1044253);
                        AddRes(index, typeof(SoySauce), "SoySauce", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(BaconAndEgg), "Dinners", "Bacon and Eggs", 100.0, 100.0, typeof(Eggs), "Eggs", 2, 1044253);
                        AddRes(index, typeof(RawBacon), "Raw Bacon", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(Spaghetti), "Dinners", "Spaghetti", 100.0, 100.0, typeof(PastaNoodles), "Pasta Noodles", 3, 1044253);
                        AddRes(index, typeof(TomatoSauce), "Tomato Sauce", 1, 1044253);
                        AddRes(index, typeof(GroundBeef), "Ground Beef", 1, 1044253);
                        AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
                        SetNeedOven(index, true);

                        index = AddCraft(typeof(MacaroniCheese), "Dinners", "Macaroni and Cheese", 100.0, 100.0, typeof(PastaNoodles), "Pasta Noodles", 3, 1044253);
                        AddRes(index, typeof(CheeseSauce), "Cheese Sauce", 1, 1044253);
                        SetNeedOven(index, true);
                        #endregion

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