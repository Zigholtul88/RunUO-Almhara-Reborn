using System;
using Server;

namespace Server.Items
{
	public class ForestOstardEgg : Item
	{
		[Constructable]
		public ForestOstardEgg() : base( 0x41BE )
		{
                        Name = "Forest Ostard Egg";
			Weight = 1.0;
			Hue = 1266;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a slightly uncommon forest ostard egg that can be sold to butchers." );
			m.PlaySound( 0x270 );
		}

		public ForestOstardEgg( Serial serial ) : base( serial )
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