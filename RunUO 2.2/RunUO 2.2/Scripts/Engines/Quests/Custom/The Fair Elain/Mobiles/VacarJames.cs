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
	[CorpseName( "Vacar's corpse" )]
	public class VacarJames : BaseQuester
	{
		[Constructable]
		public VacarJames()
		{
		}

		public override void InitOutfit()
		{
			Name = "Vacar James";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 0x83F5;
			HairItemID = 8251;  
                        HairHue = 1741;	
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			AddItem( new Sandals() );
			AddItem( new Surcoat(441) );
			AddItem( new ShortPants(443) );
			AddItem( new BodySash() );
			AddItem( new Cap() );		
	        }

		public VacarJames( Serial serial ) : base( serial )
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
				QuestObjective obj = qs.FindObjective( typeof( SeekVacarJamesObjective ) );

				if ( qs.IsObjectiveInProgress( typeof( SeekVacarJamesObjective ) ) )
				{
					obj.Complete();
					qs.AddConversation( new VacarJamesConversation() );
				}
                                else
                                {
					obj = qs.FindObjective( typeof( SeekErikSullivanObjective ) );

                                        if ( qs.IsObjectiveInProgress( typeof( SeekErikSullivanObjective ) ) )
                                        {
					        qs.AddConversation( new DuringSeekErikSullivanConversation() );
                                        }
                                        else
                                        {
						obj = qs.FindObjective( typeof( BringBookToVacarObjective ) );

                                                if ( qs.IsObjectiveInProgress( typeof( BringBookToVacarObjective ) ) )
                                                {
					                qs.AddConversation( new DuringBringLetterVacarConversation() );
                                                }
                                        }
                                }
                        }
                        else
                        {
				Say( "Oh deary me! Is there something I can help you with!" );
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
				                if( dropped is AndorasBook )
         		                        {
         			                        if( dropped.Amount!=1 )
         			                        {
					                        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "There's not the right amount here!", player.NetState );
         				                        return false;
         			                        }

					                dropped.Delete(); 
					                player.AddToBackpack( new Gold( 5 ) );
					                player.AddToBackpack( new VacarsLoveLetter() );					

					                qs.AddConversation( new VacarJamesEndConversation() );

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
				        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "What is this crap? It's all crap!", player.NetState );
     			        }
                        }

		        return false;
                }
	}
}
