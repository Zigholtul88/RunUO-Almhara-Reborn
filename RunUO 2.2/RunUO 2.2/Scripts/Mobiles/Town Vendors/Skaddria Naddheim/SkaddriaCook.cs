using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Engines.Craft;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;
using Server.Engines.BulkOrders;

namespace Server.Mobiles 
{ 
	public class SkaddriaCook : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public SkaddriaCook() : base( "the cook" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBSkaddriaCook() ); 
		}

		public override void InitOutfit()
		{
			SetStr( 117 );
			SetDex( 96 );
			SetInt( 54 );

			SetSkill( SkillName.Cooking, 75.0, 98.0 );
			SetSkill( SkillName.TasteID, 36.0, 68.0 );

			PackGold( 23, 35 );

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

		#region Bulk Orders
		public override Item CreateBulkOrder( Mobile from, bool fromContextMenu )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm != null && pm.NextCookingBulkOrder == TimeSpan.Zero && (fromContextMenu || 0.2 > Utility.RandomDouble()) )
			{
				double theirSkill = pm.Skills[SkillName.Cooking].Base;

				if ( theirSkill >= 70.1 )
					pm.NextCookingBulkOrder = TimeSpan.FromHours( 3.0 );
				else if ( theirSkill >= 50.1 )
					pm.NextCookingBulkOrder = TimeSpan.FromHours( 2.0 );
				else
					pm.NextCookingBulkOrder = TimeSpan.FromHours( 1.0 );

				return SmallCookingBOD.CreateRandomFor( from );
			}

			return null;
		}

		public override bool IsValidBulkOrder( Item item )
		{
			return ( item is SmallCookingBOD || item is LargeCookingBOD );
		}

		public override bool SupportsBulkOrders( Mobile from )
		{
			return ( from is PlayerMobile && from.Skills[SkillName.Cooking].Base > 0 );
		}

		public override TimeSpan GetNextBulkOrder( Mobile from )
		{
			if ( from is PlayerMobile )
				return ((PlayerMobile)from).NextCookingBulkOrder;

			return TimeSpan.Zero;
		}

		public override void OnSuccessfulBulkOrderReceive( Mobile from )
		{
			if( Core.SE && from is PlayerMobile )
				((PlayerMobile)from).NextCookingBulkOrder = TimeSpan.Zero;
		}
		#endregion

		public SkaddriaCook( Serial serial ) : base( serial ) 
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

	public class SBSkaddriaCook : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBSkaddriaCook() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{
				Add( new GenericBuyInfo( typeof( SackFlour ), 5, 999, 0x1039, 0 ) );
				Add( new GenericBuyInfo( typeof( JarHoney ), 3, 999, 0x9EC, 0 ) );
				Add( new GenericBuyInfo( typeof( RollingPin ), 2, 999, 0x1043, 0 ) );
				Add( new GenericBuyInfo( typeof( FlourSifter ), 2, 999, 0x103E, 0 ) );
				Add( new GenericBuyInfo( "1044567", typeof( Skillet ), 3, 999, 0x97F, 0 ) );

				Add( new GenericBuyInfo( typeof( FoodPlate ), 5, 999, 0x9D7, 0 ) );

				Add( new GenericBuyInfo( typeof( FriedChickenEggs ), 15, 500, 0x9B6, 0 ) );
				Add( new GenericBuyInfo( typeof( FriedDuckEggs ), 15, 500, 0x9B6, 0 ) );
				Add( new GenericBuyInfo( typeof( FriedEggs ), 15, 500, 0x9B6, 0 ) );

				Add( new GenericBuyInfo( typeof( ChickenLeg ), 5, 200, 0x1608, 0 ) );
				Add( new GenericBuyInfo( typeof( CookedBird ), 17, 200, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( DuckLeg ), 7, 200, 0x1608, 0 ) );
				Add( new GenericBuyInfo( typeof( LambLeg ), 8, 200, 0x160A, 0 ) );
				Add( new GenericBuyInfo( typeof( RoastChicken ), 98, 200, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( RoastDuck ), 103, 200, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( RoastPig ), 106, 200, 0x9BB, 0 ) );
				Add( new GenericBuyInfo( typeof( RoastTurkey ), 225, 200, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( SlicedTurkey ), 13, 200, 0x1E1F, 0 ) );

				Add( new GenericBuyInfo( typeof( TurkeyPlatter ), 247, 200, 0x4988, 0 ) );
				Add( new GenericBuyInfo( typeof( TurkeyLeg ), 28, 200, 0x1607, 0 ) );

				Add( new GenericBuyInfo( typeof( AsianVegMix ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlCornFlakes ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlRiceKrisps ), 20, 100, 0x1602, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseSauce ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( ChocIceCream ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( Gravy ), 20, 100, 0x15FD, 1012 ) );
				Add( new GenericBuyInfo( typeof( MixedVegetables ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( BroccoliCheese ), 20, 100, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( BroccoliCaulCheese ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( ChickenNoodleSoup ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlBeets ), 20, 100, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlBroccoli ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlCauliflower ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlGreenBeans ), 20, 100, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlSpinach ), 20, 100, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlTurnips ), 20, 100, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlMashedPotatos ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( MacaroniCheese ), 20, 100, 0x15FF, 0 ) );
				Add( new GenericBuyInfo( typeof( CauliflowerCheese ), 20, 100, 0x1602, 0 ) );
				Add( new GenericBuyInfo( typeof( PotatoFries ), 15, 100, 0x160C, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlOatmeal ), 20, 100, 0x1602, 0 ) );
				Add( new GenericBuyInfo( typeof( TomatoRice ), 20, 100, 0x1606, 0 ) );
				Add( new GenericBuyInfo( typeof( Popcorn ), 20, 100, 0x1602, 0 ) );

				Add( new GenericBuyInfo( typeof( BowlRice ), 20, 200, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlCookedVeggies ), 20, 200, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfCarrots ), 20, 200, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfCorn ), 20, 200, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfLettuce ), 20, 200, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfPeas ), 20, 200, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( EmptyPewterBowl ), 5, 500, 0x15FD, 0 ) );

				Add( new GenericBuyInfo( typeof( PewterBowlOfCorn ), 20, 200, 0x15FE, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfLettuce ), 20, 200, 0x15FF, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPeas ), 20, 200, 0x1600, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPotatos ), 20, 200, 0x1601, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlOfStew ), 20, 200, 0x1604, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfStew ), 20, 200, 0x1604, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfTomatoSoup ), 200, 20, 0x1606, 0 ) );
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
