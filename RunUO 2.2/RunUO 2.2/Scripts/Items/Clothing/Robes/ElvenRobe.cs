using System;

namespace Server.Items
{
	[Flipable( 0x2FB9, 0x3173 )]
	public class ElvenRobe : BaseOuterTorso
	{
		// TODO: Supports arcane?

		public override Race RequiredRace { get { return Race.Elf; } }

		[Constructable]
		public ElvenRobe() : this( 0 )
		{
		}

		[Constructable]
		public ElvenRobe( int hue ) : base( 0x2FB9, hue )
		{
			Weight = 2.0;
		}

		public override bool AllowFemaleWearer{ get{ return false; } }

		public ElvenRobe( Serial serial ) : base( serial )
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

