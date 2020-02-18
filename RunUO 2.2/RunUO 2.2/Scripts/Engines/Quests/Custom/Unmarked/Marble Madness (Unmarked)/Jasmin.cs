using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "Jasmin's Corpse" )]
	public class Jasmin : BaseCreature
	{
                public override bool IsInvulnerable{ get{ return true; } }
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public Jasmin() : base( AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4 ) 
		{
			InitStats( 100, 100, 25 );

			Name = "Jasmin";
                        Title = "the Lost little Girl";
			CantWalk = true;
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 0x83F8;
                        HairItemID = 8252;
                        HairHue = 1337;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			AddItem( new Necklace() );

			AddItem( new RaggedDress() );
			AddItem( new Sandals() );

			Blessed = true;	
		}

		public Jasmin( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new JasminEntry( from, this ) ); 
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

		public class JasminEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public JasminEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( MarbleMadnessGump ) ) )
					{
						mobile.SendGump( new MarbleMadnessGump( mobile ) );		
					} 
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
         	        Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;

			if ( mobile != null )
			{
				if( dropped is BigColourfulMarble )
         		        {
         			        if( dropped.Amount!=1 )
         			        {
					        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "No, that's not it...", mobile.NetState );
         				        return false;
         			        }

					dropped.Delete(); 
				        mobile.SendMessage( "Thank you for bringing back my marble. I hope you find this gold and special checkerboard useful." );
					mobile.AddToBackpack( new JasminCheckerBoard() );
					mobile.AddToBackpack( new Gold( 2000 ) );

					return true;
         		        }
				else if ( dropped is BigColourfulMarble )
				{
				        this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
         			        return false;
				}
         		        else
         		        {
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Oh no, I have no need of this, kind warrior!", mobile.NetState );
     			        }
			}

			return false;
		}
	}
}
