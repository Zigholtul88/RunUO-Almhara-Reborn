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
	public class CovensLandingWeaponsmith : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public CovensLandingWeaponsmith() : base( "the weaponsmith" )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBCovensLandingWeaponsmith() );
		}

		public override void InitOutfit()
		{
			Name = "Genji Susano";
                 	Body = 605;
                        Female = false;
                        Race = Race.Elf;
                        Hue = 33820;
                        HairItemID = 12237;
                        HairHue = 1109;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			SetStr( 267 );
			SetDex( 229 );
			SetInt( 168 );

			SetSkill( SkillName.ArmsLore, 64.0, 100.0 );
			SetSkill( SkillName.Blacksmith, 65.0, 88.0 );
			SetSkill( SkillName.Fencing, 45.0, 68.0 );
			SetSkill( SkillName.Macing, 45.0, 68.0 );
			SetSkill( SkillName.Swords, 45.0, 68.0 );
			SetSkill( SkillName.Tactics, 36.0, 68.0 );

			PackGold( 8, 16 );

			LightPlateJingasa helm = new LightPlateJingasa();
			helm.Movable = true;
                        helm.Hue = 873;
			AddItem( helm );

			LeatherDo chest = new LeatherDo();
			chest.Movable = true;
                        chest.Hue = 2425;
			AddItem( chest );

			LeatherHaidate legs = new LeatherHaidate();
			legs.Movable = true;
                        legs.Hue = 2425;
			AddItem( legs );

			AddItem( new ThighBoots(873) );

			Tetsubo weapon = new Tetsubo();
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );
                }

		public CovensLandingWeaponsmith( Serial serial ) : base( serial )
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

	public class SBCovensLandingWeaponsmith : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBCovensLandingWeaponsmith()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
////////////////////////////////////////////////////// Weapons
				Add( new GenericBuyInfo( typeof( Daisho ), 200, 20, 0x27A9, 0 ) );
				Add( new GenericBuyInfo( typeof( Kama ), 195, 20, 0x27AD, 0 ) );
				Add( new GenericBuyInfo( typeof( Lajatang ), 250, 20, 0x27A7, 0 ) );
				Add( new GenericBuyInfo( typeof( NoDachi ), 215, 20, 0x27A2, 0 ) );
				Add( new GenericBuyInfo( typeof( Sai ), 185, 20, 0x27AF, 0 ) );
				Add( new GenericBuyInfo( typeof( Shuriken ), 5, 20, 0x27AC, 0 ) );
				Add( new GenericBuyInfo( typeof( Tekagi ), 185, 20, 0x27AB, 0 ) );
				Add( new GenericBuyInfo( typeof( Tessen ), 230, 20, 0x27A3, 0 ) );
				Add( new GenericBuyInfo( typeof( Tetsubo ), 200, 20, 0x27A6, 0 ) );
				Add( new GenericBuyInfo( typeof( Wakizashi ), 165, 20, 0x27A4, 0 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
////////////////////////////////////////////////////// Weapons
// (Base Price = 100gp + Harvest component is 5 per cost equal to x amount + Secondary component is 1 per cost equal to x amount)  
				Add( typeof( Axe ), 185 );
				Add( typeof( BattleAxe ), 190 );
				Add( typeof( DoubleAxe ), 185 );
				Add( typeof( ExecutionersAxe ), 185 );
				Add( typeof( LargeBattleAxe ),180 );
				Add( typeof( Pickaxe ), 50 );
				Add( typeof( TwoHandedAxe ), 205 );
				Add( typeof( WarAxe ), 205 );

				Add( typeof( Dagger ), 125 );

				Add( typeof( Cutlass ), 165 );
				Add( typeof( Katana ), 165 );
				Add( typeof( Kryss ), 165 );
				Add( typeof( Longsword ), 185 );
				Add( typeof( Scimitar ), 175 );
				Add( typeof( VikingSword ), 195 );

				Add( typeof( Club ), 100 );
				Add( typeof( HammerPick ), 200 );
				Add( typeof( Mace ), 150 );
				Add( typeof( Maul ), 170 );
				Add( typeof( WarHammer ), 200 );
				Add( typeof( WarMace ), 190 );

				Add( typeof( Pitchfork ), 100 );
				Add( typeof( ShortSpear ), 155 );
				Add( typeof( Spear ), 185 );
				Add( typeof( WarFork ), 185 );

				Add( typeof( BlackStaff ), 200 );
				Add( typeof( CrystalStaff ), 225 );
				Add( typeof( GnarledStaff ), 135 );
				Add( typeof( QuarterStaff ), 130 );
				Add( typeof( PristineStaff ), 210 );
				Add( typeof( ShepherdsCrook ), 135 );
				Add( typeof( TribalStaff ), 215 );
				Add( typeof( WildStaff ), 135 );

				Add( typeof( Bardiche ), 215 );
				Add( typeof( Halberd ), 225 );

				Add( typeof( BladedStaff ), 185 );
				Add( typeof( BoneHarvester ), 175 );
				Add( typeof( CrescentBlade ), 195 );
				Add( typeof( DoubleBladedStaff ), 205 );
				Add( typeof( Lance ), 225 );
				Add( typeof( PaladinSword ), 100 );
				Add( typeof( Pike ), 225 );
				Add( typeof( Scepter ), 170 );
				Add( typeof( Scythe ), 205 );

				Add( typeof( Daisho ), 200 );
				Add( typeof( Kama ), 195 );
				Add( typeof( Lajatang ), 250 );
				Add( typeof( NoDachi ), 215 );
				Add( typeof( Sai ), 185 );
				Add( typeof( Shuriken ), 5 );
				Add( typeof( Tekagi ), 185 );
				Add( typeof( Tessen ), 230 );
				Add( typeof( Tetsubo ), 200 ); // Need to mod price to better reflect new system
				Add( typeof( Wakizashi ), 165 );

				Add( typeof( AssassinSpike ), 170 );
				Add( typeof( DiamondMace ), 615 );
				Add( typeof( ElvenMachete ), 195 );
				Add( typeof( ElvenSpellblade ), 195 );
				Add( typeof( Leafblade ), 185 );
				Add( typeof( OrnateAxe ), 215 );
				Add( typeof( RadiantScimitar ), 200 );
				Add( typeof( RuneBlade ), 200 );
				Add( typeof( WarCleaver ), 215 );

				Add( typeof( EbonyBattleAxe ), 200 );
				Add( typeof( EbonyBattleSpear ), 200 );
				Add( typeof( EbonyDagger ), 140 );
				Add( typeof( EbonyDualDaggers ), 180 );
				Add( typeof( EbonyDualKatanas ), 230 );
				Add( typeof( EbonyGlassAxe ), 190 );
				Add( typeof( EbonyGlassBardiche ), 225 );
				Add( typeof( EbonyMoonblade ), 195 );
				Add( typeof( EbonyMorningstar ), 230 );
				Add( typeof( EbonyPristineStaff ), 100 );
				Add( typeof( EbonyRapier ), 170 );
				Add( typeof( EbonyScimitar ), 200 );
				Add( typeof( EbonyWarMace ), 210 );
			} 
		} 
	} 
}