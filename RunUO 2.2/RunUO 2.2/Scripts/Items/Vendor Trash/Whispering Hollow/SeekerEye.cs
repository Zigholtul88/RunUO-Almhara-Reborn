using System;
using Server;

namespace Server.Items
{
	public class SeekerEye : Item
	{
		[Constructable]
		public SeekerEye() : this( 1 )
		{
		}

		[Constructable]
		public SeekerEye( int amount ) : base( 0x5749 )
		{
			Name = "Seeker Eye";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 1153;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "eyeball of a seeker that can be sold to butchers." );
			m.PlaySound( 0x0AE );
		}

		public SeekerEye( Serial serial ) : base( serial )
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