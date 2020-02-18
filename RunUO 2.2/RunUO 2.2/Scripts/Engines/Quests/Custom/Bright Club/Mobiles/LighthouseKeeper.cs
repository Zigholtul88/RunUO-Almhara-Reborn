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

namespace Server.Engines.Quests.BrightClub
{
	public class LighthouseKeeper : BaseQuester
	{
                [Constructable]
		public LighthouseKeeper()
		{
                }

		public override void InitOutfit()
		{
			InitStats( 100, 100, 25 );

			Name = "The Lighthouse Keeper";
                        Title = "(Bright Club)";
			Direction = Direction.East;
			CantWalk = true;
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 0x83EA;
			HairItemID = 0x203B;  
                        HairHue = 1175;	
                        FacialHairItemID = 0;
                        FacialHairHue = 0;		

			SetSkill( SkillName.AnimalLore, 200, 500 );
			SetSkill( SkillName.Anatomy, 200, 500 );
			SetSkill( SkillName.AnimalTaming, 200, 500 );
			SetSkill( SkillName.Meditation, 200, 500 );
			SetSkill( SkillName.Wrestling, 200, 500 );

			AddItem( new FancyShirt( Utility.RandomRedHue() ) );
			AddItem( new LongPants( Utility.RandomBlueHue() ) );
			AddItem( new BodySash( Utility.RandomGreenHue() ) );
			AddItem( new Sandals( Utility.RandomGreenHue() ) );
		}
		
		public LighthouseKeeper( Serial serial ) : base( serial )
		{
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

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			Direction = GetDirectionTo( player );

			QuestSystem qs = player.Quest;

			if ( qs is BrightClubQuest )
			{
				if ( qs.IsObjectiveInProgress( typeof( KillGolemObjective ) ) )
				{
					qs.AddConversation( new DirectionConversation() );
                                }
			}
			else
			{
				BrightClubQuest newQuest = new BrightClubQuest( player );
				bool inRestartPeriod = false;

				if ( qs != null )
				{
					if ( contextMenu )
						player.SendMessage("I understand that you're eager but perhaps you might outta finish that there quest you started earlier!");
				}
				else if ( QuestSystem.CanOfferQuest( player, typeof( BrightClubQuest ), out inRestartPeriod ) )
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

				if ( qs is BrightClubQuest )
				{
					QuestObjective obj = qs.FindObjective( typeof( ReturnToLighthouseObjective ) );

				        if( dropped is LightEnhancingCrystal )
         		                {
					        dropped.Delete();
					        obj.Complete();	
					        qs.AddConversation( new EndConversation() );
 
				                mobile.AddToBackpack( new TownTravelBook() );
					        mobile.AddToBackpack( new Gold( Utility.RandomMinMax( 3575, 4795 ) ) );

					        mobile.AddToBackpack( new SkillSlotDeedQuestReward() );
					        mobile.AddToBackpack( new WeightIncreaseDeed() );
					        mobile.AddToBackpack( new QuestGoodieBag() );
					
					        return true;
                                        }
         		        }
				if( dropped is TownTravelBook )
         		        {
					dropped.Delete();
 
				        mobile.SendMessage( "Alright, let me just do a bit of this and that...... and its now recharged." );
				        mobile.AddToBackpack( new TownTravelBook() );
					
					return true;
         		        }
         		        else
         		        {
					SayTo( from, "I have no need for that. I only need a Light Enhancing Crystal or to recharge your town travel book." );
     			        }
			}

			return false;
		}
	}
}