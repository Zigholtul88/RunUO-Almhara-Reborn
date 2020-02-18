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
	[CorpseName( "Erik's corpse" )]
	public class ErikSullivan : BaseQuester
	{
		[Constructable]
		public ErikSullivan()
		{
		}

		public override void InitOutfit()
		{
			Name = "Erik Sullivan";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 0x83F3;
			HairItemID = 8251;  
                        HairHue = 1741;	
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			Cutlass weapon = new Cutlass();
			weapon.Movable = true;
			AddItem( weapon );

			NorseHelm helm = new NorseHelm();
			helm.Movable = true;
			AddItem( helm );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Movable = true;
			AddItem( gloves );

			RingmailChest chest = new RingmailChest();
			chest.Movable = true;
			AddItem( chest );

			RingmailLegs legs = new RingmailLegs();
			legs.Movable = true;
			AddItem( legs );

			AddItem( new BodySash(944) );
			AddItem( new HighBoots() );
			AddItem( new Kilt(944) );
			AddItem( new PlumeCloak(944) );
		}

		public ErikSullivan( Serial serial ) : base( serial )
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

			if ( qs is TheFairElainQuest )
			{
				QuestObjective obj = qs.FindObjective( typeof( SeekErikSullivanObjective ) );

				if ( qs.IsObjectiveInProgress( typeof( SeekErikSullivanObjective ) ) )
				{
					obj.Complete();
					qs.AddConversation( new ErikSullivanConversation() );
				}
                                else
                                {
					obj = qs.FindObjective( typeof( SeekAndoraObjective ) );

                                        if ( qs.IsObjectiveInProgress( typeof( SeekAndoraObjective ) ) )
                                        {
					        qs.AddConversation( new DuringSeekAndoraConversation() );
                                        }
                                }
                        }
                        else
                        {
				Say( "What now! Make it quick! I'm currently preoccupied right now!" );
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

				if ( qs is TheFairElainQuest )
				{
					QuestObjective obj = qs.FindObjective( typeof( BringBookToVacarObjective ) );

				        if ( qs.IsObjectiveInProgress( typeof( BringBookToVacarObjective ) ) )
				        {
				                if( dropped is VacarsLoveLetter )
         		                        {
         			                        if( dropped.Amount!=1 )
         			                        {
					                        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "There's not the right amount here!", player.NetState );
         				                        return false;
         			                        }

					                dropped.Delete(); 
					                player.AddToBackpack( new Gold( 500 ) );

					                player.AddToBackpack( new SkillSlotDeedQuestReward() );
					                player.AddToBackpack( new WeightIncreaseDeed() );
					                player.AddToBackpack( new QuestGoodieBag() );

					                switch ( Utility.Random( 2 ) )
					                {
						                case 0: player.AddToBackpack( new JaggedKatana() ); break;
						                case 1: player.AddToBackpack( new Mauler() ); break;
					                } 				

					                qs.AddConversation( new ErikSullivanEndConversation() );
				
					                return true;
                                                }
         		                }
				        else if ( dropped is AndorasBook )
				        {
				                this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, player.NetState );
         			                return false;
				        }
                                }
         		        else
         		        {
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "This isn't what I asked for, runt.", player.NetState );
     			        }
			}

			return false;
		}
	}
}
