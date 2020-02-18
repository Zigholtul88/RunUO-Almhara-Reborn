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
	public class ElmhavenGemCrafter : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 


		[Constructable]
		public ElmhavenGemCrafter() : base( "the gem crafter" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElmhavenGemCrafter() ); 
		}

		public override void InitOutfit()
		{
			Name = "Melanchalth";
                 	Body = 667;
                  Female = true;
                  Hue = 1763;
                  HairItemID = 499;
                  HairHue = 20;

			SetStr( 164 );
			SetDex( 114 );
			SetInt( 172 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Blacksmith, 65.0, 88.0 );
			SetSkill( SkillName.Swords, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 23, 71 );

			GlassSword weapon = new GlassSword();
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );

			GargishClothWingArmor cloak = new GargishClothWingArmor();
			cloak.Hue = 618;
			cloak.Movable = true;
			AddItem( cloak );

			FemaleGargishClothArms arms = new FemaleGargishClothArms();
			arms.Hue = 618;
			arms.Movable = true;
			AddItem( arms );

			FemaleGargishClothChest chest = new FemaleGargishClothChest();
			chest.Hue = 618;
			chest.Movable = true;
			AddItem( chest );

			FemaleGargishClothKilt outerlegs = new FemaleGargishClothKilt();
			outerlegs.Hue = 618;
			outerlegs.Movable = true;
			AddItem( outerlegs );

			FemaleGargishClothLegs legs = new FemaleGargishClothLegs();
			legs.Hue = 618;
			legs.Movable = true;
			AddItem( legs );

			LeatherTalons shoes = new LeatherTalons();
			shoes.Hue = 618;
			shoes.Movable = true;
			AddItem( shoes );
            }

		public ElmhavenGemCrafter( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenGemCrafterEntry( from, this ) );
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

		public class ElmhavenGemCrafterEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenGemCrafterEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElmhavenGemCrafterGump ) ) )
					{
						mobile.SendGump( new ElmhavenGemCrafterGump( mobile ));
						
					}
				}
			}
		}

	public class SBElmhavenGemCrafter : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElmhavenGemCrafter()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Gem Carving Tool", typeof( GemCarvingTool ), 100, 500, 0x12B3, 781 ) );

				Add( new GenericBuyInfo( "Clear Hollowed Gem", typeof( ClearHollowedGem ), 25, 500, 0x3198, 2498 ) );
				Add( new GenericBuyInfo( "Earth Stone", typeof( EarthStone ), 25, 500, 0xF26, 1804 ) );
				Add( new GenericBuyInfo( "Energy Stone", typeof( EnergyStone ), 25, 500, 0xF26, 485 ) );
				Add( new GenericBuyInfo( "Fire Stone", typeof( FireStone ), 25, 500, 0xF26, 1360 ) );
				Add( new GenericBuyInfo( "Ice Stone", typeof( IceStone ), 25, 500, 0xF26, 1152 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( GemCarvingTool ), 50 );
			}
		}
	}
}
