using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBScribe: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBScribe()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( NecromancerSpellbook ), 115, 1, 0x2253, 0 ) );
				Add( new GenericBuyInfo( "Spellbook", typeof( Spellbook ), 100, 10, 0xEFA, 0 ) );
				Add( new GenericBuyInfo( "1041267", typeof( Runebook ), 10000, 10, 0xEFA, 0x461 ) );

				Add( new GenericBuyInfo( typeof( ScribesPen ), 50, 300, 0xFBF, 0 ) );
				Add( new GenericBuyInfo( typeof( BlankScroll ), 5, 999, 0x0E34, 0 ) );
				Add( new GenericBuyInfo( typeof( BrownBook ), 15, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( TanBook ), 15, 20, 0xFF0, 0 ) );
				Add( new GenericBuyInfo( typeof( BlueBook ), 15, 20, 0xFF2, 0 ) );
				Add( new GenericBuyInfo( typeof( RecallRune ), 100, 200, 0x1F14, 0 ) );

				Add( new GenericBuyInfo( typeof( ClumsyScroll ), 50, 244, 0x1F2E, 0 ) );
				Add( new GenericBuyInfo( typeof( FeeblemindScroll ), 50, 368, 0x1F30, 0 ) );
				Add( new GenericBuyInfo( typeof( HealScroll ), 50, 368, 0x1F31, 0 ) );
				Add( new GenericBuyInfo( typeof( MagicArrowScroll ), 50, 251, 0x1F32, 0 ) );
				Add( new GenericBuyInfo( typeof( ReactiveArmorScroll ), 50, 148, 0x1F2D, 0 ) );
				Add( new GenericBuyInfo( typeof( WeakenScroll ), 50, 251, 0x1F34, 0 ) );
				Add( new GenericBuyInfo( typeof( AgilityScroll ), 100, 159, 0x1F35, 0 ) );
				Add( new GenericBuyInfo( typeof( CunningScroll ), 100, 167, 0x1F36, 0 ) );
				Add( new GenericBuyInfo( typeof( CureScroll ), 100, 167, 0x1F37, 0 ) );
				Add( new GenericBuyInfo( typeof( HarmScroll ), 100, 128, 0x1F38, 0 ) );
				Add( new GenericBuyInfo( typeof( UnlockScroll ), 100, 102, 0x1F43, 0 ) );
				Add( new GenericBuyInfo( typeof( ProtectionScroll ), 100, 146, 0x1F3B, 0 ) );
				Add( new GenericBuyInfo( typeof( StrengthScroll ), 100, 121, 0x1F3C, 0 ) );
				Add( new GenericBuyInfo( typeof( FireballScroll ), 200, 98, 0x1F3E, 0 ) );
				Add( new GenericBuyInfo( typeof( PoisonScroll ), 200, 61, 0x1F40, 0 ) );
				Add( new GenericBuyInfo( typeof( TelekinisisScroll ), 200, 73, 0x1F41, 0 ) );
				Add( new GenericBuyInfo( typeof( TeleportScroll ), 200, 85, 0x1F42, 0 ) );
				Add( new GenericBuyInfo( typeof( GreaterHealScroll ), 300, 52, 0x1F49, 0 ) );
				Add( new GenericBuyInfo( typeof( LightningScroll ), 300, 48, 0x1F4A, 0 ) );

				Add( new GenericBuyInfo( typeof( ArchCureScroll ), 400, 125, 0x1F45, 0 ) );
				Add( new GenericBuyInfo( typeof( ArchProtectionScroll ), 400, 139, 0x1F46, 0 ) );
				Add( new GenericBuyInfo( typeof( CurseScroll ), 400, 98, 0x1F47, 0 ) );
				Add( new GenericBuyInfo( typeof( FireFieldScroll ), 400, 242, 0x1F48, 0 ) );
				Add( new GenericBuyInfo( typeof( ManaDrainScroll ), 400, 101, 0x1F4B, 0 ) );
				Add( new GenericBuyInfo( typeof( BladeSpiritsScroll ), 500, 211, 0x1F4D, 0 ) );
				Add( new GenericBuyInfo( typeof( IncognitoScroll ), 500, 147, 0x1F4F, 0 ) );
				Add( new GenericBuyInfo( typeof( MindBlastScroll ), 500, 128, 0x1F51, 0 ) );
				Add( new GenericBuyInfo( typeof( ParalyzeScroll ), 500, 83, 0x1F52, 0 ) );
				Add( new GenericBuyInfo( typeof( SummonCreatureScroll ), 500, 250, 0x1F54, 0 ) );

                                Add( new GenericBuyInfo( typeof( AnimateDeadScroll ), 52, 5, 0x2260, 0 ) );
                                Add( new GenericBuyInfo( typeof( BloodOathScroll ), 42, 5, 0x2261, 0 ) );
                                Add( new GenericBuyInfo( typeof( CorpseSkinScroll ), 32, 5, 0x2262, 0 ) );
                                Add( new GenericBuyInfo( typeof( CurseWeaponScroll ), 12, 5, 0x2263, 0 ) );
                                Add( new GenericBuyInfo( typeof( EvilOmenScroll ), 32, 5, 0x2264, 0 ) );
                                Add( new GenericBuyInfo( typeof( HorrificBeastScroll ), 52, 5, 0x2265, 0 ) );
                                Add( new GenericBuyInfo( typeof( LichFormScroll ), 82, 5, 0x2266, 0 ) );
                                Add( new GenericBuyInfo( typeof( MindRotScroll ), 42, 5, 0x2267, 0 ) );
                                Add( new GenericBuyInfo( typeof( PainSpikeScroll ), 32, 5, 0x2268, 0 ) );
                                Add( new GenericBuyInfo( typeof( PoisonStrikeScroll ), 62, 5, 0x2269, 0 ) );
                                Add( new GenericBuyInfo( typeof( StrangleScroll ), 72, 5, 0x226A, 0 ) );
                                Add( new GenericBuyInfo( typeof( SummonFamiliarScroll ), 82, 5, 0x226B, 0 ) );
                                Add( new GenericBuyInfo( typeof( VampiricEmbraceScroll ), 102, 5, 0x226C, 0 ) );
                                Add( new GenericBuyInfo( typeof( VengefulSpiritScroll ), 92, 5, 0x226D, 0 ) );
                                Add( new GenericBuyInfo( typeof( WitherScroll ), 72, 5, 0x226E, 0 ) );
                                Add( new GenericBuyInfo( typeof( WraithFormScroll ), 32, 5, 0x226F, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( ScribesPen ), 12 );
				Add( typeof( BlankScroll ), 3 );
				Add( typeof( BrownBook ), 7 );
				Add( typeof( TanBook ), 7 );
				Add( typeof( BlueBook ), 7 );

				Add( typeof( ClumsyScroll ), 12 );
				Add( typeof( CreateFoodScroll ), 12 );
				Add( typeof( FeeblemindScroll ), 12 );
				Add( typeof( HealScroll ), 12 );
				Add( typeof( MagicArrowScroll ), 12 );
				Add( typeof( NightSightScroll ), 12 );
				Add( typeof( ReactiveArmorScroll ), 12 );
				Add( typeof( WeakenScroll ), 12 );

				Add( typeof( AgilityScroll ), 25 );
				Add( typeof( CunningScroll ), 25 );
				Add( typeof( CureScroll ), 25 );
				Add( typeof( HarmScroll ), 25 );
				Add( typeof( MagicTrapScroll ), 25 );
				Add( typeof( MagicUnTrapScroll ), 25 );
				Add( typeof( ProtectionScroll ), 25 );
				Add( typeof( StrengthScroll ), 25 );

				Add( typeof( BlessScroll ), 50 );
				Add( typeof( FireballScroll ), 50 );
				Add( typeof( MagicLockScroll ), 50 );
				Add( typeof( PoisonScroll ), 50 );
				Add( typeof( TelekinisisScroll ), 50 );
				Add( typeof( TeleportScroll ), 50 );
				Add( typeof( UnlockScroll ), 50 );
				Add( typeof( WallOfStoneScroll ), 50 );

				Add( typeof( ArchCureScroll ), 75 );
				Add( typeof( ArchProtectionScroll ), 75 );
				Add( typeof( CurseScroll ), 75 );
				Add( typeof( FireFieldScroll ), 75 );
				Add( typeof( GreaterHealScroll ), 75 );
				Add( typeof( LightningScroll ), 75 );
				Add( typeof( ManaDrainScroll ), 75 );
				Add( typeof( RecallScroll ), 75 );

				Add( typeof( BladeSpiritsScroll ), 100 );
				Add( typeof( DispelFieldScroll ), 100 );
				Add( typeof( IncognitoScroll ), 100 );
				Add( typeof( MagicReflectScroll ), 100 );
				Add( typeof( MindBlastScroll ), 100 );
				Add( typeof( ParalyzeScroll ), 100 );
				Add( typeof( PoisonFieldScroll ), 100 );
				Add( typeof( SummonCreatureScroll ), 100 );

				Add( typeof( DispelScroll ), 125 );
				Add( typeof( EnergyBoltScroll ), 125 );
				Add( typeof( ExplosionScroll ), 125 );
				Add( typeof( InvisibilityScroll ), 125 );
				Add( typeof( MarkScroll ), 125 );
				Add( typeof( MassCurseScroll ), 125 );
				Add( typeof( ParalyzeFieldScroll ), 125 );
				Add( typeof( RevealScroll ), 125 );

				Add( typeof( ChainLightningScroll ), 150 );
				Add( typeof( EnergyFieldScroll ), 150 );
				Add( typeof( FlamestrikeScroll ), 150 );
				Add( typeof( GateTravelScroll ), 150 );
				Add( typeof( ManaVampireScroll ), 150 );
				Add( typeof( MassDispelScroll ), 150 );
				Add( typeof( MeteorSwarmScroll ), 150 );
				Add( typeof( PolymorphScroll ), 150 );

				Add( typeof( EarthquakeScroll ), 175 );
				Add( typeof( EnergyVortexScroll ), 175 );
				Add( typeof( ResurrectionScroll ), 175 );
				Add( typeof( SummonAirElementalScroll ), 175 );
				Add( typeof( SummonDaemonScroll ), 175 );
				Add( typeof( SummonEarthElementalScroll ), 175 );
				Add( typeof( SummonFireElementalScroll ), 175 );
				Add( typeof( SummonWaterElementalScroll ), 175 );
			}
		}
	}
}