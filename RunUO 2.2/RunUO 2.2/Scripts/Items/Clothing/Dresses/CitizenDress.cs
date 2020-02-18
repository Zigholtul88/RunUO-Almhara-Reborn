using System;

namespace Server.Items
{
	[Flipable( 14370, 14371 )]
	public class CitizenDress : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public CitizenDress() : this( 0 )
		{
		}

		[Constructable]
		public CitizenDress( int hue ) : base( 14370, hue )
		{
                        Name = "Citizen Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public CitizenDress( Serial serial ) : base( serial )
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

