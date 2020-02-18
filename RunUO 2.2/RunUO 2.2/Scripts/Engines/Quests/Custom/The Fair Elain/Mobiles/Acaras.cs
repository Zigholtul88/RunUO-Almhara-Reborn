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
	[CorpseName( "Acara's corpse" )]
	public class Acaras : BaseQuester
	{
		[Constructable]
		public Acaras()
		{
		}

		public override void InitOutfit()
		{
			Name = "Acaras";
                        Title = "the Mage";

                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 0x83F8;
                        HairItemID = 0;
                        HairHue = 0;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			SetStr( 150, 200 );
			SetDex( 100, 200 );
			SetInt( 175, 250 );

			SetHits( 100, 140 );

			SetDamage( 8, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.MagicResist, 85.0 );
			SetSkill( SkillName.Tactics, 70.0 );
			SetSkill( SkillName.Wrestling, 70.0 );
			SetSkill( SkillName.Anatomy, 50.0 );
			SetSkill( SkillName.Magery, 90.0 );
			SetSkill( SkillName.Meditation, 80.0 );
			SetSkill( SkillName.EvalInt, 90.0 );

			Fame = 1500;
			Karma = 0;

			VirtualArmor = 25;

			PackGold( 40, 85 );
			PackReg( 5 );
			PackReg( 5 );

			int amount = Utility.RandomMinMax( 1, 3 );

			switch ( Utility.Random( 8 ) )
			{
				case 0: PackItem( new Dagger() ); break;
				case 1: PackItem( new Shirt() ); break;
				case 2: PackGem( 2 ); break;
				case 3: PackItem( new SewingKit() ); break;
				case 4: PackItem( new LeatherGloves() ); break;
				case 5: PackItem( new AcarasRing() ); break;
				case 6: PackItem( new Lute() ); break;
				case 7: PackItem( new ScribesPen() ); break;
			}

			AddItem( new Server.Items.Boots() );
			AddItem( new Server.Items.LongPants( 12 ) );
			AddItem( new Server.Items.Shirt() );			
		}

		public Acaras( Serial serial ) : base( serial )
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
				QuestObjective obj = qs.FindObjective( typeof( SeekAcarasObjective ) );

				if ( qs.IsObjectiveInProgress( typeof( SeekAcarasObjective ) ) )
				{
					obj.Complete();
					qs.AddConversation( new AcarasConversation() );
				}
                                else
                                {
					obj = qs.FindObjective( typeof( BringRingToAndoraObjective ) );

                                        if ( qs.IsObjectiveInProgress( typeof( BringRingToAndoraObjective ) ) )
                                        {
					        qs.AddConversation( new DuringBringRingToAndoraAcaraConversation() );
                                        }
                                }
                        }
                        else
                        {
				Say( "Please don't kill me!" );
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
					QuestObjective obj = qs.FindObjective( typeof( BringAcarasRobeObjective ) );

				        if ( qs.IsObjectiveInProgress( typeof( BringAcarasRobeObjective ) ) )
				        {
				                if( dropped is Robe )
         		                        {
         			                        if( dropped.Amount!=1 )
         			                        {
					                        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "There's not the right amount here!", player.NetState );
         				                        return false;
         			                        }

					                dropped.Delete(); 
					                player.AddToBackpack( new Gold( 100 ) );
         				                player.AddToBackpack( new AcarasRing() );

					                obj.Complete();
					                qs.AddConversation( new AcarasEndConversation() );

					                return true;
                                                }
         		                }
				        else if ( dropped is AcarasRing )
				        {
				                this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, player.NetState );
         			                return false;
                                        }
			        }
         		        else
         		        {
				        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I don't need that. I need a new robe.", player.NetState );
     			        }
		        }

		        return false;
                }
	}
}
