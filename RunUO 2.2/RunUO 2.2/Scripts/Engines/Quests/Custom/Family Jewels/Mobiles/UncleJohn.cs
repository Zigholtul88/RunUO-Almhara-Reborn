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
	[CorpseName( "Uncle John's corpse" )]
	public class UncleJohn : BaseQuester
	{
		[Constructable]
		public UncleJohn()
		{
		}

		public override void InitOutfit()
		{
			Name = "Uncle John";
                        Title = "the farming fool";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 0x83F5;
			HairItemID = 8251;  
                        HairHue = 1337;	
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

	                Pitchfork pf = new Pitchfork();
                        AddItem( pf );		
	        }

		public UncleJohn( Serial serial ) : base( serial )
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
				QuestObjective obj = qs.FindObjective( typeof( SeekUncleJohnObjective ) );

				if ( qs.IsObjectiveInProgress( typeof( SeekUncleJohnObjective ) ) )
				{
					obj.Complete();
					qs.AddConversation( new UncleJohnConversation() );
				}
                                else
                                {
					obj = qs.FindObjective( typeof( ObtainGreenCarrotObjective ) );

                                        if ( qs.IsObjectiveInProgress( typeof( ObtainGreenCarrotObjective ) ) )
                                        {
					        qs.AddConversation( new DuringObtainGreenCarrotConversation() );
                                        }
                                        else
                                        {
						obj = qs.FindObjective( typeof( SeekGrandpaTamObjective ) );

                                                if ( qs.IsObjectiveInProgress( typeof( SeekGrandpaTamObjective ) ) )
                                                {
					                qs.AddConversation( new DuringSeekGrandpaTamConversation() );
                                                }
                                        }
                                }
                        }
                        else
                        {
				Say( "Hey there young whippersnapper. Watch out for those savage bunnies." );
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
					QuestObjective obj = qs.FindObjective( typeof( ObtainGreenCarrotObjective ) );

				        if ( qs.IsObjectiveInProgress( typeof( ObtainGreenCarrotObjective ) ) )
				        {
				                if( dropped is GreenCarrotQuest )
         		                        {
         			                        if( dropped.Amount!=1 )
         			                        {
					                        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I only need 1 green carrot!", player.NetState );
         				                        return false;
         			                        }

					                dropped.Delete(); 
					                player.AddToBackpack( new ArrianasDiamond() );					

					                qs.AddConversation( new UncleJohn2Conversation() );

					                return true;
                                                }
                                        }
				        else if ( dropped is GreenCarrotQuest )
				        {
				                this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, player.NetState );
         			                return false;
				        }
                                }
         		        else
         		        {
				        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "This ain't no dog gone green carrot!", player.NetState );
     			        }
                        }

		        return false;
                }
	}
}
