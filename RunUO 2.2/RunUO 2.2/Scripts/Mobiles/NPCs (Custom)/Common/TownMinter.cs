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
	public class TownMinter : BaseGuardian
	{
		[Constructable]
		public TownMinter() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Title = "the minter"; 
			Hue = Utility.RandomSkinHue();

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 0x191;
				Name = NameList.RandomName( "female" );
				AddItem( new Skirt( Utility.RandomNeutralHue() ) );
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName( "male" );
				AddItem( new ShortPants( Utility.RandomNeutralHue() ) );
			}

			Utility.AssignRandomHair( this );

			AddItem( new Boots( Utility.RandomNeutralHue() ) );
			AddItem( new FancyShirt( Utility.RandomNeutralHue() ) );

			SetStr( 150, 350 );
			SetDex( 50, 75 );
			SetInt( 9, 15 );

			SetHits( 150, 200 );

			SetDamage( 9, 15 );

			SetSkill( SkillName.Anatomy, 59.5, 68.7 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 61.0, 93.0 );

			Karma = 5000;

			PackGold( 50, 100 );
		}

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

		public TownMinter( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new TownMinterEntry( from, this ) );
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
		
		public class TownMinterEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public TownMinterEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( TownMinterGump ) ) )
					{
						mobile.SendGump( new TownMinterGump( mobile ));
						
					}
				}
			}
		}
		
		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;
			
			if( mobile != null )
			{
				if( dropped is OneGoldBar )
				{
					dropped.Delete();
		                  mobile.AddToBackpack( new Gold( 300 ) );
				      PlaySound( 741 );
					return true;
				}			
				else if( dropped is ThreeGoldBars )
				{
					dropped.Delete();
		                  mobile.AddToBackpack( new Gold( 500 ) );
				      PlaySound( 741 );
					return true;
				}
				else if( dropped is FiveGoldBars )
				{
					dropped.Delete();
		                  mobile.AddToBackpack( new Gold( 1000 ) );
				      PlaySound( 741 );
					return true;
				}

					else
					{
						mobile.SendMessage("I have no need for this item.");
					}
				}
		return false;
		}
	}
}
