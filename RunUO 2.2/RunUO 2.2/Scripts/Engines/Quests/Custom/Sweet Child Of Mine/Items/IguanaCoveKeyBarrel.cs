using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server.Engines.Quests.SweetChildOfMine
{
	public class IguanaCoveKeyBarrel : BaseContainer
	{
		[Constructable]
		public IguanaCoveKeyBarrel() : base( 0xE77 )
		{
                        Name = "a barrel";
			Movable = false;
		}

		public IguanaCoveKeyBarrel( Serial serial ) : base( serial )
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
					QuestObjective obj = qs.FindObjective( typeof( FindKeyObjective ) );

					if ( (obj != null && !obj.Completed) || SweetChildOfMineQuest.HasIguanaCoveKey( player ) )
					{
						Item item = new IguanaCoveKey();

						if ( player.PlaceInBackpack( item ) )
						{
                                                        player.SendMessage( "You take the key from the barrel and place it in your pack." );

							if ( obj != null && !obj.Completed )
								obj.Complete();
						}
						else
						{
                                                        player.SendMessage( "You find a key and have no immediate use for it. At least for now." );
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