using System;
using Server;

namespace Server.Items
{
	public class RoseOfShangyang : Item
	{
		[Constructable]
		public RoseOfShangyang() : base( 10299 )
		{
                        Name = "Rose of Shangyang";
			Weight = 0.1;
                        Hue = 2583;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the rose from a shangyang that can be sold to butchers." );
			m.PlaySound( 0x07E );
		}

		public RoseOfShangyang( Serial serial ) : base( serial )
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