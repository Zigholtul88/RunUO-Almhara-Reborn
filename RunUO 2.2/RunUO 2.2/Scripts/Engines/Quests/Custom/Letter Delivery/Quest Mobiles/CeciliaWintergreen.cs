using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Engines.Quests;

namespace Server.Engines.Quests.LetterDelivery
{
	[CorpseName( "Cecilia Wintergreen's corpse" )]
	public class CeciliaWintergreen : BaseQuester
	{
                [Constructable]
		public CeciliaWintergreen()
		{
                }

		public override void InitOutfit()
		{
			Name = "Cecilia Wintergreen";
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
                        Hue = 1002;
                        HairItemID = 12239;
                        HairHue = 1519;

			SetStr( 238 );
			SetDex( 142 );
			SetInt( 156 );

			SetSkill( SkillName.Anatomy, 59.5, 68.7 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 61.0, 93.0 );

			PackGold( 37, 51 );

			AddItem( new FeatheredHat(868) );
			AddItem( new FormalDress(688) );
			AddItem( new ThighBoots(868) );
		}

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			QuestSystem qs = player.Quest;

			if ( qs is LetterDeliveryQuest )
			{
				Direction = GetDirectionTo( player );

				QuestObjective obj = qs.FindObjective( typeof( DeliverLetterToCeciliaObjective ) );

				if ( obj != null && !obj.Completed )
				{
					obj.Complete();					
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
					if ( dropped is LetterToCecilia )
					{
						QuestObjective obj = qs.FindObjective( typeof( GiveLetterToCeciliaObjective ) );

						if ( obj != null && !obj.Completed )
						{
							dropped.Delete();
				                        PlaySound( 816 );
							player.AddToBackpack( new LetterToOzzy() );
							player.AddToBackpack( new Gold( 50 ) );								
							obj.Complete();
						}				
					}
				}
			}

			return base.OnDragDrop( from, dropped );
		}		

		public CeciliaWintergreen( Serial serial ) : base( serial )
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