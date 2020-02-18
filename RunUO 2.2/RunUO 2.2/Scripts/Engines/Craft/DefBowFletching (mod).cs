using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefBowFletching : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Fletching; }
		}

		public override int GumpTitleNumber
		{
			get { return 1044006; } // <CENTER>BOWCRAFT AND FLETCHING MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefBowFletching();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefBowFletching() : base( 1, 1, 1.25 )// base( 1, 2, 1.7 )
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
			// no animation
			//if ( from.Body.Type == BodyType.Human && !from.Mounted )
			//	from.Animate( 33, 5, 1, true, false, 0 );

			from.PlaySound( 0x55 );
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

		public override CraftECA ECA{ get{ return CraftECA.FiftyPercentChanceMinusTenPercent; } }

		public override void InitCraftList()
		{
			int index = -1;

                        // Materials
			AddCraft( typeof( Kindling ),               "Materials", 1023553, 0.0, 00.0, typeof( Log ), 1044041, 1, 1044351 );

			index = AddCraft( typeof( BarkFragment ),   "Materials", "bark fragment", 0.0, 00.0, typeof( Kindling ), "Requires kindling", 1, "Kindling" );
			SetUseAllRes( index, true );

			index = AddCraft( typeof( Shaft ),          "Materials", 1027124, 0.0, 40.0, typeof( Kindling ), 1044041, 1, 1027124 );
			SetUseAllRes( index, true );

                        // Arrows
			index = AddCraft( typeof( Arrow ),          "Arrows", 1023903, 0.0, 40.0, typeof( Shaft ), 1044560, 1, 1044561 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );

			index = AddCraft( typeof( OakArrow ),        "Arrows", "oak arrow", 20.0, 90.7, typeof( OakLog ), "oak logs or boards", 1, 1044351 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );
			
			index = AddCraft( typeof( AshArrow ),         "Arrows", "ash arrow", 30.0, 94.4, typeof( AshLog ), "ash logs or boards", 1, 1044351 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );
			
			index = AddCraft( typeof( YewArrow ),         "Arrows", "yew arrow", 40.0, 99.9, typeof( YewLog ), "yew logs or boards", 1, 1044351 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );
			
			index = AddCraft( typeof( HeartwoodArrow ),    "Arrows", "heartwood arrow", 50.0, 102.3, typeof( HeartwoodLog ), "heartwood logs or boards", 1, 1044351 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );
			
			index = AddCraft( typeof( BloodwoodArrow ),    "Arrows", "bloodwood arrow", 60.0, 106.7, typeof( BloodwoodLog ), "bloodwood logs or boards", 1, 1044351 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );
			
			index = AddCraft( typeof( FrostwoodArrow ),    "Arrows", "frostwood arrow", 70.0, 110.0, typeof( FrostwoodLog ), "frostwood logs or boards", 1, 1044351 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );

                        // Bolts
			index = AddCraft( typeof( Bolt ),              "Bolts", 1027163, 0.0, 40.0, typeof( Shaft ), 1044560, 1, 1044561 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );

			index = AddCraft( typeof( DullCopperBolt ),     "Bolts", "dull copper bolt", 20.0, 100.0, typeof( DullCopperIngot ), "dull copper ingot", 1, 1044037 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );
			
			index = AddCraft( typeof( ShadowIronBolt ),     "Bolts", "shadow iron bolt", 30.0, 102.0, typeof( ShadowIronIngot ), "shadow iron ingot", 1, 1044037 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );
			
			index = AddCraft( typeof( CopperBolt ),         "Bolts", "copper bolt", 40.0, 104.0, typeof( CopperIngot ), "copper ingot", 1, 1044037 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );
			
			index = AddCraft( typeof( BronzeBolt ),         "Bolts", "bronze bolt", 50.0, 106.0, typeof( BronzeIngot ), "bronze ingot", 1, 1044037 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );
			
			index = AddCraft( typeof( GoldBolt ),           "Bolts", "gold bolt", 60.0, 107.0, typeof( GoldIngot ), "gold ingot", 1, 1044037 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );
			
			index = AddCraft( typeof( AgapiteBolt ),        "Bolts", "agapite bolt", 70.0, 109.0, typeof( AgapiteIngot ), "agapite ingot", 1, 1044037 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );
			
			index = AddCraft( typeof( VeriteBolt ),         "Bolts", "verite bolt", 80.0, 110.0, typeof( VeriteIngot ), "verite ingot", 1, 1044037 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );
			
			index = AddCraft( typeof( ValoriteBolt ),        "Bolts", "valorite bolt", 90.0, 112.0, typeof( ValoriteIngot ), "valorite ingot", 1, 1044037 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );

                        // Ammunition
			index = AddCraft( typeof( FukiyaDarts ),    "Ammunition", 1030246, 50.0, 90.0, typeof( Shaft ), 1044560, 1, 1044561 );
			AddRes( index, typeof( Feather ), 1044562, 1, 1044563 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			SetUseAllRes( index, true );

                        // Bows (Lv.1)
			index = AddCraft( typeof( Bow ), "Bows", "bow - (lv.1)", 5.0, 25.0, typeof( Log ), 1044041, 7, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 3 regular leather", 3, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
			AddRes( index, typeof( IronWire ), "Requires 1 iron wire", 1, "Iron Wire" );

			index = AddCraft( typeof( Crossbow ), "Bows", "crossbow - (lv.1)", 5.0, 25.0, typeof( Log ), 1044041, 7, 1044351 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
			AddRes( index, typeof( Gears ), "Requires 4 gears", 4, "Gears" );
			AddRes( index, typeof( Springs ), "Requires 2 springs", 2, "Springs" );
			AddRes( index, typeof( IronWire ), "Requires 1 iron wire", 1, "Iron Wire" );
			AddRes( index, typeof( CopperWire ), "Requires 1 copper wire", 1, "Copper Wire" );

                        // Bows (Lv.5)
			index = AddCraft( typeof( Balestra ), "Bows", "balestra - (lv.5)", 10.0, 30.0, typeof( Log ), 1044041, 7, 1044351 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
			AddRes( index, typeof( Gears ), "Requires 3 gears", 3, "Gears" );
			AddRes( index, typeof( Springs ), "Requires 2 springs", 2, "Springs" );
			AddRes( index, typeof( IronWire ), "Requires 1 iron wire", 1, "Iron Wire" );
			AddRes( index, typeof( CopperWire ), "Requires 1 copper wire", 1, "Copper Wire" );

			index = AddCraft( typeof( ElvenLeafBow ), "Bows", "elven leaf bow - (lv.5)", 10.0, 30.0, typeof( Log ), 1044041, 7, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 3 regular leather", 3, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
			AddRes( index, typeof( IronWire ), "Requires 1 iron wire", 1, "Iron Wire" );
			AddRes( index, typeof( BarkFragment ), "Requires 5 bark fragment", 5, "Bark Fragment" );

                        // Bows (Lv.10)
			index = AddCraft( typeof( MagicalShortbow ), "Bows", "magical shortbow - (lv.10)", 15.0, 35.0, typeof( Log ), 1044041, 15, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 3 regular leather", 3, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
			AddRes( index, typeof( SilverWire ), "Requires 1 silver wire", 1, "Silver Wire" );

			index = AddCraft( typeof( RepeatingCrossbow ), "Bows", "repeating crossbow - (lv.10)", 15.0, 35.0, typeof( Log ), 1044041, 10, 1044351 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 6 spools of thread", 6, "Spool of Thread" );
			AddRes( index, typeof( Gears ), "Requires 5 gears", 5, "Gears" );
			AddRes( index, typeof( Springs ), "Requires 3 springs", 3, "Springs" );
			AddRes( index, typeof( IronWire ), "Requires 1 iron wire", 1, "Iron Wire" );
			AddRes( index, typeof( CopperWire ), "Requires 2 copper wires", 2, "Copper Wire" );

                        // Bows (Lv.20)
			index = AddCraft( typeof( CompositeBow ), "Bows", "composite bow - (lv.20)", 20.0, 40.0, typeof( Log ), 1044041, 7, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 5 regular leather", 5, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 6 spools of thread", 6, "Spool of Thread" );
			AddRes( index, typeof( IronWire ), "Requires 2 iron wires", 2, "Iron Wire" );

			index = AddCraft( typeof( EbonyCrossbow ), "Bows", "ebony crossbow - (lv.20)", 20.0, 40.0, typeof( Log ), 1044041, 7, 1044351 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
			AddRes( index, typeof( Gears ), "Requires 4 gears", 4, "Gears" );
			AddRes( index, typeof( Springs ), "Requires 2 springs", 2, "Springs" );
			AddRes( index, typeof( IronWire ), "Requires 1 iron wire", 1, "Iron Wire" );
			AddRes( index, typeof( CopperWire ), "Requires 1 copper wire", 1, "Copper Wire" );

                        // Bows (Lv.25)
			index = AddCraft( typeof( FireBow ), "Bows", "fire bow - (lv.25)", 25.0, 45.0, typeof( Log ), 1044041, 15, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 3 regular leather", 3, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
			AddRes( index, typeof( SilverWire ), "Requires 1 silver wire", 1, "Silver Wire" );
			AddRes( index, typeof( FireOpal ), "Requires 1 fire opal", 1, "Fire Opal" );

			index = AddCraft( typeof( GrassBow ), "Bows", "grass bow - (lv.25)", 25.0, 45.0, typeof( Log ), 1044041, 15, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 3 regular leather", 3, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
			AddRes( index, typeof( SilverWire ), "Requires 1 silver wire", 1, "Silver Wire" );
			AddRes( index, typeof( Beryl ), "Requires 1 beryl", 1, "Beryl" );

			index = AddCraft( typeof( IceBow ), "Bows", "ice bow - (lv.25)", 25.0, 45.0, typeof( Log ), 1044041, 15, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 3 regular leather", 3, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
			AddRes( index, typeof( SilverWire ), "Requires 1 silver wire", 1, "Silver Wire" );
			AddRes( index, typeof( Opal ), "Requires 1 opal", 1, "Opal" );

			index = AddCraft( typeof( LightningBow ), "Bows", "lightning bow - (lv.25)", 25.0, 45.0, typeof( Log ), 1044041, 15, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 3 regular leather", 3, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 5 spools of thread", 5, "Spool of Thread" );
			AddRes( index, typeof( SilverWire ), "Requires 1 silver wire", 1, "Silver Wire" );
			AddRes( index, typeof( TurquoiseCustom ), "Requires 1 turquoise", 1, "Turquoise" );

                        // Bows (Lv.30)
			index = AddCraft( typeof( EbonyWarBow ), "Bows", "ebony warbow - (lv.30)", 30.0, 50.0, typeof( Log ), 1044041, 10, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 6 regular leather", 6, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 7 spools of thread", 7, "Spool of Thread" );
			AddRes( index, typeof( GoldWire ), "Requires 2 gold wires", 2, "Gold Wire" );

			index = AddCraft( typeof( PistolCrossbow ), "Bows", "pistol crossbow - (lv.30)", 30.0, 50.0, typeof( Log ), 1044041, 7, 1044351 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
			AddRes( index, typeof( Gears ), "Requires 4 gears", 4, "Gears" );
			AddRes( index, typeof( Springs ), "Requires 2 springs", 2, "Springs" );
			AddRes( index, typeof( IronWire ), "Requires 1 iron wire", 1, "Iron Wire" );
			AddRes( index, typeof( CopperWire ), "Requires 1 copper wire", 1, "Copper Wire" );

                        // Bows (Lv.40)
			index = AddCraft( typeof( ElvenCompositeLongbow ), "Bows", "elven composite longbow - (lv.40)", 40.0, 60.0, typeof( Log ), 1044041, 20, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 5 regular leather", 5, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 8 spools of thread", 8, "Spool of Thread" );
			AddRes( index, typeof( SilverWire ), "Requires 2 silver wires", 2, "Silver Wire" );

			index = AddCraft( typeof( ReinforcedCrossbow ), "Bows", "reinforced crossbow - (lv.40)", 40.0, 60.0, typeof( Log ), 1044041, 7, 1044351 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
			AddRes( index, typeof( Gears ), "Requires 4 gears", 4, "Gears" );
			AddRes( index, typeof( Springs ), "Requires 2 springs", 2, "Springs" );
			AddRes( index, typeof( IronWire ), "Requires 1 iron wire", 1, "Iron Wire" );
			AddRes( index, typeof( CopperWire ), "Requires 1 copper wire", 1, "Copper Wire" );

                        // Bows (Lv.50)
			index = AddCraft( typeof( EbonyGreatBow ), "Bows", "ebony greatbow - (lv.50)", 50.0, 70.0, typeof( Log ), 1044041, 10, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 6 regular leather", 6, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 8 spools of thread", 8, "Spool of Thread" );
			AddRes( index, typeof( SilverWire ), "Requires 2 silver wires", 2, "Silver Wire" );

			index = AddCraft( typeof( HeavyCrossbow ), "Bows", "heavy crossbow - (lv.50)", 50.0, 70.0, typeof( Log ), 1044041, 10, 1044351 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 9 spools of thread", 9, "Spool of Thread" );
			AddRes( index, typeof( Gears ), "Requires 6 gears", 6, "Gears" );
			AddRes( index, typeof( Springs ), "Requires 5 springs", 5, "Springs" );
			AddRes( index, typeof( IronWire ), "Requires 2 iron wire", 2, "Iron Wire" );
			AddRes( index, typeof( CopperWire ), "Requires 1 copper wire", 1, "Copper Wire" );

                        // Bows (Lv.60)
			index = AddCraft( typeof( GreatLongbow ), "Bows", "great longbow - (lv.60)", 60.0, 80.0, typeof( Log ), 1044041, 10, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 6 regular leather", 6, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 8 spools of thread", 8, "Spool of Thread" );
			AddRes( index, typeof( SilverWire ), "Requires 2 silver wires", 2, "Silver Wire" );

                        // Bows (Lv.70)
			index = AddCraft( typeof( SkeletalWarBow ), "Bows", "skeletal war bow - (lv.70)", 70.0, 90.0, typeof( Log ), 1044041, 10, 1044351 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 7 spools of thread", 7, "Spool of Thread" );
			AddRes( index, typeof( SilverWire ), "Requires 1 silver wire", 1, "Silver Wire" );
			AddRes( index, typeof( RibCage ), "Requires 1 rib cage", 1, "Ribcage" );
			AddRes( index, typeof( Bone ), 1049064, 25, 1049063 );

                        // Bows (Lv.75)
			index = AddCraft( typeof( Yumi ), "Bows", "yumi - (lv.75)", 70.0, 95.0, typeof( Log ), 1044041, 10, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 7 regular leather", 7, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 10 spools of thread", 10, "Spool of Thread" );
			AddRes( index, typeof( SilverWire ), "Requires 1 silver wire", 1, "Silver Wire" );

                        // Bows (Lv.80)
			index = AddCraft( typeof( DragonBow ), "Bows", "dragon bow - (lv.80)", 80.0, 110.0, typeof( Log ), 1044041, 10, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 6 regular leather", 6, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 8 spools of thread", 8, "Spool of Thread" );
			AddRes( index, typeof( SilverWire ), "Requires 2 silver wires", 2, "Silver Wire" );
			AddRes( index, typeof( Zultanite ), "Requires 1 zultanite", 1, "Zultanite" );

                        // Bows (Lv.90)
			index = AddCraft( typeof( RainbowShortbow ), "Bows", "rainbow shortbow - (lv.90)", 90.0, 120.0, typeof( Log ), 1044041, 10, 1044351 );
			AddRes( index, typeof( Leather ), "Requires 6 regular leather", 6, "Leather" );
			AddRes( index, typeof( SpoolOfThread ), "Requires 8 spools of thread", 8, "Spool of Thread" );
			AddRes( index, typeof( SilverWire ), "Requires 2 silver wires", 2, "Silver Wire" );
			AddRes( index, typeof( PinkQuartz ), "Requires 1 pink quartz", 1, "Pink Quartz" );

			index = AddCraft( typeof( RainbowHeavyCrossbow ), "Bows", "rainbow heavy crossbow - (lv.90)", 90.0, 120.0, typeof( Log ), 1044041, 10, 1044351 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 9 spools of thread", 9, "Spool of Thread" );
			AddRes( index, typeof( Gears ), "Requires 6 gears", 6, "Gears" );
			AddRes( index, typeof( Springs ), "Requires 5 springs", 5, "Springs" );
			AddRes( index, typeof( IronWire ), "Requires 2 iron wire", 2, "Iron Wire" );
			AddRes( index, typeof( CopperWire ), "Requires 1 copper wire", 1, "Copper Wire" );
			AddRes( index, typeof( PinkQuartz ), "Requires 1 pink quartz", 1, "Pink Quartz" );

                        // Runic Fletchers Tools
                        index= AddCraft( typeof( RunicOakWood ), "Runic Fletchers Tools", "Runic Oak Wood", 75.0, 150.0, typeof( OakLog ), 1044041, 5 );
			AddRes( index, typeof( BrilliantAmber ), 1026256, 1, 1053098 );

                        index= AddCraft( typeof( RunicAshWood ), "Runic Fletchers Tools", "Runic Ash Wood", 80.0, 150.0, typeof( AshLog ), 1044041, 5 );
			AddRes( index, typeof( FireRuby ), 1026254, 1, 1053098 );

                        index= AddCraft( typeof( RunicYewWood ), "Runic Fletchers Tools", "Runic Yew Wood", 85.0, 150.0, typeof( YewLog ), 1044041, 5 );
			AddRes( index, typeof( EcruCitrine ), 1026252, 1, 1053098 );

                        index= AddCraft( typeof( RunicHeartwood ), "Runic Fletchers Tools", "Runic Heartwood", 90.0, 150.0, typeof( HeartwoodLog ), 1044041, 5 );
			AddRes( index, typeof( PerfectEmerald ), 1026251, 1, 1053098 );

                        index= AddCraft( typeof( RunicBloodwood ), "Runic Fletchers Tools", "Runic Bloodwood", 95.0, 150.0, typeof( BloodwoodLog ), 1044041, 5 );
			AddRes( index, typeof( DarkSapphire ), 1026249, 1, 1053098 );

                        index= AddCraft( typeof( RunicFrostwood ), "Runic Fletchers Tools", "Runic Frostwood", 100.0, 150.0, typeof( FrostwoodLog ), 1044041, 5 );
			AddRes( index, typeof( WhitePearl ), 1026253, 1, 1053098 );

			MarkOption = true;
			Repair = Core.AOS;

			SetSubRes( typeof( Log ), 1072643 );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material	TODO: Verify the required skill amount
			AddSubRes( typeof( Log ), 1072643, 00.0, 1044041, 1072652 );
			AddSubRes( typeof( OakLog ), 1072644, 70.0, 1044041, 1072652 );
			AddSubRes( typeof( AshLog ), 1072645, 75.0, 1044041, 1072652 );
			AddSubRes( typeof( YewLog ), 1072646, 80.0, 1044041, 1072652 );
			AddSubRes( typeof( HeartwoodLog ), 1072647, 85.0, 1044041, 1072652 );
			AddSubRes( typeof( BloodwoodLog ), 1072648, 90.0, 1044041, 1072652 );
			AddSubRes( typeof( FrostwoodLog ), 1072649, 95.0, 1044041, 1072652 );
		}
	}
}