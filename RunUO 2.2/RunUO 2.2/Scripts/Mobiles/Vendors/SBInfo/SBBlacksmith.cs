using System; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBBlacksmith : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBBlacksmith() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 	
////////////////////////////////////////////////////// Misc
// All tools sell at a base price of 100 gp
				Add( new GenericBuyInfo( typeof( Tongs ), 100, 999, 0xFBB, 0 ) ); 
				Add( new GenericBuyInfo( typeof( SmithHammer ), 100, 999, 0x13E3, 0 ) );

////////////////////////////////////////////////////// Primary Components
				Add( new GenericBuyInfo( "Iron Ingot", typeof( IronIngot ), 5, 999, 0x1BF2, 0 ) );
				Add( new GenericBuyInfo( "Leather", typeof( Leather ), 5, 999, 0x1081, 0 ) );
				Add( new GenericBuyInfo( "Board", typeof( Board ), 5, 999, 0x1BD7, 0 ) );

////////////////////////////////////////////////////// Secondary Components
				Add( new GenericBuyInfo( "Copper Wire", typeof( CopperWire ), 1, 999, 0x1879, 0 ) );
				Add( new GenericBuyInfo( "Feather", typeof( Feather ), 1, 999, 0x1BD1, 0 ) );
				Add( new GenericBuyInfo( "Gears", typeof( Gears ), 1, 999, 0x1053, 0 ) );
				Add( new GenericBuyInfo( "Gold Wire", typeof( GoldWire ), 1, 999, 0x1878, 0 ) );
				Add( new GenericBuyInfo( "Iron Wire", typeof( IronWire ), 1, 999, 0x1876, 0 ) );
				Add( new GenericBuyInfo( "Shaft", typeof( Shaft ), 1, 999, 0x1BD4, 0 ) );
				Add( new GenericBuyInfo( "Silver Wire", typeof( SilverWire ), 1, 999, 0x1877, 0 ) );
				Add( new GenericBuyInfo( "Spool of Thread", typeof( SpoolOfThread ), 1, 999, 0xFA0, 0 ) );
				Add( new GenericBuyInfo( "Springs", typeof( Springs ), 1, 999, 0x105D, 0 ) );
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

////////////////////////////////////////////////////// Armor
// (Base Price = 100gp + Harvest component is 5 per cost equal to x amount + Secondary component is 1 per cost equal to x amount)  
////////////////////////////////////////////////////// Leather
				Add( typeof( FemaleLeatherChest ), 163 );
				Add( typeof( LeatherArms ), 153 );
				Add( typeof( LeatherBustierArms ), 135 );
				Add( typeof( LeatherCap ), 113 );
				Add( typeof( LeatherChest ), 163 );
				Add( typeof( LeatherGloves ), 118 );
				Add( typeof( LeatherGorget ), 123 );
				Add( typeof( LeatherLegs ), 153 );
				Add( typeof( LeatherShorts ), 145 );
				Add( typeof( LeatherSkirt ), 135 );

				Add( typeof( LeatherDo ), 164 );
				Add( typeof( LeatherHaidate ), 163 );
				Add( typeof( LeatherHiroSode ), 127 );
				Add( typeof( LeatherJingasa ), 119 );
				Add( typeof( LeatherMempo ), 144 );
				Add( typeof( LeatherNinjaBelt ), 128 );
				Add( typeof( LeatherNinjaHood ), 173 );
				Add( typeof( LeatherNinjaJacket ), 168 );
				Add( typeof( LeatherNinjaMitts ), 163 );
				Add( typeof( LeatherNinjaPants ), 168 );
				Add( typeof( LeatherSuneate ), 163 );

				Add( typeof( FemaleLeafChest ), 180 );
				Add( typeof( LeafArms ), 165 );
				Add( typeof( LeafChest ), 180 );
				Add( typeof( LeafGloves ), 155 );
				Add( typeof( LeafGorget ), 165 );
				Add( typeof( LeafLegs ), 180 );
				Add( typeof( LeafTonlet ), 165 );

////////////////////////////////////////////////////// Studded Leather
				Add( typeof( FemaleStuddedChest ), 155 );
				Add( typeof( StuddedArms ), 155 );
				Add( typeof( StuddedBustierArms ), 145 );
				Add( typeof( StuddedChest ), 175 );
				Add( typeof( StuddedGloves ), 145 );
				Add( typeof( StuddedGorget ), 135 );
				Add( typeof( StuddedLegs ), 165 );

				Add( typeof( StuddedDo ), 175 );
				Add( typeof( StuddedHaidate ), 175 );
				Add( typeof( StuddedHiroSode ), 145 );
				Add( typeof( StuddedMempo ), 145 );
				Add( typeof( StuddedSuneate ), 175 );

				Add( typeof( HideChest ), 180 );
				Add( typeof( HideFemaleChest ), 180 );
				Add( typeof( HideGloves ), 155 );
				Add( typeof( HideGorget ), 165 );
				Add( typeof( HidePants ), 180 );
				Add( typeof( HidePauldrons ), 165 );

////////////////////////////////////////////////////// Chainmail
				Add( typeof( ChainCoif ), 163 );
				Add( typeof( ChainChest ), 278 );
				Add( typeof( ChainLegs ), 222 );

////////////////////////////////////////////////////// Ringmail
				Add( typeof( RingmailArms ), 182 );
				Add( typeof( RingmailChest ), 258 );
				Add( typeof( RingmailGloves ), 162 );
				Add( typeof( RingmailLegs ), 222 );

////////////////////////////////////////////////////// Helmets
				Add( typeof( Bascinet ), 188 );
				Add( typeof( CloseHelm ), 188 );
				Add( typeof( Helmet ), 188 );
				Add( typeof( NorseHelm ), 188 );
				Add( typeof( PlateHelm ), 188 );

				Add( typeof( ChainHatsuburi ), 213 );
				Add( typeof( DecorativePlateKabuto ), 238 );
				Add( typeof( LightPlateJingasa ), 213 );
				Add( typeof( HeavyPlateJingasa ), 213 );
				Add( typeof( PlateBattleKabuto ), 238 );
				Add( typeof( PlateHatsuburi ), 213 );
				Add( typeof( SmallPlateJingasa ), 213 );
				Add( typeof( StandardPlateKabuto ), 238 );

				Add( typeof( RavenHelm ), 179 );
				Add( typeof( VultureHelm ), 179 );
				Add( typeof( WingedHelm ), 214 );

				Add( typeof( Circlet ), 349 );
				Add( typeof( RoyalCirclet ), 385 );
				Add( typeof( GemmedCirclet ), 1086 );

				Add( typeof( ElvenPlateHelm ), 188 );
				Add( typeof( DemonscaleHelmet ), 215 );

////////////////////////////////////////////////////// Platemail
				Add( typeof( WoodlandArms ), 245 );
				Add( typeof( WoodlandChest ), 306 );
				Add( typeof( WoodlandGloves ), 194 );
				Add( typeof( WoodlandGorget ), 185 );
				Add( typeof( WoodlandLegs ), 279 );

				Add( typeof( FemalePlateChest ), 299 );
				Add( typeof( PlateChest ), 324 ); 
				Add( typeof( PlateArms ), 227 );
				Add( typeof( PlateGloves ), 174 );
				Add( typeof( PlateGorget ), 164 );
				Add( typeof( PlateLegs ), 253 );

				Add( typeof( PlateMempo ), 204 );
				Add( typeof( PlateDo ), 339 ); 
				Add( typeof( PlateHiroSode ), 217 );
				Add( typeof( PlateSuneate ), 253 );
				Add( typeof( PlateHaidate ), 253 );

				Add( typeof( CrusaderBreastplate ), 424 ); 
				Add( typeof( CrusaderGauntlets ), 274 );
				Add( typeof( CrusaderGorget ), 264 );
				Add( typeof( CrusaderLeggings ), 353 );
				Add( typeof( CrusaderSleeves ), 427 );

				Add( typeof( ElvenPlateArms ), 227 );
				Add( typeof( ElvenPlateChest ), 324 ); 
				Add( typeof( ElvenPlateLegs ), 253 );

				Add( typeof( DemonscaleArms ), 452 );
				Add( typeof( DemonscaleChest ), 549 ); 
				Add( typeof( DemonscaleGloves ), 399 );
				Add( typeof( DemonscaleGorget ), 389 );
				Add( typeof( DemonscaleLegs ), 378 );

////////////////////////////////////////////////////// Dragon Armor
// (Base Price = 500gp + Scales component is 10 per cost equal to x amount + Harvest component is 5 per cost equal to x amount + Secondary component is 1 per cost equal to x amount)
				Add( typeof( DragonArms ), 777 );
				Add( typeof( DragonChest ), 779 );
				Add( typeof( DragonGloves ), 594 );
				Add( typeof( DragonHelm ), 613 );
				Add( typeof( DragonLegs ), 693 );

////////////////////////////////////////////////////// Shields
				Add( typeof( BoneShield ), 190 );
				Add( typeof( ElvenShield ), 190 );
				Add( typeof( GrassShield ), 200 );
				Add( typeof( NymphShield ), 185 );


				Add( typeof( AmmoniteShield ), 215 );
				Add( typeof( BronzeShield ), 195 );
				Add( typeof( BlackHeaterShield ), 235 );
				Add( typeof( Buckler ), 185 );
				Add( typeof( HeaterShield ), 225 );
				Add( typeof( InfantryShield ), 210 );
				Add( typeof( JewelShield ), 705 );
				Add( typeof( MercenaryShield ), 215 );
				Add( typeof( MetalShield ), 205 );
				Add( typeof( MetalKiteShield ), 215 );
				Add( typeof( ScarabShield ), 230 );
				Add( typeof( SpiderShield ), 225 );
				Add( typeof( UnicornShield ), 225 );
				Add( typeof( WoodenDragonShield ), 235 );
				Add( typeof( WoodenKiteShield ), 175 );
				Add( typeof( WoodenShield ), 165 );
				Add( typeof( ChaosShield ), 260 );
				Add( typeof( OrderShield ), 260 );
			} 
		} 
	} 
}