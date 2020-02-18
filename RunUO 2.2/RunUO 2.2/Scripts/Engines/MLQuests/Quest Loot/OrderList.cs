using System;
using Server.Network;

namespace Server.Items
{
	public class OrderList : Item
	{
		[Constructable]
		public OrderList() : base( 0x14F0 )
		{
			Name = "Feron's Order List - Quest Item";
			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "an order list required to complete the Molasses Greed quest." );
		}

		public OrderList( Serial serial ) : base( serial )
		{
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


