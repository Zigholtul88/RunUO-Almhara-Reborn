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
	[CorpseName( "Grandpa Tam's corpse" )]
	public class GrandpaTam : BaseQuester
	{
		[Constructable]
		public GrandpaTam()
		{
		}

		public override void InitOutfit()
		{
			Name = "Grandpa Tam";
                        Title = "the old coot";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 0x83F5;
			HairItemID = 8251;  
                        HairHue = 1150;	
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			Boots b = new Boots();
                        b.Hue = 1;
                        AddItem( b );

                        LongPants lp = new LongPants();
                        lp.Hue = 292;
                        AddItem( lp );

		        FancyShirt fs = new FancyShirt();
                        fs.Hue = 1153;
                        AddItem( fs );		
	        }

		public GrandpaTam( Serial serial ) : base( serial )
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
				QuestObjective obj = qs.FindObjective( typeof( SeekGrandpaTamObjective ) );

				if ( qs.IsObjectiveInProgress( typeof( SeekGrandpaTamObjective ) ) )
				{
					obj.Complete();
					qs.AddConversation( new GrandpaTamConversation() );
				}
                                else
                                {
					obj = qs.FindObjective( typeof( ObtainGoldenEggObjective ) );

                                        if ( qs.IsObjectiveInProgress( typeof( ObtainGoldenEggObjective ) ) )
                                        {
					        qs.AddConversation( new DuringObtainGoldenEggConversation() );
                                        }
                                        else
                                        {
						obj = qs.FindObjective( typeof( SeekAuntieJuneObjective ) );

                                                if ( qs.IsObjectiveInProgress( typeof( SeekAuntieJuneObjective ) ) )
                                                {
					                qs.AddConversation( new DuringSeekAuntieJuneConversation() );
                                                }
                                        }
                                }
                        }
                        else
                        {
				Say( "I want a golden omelet! I want a golden chance to make my day!" );
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
					QuestObjective obj = qs.FindObjective( typeof( ObtainGoldenEggObjective ) );

				        if ( qs.IsObjectiveInProgress( typeof( ObtainGoldenEggObjective ) ) )
				        {
				                if( dropped is GoldenEggQuest )
         		                        {
         			                        if( dropped.Amount!=1 )
         			                        {
					                        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "There's not the right amount here!", player.NetState );
         				                        return false;
         			                        }

					                dropped.Delete(); 
					                player.AddToBackpack( new ArrianasHoops() );					

					                qs.AddConversation( new GrandpaTam2Conversation() );

					                return true;
                                                }
                                        }
				        else if ( dropped is GoldenEggQuest )
				        {
				                this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, player.NetState );
         			                return false;
				        }
                                }
         		        else
         		        {
				        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Heh!", player.NetState );
     			        }
                        }

		        return false;
                }
	}
}
