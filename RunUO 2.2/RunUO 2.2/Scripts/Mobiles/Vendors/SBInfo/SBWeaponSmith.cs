using System; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBWeaponSmith: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBWeaponSmith() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
////////////////////////////////////////////////////// Axes
				Add( new GenericBuyInfo( typeof( Axe ), 185, 20, 0xF49, 0 ) );
				Add( new GenericBuyInfo( typeof( BattleAxe ), 190, 20, 0xF47, 0 ) );
				Add( new GenericBuyInfo( typeof( DoubleAxe ), 185, 20, 0xF4B, 0 ) );
				Add( new GenericBuyInfo( typeof( ExecutionersAxe ), 185, 20, 0xF45, 0 ) );
				Add( new GenericBuyInfo( typeof( LargeBattleAxe ), 180, 20, 0x13FB, 0 ) );
				Add( new GenericBuyInfo( typeof( TwoHandedAxe ), 205, 20, 0x1443, 0 ) );
				Add( new GenericBuyInfo( typeof( WarAxe ), 205, 20, 0x13B0, 0 ) );

////////////////////////////////////////////////////// Knives
				Add( new GenericBuyInfo( typeof( Dagger ), 125, 20, 0xF52, 0 ) );

////////////////////////////////////////////////////// Bashing
				Add( new GenericBuyInfo( typeof( Club ), 100, 20, 0x13B4, 0 ) );
				Add( new GenericBuyInfo( typeof( HammerPick ), 200, 20, 0x143D, 0 ) );
				Add( new GenericBuyInfo( typeof( Mace ), 150, 20, 0xF5C, 0 ) );
				Add( new GenericBuyInfo( typeof( Maul ), 170, 20, 0x143B, 0 ) );
				Add( new GenericBuyInfo( typeof( WarHammer ), 200, 20, 0x1439, 0 ) );
				Add( new GenericBuyInfo( typeof( WarMace ), 190, 20, 0x1407, 0 ) );

////////////////////////////////////////////////////// Pole Arms
				Add( new GenericBuyInfo( typeof( Bardiche ), 215, 20, 0xF4D, 0 ) );
				Add( new GenericBuyInfo( typeof( Halberd ), 225, 20, 0x143E, 0 ) );

////////////////////////////////////////////////////// Spears and Forks
				Add( new GenericBuyInfo( typeof( Pitchfork ), 100, 20, 0xE87, 0 ) );
				Add( new GenericBuyInfo( typeof( ShortSpear ), 155, 20, 0x1403, 0 ) );
				Add( new GenericBuyInfo( typeof( Spear ), 185, 20, 0xF62, 0 ) );

////////////////////////////////////////////////////// Staves
				Add( new GenericBuyInfo( typeof( BlackStaff ), 200, 20, 0xDF1, 0 ) );
				Add( new GenericBuyInfo( typeof( GnarledStaff ), 135, 20, 0x13F8, 0 ) );
				Add( new GenericBuyInfo( typeof( QuarterStaff ), 130, 20, 0xE89, 0 ) );
				Add( new GenericBuyInfo( typeof( ShepherdsCrook ), 135, 20, 0xE81, 0 ) );

////////////////////////////////////////////////////// Swords
				Add( new GenericBuyInfo( typeof( Cutlass ), 165, 20, 0x1441, 0 ) );
				Add( new GenericBuyInfo( typeof( Katana ), 165, 20, 0x13FF, 0 ) );
				Add( new GenericBuyInfo( typeof( Kryss ), 165, 20, 0x1401, 0 ) );
				Add( new GenericBuyInfo( typeof( Longsword ), 185, 20, 0xF61, 0 ) );
				Add( new GenericBuyInfo( typeof( Scimitar ), 175, 20, 0x13B6, 0 ) );
				Add( new GenericBuyInfo( typeof( VikingSword ), 195, 20, 0x13B9, 0 ) );

////////////////////////////////////////////////////// AOS Weapons
				Add( new GenericBuyInfo( typeof( BladedStaff ), 185, 20, 0x26BD, 0 ) );
				Add( new GenericBuyInfo( typeof( BoneHarvester ), 175, 20, 0x26BB, 0 ) );
				Add( new GenericBuyInfo( typeof( CompositeBow ), 168, 20, 0x26C2, 0 ) );
				Add( new GenericBuyInfo( typeof( CrescentBlade ), 195, 20, 0x26C1, 0 ) );
				Add( new GenericBuyInfo( typeof( DoubleBladedStaff ), 205, 20, 0x26BF, 0 ) );
				Add( new GenericBuyInfo( typeof( Lance ), 225, 20, 0x26C0, 0 ) );
				Add( new GenericBuyInfo( typeof( PaladinSword ), 100, 20, 0x26CE, 0 ) );
				Add( new GenericBuyInfo( typeof( Pike ), 100, 20, 0x26BE, 0 ) );
				Add( new GenericBuyInfo( typeof( RepeatingCrossbow ), 162, 20, 0x26C3, 0 ) );
				Add( new GenericBuyInfo( typeof( Scepter ), 170, 20, 0x26BC, 0 ) );
				Add( new GenericBuyInfo( typeof( Scythe ), 205, 20, 0x26BA, 0 ) );

////////////////////////////////////////////////////// SE Weapons
				Add( new GenericBuyInfo( typeof( Daisho ), 200, 20, 0x27A9, 0 ) );
				Add( new GenericBuyInfo( typeof( Kama ), 195, 20, 0x27AD, 0 ) );
				Add( new GenericBuyInfo( typeof( Lajatang ), 250, 20, 0x27A7, 0 ) );
				Add( new GenericBuyInfo( typeof( NoDachi ), 215, 20, 0x27A2, 0 ) );
				Add( new GenericBuyInfo( typeof( Sai ), 185, 20, 0x27AF, 0 ) );	
				Add( new GenericBuyInfo( typeof( Shuriken ), 5, 200, 0x27AC, 0 ) );
				Add( new GenericBuyInfo( typeof( Tekagi ), 185, 20, 0x27AB, 0 ) );
				Add( new GenericBuyInfo( typeof( Tessen ), 230, 20, 0x27A3, 0 ) );
				Add( new GenericBuyInfo( typeof( Tetsubo ), 200, 20, 0x27A6, 0 ) );
				Add( new GenericBuyInfo( typeof( Wakizashi ), 165, 20, 0x27A4, 0 ) );

////////////////////////////////////////////////////// CA Weapons
				Add( new GenericBuyInfo( typeof( CrystalStaff ), 225, 20, 16176, 0 ) );
				Add( new GenericBuyInfo( typeof( PristineStaff ), 210, 20, 16177, 0 ) );
				Add( new GenericBuyInfo( typeof( TribalStaff ), 215, 20, 15816, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
////////////////////////////////////////////////////// Weapons
// (Base Price = 100gp + Harvest component is 5 per cost equal to x amount + Secondary component is 1 per cost equal to x amount)  
				Add( typeof( Axe ), 185 );
				Add( typeof( BattleAxe ), 190 );
				Add( typeof( DoubleAxe ), 185 );
				Add( typeof( ExecutionersAxe ), 185 );
				Add( typeof( LargeBattleAxe ),180 );
				Add( typeof( Pickaxe ), 50 );
				Add( typeof( TwoHandedAxe ), 205 );
				Add( typeof( WarAxe ), 205 );

				Add( typeof( Dagger ), 125 );

				Add( typeof( Cutlass ), 165 );
				Add( typeof( Katana ), 165 );
				Add( typeof( Kryss ), 165 );
				Add( typeof( Longsword ), 185 );
				Add( typeof( Scimitar ), 175 );
				Add( typeof( VikingSword ), 195 );

				Add( typeof( Club ), 100 );
				Add( typeof( HammerPick ), 200 );
				Add( typeof( Mace ), 150 );
				Add( typeof( Maul ), 170 );
				Add( typeof( WarHammer ), 200 );
				Add( typeof( WarMace ), 190 );

				Add( typeof( Pitchfork ), 100 );
				Add( typeof( ShortSpear ), 155 );
				Add( typeof( Spear ), 185 );
				Add( typeof( WarFork ), 185 );

				Add( typeof( BlackStaff ), 200 );
				Add( typeof( CrystalStaff ), 225 );
				Add( typeof( GnarledStaff ), 135 );
				Add( typeof( QuarterStaff ), 130 );
				Add( typeof( PristineStaff ), 210 );
				Add( typeof( ShepherdsCrook ), 135 );
				Add( typeof( TribalStaff ), 215 );
				Add( typeof( WildStaff ), 135 );

				Add( typeof( Bardiche ), 215 );
				Add( typeof( Halberd ), 225 );

				Add( typeof( BladedStaff ), 185 );
				Add( typeof( BoneHarvester ), 175 );
				Add( typeof( CrescentBlade ), 195 );
				Add( typeof( DoubleBladedStaff ), 205 );
				Add( typeof( Lance ), 225 );
				Add( typeof( PaladinSword ), 100 );
				Add( typeof( Pike ), 225 );
				Add( typeof( Scepter ), 170 );
				Add( typeof( Scythe ), 205 );

				Add( typeof( Daisho ), 200 );
				Add( typeof( Kama ), 195 );
				Add( typeof( Lajatang ), 250 );
				Add( typeof( NoDachi ), 215 );
				Add( typeof( Sai ), 185 );
				Add( typeof( Shuriken ), 5 );
				Add( typeof( Tekagi ), 185 );
				Add( typeof( Tessen ), 230 );
				Add( typeof( Tetsubo ), 200 ); // Need to mod price to better reflect new system
				Add( typeof( Wakizashi ), 165 );

				Add( typeof( AssassinSpike ), 170 );
				Add( typeof( DiamondMace ), 615 );
				Add( typeof( ElvenMachete ), 195 );
				Add( typeof( ElvenSpellblade ), 195 );
				Add( typeof( Leafblade ), 185 );
				Add( typeof( OrnateAxe ), 215 );
				Add( typeof( RadiantScimitar ), 200 );
				Add( typeof( RuneBlade ), 200 );
				Add( typeof( WarCleaver ), 215 );

				Add( typeof( EbonyBattleAxe ), 200 );
				Add( typeof( EbonyBattleSpear ), 200 );
				Add( typeof( EbonyDagger ), 140 );
				Add( typeof( EbonyDualDaggers ), 180 );
				Add( typeof( EbonyDualKatanas ), 230 );
				Add( typeof( EbonyGlassAxe ), 190 );
				Add( typeof( EbonyGlassBardiche ), 225 );
				Add( typeof( EbonyMoonblade ), 195 );
				Add( typeof( EbonyMorningstar ), 230 );
				Add( typeof( EbonyPristineStaff ), 100 );
				Add( typeof( EbonyRapier ), 170 );
				Add( typeof( EbonyScimitar ), 200 );
				Add( typeof( EbonyWarMace ), 210 );
			} 
		} 
	} 
}
