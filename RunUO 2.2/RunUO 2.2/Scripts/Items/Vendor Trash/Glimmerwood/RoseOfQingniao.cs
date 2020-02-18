using System;
using Server;

namespace Server.Items
{
	public class RoseOfQingniao : Item
	{
		[Constructable]
		public RoseOfQingniao() : base( 10299 )
		{
                        Name = "Rose of Qingniao";
			Weight = 0.1;
                        Hue = 88;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the rose from a qingniao that can be sold to butchers." );
			m.PlaySound( 0x07D );
		}

		public RoseOfQingniao( Serial serial ) : base( serial )
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