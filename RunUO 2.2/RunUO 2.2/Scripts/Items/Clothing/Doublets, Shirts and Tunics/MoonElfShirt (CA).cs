using System;

namespace Server.Items
{
	[Flipable( 16169, 16170 )]
	public class MoonElfShirt : BaseShirt
	{
		public override Race RequiredRace { get { return Race.Elf; } }

		[Constructable]
		public MoonElfShirt() : this( 0 )
		{
		}

		[Constructable]
		public MoonElfShirt( int hue ) : base( 16169, hue )
		{
                        Name = "Moon Elf Shirt";
			Weight = 2.0;
		}

		public MoonElfShirt(Serial serial): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
