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
using Server.Mobiles;

namespace Server.Mobiles
{
	public class SisterOfMagicResist : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

                public override bool IsInvulnerable{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public SisterOfMagicResist() : base( "the Scarlet Sister of Magic Resist" ) 
		{
                }

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBSisterOfMagicResist() ); 
		}

		public override void InitOutfit()
		{
			Name = "Leehdias Kylmia";
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
                        Hue = 1032;
                        HairItemID = 12241;
                        HairHue = 1419;

			SetSkill( SkillName.MagicResist, 120.0 );

			CloakOfHumility cloak = new CloakOfHumility(); 
			cloak.Hue = 733; 
			cloak.Movable = false; 
			AddItem( cloak );

			AddItem( new ElvenShirt(858) );
			AddItem( new Hakama(858) );
			AddItem( new Obi(733) );
			AddItem( new Waraji(733) );

			NoDachi weapon = new NoDachi();
			weapon.Hue = 718; 
			weapon.Movable = false; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );
                }

		public SisterOfMagicResist( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new SisterOfMagicResistEntry( from, this ) );
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

		public class SisterOfMagicResistEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public SisterOfMagicResistEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( SisterOfSkillGump ) ) )
					{
						mobile.SendGump( new SisterOfSkillGump( mobile ));	
					}
				}
			}
		}
        }

	public class SBSisterOfMagicResist : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSisterOfMagicResist()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Scarlet Band Of Magic Resist", typeof( ScarletBandOfMagicResist ), 500, 10, 0x1F06, 1608 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( ScarletBandOfMagicResist ), 250 );
			}
		}
	}
}