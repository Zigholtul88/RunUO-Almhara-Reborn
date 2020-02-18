using System;

namespace Server.Items
{
	[FlipableAttribute( 15840, 15841 )]
	public class FancyPants : BasePants
	{
		public override int InitMinHits{ get{ return 11; } }
		public override int InitMaxHits{ get{ return 40; } }

		[Constructable]
		public FancyPants() : this( 0 )
		{
		}

		[Constructable]
		public FancyPants( int hue ) : base( 15840, hue )
		{
                        Name = "Fancy Pants";
			Weight = 2.0;
		}

		public FancyPants( Serial serial ) : base( serial )
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
