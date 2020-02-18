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

namespace Server.Engines.Quests.FamilyJewels
{
	[CorpseName( "Arriana's corpse" )]
	public class Arriana : BaseQuester
	{
                [Constructable]
		public Arriana()
		{
                }

		public override void InitOutfit()
		{
			Name = "Arriana Loveliss";
                        Title = "(Family Jewels)";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 0x83F8;
			HairItemID = 0x203D;  
                        HairHue = 2213;	
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			FancyDress fd = new FancyDress();
                        fd.Hue = 1172;
                        AddItem( fd );

                        Sandals s = new Sandals();
                        s.Hue = 1172;
                        AddItem( s );
		}

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			Direction = GetDirectionTo( player );

			QuestSystem qs = player.Quest;

			if ( qs is FamilyJewelsQuest )
			{
				QuestObjective obj = qs.FindObjective( typeof( SeekUncleJohnObjective ) );

				if ( qs.IsObjectiveInProgress( typeof( SeekUncleJohnObjective ) ) )
				{
					qs.AddConversation( new DuringSeekUncleJohnConversation() );
				}
			}
			else
			{
				QuestSystem newQuest = new FamilyJewelsQuest( player );
				bool inRestartPeriod = false;

				if ( qs != null )
				{
					player.SendMessage("Excuse me citizen. Mind consider finishing that quest from earlier.");
				}
				else if ( QuestSystem.CanOfferQuest( player, typeof( FamilyJewelsQuest ), out inRestartPeriod ) )
				{
					newQuest.SendOffer();
				}
				else if ( inRestartPeriod )
				{
					player.SendMessage("Thank you for your help!");
				}
			}
		}

		public Arriana( Serial serial ) : base( serial )
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

				if ( qs is FamilyJewelsQuest )
				{
					QuestObjective obj = qs.FindObjective( typeof( ReturnToArrianaObjective ) );

				        if ( qs.IsObjectiveInProgress( typeof( ReturnToArrianaObjective ) ) )
				        {
				                if( dropped is DiamondHoopEarrings )
         		                        {
         			                        if( dropped.Amount!=1 )
         			                        {
					                        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "There's not the right amount here!", mobile.NetState );
         				                        return false;
         			                        }

					                dropped.Delete();

					                mobile.AddToBackpack( new ArrianasEarrings() );
					                mobile.AddToBackpack( new SkillSlotDeedQuestReward() );
					                mobile.AddToBackpack( new WeightIncreaseDeed() );
					                mobile.AddToBackpack( new Gold( Utility.RandomMinMax( 523, 1019 ) ) );
					                mobile.AddToBackpack( new QuestGoodieBag() );
	
					                qs.AddConversation( new EndConversation() );					
				
					                return true; 
                                                }
                                        }
				        else if ( dropped is DiamondHoopEarrings )
				        {
				                this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
         			                return false;
                                        }
				}
         		        else
         		        {
				        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Why on earth would I want to have that?", mobile.NetState );
                                }
			}

			return false;
		}
	}
}