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
using Server.ACC.CSS.Systems.Bard;

namespace Server.Mobiles 
{ 
	public class ElmhavenBard : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 


		[Constructable]
		public ElmhavenBard() : base( "the bard" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElmhavenBard() ); 
		}

		public override void InitOutfit()
		{
			Name = "Caius";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33821;
                        HairItemID = 0;
                        HairHue = 0;
                        FacialHairItemID = 8267;
                        FacialHairHue = 1124;

			SetStr( 148 );
			SetDex( 106 );
			SetInt( 67 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );
			SetSkill( SkillName.Discordance, 64.0, 100.0 );
			SetSkill( SkillName.Musicianship, 64.0, 100.0 );
			SetSkill( SkillName.Peacemaking, 65.0, 88.0 );
			SetSkill( SkillName.Provocation, 60.0, 83.0 );
			SetSkill( SkillName.Swords, 36.0, 68.0 );

			PackGold( 46, 75 );

			AddItem( new SkullCap(553) );
			AddItem( new Cloak(758) );
			AddItem( new FancyShirt(668) );
			AddItem( new Doublet(353) );
			AddItem( new FancyPants(773) );
			AddItem( new LightBoots(973) );
                }

		public ElmhavenBard( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenBardEntry( from, this ) );
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

		public class ElmhavenBardEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenBardEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElmhavenBardGump ) ) )
					{
						mobile.SendGump( new ElmhavenBardGump( mobile ));
						
					}
				}
			}
		}

	public class SBElmhavenBard : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBElmhavenBard() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 	
				Add( new GenericBuyInfo( "Bard Spellbook", typeof( BardSpellbook ), 1000, 10, 0xEFA, 0x96 ) );

				Add( new GenericBuyInfo( "Energy Threnody Scroll", typeof( BardEnergyThrenodyScroll ), 200, 244, 0x14ED, 0x96 ) );
				Add( new GenericBuyInfo( "Fire Threnody Scroll", typeof( BardFireThrenodyScroll ), 200, 368, 0x14ED, 0x96 ) );
				Add( new GenericBuyInfo( "Ice Threnody Scroll", typeof( BardIceThrenodyScroll ), 200, 368, 0x14ED, 0x96 ) );
				Add( new GenericBuyInfo( "Poison Threnody Scroll", typeof( BardPoisonThrenodyScroll ), 200, 251, 0x14ED, 0x96 ) );

				Add( new GenericBuyInfo( "Students Necklace of Harmony", typeof( StudentsNecklaceOfHarmony ), 1350, 10, 0x1085, 2127 ) ); 

				Add( new GenericBuyInfo( typeof( Drums ), 500, ( 20 ), 0x0E9C, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Tambourine ), 500, ( 20 ), 0x0E9E, 0 ) ); 
				Add( new GenericBuyInfo( typeof( LapHarp ), 500, ( 20 ), 0x0EB2, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Lute ), 500, ( 20 ), 0x0EB3, 0 ) ); 
 
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( BardSpellbook ), 250 ); 

				Add( typeof( BardEnergyCarolScroll ), 50 ); 
				Add( typeof( BardFireCarolScroll ), 50 ); 
				Add( typeof( BardIceCarolScroll ), 50 ); 
				Add( typeof( BardPoisonCarolScroll ), 50 ); 

				Add( typeof( BardEnergyThrenodyScroll ), 100 ); 
				Add( typeof( BardFireThrenodyScroll ), 100 ); 
				Add( typeof( BardIceThrenodyScroll ), 100 ); 
				Add( typeof( BardPoisonThrenodyScroll ), 100 ); 

				Add( typeof( LapHarp ), 25 ); 
				Add( typeof( Lute ), 25 ); 
				Add( typeof( Drums ), 25 ); 
				Add( typeof( Harp ), 50 ); 
				Add( typeof( Tambourine ), 25 ); 
			} 
		} 
	} 
}
