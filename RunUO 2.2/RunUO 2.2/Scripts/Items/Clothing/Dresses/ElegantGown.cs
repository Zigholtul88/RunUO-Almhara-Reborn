using System;

namespace Server.Items
{
	[Flipable( 14378, 14379 )]
	public class ElegantGown : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public ElegantGown() : this( 0 )
		{
		}

		[Constructable]
		public ElegantGown( int hue ) : base( 14378, hue )
		{
                        Name = "Elegant Gown";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public ElegantGown( Serial serial ) : base( serial )
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

