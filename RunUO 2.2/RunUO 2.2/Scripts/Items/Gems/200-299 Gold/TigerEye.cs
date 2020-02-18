using System;
using Server;

namespace Server.Items
{
	public class TigerEye : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public TigerEye() : this( 1 )
		{
		}

		[Constructable]
		public TigerEye( int amount ) : base( 0xF1C )
		{
			Name = "Tiger Eye";
			Stackable = true;
			Amount = amount;
			Hue = 1192;
		}

		public TigerEye( Serial serial ) : base( serial )
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