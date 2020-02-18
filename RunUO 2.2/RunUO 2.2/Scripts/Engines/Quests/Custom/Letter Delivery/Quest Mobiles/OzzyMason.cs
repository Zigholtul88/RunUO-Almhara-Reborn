using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Engines.Quests;

namespace Server.Engines.Quests.LetterDelivery
{
	[CorpseName( "Ozzy Mason's corpse" )]
	public class OzzyMason : BaseQuester
	{
            [Constructable]
		public OzzyMason()
		{
                }

		public override void InitOutfit()
		{
			Name = "Ozzy Mason";
                        Title = "(Letter Delivery)";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33807;
                        HairItemID = 8252;
                        HairHue = 1109;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			SetStr( 257 );
			SetDex( 156 );
			SetInt( 127 );

			SetSkill( SkillName.Anatomy, 59.5, 68.7 );
			SetSkill( SkillName.ArmsLore, 64.0, 100.0 );
			SetSkill( SkillName.Swords, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );

			PackGold( 26, 43 );

			LeatherArms arms = new LeatherArms();
                        arms.Hue = 2207;
			arms.Movable = true;
			AddItem( arms );

			StuddedChest chest = new StuddedChest();
                        chest.Hue = 2414;
			chest.Movable = true;
			AddItem( chest );

			LeatherGloves gloves = new LeatherGloves();
                        gloves.Hue = 2414;
			gloves.Movable = true;
			AddItem( gloves );

			LeatherLegs legs = new LeatherLegs();
                        legs.Hue = 2207;
			legs.Movable = true;
			AddItem( legs );

			Longsword weapon = new Longsword(); 
			weapon.Quality = WeaponQuality.Exceptional; 
			weapon.Movable = true; 
			AddItem( weapon ); 

			AddItem( new Shoes(2414) );
		}

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			Direction = GetDirectionTo( player );

			QuestSystem qs = player.Quest;

			if ( qs is LetterDeliveryQuest )
			{
				if ( qs.IsObjectiveInProgress( typeof( PotionObjective ) ) )
				{
					qs.AddConversation( new DuringPotionConversation() );
				}
				else if ( qs.IsObjectiveInProgress( typeof( DeliverLetterToCeciliaObjective ) ) )
				{
					qs.AddConversation( new DuringLetterToCeciliaConversation() );
				}
				else if ( qs.IsObjectiveInProgress( typeof( DeliverLetterToOzzyObjective ) ) )
				{
					qs.AddConversation( new DuringLetterToOzzyConversation() );
				}
			}
			else
			{
				QuestSystem newQuest = new LetterDeliveryQuest( player );

				if ( qs == null && QuestSystem.CanOfferQuest( player, typeof( LetterDeliveryQuest ) ) )
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

				if ( qs is LetterDeliveryQuest )
				{
					if ( dropped is LesserHealPotion )
					{
						QuestObjective obj = qs.FindObjective( typeof( PotionObjective ) );

						if ( obj != null && !obj.Completed )
						{
							obj.Complete();
				                        PlaySound( 1054 );
							player.AddToBackpack( new LetterToCecilia() );								
							dropped.Delete();								
						}				
					}					
					else if ( dropped is LetterToOzzy )
					{
						QuestObjective obj = qs.FindObjective( typeof( DeliverLetterToOzzyObjective ) );

						if ( obj != null && !obj.Completed )
						{
							obj.Complete();
							player.AddToBackpack( new Gold( 1000 ) );	
							player.AddToBackpack( new FireOpal() );	
					                player.AddToBackpack( new SkillSlotDeedQuestReward() );
							player.AddToBackpack( new WeightIncreaseDeed() );								
							dropped.Delete();								
						}				
					}
				}
			}

			return base.OnDragDrop( from, dropped );
		}

		public OzzyMason( Serial serial ) : base( serial )
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