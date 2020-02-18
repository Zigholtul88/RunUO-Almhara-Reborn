using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefWandsystem : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Blacksmith;	}
		}

		public override string GumpTitleString
		{
			get { return "<basefont color=#FFFFFF><CENTER>Wandcrafting MENU</CENTER></basefont>"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefWandsystem();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefWandsystem() : base( 1, 1, 1.25 )// base( 1, 2, 1.7 )
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

            int index = -1;

			
		//Magic Wands
                      index= AddCraft( typeof( ClumsyWand ), "Magic Wands First", "ClumsyWand", 10.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( CreateFoodWand ), "Magic Wands First", "CreateFoodWand", 10.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( FeebleWand ), "Magic Wands First", "FeebleWand", 10.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( HealWand ), "Magic Wands First", "HealWand", 10.0, 130.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( MagicArrowWand ), "Magic Wands First", "MagicArrowWand", 10.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( NightSightWand ), "Magic Wands First", "NightSightWand", 10.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( ReactiveArmorWand ), "Magic Wands First", "ReactiveArmorWand", 10.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( WeaknessWand ), "Magic Wands First", "WeaknessWand", 10.0, 100.0, typeof( IronIngot ), 1044036, 10);

                      index= AddCraft( typeof( AgilityWand ), "Magic Wands Second", "AgilityWand", 20.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( CunningWand ), "Magic Wands Second", "CunningWand", 20.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( CureWand ), "Magic Wands Second", "CureWand", 20.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( HarmWand ), "Magic Wands Second", "HarmWand", 20.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( MagicTrapWand ), "Magic Wands Second", "MagicTrapWand", 20.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( ProtectionWand ), "Magic Wands Second", "ProtectionWand", 20.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( RemoveTrapWand ), "Magic Wands Second", "RemoveTrapWand", 20.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( StrengthWand ), "Magic Wands Second", "StrengthWand", 20.0, 100.0, typeof( IronIngot ), 1044036, 10);

                      index= AddCraft( typeof( BlessWand ), "Magic Wands Third", "BlessWand", 30.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( FireballWand ), "Magic Wands Third", "FireballWand", 30.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( MagicLockWand ), "Magic Wands Third", "MagicLockWand", 30.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( PoisonWand ), "Magic Wands Third", "PoisonWand", 30.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( TelekinesisWand ), "Magic Wands Third", "TelekinesisWand", 30.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( TeleportWand ), "Magic Wands Third", "TeleportWand", 30.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( UnlockWand ), "Magic Wands Third", "UnlockWand", 30.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( WallOfStoneWand ), "Magic Wands Third", "WallOfStoneWand", 30.0, 100.0, typeof( IronIngot ), 1044036, 10);

                      index= AddCraft( typeof( ArchCureWand ), "Magic Wands Fourth", "ArchCureWand", 40.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( ArchProtectionWand), "Magic Wands Fourth", "ArchProtectionWand", 40.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( CurseWand ), "Magic Wands Fourth", "CurseWand", 40.0, 100.0, typeof( IronIngot ), "1044036", 10);
                      index= AddCraft( typeof( FireFieldWand ), "Magic Wands Fourth", "FireFieldWand", 40.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( GreaterHealWand ), "Magic Wands Fourth", "GreaterHealWand", 40.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( LightningWand), "Magic Wands Fourth", "LightningWand", 40.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( ManaDrainWand ), "Magic Wands Fourth", "ManaDrainWand", 40.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( RecallWand ), "Magic Wands Fourth", "RecallWand", 40.0, 100.0, typeof( IronIngot ), 1044036, 10);

                      index= AddCraft( typeof( BladeSpiritsWand ), "Magic Wands Fifth", "BladeSpiritsWand", 50.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( DispelFieldWand ), "Magic Wands Fifth", "DispelFieldWand", 50.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( IncognitoWand ), "Magic Wands Fifth", "IncognitoWand", 50.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( MagicReflectWand ), "Magic Wands Fifth", "MagicReflectWand", 50.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( MindBlastWand ), "Magic Wands Fifth", "MindBlastWand", 50.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( ParalyzeWand ), "Magic Wands Fifth", "ParalyzeWand", 50.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( PoisonFieldWand ), "Magic Wands Fifth", "PoisonFieldWand", 50.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( SummonCreatureWand ), "Magic Wands Fifth", "SummonCreatureWand", 50.0, 100.0, typeof( IronIngot ), 1044036, 10);

                      index= AddCraft( typeof( DispelWand ), "Magic Wands Sixth","DispelWand", 60.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( EnergyBoltWand ), "Magic Wands Sixth", "EnergyBoltWand", 60.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( ExplosionWand ), "Magic Wands Sixth", "ExplosionWand", 60.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( InvisibilityWand ), "Magic Wands Sixth", "InvisibilityWand", 60.0, 100.0, typeof( IronIngot ), 1044036, 10); 
                      index= AddCraft( typeof( MarkWand ), "Magic Wands Sixth", "MarkWand", 60.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( MassCurseWand ), "Magic Wands Sixth", "MassCurseWand", 60.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( ParalyzeFieldWand ), "Magic Wands Sixth", "ParalyzeFieldWand", 60.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( RevealWand ), "Magic Wands Sixth", "RevealWand", 60.0, 100.0, typeof( IronIngot ), 1044036, 10); 

                      index= AddCraft( typeof( ChainLightningWand ), "Magic Wands Seventh", "ChainLightningWand", 70.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( EnergyFieldWand ), "Magic Wands Seventh", "EnergyFieldWand", 70.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( FlameStrikeWand ), "Magic Wands Seventh", "FlameStrikeWand", 70.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( GateTravelWand ), "Magic Wands Seventh", "GateTravelWand", 70.0, 100.0, typeof( IronIngot ), 1044036, 10); 
                      index= AddCraft( typeof( ManaVampireWand ), "Magic Wands Seventh", "ManaVampireWand", 70.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( MassDispelWand ), "Magic Wands Seventh", "MassDispelWand", 70.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( MeteorSwarmWand ), "Magic Wands Seventh", "MeteorSwarmWand", 70.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( PolymorphWand ), "Magic Wands Seventh", "PolymorphWand", 70.0, 100.0, typeof( IronIngot ), 1044036, 10); 

                      index= AddCraft( typeof( AirElementalWand ), "Magic Wands Eighth", "AirElementalWand", 80.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( EarthElementalWand ), "Magic Wands Eighth", "EarthElementalWand", 80.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( EarthquakeWand ), "Magic Wands Eighth", "EarthquakeWand", 80.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( EnergyVortexWand ), "Magic Wands Eighth", "EnergyVortexWand", 80.0, 100.0, typeof( IronIngot ), 1044036, 10); 
                      index= AddCraft( typeof( FireElementalWand ), "Magic Wands Eighth", "FireElementalWand", 80.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( ResurrectionWand ), "Magic Wands Eighth", "ResurrectionWand", 80.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( SummonDaemonWand ), "Magic Wands Eighth", "SummonDaemonWand", 80.0, 100.0, typeof( IronIngot ), 1044036, 10);
                      index= AddCraft( typeof( WaterElementalWand ), "Magic Wands Eighth", "WaterElementalWand", 80.0, 100.0, typeof( IronIngot ), 1044036, 10); 

                      index= AddCraft( typeof( AncientFireworksWand ), "Magic Wands Special", "AncientFireworksWand", 95.0, 100.0, typeof( IronIngot ), 1044036, 10); 
                      index= AddCraft( typeof( FireworksWand ), "Magic Wands Special", "FireworksWand", 95.0, 100.0, typeof( IronIngot ), 1044036, 10); 
                      
               
                        
		



			// Set the overidable material
			SetSubRes( typeof( IronIngot ), 1044022 );

			// Add every material you want the player to be able to chose from
			// This will overide the overidable material
			AddSubRes( typeof( IronIngot ),			1044022, 00.0, 1044036, 1044267 );
			AddSubRes( typeof( DullCopperIngot ),	1044023, 65.0, 1044036, 1044268 );
			AddSubRes( typeof( ShadowIronIngot ),	1044024, 70.0, 1044036, 1044268 );
			AddSubRes( typeof( CopperIngot ),		1044025, 75.0, 1044036, 1044268 );
			AddSubRes( typeof( BronzeIngot ),		1044026, 80.0, 1044036, 1044268 );
			AddSubRes( typeof( GoldIngot ),			1044027, 85.0, 1044036, 1044268 );
			AddSubRes( typeof( AgapiteIngot ),		1044028, 90.0, 1044036, 1044268 );
			AddSubRes( typeof( VeriteIngot ),		1044029, 95.0, 1044036, 1044268 );
			AddSubRes( typeof( ValoriteIngot ),		1044030, 99.0, 1044036, 1044268 );

			

			Resmelt = true;
			Repair = true;
			MarkOption = true;
			CanEnhance = Core.AOS;
		}
	}

	public class ForgeAttribute2 : Attribute
	{
		public ForgeAttribute2()
		{
		}
	}

	public class AnvilAttribute2 : Attribute
	{
		public AnvilAttribute2()
		{
		}
	}
}