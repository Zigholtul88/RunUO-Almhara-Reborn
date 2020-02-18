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
	public class RedDaggerKeepWeaponsmith2 : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public RedDaggerKeepWeaponsmith2() : base( "the weaponsmith" )
		{
                }

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBRedDaggerKeepWeaponsmith2() );
		}

		public override void InitOutfit()
		{
			Name = "Kourikata";
			Body = 87;
			BaseSoundID = 644;

			SetStr( 287 );
			SetDex( 159 );
			SetInt( 78 );

			SetSkill( SkillName.ArmsLore, 64.0, 100.0 );
			SetSkill( SkillName.Blacksmith, 65.0, 88.0 );
			SetSkill( SkillName.Fencing, 45.0, 68.0 );
			SetSkill( SkillName.Macing, 45.0, 68.0 );
			SetSkill( SkillName.Swords, 45.0, 68.0 );
			SetSkill( SkillName.Tactics, 36.0, 68.0 );

			PackGold( 42, 68 );
                }

		public RedDaggerKeepWeaponsmith2( Serial serial ) : base( serial )
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

	public class SBRedDaggerKeepWeaponsmith2: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBRedDaggerKeepWeaponsmith2()
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
				Add( new GenericBuyInfo( typeof( WarAxe ), 1000, 500, 0x13B0, 0 ) ); // Level 30
				Add( new GenericBuyInfo( typeof( OrnateAxe ), 1200, 500, 0x2D28, 0 ) ); // Level 35
				Add( new GenericBuyInfo( typeof( ExecutionersAxe ), 1500, 500, 0xF45, 0 ) ); // Level 40
				Add( new GenericBuyInfo( typeof( LargeBattleAxe ), 2000, 500, 0x13FB, 0 ) ); // Level 50

////////////////////////////////////////////////////// Bashing
				Add( new GenericBuyInfo( typeof( Club ), 100, 500, 0x13B4, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Nunchaku ), 100, 500, 0x27F9, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Mace ), 200, 500, 0xF5C, 0 ) ); // Level 5
				Add( new GenericBuyInfo( typeof( Maul ), 300, 500, 0x143B, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( Scepter ), 400, 500, 0x26BC, 0 ) ); // Level 15
				Add( new GenericBuyInfo( typeof( WarMace ), 500, 500, 0x1407, 0 ) ); // Level 20
				Add( new GenericBuyInfo( typeof( Tessen ), 600, 500, 0x27A3, 0 ) ); // Level 25
				Add( new GenericBuyInfo( typeof( HammerPick ), 1000, 500, 0x143D, 0 ) ); // Level 30
				Add( new GenericBuyInfo( typeof( DiamondMace ), 1200, 500, 0x2D24, 0 ) ); // Level 35
				Add( new GenericBuyInfo( typeof( WarHammer ), 1500, 500, 0x1439, 0 ) ); // Level 40
				Add( new GenericBuyInfo( typeof( Tetsubo ), 1800, 500, 0x27A6, 0 ) ); // Level 45
				Add( new GenericBuyInfo( typeof( EbonyMorningstar ), 2000, 500, 15812, 0 ) ); // Level 50

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
				Add( new GenericBuyInfo( typeof( ElvenSpellblade ), 500, 500, 0x2D20, 0 ) ); // Level 30
				Add( new GenericBuyInfo( typeof( Kama ), 800, 500, 0x27AD, 0 ) ); // Level 35
				Add( new GenericBuyInfo( typeof( Lajatang ), 1000, 500, 0x27A7, 0 ) ); // Level 40
				Add( new GenericBuyInfo( typeof( AssassinSpike ), 1500, 500, 0x2D21, 0 ) ); // Level 50
				Add( new GenericBuyInfo( typeof( WarCleaver ), 1500, 500, 0x2D2F, 0 ) ); // Level 50

////////////////////////////////////////////////////// Spears and Forks
				Add( new GenericBuyInfo( typeof( Pitchfork ), 150, 500, 0xE87, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( ShortSpear ), 200, 500, 0x1403, 0 ) ); // Level 5
				Add( new GenericBuyInfo( typeof( Pilum ), 300, 500, 15380, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( Pike ), 400, 500, 0x26BE, 0 ) ); // Level 15
				Add( new GenericBuyInfo( typeof( Spear ), 500, 500, 0xF62, 0 ) ); // Level 20
				Add( new GenericBuyInfo( typeof( BoneSpear ), 600, 500, 15377, 0 ) ); // Level 25
				Add( new GenericBuyInfo( typeof( SkeletalSpear ), 1200, 500, 15381, 0 ) ); // Level 35
				Add( new GenericBuyInfo( typeof( WarFork ), 1500, 500, 0x1405, 0 ) ); // Level 40
				Add( new GenericBuyInfo( typeof( BladedStaff ), 2000, 500, 0x26BD, 0 ) ); // Level 50

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
				Add( new GenericBuyInfo( typeof( BlackStaff ), 1000, 500, 0xDF1, 0 ) ); // Level 30
				Add( new GenericBuyInfo( typeof( WildStaff ), 1200, 500, 0x2D25, 0 ) ); // Level 35
				Add( new GenericBuyInfo( typeof( TribalStaff ), 1500, 500, 15816, 0 ) ); // Level 40
				Add( new GenericBuyInfo( typeof( PristineStaff ), 2000, 500, 16177, 0 ) ); // Level 50

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
				Add( new GenericBuyInfo( typeof( Daisho ), 1000, 500, 0x27A9, 0 ) ); // Level 30
				Add( new GenericBuyInfo( typeof( EbonyScimitar ), 1000, 500, 15824, 0 ) ); // Level 30
				Add( new GenericBuyInfo( typeof( RuneBlade ), 1000, 500, 0x2D32, 0 ) ); // Level 30
				Add( new GenericBuyInfo( typeof( PaladinSword ), 1200, 500, 0x26CE, 0 ) ); // Level 35
				Add( new GenericBuyInfo( typeof( Katana ), 1500, 500, 0x13FF, 0 ) ); // Level 40
				Add( new GenericBuyInfo( typeof( NoDachi ), 1500, 500, 0x27A2, 0 ) ); // Level 40
				Add( new GenericBuyInfo( typeof( CrescentBlade ), 1800, 500, 0x26C1, 0 ) ); // Level 45
				Add( new GenericBuyInfo( typeof( EbonyDualKatanas ), 2000, 500, 15828, 0 ) ); // Level 50
				Add( new GenericBuyInfo( typeof( EbonyMoonblade ), 2000, 500, 15822, 0 ) ); // Level 50
				Add( new GenericBuyInfo( typeof( Lance ), 2000, 500, 0x26C0, 0 ) ); // Level 50
				Add( new GenericBuyInfo( typeof( RadiantScimitar ), 2000, 500, 0x2D33, 0 ) ); // Level 50
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