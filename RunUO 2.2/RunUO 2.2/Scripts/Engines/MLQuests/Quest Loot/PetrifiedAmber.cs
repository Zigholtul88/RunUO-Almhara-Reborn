using System;
using Server;

namespace Server.Items
{
	public class PetrifiedAmber : Item
	{
		[Constructable]
		public PetrifiedAmber() : this( 1 )
		{
		}

		[Constructable]
		public PetrifiedAmber( int amount ) : base( 0xF25 )
		{
                        Name = "Petrified Amber - (Quest Item)";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
			Hue = 1169;
			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "amber that is used for various quests." );
		}

		public PetrifiedAmber( Serial serial ) : base( serial )
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
		}
	}
}