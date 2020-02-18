using System;
using Server;

namespace Server.Items
{
	public class AdamantoiseTooth : Item
	{
		[Constructable]
		public AdamantoiseTooth() : this( 1 )
		{
		}

		[Constructable]
		public AdamantoiseTooth( int amount ) : base( 0x5747 )
		{
                        Name = "Adamantoise Tooth";
			Weight = 0.5;
			Hue = 2119;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the tooth from an adamantoise that can be sold to butchers." );
			m.PlaySound( 224 );
		}

		public AdamantoiseTooth( Serial serial ) : base( serial )
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