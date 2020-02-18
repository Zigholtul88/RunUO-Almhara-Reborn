using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Engines.Quests;

namespace Server.Engines.Quests.StolenNecklace
{
	[CorpseName( "Raina Gollemere's corpse" )]
	public class RainaGollemere : BaseQuester
	{
                [Constructable]
		public RainaGollemere()
		{
                }

		public override void InitOutfit()
		{
			Name = "Raina Gollemere";
                        Title = "(Stolen Necklace)";
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
			CantWalk = true;
                        Hue = 1023;
                        HairItemID = 12240;
                        HairHue = 1141;

			SetStr( 136 );
			SetDex( 71 );
			SetInt( 102 );

			SetSkill( SkillName.Anatomy, 59.5, 68.7 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 61.0, 93.0 );
                }

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			Direction = GetDirectionTo( player );

			QuestSystem qs = player.Quest;

			if ( qs is StolenNecklaceQuest )
			{
				if ( qs.IsObjectiveInProgress( typeof( GetStolenNecklaceObjective ) ) )
				{
					qs.AddConversation( new DuringGetStolenNecklaceConversation() );
				}						
			}
			else
			{
				QuestSystem newQuest = new StolenNecklaceQuest( player );

				if ( qs == null && QuestSystem.CanOfferQuest( player, typeof( StolenNecklaceQuest ) ) )
				{
					newQuest.SendOffer();
				}
				else
				{
					newQuest.AddConversation( new DontOfferConversation() );
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{			
			PlayerMobile player = from as PlayerMobile;

			if ( player != null )
			{
				QuestSystem qs = player.Quest;

				if ( qs is StolenNecklaceQuest )
				{
					if ( dropped is QuestStolenNecklace )
					{
					      qs.AddConversation( new EndConversation() );
						QuestObjective obj = qs.FindObjective( typeof( ReturnStolenNecklaceObjective ) );

						if ( obj != null && !obj.Completed )
						{
							dropped.Delete();
							player.AddToBackpack( new GreaterManaPotion() );	
							player.AddToBackpack( new Gold( 1180 ) );
							player.AddToBackpack( new WeightIncreaseDeed() );
							player.AddToBackpack( new SkillSlotDeedQuestReward() );		
							obj.Complete();	
						}				
					}
				}
			}

			return base.OnDragDrop( from, dropped );
		}

		public RainaGollemere( Serial serial ) : base( serial )
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