using System;
using Server;

namespace Server.Items
{
	public class TeePee : Item
	{
		[Constructable]
		public TeePee() : base( 1173 )
		{
                        Name = "Tee Pee";
			Weight = 0.1;
                        Hue = 1150;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "A piece of fabric designed for use on one's posterior." );
		}

		public TeePee( Serial serial ) : base( serial )
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