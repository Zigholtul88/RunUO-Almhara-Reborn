using System;

namespace Server.Items
{
	[Flipable( 16373, 16374 )]
	public class MoonElfFancyRobe : BaseOuterTorso
	{
		public override Race RequiredRace { get { return Race.Elf; } }

		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 50; } }

		[Constructable]
		public MoonElfFancyRobe() : this( 0 )
		{
		}

		[Constructable]
		public MoonElfFancyRobe( int hue ) : base( 16373, hue )
		{
                        Name = "Moon Elf Fancy Robe";
			Weight = 5.0;
		}

		public MoonElfFancyRobe( Serial serial ) : base( serial )
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

