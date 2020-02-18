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
	public class SisterOfHealing : BaseHealer
	{
		public override bool IsActiveVendor{ get{ return true; } }

                public override bool IsInvulnerable{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public SisterOfHealing() 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			SBInfos.Add( new SBSisterOfHealing() ); 
		}

		public override void InitOutfit()
		{
			Name = "Giolia Uumena";
                        Title = "the Scarlet Sister of Healing";
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
                        Hue = 1002;
                        HairItemID = 12236;
                        HairHue = 1619;

			SetSkill( SkillName.Healing, 120.0 );

			Circlet helm = new Circlet(); 
			helm.Hue = 763; 
			helm.Movable = false; 
			AddItem( helm );

			CloakOfHumility cloak = new CloakOfHumility(); 
			cloak.Hue = 718; 
			cloak.Movable = false; 
			AddItem( cloak );

			AddItem( new ClothNinjaJacket(888) );
			AddItem( new BodySash(718) );
			AddItem( new Skirt(888) );
			AddItem( new ThighBoots(888) );

			WildStaff weapon = new WildStaff();
			weapon.Hue = 743; 
			weapon.Movable = false; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );
                }

		public SisterOfHealing( Serial serial ) : base( serial )
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
			list.Add( new SisterOfHealingEntry( from, this ) );
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

		public class SisterOfHealingEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public SisterOfHealingEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
}