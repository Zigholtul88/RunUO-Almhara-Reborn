using System;
using Server;

namespace Server.Items
{
	public class IvoryRose : Item
	{
		[Constructable]
		public IvoryRose() : this( 1 )
		{
		}

		[Constructable]
		public IvoryRose( int amount ) : base( 0x234C )
		{
                        Name = "Ivory Rose - (Quest Item)";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
			Hue = 2404;
			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a rose that's used for various quests." );
		}

		public IvoryRose( Serial serial ) : base( serial )
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