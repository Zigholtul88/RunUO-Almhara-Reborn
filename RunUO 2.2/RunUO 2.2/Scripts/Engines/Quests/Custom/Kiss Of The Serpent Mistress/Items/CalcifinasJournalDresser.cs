using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server.Engines.Quests.KissOfTheSerpentMistress
{
	public class CalcifinasJournalDresser : BaseContainer
	{
		[Constructable]
		public CalcifinasJournalDresser() : base( 0xA4F )
		{
                      Name = "a dresser";
		      Movable = false;
		}

		public CalcifinasJournalDresser( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile player = from as PlayerMobile;

			if ( player != null && player.InRange( GetWorldLocation(), 2 ) )
			{
				QuestSystem qs = player.Quest;

				if ( qs is KissOfTheSerpentMistressQuest )
				{
					QuestObjective obj = qs.FindObjective( typeof( ObtainBowAndJournalObjective ) );

					if ( (obj != null && !obj.Completed) || KissOfTheSerpentMistressQuest.HasCalcifinasJournal( player ) )
					{
						Item journal = new CalcifinasJournal();

						if ( player.PlaceInBackpack( journal ) )
						{
                                                        player.SendMessage( "You take the journal from the dresser and place it into your pack." );

							if ( obj != null && !obj.Completed )
								obj.Complete();
						}
						else
						{
                                                        player.SendMessage( "You find a journal, but can't pick it up because your pack is too full. Come back when you have more room in your pack." );
							journal.Delete();
						}

						return;
					}
				}
			}

			base.OnDoubleClick( from );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}