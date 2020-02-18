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
	[CorpseName( "Auntie June's corpse" )]
	public class AuntieJune : BaseQuester
	{
		[Constructable]
		public AuntieJune()
		{
		}

		public override void InitOutfit()
		{
			Name = "Auntie June";
                        Title = "the biofarmer";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 0x83F8;
                        HairItemID = 0x203D;
                        HairHue = 91;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			Robe r = new Robe();
                        r.Hue = 1156;
                        AddItem( r );
		}

		public AuntieJune( Serial serial ) : base( serial )
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

			if ( qs is FamilyJewelsQuest )
			{
				QuestObjective obj = qs.FindObjective( typeof( SeekAuntieJuneObjective ) );

				if ( qs.IsObjectiveInProgress( typeof( SeekAuntieJuneObjective ) ) )
				{
					obj.Complete();
					qs.AddConversation( new AuntieJuneConversation() );
				}
                                else
                                {
					obj = qs.FindObjective( typeof( ObtainBlueAppleObjective ) );

                                        if ( qs.IsObjectiveInProgress( typeof( ObtainBlueAppleObjective ) ) )
                                        {
					        qs.AddConversation( new DuringObtainBlueAppleConversation() );
                                        }
                                        else
                                        {
						obj = qs.FindObjective( typeof( ReturnToArrianaObjective ) );

                                                if ( qs.IsObjectiveInProgress( typeof( ReturnToArrianaObjective ) ) )
                                                {
					                qs.AddConversation( new DuringReturnToArrianaConversation() );
                                                }
                                        }
                                }
                        }
                        else
                        {
				Say( "*sighs* These apples are too darn heavy." );
                        }

			return;
		}

                public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
			PlayerMobile player = from as PlayerMobile;

			if ( player != null )
			{
				QuestSystem qs = player.Quest;

				if ( qs is FamilyJewelsQuest )
				{
					QuestObjective obj = qs.FindObjective( typeof( ObtainBlueAppleObjective ) );

				        if ( qs.IsObjectiveInProgress( typeof( ObtainBlueAppleObjective ) ) )
				        {
				                if( dropped is BlueAppleQuest )
         		                        {
         			                        if( dropped.Amount!=1 )
         			                        {
					                        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "There's not the right amount here!", player.NetState );
         				                        return false;
         			                        }

					                dropped.Delete();
         				                player.AddToBackpack( new ArrianasClips() );

					                obj.Complete();
					                qs.AddConversation( new AuntieJune2Conversation() );

					                return true;
                                                }
         		                }
				        else if ( dropped is BlueAppleQuest )
				        {
				                this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, player.NetState );
         			                return false;
				        }
                                }
         		        else
         		        {
				        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Find me a blue apple that can be lifted.", player.NetState );
			        }
                        }

                        return false;
                }
	}
}
