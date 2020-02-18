using System;
using Server;

namespace Server.Items
{
	public class HillToadEye : Item
	{
		[Constructable]
		public HillToadEye() : this( 1 )
		{
		}

		[Constructable]
		public HillToadEye( int amount ) : base( 0x5749 )
		{
			Name = "Hill Toad Eye";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                  Hue = 176;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the eye of a hill toad that can be sold to butchers." );
			m.PlaySound( 0x26B );
		}

		public HillToadEye( Serial serial ) : base( serial )
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