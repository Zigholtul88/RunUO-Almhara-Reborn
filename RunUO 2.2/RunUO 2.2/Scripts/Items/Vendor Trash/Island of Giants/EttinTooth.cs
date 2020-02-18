using System;
using Server;

namespace Server.Items
{
	public class EttinTooth : Item
	{
		[Constructable]
		public EttinTooth() : this( 1 )
		{
		}

		[Constructable]
		public EttinTooth( int amount ) : base( 0x5747 )
		{
                        Name = "Ettin Tooth";
			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the tooth from an ettin that can be sold to butchers." );
			m.PlaySound( 367 );
		}

		public EttinTooth( Serial serial ) : base( serial )
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