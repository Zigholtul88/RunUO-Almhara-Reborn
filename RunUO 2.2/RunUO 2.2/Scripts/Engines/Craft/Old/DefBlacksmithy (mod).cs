using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefBlacksmithy : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Blacksmith;	}
		}

		public override int GumpTitleNumber
		{
			get { return 1044002; } // <CENTER>BLACKSMITHY MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefBlacksmithy();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefBlacksmithy() : base( 1, 1, 1.25 )// base( 1, 2, 1.7 )
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

		private static Type typeofAnvil = typeof( AnvilAttribute );
		private static Type typeofForge = typeof( ForgeAttribute );

		public static void CheckAnvilAndForge( Mobile from, int range, out bool anvil, out bool forge )
		{
			anvil = false;
			forge = false;

			Map map = from.Map;

			if ( map == null )
				return;

			IPooledEnumerable eable = map.GetItemsInRange( from.Location, range );

			foreach ( Item item in eable )
			{
				Type type = item.GetType();

				bool isAnvil = ( type.IsDefined( typeofAnvil, false ) || item.ItemID == 4015 || item.ItemID == 4016 || item.ItemID == 0x2DD5 || item.ItemID == 0x2DD6 );
				bool isForge = ( type.IsDefined( typeofForge, false ) || item.ItemID == 4017 || (item.ItemID >= 6522 && item.ItemID <= 6569) || item.ItemID == 0x2DD8 );

				if ( isAnvil || isForge )
				{
					if ( (from.Z + 16) < item.Z || (item.Z + 16) < from.Z || !from.InLOS( item ) )
						continue;

					anvil = anvil || isAnvil;
					forge = forge || isForge;

					if ( anvil && forge )
						break;
				}
			}

			eable.Free();

			for ( int x = -range; (!anvil || !forge) && x <= range; ++x )
			{
				for ( int y = -range; (!anvil || !forge) && y <= range; ++y )
				{
					StaticTile[] tiles = map.Tiles.GetStaticTiles( from.X+x, from.Y+y, true );

					for ( int i = 0; (!anvil || !forge) && i < tiles.Length; ++i )
					{
						int id = tiles[i].ID;

						bool isAnvil = ( id == 4015 || id == 4016 || id == 0x2DD5 || id == 0x2DD6 );
						bool isForge = ( id == 4017 || (id >= 6522 && id <= 6569) || id == 0x2DD8 );

						if ( isAnvil || isForge )
						{
							if ( (from.Z + 16) < tiles[i].Z || (tiles[i].Z + 16) < from.Z || !from.InLOS( new Point3D( from.X+x, from.Y+y, tiles[i].Z + (tiles[i].Height/2) + 1 ) ) )
								continue;

							anvil = anvil || isAnvil;
							forge = forge || isForge;
						}
					}
				}
			}
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
			CheckAnvilAndForge( from, 2, out anvil, out forge );

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

////////////////////////// Axes
index = AddCraft( typeof( Axe ), "Axes", 1023913, 53.8, 84.2, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 1 board", 1, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( BattleAxe ), "Axes", 1023911, 48.7, 80.5, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( DoubleAxe ), "Axes", 1023915, 47.1, 79.3, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 1 board", 1, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( EbonyBattleAxe ), "Axes", "ebony battle axe", 48.7, 80.5, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( EbonyGlassAxe ), "Axes", "ebony glass axe", 53.8, 84.2, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 1 board", 1, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( ExecutionersAxe ), "Axes", 1023909, 53.8, 84.2, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 1 board", 1, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( LargeBattleAxe ), "Axes", 1025115, 45.4, 78.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 1 board", 1, "Board" );
	AddRes( index, typeof( Leather ), "Requires 3 regular leather", 3, "Leather" );

index = AddCraft( typeof( OrnateAxe ), "Axes", 1031572, 70.0, 120.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 3 regular leather", 3, "Leather" );

index = AddCraft( typeof( TwoHandedAxe ), "Axes", 1025187, 52.0, 83.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( WarAxe ), "Axes", 1025040, 60.2, 89.1, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( GuardianAxe ), "Axes", 1073545, 75.0, 125.0, typeof( OrnateAxe ), "Requires 1 ornate axe", 1, "Ornate Axe" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( BlueDiamond ), 1032696, 1, 1044240 );

index = AddCraft( typeof( HeavyOrnateAxe ), "Axes", 1073548, 75.0, 125.0, typeof( OrnateAxe ), "Requires 1 ornate axe", 1, "Ornate Axe" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( Turquoise ), 1032691, 1, 1044240 );

index = AddCraft( typeof( SingingAxe ), "Axes", 1073546, 75.0, 125.0, typeof( OrnateAxe ), "Requires 1 ornate axe", 1, "Ornate Axe" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( BrilliantAmber ), 1032697, 1, 1044240 );

index = AddCraft( typeof( ThunderingAxe ), "Axes", 1073547, 75.0, 125.0, typeof( OrnateAxe ), "Requires 1 ornate axe", 1, "Ornate Axe" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( EcruCitrine ), 1032693, 1, 1044240 );

////////////////////////// Chainmail and Ringmail
index = AddCraft( typeof( ChainCoif ), "Chainmail and Ringmail", 1025051, 27.5, 64.5, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( ChainChest ), "Chainmail and Ringmail", 1025055, 43.8, 89.1, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 15 regular leather", 15, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( ChainLegs ), "Chainmail and Ringmail", 1025054, 40.5, 86.7, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 6 regular leather", 6, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( RingmailArms ), "Chainmail and Ringmail", 1025103, 24.3, 66.9, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 5 regular leather", 5, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( RingmailChest ), "Chainmail and Ringmail", 1025100, 30.7, 71.9, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 13 regular leather", 13, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( RingmailGloves ), "Chainmail and Ringmail", 1025099, 17.6, 62.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 1 regular leather", 1, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( RingmailLegs ), "Chainmail and Ringmail", 1025104, 27.5, 69.4, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 8 regular leather", 8, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

////////////////////////// Helmets
index = AddCraft( typeof( Bascinet ), "Helmets", 1025132, 19.2, 58.3, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( CloseHelm ), "Helmets", 1025128, 58.6, 87.9, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( Helmet ), "Helmets", 1025130, 58.6, 87.9, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( NorseHelm ), "Helmets", 1025134, 59.3, 87.9, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( PlateHelm ), "Helmets", 1025138, 58.6, 89.9, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( ChainHatsuburi ), "Helmets", 1030175, 30.0, 80.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( DecorativePlateKabuto ), "Helmets", 1030179, 45.0, 95.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( LightPlateJingasa ), "Helmets", 1030188, 45.0, 95.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( HeavyPlateJingasa ), "Helmets", 1030178, 45.0, 95.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( PlateBattleKabuto ), "Helmets", 1030192, 90.0, 95.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( PlateHatsuburi ), "Helmets", 1030176, 45.0, 95.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( SmallPlateJingasa ), "Helmets", 1030191, 45.0, 95.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( StandardPlateKabuto ), "Helmets", 1030196, 90.0, 95.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( Circlet ), "Helmets", 1032645, 62.1, 100.0, typeof( IronIngot ), 1044036, 6, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( Tourmaline ), 1044237, 1, 1044240 );

index = AddCraft( typeof( RoyalCirclet ), "Helmets", 1032646, 70.0, 100.0, typeof( IronIngot ), 1044036, 6, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( Amethyst ), 1044236, 1, 1044240 );

index = AddCraft( typeof( GemmedCirclet ), "Helmets", 1032647, 75.0, 100.0, typeof( IronIngot ), 1044036, 6, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	AddRes( index, typeof( Tourmaline ), 1044237, 1, 1044240 );
	AddRes( index, typeof( Amethyst ), 1044236, 1, 1044240 );
        AddRes( index, typeof( Diamond ), "Requires 1 diamond", 1, "Diamond" );

index = AddCraft( typeof( ElvenPlateHelm ), "Helmets", "elven plate helm", 58.6, 87.9, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( DemonscaleHelmet ), "Helmets", "demonscale helmet", 85.0, 99.5, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

////////////////////////// Maces and Hammers
index = AddCraft( typeof( DiamondMace ), "Maces and Hammers", "diamond mace", 30.5, 85.2, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
        AddRes( index, typeof( Diamond ), "Requires 1 diamond", 1, "Diamond" );

index = AddCraft( typeof( EbonyMorningstar ), "Maces and Hammers", "ebony morningstar", 45.4, 78.0, typeof( IronIngot ), 1044036, 22, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( EbonyWarMace ), "Maces and Hammers", "ebony war mace", 49.9, 83.5, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( HammerPick ), "Maces and Hammers", 1025181, 42.2, 84.2, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Mace ), "Maces and Hammers", 1023932, 27.5, 64.5, typeof( IronIngot ), 1044036, 6, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Maul ), "Maces and Hammers", 1025179, 33.9, 69.4, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Scepter ), "Maces and Hammers", 1029916, 21.4, 71.4, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Tessen ), "Maces and Hammers", 1030222, 85.0, 135.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddSkill( index, SkillName.Tailoring, 50.0, 55.0 );
	AddRes( index, typeof( Cloth ), 1044286, 10, 1044287 );

index = AddCraft( typeof( WarHammer ), "Maces and Hammers", 1025177, 53.8, 84.2, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( WarMace ), "Maces and Hammers", 1025127, 45.4, 78.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( EmeraldMace ), "Maces and Hammers", 1073530, 75.0, 125.0, typeof( DiamondMace ), "Requires 1 diamond mace", 1, "Diamond Mace" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( PerfectEmerald ), 1032692, 1, 1044240 );

index = AddCraft( typeof( RubyMace ), "Maces and Hammers", 1073529, 75.0, 125.0, typeof( DiamondMace ), "Requires 1 diamond mace", 1, "Diamond Mace" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( FireRuby ), 1032695, 1, 1044240 );

index = AddCraft( typeof( SapphireMace ), "Maces and Hammers", 1073531, 75.0, 125.0, typeof( DiamondMace ), "Requires 1 diamond mace", 1, "Diamond Mace" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( DarkSapphire ), 1032690, 1, 1044240 );

index = AddCraft( typeof( SilverEtchedMace ), "Maces and Hammers", 1073532, 75.0, 125.0, typeof( DiamondMace ), "Requires 1 diamond mace", 1, "Diamond Mace" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( BlueDiamond ), 1032696, 1, 1044240 );

////////////////////////// Platemail
index = AddCraft( typeof( FemalePlateChest ),   "Platemail", 1046430, 43.8, 94.1, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( PlateChest ),         "Platemail", 1046431, 75.0, 95.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( PlateArms ),          "Platemail", 1025136, 63.5, 93.3, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 7 regular leather", 7, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( PlateGloves ),        "Platemail", 1025140, 53.7, 91.9, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( PlateGorget ),        "Platemail", 1025139, 50.4, 92.4, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( PlateLegs ),          "Platemail", 1025137, 66.8, 94.8, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( PlateMempo ), "Platemail", 1030180, 80.0, 130.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( PlateDo ), "Platemail", 1030184, 80.0, 130.0, typeof( IronIngot ), 1044036, 28, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( PlateHiroSode ), "Platemail", 1030187, 80.0, 130.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 7 regular leather", 7, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( PlateSuneate ), "Platemail", 1030195, 65.0, 115.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( PlateHaidate ), "Platemail", 1030200, 65.0, 115.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( ElvenPlateArms ), "Platemail", "elven plate arms", 70.0, 90.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 7 regular leather", 7, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( ElvenPlateChest ), "Platemail", "elven plate chest", 70.0, 90.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( ElvenPlateLegs ), "Platemail", "elven plate legs", 70.0, 90.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( DemonscaleArms ), "Platemail", "demonscale arms", 85.0, 99.5, typeof( IronIngot ), 1044036, 23, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 7 regular leather", 7, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( DemonscaleChest ), "Platemail", "demonscale chest", 85.0, 99.5, typeof( IronIngot ), 1044036, 30, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( DemonscaleGloves ), "Platemail", "demonscale gloves", 85.0, 99.5, typeof( IronIngot ), 1044036, 17, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( DemonscaleGorget ), "Platemail", "demonscale gorget", 85.0, 99.5, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( DemonscaleLegs ), "Platemail", "demonscale legs", 85.0, 99.5, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

////////////////////////// Pole Arms
index = AddCraft( typeof( Bardiche ), "Pole Arms", 1023917, 50.4, 81.7, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( EbonyGlassBardiche ), "Pole Arms", "ebony glass bardiche", 55.6, 84.4, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Halberd ), "Pole Arms", 1025183, 60.2, 89.1, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Scythe ), "Pole Arms", 1029914, 39.0, 89.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Shields
index = AddCraft( typeof( AmmoniteShield ),     "Shields", "ammonite shield", 25.7, 74.4, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( BronzeShield ),       "Shields", 1027026, 1.0, 34.8, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( BlackHeaterShield ),  "Shields", "black heater shield", 50.5, 82.6, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Buckler ),            "Shields", 1027027, 1.0, 25.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( HeaterShield ),       "Shields", 1027030, 40.5, 74.3, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( InfantryShield ),     "Shields", "infantry shield", 23.2, 62.1, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( JewelShield ),        "Shields", "jewel shield", 32.9, 73.3, typeof( IronIngot ), 1044036, 17, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
        AddRes( index, typeof( Diamond ), "Requires 1 diamond", 1, "Diamond" );

index = AddCraft( typeof( MercenaryShield ),    "Shields", "mercenary shield", 45.8, 76.7, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( MetalShield ),        "Shields", 1027035, 0.0, 39.8, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( MetalKiteShield ),    "Shields", 1027028, 14.3, 54.6, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( ScarabShield ),       "Shields", "scarab shield", 57.6, 82.1, typeof( IronIngot ), 1044036, 19, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( SpiderShield ),       "Shields", "spider shield", 41.2, 79.7, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( UnicornShield ),      "Shields", "unicorn shield", 63.4, 89.2, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( WoodenDragonShield ), "Shields", "wooden dragon shield", 21.6, 68.1, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( WoodenKiteShield ),   "Shields", 1027032, 0.0, 34.8, typeof( IronIngot ), 1044036, 8, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( ChaosShield ),        "Shields", 1027107, 85.0, 135.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( OrderShield ),        "Shields", 1027108, 85.0, 135.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Spears and Forks
index = AddCraft( typeof( EbonyBattleSpear ), "Spears and Forks", "ebony battle spear", 77.6, 96.7, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( ShortSpear ), "Spears and Forks", 1025123, 68.4, 95.3, typeof( IronIngot ), 1044036, 6, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Spear ), "Spears and Forks", 1023938, 73.2, 92.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( WarFork ), "Spears and Forks", 1025125, 58.6, 92.9, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( DoubleBladedStaff ), "Spears and Forks", 1029919, 45.0, 95.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Pike ), "Spears and Forks", 1029918, 47.0, 97.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Swords and Blades
index = AddCraft( typeof( Cutlass ), "Swords and Blades", 1025185, 40.5, 74.3, typeof( IronIngot ), 1044036, 8, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Dagger ), "Swords and Blades", 1023921, -25.0, 49.6, typeof( IronIngot ), 1044036, 3, 1044037 );
	AddRes( index, typeof( Board ), "Requires 1 board", 1, "Board" );
	AddRes( index, typeof( Leather ), "Requires 1 regular leather", 1, "Leather" );

index = AddCraft( typeof( Katana ), "Swords and Blades", 1025119, 66.8, 94.1, typeof( IronIngot ), 1044036, 8, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Kryss ), "Swords and Blades", 1025121, 56.8, 86.7, typeof( IronIngot ), 1044036, 8, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Longsword ), "Swords and Blades", 1023937, 45.4, 78.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Scimitar ), "Swords and Blades", 1025046, 50.4, 81.7, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( VikingSword ), "Swords and Blades", 1025049, 40.5, 74.3, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( BladedStaff ), "Swords and Blades", 1029917, 40.0, 90.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( BoneHarvester ), "Swords and Blades", 1029915, 33.0, 83.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( CrescentBlade ), "Swords and Blades", 1029921, 45.0, 95.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Lance ), "Swords and Blades", 1029920, 48.0, 98.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Daisho ), "Swords and Blades", 1030228, 60.0, 110.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Kama ), "Swords and Blades", 1030232, 40.0, 90.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Lajatang ), "Swords and Blades", 1030226, 80.0, 115.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( NoDachi ), "Swords and Blades", 1030221, 75.0, 115.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Sai ), "Swords and Blades", 1030234, 50.0, 100.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

AddCraft( typeof( Shuriken ), "Swords and Blades", 1030231, 45.0, 95.0, typeof( IronIngot ), 1044036, 5, 1044037 );

index = AddCraft( typeof( Tekagi ), "Swords and Blades", 1030230, 55.0, 105.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Wakizashi ), "Swords and Blades", 1030223, 50.0, 100.0, typeof( IronIngot ), 1044036, 8, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( AssassinSpike ), "Swords and Blades", 1031565, 18.1, 53.4, typeof( IronIngot ), 1044036, 9, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( ElvenMachete ), "Swords and Blades", 1031573, 45.4, 78.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( ElvenSpellblade ), "Swords and Blades", 1031564, 55.5, 85.4, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Leafblade ), "Swords and Blades", 1031566, -25.0, 49.6, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( RadiantScimitar ), "Swords and Blades", 1031571, 50.4, 81.7, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( RuneBlade ), "Swords and Blades", 1031570, 31.7, 49.8, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( WarCleaver ), "Swords and Blades", 1031567, 41.3, 62.5, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( EbonyDagger ), "Swords and Blades", "ebony dagger", -25.0, 49.6, typeof( IronIngot ), 1044036, 3, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( EbonyDualDaggers ), "Swords and Blades", "ebony dual daggers", 15.0, 50.0, typeof( IronIngot ), 1044036, 6, 1044037 );
	AddRes( index, typeof( Board ), "Requires 6 board", 6, "Board" );
	AddRes( index, typeof( Leather ), "Requires 4 regular leather", 4, "Leather" );

index = AddCraft( typeof( EbonyDualKatanas ), "Swords and Blades", "ebony dual katanas", 60.0, 110.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 6 board", 6, "Board" );
	AddRes( index, typeof( Leather ), "Requires 4 regular leather", 4, "Leather" );

index = AddCraft( typeof( EbonyMoonblade ), "Swords and Blades", "ebony moonblade", 55.5, 85.4, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( EbonyRapier ), "Swords and Blades", "ebony rapier", 56.8, 86.7, typeof( IronIngot ), 1044036, 9, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( EbonyScimitar ), "Swords and Blades", "ebony scimitar", 50.4, 81.7, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( AdventurersMachete ), "Swords and Blades", 1073533, 75.0, 125.0, typeof( ElvenMachete ), "Requires 1 elven machete", 1, "Elven Machete" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( WhitePearl ), 1032694, 1, 1044240 );

index = AddCraft( typeof( ChargedAssassinSpike ), "Swords and Blades", 1073518, 75.0, 125.0, typeof( AssassinSpike ), "Requires 1 assassin spike", 1, "Assassin Spike" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( EcruCitrine ), 1032693, 1, 1044240 );

index = AddCraft( typeof( CorruptedRuneBlade ), "Swords and Blades", 1073540, 75.0, 125.0, typeof( RuneBlade ), "Requires 1 runeblade", 1, "Rune Blade" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( Corruption ), 1072135, 1, 1042081 );

index = AddCraft( typeof( DarkglowScimitar ), "Swords and Blades", 1073542, 75.0, 125.0, typeof( RadiantScimitar ), "Requires 1 radiant scimitar", 1, "Radiant Scimitar" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( DarkSapphire ), 1032690, 1, 1044240 );

index = AddCraft( typeof( DiseasedMachete ), "Swords and Blades", 1073536, 75.0, 125.0, typeof( ElvenMachete ), "Requires 1 elven machete", 1, "Elven Machete" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( Blight ), 1072134, 1, 1042081 );

index = AddCraft( typeof( FierySpellblade ), "Swords and Blades", 1073515, 75.0, 125.0, typeof( ElvenSpellblade ), "Requires 1 elven spellblade", 1, "Elven Spellblade" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( FireRuby ), 1032695, 1, 1044240 );

index = AddCraft( typeof( IcyScimitar ), "Swords and Blades", 1073543, 75.0, 125.0, typeof( RadiantScimitar ), "Requires 1 radiant scimitar", 1, "Radiant Scimitar" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( DarkSapphire ), 1032690, 1, 1044240 );

index = AddCraft( typeof( IcySpellblade ), "Swords and Blades", 1073514, 75.0, 125.0, typeof( ElvenSpellblade ), "Requires 1 elven spellblade", 1, "Elven Spellblade" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( Turquoise ), 1032691, 1, 1044240 );

index = AddCraft( typeof( KnightsWarCleaver ), "Swords and Blades", 1073525, 75.0, 125.0, typeof( WarCleaver ), "Requires 1 war cleaver", 1, "War Cleaver" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( PerfectEmerald ), 1032692, 1, 1044240 );

index = AddCraft( typeof( LeafbladeOfEase ), "Swords and Blades", 1073524, 75.0, 125.0, typeof( Leafblade ), "Requires 1 leafblade", 1, "Leafblade" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( PerfectEmerald ), 1032692, 1, 1044240 );

index = AddCraft( typeof( Luckblade ), "Swords and Blades", 1073522, 75.0, 125.0, typeof( Leafblade ), "Requires 1 leafblade", 1, "Leafblade" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( WhitePearl ), 1032694, 1, 1044240 );

index = AddCraft( typeof( MacheteOfDefense ), "Swords and Blades", 1073535, 75.0, 125.0, typeof( ElvenMachete ), "Requires 1 elven machete", 1, "Elven Machete" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( BrilliantAmber ), 1032697, 1, 1044240 );

index = AddCraft( typeof( MagekillerAssassinSpike ), "Swords and Blades", 1073519, 75.0, 125.0, typeof( AssassinSpike ), "Requires 1 assassin spike", 1, "Assassin Spike" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( BrilliantAmber ), 1032697, 1, 1044240 );

index = AddCraft( typeof( MagekillerLeafblade ), "Swords and Blades", 1073523, 75.0, 125.0, typeof( Leafblade ), "Requires 1 leafblade", 1, "Leafblade" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( FireRuby ), 1032695, 1, 1044240 );

index = AddCraft( typeof( MagesRuneBlade ), "Swords and Blades", 1073538, 75.0, 125.0, typeof( RuneBlade ), "Requires 1 runeblade", 1, "Rune Blade" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( BlueDiamond ), 1032696, 1, 1044240 );

index = AddCraft( typeof( OrcishMachete ), "Swords and Blades", 1073534, 75.0, 125.0, typeof( ElvenMachete ), "Requires 1 elven machete", 1, "Elven Machete" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( Scourge ), 1072136, 1, 1042081 );

index = AddCraft( typeof( RuneBladeOfKnowledge ), "Swords and Blades", 1073539, 75.0, 125.0, typeof( RuneBlade ), "Requires 1 runeblade", 1, "Rune Blade" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( EcruCitrine ), 1032693, 1, 1044240 );

index = AddCraft( typeof( Runesabre ), "Swords and Blades", 1073537, 75.0, 125.0, typeof( RuneBlade ), "Requires 1 runeblade", 1, "Rune Blade" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( Turquoise ), 1032691, 1, 1044240 );

index = AddCraft( typeof( SerratedWarCleaver ), "Swords and Blades", 1073527, 75.0, 125.0, typeof( WarCleaver ), "Requires 1 war cleaver", 1, "War Cleaver" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( EcruCitrine ), 1032693, 1, 1044240 );

index = AddCraft( typeof( SpellbladeOfDefense ), "Swords and Blades", 1073516, 75.0, 125.0, typeof( ElvenSpellblade ), "Requires 1 elven spellblade", 1, "Elven Spellblade" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( WhitePearl ), 1032694, 1, 1044240 );

index = AddCraft( typeof( TrueAssassinSpike ), "Swords and Blades", 1073517, 75.0, 125.0, typeof( AssassinSpike ), "Requires 1 assassin spike", 1, "Assassin Spike" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( DarkSapphire ), 1032690, 1, 1044240 );

index = AddCraft( typeof( TrueLeafblade ), "Swords and Blades", 1073521, 75.0, 125.0, typeof( Leafblade ), "Requires 1 leafblade", 1, "Leafblade" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( BlueDiamond ), 1032696, 1, 1044240 );

index = AddCraft( typeof( TrueRadiantScimitar ), "Swords and Blades", 1073541, 75.0, 125.0, typeof( RadiantScimitar ), "Requires 1 radiant scimitar", 1, "Radiant Scimitar" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( BrilliantAmber ), 1032697, 1, 1044240 );

index = AddCraft( typeof( TrueSpellblade ), "Swords and Blades", 1073513, 75.0, 125.0, typeof( ElvenSpellblade ), "Requires 1 elven spellblade", 1, "Elven Spellblade" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( BlueDiamond ), 1032696, 1, 1044240 );

index = AddCraft( typeof( TrueWarCleaver ), "Swords and Blades", 1073528, 75.0, 125.0, typeof( WarCleaver ), "Requires 1 war cleaver", 1, "War Cleaver" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( BrilliantAmber ), 1032697, 1, 1044240 );

index = AddCraft( typeof( TwinklingScimitar ), "Swords and Blades", 1073544, 75.0, 125.0, typeof( RadiantScimitar ), "Requires 1 radiant scimitar", 1, "Radiant Scimitar" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( DarkSapphire ), 1032690, 1, 1044240 );

index = AddCraft( typeof( WoundingAssassinSpike ), "Swords and Blades", 1073520, 75.0, 125.0, typeof( AssassinSpike ), "Requires 1 assassin spike", 1, "Assassin Spike" );
	AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );
	AddRes( index, typeof( PerfectEmerald ), 1032692, 1, 1044240 );

////////////////////////// Special Armor
index = AddCraft( typeof( CrusaderBreastplate ), "Special Armor", "crusader breastplate", 75.0, 95.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddSkill( index, SkillName.Swords, 25.0, 50.0 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( CrusaderGauntlets ), "Special Armor", "crusader gauntlets", 75.0, 95.0, typeof( IronIngot ), 1044036, 17, 1044037 );
	AddSkill( index, SkillName.Swords, 25.0, 50.0 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( CrusaderGorget ), "Special Armor", "crusader gorget", 75.0, 95.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddSkill( index, SkillName.Swords, 25.0, 50.0 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );

index = AddCraft( typeof( CrusaderLeggings ), "Special Armor", "crusader leggings", 75.0, 95.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddSkill( index, SkillName.Swords, 25.0, 50.0 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );

index = AddCraft( typeof( CrusaderSleeves ), "Special Armor", "crusader sleeves", 75.0, 95.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddSkill( index, SkillName.Swords, 25.0, 50.0 );
	AddRes( index, typeof( Leather ), "Requires 7 regular leather", 7, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );

index = AddCraft( typeof( DragonArms ),   "Special Armor", 1029815, 76.3, 105.0, typeof( RedScales ), 1060883, 24, 1060884 );
	AddRes( index, typeof( Leather ), "Requires 7 regular leather", 7, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 2 spools of thread", 2, "Spool of Thread" );
	SetUseSubRes2( index, true );

index = AddCraft( typeof( DragonChest ),  "Special Armor", 1029793, 85.0, 105.0, typeof( RedScales ), 1060883, 36, 1060884 );
	AddRes( index, typeof( Leather ), "Requires 19 regular leather", 19, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
	SetUseSubRes2( index, true );

index = AddCraft( typeof( DragonGloves ), "Special Armor", 1029795, 68.9, 105.0, typeof( RedScales ), 1060883, 16, 1060884 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 4 spools of thread", 4, "Spool of Thread" );
	SetUseSubRes2( index, true );

index = AddCraft( typeof( DragonHelm ),   "Special Armor", 1029797, 72.6, 105.0, typeof( RedScales ), 1060883, 20, 1060884 );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	SetUseSubRes2( index, true );

index = AddCraft( typeof( DragonLegs ),   "Special Armor", 1029799, 78.8, 105.0, typeof( RedScales ), 1060883, 28, 1060884 );
	AddRes( index, typeof( Leather ), "Requires 10 regular leather", 10, "Leather" );
	AddRes( index, typeof( SpoolOfThread ), "Requires 3 spools of thread", 3, "Spool of Thread" );
	SetUseSubRes2( index, true );

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

	public class ForgeAttribute : Attribute
	{
		public ForgeAttribute()
		{
		}
	}

	public class AnvilAttribute : Attribute
	{
		public AnvilAttribute()
		{
		}
	}
}