using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefCarpentry : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Carpentry;	}
		}

		public override int GumpTitleNumber
		{
			get { return 1044004; } // <CENTER>CARPENTRY MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefCarpentry();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefCarpentry() : base( 1, 1, 1.25 )// base( 1, 1, 3.0 )
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
			//	from.Animate( 9, 5, 1, true, false, 0 );

			from.PlaySound( 0x23D );
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

			// Other Items
			if ( Core.Expansion == Expansion.AOS || Core.Expansion == Expansion.SE )
			{
				index =	AddCraft( typeof( Board ),				1044294, 1027127,	 0.0,   0.0,	typeof( Log ), 1044466,  1, 1044465 );
				SetUseAllRes( index, true );
			}

			AddCraft( typeof( BarrelStaves ),				1044294, 1027857,	00.0,  25.0,	typeof( Log ), 1044041,  5, 1044351 );
			AddCraft( typeof( BarrelLid ),					1044294, 1027608,	11.0,  36.0,	typeof( Log ), 1044041,  4, 1044351 );
			AddCraft( typeof( ShortMusicStand ),			1044294, 1044313,	78.9, 103.9,	typeof( Log ), 1044041, 15, 1044351 );
			AddCraft( typeof( TallMusicStand ),				1044294, 1044315,	81.5, 106.5,	typeof( Log ), 1044041, 20, 1044351 );
			AddCraft( typeof( Easle ),						1044294, 1044317,	86.8, 111.8,	typeof( Log ), 1044041, 20, 1044351 );
			if( Core.SE )
			{
				index = AddCraft( typeof( RedHangingLantern ), 1044294, 1029412, 65.0, 90.0, typeof( Log ), 1044041, 5, 1044351 );
				AddRes( index, typeof( BlankScroll ), 1044377, 10, 1044378 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( WhiteHangingLantern ), 1044294, 1029416, 65.0, 90.0, typeof( Log ), 1044041, 5, 1044351 );
				AddRes( index, typeof( BlankScroll ), 1044377, 10, 1044378 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( ShojiScreen ), 1044294, 1029423, 80.0, 105.0, typeof( Log ), 1044041, 75, 1044351 );
				AddSkill( index, SkillName.Tailoring, 50.0, 55.0 );
				AddRes( index, typeof( Cloth ), 1044286, 60, 1044287 );
				SetNeededExpansion( index, Expansion.SE );

				index = AddCraft( typeof( BambooScreen ), 1044294, 1029428, 80.0, 105.0, typeof( Log ), 1044041, 75, 1044351 );
				AddSkill( index, SkillName.Tailoring, 50.0, 55.0 );
				AddRes( index, typeof( Cloth ), 1044286, 60, 1044287 );
				SetNeededExpansion( index, Expansion.SE );
			}

			if( Core.AOS )	//Duplicate Entries to preserve ordering depending on era
			{
				index = AddCraft( typeof( FishingPole ), 1044294, 1023519, 68.4, 93.4, typeof( Log ), 1044041, 5, 1044351 ); //This is in the categor of Other during AoS
				AddSkill( index, SkillName.Tailoring, 40.0, 45.0 );
				AddRes( index, typeof( Cloth ), 1044286, 5, 1044287 );
			}

                        #region Mondain's Legacy
                        if ( Core.ML )
                        {
                            index = AddCraft(typeof(ArcanistStatueSouthDeed), 1044294, 1072885, 0.0, 35.0, typeof(Board), 1044041, 250, 1044351);
                            ForceNonExceptional(index);
                            SetNeededExpansion(index, Expansion.ML);

                            index = AddCraft(typeof(ArcanistStatueEastDeed), 1044294, 1072886, 0.0, 35.0, typeof(Board), 1044041, 250, 1044351);
                            ForceNonExceptional(index);
                            SetNeededExpansion(index, Expansion.ML);

                            index = AddCraft(typeof(WarriorStatueSouthDeed), 1044294, 1072887, 0.0, 35.0, typeof(Board), 1044041, 250, 1044351);
                            ForceNonExceptional(index);
                            SetNeededExpansion(index, Expansion.ML);

                            index = AddCraft(typeof(WaterTroughEastDeed), 1044294, 1072888, 0.0, 35.0, typeof(Board), 1044041, 250, 1044351);
                            ForceNonExceptional(index);
                            SetNeededExpansion(index, Expansion.ML);

                    index = AddCraft(typeof(SquirrelStatueSouthDeed), 1044294, 1072884, 0.0, 35.0, typeof(Board), 1044041, 250, 1044351);
                            ForceNonExceptional(index);
                            SetNeededExpansion(index, Expansion.ML);

                            index = AddCraft(typeof(StoneFireplaceEastDeed), 1044294, 1073398, 0.0, 35.0, typeof(Board), 1044041, 250, 1044351);
                            ForceNonExceptional(index);
                            SetNeededExpansion(index, Expansion.ML);
                        }
                        #endregion

                        #region SA
                        if ( Core.SA )
                        {
                             index = AddCraft( typeof( GargishBanner ), 1044294, 1095312, 94.7, 115.0, typeof(Board), 1044041, 50, 1044351);
                             AddSkill(index, SkillName.Tailoring, 75.0, 105.0);
                             AddRes(index, typeof(Cloth), 1044286, 50, 1044287);
                             SetNeededExpansion(index, Expansion.SA);
                        }
                        #endregion

			// Furniture
                        AddCraft( typeof( ArcaneBookshelfEastDeed ), 1044291, 1073371, 94.7, 119.7, typeof( Board ), 1044041, 80, 1044351 );
                        AddCraft( typeof( ArcaneBookshelfSouthDeed ), 1044291, 1072871, 94.7, 119.7, typeof( Board ), 1044041, 80, 1044351 );
                        AddCraft( typeof( ElvenDresserEastDeed ), 1044291, 1073388, 75.0, 100.0, typeof( Board ), 1044041, 45, 1044351 );
                        AddCraft( typeof( ElvenDresserSouthDeed ), 1044291, 1072864, 75.0, 100.0, typeof( Board ), 1044041, 45, 1044351 );
                        AddCraft( typeof( ElvenWashBasinEastDeed ), 1044291, 1073387, 70.0, 95.0, typeof( Board ), 1044041, 40, 1044351 );
                        AddCraft( typeof( ElvenWashBasinSouthDeed ), 1044291, 1072865, 70.0, 95.0, typeof( Board ), 1044041, 40, 1044351 );

			AddCraft( typeof( BambooChair ), 1044291, 1044300, 21.0, 46.0, typeof( Log ), 1044041, 13, 1044351 );
                        AddCraft( typeof( BigElvenChair ), 1044291, 1072872, 85.0, 110.0, typeof( Log ), 1044041, 40, 1044351 );
                        AddCraft( typeof( ElvenReadingChair ), 1044291, 1072873, 80.0, 105.0, typeof( Log ), 1044041, 30, 1044351 );

			AddCraft( typeof( FancyWoodenChairCushion ), 1044291, 1044302, 42.1, 67.1, typeof( Log ), 1044041, 15, 1044351 );
			AddCraft( typeof( FootStool ), 1044291, 1022910, 11.0, 36.0, typeof( Log ), 1044041, 9, 1044351 );
                        AddCraft( typeof( OrnateElvenChair ), 1044291, 1072870, 80.0, 105.0, typeof( Log ), 1044041, 30, 1044351 );

			AddCraft( typeof( Stool ), 1044291, 1022602, 11.0, 36.0, typeof( Log ), 1044041, 9, 1044351 );
                        AddCraft( typeof( TerMurStyleChair ), 1044291, 1095291, 85.0, 110.0, typeof( Log ), 1044041, 40, 1044351 );
			AddCraft( typeof( Throne ), 1044291, 1044305, 73.6, 98.6, typeof( Log ), 1044041, 19, 1044351 );
			AddCraft( typeof( WoodenBench ), 1044291, 1022860, 52.6, 77.6, typeof( Log ), 1044041, 17, 1044351 );
			AddCraft( typeof( WoodenChair ), 1044291, 1044301, 21.0, 46.0, typeof( Log ), 1044041, 13, 1044351 );
			AddCraft( typeof( WoodenChairCushion ),	1044291, 1044303, 42.1, 67.1, typeof( Log ), 1044041, 13, 1044351 );
			AddCraft( typeof( WoodenThrone ), 1044291, 1044304, 52.6, 77.6, typeof( Log ), 1044041, 17, 1044351 );

                        AddCraft( typeof( AlchemistTableEastDeed ), 1044291, 1073397, 85.0, 110.0, typeof( Board ), 1044041, 70, 1044351 );
                        AddCraft( typeof( AlchemistTableSouthDeed ), 1044291, 1073396, 85.0, 110.0, typeof( Board ), 1044041, 70, 1044351 );
			AddCraft( typeof( ElegantLowTable ), 1044291, 1030265,	80.0, 105.0, typeof( Log ), 1044041, 35, 1044351 );
                        AddCraft( typeof( FancyElvenTableEastDeed ), 1044291, 1073386, 80.0, 105.0, typeof( Board ), 1044041, 50, 1044351 );
                        AddCraft( typeof( FancyElvenTableSouthDeed ), 1044291, 1073385, 80.0, 105.0, typeof( Board ), 1044041, 50, 1044351 );
			AddCraft( typeof( LargeTable ),	1044291, 1044308, 84.2, 109.2, typeof( Log ), 1044041, 27, 1044351 );
			AddCraft( typeof( Nightstand ),	1044291, 1044306, 42.1,  67.1, typeof( Log ), 1044041, 17, 1044351 );
                        AddCraft( typeof( OrnateElvenTableEastDeed ), 1044291, 1073384, 85.0, 110.0, typeof( Board ), 1044041, 60, 1044351 );
                        AddCraft( typeof( OrnateElvenTableSouthDeed ), 1044291, 1072869, 85.0, 110.0, typeof( Board ), 1044041, 60, 1044351 );
			AddCraft( typeof( PlainLowTable ), 1044291, 1030266, 80.0, 105.0, typeof( Log ), 1044041, 35, 1044351 );
                        AddCraft( typeof( TerMurStyleTable ), 1044291, 1095321, 75.0, 100.0, typeof( Log ), 1044041, 50, 1044351 );
			AddCraft( typeof( WritingTable ), 1044291, 1022890, 63.1,  88.1, typeof( Log ), 1044041, 17, 1044351 );
			AddCraft( typeof( YewWoodTable ), 1044291, 1044307, 63.1,  88.1, typeof( Log ), 1044041, 23, 1044351 );

			// Containers
			index = AddCraft( typeof( Keg ), 1044292, 1023711, 57.8, 82.8, typeof( BarrelStaves ), 1044288, 3, 1044253 );
			AddRes( index, typeof( BarrelHoops ), 1044289, 1, 1044253 );
			AddRes( index, typeof( BarrelLid ), 1044251, 1, 1044253 );

			AddCraft( typeof( WoodenBox ), 1044292, 1023709, 21.0,  46.0,	typeof( Log ), 1044041, 10, 1044351 );

			AddCraft( typeof( SmallCrate ),	1044292, 1044309, 10.0,  35.0,	typeof( Log ), 1044041, 8 , 1044351 );
			AddCraft( typeof( MediumCrate ), 1044292, 1044310, 31.0,  56.0,	typeof( Log ), 1044041, 15, 1044351 );
			AddCraft( typeof( LargeCrate ),	1044292, 1044311, 47.3,  72.3,	typeof( Log ), 1044041, 18, 1044351 );

			AddCraft( typeof( WoodenChest ), 1044292, 1023650, 73.6,  98.6,	typeof( Log ), 1044041, 20, 1044351 );
			AddCraft( typeof( FinishedWoodenChest ), 1044292, 1030259, 90.0, 115.0,	typeof( Log ), 1044041, 30, 1044351 );
                        AddCraft( typeof( GargishChest ), 1044292, 1095293, 80.0, 105.0, typeof( Log ), 1044041, 30, 1044351 );
			AddCraft( typeof( GildedWoodenChest ), 1044292, 1030255, 90.0, 115.0,	typeof( Log ), 1044041, 30, 1044351 );
			AddCraft( typeof( OrnateWoodenChest ), 1044292, 1030253, 90.0, 115.0,	typeof( Log ), 1044041, 30, 1044351 );
			AddCraft( typeof( PlainWoodenChest ), 1044292, 1030251, 90.0, 115.0,	typeof( Log ), 1044041, 30, 1044351 );

			AddCraft( typeof( EmptyBookcase ), 1044292, 1022718,	31.5,  56.5,	typeof( Log ), 1044041, 25, 1044351 );
			AddCraft( typeof( FancyArmoire ), 1044292, 1044312,	84.2, 109.2,	typeof( Log ), 1044041, 35, 1044351 );
			AddCraft( typeof( Armoire ), 1044292, 1022643,	84.2, 109.2,	typeof( Log ), 1044041, 35, 1044351 );
			AddCraft( typeof( CherryArmoire ), 1044292, 1030334, 90.0, 115.0,	typeof( Log ), 1044041, 40, 1044351 );
			AddCraft( typeof( ElegantArmoire ), 1044292, 1030330, 90.0, 115.0,	typeof( Log ), 1044041, 40, 1044351 );
			AddCraft( typeof( MapleArmoire ), 1044292, 1030332, 90.0, 115.0,	typeof( Log ), 1044041, 40, 1044351 );
			AddCraft( typeof( RedArmoire ),	1044292, 1030328, 90.0, 115.0,	typeof( Log ), 1044041, 40, 1044351 );
			AddCraft( typeof( ShortCabinet ), 1044292, 1030263, 90.0, 115.0,	typeof( Log ), 1044041, 35, 1044351 );
			AddCraft( typeof( TallCabinet ), 1044292, 1030261, 90.0, 115.0,	typeof( Log ), 1044041, 35, 1044351 );
			AddCraft( typeof( WoodenFootLocker ), 1044292, 1030257, 90.0, 115.0,	typeof( Log ), 1044041, 30, 1044351 );

			// Armor
	                index = AddCraft( typeof( WoodenShield ), "Armor", 1027034, 52.6, 77.6, typeof( Log ), 1044041, 9, 1044351 );
	                AddRes( index, typeof( IronIngot ), 1044036, 2, 1044037 );
	                AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

                        index = AddCraft( typeof( WoodlandArms ), "Armor", 1031116, 80.0, 105.0, typeof( Log ), 1044041, 15, 1044351 );
                        AddRes( index, typeof( BarkFragment ), 1032687, 4, 1053098 );

                        index = AddCraft( typeof( WoodlandChest ), "Armor", 1031111, 90.0, 115.0, typeof( Log ), 1044041, 20, 1044351 );
                        AddRes( index, typeof( BarkFragment ), 1032687, 6, 1053098 );

                        index = AddCraft( typeof( WoodlandGloves ), "Armor", 1031114, 85.0, 110.0, typeof( Log ), 1044041, 15, 1044351 );
                        AddRes( index, typeof( BarkFragment ), 1032687, 4, 1053098 );

                        index = AddCraft( typeof( WoodlandGorget ), "Armor", 1031113, 85.0, 110.0, typeof( Log ), 1044041, 15, 1044351 );
                        AddRes( index, typeof( BarkFragment ), 1032687, 4, 1053098 );

                        index = AddCraft( typeof( WoodlandLegs ), "Armor", 1031115, 85.0, 110.0, typeof( Log ), 1044041, 15, 1044351 );
                        AddRes( index, typeof( BarkFragment ), 1032687, 4, 1053098 );


                        index = AddCraft( typeof( RavenHelm ), "Armor", 1031121, 65.0, 115.0, typeof( Log ), 1044041, 10, 1044351 );
                        AddRes( index, typeof( BarkFragment ), 1032687, 4, 1053098 );
                        AddRes( index, typeof( Feather ), 1027123, 25, 1053098 );

                        index = AddCraft( typeof( VultureHelm ), "Armor", 1031122, 63.9, 113.9, typeof( Log ), 1044041, 10, 1044351 );
                        AddRes( index, typeof( BarkFragment ), 1032687, 4, 1053098);
                        AddRes( index, typeof( Feather ), 1027123, 25, 1053098);

                        index = AddCraft( typeof( WingedHelm ), "Armor", 1031123, 58.4, 108.4, typeof( Log ), 1044041, 10, 1044351 );
                        AddRes( index, typeof( BarkFragment ), 1032687, 4, 1053098);
                        AddRes( index, typeof( Feather ), 1027123, 60, 1053098);

			// Weapons
			AddCraft( typeof( BlackStaff ), "Weapons", "black staff", 85.9, 105.9, typeof( Log ), 1044041, 10, 1044351 );
			AddCraft( typeof( Bokuto ), "Weapons", 1030227, 70.0, 95.0, typeof( Log ), 1044041, 6, 1044351 );
			AddCraft( typeof( CrystalStaff ), "Weapons", "crystal staff", 85.0, 110.0, typeof( Log ), 1044041, 15, 1044351 );
                        AddCraft( typeof( Fukiya ), "Weapons", 1030229, 60.0, 85.0, typeof( Log ), 1044041, 6, 1044351 );
			AddCraft( typeof( GnarledStaff ), "Weapons", 1025112, 78.9, 103.9, typeof( Log ), 1044041, 7, 1044351 );
			AddCraft( typeof( PristineStaff ), "Weapons", "pristine staff", 85.0, 110.0, typeof( Log ), 1044041, 12, 1044351 );
			AddCraft( typeof( QuarterStaff ), "Weapons", 1023721, 73.6, 98.6, typeof( Log ), 1044041, 6, 1044351 );
			AddCraft( typeof( ShepherdsCrook ), "Weapons", 1023713, 78.9, 103.9, typeof( Log ), 1044041, 7, 1044351 );
			AddCraft( typeof( Tetsubo ), "Weapons", 1030225, 80.0, 140.3, typeof( Log ), 1044041, 10, 1044351 );

			index = AddCraft( typeof( TribalStaff ), "Weapons", "tribal staff", 85.0, 110.0, typeof( Log ), 1044041, 10, 1044351 );
			AddRes( index, typeof( Bone ), 1049064, 15, 1049063 );

			AddCraft( typeof( WildStaff ), "Weapons", "wild staff", 78.9, 103.9, typeof( Log ), 1044041, 7, 1044351 );

			index = AddCraft( typeof( AncientWildStaff ), "Weapons", 1073550, 63.8, 113.8, typeof( Log ), 1044041, 16, 1044351 );
			AddRes( index, typeof( PerfectEmerald ), 1026251, 1, 1053098 );

			index = AddCraft( typeof( ArcanistsWildStaff ), "Weapons", 1073549, 63.8, 113.8, typeof( Log ), 1044041, 16, 1044351 );
			AddRes( index, typeof( WhitePearl ), 1026253, 1, 1053098 );

			index = AddCraft( typeof( HardenedWildStaff ), "Weapons", 1073552, 63.8, 113.8, typeof( Log ), 1044041, 16, 1044351 );
			AddRes( index, typeof( Turquoise ), 1026250, 1, 1053098 );

			index = AddCraft( typeof( ThornedWildStaff ), "Weapons", 1073551, 63.8, 113.8, typeof( Log ), 1044041, 16, 1044351 );
			AddRes( index, typeof( FireRuby ), 1026254, 1, 1053098 );

			// Instruments
			index = AddCraft( typeof( Drums ), 1044293, 1023740, 57.8, 82.8, typeof( Log ), 1044041, 20, 1044351 );
			AddSkill( index, SkillName.Musicianship, 45.0, 50.0 );
			AddRes( index, typeof( Cloth ), 1044286, 10, 1044287 );

			index = AddCraft( typeof( LapHarp ), 1044293, 1023762, 63.1, 88.1, typeof( Log ), 1044041, 20, 1044351 );
			AddSkill( index, SkillName.Musicianship, 45.0, 50.0 );
			AddRes( index, typeof( Cloth ), 1044286, 10, 1044287 );

			index = AddCraft( typeof( Lute ), 1044293, 1023763, 68.4, 93.4, typeof( Log ), 1044041, 25, 1044351 );
			AddSkill( index, SkillName.Musicianship, 45.0, 50.0 );
			AddRes( index, typeof( Cloth ), 1044286, 10, 1044287 );

			index = AddCraft( typeof( Tambourine ), 1044293, 1023741, 57.8, 82.8, typeof( Log ), 1044041, 15, 1044351 );
			AddSkill( index, SkillName.Musicianship, 45.0, 50.0 );
			AddRes( index, typeof( Cloth ), 1044286, 10, 1044287 );

			// Misc
			AddCraft( typeof( BallotBoxDeed ), "Misc", 1044327, 47.3, 72.3, typeof( Board ), 1044041, 5, 1044351 );
			AddCraft( typeof( DartBoardSouthDeed ), "Misc", 1044325, 15.7, 40.7, typeof( Board ), 1044041, 5, 1044351 );
			AddCraft( typeof( DartBoardEastDeed ), "Misc", 1044326, 15.7, 40.7, typeof( Board ), 1044041, 5, 1044351 );
			AddCraft( typeof( PlayerBBEast ), "Misc", 1062420, 85.0, 110.0, typeof( Board ), 1044041, 50, 1044351 );
			AddCraft( typeof( PlayerBBSouth ), "Misc", 1062421, 85.0, 110.0, typeof( Board ), 1044041, 50, 1044351 );
			AddCraft( typeof( WaterTroughEastDeed ), "Misc", 1044349, 94.7, 119.7, typeof( Board ), 1044041, 150, 1044351 );
			AddCraft( typeof( WaterTroughSouthDeed ), "Misc", 1044350, 94.7, 119.7, typeof( Board ), 1044041, 150, 1044351 );

			// Skill
			index = AddCraft( typeof( FishingPole ), "Skill", 1023519, 68.4, 93.4, typeof( Board ), 1044041, 5, 1044351 ); 
			AddSkill( index, SkillName.Tailoring, 40.0, 45.0 );
			AddRes( index, typeof( Cloth ), 1044286, 5, 1044287 );

			index = AddCraft( typeof( AbbatoirDeed ), "Skill", 1044329, 100.0, 125.0, typeof( Board ), 1044041, 100, 1044351 );
			AddSkill( index, SkillName.Magery, 50.0, 55.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 40, 1044037 );

			index = AddCraft( typeof( PentagramDeed ), "Skill", 1044328, 100.0, 125.0, typeof( Board ), 1044041, 100, 1044351 );
			AddSkill( index, SkillName.Magery, 75.0, 80.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 40, 1044037 );

			// Blacksmithy
			index = AddCraft( typeof( AnvilEastDeed ), "Skill", 1044333, 73.6, 98.6, typeof( Board ), 1044041, 5, 1044351 );
			AddSkill( index, SkillName.Blacksmith, 75.0, 80.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 150, 1044037 );
			index = AddCraft( typeof( AnvilSouthDeed ), "Skill", 1044334, 73.6, 98.6, typeof( Board ), 1044041, 5, 1044351 );
			AddSkill( index, SkillName.Blacksmith, 75.0, 80.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 150, 1044037 );

                        index = AddCraft( typeof( ElvenForgeDeed ), "Skill", 1072875, 94.7, 119.7, typeof( Board ), 1044041, 200, 1044351);
			AddSkill( index, SkillName.Blacksmith, 75.0, 80.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 75, 1044037 );

			index = AddCraft( typeof( LargeForgeEastDeed ), "Skill", 1044331, 78.9, 103.9, typeof( Board ), 1044041, 5, 1044351 );
			AddSkill( index, SkillName.Blacksmith, 80.0, 85.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 100, 1044037 );
			index = AddCraft( typeof( LargeForgeSouthDeed ), "Skill", 1044332, 78.9, 103.9, typeof( Board ), 1044041, 5, 1044351 );
			AddSkill( index, SkillName.Blacksmith, 80.0, 85.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 100, 1044037 );

			index = AddCraft( typeof( SmallForgeDeed ), "Skill", 1044330, 73.6, 98.6, typeof( Board ), 1044041, 5, 1044351 );
			AddSkill( index, SkillName.Blacksmith, 75.0, 80.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 75, 1044037 );

			// Tailoring
			index = AddCraft( typeof( Dressform ), "Skill", 1044339, 63.1, 88.1, typeof( Log ), 1044041, 25, 1044351 );
			AddSkill( index, SkillName.Tailoring, 65.0, 70.0 );
			AddRes( index, typeof( Cloth ), 1044286, 10, 1044287 );

                        index = AddCraft( typeof( ElvenBedEastDeed ), "Skill", 1072861, 94.7, 119.7, typeof( Board ), 1044041, 100, 1044351 );
                        AddSkill( index, SkillName.Tailoring, 75.0, 80.0 );
                        AddRes( index, typeof( Cloth ), 1044286, 100, 1044287 );
			AddRes( index, typeof( Flax ), "Requires 25 flax", 25, "Flax" );
                        index = AddCraft( typeof( ElvenBedSouthDeed ), "Skill", 1072860, 94.7, 119.7, typeof( Board ), 1044041, 100, 1044351 );
                        AddSkill( index, SkillName.Tailoring, 75.0, 80.0 );
                        AddRes( index, typeof( Cloth ), 1044286, 100, 1044287 );
			AddRes( index, typeof( Flax ), "Requires 25 flax", 25, "Flax" );

                        AddCraft( typeof( ElvenLoveseatEastDeed ), "Skill", 1073372, 80.0, 105.0, typeof( Board ), 1044041, 50, 1044351 );
                        AddSkill( index, SkillName.Tailoring, 75.0, 80.0 );
                        AddRes( index, typeof( Cloth ), 1044286, 75, 1044287 );
			AddRes( index, typeof( Flax ), "Requires 20 flax", 20, "Flax" );
                        AddCraft( typeof( ElvenLoveseatSouthDeed ), "Skill", 1072867, 80.0, 105.0, typeof( Board ), 1044041, 50, 1044351 );
                        AddSkill( index, SkillName.Tailoring, 75.0, 80.0 );
                        AddRes( index, typeof( Cloth ), 1044286, 75, 1044287 );
			AddRes( index, typeof( Flax ), "Requires 20 flax", 20, "Flax" );

                        index = AddCraft( typeof( ElvenSpinningwheelEastDeed ), "Skill", 1073393, 75.0, 100.0, typeof( Board ), 1044041, 60, 1044351 );
                        AddSkill( index, SkillName.Tailoring, 65.0, 85.0 );
                        AddRes( index, typeof( Cloth ), 1044286, 40, 1044287 );
                        index = AddCraft( typeof( ElvenSpinningwheelSouthDeed ), "Skill", 1072878, 75.0, 100.0, typeof( Board ), 1044041, 60, 1044351 );
                        AddSkill( index, SkillName.Tailoring, 65.0, 85.0 );
                        AddRes( index, typeof( Cloth ), 1044286, 40, 1044287 );

			index = AddCraft(typeof( LargeBedEastDeed ), "Skill", 1044324, 94.7, 119.8, typeof( Board ), 1044041, 150, 1044351);
			AddSkill( index, SkillName.Tailoring, 75.0, 80.0 );
			AddRes( index, typeof( Cloth ), 1044286, 150, 1044287 );
			AddRes( index, typeof( Flax ), "Requires 25 flax", 25, "Flax" );
			index = AddCraft(typeof( LargeBedSouthDeed ), "Skill", 1044323, 94.7, 119.8, typeof( Board ), 1044041, 150, 1044351);
			AddSkill( index, SkillName.Tailoring, 75.0, 80.0 );
			AddRes( index, typeof( Cloth ), 1044286, 150, 1044287 );
			AddRes( index, typeof( Flax ), "Requires 25 flax", 25, "Flax" );

			index = AddCraft( typeof( LoomEastDeed ), "Skill", 1044343, 84.2, 109.2, typeof( Board ), 1044041, 85, 1044351 );
			AddSkill( index, SkillName.Tailoring, 65.0, 70.0 );
			AddRes( index, typeof( Cloth ), 1044286, 25, 1044287 );
			index = AddCraft( typeof( LoomSouthDeed ), "Skill", 1044344, 84.2, 109.2, typeof( Board ), 1044041, 85, 1044351 );
			AddSkill( index, SkillName.Tailoring, 65.0, 70.0 );
			AddRes( index, typeof( Cloth ), 1044286, 25, 1044287 );

			index = AddCraft( typeof( PickpocketDipEastDeed ), "Skill", 1044337, 73.6, 98.6, typeof( Board ), 1044041, 65, 1044351 );
			AddSkill( index, SkillName.Tailoring, 50.0, 55.0 );
			AddRes( index, typeof( Cloth ), 1044286, 60, 1044287 );
			index = AddCraft( typeof( PickpocketDipSouthDeed ), "Skill", 1044338, 73.6, 98.6, typeof( Board ), 1044041, 65, 1044351 );
			AddSkill( index, SkillName.Tailoring, 50.0, 55.0 );
			AddRes( index, typeof( Cloth ), 1044286, 60, 1044287 );

			index = AddCraft(typeof( SmallBedEastDeed ), "Skill", 1044322, 94.7, 119.8, typeof( Board ), 1044041, 100, 1044351);
			AddSkill( index, SkillName.Tailoring, 75.0, 80.0 );
			AddRes( index, typeof( Cloth ), 1044286, 100, 1044287 );
			AddRes( index, typeof( Flax ), "Requires 20 flax", 20, "Flax" );
			index = AddCraft( typeof( SmallBedSouthDeed ), "Skill", 1044321, 94.7, 119.8, typeof( Board ), 1044041, 100, 1044351 );
			AddSkill( index, SkillName.Tailoring, 75.0, 80.0 );
			AddRes( index, typeof( Cloth ), 1044286, 100, 1044287 );
			AddRes( index, typeof( Flax ), "Requires 20 flax", 20, "Flax" );

			index = AddCraft( typeof( SpinningwheelEastDeed ), "Skill", 1044341, 73.6, 98.6, typeof( Board ), 1044041, 75, 1044351 );
			AddSkill( index, SkillName.Tailoring, 65.0, 70.0 );
			AddRes( index, typeof( Cloth ), 1044286, 25, 1044287 );
			index = AddCraft( typeof( SpinningwheelSouthDeed ), "Skill", 1044342, 73.6, 98.6, typeof( Board ), 1044041, 75, 1044351 );
			AddSkill( index, SkillName.Tailoring, 65.0, 70.0 );
			AddRes( index, typeof( Cloth ), 1044286, 25, 1044287 );

                        index = AddCraft( typeof( TallElvenBedEastDeed ), "Skill", 1072859, 94.7, 119.7, typeof( Board ), 1044041, 200, 1044351 );
                        AddSkill( index, SkillName.Tailoring, 75.0, 80.0 );
                        AddRes( index, typeof( Cloth ), 1044286, 100, 1044287 );
			AddRes( index, typeof( Flax ), "Requires 20 flax", 20, "Flax" );
			index = AddCraft( typeof( TallElvenBedSouthDeed ), "Skill", 1072858, 94.7, 119.7, typeof( Board ), 1044041, 200, 1044351 );
                        AddSkill( index, SkillName.Tailoring, 75.0, 80.0 );
                        AddRes( index, typeof( Cloth ), 1044286, 100, 1044287 );
			AddRes( index, typeof( Flax ), "Requires 20 flax", 20, "Flax" );

			index = AddCraft( typeof( TrainingDummyEastDeed ), "Skill", 1044335, 68.4, 93.4, typeof( Board ), 1044041, 55, 1044351 );
			AddSkill( index, SkillName.Tailoring, 50.0, 55.0 );
			AddRes( index, typeof( Cloth ), 1044286, 60, 1044287 );
			index = AddCraft( typeof( TrainingDummySouthDeed ), "Skill", 1044336, 68.4, 93.4, typeof( Board ), 1044041, 55, 1044351 );
			AddSkill( index, SkillName.Tailoring, 50.0, 55.0 );
			AddRes( index, typeof( Cloth ), 1044286, 60, 1044287 );

			// Cooking & Tinkering
                        index = AddCraft( typeof( ElvenStoveEastDeed ), "Skill", 1073395, 85.0, 110.0, typeof( Board ), 1044041, 80, 1044351 );
			AddSkill( index, SkillName.Cooking, 25.0, 50.0 );
			AddSkill( index, SkillName.Tinkering, 50.0, 55.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 125, 1044037 );
                        index = AddCraft( typeof( ElvenStoveSouthDeed ), "Skill", 1073394, 85.0, 110.0, typeof( Board ), 1044041, 80, 1044351 );
			AddSkill( index, SkillName.Cooking, 25.0, 50.0 );
			AddSkill( index, SkillName.Tinkering, 50.0, 55.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 125, 1044037 );

			index = AddCraft( typeof( FlourMillEastDeed ), "Skill", 1044347, 94.7, 119.7, typeof( Board ), 1044041, 100, 1044351 );
			AddSkill( index, SkillName.Cooking, 25.0, 50.0 );
			AddSkill( index, SkillName.Tinkering, 50.0, 55.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 50, 1044037 );
			index = AddCraft( typeof( FlourMillSouthDeed ), "Skill", 1044348, 94.7, 119.7, typeof( Board ), 1044041, 100, 1044351 );
			AddSkill( index, SkillName.Cooking, 25.0, 50.0 );
			AddSkill( index, SkillName.Tinkering, 50.0, 55.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 50, 1044037 );

			index = AddCraft( typeof( StoneOvenEastDeed ), "Skill", 1044345, 68.4, 93.4, typeof( Board ), 1044041, 85, 1044351 );
			AddSkill( index, SkillName.Cooking, 25.0, 50.0 );
			AddSkill( index, SkillName.Tinkering, 50.0, 55.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 125, 1044037 );
			index = AddCraft( typeof( StoneOvenSouthDeed ), "Skill", 1044346, 68.4, 93.4, typeof( Board ), 1044041, 85, 1044351 );
			AddSkill( index, SkillName.Cooking, 25.0, 50.0 );
			AddSkill( index, SkillName.Tinkering, 50.0, 55.0 );
			AddRes( index, typeof( IronIngot ), 1044036, 125, 1044037 );

			MarkOption = true;
			Repair = Core.AOS;

			SetSubRes( typeof( Log ), 1072643 );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material	TODO: Verify the required skill amount
			AddSubRes( typeof( Log ), 1072643, 00.0, 1044041, 1072652 );
			AddSubRes( typeof( OakLog ), 1072644, 65.0, 1044041, 1072652 );
			AddSubRes( typeof( AshLog ), 1072645, 80.0, 1044041, 1072652 );
			AddSubRes( typeof( YewLog ), 1072646, 95.0, 1044041, 1072652 );
			AddSubRes( typeof( HeartwoodLog ), 1072647, 100.0, 1044041, 1072652 );
			AddSubRes( typeof( BloodwoodLog ), 1072648, 100.0, 1044041, 1072652 );
			AddSubRes( typeof( FrostwoodLog ), 1072649, 100.0, 1044041, 1072652 );
		}
	}
}