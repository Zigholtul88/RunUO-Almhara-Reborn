using System;
using Server;

namespace Server.Items
{
	public class PookahEye : Item
	{
		[Constructable]
		public PookahEye() : this( 1 )
		{
		}

		[Constructable]
		public PookahEye( int amount ) : base( 0x5749 )
		{
			Name = "Pookah Eye";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 1908;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "eyeball of a pookah that can be sold to butchers." );
			m.PlaySound( 0xA8 );
		}

		public PookahEye( Serial serial ) : base( serial )
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