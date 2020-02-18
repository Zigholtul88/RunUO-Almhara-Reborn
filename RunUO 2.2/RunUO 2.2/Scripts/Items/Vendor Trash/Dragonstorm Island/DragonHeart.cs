using System;
using Server;

namespace Server.Items
{
	public class DragonHeart : Item
	{
		[Constructable]
		public DragonHeart() : base( 0xF91 )
		{
                        Name = "Dragon Heart";
			Weight = 5.0;
                        Hue = 39;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a dragon heart that can be sold to butchers." );
		}

		public DragonHeart( Serial serial ) : base( serial )
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