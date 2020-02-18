using System;

namespace Server.Items
{
	[FlipableAttribute( 15844, 15845 )]
	public class ReinassancePants : BasePants
	{
		public override int InitMinHits{ get{ return 11; } }
		public override int InitMaxHits{ get{ return 40; } }

		[Constructable]
		public ReinassancePants() : this( 0 )
		{
		}

		[Constructable]
		public ReinassancePants( int hue ) : base( 15844, hue )
		{
                        Name = "Reinassance Pants";
			Weight = 2.0;
		}

		public ReinassancePants( Serial serial ) : base( serial )
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
