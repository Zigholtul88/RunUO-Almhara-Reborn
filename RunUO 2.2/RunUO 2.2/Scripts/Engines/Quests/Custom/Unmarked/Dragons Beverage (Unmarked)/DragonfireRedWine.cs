using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class DragonfireRedWine : Item
	{
		[Constructable]
		public DragonfireRedWine() : base( 0x99F )
		{
			Name = "Dragonfire Red Wine";
			Weight = 1.0;
                  Hue = 37;
		}

		public DragonfireRedWine( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a dragon's favorite alcholic beverage" );
		}
	}
}


