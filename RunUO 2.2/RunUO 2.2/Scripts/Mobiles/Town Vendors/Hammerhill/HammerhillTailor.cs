using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;
using Server.Engines.BulkOrders;

namespace Server.Mobiles
{
	public class HammerhillTailor : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public HammerhillTailor() : base( "the tailor" )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBHammerhillTailor() );
		}

		public override void InitOutfit()
		{
			SetStr( 117 );
			SetDex( 96 );
			SetInt( 54 );

			SetSkill( SkillName.Tailoring, 64.0, 100.0 );

			PackGold( 41, 82 );

			if ( this.Female = Utility.RandomBool() ) 
			{ 
				this.Body = 0x191; 
				this.Name = NameList.RandomName( "female" );
			        this.Hue = Utility.RandomSkinHue(); 

                                this.HairHue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
                                this.HairItemID = Utility.RandomList( 8251,8252,8253,8260,8261,8262,8263,8264,8265 );

			        switch ( Utility.Random( 17 ) )
			        {
				       case 0: AddItem( new CitizenDress( Utility.RandomBlueHue() ) ); break;
				       case 1: AddItem( new CommonerDress( Utility.RandomGreenHue() ) ); break;
				       case 2: AddItem( new ConfessorDress( Utility.RandomRedHue() ) ); break;
				       case 3: AddItem( new ElegantGown( Utility.RandomYellowHue() ) ); break;
				       case 4: AddItem( new FancyDress( Utility.RandomBlueHue() ) ); break;
				       case 5: AddItem( new FlowerDress( Utility.RandomGreenHue() ) ); break;
				       case 6: AddItem( new FormalDress( Utility.RandomRedHue() ) ); break;
				       case 7: AddItem( new GildedDress( Utility.RandomYellowHue() ) ); break;
				       case 8: AddItem( new MaidensDress( Utility.RandomBlueHue() ) ); break;
				       case 9: AddItem( new MedievalLongDress( Utility.RandomGreenHue() ) ); break;
				       case 10: AddItem( new NobleDress( Utility.RandomRedHue() ) ); break;
				       case 11: AddItem( new NocturnalDress( Utility.RandomYellowHue() ) ); break;
				       case 12: AddItem( new PartyDress( Utility.RandomBlueHue() ) ); break;
				       case 13: AddItem( new PlainDress( Utility.RandomGreenHue() ) ); break;
				       case 14: AddItem( new ReinassanceDress( Utility.RandomRedHue() ) ); break;
				       case 15: AddItem( new TheaterDress( Utility.RandomYellowHue() ) ); break;
				       case 16: AddItem( new VictorianDress( Utility.RandomNeutralHue() ) ); break;
			        }

			        switch ( Utility.Random( 8 ) )
			        {
				       case 0: AddItem( new Boots( Utility.RandomNeutralHue() ) ); break;
				       case 1: AddItem( new FurBoots( Utility.RandomNeutralHue() ) ); break;
				       case 2: AddItem( new LightBoots( Utility.RandomNeutralHue() ) ); break;
				       case 3: AddItem( new Sandals( Utility.RandomNeutralHue() ) ); break;
				       case 4: AddItem( new ShortBoots( Utility.RandomNeutralHue() ) ); break;
				       case 5: AddItem( new ThighBoots( Utility.RandomNeutralHue() ) ); break;
			        }

			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverBracelet bracelet = new SilverBracelet();
                                      bracelet.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              bracelet.Movable = true;
			              AddItem( bracelet );
                                }

			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverNecklace necklace = new SilverNecklace();
                                      necklace.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              necklace.Movable = true;
			              AddItem( necklace );
                                }

			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverEarrings earrings = new SilverEarrings();
                                      earrings.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              earrings.Movable = true;
			              AddItem( earrings );
                                }
			}
			else 
			{ 
				this.Body = 0x190; 
				this.Name = NameList.RandomName( "male" );
			        this.Hue = Utility.RandomSkinHue();

                                this.HairHue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
                                this.HairItemID = Utility.RandomList( 8251,8252,8253,8260,8261,8262,8263,8264,8265 );
                                this.FacialHairHue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
                                this.FacialHairItemID = Utility.RandomList( 8254,8255,8256,8257,8267,8268,8269 );

			        switch ( Utility.Random( 8 ) )
			        {
				       case 0: AddItem( new FancyShirt( Utility.RandomBlueHue() ) ); break;
				       case 1: AddItem( new FancyTunic( Utility.RandomGreenHue() ) ); break;
				       case 2: AddItem( new FormalShirt( Utility.RandomRedHue() ) ); break;
				       case 3: AddItem( new LeatherShirt( Utility.RandomYellowHue() ) ); break;
				       case 4: AddItem( new ReinassanceShirt( Utility.RandomBlueHue() ) ); break;
				       case 5: AddItem( new Shirt( Utility.RandomGreenHue() ) ); break;
				       case 6: AddItem( new Surcoat( Utility.RandomRedHue() ) ); break;
				       case 7: AddItem( new Tunic( Utility.RandomNeutralHue() ) ); break;
                                }


			        switch ( Utility.Random( 9 ) )
			        {
				       case 0: AddItem( new FancyPants( Utility.RandomNeutralHue() ) ); break;
				       case 1: AddItem( new FurSarong( Utility.RandomNeutralHue() ) ); break;
				       case 2: AddItem( new Hakama( Utility.RandomNeutralHue() ) ); break;
				       case 3: AddItem( new Kilt( Utility.RandomNeutralHue() ) ); break;
				       case 4: AddItem( new LeatherPants( Utility.RandomNeutralHue() ) ); break;
				       case 5: AddItem( new LongPants( Utility.RandomNeutralHue() ) ); break;
				       case 6: AddItem( new ReinassancePants( Utility.RandomNeutralHue() ) ); break;
				       case 7: AddItem( new ShortPants( Utility.RandomNeutralHue() ) ); break;
				       case 8: AddItem( new TattsukeHakama( Utility.RandomNeutralHue() ) ); break;
                                }

			        switch ( Utility.Random( 6 ) )
			        {
				       case 0: AddItem( new Boots( Utility.RandomNeutralHue() ) ); break;
				       case 1: AddItem( new HeavyBoots( Utility.RandomNeutralHue() ) ); break;
				       case 2: AddItem( new HighBoots( Utility.RandomNeutralHue() ) ); break;
				       case 3: AddItem( new Shoes( Utility.RandomNeutralHue() ) ); break;
				       case 4: AddItem( new ShortBoots( Utility.RandomNeutralHue() ) ); break;
				       case 5: AddItem( new ThighBoots( Utility.RandomNeutralHue() ) ); break;
                                }


			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverBracelet bracelet = new SilverBracelet();
                                      bracelet.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              bracelet.Movable = true;
			              AddItem( bracelet );
                                }

			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverEarrings earrings = new SilverEarrings();
                                      earrings.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              earrings.Movable = true;
			              AddItem( earrings );
                                }
			} 

			if ( 0.05 > Utility.RandomDouble() )
				AddItem( new BodySash( Utility.RandomDyedHue() ) );

			if ( 0.05 > Utility.RandomDouble() )
                        {
			        switch ( Utility.Random( 6 ) )
			        {
				      case 0: AddItem( new Bandana( Utility.RandomDyedHue() ) ); break;
				      case 1: AddItem( new Bonnet( Utility.RandomDyedHue() ) ); break;
				      case 2: AddItem( new Cap( Utility.RandomDyedHue() ) ); break;
				      case 3: AddItem( new FeatheredHat( Utility.RandomDyedHue() ) ); break;
				      case 4: AddItem( new SkullCap( Utility.RandomDyedHue() ) ); break;
				      case 5: AddItem( new WideBrimHat( Utility.RandomDyedHue() ) ); break;
			        }
                        }
                }

		public HammerhillTailor( Serial serial ) : base( serial )
		{
		}

		#region Bulk Orders
		public override Item CreateBulkOrder( Mobile from, bool fromContextMenu )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm != null && pm.NextTailorBulkOrder == TimeSpan.Zero && (fromContextMenu || 0.2 > Utility.RandomDouble()) )
			{
				double theirSkill = pm.Skills[SkillName.Tailoring].Base;

				if ( theirSkill >= 70.1 )
					pm.NextTailorBulkOrder = TimeSpan.FromHours( 3.0 );
				else if ( theirSkill >= 50.1 )
					pm.NextTailorBulkOrder = TimeSpan.FromHours( 2.0 );
				else
					pm.NextTailorBulkOrder = TimeSpan.FromHours( 1.0 );

				return SmallTailorBOD.CreateRandomFor( from );
			}

			return null;
		}

		public override bool IsValidBulkOrder( Item item )
		{
			return ( item is SmallTailorBOD || item is LargeTailorBOD );
		}

		public override bool SupportsBulkOrders( Mobile from )
		{
			return ( from is PlayerMobile && from.Skills[SkillName.Tailoring].Base > 0 );
		}

		public override TimeSpan GetNextBulkOrder( Mobile from )
		{
			if ( from is PlayerMobile )
				return ((PlayerMobile)from).NextTailorBulkOrder;

			return TimeSpan.Zero;
		}

		public override void OnSuccessfulBulkOrderReceive( Mobile from )
		{
			if( Core.SE && from is PlayerMobile )
				((PlayerMobile)from).NextTailorBulkOrder = TimeSpan.Zero;
		}
		#endregion

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class SBHammerhillTailor : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHammerhillTailor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
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

				Add( new GenericBuyInfo( typeof( OnePieceBikini ), 50, 20, 15297, 0 ) );
				Add( new GenericBuyInfo( typeof( TwoPieceBikini ), 50, 20, 15299, 0 ) );
				Add( new GenericBuyInfo( typeof( Boxers ), 25, 20, 15293, 0 ) );
				Add( new GenericBuyInfo( typeof( Panties ), 25, 20, 15295, 0 ) );
				Add( new GenericBuyInfo( typeof( RoyalTonlet ), 100, 20, 15305, 0 ) );
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