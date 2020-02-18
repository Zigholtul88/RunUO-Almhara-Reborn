using System;

namespace Server.Items
{
	[FlipableAttribute( 15293, 15294 )]
	public class Boxers : BasePants
	{
		public override int InitMinHits{ get{ return 45; } }
		public override int InitMaxHits{ get{ return 55; } }

		[Constructable]
		public Boxers() : this( 0 )
		{
		}

		[Constructable]
		public Boxers( int hue ) : base( 15293, hue )
		{
                        Name = "Boxers";
			Weight = 0.1;
		}

		public Boxers( Serial serial ) : base( serial )
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
