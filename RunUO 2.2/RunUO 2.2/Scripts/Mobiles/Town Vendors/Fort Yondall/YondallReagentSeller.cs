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
using Server.ACC.CSS.Systems.Druid;

namespace Server.Mobiles 
{ 
	public class YondallReagentSeller : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public YondallReagentSeller() : base( "the reagent seller" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBYondallReagentSeller() ); 
		}

		public override void InitOutfit()
		{
			SetStr( 117 );
			SetDex( 96 );
			SetInt( 54 );

			SetSkill( SkillName.Alchemy, 85.0, 100.0 );
			SetSkill( SkillName.EvalInt, 65.0, 88.0 );
			SetSkill( SkillName.Magery, 64.0, 100.0 );
			SetSkill( SkillName.MagicResist, 65.0, 88.0 );
			SetSkill( SkillName.TasteID, 65.0, 88.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 44, 88 );

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

		public YondallReagentSeller( Serial serial ) : base( serial ) 
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

	public class SBYondallReagentSeller : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBYondallReagentSeller()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Reagent Harvesting Axe", typeof( ReagentAxe ), 100, 999, 0xF43, 64 ) );

				Add( new GenericBuyInfo( typeof( BlackPearl ), 8, 999, 0xF7A, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 8, 999, 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 8, 999, 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 8, 999, 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 8, 999, 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 8, 999, 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 8, 999, 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 8, 999, 0xF8C, 0 ) );

				Add( new GenericBuyInfo( typeof( BatWing ), 8, 999, 0xF78, 0 ) );
				Add( new GenericBuyInfo( typeof( DaemonBlood ), 8, 999, 0xF7D, 0 ) );
				Add( new GenericBuyInfo( typeof( GraveDust ), 8, 999, 0xF8F, 0 ) );
				Add( new GenericBuyInfo( typeof( NoxCrystal ), 8, 999, 0xF8E, 0 ) );
				Add( new GenericBuyInfo( typeof( PigIron ), 8, 999, 0xF8A, 0 ) );

				Add( new GenericBuyInfo( "Destroying Angel", typeof( DestroyingAngel ), 8, 999, 0xE1F, 0x290 ) );
				Add( new GenericBuyInfo( "Petrafied Wood", typeof( PetrafiedWood ), 8, 999, 0x97A, 0x46C ) );
				Add( new GenericBuyInfo( "Spring Water", typeof( SpringWater ), 8, 999, 0xE24, 0x47F ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( BlackPearl ), 1 ); 
				Add( typeof( Bloodmoss ), 1 ); 
				Add( typeof( MandrakeRoot ), 1 ); 
				Add( typeof( Garlic ), 1 ); 
				Add( typeof( Ginseng ), 1 ); 
				Add( typeof( Nightshade ), 1 ); 
				Add( typeof( SpidersSilk ), 1 ); 
				Add( typeof( SulfurousAsh ), 1 ); 

				Add( typeof( BatWing ), 1 );
				Add( typeof( DaemonBlood ), 1 );
				Add( typeof( GraveDust ), 1 );
				Add( typeof( NoxCrystal ), 1 );
				Add( typeof( PigIron ), 1 );

				Add( typeof( DestroyingAngel ), 1 ); 
				Add( typeof( PetrafiedWood ), 1 ); 
				Add( typeof( SpringWater ), 1 ); 
			}
		}
	}
}
