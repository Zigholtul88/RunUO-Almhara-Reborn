using System;
using Server;

namespace Server.Items
{
	public class LionTooth : Item
	{
		[Constructable]
		public LionTooth() : this( 1 )
		{
		}

		[Constructable]
		public LionTooth( int amount ) : base( 0x5747 )
		{
                        Name = "Lion Tooth";
			Weight = 0.2;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the tooth from a lion that can be sold to butchers." );
			m.PlaySound( 0x3F0 );
		}

		public LionTooth( Serial serial ) : base( serial )
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