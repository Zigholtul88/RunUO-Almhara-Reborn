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
	[CorpseName( "Andora's corpse" )]
	public class Andora : BaseQuester
	{
		[Constructable]
		public Andora()
		{
		}

		public override void InitOutfit()
		{
			Name = "Andora";
                        Title = "the Ranger";

                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 0x83F8;
                        HairItemID = 0x203D;
                        HairHue = 351;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			CompositeBow weapon = new CompositeBow();
			weapon.Movable = true;
			AddItem( weapon );

			LeatherChest chest = new LeatherChest();
			chest.Movable = true;
			AddItem( chest );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Movable = true;
			AddItem( gloves );

			AddItem( new Shirt(3) );
			AddItem( new ThighBoots() );
			AddItem( new ShortPants(5) );
			AddItem( new RegalCloak(168) );	
		}

		public Andora( Serial serial ) : base( serial )
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
				QuestObjective obj = qs.FindObjective( typeof( SeekAndoraObjective ) );

				if ( qs.IsObjectiveInProgress( typeof( SeekAndoraObjective ) ) )
				{
					obj.Complete();
					qs.AddConversation( new AndoraConversation() );
				}
                                else
                                {
					obj = qs.FindObjective( typeof( SeekAcarasObjective ) );

                                        if ( qs.IsObjectiveInProgress( typeof( SeekAcarasObjective ) ) )
                                        {
					        qs.AddConversation( new DuringSeekAcarasConversation() );
                                        }
                                }
                        }
                        else
                        {
				Say( "What do you want?" );
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
					QuestObjective obj = qs.FindObjective( typeof( BringRingToAndoraObjective ) );

				        if ( qs.IsObjectiveInProgress( typeof( BringRingToAndoraObjective ) ) )
				        {
				                if( dropped is AcarasRing )
         		                        {
         			                        if( dropped.Amount!=1 )
         			                        {
					                        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "There's not the right amount here!", player.NetState );
         				                        return false;
         			                        }

					                dropped.Delete(); 
					                player.AddToBackpack( new Gold( 500 ) );
         				                player.AddToBackpack( new AndorasBook() );

					                obj.Complete();
					                qs.AddConversation( new AndorasEndConversation() );

					                return true;
                                                }
         		                }
				        else if ( dropped is Whip )
				        {
				                this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, player.NetState );
         			                return false;
				        }
                                }
         		        else
         		        {
				        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Bring me the insolent mage's ring.", player.NetState );
			        }
                        }

                        return false;
                }
	}
}
