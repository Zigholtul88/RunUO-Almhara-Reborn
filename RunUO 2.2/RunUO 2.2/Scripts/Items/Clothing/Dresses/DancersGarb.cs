using System;

namespace Server.Items
{
	[Flipable( 14376, 14377 )]
	public class DancersGarb : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public DancersGarb() : this( 0 )
		{
		}

		[Constructable]
		public DancersGarb( int hue ) : base( 14376, hue )
		{
                        Name = "Dancers Garb";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public DancersGarb( Serial serial ) : base( serial )
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

