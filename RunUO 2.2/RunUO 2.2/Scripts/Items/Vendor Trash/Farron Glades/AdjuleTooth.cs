using System;
using Server;

namespace Server.Items
{
	public class AdjuleTooth : Item
	{
		[Constructable]
		public AdjuleTooth() : this( 1 )
		{
		}

		[Constructable]
		public AdjuleTooth( int amount ) : base( 0x5747 )
		{
                        Name = "Adjule Tooth";
			Weight = 0.2;
			Hue = 1165;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the tooth from an adjule that can be sold to butchers." );
			m.PlaySound( 0x85 );
		}

		public AdjuleTooth( Serial serial ) : base( serial )
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