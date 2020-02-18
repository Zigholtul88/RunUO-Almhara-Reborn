using System;

namespace Server.Items
{
	public class FaerieWings : BaseCloak
	{
		public override int InitMinHits{ get{ return 11; } }
		public override int InitMaxHits{ get{ return 40; } }

		[Constructable]
		public FaerieWings() : this( 0 )
		{
		}

		[Constructable]
		public FaerieWings( int hue ) : base( 15302, hue )
		{ 
                        Name = "Faerie Wings";
			Weight = 5.0;
		}

		public FaerieWings( Serial serial ) : base( serial )
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