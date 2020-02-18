using System;
using Server;

namespace Server.Items
{
	public class TrollTooth : Item
	{
		[Constructable]
		public TrollTooth() : this( 1 )
		{
		}

		[Constructable]
		public TrollTooth( int amount ) : base( 0x5747 )
		{
                        Name = "Troll Tooth";
			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the tooth from a troll that can be sold to butchers." );
			m.PlaySound( 367 );
		}

		public TrollTooth( Serial serial ) : base( serial )
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