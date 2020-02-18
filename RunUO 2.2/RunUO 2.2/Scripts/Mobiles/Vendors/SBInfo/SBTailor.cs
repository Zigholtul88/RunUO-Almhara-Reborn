using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBTailor: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBTailor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Black Bandana", typeof( BlackBandana ), 750, 100, 0x1540, 2405 ) );
				Add( new GenericBuyInfo( "Earth Crusted Shirt", typeof( EarthCrustedShirt ), 850, 100, 0x1517, 1181 ) );
				Add( new GenericBuyInfo( "Feathered Hat Of Speed", typeof( FeatheredHatOfSpeed ), 450, 100, 0x171A, 0 ) );
				Add( new GenericBuyInfo( "Flame Broiled Shirt", typeof( FlameBroiledShirt ), 850, 100, 0x1517, 1281 ) );
				Add( new GenericBuyInfo( "Feathered Hat Of Speed", typeof( FeatheredHatOfSpeed ), 450, 100, 0x171A, 0 ) );
				Add( new GenericBuyInfo( "Green Bonnet", typeof( GreenBonnet ), 550, 100, 0x1719, 67 ) );
				Add( new GenericBuyInfo( "Ivy Barked Shirt", typeof( IvyBarkedShirt ), 850, 100, 0x1517, 1371 ) );
				Add( new GenericBuyInfo( "Salamander's Robe", typeof( SalamandersRobe ), 1250, 100, 0x1F03, 1281 ) );
				Add( new GenericBuyInfo( "Short Pants Of Agility", typeof( ShortPantsOfAgility ), 1000, 100, 0x152E, 0 ) );
				Add( new GenericBuyInfo( "Short Pants Of Protection", typeof( ShortPantsOfProtection ), 1000, 100, 0x152E, 0 ) );
				Add( new GenericBuyInfo( "Short Pants Of Strength", typeof( ShortPantsOfStrength ), 1000, 100, 0x152E, 0 ) );
				Add( new GenericBuyInfo( "Snow Crusted Cloak", typeof( SnowCrustedCloak ), 825, 100, 0x1515, 1150 ) );
				Add( new GenericBuyInfo( "Tough Vine Belt", typeof( ToughVineBelt ), 215, 100, 0x2B68, 66 ) );
				Add( new GenericBuyInfo( "Wind Stitched Shirt", typeof( WindStitchedShirt ), 850, 100, 0x1517, 991 ) );
				Add( new GenericBuyInfo( "Woven Hedge Cloak", typeof( WovenHedgeCloak ), 650, 100, 0x1515, 66 ) );

				Add( new GenericBuyInfo( typeof( BoltOfCloth ), 50, 500, 0xf95, Utility.RandomDyedHue() ) ); 

				Add( new GenericBuyInfo( typeof( Cloth ), 10, 999, 0x1766, Utility.RandomDyedHue() ) ); 
				Add( new GenericBuyInfo( typeof( UncutCloth ), 10, 999, 0x1767, Utility.RandomDyedHue() ) ); 

				Add( new GenericBuyInfo( typeof( Cotton ), 10, 999, 0xDF9, 0 ) );
				Add( new GenericBuyInfo( "Dark Yarn", typeof( DarkYarn ), 10, 999, 0xE1D, 0 ) );
				Add( new GenericBuyInfo( "Light Yarn", typeof( LightYarn ), 10, 999, 0xE1E, 0 ) );

				Add( new GenericBuyInfo( typeof( Flax ), 10, 999, 0x1A9C, 0 ) );
				Add( new GenericBuyInfo( typeof( SpoolOfThread ), 10, 999, 0xFA0, 0 ) );
				Add( new GenericBuyInfo( typeof( Wool ), 10, 999, 0xDF8, 0 ) );

				Add( new GenericBuyInfo( typeof( DyeTub ), 5000, 20, 0xFAB, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Dyes ), 2500, 20, 0xFA9, 0 ) ); 
		                Add( new GenericBuyInfo( typeof( Scissors ), 100, 40, 0xF9F, 0 ) );
				Add( new GenericBuyInfo( typeof( SewingKit ), 100, 500, 0xF9D, 0 ) );

				Add( new GenericBuyInfo( typeof( Bandana ), 6, 20, 0x1540, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( BaroqueMask ), 25, 20, 15850, 0 ) );
				Add( new GenericBuyInfo( typeof( BearMask ), 35, 20, 0x1545, 0 ) );
				Add( new GenericBuyInfo( typeof( Bonnet ), 26, 20, 0x1719, 0 ) );
				Add( new GenericBuyInfo( typeof( Cap ), 10, 20, 0x1715, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( ClothNinjaHood ), 8, 20, 0x278F, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( DeerMask ), 35, 20, 0x1547, 0 ) );
				Add( new GenericBuyInfo( typeof( FeatheredHat ), 10, 20, 0x171A, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( FloppyHat ), 7, 20, 0x1713, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( JesterHat ), 12, 20, 0x171C, 0 ) );
				Add( new GenericBuyInfo( typeof( Kasa ), 15, 20, 0x2798, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( SkullCap ), 7, 20, 0x1544, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( StrawHat ), 7, 20, 0x1717, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( TallStrawHat ), 8, 20, 0x1716, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( TribalMask ), 12, 20, 0x1716, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( TribalMask ), 12, 20, 0x1716, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( TribalMask ), 12, 20, 0x1716, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( TricorneHat ), 8, 20, 0x171B, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( WideBrimHat ), 8, 20, 0x1714, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( WizardsHat ), 11, 20, 0x1718, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( typeof( ClothNinjaJacket ), 75, 20, 0x2794, 0 ) );
				Add( new GenericBuyInfo( typeof( Doublet ), 65, 20, 0x1F7B, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenShirt ), 75, 20, 0x3175, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenDarkShirt ), 95, 20, 0x3176, 0 ) );
				Add( new GenericBuyInfo( typeof( FancyShirt ), 85, 20, 0x1EFD, 0 ) );
				Add( new GenericBuyInfo( typeof( FormalShirt ), 80, 20, 0x2310, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherShirt ), 95, 20, 15900, 0 ) );
				Add( new GenericBuyInfo( typeof( MoonElfShirt ), 75, 20, 16169, 0 ) );
				Add( new GenericBuyInfo( typeof( ReinassanceShirt ), 90, 20, 15842, 0 ) );
				Add( new GenericBuyInfo( typeof( Shirt ), 65, 20, 0x1517, 0 ) );

				Add( new GenericBuyInfo( typeof( BodySash ), 55, 20, 0x1541, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Cloak ), 65, 20, 0x1515, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenRobe ), 90, 20, 0x2FB9, 0 ) );
				Add( new GenericBuyInfo( typeof( FancyRobe ), 120, 20, 16369, 0 ) );
				Add( new GenericBuyInfo( typeof( FancyTunic ), 135, 20, 15846, 0 ) );
				Add( new GenericBuyInfo( typeof( FemaleElvenRobe ), 90, 20, 0x2FBA, 0 ) );
				Add( new GenericBuyInfo( typeof( FullApron ), 105, 20, 0x153d, 0 ) );
				Add( new GenericBuyInfo( typeof( FurCape ), 72, 20, 0x230A, 0 ) );
				Add( new GenericBuyInfo( typeof( HakamaShita ), 155, 20, 0x279C, 0 ) );
				Add( new GenericBuyInfo( typeof( HalfApron ), 75, 20, 0x153b, 0 ) );
				Add( new GenericBuyInfo( typeof( HoodedShroudOfShadows ), 500, 20, 0x2684, 0 ) );
				Add( new GenericBuyInfo( typeof( JesterSuit ), 126, 20, 0x1F9F, 0 ) );
				Add( new GenericBuyInfo( typeof( JinBaori ), 93, 20, 0x27A1, 0 ) );
				Add( new GenericBuyInfo( typeof( Kamishimo ), 145, 20, 0x2799, 0 ) );
				Add( new GenericBuyInfo( typeof( FemaleKimono ), 145, 20, 0x2783, 0 ) );
				Add( new GenericBuyInfo( typeof( MaleKimono ), 145, 20, 0x2782, 0 ) );
				Add( new GenericBuyInfo( typeof( MoonElfFancyRobe ), 120, 20, 16373, 0 ) );
				Add( new GenericBuyInfo( typeof( Obi ), 77, 20, 0x27A0, 0 ) );
				Add( new GenericBuyInfo( typeof( PlumeCloak ), 79, 20, 15884, 0 ) );
				Add( new GenericBuyInfo( typeof( RegalCloak ), 85, 20, 15886, 0 ) );
				Add( new GenericBuyInfo( typeof( Robe ), 68, 20, 0x1F03, 0 ) );
				Add( new GenericBuyInfo( typeof( RogueGarb ), 95, 20, 15904, 0 ) );
				Add( new GenericBuyInfo( typeof( SunElfFancyRobe ), 120, 20, 16371, 0 ) );
				Add( new GenericBuyInfo( typeof( Surcoat ), 105, 20, 0x1ffd, 0 ) );
				Add( new GenericBuyInfo( typeof( Trenchcoat ), 115, 20, 16173, 0 ) );
				Add( new GenericBuyInfo( typeof( Tunic ), 115, 20, 0x1FA1, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodlandBelt ), 75, 20, 0x2B68, 0 ) );

				Add( new GenericBuyInfo( typeof( ElvenPants ), 100, 20, 0x2FC3, 0 ) );
				Add( new GenericBuyInfo( typeof( FancyPants ), 125, 20, 15840, 0 ) );
				Add( new GenericBuyInfo( typeof( FurSarong ), 70, 20, 0x230C, 0 ) );
				Add( new GenericBuyInfo( typeof( Hakama ), 65, 20, 0x279A, 0 ) );
				Add( new GenericBuyInfo( typeof( Kilt ), 85, 20, 0x1537, 0 ) );
				Add( new GenericBuyInfo( typeof( Kilt ), 85, 20, 0x1537, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( LeatherPants ), 145, 20, 15902, 0 ) );
				Add( new GenericBuyInfo( typeof( MoonElfSkirt ), 85, 20, 16171, 0 ) );
				Add( new GenericBuyInfo( typeof( ReinassancePants ), 110, 20, 15844, 0 ) );
				Add( new GenericBuyInfo( typeof( ShortPants ), 55, 20, 0x152E, 0 ) );
				Add( new GenericBuyInfo( typeof( Skirt ), 85, 20, 0x1516, 0 ) );
				Add( new GenericBuyInfo( typeof( TattsukeHakama ), 80, 20, 0x279B, 0 ) );

				Add( new GenericBuyInfo( typeof( BaroqueDress ), 225, 20, 16379, 0 ) );
				Add( new GenericBuyInfo( typeof( CitizenDress ), 125, 20, 14370, 0 ) );
				Add( new GenericBuyInfo( typeof( CommonerDress ), 150, 20, 14372, 0 ) );
				Add( new GenericBuyInfo( typeof( ConfessorDress ), 165, 20, 14374, 0 ) );
				Add( new GenericBuyInfo( typeof( DancersGarb ), 140, 20, 14376, 0 ) );
				Add( new GenericBuyInfo( typeof( ElegantGown ), 230, 20, 14378, 0 ) );
				Add( new GenericBuyInfo( typeof( FancyDress ), 225, 20, 0x1EFF, 0 ) );
				Add( new GenericBuyInfo( typeof( FlowerDress ), 210, 20, 14380, 0 ) );
				Add( new GenericBuyInfo( typeof( FormalDress ), 190, 20, 14382, 0 ) );
				Add( new GenericBuyInfo( typeof( GildedDress ), 175, 20, 0x230E, 0 ) );
				Add( new GenericBuyInfo( typeof( MaidensDress ), 235, 20, 14384, 0 ) );
				Add( new GenericBuyInfo( typeof( MedievalLongDress ), 210, 20, 14386, 0 ) );
				Add( new GenericBuyInfo( typeof( MoonElfPlainDress ), 150, 20, 16377, 0 ) );
				Add( new GenericBuyInfo( typeof( NobleDress ), 275, 20, 14388, 0 ) );
				Add( new GenericBuyInfo( typeof( NocturnalDress ), 140, 20, 14390, 0 ) );
				Add( new GenericBuyInfo( typeof( PartyDress ), 220, 20, 14392, 0 ) );
				Add( new GenericBuyInfo( typeof( PlainDress ), 150, 20, 0x1F01, 0 ) );
				Add( new GenericBuyInfo( typeof( RaggedDress ), 110, 20, 14394, 0 ) );
				Add( new GenericBuyInfo( typeof( ReinassanceDress ), 210, 20, 15848, 0 ) );
				Add( new GenericBuyInfo( typeof( SunElfPlainDress ), 150, 20, 16375, 0 ) );
				Add( new GenericBuyInfo( typeof( TheaterDress ), 280, 20, 14396, 0 ) );
				Add( new GenericBuyInfo( typeof( VictorianDress ), 210, 20, 14398, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Dyes ), 1200 );
				Add( typeof( DyeTub ), 2500 );
				Add( typeof( Scissors ), 10 );
				Add( typeof( SewingKit ), 12 );

				Add( typeof( Doublet ), 7 );
				Add( typeof( FormalShirt ), 10 );
				Add( typeof( Shirt ), 7 );
				Add( typeof( RogueGarb ), 15 );

				Add( typeof( Bandana ), 5 );
				Add( typeof( Cap ), 5 );
				Add( typeof( StrawHat ), 5 );

				Add( typeof( Cloak ), 10 );
				Add( typeof( FurCape ), 15 );
				Add( typeof( HalfApron ), 10 );
				Add( typeof( PlainDress ), 10 );
				Add( typeof( Robe ), 10 );
				Add( typeof( FancyRobe ), 10 );
				Add( typeof( Trenchcoat ), 15 );

				Add( typeof( FancyPants ), 15 );
				Add( typeof( ShortPants ), 7 );
				Add( typeof( Skirt ), 7 );

				Add( typeof( BoltOfCloth ), 25 );
				Add( typeof( Cloth ), 5 );
				Add( typeof( UncutCloth ), 5 );

				Add( typeof( Cotton ), 5 );
				Add( typeof( DarkYarn ), 5 );
				Add( typeof( Flax ), 5 );
				Add( typeof( LightYarn ), 5 );
				Add( typeof( LightYarnUnraveled ), 5 );
				Add( typeof( SpoolOfThread ), 5 );
				Add( typeof( Wool ), 5 );
			}
		}
	}
}
