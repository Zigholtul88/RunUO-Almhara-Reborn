using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefArmorsmithy : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Blacksmith;	}
		}

		public override string GumpTitleString
		{
			get { return "<basefont color=#FFFFFF><CENTER>Armorsmithy MENU</CENTER></basefont>"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefArmorsmithy();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefArmorsmithy() : base( 1, 1, 1.25 )// base( 1, 2, 1.7 )
		{
			/*
			
			base( MinCraftEffect, MaxCraftEffect, Delay )
			
			MinCraftEffect	: The minimum number of time the mobile will play the craft effect
			MaxCraftEffect	: The maximum number of time the mobile will play the craft effect
			Delay			: The delay between each craft effect
			
			Example: (3, 6, 1.7) would make the mobile do the PlayCraftEffect override
			function between 3 and 6 time, with a 1.7 second delay each time.
			
			*/ 
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if ( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !BaseTool.CheckTool( tool, from ) )
				return 1048146; // If you have a tool equipped, you must use that tool.
			else if ( !BaseTool.CheckAccessible( tool, from ) )
				return 1044263; // The tool must be on your person to use.

			bool anvil, forge;
			DefBlacksmithy.CheckAnvilAndForge( from, 2, out anvil, out forge );

			if ( anvil && forge )
				return 0;

			return 1044267; // You must be near an anvil and a forge to smith items.
		}

		public override void PlayCraftEffect( Mobile from )
		{
			// no animation, instant sound
			//if ( from.Body.Type == BodyType.Human && !from.Mounted )
			//	from.Animate( 9, 5, 1, true, false, 0 );
			//new InternalTimer( from ).Start();

			from.PlaySound( 0x2A );
		}

		// Delay to synchronize the sound with the hit on the anvil
		private class InternalTimer : Timer
		{
			private Mobile m_From;

			public InternalTimer( Mobile from ) : base( TimeSpan.FromSeconds( 0.7 ) )
			{
				m_From = from;
			}

			protected override void OnTick()
			{
				m_From.PlaySound( 0x2A );
			}
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
			/*
			Synthax for a SIMPLE craft item
			AddCraft( ObjectType, Group, MinSkill, MaxSkill, ResourceType, Amount, Message )
			
			ObjectType		: The type of the object you want to add to the build list.
			Group			: The group in wich the object will be showed in the craft menu.
			MinSkill		: The minimum of skill value
			MaxSkill		: The maximum of skill value
			ResourceType	: The type of the resource the mobile need to create the item
			Amount			: The amount of the ResourceType it need to create the item
			Message			: String or Int for Localized.  The message that will be sent to the mobile, if the specified resource is missing.
			
			Synthax for a COMPLEXE craft item.  A complexe item is an item that need either more than
			only one skill, or more than only one resource.
			
			Coming soon....
			*/

                        int index = -1;

////////////////////////// Chainmail Types //////////////////////////
////////////////////////// Chainmail (Lv.27)
index = AddCraft( typeof( ChainChest ), "Chainmail", "chain chest - (lv.27)", 27.0, 47.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 15 regular leather", 15, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( ChainCoif ), "Chainmail", "chain coif - (lv.27)", 27.0, 47.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( ChainLegs ), "Chainmail", "chain legs - (lv.27)", 27.0, 47.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 6 regular leather", 6, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

////////////////////////// Chainmail Types //////////////////////////
////////////////////////// Welded Chain (Lv.30)
index = AddCraft( typeof( WeldedChainArms ), "Welded Chain", "welded chain arms - (lv.30)", 30.0, 50.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 5 regular leather", 5, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( WeldedChainChest ), "Welded Chain", "welded chain arms - (lv.30)", 30.0, 50.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 15 regular leather", 15, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( WeldedChainLegs ), "Welded Chain", "welded chain legs - (lv.30)", 30.0, 50.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 6 regular leather", 6, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

////////////////////////// Chainmail Types //////////////////////////
////////////////////////// Elven Chain (Lv.33)
index = AddCraft( typeof( ElvenChainArms ), "Elven Chain", "elven chain arms - (lv.33)", 33.0, 53.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 5 regular leather", 5, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( ElvenChainChest ), "Elven Chain", "elven chain chest - (lv.33)", 33.0, 53.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 15 regular leather", 15, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( ElvenChainGloves ), "Elven Chain", "elven chain gloves - (lv.33)", 33.0, 53.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 1 regular leather", 1, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( ElvenChainGorget ), "Elven Chain", "elven chain gorget - (lv.33)", 33.0, 53.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( ElvenChainHelmet ), "Elven Chain", "elven chain helmet - (lv.33)", 33.0, 53.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( ElvenChainLegs ), "Elven Chain", "elven chain legs - (lv.33)", 33.0, 53.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 6 regular leather", 6, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

////////////////////////// Ringmail Types //////////////////////////
////////////////////////// Ringmail (Lv.36)
index = AddCraft( typeof( RingmailArms ), "Ringmail", "ringmail arms - (lv.36)", 36.0, 56.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 5 regular leather", 5, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( RingmailChest ), "Ringmail", "ringmail chest - (lv.36)", 36.0, 56.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 13 regular leather", 13, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( RingmailGloves ), "Ringmail", "ringmail gloves - (lv.36)", 36.0, 56.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 1 regular leather", 1, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( RingmailLegs ), "Ringmail", "ringmail legs - (lv.36)", 36.0, 56.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 8 regular leather", 8, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

////////////////////////// Ringmail Types //////////////////////////
////////////////////////// Scalemail (Lv.39)
index = AddCraft( typeof( ScalemailArms ), "Scalemail", "scalemail arms - (lv.39)", 39.0, 59.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 5 regular leather", 5, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( ScalemailChest ), "Scalemail", "scalemail chest - (lv.39)", 39.0, 59.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 13 regular leather", 13, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( ScalemailGloves ), "Scalemail", "scalemail gloves - (lv.39)", 39.0, 59.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 1 regular leather", 1, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( ScalemailGorget ), "Scalemail", "scalemail gorget - (lv.39)", 39.0, 59.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( ScalemailLegs ), "Scalemail", "scalemail legs - (lv.39)", 39.0, 59.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 8 regular leather", 8, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

////////////////////////// Platemail Types //////////////////////////
////////////////////////// Platemail (Lv.45)
index = AddCraft( typeof( Bascinet ), "Platemail", "bascinet - (lv.45)", 45.0, 65.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( CloseHelm ), "Platemail", "close helm - (lv.45)", 45.0, 65.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( FemalePlateChest ), "Platemail", "female plate chest - (lv.45)", 45.0, 65.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( Helmet ), "Platemail", "helmet - (lv.45)", 45.0, 65.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( NorseHelm ), "Platemail", "norse helm - (lv.45)", 45.0, 65.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( PlateArms ), "Platemail", "plate arms - (lv.45)", 45.0, 65.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 7 regular leather", 7, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( PlateChest ), "Platemail", "plate chest - (lv.45)", 45.0, 65.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( PlateGloves ), "Platemail", "plate gloves - (lv.45)", 45.0, 65.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( PlateGorget ), "Platemail", "plate gorget - (lv.45)", 45.0, 65.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( PlateHelm ), "Platemail", "plate helm - (lv.45)", 45.0, 65.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( PlateLegs ), "Platemail", "plate legs - (lv.45)", 45.0, 65.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

////////////////////////// Platemail Types //////////////////////////
////////////////////////// Samurai Plate (Lv.51)
index = AddCraft( typeof( DecorativePlateKabuto ), "Samurai Plate", "decorative plate kabuto - (lv.51)", 51.0, 71.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( HeavyPlateJingasa ), "Samurai Plate", "heavy plate jingasa - (lv.51)", 51.0, 71.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LightPlateJingasa ), "Samurai Plate", "light plate jingasa - (lv.51)", 51.0, 71.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( PlateBattleKabuto ), "Samurai Plate", "plate battle kabuto - (lv.51)", 51.0, 71.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( PlateDo ), "Samurai Plate", "plate do - (lv.51)", 51.0, 71.0, typeof( IronIngot ), 1044036, 28, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( PlateHaidate ), "Samurai Plate", "plate haidate - (lv.51)", 51.0, 71.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( PlateHatsuburi ), "Samurai Plate", "plate hatsuburi - (lv.51)", 51.0, 71.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( PlateHiroSode ), "Samurai Plate", "plate hiro sode - (lv.51)", 51.0, 71.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 7 regular leather", 7, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( PlateMempo ), "Samurai Plate", "plate mempo - (lv.51)", 51.0, 71.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( PlateSuneate ), "Samurai Plate", "plate suneate - (lv.51)", 51.0, 71.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( SmallPlateJingasa ), "Samurai Plate", "small plate jingasa - (lv.51)", 51.0, 71.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( StandardPlateKabuto ), "Samurai Plate", "standard plate kabuto - (lv.51)", 51.0, 71.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

////////////////////////// Platemail Types //////////////////////////
////////////////////////// Elven Plate (Lv.54)
index = AddCraft( typeof( ElvenPlateArms ), "Elven Plate", "elven plate arms - (lv.54)", 54.0, 74.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 7 regular leather", 7, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( ElvenPlateChest ), "Elven Plate", "elven plate chest - (lv.54)", 54.0, 74.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( ElvenPlateHelm ), "Elven Plate", "elven plate helm - (lv.54)", 54.0, 74.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( ElvenPlateLegs ), "Elven Plate", "elven plate legs - (lv.54)", 54.0, 74.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

////////////////////////// Elite Types //////////////////////////
////////////////////////// Crusader (Lv.60)
index = AddCraft( typeof( CrusaderBreastplate ), "Elite Types", "crusader breastplate - (lv.60)", 60.0, 80.0, typeof( IronIngot ), 1044036, 30, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( CrusaderGauntlets ), "Elite Types", "crusader gauntlets - (lv.60)", 60.0, 80.0, typeof( IronIngot ), 1044036, 17, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( CrusaderGorget ), "Elite Types", "crusader gorget - (lv.60)", 60.0, 80.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( CrusaderLeggings ), "Elite Types", "crusader leggings - (lv.60)", 60.0, 80.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( CrusaderSleeves ), "Elite Types", "crusader sleeves - (lv.60)", 60.0, 80.0, typeof( IronIngot ), 1044036, 23, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 7 regular leather", 7, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

////////////////////////// Elite Types //////////////////////////
////////////////////////// Demonscale (Lv.70)
index = AddCraft( typeof( DemonscaleArms ), "Elite Types", "demonscale arms - (lv.70)", 70.0, 90.0, typeof( IronIngot ), 1044036, 23, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 7 regular leather", 7, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( DemonscaleChest ), "Elite Types", "demonscale chest - (lv.70)", 70.0, 90.0, typeof( IronIngot ), 1044036, 30, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( DemonscaleGloves ), "Elite Types", "demonscale gloves - (lv.70)", 70.0, 90.0, typeof( IronIngot ), 1044036, 17, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( DemonscaleGorget ), "Elite Types", "demonscale gorget - (lv.70)", 70.0, 90.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( DemonscaleHelmet ), "Elite Types", "demonscale helmet - (lv.70)", 70.0, 90.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( DemonscaleLegs ), "Elite Types", "demonscale legs - (lv.70)", 70.0, 90.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

////////////////////////// Elite Types //////////////////////////
////////////////////////// Dragon (Lv.80)
index = AddCraft( typeof( DragonArms ),   "Elite Types", "dragon arms - (lv.80)", 80.0, 100.0, typeof( RedScales ), 1060883, 24, 1060884 );
	AddRes( index, typeof( Leather ), "Requires 7 regular leather", 7, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	SetUseSubRes2( index, true );

index = AddCraft( typeof( DragonChest ),  "Elite Types", "dragon chest - (lv.80)", 80.0, 100.0, typeof( RedScales ), 1060883, 36, 1060884 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
	SetUseSubRes2( index, true );

index = AddCraft( typeof( DragonGloves ), "Elite Types", "dragon gloves - (lv.80)", 80.0, 100.0, typeof( RedScales ), 1060883, 16, 1060884 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
	SetUseSubRes2( index, true );

index = AddCraft( typeof( DragonHelm ),   "Elite Types", "dragon helm - (lv.80)", 80.0, 100.0, typeof( RedScales ), 1060883, 20, 1060884 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	SetUseSubRes2( index, true );

index = AddCraft( typeof( DragonLegs ),   "Elite Types", "dragon legs - (lv.80)", 80.0, 100.0, typeof( RedScales ), 1060883, 28, 1060884 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	SetUseSubRes2( index, true );

////////////////////////// Shields //////////////////////////
////////////////////////// Shields (Lv.1)
index = AddCraft( typeof( Buckler ),            "Shields", "buckler - (lv.1)", -25.0, 25.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.6)
index = AddCraft( typeof( AmmoniteShield ),     "Shields", "ammonite shield - (lv.6)", 6.0, 26.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.9)
index = AddCraft( typeof( BronzeShield ),       "Shields", "bronze shield - (lv.9)", 9.0, 29.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.12)
index = AddCraft( typeof( MetalShield ),        "Shields", "metal shield - (lv.12)", 12.0, 32.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.15)
index = AddCraft( typeof( WoodenKiteShield ),   "Shields", "wooden kite shield - (lv.15)", 15.0, 35.0, typeof( IronIngot ), 1044036, 8, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.18)
index = AddCraft( typeof( MetalKiteShield ),    "Shields", "metal kite shield - (lv.18)", 18.0, 38.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.24)
index = AddCraft( typeof( InfantryShield ),     "Shields", "infantry shield - (lv.24)", 24.0, 44.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.27)
index = AddCraft( typeof( SpiderShield ),       "Shields", "spider shield - (lv.27)", 27.0, 47.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.33)
index = AddCraft( typeof( MercenaryShield ),    "Shields", "mercenary shield - (lv.33)", 33.0, 53.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.39)
index = AddCraft( typeof( ScarabShield ),       "Shields", "scarab shield - (lv.39)", 39.0, 59.0, typeof( IronIngot ), 1044036, 19, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.45)
index = AddCraft( typeof( UnicornShield ),      "Shields", "unicorn shield - (lv.45)", 45.0, 65.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.51)
index = AddCraft( typeof( WoodenDragonShield ), "Shields", "wooden dragon shield - (lv.51)", 51.0, 71.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.54)
index = AddCraft( typeof( ChaosShield ),        "Shields", "chaos shield - (lv.54)", 54.0, 74.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( OrderShield ),        "Shields", "order shield - (lv.54)", 54.0, 74.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.57)
index = AddCraft( typeof( HeaterShield ),       "Shields", "heater shield - (lv.57)", 57.0, 77.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields (Lv.60)
index = AddCraft( typeof( JewelShield ),        "Shields", "jewel shield - (lv.60)", 60.0, 80.0, typeof( IronIngot ), 1044036, 17, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
        AddRes( index, typeof( Diamond ), "Requires 1 diamond", 1, "Diamond" );

////////////////////////// Shields (Lv.70)
index = AddCraft( typeof( BlackHeaterShield ),  "Shields", "black heater shield - (lv.70)", 70.0, 90.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Runic Hammers
index= AddCraft( typeof( RunicDullCopper ), "Runic Hammers", "Runic Dull Copper", 70.0, 150.0, typeof( DullCopperIngot ), 1044036, 5);
index= AddCraft( typeof( RunicShadowIron ), "Runic Hammers", "Runic Shadow Iron", 75.0, 150.0, typeof( ShadowIronIngot ), 1044036, 5);
index= AddCraft( typeof( RunicCopper ),     "Runic Hammers", "Runic Copper", 80.0, 150.0, typeof( CopperIngot ), 1044036, 5);
index= AddCraft( typeof( RunicBronze ),     "Runic Hammers", "Runic Bronze", 85.0, 150.0, typeof( BronzeIngot ), 1044036, 5);
index= AddCraft( typeof( RunicGold ),       "Runic Hammers", "Runic Gold", 90.0, 150.0, typeof( GoldIngot ), 1044036, 5);
index= AddCraft( typeof( RunicAgapite ),    "Runic Hammers", "Runic Agapite", 95.0, 150.0, typeof( AgapiteIngot ), 1044036, 5);
index= AddCraft( typeof( RunicVerite ),     "Runic Hammers", "Runic Verite", 100.0, 150.0, typeof( VeriteIngot ), 1044036, 5);
index= AddCraft( typeof( RunicValorite ),   "Runic Hammers", "Runic Valorite", 105.0, 150.0, typeof( ValoriteIngot ), 1044036, 5);

			// Set the overridable material
			SetSubRes( typeof( IronIngot ), 1044022 );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes( typeof( IronIngot ),		1044022, 00.0, 1044036, 1044267 );
			AddSubRes( typeof( DullCopperIngot ),	1044023, 65.0, 1044036, 1044268 );
			AddSubRes( typeof( ShadowIronIngot ),	1044024, 70.0, 1044036, 1044268 );
			AddSubRes( typeof( CopperIngot ),		1044025, 75.0, 1044036, 1044268 );
			AddSubRes( typeof( BronzeIngot ),		1044026, 80.0, 1044036, 1044268 );
			AddSubRes( typeof( GoldIngot ),		1044027, 85.0, 1044036, 1044268 );
			AddSubRes( typeof( AgapiteIngot ),		1044028, 90.0, 1044036, 1044268 );
			AddSubRes( typeof( VeriteIngot ),		1044029, 95.0, 1044036, 1044268 );
			AddSubRes( typeof( ValoriteIngot ),		1044030, 99.0, 1044036, 1044268 );

			SetSubRes2( typeof( RedScales ), 1060875 );

			AddSubRes2( typeof( RedScales ),		1060875, 0.0, 1053137, 1044268 );
			AddSubRes2( typeof( YellowScales ),		1060876, 0.0, 1053137, 1044268 );
			AddSubRes2( typeof( BlackScales ),		1060877, 0.0, 1053137, 1044268 );
			AddSubRes2( typeof( GreenScales ),		1060878, 0.0, 1053137, 1044268 );
			AddSubRes2( typeof( WhiteScales ),		1060879, 0.0, 1053137, 1044268 );
			AddSubRes2( typeof( BlueScales ),		1060880, 0.0, 1053137, 1044268 );

			Resmelt = true;
			Repair = true;
			MarkOption = true;
			CanEnhance = Core.AOS;
		}
	}
}