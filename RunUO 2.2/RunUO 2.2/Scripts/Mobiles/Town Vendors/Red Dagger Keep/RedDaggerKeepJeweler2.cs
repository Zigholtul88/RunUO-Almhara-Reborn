using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Commands;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;

namespace Server.Mobiles 
{ 
	public class RedDaggerKeepJeweler2 : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public RedDaggerKeepJeweler2() : base( "the jeweler" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBRedDaggerKeepJeweler2() ); 
		} 

		public override void InitOutfit()
		{
			SetStr( 72 );
			SetDex( 61 );
			SetInt( 38 );

			PackGold( 53, 74 );

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

		public RedDaggerKeepJeweler2( Serial serial ) : base( serial ) 
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

	public class SBRedDaggerKeepJeweler2: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBRedDaggerKeepJeweler2() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{
				Add( new GenericBuyInfo( "Cracked Attack Chance Gem", typeof( CrackedAttackChanceGem ), 500, 500, 0x3198, 1023 ) );
				Add( new GenericBuyInfo( "Cracked Spell Damage Gem", typeof( CrackedSpellDamageGem ), 500, 500, 0x3198, 2607 ) );
				Add( new GenericBuyInfo( "Cracked Weapon Damage Gem", typeof( CrackedWeaponDamageGem ), 500, 500, 0x3198, 971 ) );
				Add( new GenericBuyInfo( "Cracked Weapon Speed Gem", typeof( CrackedWeaponSpeedGem ), 500, 500, 0x3198, 1009 ) );

				Add( new GenericBuyInfo( typeof( GoldRing ), 50, 20, 0x108A, 0 ) );
				Add( new GenericBuyInfo( typeof( Necklace ), 100, 20, 0x1085, 0 ) );
				Add( new GenericBuyInfo( typeof( GoldNecklace ), 100, 20, 0x1088, 0 ) );
				Add( new GenericBuyInfo( typeof( GoldBeadNecklace ), 100, 20, 0x1089, 0 ) );
				Add( new GenericBuyInfo( typeof( Beads ), 50, 20, 0x108B, 0 ) );
				Add( new GenericBuyInfo( typeof( GoldBracelet ), 80, 20, 0x1086, 0 ) );
				Add( new GenericBuyInfo( typeof( GoldEarrings ), 60, 20, 0x1087, 0 ) );

				Add( new GenericBuyInfo( typeof( Agate ), 30, 999, 0xF17, 2307 ) );
				Add( new GenericBuyInfo( typeof( Beryl ), 47, 999, 0xF2F, 496 ) );
				Add( new GenericBuyInfo( typeof( ChromeDiopside ), 70, 999, 0xF1C, 1902 ) );
				Add( new GenericBuyInfo( typeof( FireOpal ), 95, 999, 0xF15, 1357 ) );
				Add( new GenericBuyInfo( typeof( MoonstoneCustom ), 35, 999, 0xF1B, 1846 ) );
				Add( new GenericBuyInfo( typeof( Onyx ), 43, 999, 0xF18, 1905 ) );
				Add( new GenericBuyInfo( typeof( Opal ), 15, 999, 0xF26, 1187 ) );
				Add( new GenericBuyInfo( typeof( Pearl ), 31, 999, 0xF2B, 2960 ) );
				Add( new GenericBuyInfo( typeof( TurquoiseCustom ), 53, 999, 0xF15, 1286 ) );

				Add( new GenericBuyInfo( typeof( Bloodstone ), 162, 999, 0xF2F, 1194 ) );
				Add( new GenericBuyInfo( typeof( Citrine ), 169, 999, 0xF15, 0 ) );
				Add( new GenericBuyInfo( typeof( Demantoid ), 134, 999, 0xF26, 2076 ) );
				Add( new GenericBuyInfo( typeof( Jasper ), 165, 999, 0xF1B, 538 ) );
				Add( new GenericBuyInfo( typeof( Lolite ), 181, 999, 0xF17, 1176 ) );
				Add( new GenericBuyInfo( typeof( Lupis ), 144, 999, 0xF15, 2124 ) );
				Add( new GenericBuyInfo( typeof( Peridot ), 120, 999, 0xF18, 2126 ) );
				Add( new GenericBuyInfo( typeof( Tsavorite ), 193, 999, 0xF1C, 1594 ) );
				Add( new GenericBuyInfo( typeof( Zircon ), 112, 999, 0xF2B, 2422 ) );

				Add( new GenericBuyInfo( typeof( Amber ), 243, 999, 0xF25, 0 ) );
				Add( new GenericBuyInfo( typeof( Amethyst ), 242, 999, 0xF16, 0 ) );
				Add( new GenericBuyInfo( typeof( Andalusite ), 264, 999, 0xF2F, 2424 ) );
				Add( new GenericBuyInfo( typeof( Chrysoberyl ), 288, 999, 0xF15, 2961 ) );
				Add( new GenericBuyInfo( typeof( Garnet ), 238, 999, 0xF1B, 2116 ) );
				Add( new GenericBuyInfo( typeof( Jade ), 205, 999, 0xF17, 2002 ) );
				Add( new GenericBuyInfo( typeof( Mandarin ), 232, 999, 0xF2B, 1358 ) );
				Add( new GenericBuyInfo( typeof( Morganite ), 252, 999, 0xF26, 2970 ) );
				Add( new GenericBuyInfo( typeof( Paraiba ), 291, 999, 0xF18, 2499 ) );
				Add( new GenericBuyInfo( typeof( TigerEye ), 281, 999, 0xF1C, 1192 ) );
				Add( new GenericBuyInfo( typeof( Tourmaline ), 206, 999, 0xF2D, 0 ) );

				Add( new GenericBuyInfo( typeof( Alexandrite ), 360, 999, 0xF26, 2591 ) );
				Add( new GenericBuyInfo( typeof( Ametrine ), 353, 999, 0xF1B, 2599 ) );
				Add( new GenericBuyInfo( typeof( Kunzite ), 359, 999, 0xF17, 2535 ) );
				Add( new GenericBuyInfo( typeof( Ruby ), 392, 20, 0xF13, 0 ) );
				Add( new GenericBuyInfo( typeof( Sapphire ), 304, 999, 0xF19, 0 ) );
				Add( new GenericBuyInfo( typeof( Tanzanite ), 377, 999, 0xF15, 2593 ) );
				Add( new GenericBuyInfo( typeof( Topaz ), 386, 999, 0xF1C, 2952 ) );
				Add( new GenericBuyInfo( typeof( Zultanite ), 354, 999, 0xF2F, 2105 ) );

				Add( new GenericBuyInfo( typeof( Diamond ), 495, 999, 0xF26, 0 ) );
				Add( new GenericBuyInfo( typeof( Emerald ), 440, 999, 0xF10, 0 ) );
				Add( new GenericBuyInfo( typeof( PinkQuartz ), 454, 999, 0xF17, 2662 ) );
				Add( new GenericBuyInfo( typeof( StarSapphire ), 463, 999, 0xF21, 0 ) );

				Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ),  100, 20, 0x1ED0, 0, new object[] {  500 } ) ); // 500 charges
				Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ), 200, 20, 0x1ED0, 0, new object[] { 1000 } ) ); // 1000 charges
				Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ), 300, 20, 0x1ED0, 0, new object[] { 2000 } ) ); // 2000 charges

				Add( new GenericBuyInfo( "1060740", typeof( ReceiverCrystal ), 50, 20, 0x1ED0, 0 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( Agate ), 30 );
				Add( typeof( Beryl ), 47 );
				Add( typeof( ChromeDiopside ), 70 );
				Add( typeof( FireOpal ), 95 );
				Add( typeof( MoonstoneCustom ), 35 );
				Add( typeof( Onyx ), 43 );
				Add( typeof( Opal ), 15 );
				Add( typeof( Pearl ), 31 );
				Add( typeof( TurquoiseCustom ), 53 );

				Add( typeof( Bloodstone ), 162 );
				Add( typeof( Citrine ), 169 );
				Add( typeof( Demantoid ), 134 );
				Add( typeof( Jasper ), 165 );
				Add( typeof( Lolite ), 181 );
				Add( typeof( Lupis ), 144 );
				Add( typeof( Peridot ), 120 );
				Add( typeof( Tsavorite ), 193 );
				Add( typeof( Zircon ), 112 );

				Add( typeof( Amber ), 243 );
				Add( typeof( Amethyst ), 242 );
				Add( typeof( Andalusite ), 264 );
				Add( typeof( Chrysoberyl ), 288 );
				Add( typeof( Garnet ), 238 );
				Add( typeof( Jade ), 205 );
				Add( typeof( Mandarin ), 232 );
				Add( typeof( Morganite ), 252 );
				Add( typeof( Paraiba ), 291 );
				Add( typeof( TigerEye ), 281 );
				Add( typeof( Tourmaline ), 206 );

				Add( typeof( Alexandrite ), 360 );
				Add( typeof( Ametrine ), 353 );
				Add( typeof( Kunzite ), 359 );
				Add( typeof( Ruby ), 392 );
				Add( typeof( Sapphire ), 304 );
				Add( typeof( Tanzanite ), 377 );
				Add( typeof( Topaz ), 386 );
				Add( typeof( Zultanite ), 354 );

				Add( typeof( Diamond ), 495 );
				Add( typeof( Emerald ), 440 );
				Add( typeof( PinkQuartz ), 454 );
				Add( typeof( StarSapphire ), 463 );

				Add( typeof( GoldRing ), 25 );
				Add( typeof( SilverRing ), 25 );

				Add( typeof( Necklace ), 50 );
				Add( typeof( GoldNecklace ), 50 );
				Add( typeof( GoldBeadNecklace ), 50 );
				Add( typeof( SilverNecklace ), 50 );
				Add( typeof( SilverBeadNecklace ), 50 );

				Add( typeof( Beads ), 25 );

				Add( typeof( GoldBracelet ), 40 );
				Add( typeof( SilverBracelet ), 40 );

				Add( typeof( GoldEarrings ), 30 );
				Add( typeof( SilverEarrings ), 30 );
			} 
		} 
	} 
}
