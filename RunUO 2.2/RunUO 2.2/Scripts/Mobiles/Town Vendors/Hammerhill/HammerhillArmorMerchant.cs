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

namespace Server.Mobiles
{
	public class HammerhillArmorMerchant : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public HammerhillArmorMerchant() : base( "the armor merchant" )
		{
                }

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBHammerhillArmorMerchant() );
		}

		public override void InitOutfit()
		{
			SetStr( 117 );
			SetDex( 96 );
			SetInt( 54 );

			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );

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

		public HammerhillArmorMerchant( Serial serial ) : base( serial )
		{
		}

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

	public class SBHammerhillArmorMerchant : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHammerhillArmorMerchant()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
////////////////////////////////////////////////////// Level 1
				Add( new GenericBuyInfo( typeof( FemaleLeatherChest ), 100, 500, 0x1C06, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherArms ), 50, 500, 0x13CD, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherBustierArms ), 100, 500, 0x1C0A, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherCap ), 20, 500, 0x1DB9, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherChest ), 100, 500, 0x13CC, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherGloves ), 20, 500, 0x13C6, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherGorget ), 40, 500, 0x13C7, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherLegs ), 80, 500, 0x13CB, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherShorts ), 80, 500, 0x1C00, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherSkirt ), 80, 500, 0x1C08, 0 ) );

////////////////////////////////////////////////////// Level 3
				Add( new GenericBuyInfo( typeof( FemaleLeafChest ), 200, 50, 0x2FCB, 0 ) );
				Add( new GenericBuyInfo( typeof( LeafArms ), 100, 500, 0x2FC8, 0 ) );
				Add( new GenericBuyInfo( typeof( LeafChest ), 200, 500, 0x2FC5, 0 ) );
				Add( new GenericBuyInfo( typeof( LeafGloves ), 40, 500, 0x2FC6, 0 ) );
				Add( new GenericBuyInfo( typeof( LeafGorget ), 80, 500, 0x2FC7, 0 ) );
				Add( new GenericBuyInfo( typeof( LeafLegs ), 160, 500, 0x2FC9, 0 ) );
				Add( new GenericBuyInfo( typeof( LeafTonlet ), 160, 500, 0x2FCA, 0 ) );

////////////////////////////////////////////////////// Level 6
				Add( new GenericBuyInfo( typeof( LeatherDo ), 300, 500, 0x277B, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherHaidate ), 300, 500, 0x278A, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherHiroSode ), 300, 500, 0x277E, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherJingasa ), 300, 500, 0x2776, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherMempo ), 300, 500, 0x277A, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherNinjaHood ), 300, 500, 0x278E, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherNinjaJacket ), 300, 500, 0x2793, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherNinjaMitts ), 300, 500, 0x2792, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherNinjaPants ), 300, 500, 0x2791, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherSuneate ), 300, 500, 0x2786, 0 ) );

////////////////////////////////////////////////////// Level 9
				Add( new GenericBuyInfo( typeof( EbonsilkArms ), 400, 500, 15852, 0 ) );
				Add( new GenericBuyInfo( typeof( EbonsilkChest ), 400, 500, 15855, 0 ) );
				Add( new GenericBuyInfo( typeof( EbonsilkGloves ), 400, 500, 15856, 0 ) );
				Add( new GenericBuyInfo( typeof( EbonsilkGorget ), 400, 500, 15859, 0 ) );
				Add( new GenericBuyInfo( typeof( EbonsilkLegs ), 400, 500, 15860, 0 ) );
				Add( new GenericBuyInfo( typeof( EbonsilkTiara ), 400, 500, 15862, 0 ) );

////////////////////////////////////////////////////// Level 12
				Add( new GenericBuyInfo( typeof( ChitinArms ), 500, 500, 15329, 0 ) );
				Add( new GenericBuyInfo( typeof( ChitinChest ), 500, 500, 15332, 0 ) );
				Add( new GenericBuyInfo( typeof( ChitinGloves ), 500, 500, 15333, 0 ) );
				Add( new GenericBuyInfo( typeof( ChitinGorget ), 500, 500, 15335, 0 ) );
				Add( new GenericBuyInfo( typeof( ChitinHelmet ), 500, 500, 15336, 0 ) );
				Add( new GenericBuyInfo( typeof( ChitinLegs ), 500, 500, 15337, 0 ) );

////////////////////////////////////////////////////// Shields
				Add( new GenericBuyInfo( typeof( Buckler ), 100, 500, 0x1B73, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( WoodenShield ), 200, 500, 0x1B7A, 0 ) ); // Level 3
				Add( new GenericBuyInfo( typeof( AmmoniteShield ), 300, 500, 14404, 0 ) ); // Level 6
				Add( new GenericBuyInfo( typeof( BronzeShield ), 400, 500, 0x1B72, 0 ) ); // Level 9
				Add( new GenericBuyInfo( typeof( MetalShield ), 500, 500, 0x1B7B, 0 ) ); // Level 12
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
			} 
		} 
	} 
}