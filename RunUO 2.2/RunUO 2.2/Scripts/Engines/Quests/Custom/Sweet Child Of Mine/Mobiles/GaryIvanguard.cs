using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Engines.Quests;

namespace Server.Engines.Quests.SweetChildOfMine
{
	[CorpseName( "a dedicated father's corpse" )]
	public class GaryIvanguard : BaseQuester
	{
		[Constructable]
		public GaryIvanguard()
		{
		}

		public override void InitOutfit()
		{
			Name = "Gary Ivanguard";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
			SpeechHue = 9;
                        Hue = 46;
                        HairItemID = 0x203B;
                        HairHue = 1836;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			SetStr( 1025, 1250 );
			SetDex( 120, 125 );
			SetInt( 1800, 1935 );
			SetHits( 5000, 5550 );

			SetSkill( SkillName.MagicResist, 205.0, 220.0 );
			SetSkill( SkillName.Focus, 216.0, 230.0);
			SetSkill( SkillName.Magery, 219.0, 225.0 ); 
			SetSkill( SkillName.Meditation, 212.0, 215.0 ); 

			VirtualArmor = 44; 

			Container pack = new Backpack();
			pack.Movable = false;
			AddItem( pack );
			
			Item Boots = new Boots();
			Boots.Hue = 351;
			Boots.Name = "Work Boots";
			Boots.Movable = false;
			AddItem( Boots );
			
			Item LongPants = new LongPants();
			LongPants.Hue = 1282;
      	                LongPants.Name = "Wrangler Jeans";
			LongPants.Movable = false;
			AddItem( LongPants );
			
			Item FancyShirt = new FancyShirt();
			FancyShirt.Hue = 1321;
      	                FancyShirt.Name = "Flannel Button-Up Shirt";
			FancyShirt.Movable = false;
			AddItem( FancyShirt );
			
			Item ring = new GoldRing();
			ring.Name = "Wedding Ring";
			ring.Movable = false;
			AddItem( ring );
		}

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			Direction = GetDirectionTo( player );

			QuestSystem qs = player.Quest;

			if ( qs is SweetChildOfMineQuest )
			{
				QuestObjective obj = qs.FindObjective( typeof( FindHusbandObjective ) );

				if ( qs.IsObjectiveInProgress( typeof( FindHusbandObjective ) ) )
				{
                                        // punches
			                PlaySound( 315 );
					Animate( 31, 5, 1, true, false, 0 );
					obj.Complete();
					qs.AddConversation( new TalkToGaryConversation() );
				}
                                else
                                {
					obj = qs.FindObjective( typeof( FindKeyObjective ) );

                                        if ( qs.IsObjectiveInProgress( typeof( FindKeyObjective ) ) )
                                        {
                                                // huh?
			                        PlaySound( 1071 );
					        qs.AddConversation( new DuringFindKeyConversation() );
                                        }
                                        else
                                        {
						obj = qs.FindObjective( typeof( ReturnKeyObjective ) );

                                                if ( qs.IsObjectiveInProgress( typeof( ReturnKeyObjective ) ) )
                                                {
                                                        // slaps
					                Say( "*Gary slaps you in the face*" );
			                                PlaySound( 948 );
					                Animate( 11, 5, 1, true, false, 0 );
					                qs.AddConversation( new DuringFindKeyConversation() );
                                                }
                                                else
                                                {
						        obj = qs.FindObjective( typeof( RetrieveBabyObjective ) );

                                                        if ( qs.IsObjectiveInProgress( typeof( RetrieveBabyObjective ) ) )
                                                        {
                                                                // slaps
					                        Say( "*Gary slaps you in the face*" );
			                                        PlaySound( 948 );
					                        Animate( 11, 5, 1, true, false, 0 );
					                        qs.AddConversation( new DuringRetrieveBabyConversation() );
                                                        }
                                                        else
                                                        {
						                obj = qs.FindObjective( typeof( ReturnBabyObjective ) );

						                if ( qs.IsObjectiveInProgress( typeof( ReturnBabyObjective ) ) )
						                {
					                                Say( "The baby! Give her to me!" );
					                                Animate( 32, 5, 1, true, false, 0 );
                                                                }
                                                                else
                                                                {
						                        obj = qs.FindObjective( typeof( ReturnToDebbieObjective ) );

						                        if ( qs.IsObjectiveInProgress( typeof( ReturnToDebbieObjective ) ) )
						                        {
					                                        qs.AddConversation( new DuringReturnToDebbieConversation() );
                                                                        }
                                                                }
                                                        }             
						}
				        }
                                }
                        }
                        else
                        {
				Say( "Bugger off, I'm busy! Open! Damn it door, open!" );
			        PlaySound( 315 );
				Animate( 31, 5, 1, true, false, 0 );
                        }

			return;
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{			
			PlayerMobile player = from as PlayerMobile;

			if ( player != null )
			{
				QuestSystem qs = player.Quest;

				if ( qs is SweetChildOfMineQuest )
				{
					if ( dropped is IguanaCoveKey )
					{
						QuestObjective obj = qs.FindObjective( typeof( ReturnKeyObjective ) );

						if ( obj != null && !obj.Completed )
						{
							obj.Complete();	
					                qs.AddConversation( new HandKeyToGaryConversation() );
							player.AddToBackpack( new IguanaCoveKey() );									
							dropped.Delete();								
						}				
					}					
					else if ( dropped is Baby )
					{
						QuestObjective obj = qs.FindObjective( typeof( ReturnBabyObjective ) );

						if ( obj != null && !obj.Completed )
						{
							obj.Complete();	
					                qs.AddConversation( new RelievedGaryConversation() );								
							dropped.Delete();								
						}				
					}
				}
			}

			return base.OnDragDrop( from, dropped );
		}

		public GaryIvanguard( Serial serial ) : base( serial )
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
	}
}