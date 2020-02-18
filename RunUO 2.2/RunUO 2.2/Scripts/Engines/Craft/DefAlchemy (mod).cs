using System;
using Server.Items;
using Server.ACC.CSS.Systems.Druid;

namespace Server.Engines.Craft
{
	public class DefAlchemy : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Alchemy;	}
		}

		public override int GumpTitleNumber
		{
			get { return 1044001; } // <CENTER>ALCHEMY MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefAlchemy();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefAlchemy() : base( 1, 1, 1.25 )// base( 1, 1, 3.1 )
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
			from.PlaySound( 0x242 );
		}

		private static Type typeofPotion = typeof( BasePotion );

		public static bool IsPotion( Type type )
		{
			return typeofPotion.IsAssignableFrom( type );
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
		{
			if ( toolBroken )
				from.SendLocalizedMessage( 1044038 ); // You have worn out your tool

			if ( failed )
			{
				if ( IsPotion( item.ItemType ) )
				{
					from.AddToBackpack( new Bottle() );
					return 500287; // You fail to create a useful potion.
				}
				else
				{
					return 1044043; // You failed to create the item, and some of your materials are lost.
				}
			}
			else
			{
				from.PlaySound( 0x240 ); // Sound of a filling bottle

				if ( IsPotion( item.ItemType ) )
				{
					if ( quality == -1 )
						return 1048136; // You create the potion and pour it into a keg.
					else
						return 500279; // You pour the potion into a bottle...
				}
				else
				{
					return 1044154; // You create the item.
				}
			}
		}

		public override void InitCraftList()
		{
			int index = -1;

			// Restoration Potions
			index = AddCraft( typeof( LesserCurePotion ), "Restoration", "lesser cure potion", -10.0, 40.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Garlic ), 1044355, 1, 1044363 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( CurePotion ), "Restoration", "cure potion", 25.0, 75.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Garlic ), 1044355, 3, 1044363 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( GreaterCurePotion ), "Restoration", "greater cure potion", 65.0, 100.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Garlic ), 1044355, 6, 1044363 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( MaximumCurePotion ), "Restoration", "maximum cure potion", 110.0, 135.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Garlic ), 1044355, 15, 1044363 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( LesserHealPotion ), "Restoration", "lesser heal potion", -25.0, 25.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Ginseng ), 1044356, 1, 1044364 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( HealPotion ), "Restoration", "heal potion", 15.0, 65.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Ginseng ), 1044356, 3, 1044364 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( GreaterHealPotion ), "Restoration", "greater heal potion", 55.0, 100.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Ginseng ), 1044356, 7, 1044364 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( MaximumHealPotion ), "Restoration", "maximum heal potion", 110.0, 135.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Ginseng ), 1044356, 15, 1044364 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( RefreshPotion ), "Restoration", "refresh potion", -25, 25.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( BlackPearl ), 1044353, 1, 1044361 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( TotalRefreshPotion ), "Restoration", "total refresh potion", 25.0, 75.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( BlackPearl ), 1044353, 5, 1044361 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( LesserManaPotion ),         "Restoration", "lesser mana potion", 5.0, 55.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( BlackPearl ), 1044353, 1, 1044361 );
			AddRes( index, typeof( Ginseng ), 1044356, 1, 1044364 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( ManaPotion ),               "Restoration", "mana potion", 35.0, 85.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( BlackPearl ), 1044353, 1, 1044361 );
			AddRes( index, typeof( Ginseng ), 1044356, 2, 1044364 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( GreaterManaPotion ),        "Restoration", "greater mana potion", 65.0, 100.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( BlackPearl ), 1044353, 3, 1044361 );
			AddRes( index, typeof( Ginseng ), 1044356, 4, 1044364 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( MaximumManaPotion ),        "Restoration", "maximum mana potion", 110.0, 135.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( BlackPearl ), 1044353, 7, 1044361 );
			AddRes( index, typeof( Ginseng ), 1044356, 8, 1044364 );
			SetNeedHeat( index, true );

			// Stat Buff Potions
			index = AddCraft( typeof( AgilityPotion ),            "Stat Buff", "agility potion", 15.0, 65.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Bloodmoss ), 1044354, 1, 1044362 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( GreaterAgilityPotion ),     "Stat Buff", "greater agility potion", 35.0, 85.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Bloodmoss ), 1044354, 3, 1044362 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( MaximumAgilityPotion ),     "Stat Buff", "maximum agility potion", 110.0, 135.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Bloodmoss ), 1044354, 15, 1044362 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( StrengthPotion ),           "Stat Buff", "strength potion", 25.0, 75.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( MandrakeRoot ), 1044357, 2, 1044365 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( GreaterStrengthPotion ),    "Stat Buff", "greater strength potion", 45.0, 95.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( MandrakeRoot ), 1044357, 5, 1044365 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( MaximumStrengthPotion ),    "Stat Buff", "maximum strength potion", 110.0, 135.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( MandrakeRoot ), 1044357, 15, 1044365 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( MindPotion ),               "Stat Buff", "mind potion", 25.0, 75.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Bloodmoss ), 1044354, 2, 1044362 );
			AddRes( index, typeof( MandrakeRoot ), 1044357, 1, 1044365 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( GreaterMindPotion ),        "Stat Buff", "greater mind potion", 45.0, 95.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Bloodmoss ), 1044354, 5, 1044362 );
			AddRes( index, typeof( MandrakeRoot ), 1044357, 3, 1044365 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( MaximumMindPotion ),        "Stat Buff", "maximum mind potion", 110.0, 135.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Bloodmoss ), 1044354, 8, 1044362 );
			AddRes( index, typeof( MandrakeRoot ), 1044357, 7, 1044365 );
			SetNeedHeat( index, true );

                        // Damage Potions
			index = AddCraft( typeof( LesserExplosionPotion ),    "Damage", "lesser explosion potion", 5.0, 55.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( SulfurousAsh ), 1044359, 3, 1044367 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( ExplosionPotion ),          "Damage", "explosion potion", 35.0, 85.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( SulfurousAsh ), 1044359, 5, 1044367 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( GreaterExplosionPotion ),   "Damage", "greater explosion potion", 65.0, 100.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( SulfurousAsh ), 1044359, 10, 1044367 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( MaximumExplosionPotion ),   "Damage", "maximum explosion potion", 110.0, 135.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( SulfurousAsh ), 1044359, 15, 1044367 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( LesserShatterPotion ),    "Damage", "lesser shatter potion", 5.0, 55.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( SpringWater ), "Requires 3 spring water", 3, "Spring Water" );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( ShatterPotion ),          "Damage", "shatter potion", 35.0, 85.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( SpringWater ), "Requires 5 spring water", 5, "Spring Water" );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( GreaterShatterPotion ),   "Damage", "greater shatter potion", 65.0, 100.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( SpringWater ), "Requires 10 spring water", 10, "Spring Water" );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( MaximumShatterPotion ),   "Damage", "maximum shatter potion", 110.0, 135.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( SpringWater ), "Requires 15 spring water", 15, "Spring Water" );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( LesserLightningPotion ),    "Damage", "lesser lightning potion", 5.0, 55.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( DestroyingAngel ), "Requires 3 destroying angel", 3, "Destroying Angel" );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( LightningPotion ),          "Damage", "lightning potion", 35.0, 85.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( DestroyingAngel ), "Requires 5 destroying angel", 5, "Destroying Angel" );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( GreaterLightningPotion ),   "Damage", "greater lightning potion", 65.0, 100.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( DestroyingAngel ), "Requires 10 destroying angel", 10, "Destroying Angel" );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( MaximumLightningPotion ),   "Damage", "maximum lightning potion", 110.0, 135.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( DestroyingAngel ), "Requires 15 destroying angel", 15, "Destroying Angel" );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( LesserPoisonPotion ),       "Damage", "lesser poison potion", -5.0, 45.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Nightshade ), 1044358, 1, 1044366 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( PoisonPotion ),             "Damage", "poison potion", 15.0, 65.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Nightshade ), 1044358, 2, 1044366 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( GreaterPoisonPotion ),      "Damage", "greater poison potion", 55.0, 100.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Nightshade ), 1044358, 4, 1044366 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( DeadlyPoisonPotion ),       "Damage", "deadly poison potion", 90.0, 100.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Nightshade ), 1044358, 8, 1044366 );
			SetNeedHeat( index, true );
			index = AddCraft( typeof( MaximumPoisonPotion ),      "Damage", "maximum poison potion", 110.0, 135.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( Nightshade ), 1044358, 15, 1044366 );
			SetNeedHeat( index, true );

                        // Misc Potions
			index = AddCraft( typeof(ConflagrationPotion), "Misc", 1072096, 55.0, 105.0, typeof(GraveDust), 1023983, 5, 1044253 );
			AddRes( index, typeof(Bottle), 1044529, 1, 500315 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof(GreaterConflagrationPotion), "Misc", 1072099, 65.0, 115.0, typeof(GraveDust), 1023983, 10, 1044253 );
			AddRes( index, typeof(Bottle), 1044529, 1, 500315 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof(ConfusionBlastPotion), "Misc", 1072106, 55.0, 105.0, typeof(PigIron), 1023978, 5, 1044253 );
			AddRes( index, typeof(Bottle), 1044529, 1, 500315 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof(GreaterConfusionBlastPotion), "Misc", 1072109, 65.0, 115.0, typeof(PigIron), 1023978, 10, 1044253 );
			AddRes( index, typeof(Bottle), 1044529, 1, 500315 );
			SetNeedHeat( index, true );

                        index = AddCraft(typeof(InvisibilityPotion), "Misc", 1074860, 65.0, 115.0, typeof(Bottle), 1044529, 1, 500315);
                        AddRes(index, typeof(Bloodmoss), 1044354, 4, 1044362);
                        AddRes(index, typeof(Nightshade), 1044358, 3, 1044366);
			SetNeedHeat( index, true );

			index = AddCraft( typeof( NightSightPotion ), "Misc", "night sight potion", -25.0, 25.0, typeof ( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( SpidersSilk ), 1044360, 1, 1044368 );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( SmokeBomb ), "Misc", 1030248, 90.0, 120.0, typeof( Eggs ), 1044477, 1, 1044253 );
			AddRes( index, typeof ( Ginseng ), 1044356, 3, 1044364 );
			SetNeedHeat( index, true );
		}
	}
}