using System;

namespace Server.Items
{
	[Flipable( 15846, 15847 )]
	public class FancyTunic : BaseMiddleTorso
	{
		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public FancyTunic() : this( 0 )
		{
		}

		[Constructable]
		public FancyTunic( int hue ) : base( 15846, hue )
		{
                        Name = "Fancy Tunic";
			Weight = 5.0;
		}

		public FancyTunic( Serial serial ) : base( serial )
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

