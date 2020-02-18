using System;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 0x170d, 0x170e )]
	public class Sandals : BaseShoes
	{
		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		[Constructable]
		public Sandals() : this( 0 )
		{
		}

		[Constructable]
		public Sandals( int hue ) : base( 0x170D, hue )
		{
			Weight = 1.0;
		}

		public Sandals( Serial serial ) : base( serial )
		{
		}

		public override bool Dye( Mobile from, DyeTub sender )
		{
			from.SendLocalizedMessage( sender.FailMessage );
			return false;
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
