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
	public class HammerhillTeleporter : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public HammerhillTeleporter() : base( "the teleporter" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBHammerhillTeleporter() ); 
		}

		public override void InitOutfit()
		{
			Name = NameList.RandomName( "gargoyle vendor" );
			Body = 788;

			SetStr( 1001, 1200 );
			SetDex( 176, 195 );
			SetInt( 301, 400 );

			SetDamage( 10, 15 );

			SetDamageType( ResistanceType.Physical, 85 );
			SetDamageType( ResistanceType.Energy, 15 );

			SetResistance( ResistanceType.Physical, 60, 80 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 40, 60 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Anatomy, 25.1, 50 );
			SetSkill( SkillName.EvalInt, 90.1, 100 );
			SetSkill( SkillName.Magery, 95.5, 100 );
			SetSkill( SkillName.MagicResist, 100.5, 150 );
			SetSkill( SkillName.Meditation, 95.1, 120 );
			SetSkill( SkillName.Tactics, 90.1, 100 );
			SetSkill( SkillName.Wrestling, 90.1, 100 );

			PackGold( 23, 71 );
                }

		public HammerhillTeleporter( Serial serial ) : base( serial ) 
		{ 
		} 

		public override int GetAngerSound() { return 0x518; }
		public override int GetAttackSound() { return 0x516; }
		public override int GetDeathSound() { return 0x515; }
		public override int GetHurtSound() { return 0x519; }
		public override int GetIdleSound() { return 0x517; }

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new HammerhillTeleporterEntry( from, this ) );
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

		public class HammerhillTeleporterEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public HammerhillTeleporterEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( AreaTeleporterGump ) ) )
					{
						mobile.SendGump( new AreaTeleporterGump( mobile ));
						
					}
				}
			}
		}
        }

	public class SBHammerhillTeleporter : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHammerhillTeleporter()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Rune to Skaddria Naddheim", typeof( RuneToSkaddriaNaddheim ), 100, 500, 0x1F14, 0 ) );
				Add( new GenericBuyInfo( "Rune to Elmhaven", typeof( RuneToElmhaven ), 100, 500, 0x1F14, 0 ) );
				Add( new GenericBuyInfo( "Rune to Old Plunderer's Haven", typeof( RuneToOldPlunderersHaven ), 100, 500, 0x1F14, 0 ) );
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
