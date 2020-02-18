using System;
using Server;

namespace Server.Items
{
	public class SalivaEye : Item
	{
		[Constructable]
		public SalivaEye() : this( 1 )
		{
		}

		[Constructable]
		public SalivaEye( int amount ) : base( 0x5749 )
		{
			Name = "Eye of Saliva";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the eye of Saliva that can be sold to butchers." );
			m.PlaySound( 402 );
		}

		public SalivaEye( Serial serial ) : base( serial )
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