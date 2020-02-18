using System;

namespace Server.Items
{
	[FlipableAttribute( 15295, 15296 )]
	public class Panties : BasePants
	{
		public override int InitMinHits{ get{ return 45; } }
		public override int InitMaxHits{ get{ return 55; } }

		[Constructable]
		public Panties() : this( 0 )
		{
		}

		[Constructable]
		public Panties( int hue ) : base( 15295, hue )
		{
                        Name = "Panties";
			Weight = 0.1;
		}

		public Panties( Serial serial ) : base( serial )
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
