using System;
using Server;

namespace Server.Items
{
	public class AntLionEgg : Item
	{
		[Constructable]
		public AntLionEgg() : base( 0x41BE )
		{
                        Name = "Ant Lion Egg";
			Weight = 2.0;
			Hue = Utility.RandomList( 1151,1153 );
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a very rare ant lion egg that can be sold to butchers." );
			m.PlaySound( 1006 );
		}

		public AntLionEgg( Serial serial ) : base( serial )
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