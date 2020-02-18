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
using Server.Engines.Quests;

namespace Server.Engines.Quests.HaldursBait
{
	public class OldFisherman : BaseQuester
	{
                [Constructable]
		public OldFisherman()
		{
                }

		public override void InitOutfit()
		{
			Name = "Haldur the old fisherman";
                        Title = "(Haldur's Bait)";
			CantWalk = true;
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 0x83F8;
                        HairItemID = 8253;
                        HairHue = 1150;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			AddItem( new Server.Items.Boots( 1138 ) );
			AddItem( new Server.Items.Shirt( 969 ) );
			AddItem( new Server.Items.ShortPants( 1118 ) );
			AddItem( new Server.Items.FloppyHat( 1138 ) );
			
			FishingPole fp = new FishingPole();
			fp.Hue = 1150;
			fp.Name = "Ancient Fishing Pole";
                        AddItem( fp );
			
			Blessed = true;
		}

		public OldFisherman( Serial serial ) : base( serial )
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

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			Direction = GetDirectionTo( player );

			QuestSystem qs = player.Quest;

			if ( qs is HaldursBaitQuest )
			{
				if ( qs.IsObjectiveInProgress( typeof( GetBaitObjective ) ) )
				{
					qs.AddConversation( new DirectionConversation() );
                                }
			}
			else
			{
				HaldursBaitQuest newQuest = new HaldursBaitQuest( player );
				bool inRestartPeriod = false;

				if ( qs != null )
				{
					if ( contextMenu )
						player.SendMessage("I understand that you're eager but perhaps you might outta finish that there quest you started earlier!");
				}
				else if ( QuestSystem.CanOfferQuest( player, typeof( HaldursBaitQuest ), out inRestartPeriod ) )
				{
					newQuest.SendOffer();
				}
				else if ( inRestartPeriod && contextMenu )
				{
					player.SendMessage("Darling I'd like to help out but I am currently tending to business. Try coming back in three hours.");
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
         	        Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;

			if ( mobile != null )
			{
				QuestSystem qs = mobile.Quest;

				if ( qs is HaldursBaitQuest )
				{
					QuestObjective obj = qs.FindObjective( typeof( GetBaitObjective ) );

				        if( dropped is WormJarFull )
			                {
				                if( dropped.Amount!=1 )
				                {
					                this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "AH! Now this is Babe Winkleman material here!", mobile.NetState );
					                return false;
				                }
                                        }
				
					dropped.Delete();

					mobile.AddToBackpack( new Gold( Utility.RandomMinMax( 2375, 2595 ) ) );

					mobile.AddToBackpack( new SkillSlotDeedQuestReward() );
					mobile.AddToBackpack( new WeightIncreaseDeed() );
					mobile.AddToBackpack( new QuestGoodieBag() );

					obj.Complete();	
					qs.AddConversation( new EndConversation() );
					
 			                if( 1 > Utility.RandomDouble() ) // 1 = 100% = chance to drop 
			                switch ( Utility.Random( 3 ) )  
			                { 
		
					        case 0: mobile.AddToBackpack( new AncientFishingPole15() ); break;
					        case 1: mobile.AddToBackpack( new AncientFishingPole30() ); break;
					        case 2: mobile.AddToBackpack( new AncientFishingPole60() ); break;
					
			                }					
				
					return true;
         		        }
				else if ( dropped is WormJarFull )
				{
				        this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
         			        return false;
				}
         		        else
         		        {
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I don't think the fish will be biting on that!", mobile.NetState );
     			        }
			}

			return false;
		}
	}
}
				


				


