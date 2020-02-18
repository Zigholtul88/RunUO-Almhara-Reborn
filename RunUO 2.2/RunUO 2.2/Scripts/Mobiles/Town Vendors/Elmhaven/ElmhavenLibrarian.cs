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
	public class ElmhavenLibrarian : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		[Constructable]
		public ElmhavenLibrarian() : base( "the librarian" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElmhavenLibrarian() ); 
		}

		public override void InitOutfit()
		{
			Name = "Cadahan";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33814;
                        HairItemID = 8253;
                        HairHue = 1141;
                        FacialHairItemID = 8269;
                        FacialHairHue = 1141;

			SetStr( 158 );
			SetDex( 75 );
			SetInt( 102 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 42, 67 );

			AddItem( new FancyShirt(608) );
			AddItem( new Doublet(718) );
			AddItem( new FancyPants(613) );
			AddItem( new ShortBoots(823) );
                }

		public ElmhavenLibrarian( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenLibrarianEntry( from, this ) );
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

		public class ElmhavenLibrarianEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenLibrarianEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}
			
			public override void OnClick()
			{
				if( !( m_Mobile is PlayerMobile ) )
					return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;
				{
					if ( ! mobile.HasGump( typeof( ElmhavenLibrarianGump ) ) )
					{
						mobile.SendGump( new ElmhavenLibrarianGump( mobile ));
						
					}
				}
			}
		}
        }

	public class SBElmhavenLibrarian : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElmhavenLibrarian()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( ArmsAndWeaponsPrimer ), 50, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( ChildrenTalesVol2 ), 50, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( DimensionalTravel ), 50, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( DiversityOfOurLand ), 50, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( EthicalHedonism ), 50, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( GrammarOfOrcish ), 50, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( MyStory ), 50, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( RankingsOfTrades ), 50, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( RegardingLlamas ), 50, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( TalkingToWisps ), 50, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( TamingDragons ), 50, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( TheFight ), 50, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( TreatiseOnAlchemy ), 50, 20, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( WildGirlOfTheForest ), 50, 20, 0xFEF, 0 ) );

				Add( new GenericBuyInfo( "Book of Zoo Travel", typeof( BookOfZooTravel ), 1000, 100, 17080, 0 ) );

				Add( new GenericBuyInfo( "TamersHandbookEcology", typeof( TamersHandbookEcology ), 5, 999, 0x1C11, 2110 ) );

				Add( new GenericBuyInfo( "ModernGenesisC1", typeof( ModernGenesisC1 ), 500, 100, 0x1C11, 2126 ) );
				Add( new GenericBuyInfo( "ModernGenesisC2", typeof( ModernGenesisC2 ), 500, 100, 0x1C11, 2126 ) );
				Add( new GenericBuyInfo( "ModernGenesisC3", typeof( ModernGenesisC3 ), 500, 100, 0x1C11, 2126 ) );
				Add( new GenericBuyInfo( "ModernGenesisC4", typeof( ModernGenesisC4 ), 500, 100, 0x1C11, 2126 ) );
				Add( new GenericBuyInfo( "ModernGenesisC5", typeof( ModernGenesisC5 ), 500, 100, 0x1C11, 2126 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( GrammarOfOrcish ), 25 );
				Add( typeof( ArmsAndWeaponsPrimer ), 25 );
				Add( typeof( ChildrenTalesVol2 ), 25 );
				Add( typeof( DimensionalTravel ), 25 );
				Add( typeof( EthicalHedonism ), 25 );
				Add( typeof( MyStory ), 25 );
				Add( typeof( DiversityOfOurLand ), 25 );
				Add( typeof( RegardingLlamas ), 25 );
				Add( typeof( TalkingToWisps ), 25 );
				Add( typeof( TamingDragons ), 25 );
				Add( typeof( TheFight ), 25 );
				Add( typeof( RankingsOfTrades ), 25 );
				Add( typeof( WildGirlOfTheForest ), 25 );
				Add( typeof( TreatiseOnAlchemy ), 25 );

				Add( typeof( ModernGenesisC1 ), 250 );
				Add( typeof( ModernGenesisC2 ), 250 );
				Add( typeof( ModernGenesisC3 ), 250 );
				Add( typeof( ModernGenesisC4 ), 250 );
				Add( typeof( ModernGenesisC5 ), 250 );
			}
		}
	}
}
