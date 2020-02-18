using System;
using Server;

namespace Server.Items
{
	public class DesertOstardEgg : Item
	{
		[Constructable]
		public DesertOstardEgg() : base( 0x41BE )
		{
                        Name = "Desert Ostard Egg";
			Weight = 1.0;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a slightly uncommon destard ostard egg that can be sold to butchers." );
			m.PlaySound( 1561 );
		}

		public DesertOstardEgg( Serial serial ) : base( serial )
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