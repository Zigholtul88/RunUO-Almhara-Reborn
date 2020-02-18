using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefWeaponsmithy : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Blacksmith;	}
		}

		public override string GumpTitleString
		{
			get { return "<basefont color=#FFFFFF><CENTER>Weaponsmithy MENU</CENTER></basefont>"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefWeaponsmithy();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefWeaponsmithy() : base( 1, 1, 1.25 )// base( 1, 2, 1.7 )
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

////////////////////////// Axes	//////////////////////////
////////////////////////// Axes (Lv.5)
index = AddCraft( typeof( Axe ), "Axes", "axe - (lv.5)", 5.0, 25.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 1 board", 1, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Axes (Lv.10)
index = AddCraft( typeof( BattleAxe ), "Axes", "battle axe - (lv.10)", 10.0, 30.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Axes (Lv.20)
index = AddCraft( typeof( DoubleAxe ), "Axes", "double axe - (lv.20)", 20.0, 40.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 1 board", 1, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Axes (Lv.25)
index = AddCraft( typeof( TwoHandedAxe ), "Axes", "two-handed axe - (lv.25)", 25.0, 45.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Axes (Lv.30)
index = AddCraft( typeof( WarAxe ), "Axes", "war axe - (lv.35)", 30.0, 50.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Axes (Lv.35)
index = AddCraft( typeof( OrnateAxe ), "Axes", "ornate axe - (lv.35)", 35.0, 55.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 3 regular leather", 3, "Leather" );

////////////////////////// Axes (Lv.40)
index = AddCraft( typeof( ExecutionersAxe ), "Axes", "executioner's axe - (lv.40)", 40.0, 60.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 1 board", 1, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Axes (Lv.50)
index = AddCraft( typeof( LargeBattleAxe ), "Axes", "large battle axe - (lv.50)", 50.0, 70.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 1 board", 1, "Board" );
	AddRes( index, typeof( Leather ), "Requires 3 regular leather", 3, "Leather" );

////////////////////////// Axes (Lv.70)
index = AddCraft( typeof( EbonyGlassAxe ), "Axes", "ebony glass axe - (lv.70)", 70.0, 90.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 1 board", 1, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Axes (Lv.80)
index = AddCraft( typeof( EbonyBattleAxe ), "Axes", "ebony battle axe - (lv.80)", 80.0, 110.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );


////////////////////////// Knives and Daggers //////////////////////////
////////////////////////// Knives and Daggers (Lv.1)
index = AddCraft( typeof( Leafblade ), "Knives and Daggers", "leafblade - (lv.1)", -25.0, 20.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Knives and Daggers (Lv.5)
index = AddCraft( typeof( Dagger ), "Knives and Daggers", "dagger - (lv.5)", 5.0, 25.0, typeof( IronIngot ), 1044036, 3, 1044037 );
	AddRes( index, typeof( Board ), "Requires 1 board", 1, "Board" );
	AddRes( index, typeof( Leather ), "Requires 1 regular leather", 1, "Leather" );

////////////////////////// Knives and Daggers (Lv.10)
index = AddCraft( typeof( EbonyDagger ), "Knives and Daggers", "ebony dagger - (lv.10)", 10.0, 30.0, typeof( IronIngot ), 1044036, 3, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Knives and Daggers (Lv.15)
index = AddCraft( typeof( Sai ), "Knives and Daggers", "sai - (lv.15)", 15.0, 35.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Knives and Daggers (Lv.20)
index = AddCraft( typeof( EbonyDualDaggers ), "Knives and Daggers", "ebony dual daggers - (lv.20)", 20.0, 40.0, typeof( IronIngot ), 1044036, 6, 1044037 );
	AddRes( index, typeof( Board ), "Requires 6 board", 6, "Board" );
	AddRes( index, typeof( Leather ), "Requires 4 regular leather", 4, "Leather" );

////////////////////////// Knives and Daggers (Lv.25)
index = AddCraft( typeof( Tekagi ), "Knives and Daggers", "tekagi - (lv.25)", 25.0, 45.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Knives and Daggers (Lv.30)
index = AddCraft( typeof( ElvenSpellblade ), "Knives and Daggers", "elven spellblade - (lv.30)", 30.0, 50.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Knives and Daggers (Lv.35)
index = AddCraft( typeof( Kama ), "Knives and Daggers", "kama - (lv.35)", 35.0, 55.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Knives and Daggers (Lv.40)
index = AddCraft( typeof( Lajatang ), "Knives and Daggers", "lajatang - (lv.40)", 40.0, 60.0, typeof( IronIngot ), 1044036, 25, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Knives and Daggers (Lv.50)
index = AddCraft( typeof( AssassinSpike ), "Knives and Daggers", "assassin spike - (lv.50)", 50.0, 70.0, typeof( IronIngot ), 1044036, 9, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( WarCleaver ), "Knives and Daggers", "war cleaver - (lv.50)", 50.0, 70.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );


////////////////////////// Maces and Hammers //////////////////////////
////////////////////////// Maces and Hammers (Lv.5)
index = AddCraft( typeof( Mace ), "Maces and Hammers", "mace - (lv.5)", 5.0, 25.0, typeof( IronIngot ), 1044036, 6, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Maces and Hammers (Lv.10)
index = AddCraft( typeof( Maul ), "Maces and Hammers", "maul - (lv.10)", 10.0, 30.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Maces and Hammers (Lv.15)
index = AddCraft( typeof( Scepter ), "Maces and Hammers", "scepter - (lv.15)", 15.0, 35.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Maces and Hammers (Lv.20)
index = AddCraft( typeof( WarMace ), "Maces and Hammers", "war mace - (lv.20)", 20.0, 40.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Maces and Hammers (Lv.25)
index = AddCraft( typeof( Tessen ), "Maces and Hammers", "tessen - (lv.25)", 25.0, 45.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddSkill( index, SkillName.Tailoring, 50.0, 55.0 );
	AddRes( index, typeof( Cloth ), 1044286, 10, 1044287 );

////////////////////////// Maces and Hammers (Lv.30)
index = AddCraft( typeof( HammerPick ), "Maces and Hammers", "hammer pick - (lv.30)", 30.0, 50.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Maces and Hammers (Lv.35)
index = AddCraft( typeof( DiamondMace ), "Maces and Hammers", "diamond mace - (lv.35)", 35.0, 55.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Maces and Hammers (Lv.40)
index = AddCraft( typeof( WarHammer ), "Maces and Hammers", "war hammer - (lv.40)", 40.0, 60.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Maces and Hammers (Lv.50)
index = AddCraft( typeof( EbonyMorningstar ), "Maces and Hammers", "ebony morningstar - (lv.50)", 50.0, 70.0, typeof( IronIngot ), 1044036, 22, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( EbonyWarMace ), "Maces and Hammers", "ebony war mace - (lv.50)", 50.0, 70.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 2 board", 2, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );


////////////////////////// Pole Arms //////////////////////////
////////////////////////// Pole Arms (Lv.60)
index = AddCraft( typeof( Halberd ), "Pole Arms", "halberd - (lv.60)", 60.0, 80.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Pole Arms (Lv.70)
index = AddCraft( typeof( Bardiche ), "Pole Arms", "bardiche - (lv.70)", 70.0, 90.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Pole Arms (Lv.80)
index = AddCraft( typeof( Scythe ), "Pole Arms", "scythe - (lv.80)", 80.0, 110.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 5 board", 5, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Pole Arms (Lv.90)
index = AddCraft( typeof( EbonyGlassBardiche ), "Pole Arms", "ebony glass bardiche - (lv.90)", 90.0, 120.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );


////////////////////////// Spears and Forks //////////////////////////
////////////////////////// Spears and Forks (Lv.5)
index = AddCraft( typeof( ShortSpear ), "Spears and Forks", "short spear - (lv.5)", 5.0, 25.0, typeof( IronIngot ), 1044036, 6, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Spears and Forks (Lv.10)
index = AddCraft( typeof( Pilum ), "Spears and Forks", "pilum - (lv.10)", 10.0, 30.0, typeof( IronIngot ), 1044036, 6, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Spears and Forks (Lv.15)
index = AddCraft( typeof( Pike ), "Spears and Forks", "pike - (lv.15)", 15.0, 35.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Spears and Forks (Lv.20)
index = AddCraft( typeof( Spear ), "Spears and Forks", "spear - (lv.20)", 20.0, 40.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Spears and Forks (Lv.25)
index = AddCraft( typeof( BoneSpear ), "Spears and Forks", "bone spear - (lv.25)", 25.0, 45.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( RibCage ), "Requires 1 rib cage", 1, "Ribcage" );
	AddRes( index, typeof( Bone ), 1049064, 25, 1049063 );

////////////////////////// Spears and Forks (Lv.35)
index = AddCraft( typeof( SkeletalSpear ), "Spears and Forks", "skeletal spear - (lv.35)", 35.0, 55.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );
	AddRes( index, typeof( RibCage ), "Requires 1 rib cage", 1, "Ribcage" );
	AddRes( index, typeof( Bone ), 1049064, 25, 1049063 );

////////////////////////// Spears and Forks (Lv.40)
index = AddCraft( typeof( WarFork ), "Spears and Forks", "war fork - (lv.40)", 40.0, 60.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Spears and Forks (Lv.50)
index = AddCraft( typeof( BladedStaff ), "Spears and Forks", "bladed staff - (lv.50)", 50.0, 70.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Spears and Forks (Lv.60)
index = AddCraft( typeof( DoubleBladedStaff ), "Spears and Forks", "double bladed staff - (lv.60)", 60.0, 80.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Spears and Forks (Lv.70)
index = AddCraft( typeof( EbonyBattleSpear ), "Spears and Forks", "ebony battle spear - (lv.70)", 70.0, 90.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Spears and Forks (Lv.80)
index = AddCraft( typeof( SonicSpear ), "Spears and Forks", "sonic spear - (lv.80)", 80.0, 110.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );


////////////////////////// Swords and Blades //////////////////////////
////////////////////////// Swords and Blades (Lv.1)
index = AddCraft( typeof( BoneHarvester ), "Swords and Blades", "bone harvester - (lv.1)", 5.0, 20.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Cutlass ), "Swords and Blades", "cutlass - (lv.1)", 5.0, 20.0, typeof( IronIngot ), 1044036, 8, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( ElvenMachete ), "Swords and Blades", "elven machete - (lv.1)", 5.0, 20.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Kryss ), "Swords and Blades", "kryss - (lv.1)", 5.0, 20.0, typeof( IronIngot ), 1044036, 8, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Swords and Blades (Lv.10)
index = AddCraft( typeof( EbonyRapier ), "Swords and Blades", "ebony rapier - (lv.10)", 10.0, 30.0, typeof( IronIngot ), 1044036, 9, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Scimitar ), "Swords and Blades", "scimitar - (lv.10)", 10.0, 30.0, typeof( IronIngot ), 1044036, 10, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Swords and Blades (Lv.20)
index = AddCraft( typeof( Longsword ), "Swords and Blades", "longsword - (lv.20)", 20.0, 40.0, typeof( IronIngot ), 1044036, 12, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( VikingSword ), "Swords and Blades", "viking sword - (lv.20)", 20.0, 40.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Wakizashi ), "Swords and Blades", "wakizashi - (lv.20)", 20.0, 40.0, typeof( IronIngot ), 1044036, 8, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Swords and Blades (Lv.30)
index = AddCraft( typeof( Daisho ), "Swords and Blades", "daisho - (lv.30)", 30.0, 50.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( EbonyScimitar ), "Swords and Blades", "ebony scimitar - (lv.30)", 30.0, 50.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( RuneBlade ), "Swords and Blades", "rune blade - (lv.30)", 30.0, 50.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Swords and Blades (Lv.35)
index = AddCraft( typeof( PaladinSword ), "Swords and Blades", "paladin sword - (lv.35)", 35.0, 55.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 6 board", 6, "Board" );
	AddRes( index, typeof( Leather ), "Requires 4 regular leather", 4, "Leather" );

////////////////////////// Swords and Blades (Lv.40)
index = AddCraft( typeof( Katana ), "Swords and Blades", "katana - (lv.40)", 40.0, 60.0, typeof( IronIngot ), 1044036, 8, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( NoDachi ), "Swords and Blades", "no-dachi - (lv.40)", 40.0, 60.0, typeof( IronIngot ), 1044036, 18, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Swords and Blades (Lv.45)
index = AddCraft( typeof( CrescentBlade ), "Swords and Blades", "crescent blade - (lv.45)", 45.0, 65.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

////////////////////////// Swords and Blades (Lv.50)
index = AddCraft( typeof( EbonyDualKatanas ), "Swords and Blades", "ebony dual katanas - (lv.50)", 50.0, 70.0, typeof( IronIngot ), 1044036, 16, 1044037 );
	AddRes( index, typeof( Board ), "Requires 6 board", 6, "Board" );
	AddRes( index, typeof( Leather ), "Requires 4 regular leather", 4, "Leather" );

index = AddCraft( typeof( EbonyMoonblade ), "Swords and Blades", "ebony moonblade - (lv.50)", 50.0, 70.0, typeof( IronIngot ), 1044036, 14, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( Lance ), "Swords and Blades", "lance - (lv.50)", 50.0, 70.0, typeof( IronIngot ), 1044036, 20, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );

index = AddCraft( typeof( RadiantScimitar ), "Swords and Blades", "radiant scimitar - (lv.50)", 50.0, 70.0, typeof( IronIngot ), 1044036, 15, 1044037 );
	AddRes( index, typeof( Board ), "Requires 3 board", 3, "Board" );
	AddRes( index, typeof( Leather ), "Requires 2 regular leather", 2, "Leather" );


////////////////////////// Misc //////////////////////////
AddCraft( typeof( Shuriken ), "Misc", 1030231, 45.0, 95.0, typeof( IronIngot ), 1044036, 5, 1044037 );

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