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
	public class ElmhavenHealer : BaseHealer 
	{ 
		public override bool IsActiveVendor{ get{ return true; } }

		[Constructable]
		public ElmhavenHealer() 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			SBInfos.Add( new SBElmhavenHealer() ); 
		}

		public override void InitOutfit()
		{
			Name = "Pastor Fargo the healer";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33799;
                        HairItemID = 8251;
                        HairHue = 1112;
                        FacialHairItemID = 8255;
                        FacialHairHue = 1112;

			SetStr( 127 );
			SetDex( 105 );
			SetInt( 163 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Forensics, 80.0, 100.0 );
			SetSkill( SkillName.SpiritSpeak, 80.0, 100.0 );
			SetSkill( SkillName.Swords, 80.0, 100.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 46, 61 );

			AddItem( new FancyShirt(906) );
			AddItem( new FancyPants(902) );
			AddItem( new Shoes(924) );
            }

		public ElmhavenHealer( Serial serial ) : base( serial ) 
		{ 
		} 

		public override bool CheckResurrect( Mobile m )
		{
			if ( m.Criminal )
			{
				Say( 501222 ); // Thou art a criminal.  I shall not resurrect thee.
				return false;
			}
			else if ( m.Kills >= 5 )
			{
				Say( 501223 ); // Thou'rt not a decent and good person. I shall not resurrect thee.
				return false;
			}
			else if ( m.Karma < 0 )
			{
				Say( 501224 ); // Thou hast strayed from the path of virtue, but thou still deservest a second chance.
			}

			return true;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenHealerEntry( from, this ) );
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

		public class ElmhavenHealerEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenHealerEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElmhavenHealerGump ) ) )
					{
						mobile.SendGump( new ElmhavenHealerGump( mobile ));
						
					}
				}
			}
		}
}
