using System;
using Server;

namespace Server.Items
{
	public class WyvernTooth : Item
	{
		[Constructable]
		public WyvernTooth() : this( 1 )
		{
		}

		[Constructable]
		public WyvernTooth( int amount ) : base( 0x5747 )
		{
                        Name = "Wyvern Tooth";
			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the tooth from a wvyern that can be sold to butchers." );
			m.PlaySound( 362 );
		}

		public WyvernTooth( Serial serial ) : base( serial )
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