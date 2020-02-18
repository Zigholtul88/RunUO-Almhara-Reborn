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
	public class ElandrimNurShazWeaponsmith : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public ElandrimNurShazWeaponsmith() : base( "the weaponsmith" )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBElandrimNurShazWeaponsmith() );
		}

		public override void InitOutfit()
		{
			Name = "Xandarthaxx";
                 	Body = 605;
                        Female = false;
                        Race = Race.Elf;
                        Hue = 2404;
                        HairItemID = 12225;
                        HairHue = 1419;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			SetStr( 267 );
			SetDex( 229 );
			SetInt( 168 );

			SetSkill( SkillName.ArmsLore, 36.0, 68.0 );
			SetSkill( SkillName.Blacksmith, 65.0, 88.0 );
			SetSkill( SkillName.Fencing, 60.0, 83.0 );
			SetSkill( SkillName.Macing, 61.0, 93.0 );
			SetSkill( SkillName.Swords, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );

			PackGold( 8, 16 );

			AddItem( new ThighBoots() );

			HideChest chest = new HideChest();
			chest.Movable = true;
			AddItem( chest );

			HideGloves gloves = new HideGloves();
			gloves.Movable = true;
			AddItem( gloves );

			HideGorget gorget = new HideGorget();
			gorget.Movable = true;
			AddItem( gorget );

			HidePants legs = new HidePants();
			legs.Movable = true;
			AddItem( legs );

			OrnateAxe weapon = new OrnateAxe();
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );
                }

		public ElandrimNurShazWeaponsmith( Serial serial ) : base( serial )
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

	public class SBElandrimNurShazWeaponsmith : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElandrimNurShazWeaponsmith()
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