using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicBarbedLeather : RunicSewingKit
	{

		[Constructable]
		public RunicBarbedLeather() : this( 10 )
		{
		}		

		[Constructable]
		public RunicBarbedLeather( int uses ) : base( CraftResource.BarbedLeather )
		{
                  Name = "Barbed Leather Runic Sewing Kit";
                  Hue = 2129;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicBarbedLeather( Serial serial ) : base( serial )
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