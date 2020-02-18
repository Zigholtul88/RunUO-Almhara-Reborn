using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Engines.Quests;

namespace Server.Engines.Quests.SweetChildOfMine
{
	[CorpseName( "a loving mother's corpse" )]
	public class DebbieIvanguard : BaseQuester
	{
                [Constructable]
		public DebbieIvanguard()
		{
                }

		public override void InitOutfit()
		{
			Name = "Debbie Ivanguard";
                        Title = "(Sweet Child Of Mine)";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
			SpeechHue = 6;
                        Hue = 46;
                        HairItemID = 0x203D;
                        HairHue = 351;
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

			Container pack = new Backpack();
			pack.Movable = false;
			AddItem( pack );
			
			Item PlainDress = new PlainDress();//Hue = 0xE6;
			PlainDress.Hue = 0xE6;
			PlainDress.Movable = false;
			AddItem( PlainDress );
			
			Item Sandals = new Sandals();
			Sandals.Hue = 0xE6;
			Sandals.Movable = false;
			AddItem( Sandals );
			
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
				QuestObjective obj = qs.FindObjective( typeof( GoToIguanaCoveObjective ) );

				if ( qs.IsObjectiveInProgress( typeof( GoToIguanaCoveObjective ) ) )
				{
					Say( "*blows nose*" );
					PlaySound( 781 ); //play blows nose
					Animate( 34, 5, 1, true, false, 0 );

					qs.AddConversation( new DuringGoToIguanaCoveConversation() );
				}
                                else
                                {
					obj = qs.FindObjective( typeof( ReturnToDebbieObjective ) );

				        if ( qs.IsObjectiveInProgress( typeof( ReturnToDebbieObjective ) ) )
				        {
					         PlaySound( 803 ); //play oh!
						 Animate( 33, 5, 1, true, false, 0 );
					         obj.Complete();
				        }
                                }
			}
			else
			{
				QuestSystem newQuest = new SweetChildOfMineQuest( player );
				bool inRestartPeriod = false;

				if ( qs != null )
				{
					newQuest.AddConversation( new DontOfferConversation() );
				}
				else if ( QuestSystem.CanOfferQuest( player, typeof( SweetChildOfMineQuest ), out inRestartPeriod ) )
				{
					PlaySound( 787 ); //play cries
					Animate( 34, 5, 1, true, false, 0 );
					newQuest.SendOffer();
				}
				else if ( inRestartPeriod )
				{
					PlaySound( 816 ); //play sigh
					Animate( 32, 5, 1, true, false, 0 );
					newQuest.AddConversation( new RecentlyFinishedConversation() );
				}
			}
		}

		public DebbieIvanguard( Serial serial ) : base( serial )
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