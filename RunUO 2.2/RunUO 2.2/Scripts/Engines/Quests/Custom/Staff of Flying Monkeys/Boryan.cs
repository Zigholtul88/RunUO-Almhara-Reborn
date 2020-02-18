using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Engines.Quests;

namespace Server.Engines.Quests.StaffOfFlyingMonkeys
{
	[CorpseName( "Boryan's corpse" )]
	public class Boryan : BaseQuester
	{
                [Constructable]
		public Boryan()
		{
                }

		public override void InitOutfit()
		{
			Name = "Boryan the Crazed Collector";
                        Title = "(Staff of Flying Monkeys)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
			CantWalk = true;
                        Hue = 33820;
                        HairItemID = 0;
                        HairHue = 0;
                        FacialHairItemID = 8257;
                        FacialHairHue = 1109;

                        InitStats( 31, 41, 51 );

			AddItem( new SkullCap(902) );
			AddItem( new FancyRobe(153) );
                }

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			Direction = GetDirectionTo( player );

			QuestSystem qs = player.Quest;

			if ( qs is StaffOfFlyingMonkeysQuest )
			{
				QuestObjective obj = qs.FindObjective( typeof( GoToMongbatCavernsObjective ) );

				if ( qs.IsObjectiveInProgress( typeof( GoToMongbatCavernsObjective ) ) )
				{
					qs.AddConversation( new DuringGoToMongbatCavernsConversation() );
				}
                                else
                                {
					obj = qs.FindObjective( typeof( HandStaffOverObjective ) );

                                        if ( qs.IsObjectiveInProgress( typeof( HandStaffOverObjective ) ) )
                                        {
					        qs.AddConversation( new DuringHandStaffOverConversation() );
                                        }
                                }
                        }
			else
			{
				StaffOfFlyingMonkeysQuest newQuest = new StaffOfFlyingMonkeysQuest( player );
				bool inRestartPeriod = false;

				if ( qs != null )
				{
					newQuest.AddConversation( new DontOfferConversation() );
				}
				else if ( QuestSystem.CanOfferQuest( player, typeof( StaffOfFlyingMonkeysQuest ), out inRestartPeriod ) )
				{
					newQuest.SendOffer();
				}
				else if ( inRestartPeriod && contextMenu )
				{
					newQuest.AddConversation( new RecentlyFinishedConversation() );
				}
			}
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			base.OnMovement( m, oldLocation );

                        if ( m.Alive )
                        {
			        if ( InRange( m.Location, 10 ) && !InRange( oldLocation, 10 ) && m is PlayerMobile )
			        {
				        PlayerMobile pm = (PlayerMobile)m;
				        QuestSystem qs = pm.Quest;

				        if ( qs is StaffOfFlyingMonkeysQuest )
				        {
				                 QuestObjective obj = qs.FindObjective( typeof( EscapeObjective ) );

					         if ( obj != null && !obj.Completed )
                                                 {
					                  StaffOfMongbats staffofmongbats = pm.Backpack.FindItemByType( typeof ( StaffOfMongbats ) ) as StaffOfMongbats;

					                  if ( staffofmongbats != null )
					                  {
                                                                 // hey!
			                                         PlaySound( 1069 );

							         obj.Complete();
					                         qs.AddConversation( new HandStaffOverConversation() );
                                                          }
					                  else if ( staffofmongbats == null )
					                  {
                                                                 // growls!
			                                         PlaySound( 1068 );
                                                          }
					         }
					}
				}
                                else
                                {
			                if ( InRange( m.Location, 2 ) && !InRange( oldLocation, 2 ) && m is PlayerMobile )
			                {
				                PlayerMobile pm = (PlayerMobile)m;
				                QuestSystem qs = pm.Quest;

				                if ( qs is StaffOfFlyingMonkeysQuest )
				                {
				                          QuestObjective obj = qs.FindObjective( typeof( HandStaffOverObjective ) );

					                  if ( obj != null && !obj.Completed )
                                                          {
					                         StaffOfMongbats staffofmongbats = pm.Backpack.FindItemByType( typeof ( StaffOfMongbats ) ) as StaffOfMongbats;

					                         if ( staffofmongbats != null )
					                         {
                                                                        // ah!
			                                                PlaySound( 1049 );

                                                                 }
					                         else if ( staffofmongbats == null )
					                         {
                                                                        // ahhhh!
			                                                PlaySound( 1088 );
                                                                 }
                                                          }
					         }
					}
				}
			}
                }

		public override bool OnDragDrop( Mobile from, Item dropped )
		{			
			PlayerMobile player = from as PlayerMobile;

			if ( player != null )
			{
				QuestSystem qs = player.Quest;

				if ( qs is StaffOfFlyingMonkeysQuest )
				{
					if ( dropped is StaffOfMongbats )
					{
						QuestObjective obj = qs.FindObjective( typeof( HandStaffOverObjective ) );

						if ( obj != null && !obj.Completed )
						{
							obj.Complete();	
							dropped.Delete();

					                player.AddToBackpack( new Gold( Utility.RandomMinMax( 4200, 4500 ) ) );

						        player.AddToBackpack( new WeightIncreaseDeed() );
						        player.AddToBackpack( new SkillSlotDeedQuestReward() );

							player.AddToBackpack( new CrackedHitFireballGem() );
						}				
					}
				}
			}

			return base.OnDragDrop( from, dropped );
		}

		public Boryan( Serial serial ) : base( serial )
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
	}
}