using System;
using Server;

namespace Server.Items
{
	public class RoseOfUmdhlebi : Item
	{
		[Constructable]
		public RoseOfUmdhlebi() : base( 10299 )
		{
                        Name = "Rose of Umdhlebi";
			Weight = 0.1;
                        Hue = 181;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the rose from an umdhlebi that can be sold to butchers." );
			m.PlaySound( 0x018 );
		}

		public RoseOfUmdhlebi( Serial serial ) : base( serial )
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