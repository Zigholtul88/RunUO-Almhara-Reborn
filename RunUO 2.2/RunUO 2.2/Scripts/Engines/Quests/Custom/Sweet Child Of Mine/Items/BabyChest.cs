using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server.Engines.Quests.SweetChildOfMine
{
	public class BabyChest : BaseContainer
	{
		[Constructable]
		public BabyChest() : base( 0xE43 )
		{
                        Name = "a chest with something screaming inside";
			Hue = 0xE6;

			Movable = false;
		}

		public BabyChest( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile player = from as PlayerMobile;

			if ( player != null && player.InRange( GetWorldLocation(), 2 ) )
			{
				QuestSystem qs = player.Quest;

				if ( qs is SweetChildOfMineQuest )
				{
					QuestObjective obj = qs.FindObjective( typeof( RetrieveBabyObjective ) );

					if ( (obj != null && !obj.Completed) || SweetChildOfMineQuest.HasBaby( player ) )
					{
						Item item = new Baby();

						if ( player.PlaceInBackpack( item ) )
						{
                                                        player.SendMessage( "Turns out this baby actually belongs to someone. You better take her." );
                                                        player.PlaySound( 0x8E );

							if ( obj != null && !obj.Completed )
								obj.Complete();
						}
						else
						{
                                                        player.SendMessage( "The harsh noise coming from within the chest is enough to repel you back." );
							item.Delete();
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