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
	public class HappySalesman : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public HappySalesman() : base( "the happy sales dolphin" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBHappySalesman() ); 
		}

		public override void InitOutfit()
		{
			Name = "Flippy";
			Body = 0x97;
			BaseSoundID = 0x8A;

			SetStr( 181, 204 );
			SetDex( 195, 213 );
			SetInt( 100, 119 );

			SetHits( 25000, 50000 );
			SetMana( 500, 595 );

			SetDamage( 50, 75 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 70 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 70 );
			SetResistance( ResistanceType.Poison, 70 );
			SetResistance( ResistanceType.Energy, 70 );

			SetSkill( SkillName.EvalInt, 80.4, 93.6 );
			SetSkill( SkillName.Magery, 87.3, 97.6 );
			SetSkill( SkillName.MagicResist, 84.6, 86.0 );
			SetSkill( SkillName.Tactics, 74.5, 78.3 );
			SetSkill( SkillName.Wrestling, 39.5, 55.9 );

			Fame = 4000;
			Karma = -4000;

			CanSwim = true;
			CantWalk = false;
                }

		public HappySalesman( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void OnDoubleClick( Mobile from )
		{
			if( from.AccessLevel >= AccessLevel.GameMaster )
				Jump();
		}

		public virtual void Jump()
		{
			if( Utility.RandomBool() )
				Animate( 3, 16, 1, true, false, 0 );
			else
				Animate( 4, 20, 1, true, false, 0 );
		}

		public override void OnThink()
		{
			if( Utility.RandomDouble() < .005 ) // slim chance to jump
				Jump();

			base.OnThink();
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

	public class SBHappySalesman : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHappySalesman()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Fat Man Agility Potion", typeof( FatManAgilityPotion ), 15000, 999, 0xF08, 0 ) );
				Add( new GenericBuyInfo( "Fat Man Explosion Potion", typeof( FatManExplosionPotion ), 20000, 999, 0xF0D, 0 ) );
				Add( new GenericBuyInfo( "Fat Man Heal Potion", typeof( FatManHealPotion ), 20000, 999, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( "Fat Man Strength Potion", typeof( FatManStrengthPotion ), 20000, 999, 0xF09, 0 ) );

				Add( new GenericBuyInfo( "Fat Man Mind Potion", typeof( FatManMindPotion ), 20000, 999, 0xF04, 1173 ) );
				Add( new GenericBuyInfo( "Fat Man Mana Potion", typeof( FatManManaPotion ), 30000, 999, 0xF03, 1266 ) );

				Add( new GenericBuyInfo( "Skill Buff Elixir", typeof( BaseElixir ), 50000, 500, 0xE2A, 0x290 ) );

				Add( new GenericBuyInfo( "GM Buff Statue", typeof( GMBuffStatue ), 65666, 5, 0x3FFE, 0 ) );

				Add( new GenericBuyInfo( "Steel Jaw", typeof( SteelJaw ), 65666, 5, 0xF50, 0 ) );

				Add( new GenericBuyInfo( "Super Rod", typeof( SuperRod ), 10000, 500, 15906, 0 ) );
				Add( new GenericBuyInfo( "Fire Rod", typeof( FireRod ), 10000, 500, 15907, 1360 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Gold ), 1 );					
			}
		}
	}
}
