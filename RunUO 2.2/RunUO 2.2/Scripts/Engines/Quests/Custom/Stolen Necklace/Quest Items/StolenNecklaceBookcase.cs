using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server.Engines.Quests.StolenNecklace
{
	public class StolenNecklaceBookcase : BaseContainer
	{
		[Constructable]
		public StolenNecklaceBookcase() : base( 0xA98 )
		{
                  Name = "a bookcase";
			Movable = false;
		}

		public StolenNecklaceBookcase( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile player = from as PlayerMobile;

			if ( player != null && player.InRange( GetWorldLocation(), 2 ) )
			{
				QuestSystem qs = player.Quest;

				if ( qs is StolenNecklaceQuest )
				{
					QuestObjective obj = qs.FindObjective( typeof( GetStolenNecklaceObjective ) );

					if ( (obj != null && !obj.Completed) || StolenNecklaceQuest.HasStolenNecklace( player ) )
					{
						Item necklace = new QuestStolenNecklace();

						if ( player.PlaceInBackpack( necklace ) )
						{
                                                        player.SendMessage( "You take the necklace from the bookcase and place it into your pack." );

							if ( obj != null && !obj.Completed )
								obj.Complete();
						}
						else
						{
                                                        player.SendMessage( "You find a necklace, but can't pick it up because your pack is too full. Come back when you have more room in your pack." );
							necklace.Delete();
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