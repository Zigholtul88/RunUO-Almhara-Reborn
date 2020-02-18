using System;
using Server;

namespace Server.Items
{
	public class PygmyCraneEggs : Item
	{
		[Constructable]
		public PygmyCraneEggs() : this( 1 )
		{
		}

		[Constructable]
		public PygmyCraneEggs( int amount ) : base( 0x9B5 )
		{
                        Name = "Pygmy Crane Eggs - (Quest Item)";
			Stackable = true;
			Amount = amount;

			Weight = 1.0;
			Hue = 0x482;
			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "eggs that are used for various quests." );
		}

		public PygmyCraneEggs( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( version < 1 )
			{
				Stackable = true;

				if ( Weight == 0.5 )
					Weight = 1.0;
			}
		}
	}
}