using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefGemCrafting : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Imbuing;	}
		}

		public override string GumpTitleString
		{
			get { return "<basefont color=#FFFFFF><CENTER>Gem Crafting MENU</CENTER></basefont>"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefGemCrafting();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefGemCrafting() : base( 1, 1, 1.25 )// base( 1, 2, 1.7 )
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
				m_From.PlaySound( 245 ); // sfx01
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

                  ///////////////////// Elemental Resists
			index = AddCraft( typeof( CrackedResistColdGem ),      "Elemental Resists", "CrackedResistColdGem", 5.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( ElementalDust ), "Requires 1 elemental dust", 1, "Elemental Dust" );
			AddRes( index, typeof( IceStone ), "Requires 1 ice stone", 1, "Ice Stone" );

			index = AddCraft( typeof( CrackedResistFireGem ),      "Elemental Resists", "CrackedResistFireGem", 5.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( ElementalDust ), "Requires 1 elemental dust", 1, "Elemental Dust" );
                        AddRes( index, typeof( FireStone ), "Requires 1 fire stone", 1, "Fire Stone" );

			index = AddCraft( typeof( CrackedResistEnergyGem ),    "Elemental Resists", "CrackedResistEnergyGem", 5.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( ElementalDust ), "Requires 1 elemental dust", 1, "Elemental Dust" );
			AddRes( index, typeof( EnergyStone ), "Requires 1 energy stone", 1, "Energy Stone" );

			index = AddCraft( typeof( CrackedResistPoisonGem ),    "Elemental Resists", "CrackedResistPoisonGem", 5.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( ElementalDust ), "Requires 1 elemental dust", 1, "Elemental Dust" );
			AddRes( index, typeof( EarthStone ), "Requires 1 earth stone", 1, "Earth Stone" );

                  ///////////////////// Hit Attacks
			index = AddCraft( typeof( CrackedHitFireballGem ),     "Hit Attacks", "CrackedHitFireballGem", 25.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( CharredFeather ), "Requires 5 charred feathers", 5, "Charred Feather" );

			index = AddCraft( typeof( CrackedHitHarmGem ),         "Hit Attacks", "CrackedHitHarmGem", 15.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( DiamondDust ), "Requires 5 diamond dust", 5, "Diamond Dust" );

			index = AddCraft( typeof( CrackedHitLeechHitsGem ),    "Hit Attacks", "CrackedHitLeechHitsGem", 5.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( Bonemeal ), "Requires 5 bonemeal", 5, "Bonemeal" );

			index = AddCraft( typeof( CrackedHitLeechManaGem ),    "Hit Attacks", "CrackedHitLeechManaGem", 5.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( LichDust ), "Requires 5 lich dust", 5, "Lich Dust" );

			index = AddCraft( typeof( CrackedHitLeechStamGem ),    "Hit Attacks", "CrackedHitLeechStamGem", 5.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( ShadowEssence ), "Requires 5 shadow essence", 5, "Shadow Essence" );

			index = AddCraft( typeof( CrackedHitLightningGem ),   "Hit Attacks", "CrackedHitLightningGem", 5.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( ThunderStone ), "Requires 5 thunder stones", 5, "Thunder Stone" );

			index = AddCraft( typeof( CrackedHitMagicArrowGem ),   "Hit Attacks", "CrackedHitMagicArrowGem", 5.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( ArcaneStone ), "Requires 5 arcane stones", 5, "Arcane Stone" );

                  ///////////////////// Regen Speed
			index = AddCraft( typeof( CrackedHPRegenGem ),         "Regen Speed", "CrackedHPRegenGem", -25.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( BeetleEgg ), "Requires 5 beetle eggs", 5, "Beetle Egg" );

			index = AddCraft( typeof( CrackedManaRegenGem ),       "Regen Speed", "CrackedManaRegenGem", -25.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( SpiderEgg ), "Requires 5 spider eggs", 5, "Spider Egg" );

			index = AddCraft( typeof( CrackedStamRegenGem ),       "Regen Speed", "CrackedStamRegenGem", -25.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( Nirnroot ), "Requires 5 nirnroots", 5, "Nirnroot" );

                  ///////////////////// Spellcasting Mods
			index = AddCraft( typeof( CrackedSpellDamageGem ),     "Spellcasting Mods", "CrackedSpellDamageGem", 5.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( DragonScale ), "Requires 5 dragon scales", 5, "Dragon Scale" );

                  ///////////////////// Stat Bonus
			index = AddCraft( typeof( CrackedDexBonusGem ),        "Stat Bonus", "CrackedDexBonusGem", 15.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( BronzeGear ), "Requires 5 bronze gears", 5, "Bronze Gear" );

			index = AddCraft( typeof( CrackedIntBonusGem ),        "Stat Bonus", "CrackedIntBonusGem", 15.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( CrimsonGear ), "Requires 5 crimson gears", 5, "Crimson Gear" );

			index = AddCraft( typeof( CrackedStrBonusGem ),        "Stat Bonus", "CrackedStrBonusGem", 15.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( BlackGear ), "Requires 5 black gears", 5, "Black Gear" );

                  ///////////////////// Weapon Mods
			index = AddCraft( typeof( CrackedAttackChanceGem ),    "Weapon Mods", "CrackedAttackChanceGem", 5.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( SerpentScale ), "Requires 5 serpent scales", 5, "Serpent Scale" );

			index = AddCraft( typeof( CrackedWeaponDamageGem ),    "Weapon Mods", "CrackedWeaponDamageGem", 5.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( DragonScale ), "Requires 5 draco scales", 5, "Dragon Scale" );

			index = AddCraft( typeof( CrackedWeaponSpeedGem ),     "Weapon Mods", "CrackedWeaponSpeedGem", 5.0, 150.0, typeof( ClearHollowedGem ), "Requires 1 clear hollowed gem", 1, "Clear Hollowed Gem" );
			AddRes( index, typeof( FishScale ), "Requires 5 fish scales", 5, "Fish Scale" );
		}
	}
}