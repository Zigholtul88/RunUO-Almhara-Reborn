using System;
using Server;

namespace Server.Items
{
	public class RoseOfJubokko : Item
	{
		[Constructable]
		public RoseOfJubokko() : base( 10299 )
		{
                        Name = "Rose of Jubokko";
			Weight = 0.1;
                        Hue = 251;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the rose from a jubokko that can be sold to butchers." );
			m.PlaySound( 352 );
		}

		public RoseOfJubokko( Serial serial ) : base( serial )
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