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
	public class SkaddriaWeaponMerchant : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public SkaddriaWeaponMerchant() : base( "the weapon merchant" )
		{
                }

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBSkaddriaWeaponMerchant() );
		}

		public override void InitOutfit()
		{
			Name = "Luthor Yorkshire";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33815;
                        HairItemID = 8261;
                        HairHue = 1149;
                        FacialHairItemID = 8257;
                        FacialHairHue = 1149;

			SetStr( 95 );
			SetDex( 72 );
			SetInt( 31 );

			SetSkill( SkillName.ArmsLore, 64.0, 100.0 );
			SetSkill( SkillName.Fencing, 45.0, 68.0 );
			SetSkill( SkillName.Macing, 87.2, 95.3 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );
			SetSkill( SkillName.Swords, 45.0, 68.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );

			PackGold( 48, 96 );

			AddItem( new HeavyBoots() );

			LeatherArms arms = new LeatherArms();
			arms.Movable = true;
			AddItem( arms );

			RingmailChest chest = new RingmailChest();
			chest.Movable = true;
			AddItem( chest );

			LeatherGorget gorget = new LeatherGorget();
			gorget.Movable = true;
			AddItem( gorget );

			LeatherLegs legs = new LeatherLegs();
			legs.Movable = true;
			AddItem( legs );

			Mace weapon = new Mace();
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );
                }

		public SkaddriaWeaponMerchant( Serial serial ) : base( serial )
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

	public class SBSkaddriaWeaponMerchant: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSkaddriaWeaponMerchant()
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

////////////////////////////////////////////////////// Bashing
				Add( new GenericBuyInfo( typeof( Club ), 100, 500, 0x13B4, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Nunchaku ), 100, 500, 0x27F9, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Mace ), 200, 500, 0xF5C, 0 ) ); // Level 5

////////////////////////////////////////////////////// Knives
				Add( new GenericBuyInfo( typeof( Leafblade ), 50, 500, 0x2D22, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( SkinningKnife ), 50, 500, 0xEC5, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Cleaver ), 100, 500, 0xEC2, 0 ) ); // Level 5
				Add( new GenericBuyInfo( typeof( Dagger ), 100, 500, 0xF52, 0 ) ); // Level 5

////////////////////////////////////////////////////// Spears and Forks
				Add( new GenericBuyInfo( typeof( Pitchfork ), 150, 500, 0xE87, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( ShortSpear ), 200, 500, 0x1403, 0 ) ); // Level 5

////////////////////////////////////////////////////// Staves
				Add( new GenericBuyInfo( typeof( GnarledStaff ), 100, 500, 0x13F8, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( ShepherdsCrook ), 100, 500, 0xE81, 0 ) ); // Level 1

////////////////////////////////////////////////////// Swords
				Add( new GenericBuyInfo( typeof( Bokuto ), 100, 500, 0x27F3, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( BoneHarvester ), 100, 500, 0x26C5, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Cutlass ), 100, 500, 0x1441, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( ElvenMachete ), 100, 500, 0x2D35, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Kryss ), 100, 500, 0x1400, 0 ) ); // Level 1
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