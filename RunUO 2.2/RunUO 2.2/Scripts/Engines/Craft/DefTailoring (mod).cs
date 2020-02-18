using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefTailoring : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Tailoring; }
		}

		public override int GumpTitleNumber
		{
			get { return 1044005; } // <CENTER>TAILORING MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefTailoring();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefTailoring() : base( 1, 1, 1.25 )// base( 1, 1, 4.5 )
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

		public static bool IsNonColorable(Type type)
		{
			for (int i = 0; i < m_TailorNonColorables.Length; ++i)
			{
				if (m_TailorNonColorables[i] == type)
				{
					return true;
				}
			}

			return false;
		}

		private static Type[] m_TailorNonColorables = new Type[]
			{
				typeof( OrcHelm )
			};

		private static Type[] m_TailorColorables = new Type[]
			{
				typeof( GozaMatEastDeed ), typeof( GozaMatSouthDeed ),
				typeof( SquareGozaMatEastDeed ), typeof( SquareGozaMatSouthDeed ),
				typeof( BrocadeGozaMatEastDeed ), typeof( BrocadeGozaMatSouthDeed ),
				typeof( BrocadeSquareGozaMatEastDeed ), typeof( BrocadeSquareGozaMatSouthDeed )
			};

		public override bool RetainsColorFrom( CraftItem item, Type type )
		{
			if ( type != typeof( Cloth ) && type != typeof( UncutCloth ) )
				return false;

			type = item.ItemType;

			bool contains = false;

			for ( int i = 0; !contains && i < m_TailorColorables.Length; ++i )
				contains = ( m_TailorColorables[i] == type );

			return contains;
		}

		public override void PlayCraftEffect( Mobile from )
		{
			from.PlaySound( 0x248 );
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

////////////////////////// Hats and Masks
index = AddCraft( typeof( Bandana ), "Hats and Masks", 1025440, 0.0, 25.0, typeof( Cloth ), 1044286, 2, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 2 light yarn", 2, "Light Yarn" );

index = AddCraft( typeof( BaroqueMask ), "Hats and Masks", "baroque mask", 59.5, 72.9, typeof( Cloth ), 1044286, 15, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 15 dark yarn", 15, "Dark Yarn" );
	AddRes( index, typeof( Feather ), "Requires 5 feathers", 5, "Feather" );

index = AddCraft( typeof( BearMask ), "Hats and Masks", "bear mask", 77.5, 125.0, typeof( Cloth ), 1044286, 15, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 15 dark yarn", 15, "Dark Yarn" );
	AddRes( index, typeof( BearHead ), "Requires 1 bear head", 1, "Bear Head" );

index = AddCraft( typeof( Bonnet ), "Hats and Masks", 1025913, 6.2, 31.2, typeof( Cloth ), 1044286, 11, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 11 light yarn", 11, "Light Yarn" );

index = AddCraft( typeof( Cap ), "Hats and Masks", 1025909, 6.2, 31.2, typeof( Cloth ), 1044286, 11, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 11 light yarn", 11, "Light Yarn" );

index = AddCraft( typeof( ClothNinjaHood ), "Hats and Masks", 1030202, 80.0, 105.0, typeof( Cloth ), 1044286, 13, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 13 dark yarn", 13, "Dark Yarn" );

index = AddCraft( typeof( DeerMask ), "Hats and Masks", "deer mask", 77.5, 125.0, typeof( Cloth ), 1044286, 15, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 15 dark yarn", 15, "Dark Yarn" );
	AddRes( index, typeof( DeerHead ), "Requires 1 deer head", 1, "Deer Head" );

index = AddCraft( typeof( FeatheredHat ), "Hats and Masks", 1025914, 6.2, 31.2, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 12 light yarn", 12, "Light Yarn" );
	AddRes( index, typeof( Feather ), "Requires 1 feather", 1, "Feather" );

index = AddCraft( typeof( FloppyHat ), "Hats and Masks", 1025907, 6.2, 31.2, typeof( Cloth ), 1044286, 11, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 11 light yarn", 11, "Light Yarn" );

index = AddCraft( typeof( JesterHat ), "Hats and Masks", 1025916, 7.2, 32.2, typeof( Cloth ), 1044286, 15, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 15 dark yarn", 15, "Dark Yarn" );

index = AddCraft( typeof( Kasa ), "Hats and Masks", 1030211, 60.0, 85.0, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );	
	AddRes( index, typeof( LightYarn ), "Requires 12 light yarn", 12, "Light Yarn" );

index = AddCraft( typeof( OrcishKinMask ), "Hats and Masks", "orc mask", 75.0, 125.0, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 12 dark yarn", 12, "Dark Yarn" );
	AddRes( index, typeof( OrcHead ), "Requires 1 orc head", 1, "Orc Head" );

index = AddCraft( typeof( SkullCap ), "Hats and Masks", 1025444, 0.0, 25.0, typeof( Cloth ), 1044286, 2, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 2 light yarn", 2, "Light Yarn" );

index = AddCraft( typeof( StrawHat ), "Hats and Masks", 1025911, 6.2, 31.2, typeof( Cloth ), 1044286, 10, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 10 spool of thread", 10, "Spool of Thread" );

index = AddCraft( typeof( TallStrawHat ), "Hats and Masks", 1025910, 6.7, 31.7, typeof( Cloth ), 1044286, 13, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 13 spool of thread", 13, "Spool of Thread" );

index = AddCraft( typeof( TricorneHat ), "Hats and Masks", 1025915, 6.2, 31.2, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 12 dark yarn", 12, "Dark Yarn" );

index = AddCraft( typeof( WideBrimHat ), "Hats and Masks", 1025908, 6.2, 31.2, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 12 light yarn", 12, "Light Yarn" );

index = AddCraft( typeof( WizardsHat ), "Hats and Masks", 1025912, 7.2, 32.2, typeof( Cloth ), 1044286, 15, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 15 dark yarn", 15, "Dark Yarn" );

index = AddCraft( typeof( SavageMask ), "Hats and Masks", "savage mask", 82.5, 125.0, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 12 dark yarn", 12, "Dark Yarn" );

index = AddCraft( typeof( TribalMask ), "Hats and Masks", "tribal mask", 82.5, 125.0, typeof( Cloth ), 1044286, 15, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 15 dark yarn", 15, "Dark Yarn" );

////////////////////////// Bodywear
index = AddCraft( typeof( Cloak ), "Bodywear", 1025397, 41.4, 66.4, typeof( Cloth ), 1044286, 14, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 14 light yarn", 14, "Light Yarn" );

index = AddCraft( typeof( Doublet ), "Bodywear", 1028059, 0, 25.0, typeof( Cloth ), 1044286, 8, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 8 light yarn", 8, "Light Yarn" );

index = AddCraft( typeof( FancyRobe ), "Bodywear", "fancy robe", 65.5, 82.7, typeof( Cloth ), 1044286, 25, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 25 light yarn", 25, "Light Yarn" );

index = AddCraft( typeof( FancyShirt ), "Bodywear", 1027933, 24.8, 49.8, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 12 light yarn", 12, "Light Yarn" );

index = AddCraft( typeof( FancyTunic ), "Bodywear", "fancy tunic", 25.0, 50.0, typeof( Cloth ), 1044286, 14, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 7 dark yarn", 7, "Dark Yarn" );
	AddRes( index, typeof( LightYarn ), "Requires 7 light yarn", 7, "Light Yarn" );

index = AddCraft( typeof( FormalShirt ), "Bodywear", "formal shirt", 29.3, 51.4, typeof( Cloth ), 1044286, 10, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 10 light yarn", 10, "Light Yarn" );

index = AddCraft( typeof( FurCape ), "Bodywear", "fur cape", 43.9, 69.3, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 12 light yarn", 12, "Light Yarn" );

index = AddCraft( typeof( JesterSuit ), "Bodywear", 1028095, 8.2, 33.2, typeof( Cloth ), 1044286, 24, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 12 dark yarn", 12, "Dark Yarn" );
	AddRes( index, typeof( LightYarn ), "Requires 12 light yarn", 12, "Light Yarn" );

index = AddCraft( typeof( PlumeCloak ), "Bodywear", "plume cloak", 51.3, 76.8, typeof( Cloth ), 1044286, 18, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 18 light yarn", 18, "Light Yarn" );
	AddRes( index, typeof( Feather ), "Requires 50 feathers", 50, "Feather" );

index = AddCraft( typeof( RegalCloak ), "Bodywear", "regal cloak", 58.4, 89.9, typeof( Cloth ), 1044286, 16, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 16 light yarn", 16, "Light Yarn" );

index = AddCraft( typeof( ReinassanceShirt ), "Bodywear", "reinassance shirt", 45.5, 55.5, typeof( Cloth ), 1044286, 9, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 5 dark yarn", 5, "Dark Yarn" );
	AddRes( index, typeof( LightYarn ), "Requires 4 light yarn", 4, "Light Yarn" );

index = AddCraft( typeof( Robe ), "Bodywear", 1027939, 53.9, 78.9, typeof( Cloth ), 1044286, 16, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 16 light yarn", 16, "Light Yarn" );

index = AddCraft( typeof( RogueGarb ), "Bodywear", "rogue garb", 35.0, 60.0, typeof( Cloth ), 1044286, 13, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 6 dark yarn", 6, "Dark Yarn" );
	AddRes( index, typeof( LightYarn ), "Requires 7 light yarn", 7, "Light Yarn" );

index = AddCraft( typeof( Shirt ), "Bodywear", 1025399, 20.7, 45.7, typeof( Cloth ), 1044286, 8, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 8 light yarn", 8, "Light Yarn" );

index = AddCraft( typeof( Surcoat ), "Bodywear", 1028189, 8.2, 33.2, typeof( Cloth ), 1044286, 14, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 14 light yarn", 14, "Light Yarn" );

index = AddCraft( typeof( Trenchcoat ), "Bodywear", "trenchcoat", 34.7, 52.7, typeof( Cloth ), 1044286, 20, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 20 dark yarn", 20, "Dark Yarn" );

index = AddCraft( typeof( Tunic ), "Bodywear", "tunic", 0.0, 25.0, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 6 dark yarn", 6, "Dark Yarn" );
	AddRes( index, typeof( LightYarn ), "Requires 6 light yarn", 6, "Light Yarn" );

index = AddCraft( typeof( ClothNinjaJacket ), "Bodywear", 1030207, 75.0, 100.0, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 12 dark yarn", 12, "Dark Yarn" );

index = AddCraft( typeof( HakamaShita ), "Bodywear", 1030215, 40.0, 65.0, typeof( Cloth ), 1044286, 14, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 14 light yarn", 14, "Light Yarn" );

index = AddCraft( typeof( JinBaori ), "Bodywear", 1030220, 30.0, 55.0, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 12 light yarn", 12, "Light Yarn" );

index = AddCraft( typeof( Kamishimo ), "Bodywear", 1030212, 75.0, 100.0, typeof( Cloth ), 1044286, 15, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 15 light yarn", 15, "Light Yarn" );

index = AddCraft( typeof( MaleKimono ), "Bodywear", 1030189, 50.0, 75.0, typeof( Cloth ), 1044286, 16, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 16 light yarn", 16, "Light Yarn" );

index = AddCraft( typeof( FemaleKimono ), "Bodywear", 1030190, 50.0, 75.0, typeof( Cloth ), 1044286, 16, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 16 light yarn", 16, "Light Yarn" );

index = AddCraft( typeof( ElvenDarkShirt ),            "Bodywear", "elven dark shirt", 43.9, 69.3, typeof( Cloth ), 1044286, 10, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 10 dark yarn", 10, "Dark Yarn" );

index = AddCraft( typeof( ElvenShirt ),                "Bodywear", "elven shirt", 24.8, 49.8, typeof( Cloth ), 1044286, 10, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 10 light yarn", 10, "Light Yarn" );


index = AddCraft( typeof( ElvenRobe ),                 "Bodywear", "elven robe", 53.9, 78.9, typeof( Cloth ), 1044286, 30, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 30 light yarn", 30, "Light Yarn" );

index = AddCraft( typeof( FemaleElvenRobe ),           "Bodywear", "female elven robe", 53.9, 78.9, typeof( Cloth ), 1044286, 30, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 10 dark yarn", 10, "Dark Yarn" );

index = AddCraft( typeof( MoonElfFancyRobe ),          "Bodywear", "moon elf fancy robe", 65.5, 82.7, typeof( Cloth ), 1044286, 30, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 10 dark yarn", 10, "Dark Yarn" );

index = AddCraft( typeof( MoonElfShirt ),              "Bodywear", "moon elf shirt", 43.9, 69.3, typeof( Cloth ), 1044286, 10, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 10 dark yarn", 10, "Dark Yarn" );

index = AddCraft( typeof( SunElfFancyRobe ),           "Bodywear", "sun elf fancy robe", 65.5, 82.7, typeof( Cloth ), 1044286, 30, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 30 light yarn", 30, "Light Yarn" );

index = AddCraft( typeof( OnePieceBikini),                "Bodywear", "one-piece bikini", 24.8, 49.8, typeof( Cloth ), 1044286, 7, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 6 light yarn", 6, "Light Yarn" );

index = AddCraft( typeof( TwoPieceBikini),                "Bodywear", "two-piece bikini", 24.8, 49.8, typeof( Cloth ), 1044286, 5, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 5 light yarn", 5, "Light Yarn" );

index = AddCraft( typeof( BaroqueDress ),              "Bodywear", "baroque dress", 59.5, 72.9, typeof( Cloth ), 1044286, 18, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 9 dark yarn", 9, "Dark Yarn" );
	AddRes( index, typeof( LightYarn ), "Requires 9 light yarn", 9, "Light Yarn" );

index = AddCraft( typeof( CitizenDress ),              "Bodywear", "citizen dress", 17.3, 39.6, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 12 light yarn", 12, "Light Yarn" );

index = AddCraft( typeof( CommonerDress ),             "Bodywear", "commoner dress", 14.7, 38.2, typeof( Cloth ), 1044286, 11, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 11 light yarn", 11, "Light Yarn" );

index = AddCraft( typeof( ConfessorDress ),            "Bodywear", "confessor dress", 24.3, 41.4, typeof( Cloth ), 1044286, 13, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 13 light yarn", 13, "Light Yarn" );

index = AddCraft( typeof( DancersGarb ),               "Bodywear", "dancers garb", 52.4, 67.3, typeof( Cloth ), 1044286, 8, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 8 light yarn", 18, "Light Yarn" );

index = AddCraft( typeof( ElegantGown ),               "Bodywear", "elegant gown", 49.6, 69.6, typeof( Cloth ), 1044286, 10, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 10 light yarn", 10, "Light Yarn" );

index = AddCraft( typeof( FancyDress ),                "Bodywear", 1027935, 33.1, 58.1, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 12 light yarn", 12, "Light Yarn" );

index = AddCraft( typeof( FlowerDress ),               "Bodywear", "flower dress", 38.5, 62.5, typeof( Cloth ), 1044286, 15, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 15 light yarn", 15, "Light Yarn" );

index = AddCraft( typeof( FormalDress ),               "Bodywear", "formal dress", 27.6, 50.4, typeof( Cloth ), 1044286, 13, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 13 light yarn", 13, "Light Yarn" );

index = AddCraft( typeof( GildedDress ),               "Bodywear", "gilded dress", 37.2, 61.3, typeof( Cloth ), 1044286, 14, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 14 light yarn", 14, "Light Yarn" );

index = AddCraft( typeof( MaidensDress ),              "Bodywear", "maidens dress", 48.7, 63.4, typeof( Cloth ), 1044286, 16, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 16 light yarn", 16, "Light Yarn" );

index = AddCraft( typeof( MedievalLongDress ),         "Bodywear", "medieval long dress", 52.1, 69.6, typeof( Cloth ), 1044286, 17, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 17 light yarn", 17, "Light Yarn" );

index = AddCraft( typeof( MoonElfPlainDress ),         "Bodywear", "moon elf plain dress", 12.4, 37.4, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 12 light yarn", 12, "Light Yarn" );

index = AddCraft( typeof( NobleDress ),                "Bodywear", "noble dress", 41.1, 64.4, typeof( Cloth ), 1044286, 14, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 14 light yarn", 14, "Light Yarn" );

index = AddCraft( typeof( NocturnalDress ),            "Bodywear", "nocturnal dress", 33.3, 66.6, typeof( Cloth ), 1044286, 14, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 14 light yarn", 14, "Light Yarn" );

index = AddCraft( typeof( PartyDress ),                "Bodywear", "party dress", 45.7, 62.1, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 12 light yarn", 12, "Light Yarn" );

index = AddCraft( typeof( PlainDress ),                "Bodywear", 1027937, 12.4, 37.4, typeof( Cloth ), 1044286, 10, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 10 light yarn", 10, "Light Yarn" );

index = AddCraft( typeof( RaggedDress ),               "Bodywear", "ragged dress", 12.1, 22.3, typeof( Cloth ), 1044286, 7, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 7 light yarn", 7, "Light Yarn" );

index = AddCraft( typeof( ReinassanceDress ),          "Bodywear", "reinassance dress", 56.8, 70.5, typeof( Cloth ), 1044286, 18, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 18 light yarn", 18, "Light Yarn" );

index = AddCraft( typeof( SunElfPlainDress ),          "Bodywear", "sun elf plain dress", 12.4, 37.4, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 12 light yarn", 12, "Light Yarn" );

index = AddCraft( typeof( TheaterDress ),              "Bodywear", "theater dress", 27.4, 43.3, typeof( Cloth ), 1044286, 13, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 13 light yarn", 13, "Light Yarn" );

index = AddCraft( typeof( VictorianDress ),            "Bodywear", "victorian dress", 57.9, 71.6, typeof( Cloth ), 1044286, 17, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 17 light yarn", 17, "Light Yarn" );

index = AddCraft( typeof( ScholarsDress ), "Bodywear", "Scholars Dress", 75.0, 125.0, typeof( BaroqueDress ), "Requires 1 baroque dress", 1, "Baroque Dress" );
	AddRes( index, typeof( Turquoise ), 1032691, 1, 1044240 );

index = AddCraft( typeof( ScholarsRobe ), "Bodywear", "Scholars Robe", 75.0, 125.0, typeof( FancyRobe ), "Requires 1 fancy robe", 1, "Fancy Robe" );
	AddRes( index, typeof( Turquoise ), 1032691, 1, 1044240 );

////////////////////////// Legwear
index = AddCraft( typeof( FancyPants ),                "Legwear", "fancy pants", 60.0, 80.0, typeof( Cloth ), 1044286, 9, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 9 light yarn", 9, "Light Yarn" );

index = AddCraft( typeof( FurSarong ),                 "Legwear", "fur sarong", 34.2, 57.7, typeof( Cloth ), 1044286, 8, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 8 light yarn", 8, "Light Yarn" );

index = AddCraft( typeof( LongPants ),                 "Legwear", 1025433, 24.8, 49.8, typeof( Cloth ), 1044286, 8, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 8 light yarn", 8, "Light Yarn" );

index = AddCraft( typeof( ReinassancePants ),          "Legwear", "reinassance pants", 45.5, 55.5, typeof( Cloth ), 1044286, 10, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 5 dark yarn", 5, "Dark Yarn" );
	AddRes( index, typeof( LightYarn ), "Requires 5 light yarn", 5, "Light Yarn" );

index = AddCraft( typeof( ShortPants ),                "Legwear", 1025422, 24.8, 49.8, typeof( Cloth ), 1044286, 6, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 6 light yarn", 6, "Light Yarn" );

index = AddCraft( typeof( Kilt ),                      "Legwear", 1025431, 20.7, 45.7, typeof( Cloth ), 1044286, 8, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 8 light yarn", 8, "Light Yarn" );

index = AddCraft( typeof( Skirt ),                     "Legwear", 1025398, 29.0, 54.0, typeof( Cloth ), 1044286, 10, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 10 light yarn", 10, "Light Yarn" );

index = AddCraft( typeof( ElvenPants ),                "Legwear", "elven pants", 80.0, 125.0, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 12 light yarn", 12, "Light Yarn" );

index = AddCraft( typeof( MoonElfSkirt ),              "Legwear", "moon elf skirt", 50.0, 90.0, typeof( Cloth ), 1044286, 12, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 12 dark yarn", 12, "Dark Yarn" );

index = AddCraft( typeof( Hakama ),                    "Legwear", 1030213, 50.0, 75.0, typeof( Cloth ), 1044286, 16, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 16 light yarn", 16, "Light Yarn" );

index = AddCraft( typeof( TattsukeHakama ),            "Legwear", 1030214, 50.0, 75.0, typeof( Cloth ), 1044286, 16, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( DarkYarn ), "Requires 16 dark yarn", 16, "Dark Yarn" );

index = AddCraft( typeof( Boxers ),              "Legwear", "boxer", 50.0, 90.0, typeof( Cloth ), 1044286, 4, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 9 light yarn", 9, "Light Yarn" );

index = AddCraft( typeof( Panties ),              "Legwear", "panties", 50.0, 90.0, typeof( Cloth ), 1044286, 2, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 8 light yarn", 8, "Light Yarn" );

////////////////////////// Misc
index = AddCraft( typeof( BodySash ),                  "Misc", 1025441, 4.1, 29.1, typeof( Cloth ), 1044286, 4, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 4 light yarn", 4, "Light Yarn" );

index = AddCraft( typeof( HalfApron ),                 "Misc", 1025435, 20.7, 45.7, typeof( Cloth ), 1044286, 6, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 6 light yarn", 6, "Light Yarn" );

index = AddCraft( typeof( FullApron ),                 "Misc", 1025437, 29.0, 54.0, typeof( Cloth ), 1044286, 10, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 10 light yarn", 10, "Light Yarn" );

index = AddCraft( typeof( Obi ),                       "Misc", 1030219, 20.0, 45.0, typeof( Cloth ), 1044286, 6, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 6 light yarn", 6, "Light Yarn" );

index = AddCraft( typeof( ElvenQuiver ),               "Misc", 1032657, 65.0, 115.0, typeof( Leather ), 1044462, 28, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 28 light yarn", 28, "Light Yarn" );

index = AddCraft( typeof( QuiverOfBlight ), "Misc", 1073111, 65.0, 115.0, typeof( Leather ), 1044462, 28, 1044463 );
	AddRes( index, typeof( Blight ), 1032675, 10, 1042081 );

index = AddCraft( typeof( QuiverOfFire ), "Misc", 1073109, 65.0, 115.0, typeof( Leather ), 1044462, 28, 1044463 );
	AddRes( index, typeof( FireRuby ), 1032695, 15, 1042081 );

index = AddCraft( typeof( QuiverOfIce ), "Misc", 1073110, 65.0, 115.0, typeof( Leather ), 1044462, 28, 1044463 );
	AddRes( index, typeof( WhitePearl ), 1032694, 15, 1042081 );

index = AddCraft( typeof( QuiverOfLightning ), "Misc", 1073112, 65.0, 115.0, typeof( Leather ), 1044462, 28, 1044463 );
	AddRes( index, typeof( Corruption ), 1032676, 10, 1042081 );

			AddCraft( typeof( OilCloth ),                  "Misc", 1041498, 74.6, 99.6, typeof( Cloth ), 1044286, 1, 1044287 );

			AddCraft( typeof( GozaMatEastDeed ),           "Misc", 1030404, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );

			AddCraft( typeof( GozaMatSouthDeed ),          "Misc", 1030405, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
			AddCraft( typeof( SquareGozaMatEastDeed ),     "Misc", 1030407, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
			AddCraft( typeof( SquareGozaMatSouthDeed ),    "Misc", 1030406, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
			AddCraft( typeof( BrocadeGozaMatEastDeed ),    "Misc", 1030408, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
			AddCraft( typeof( BrocadeGozaMatSouthDeed ),   "Misc", 1030409, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
			AddCraft( typeof( BrocadeSquareGozaMatEastDeed ), "Misc", 1030411, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );
			AddCraft( typeof( BrocadeSquareGozaMatSouthDeed ), "Misc", 1030410, 55.0, 80.0, typeof( Cloth ), 1044286, 25, 1044287 );

index = AddCraft( typeof( WoodlandBelt ),              "Misc", "woodland belt", 80.0, 125.0, typeof( Leather ), 1044462, 10, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( LightYarn ), "Requires 10 light yarn", 10, "Light Yarn" );

////////////////////////// Footwear
index = AddCraft( typeof( Boots ), "Footwear", 1025899, 33.1, 58.1, typeof( Leather ), 1044462, 8, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );	
	AddRes( index, typeof( LightYarn ), "Requires 8 light yarn", 8, "Light Yarn" );

index = AddCraft( typeof( ElvenBoots ), "Footwear", "elven boots", 80.0, 125.0, typeof( Leather ), 1044462, 15, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );	
	AddRes( index, typeof( LightYarn ), "Requires 15 light yarn", 15, "Light Yarn" );

index = AddCraft( typeof( FurBoots ), "Footwear", "fur boots", 43.6, 62.0, typeof( Leather ), 1044462, 10, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );	
	AddRes( index, typeof( LightYarn ), "Requires 10 light yarn", 10, "Light Yarn" );

index = AddCraft( typeof( HeavyBoots ), "Footwear", "heavy boots", 57.8, 73.7, typeof( Leather ), 1044462, 18, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );	
	AddRes( index, typeof( LightYarn ), "Requires 18 light yarn", 18, "Light Yarn" );

index = AddCraft( typeof( HighBoots ), "Footwear", "high boots", 43.1, 56.2, typeof( Leather ), 1044462, 14, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );	
	AddRes( index, typeof( LightYarn ), "Requires 14 light yarn", 14, "Light Yarn" );

index = AddCraft( typeof( LightBoots ), "Footwear", "light boots", 31.6, 52.4, typeof( Leather ), 1044462, 6, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );	
	AddRes( index, typeof( LightYarn ), "Requires 6 light yarn", 6, "Light Yarn" );

index = AddCraft( typeof( NinjaTabi ), "Footwear", 1030210, 70.0, 95.0, typeof( Cloth ), 1044286, 10, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );	
	AddRes( index, typeof( DarkYarn ), "Requires 10 dark yarn", 10, "Dark Yarn" );

index = AddCraft( typeof( SamuraiTabi ), "Footwear", 1030209, 20.0, 45.0, typeof( Cloth ), 1044286, 6, 1044287 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );	
	AddRes( index, typeof( DarkYarn ), "Requires 6 dark yarn", 6, "Dark Yarn" );

index = AddCraft( typeof( Sandals ), "Footwear", 1025901, 12.4, 37.4, typeof( Leather ), 1044462, 4, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );	
	AddRes( index, typeof( LightYarn ), "Requires 4 light yarn", 4, "Light Yarn" );

index = AddCraft( typeof( Shoes ), "Footwear", 1025904, 16.5, 41.5, typeof( Leather ), 1044462, 6, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );	
	AddRes( index, typeof( LightYarn ), "Requires 6 light yarn", 6, "Light Yarn" );

index = AddCraft( typeof( ShortBoots ), "Footwear", "short boots", 17.4, 36.7, typeof( Leather ), 1044462, 7, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );	
	AddRes( index, typeof( LightYarn ), "Requires 7 light yarn", 7, "Light Yarn" );

index = AddCraft( typeof( ThighBoots ), "Footwear", 1025906, 41.4, 66.4, typeof( Leather ), 1044462, 10, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );	
	AddRes( index, typeof( DarkYarn ), "Requires 10 dark yarn", 10, "Dark Yarn" );

////////////////////////// Armor
index = AddCraft( typeof( LeatherArms ), "Armor", 1025061, 53.9, 78.9, typeof( Leather ), 1044462, 4, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeatherCap ), "Armor", 1027609, 6.2, 31.2, typeof( Leather ), 1044462, 2, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeatherChest ), "Armor", 1025068, 70.5, 95.5, typeof( Leather ), 1044462, 12, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeatherGloves ), "Armor", 1025062, 51.8, 76.8, typeof( Leather ), 1044462, 3, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeatherGorget ), "Armor", 1025063, 53.9, 78.9, typeof( Leather ), 1044462, 4, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeatherLegs ), "Armor", 1025067, 66.3, 91.3, typeof( Leather ), 1044462, 10, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeatherDo ), "Armor", 1030182, 75.0, 100.0, typeof( Leather ), 1044462, 12, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( LeatherHaidate ), "Armor", 1030197, 68.0, 93.0, typeof( Leather ), 1044462, 12, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeatherHiroSode ), "Armor", 1030185, 55.0, 80.0, typeof( Leather ), 1044462, 5, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( LeatherJingasa ), "Armor", 1030177, 45.0, 70.0, typeof( Leather ), 1044462, 4, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeatherMempo ), "Armor", 1030181, 80.0, 105.0, typeof( Leather ), 1044462, 8, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( LeatherNinjaBelt ), "Armor", 1030203, 50.0, 75.0, typeof( Leather ), 1044462, 5, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeatherNinjaHood ), "Armor", 1030201, 90.0, 115.0, typeof( Leather ), 1044462, 14, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeatherNinjaJacket ), "Armor", 1030206, 85.0, 110.0, typeof( Leather ), 1044462, 13, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeatherNinjaMitts ), "Armor", 1030205, 65.0, 90.0, typeof( Leather ), 1044462, 12, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeatherNinjaPants ), "Armor", 1030204, 80.0, 105.0, typeof( Leather ), 1044462, 13, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeatherSuneate ), "Armor", 1030193, 68.0, 93.0, typeof( Leather ), 1044462, 12, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LeafArms ), "Armor", "leaf arms", 60.0, 100.0, typeof( Leather ), 1044462, 12, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( LeafChest ), "Armor", "leaf chest", 75.0, 100.0, typeof( Leather ), 1044462, 15, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( LeafGloves ), "Armor", "leaf gloves", 60.0, 100.0, typeof( Leather ), 1044462, 10, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( LeafGorget ), "Armor", "leaf gorget", 65.0, 100.0, typeof( Leather ), 1044462, 12, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( LeafLegs ), "Armor", "leaf legs", 75.0, 100.0, typeof( Leather ), 1044462, 15, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( LeafTonlet ), "Armor", "leaf tonlet", 70.0, 100.0, typeof( Leather ), 1044462, 12, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( ElvenShield ), "Armor", "elven shield", 65.0, 100.0, typeof( Leather ), 1044462, 16, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 10 spools of thread", 10, "Spool of Thread" );

index = AddCraft( typeof( GrassShield ), "Armor", "grass shield", 75.0, 100.0, typeof( Leather ), 1044462, 18, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 10 spools of thread", 10, "Spool of Thread" );

index = AddCraft( typeof( NymphShield ), "Armor", "nymph shield", 60.0, 100.0, typeof( Leather ), 1044462, 15, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 10 spools of thread", 10, "Spool of Thread" );

index = AddCraft( typeof( StuddedArms ), "Armor", 1025076, 87.1, 112.1, typeof( Leather ), 1044462, 10, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( StuddedChest ), "Armor", 1025083, 94.0, 119.0, typeof( Leather ), 1044462, 14, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( StuddedGloves ), "Armor", 1025077, 82.9, 107.9, typeof( Leather ), 1044462, 8, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( StuddedGorget ), "Armor", 1025078, 78.8, 103.8, typeof( Leather ), 1044462, 6, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( StuddedLegs ), "Armor", 1025082, 91.2, 116.2, typeof( Leather ), 1044462, 12, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( StuddedDo ), "Armor", 1030183, 95.0, 120.0, typeof( Leather ), 1044462, 14, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( StuddedHaidate ), "Armor", 1030198, 92.0, 117.0, typeof( Leather ), 1044462, 14, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( StuddedHiroSode ), "Armor", 1030186, 85.0, 110.0, typeof( Leather ), 1044462, 8, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( StuddedMempo ), "Armor", 1030216, 80.0, 105.0, typeof( Leather ), 1044462, 8, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( StuddedSuneate ), "Armor", 1030194, 92.0, 117.0, typeof( Leather ), 1044462, 14, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( HideChest ), "Armor", "hide chest", 85.0, 125.0, typeof( Leather ), 1044462, 15, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( HideGloves ), "Armor", "hide gloves", 75.0, 125.0, typeof( Leather ), 1044462, 10, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( HideGorget ), "Armor", "hide gorget", 90.0, 125.0, typeof( Leather ), 1044462, 12, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( HidePants ), "Armor", "hide pants", 92.0, 125.0, typeof( Leather ), 1044462, 15, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( HidePauldrons ), "Armor", "hide pauldrons", 75.0, 125.0, typeof( Leather ), 1044462, 12, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( BoneHelm ), "Armor", 1025206, 85.0, 110.0, typeof( Leather ), 1044462, 4, 1044463 );
	AddRes( index, typeof( Bone ), 1049064, 2, 1049063 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( BoneGloves ), "Armor", 1025205, 89.0, 114.0, typeof( Leather ), 1044462, 6, 1044463 );
	AddRes( index, typeof( Bone ), 1049064, 2, 1049063 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( BoneArms ), "Armor", 1025203, 92.0, 117.0, typeof( Leather ), 1044462, 8, 1044463 );
	AddRes( index, typeof( Bone ), 1049064, 4, 1049063 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( BoneLegs ), "Armor", 1025202, 95.0, 120.0, typeof( Leather ), 1044462, 10, 1044463 );
	AddRes( index, typeof( Bone ), 1049064, 6, 1049063 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( BoneChest ), "Armor", 1025199, 96.0, 121.0, typeof( Leather ), 1044462, 12, 1044463 );
	AddRes( index, typeof( Bone ), 1049064, 10, 1049063 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( OrcHelm ), "Armor", 1027947, 90.0, 115.0, typeof( Leather ), 1044462, 6, 1044463 );
	AddRes( index, typeof( Bone ), 1049064, 4, 1049063 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft(typeof( BoneShield ), "Armor", "bone shield", 94.0, 115.0, typeof( Leather ), 1044462, 15, 1044463 );
	AddRes( index, typeof( Bone ), 1049064, 10, 1049063 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

////////////////////////// Female Armor
index = AddCraft( typeof( LeatherShorts ), "Female Armor", 1027168, 62.2, 87.2, typeof( Leather ), 1044462, 8, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( LeatherSkirt ), "Female Armor", 1027176, 58.0, 83.0, typeof( Leather ), 1044462, 6, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( LeatherBustierArms ), "Female Armor", 1027178, 58.0, 83.0, typeof( Leather ), 1044462, 6, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( StuddedBustierArms ), "Female Armor", 1027180, 82.9, 107.9, typeof( Leather ), 1044462, 8, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( FemaleLeatherChest ), "Female Armor", 1027174, 62.2, 87.2, typeof( Leather ), 1044462, 8, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( FemaleStuddedChest ), "Female Armor", 1027170, 87.1, 112.1, typeof( Leather ), 1044462, 10, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( FemaleLeafChest ), "Female Armor", "female leaf chest", 75.0, 100.0, typeof( Leather ), 1044462, 15, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );

index = AddCraft( typeof( HideFemaleChest ), "Female Armor", "hide female chest", 85.0, 125.0, typeof( Leather ), 1044462, 15, 1044463 );
	AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );


                        index= AddCraft( typeof( RunicSpinedLeather ), "Runic Sewing Kits", "Runic Spined Leather", 70.0, 150.0, typeof( SpinedLeather ), 1044462, 5);
                        index= AddCraft( typeof( RunicHornedLeather ), "Runic Sewing Kits", "Runic Horned Leather", 85.0, 150.0, typeof( HornedLeather ), 1044462, 5);
                        index= AddCraft( typeof( RunicBarbedLeather ), "Runic Sewing Kits", "Runic Barbed Leather", 100.0, 150.0, typeof( BarbedLeather ), 1044462, 5);

			// Set the overridable material
			SetSubRes( typeof( Leather ), 1049150 );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes( typeof( Leather ),		1049150, 00.0, 1044462, 1049311 );
			AddSubRes( typeof( SpinedLeather ),	1049151, 65.0, 1044462, 1049311 );
			AddSubRes( typeof( HornedLeather ),	1049152, 80.0, 1044462, 1049311 );
			AddSubRes( typeof( BarbedLeather ),	1049153, 99.0, 1044462, 1049311 );

			MarkOption = true;
			Repair = Core.AOS;
			CanEnhance = Core.AOS;
		}
	}
}