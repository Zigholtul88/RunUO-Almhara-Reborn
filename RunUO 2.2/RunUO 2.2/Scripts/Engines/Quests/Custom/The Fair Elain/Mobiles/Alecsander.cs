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
using Server.Engines.Quests;

namespace Server.Engines.Quests.TheFairElain
{
	[CorpseName( "Alecsander's corpse" )]
	public class Alecsander : BaseQuester
	{
                [Constructable]
		public Alecsander()
		{
                }

		public override void InitOutfit()
		{
			Name = "Alecsander";
                        Title = "(The Fair Elain)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 0x83F8;
			HairItemID = 8251;  
                        HairHue = 1741;	
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			AddItem( new Server.Items.Boots() );
			AddItem( new Server.Items.FancyShirt( 21 ) );
			AddItem( new Server.Items.LongPants( 20 ) );
			AddItem( new Server.Items.Cloak( 518 ) );
			AddItem( new Server.Items.FeatheredHat( 1 ) );
		}

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			Direction = GetDirectionTo( player );

			QuestSystem qs = player.Quest;

			if ( qs is TheFairElainQuest )
			{
				QuestObjective obj = qs.FindObjective( typeof( SeekVacarJamesObjective ) );

				if ( qs.IsObjectiveInProgress( typeof( SeekVacarJamesObjective ) ) )
				{
					qs.AddConversation( new DuringSeekVacarJamesConversation() );
				}
			}
			else
			{
				QuestSystem newQuest = new TheFairElainQuest( player );
				bool inRestartPeriod = false;

				if ( qs != null )
				{
					player.SendMessage("Yo mate. Mind consider finishing that quest from earlier.");
				}
				else if ( QuestSystem.CanOfferQuest( player, typeof( TheFairElainQuest ), out inRestartPeriod ) )
				{
					newQuest.SendOffer();
				}
				else if ( inRestartPeriod )
				{
					player.SendMessage("I'm currently tending to matters this very moment. Come back in three hours and maybe you might be of some use.");
				}
			}
		}

		public Alecsander( Serial serial ) : base( serial )
		{
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

                public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
         	        Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;

			if ( mobile != null )
			{
				QuestSystem qs = mobile.Quest;

				if ( qs is TheFairElainQuest )
				{
					QuestObjective obj = qs.FindObjective( typeof( BringBookToVacarObjective ) );

				        if ( qs.IsObjectiveInProgress( typeof( BringBookToVacarObjective ) ) )
				        {
				                if( dropped is VacarsLoveLetter )
         		                        {
         			                        if( dropped.Amount!=1 )
         			                        {
					                        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "There's not the right amount here!", mobile.NetState );
         				                        return false;
         			                        }

					                dropped.Delete();

					                mobile.AddToBackpack( new SkillSlotDeedQuestReward() );
					                mobile.AddToBackpack( new WeightIncreaseDeed() );
					                mobile.AddToBackpack( new Gold( Utility.RandomMinMax( 523, 1019 ) ) );
					                mobile.AddToBackpack( new QuestGoodieBag() );

					                switch ( Utility.Random( 4 ) )
					                {
						                case 0: mobile.AddToBackpack( new BrownLeatherTunicOfEarthProtection() ); break;
						                case 1: mobile.AddToBackpack( new GreenLeatherTunicOfPoisonProtection() ); break;
						                case 2: mobile.AddToBackpack( new RedLeatherTunicOfFireProtection() ); break;
						                case 3: mobile.AddToBackpack( new WindLeatherTunicOfProtection() ); break;
					                } 
	
					                qs.AddConversation( new AlecsanderEndConversation() );					
				
					                return true; 
                                                }
                                        }
				        else if ( dropped is VacarsLoveLetter )
				        {
				                this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
         			                return false;
                                        }
				}
         		        else
         		        {
				        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Nooo! I need that love letter!", mobile.NetState );
                                }
			}

			return false;
		}
	}
}