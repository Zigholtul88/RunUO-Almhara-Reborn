using System;
using Server;

namespace Server.Items
{
	public class TerathanEye : Item
	{
		[Constructable]
		public TerathanEye() : this( 1 )
		{
		}

		[Constructable]
		public TerathanEye( int amount ) : base( 0x5749 )
		{
			Name = "Terathan Eye";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the eye of a terathan that can be sold to butchers." );
			m.PlaySound( 594 );
		}

		public TerathanEye( Serial serial ) : base( serial )
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