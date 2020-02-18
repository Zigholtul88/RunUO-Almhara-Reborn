using System;
using Server;

namespace Server.Items
{
	public class AntLionTooth : Item
	{
		[Constructable]
		public AntLionTooth() : this( 1 )
		{
		}

		[Constructable]
		public AntLionTooth( int amount ) : base( 0x5747 )
		{
                        Name = "Ant Lion Tooth";
			Weight = 0.5;
			Hue = 1058;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the tooth from an ant lion that can be sold to butchers." );
			m.PlaySound( 1006 );
		}

		public AntLionTooth( Serial serial ) : base( serial )
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