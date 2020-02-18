using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.ContextMenus;
using Server.Items;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles 
{ 
	public class OrdenTheGrachioHerder : BaseCreature 
	{ 
		private Mobile m_ListeningTo;
		private string m_LastSaid;
		private string m_LastHeard;

		public override bool InitialInnocent{ get{ return true; } }

		[Constructable] 
		public OrdenTheGrachioHerder () : base( AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4 ) 
		{ 
			m_ListeningTo = null;
			m_LastSaid = null;
			m_LastHeard = null;

			Name = "Orden";
			Title = "the Grachiosaur-Herder"; 
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33824;
                        HairItemID = 8264;
                        HairHue = 1125;
                        FacialHairItemID = 8254;
                        FacialHairHue = 1133;

			SetStr( 386 );
			SetDex( 88 );
			SetInt( 49 );

			SetDamage( 4, 12 );

			SetSkill( SkillName.Anatomy, 71.2, 81.4 );
			SetSkill( SkillName.MagicResist, 25.9, 29.8 );
			SetSkill( SkillName.Wrestling, 76.5, 98.1 );
			SetSkill( SkillName.Tactics, 69.8, 82.6 );

			AddItem( new JinBaori(883) );
			AddItem( new LeatherShirt(763) );
			AddItem( new LeatherPants(763) );
			AddItem( new FurBoots(798) );

			SpeechHue = 763;

			Container pack = new Backpack(); 
			pack.DropItem( new Gold( 45, 75 ) );
			pack.DropItem( Loot.RandomClothing() );
			pack.DropItem( Loot.RandomClothing() );

 		        if ( Utility.RandomDouble() < 0.8 )
                        {
			        Pitchfork weapon = new Pitchfork();
		                BaseRunicTool.ApplyAttributesTo( weapon, 5, 10, 15 );
			        weapon.WeaponAttributes.HitLightning = 5;
                                weapon.Hue = 2405;
			        weapon.Movable = true;

                                pack.DropItem( weapon );
                        }

			Container bag = new Bag();
			bag.DropItem( new Bandage( Utility.RandomMinMax( 9, 18 ) ) );

                        Item ScrollLoot1 = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                        ScrollLoot1.Amount = Utility.Random( 2, 5 );
                        bag.DropItem( ScrollLoot1 );

                        Item ScrollLoot2 = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                        ScrollLoot2.Amount = Utility.Random( 2, 5 );
                        bag.DropItem( ScrollLoot2 );

			bag.DropItem( Loot.RandomWand() );
			bag.DropItem( Loot.RandomPotion() );
			bag.DropItem( Loot.RandomGem() );

			pack.DropItem( bag );

			AddItem( pack ); 
		} 

		public override bool ClickTitle{ get{ return false; } }

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
				return "Woah there! You aren't thinking about diving neck deep into the swamps now, are you? [who are you], [swamps], [grachiosaur].";

//////////////////////////////////////////////////////////// who are you
			else if ( text == "Who are you" || text == "who are you" )
				return "I'm Orden. I run this small farm. The water is fresh and the carrots are ripe for pickin.";

//////////////////////////////////////////////////////////// swamps
			else if ( text == "swamps" || text == "Swamps" )
				return "Between you and I, I wouldn't go past the bridge as it leads directly into [Samson Swamplands], home to [Miasma] and her gang of [bog creepers].";
			     else if ( text == "Samson Swamplands" || text == "samson swamplands" )
				     return "Its a spooky place full of strange oddities. Though interestly enough, it was where I found one of my dearest friends. Figure that one out.";
			     else if ( text == "Miasma" || text == "miasma" )
				     return "Leader of the bog creepers and one not to be easily trifled. However I heard that it is possible to get onto her good side should you find yourself wanting to join their [faction].";
			          else if ( text == "faction" || text == "Faction" )
				          return "A faction known as the Swampland Servants. By joining it'll make traversing the region less tedious and far less dangerous.";
			     else if ( text == "bog creepers" || text == "bog creeper" || text == "Bog Creepers" || text == "Bog Creeper" )
				     return "Oh, these guys are a real pain. If you're foolish enough to go through without presenting a [green candle] then you'll be swarmed in seconds. Lethal poisoned and literally nowhere to escape since they're extremely fast and will easily outrun you on foot.";
			          else if ( text == "green candle" || text == "Green Candle" )
				          return "I hear you're able to craft them, though I was never good with candlemaking to be perfect honest. However if you can get a hold of one, you might at least be able to glance a peak upon the entrance to its [dungeon].";

			          else if ( text == "dungeon" || text == "dungeons" )
				          return "To gain access to [Murkmere Dwelling] would require a trinket normally found on [wild harts] found throughout the alytharr region.";
			               else if ( text == "wild hart" || text == "wild harts" )
				               return "Don't underestimate them. Unlike regular hinds, these tend to put up one heck of a fight backed up through magical means.";

			          else if ( text == "murkmere dwelling" || text == "Murkmere Dwelling" )
				          return "Murkmere Dwelling is filled to brim with all sorts of dangerous [plant life].";
			               else if ( text == "plant life" || text == "Plant Life" )
				               return "Yeah. That place despite the calm alure is host to critters such as [boglings], [bog things], and stuff you don't really want to mess with.";
			               else if ( text == "bogling" || text == "boglings" )
				               return "I heard that they're extremely weak to fire based attacks. Makes sense for being a plant I guess.";
			               else if ( text == "bog thing" || text == "bog things" )
				          return "They hit like a mine cart and when under severe duress with attempt to consume any nearby boglings in order to regenerate its health.";

//////////////////////////////////////////////////////////// grachiosaur
			else if ( text == "grachiosaur" || text == "Grachiosaur" )
				return "His name is [Onix] and he watches over the farm, making sure no criminals wander onto the property.";
			     else if ( text == "Onix" || text == "onix"  )
				     return "Well yeah, I thought it was a neat name. Even if I did kinda base it off of a supposed tunnel serpent of the same title.";

//////////////////////////////////////////////////////////// Bye
			else if ( text == "Bye" || text == "bye" || text == "goodbye" || text == "see ya" || text == "peace" || text == "peace out" )
				return "Remember. Don't go into the swamp without being prepared first.";
			else
				return text;
		}

		public OrdenTheGrachioHerder( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new OrdenTheGrachioHerderEntry( from, this ) );
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

		public class OrdenTheGrachioHerderEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public OrdenTheGrachioHerderEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( OrdenTheGrachioHerderGump ) ) )
					{
						mobile.SendGump( new OrdenTheGrachioHerderGump( mobile ));
						
					}
				}
			}
		}
        }

        public class OrdenTheGrachioHerderGump : Gump 
        { 
                public static void Initialize() 
                { 
                     CommandSystem.Register( "OrdenTheGrachioHerderGump", AccessLevel.GameMaster, new CommandEventHandler( OrdenTheGrachioHerderGump_OnCommand ) ); 
                } 

                private static void OrdenTheGrachioHerderGump_OnCommand( CommandEventArgs e ) 
                { 
                     e.Mobile.SendGump( new OrdenTheGrachioHerderGump( e.Mobile ) ); 
                } 

                public OrdenTheGrachioHerderGump( Mobile owner ) : base( 50,50 ) 
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
			this.AddHtml( 157, 181, 345, 279, "Woah there! You aren't thinking about diving neck deep into the swamps now, are you?<BR><BR><I><BASEFONT COLOR=#0099FF>Who Are You<BR><BR>Swamps<BR><BR>Grachiosaur</BASEFONT COLOR></I>", false, true);

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