using System;
using Server;

namespace Server.Items
{
	public class LamiaScale : Item
	{
		[Constructable]
		public LamiaScale() : this( 1 )
		{
		}

		[Constructable]
		public LamiaScale( int amount ) : base( 0x26B4 )
		{
			Name = "Lamia Scale";
			Stackable = true;
			Amount = amount;
                        Hue = 88;

			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the scale of a lamia that can be sold to butchers." );
			m.PlaySound( 816 );
		}

		public LamiaScale( Serial serial ) : base( serial )
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