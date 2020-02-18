using System;

namespace Server.Items
{
	[Flipable( 16375, 16376 )]
	public class SunElfPlainDress : BaseOuterTorso
	{
		public override Race RequiredRace { get { return Race.Elf; } }

		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 50; } }

		[Constructable]
		public SunElfPlainDress() : this( 0 )
		{
		}

		[Constructable]
		public SunElfPlainDress( int hue ) : base( 16375, hue )
		{
                        Name = "Sun Elf Plain Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public SunElfPlainDress( Serial serial ) : base( serial )
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

