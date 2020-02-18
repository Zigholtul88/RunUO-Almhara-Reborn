using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefCandleCrafting : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Camping;	}
		}

		public override string GumpTitleString
		{
			get { return "<basefont color=#FFFFFF><CENTER>Candle Crafting MENU</CENTER></basefont>"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefCandleCrafting();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefCandleCrafting() : base( 1, 1, 1.25 )// base( 1, 2, 1.7 )
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

                        ///////////////////// Candles
			index = AddCraft( typeof( Candle ),           "Candles", "candle", 10.0, 30.0, typeof( Beeswax ), "Requires 1 beeswax", 1, "Beeswax" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( BlueCandle ),           "Candles", "blue candle", 25.0, 50.0, typeof( Beeswax ), "Requires 1 beeswax", 1, "Beeswax" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( EnergyStone ), "Requires 1 energy stone", 1, "Energy Stone" );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( GreenCandle ),           "Candles", "green candle", 25.0, 50.0, typeof( Beeswax ), "Requires 1 beeswax", 1, "Beeswax" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( SerpentScale ), "Requires 1 serpent scale", 1, "Serpent Scale" );
			SetNeedHeat( index, true );

			index = AddCraft( typeof( WhiteCandle ),           "Candles", "white candle", 25.0, 50.0, typeof( Beeswax ), "Requires 1 beeswax", 1, "Beeswax" );
			AddRes( index, typeof( IronIngot ), 1044036, 1, 1044037 );
			AddRes( index, typeof( SpoolOfThread ), "Requires 1 spool of thread", 1, "Spool of Thread" );
			AddRes( index, typeof( IceStone ), "Requires 1 ice stone", 1, "Ice Stone" );
			SetNeedHeat( index, true );

                        ///////////////////// Torches
			index = AddCraft( typeof( Torch ),                 "Torches", "torch", -25.0, 25.0, typeof( Log ), 1044041, 1, 1044351 );
			AddRes( index, typeof( Beeswax ), "Requires 1 beeswax", 1, "Beeswax" );
		}
	}
}