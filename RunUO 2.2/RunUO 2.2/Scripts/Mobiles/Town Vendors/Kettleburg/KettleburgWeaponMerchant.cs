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
	public class KettleburgWeaponMerchant : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public KettleburgWeaponMerchant() : base( "the weapon merchant" )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBKettleburgWeaponMerchant() );
		}

		public override void InitOutfit()
		{
			SetStr( 117 );
			SetDex( 96 );
			SetInt( 54 );

			SetSkill( SkillName.ArmsLore, 64.0, 100.0 );
			SetSkill( SkillName.Fencing, 45.0, 68.0 );
			SetSkill( SkillName.Macing, 87.2, 95.3 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );
			SetSkill( SkillName.Swords, 45.0, 68.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );

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

		public KettleburgWeaponMerchant( Serial serial ) : base( serial )
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

	public class SBKettleburgWeaponMerchant: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBKettleburgWeaponMerchant()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
////////////////////////////////////////////////////// Axes
				Add( new GenericBuyInfo( typeof( Hatchet ), 150, 500, 0xF43, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Axe ), 200, 500, 0xF49, 0 ) ); // Level 5
				Add( new GenericBuyInfo( typeof( BattleAxe ), 300, 500, 0xF47, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( DoubleAxe ), 500, 500, 0xF4B, 0 ) ); // Level 20
				Add( new GenericBuyInfo( typeof( TwoHandedAxe ), 600, 500, 0x1443, 0 ) ); // Level 25

////////////////////////////////////////////////////// Bashing
				Add( new GenericBuyInfo( typeof( Club ), 100, 500, 0x13B4, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Nunchaku ), 100, 500, 0x27F9, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Mace ), 200, 500, 0xF5C, 0 ) ); // Level 5
				Add( new GenericBuyInfo( typeof( Maul ), 300, 500, 0x143B, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( Scepter ), 400, 500, 0x26BC, 0 ) ); // Level 15
				Add( new GenericBuyInfo( typeof( WarMace ), 500, 500, 0x1407, 0 ) ); // Level 20
				Add( new GenericBuyInfo( typeof( Tessen ), 600, 500, 0x27A3, 0 ) ); // Level 25

////////////////////////////////////////////////////// Knives
				Add( new GenericBuyInfo( typeof( Leafblade ), 50, 500, 0x2D22, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( SkinningKnife ), 50, 500, 0xEC5, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Cleaver ), 100, 500, 0xEC2, 0 ) ); // Level 5
				Add( new GenericBuyInfo( typeof( Dagger ), 100, 500, 0xF52, 0 ) ); // Level 5
				Add( new GenericBuyInfo( typeof( ButcherKnife ), 150, 500, 0x13F7, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( EbonyDagger ), 150, 500, 15819, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( Sai ), 200, 500, 0x27AF, 0 ) ); // Level 15
				Add( new GenericBuyInfo( typeof( EbonyDualDaggers ), 250, 500, 15820, 0 ) ); // Level 20
				Add( new GenericBuyInfo( typeof( Tekagi ), 300, 500, 0x27Ab, 0 ) ); // Level 25

////////////////////////////////////////////////////// Spears and Forks
				Add( new GenericBuyInfo( typeof( Pitchfork ), 150, 500, 0xE87, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( ShortSpear ), 200, 500, 0x1403, 0 ) ); // Level 5
				Add( new GenericBuyInfo( typeof( Pilum ), 300, 500, 15380, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( Pike ), 400, 500, 0x26BE, 0 ) ); // Level 15
				Add( new GenericBuyInfo( typeof( Spear ), 500, 500, 0xF62, 0 ) ); // Level 20
				Add( new GenericBuyInfo( typeof( BoneSpear ), 600, 500, 15377, 0 ) ); // Level 25

////////////////////////////////////////////////////// Staves
				Add( new GenericBuyInfo( typeof( GnarledStaff ), 100, 500, 0x13F8, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( ShepherdsCrook ), 100, 500, 0xE81, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( QuarterStaff ), 300, 500, 0xE89, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( ReptilianStaff ), 400, 500, 15393, 0 ) ); // Level 15
				Add( new GenericBuyInfo( typeof( BubbleStaff ), 600, 500, 15385, 0 ) ); // Level 25
				Add( new GenericBuyInfo( typeof( CrystalStaff ), 600, 500, 16176, 0 ) ); // Level 25
				Add( new GenericBuyInfo( typeof( EnergyStaff ), 600, 500, 15390, 0 ) ); // Level 25
				Add( new GenericBuyInfo( typeof( FireStaff ), 600, 500, 15391, 0 ) ); // Level 25
				Add( new GenericBuyInfo( typeof( VineStaff ), 600, 500, 15396, 0 ) ); // Level 25

////////////////////////////////////////////////////// Swords
				Add( new GenericBuyInfo( typeof( Bokuto ), 100, 500, 0x27F3, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( BoneHarvester ), 100, 500, 0x26C5, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Cutlass ), 100, 500, 0x1441, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( ElvenMachete ), 100, 500, 0x2D35, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Kryss ), 100, 500, 0x1400, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( EbonyRapier ), 300, 500, 15826, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( Scimitar ), 300, 500, 0x13B5, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( Longsword ), 500, 500, 0xF61, 0 ) ); // Level 20
				Add( new GenericBuyInfo( typeof( VikingSword ), 500, 500, 0x13B9, 0 ) ); // Level 20
				Add( new GenericBuyInfo( typeof( Wakizashi ), 500, 500, 0x27A4, 0 ) ); // Level 20
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
