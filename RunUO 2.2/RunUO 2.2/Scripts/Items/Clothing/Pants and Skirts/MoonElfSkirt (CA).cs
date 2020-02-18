using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[Flipable( 16171, 16172 )]
	public class MoonElfSkirt : BaseOuterLegs
	{
		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 24; } }

		[Constructable]
		public MoonElfSkirt() : this( 0 )
		{
		}

		[Constructable]
		public MoonElfSkirt( int hue ) : base( 16171, hue )
		{
                        Name = "Moon Elf Skirt";
			Weight = 4.0;
		}

		public MoonElfSkirt( Serial serial ) : base( serial )
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