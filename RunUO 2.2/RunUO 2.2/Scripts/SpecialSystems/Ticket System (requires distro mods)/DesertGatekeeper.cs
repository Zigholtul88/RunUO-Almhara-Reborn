using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles 
{ 
	public class DesertGatekeeper : BaseGuardian
	{ 
		public override bool InitialInnocent{ get{ return true; } }
		public override bool ClickTitle{ get{ return false; } }

		private Mobile m_ListeningTo;
		private string m_LastSaid;
		private string m_LastHeard;

		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 25.0 ); //the delay between talks is 25 seconds
		public DateTime m_NextTalk;

		[Constructable]
		public DesertGatekeeper() : base( AIType.AI_Animal, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{
			Name = "Brucilla";
			Title = "the Desert Gatekeeper";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 0x83EA;
			HairItemID = 0x203B;
			HairHue = 0x1BB;

			SetStr( 1005, 1183 );
			SetDex( 187, 238 );
			SetInt( 151, 247 );

			SetHits( 1184, 1422 );
			SetMana( 1105, 1205 );

			SetDamage( 5, 10 );

			FemaleStuddedChest chest = new FemaleStuddedChest();
			chest.Hue = 313;
			chest.Movable = true;
			AddItem( chest );

			StuddedGorget gorget = new StuddedGorget();
			gorget.Hue = 23;
			gorget.Movable = true;
			AddItem( gorget );

			StuddedArms arms = new StuddedArms();
			arms.Hue = 23;
			arms.Movable = true;
			AddItem( arms );

			StuddedGloves gloves = new StuddedGloves();
			gloves.Hue = 313;
			gloves.Movable = true;
			AddItem( gloves );

			SteelJaw weapon = new SteelJaw();
		        BaseRunicTool.ApplyAttributesTo( weapon, 5, 25, 35 );
			weapon.WeaponAttributes.HitLightning = 25;
                        weapon.Hue = 23;
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );

			AddItem( new HighBoots(23) );
			AddItem( new PlumeCloak(313) );

			PackItem( new Bolt( Utility.RandomMinMax( 50, 80 ) ) ); 
                }

		public override void OnSpeech( SpeechEventArgs e )
		{
			if ( !e.Handled )
			{
				Mobile from = e.Mobile;
				if ( this.ControlMaster == from )
				{
					String command = e.Speech;
					if ( command == "What did you just say?" && m_LastSaid != null )
						this.Say( m_LastSaid );
					else if ( command == "Repeat what you just heard." && m_LastHeard != null )
					if ( command == "Who are you listening to?" && this.m_ListeningTo != null )
						this.Say( "{0}", this.m_ListeningTo.Name );
				}
				if ( from is PlayerMobile )
				{
					String text = e.Speech;
					if ( this.m_ListeningTo == null )
					{
						this.m_ListeningTo = from;
						this.BeginLineRecognition( text, from );
					}
					else if ( this.m_ListeningTo == from )
						this.BeginLineRecognition( text, from );
				}
			}
		}

		public override void OnThink()
		{
			if ( this.m_ListeningTo != null && !this.m_ListeningTo.InRange( this.Location, 6 ))
				this.m_ListeningTo = null;
		}

		public void BeginLineRecognition( String text, Mobile from )
		{
			string response = this.GetResponseFor( text, from );
			this.m_LastSaid = response;
			this.m_LastHeard = text;
			this.Say( response );
		}

		public string GetResponseFor( String text, Mobile from )
		{
			if ( text == "hi" || text == "hello" || text == "hey" || text == "g'day" || text == "good day" || text == "hi there" )
				return "The Harashi Nabi is off limits to those lacking in good judgement. [who are you], [objectives], [bye].";

//////////////////////////////////////////////////////////// Who Are You
			else if ( text == "Who are you" || text == "who are you" )
				return "Brucilla's the name and I'm here to keep out any undesirables. Or at the very least those who I deem worthy enough to convience me otherwise.";

//////////////////////////////////////////////////////////// Objectives
			else if ( text == "Objectives" || text == "objectives" )
				return "Your objectives are pretty simple. Complete 15 tasks found in [Zaythalor] along with 9 tasks in [Alytharr] and you will have proven yourself good in my eyes to allow access.";
			     else if ( text == "Zaythalor" || text == "zaythalor" )
				     return "Its where you've just come from. You can find your objectives in a tavern posted on a blue bulletin board. Select one and it'll teleport you to that [quest] destination.";
			     else if ( text == "Alytharr" || text == "alytharr" )
				     return "Its an area for slightly more experienced adventurers. You can find your objectives in a tavern posted on a blue bulletin board. Select one and it'll teleport you to that [quest] destination.";
			          else if ( text == "Quest" || text == "quest" )
				          return "Quests range from your typical seek and destroys to collectathons to even running for your life.";

//////////////////////////////////////////////////////////// Bye
			else if ( text == "Bye" || text == "bye" || text == "goodbye" || text == "see ya" || text == "peace" || text == "peace out" )
				return "Remember. 9 tasks from the bulletin board. You have no idea how many dumbasses I've come across that couldn't put 2 and 2 together.";
			else
				return text;
		}

		public DesertGatekeeper( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new DesertGatekeeperEntry( from, this ) );
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 5 ) && InLOS( m ) && m is PlayerMobile && !m.Hidden ) // check if it's time to talk & mobile in range & in los.
			{
		                PlayerMobile player = m as PlayerMobile;

			        if ( m is PlayerMobile && player.AreaAccessDesertRegion == false && player.HasMetGateKeeper == false )
                                {
				        m.CloseGump( typeof( HasMetGateKeeperGump ) );
				        m.SendGump( new HasMetGateKeeperGump( m ) );

                                        m.AddToBackpack( new ZaythalorTicketConnectionBox() );
				        player.HasMetGateKeeper = true;
                                }

			        else if ( m is PlayerMobile && player.AreaAccessDesertRegion == false && player.HasMetGateKeeper == true )
                                {
        	                        m.SendMessage("Help the citizens of Zaythalor along with Alytharr and I will allow you passage into the desert.");
                                }

				GateKeepersPermissionSlip gatekeeperspermissionslip = player.Backpack.FindItemByType( typeof ( GateKeepersPermissionSlip ) ) as GateKeepersPermissionSlip;

				if ( gatekeeperspermissionslip != null )
				{
                                        // ah!
			                PlaySound( 1049 );
				        m.SendMessage( "Hand the slip over and I'll allow you access." );
                                }
				else if ( gatekeeperspermissionslip == null )
				{
				        ZaythalorTicketConnectionBox zaythalorticketconnectionbox = player.Backpack.FindItemByType( typeof ( ZaythalorTicketConnectionBox ) ) as ZaythalorTicketConnectionBox;

				        if ( zaythalorticketconnectionbox != null )
				        {
				                m.SendMessage( "Come back whenever you finish those objectives." );
                                        }
                                }

				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 6 ) )
				{
					case 0: Say("*blows nose*");
						PlaySound(1052);
						break;
					case 1: Say("*burp!*");
						PlaySound(1053);
						break;	
					case 2: Say("*clears throat*");
						PlaySound(1055);
						break;
					case 3: Say("*cough!*");
						PlaySound(1056);
						break;
					case 4: Say("*groans*");
						PlaySound(1067);
						break;
					case 5: Say("*ahh-choo!*"); 
						PlaySound(1091);
						break;
				};
			}
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

		public class DesertGatekeeperEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public DesertGatekeeperEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( HasMetGateKeeperGump ) ) )
					{
						mobile.SendGump( new HasMetGateKeeperGump( mobile ));
						
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
				if( dropped is GateKeepersPermissionSlip )
				{
				        if(dropped.Amount!=1)
         			        {
                                        }
					dropped.Delete();
			                mobile.SendMessage( "You have my full permission to progress onward. Take heed and be on your guard. Or the sand krakens might sneak up on you. I shall go back to my duties and pretend that this conversation has never happened." );
				        mobile.AreaAccessDesertRegion = true;

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

                public class HasMetGateKeeperGump : Gump 
                { 

                public static void Initialize() 
                { 
                     CommandSystem.Register( "HasMetGateKeeperGump", AccessLevel.GameMaster, new CommandEventHandler( HasMetGateKeeperGump_OnCommand ) ); 
                } 

                private static void HasMetGateKeeperGump_OnCommand( CommandEventArgs e ) 
                { 
                     e.Mobile.SendGump( new HasMetGateKeeperGump( e.Mobile ) ); 
                } 

                public HasMetGateKeeperGump( Mobile owner ) : base( 50,50 ) 
                { 
//----------------------------------------------------------------------------------------------------
			this.AddPage(0);
			this.AddBackground(126, 131, 398, 389, 9270);
			this.AddAlphaRegion(130, 132, 391, 389);
			this.AddImage(110, 460, 10464);
			this.AddImage(536, 214, 9265);
			this.AddImage(507, 460, 10464);
			this.AddImage(507, 408, 10464);
			this.AddImage(110, 193, 10464);
			this.AddImage(110, 247, 10464);
			this.AddImage(110, 301, 10464);
			this.AddImage(110, 354, 10464);
			this.AddImage(110, 408, 10464);
			this.AddImage(110, 139, 10464);
			this.AddImage(93, 197, 9263);
			this.AddImage(59, 124, 10421);
			this.AddImage(88, 110, 10420);
			this.AddImage(107, 246, 10411);
			this.AddImage(43, 399, 10402);
			this.AddImage(93, 513, 10103);
			this.AddImage(109, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(218, 513, 10100);
			this.AddImage(202, 513, 10100);
			this.AddImage(124, 513, 10100);
			this.AddImage(172, 513, 10100);
			this.AddImage(156, 513, 10100);
			this.AddImage(140, 513, 10100);
			this.AddImage(188, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(249, 513, 10100);
			this.AddImage(264, 513, 10100);
			this.AddImage(218, 513, 10100);
			this.AddImage(308, 513, 10100);
			this.AddImage(172, 513, 10100);
			this.AddImage(292, 513, 10100);
			this.AddImage(188, 513, 10100);
			this.AddImage(277, 513, 10100);
			this.AddImage(339, 513, 10100);
			this.AddImage(324, 513, 10100);
			this.AddImage(415, 513, 10100);
			this.AddImage(399, 513, 10100);
			this.AddImage(354, 513, 10100);
			this.AddImage(368, 123, 10100);
			this.AddImage(385, 513, 10100);
			this.AddImage(445, 513, 10100);
			this.AddImage(430, 513, 10100);
			this.AddImage(521, 513, 10100);
			this.AddImage(505, 513, 10100);
			this.AddImage(460, 513, 10100);
			this.AddImage(476, 513, 10100);
			this.AddImage(491, 513, 10100);
			this.AddImage(156, 123, 10100);
			this.AddImage(140, 123, 10100);
			this.AddImage(232, 123, 10100);
			this.AddImage(216, 123, 10100);
			this.AddImage(171, 123, 10100);
			this.AddImage(187, 123, 10100);
			this.AddImage(202, 123, 10100);
			this.AddImage(339, 513, 10100);
			this.AddImage(324, 513, 10100);
			this.AddImage(415, 513, 10100);
			this.AddImage(399, 513, 10100);
			this.AddImage(353, 123, 10100);
			this.AddImage(369, 513, 10100);
			this.AddImage(385, 513, 10100);
			this.AddImage(263, 123, 10100);
			this.AddImage(248, 123, 10100);
			this.AddImage(339, 123, 10100);
			this.AddImage(323, 123, 10100);
			this.AddImage(278, 123, 10100);
			this.AddImage(294, 123, 10100);
			this.AddImage(309, 123, 10100);
			this.AddImage(398, 123, 10100);
			this.AddImage(383, 123, 10100);
			this.AddImage(474, 123, 10100);
			this.AddImage(458, 123, 10100);
			this.AddImage(413, 123, 10100);
			this.AddImage(429, 123, 10100);
			this.AddImage(444, 123, 10100);
			this.AddImage(505, 123, 10100);
			this.AddImage(489, 123, 10100);
			this.AddImage(521, 123, 10100);
			this.AddImage(507, 193, 10464);
			this.AddImage(507, 139, 10464);
			this.AddImage(507, 354, 10464);
			this.AddImage(507, 299, 10464);
			this.AddImage(507, 247, 10464);
			this.AddImage(523, 254, 10411);
			this.AddImage(532, 130, 10431);
			this.AddImage(500, 112, 10430);
			this.AddImage(535, 513, 10105);
			this.AddImage(520, 417, 10412);
			this.AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 );
			this.AddHtml( 157, 181, 345, 279, "Hey buddy. You're gonna have to prove your worth if you want access through my desert. Take this box, complete some quest objectives for the Zaythalor folk and I'll let you through.<BR><BR><I><BASEFONT COLOR=#0099FF>Who Are You<BR><BR>Objectives<BR><BR>Bye</BASEFONT COLOR></I>", false, true);

//----------------------------------------------------------------------------------------------------
		}

                public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 

                { 
                    Mobile from = state.Mobile; 

                    switch ( info.ButtonID ) 
                { 

                case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
                { 
                    //Cancel 
                    break; 
                } 
            }
        }
    }
}