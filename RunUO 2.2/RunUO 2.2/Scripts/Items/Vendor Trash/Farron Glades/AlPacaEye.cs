using System;
using Server;

namespace Server.Items
{
	public class AlPacaEye : Item
	{
		[Constructable]
		public AlPacaEye() : this( 1 )
		{
		}

		[Constructable]
		public AlPacaEye( int amount ) : base( 0x5749 )
		{
			Name = "Al-Paca Eye";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 1058;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "eyeball of an al paca that can be sold to butchers." );
			m.PlaySound( 1088 );
		}

		public AlPacaEye( Serial serial ) : base( serial )
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