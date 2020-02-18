using System;

namespace Server.Items
{
	[Flipable( 16377, 16378 )]
	public class MoonElfPlainDress : BaseOuterTorso
	{
		public override Race RequiredRace { get { return Race.Elf; } }

		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 50; } }

		[Constructable]
		public MoonElfPlainDress() : this( 0 )
		{
		}

		[Constructable]
		public MoonElfPlainDress( int hue ) : base( 16377, hue )
		{
                        Name = "Moon Elf Plain Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public MoonElfPlainDress( Serial serial ) : base( serial )
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

