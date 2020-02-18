using System;
using Server;

namespace Server.Items
{
	public class GiantToadEye : Item
	{
		[Constructable]
		public GiantToadEye() : this( 1 )
		{
		}

		[Constructable]
		public GiantToadEye( int amount ) : base( 0x5749 )
		{
			Name = "Giant Toad Eye";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the eye of a giant toad that can be sold to butchers." );
			m.PlaySound( 0x26B );
		}

		public GiantToadEye( Serial serial ) : base( serial )
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