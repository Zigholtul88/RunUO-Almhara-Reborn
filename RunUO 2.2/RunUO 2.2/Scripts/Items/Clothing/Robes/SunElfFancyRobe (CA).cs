using System;

namespace Server.Items
{
	[Flipable( 16371, 16372 )]
	public class SunElfFancyRobe : BaseOuterTorso
	{
		public override Race RequiredRace { get { return Race.Elf; } }

		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 50; } }

		[Constructable]
		public SunElfFancyRobe() : this( 0 )
		{
		}

		[Constructable]
		public SunElfFancyRobe( int hue ) : base( 16371, hue )
		{
                        Name = "Sun Elf Fancy Robe";
			Weight = 5.0;
		}

		public SunElfFancyRobe( Serial serial ) : base( serial )
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

