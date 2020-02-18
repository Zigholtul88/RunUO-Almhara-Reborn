using System;

namespace Server.Items
{
	[FlipableAttribute( 15902, 15903 )]
	public class LeatherPants : BasePants
	{
		public override int InitMinHits{ get{ return 45; } }
		public override int InitMaxHits{ get{ return 55; } }

		[Constructable]
		public LeatherPants() : this( 0 )
		{
		}

		[Constructable]
		public LeatherPants( int hue ) : base( 15902, hue )
		{
                        Name = "Leather Pants";
			Weight = 2.0;
		}

		public LeatherPants( Serial serial ) : base( serial )
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
