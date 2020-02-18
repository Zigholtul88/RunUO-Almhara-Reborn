using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicSpinedLeather : RunicSewingKit
	{

		[Constructable]
		public RunicSpinedLeather() : this( 10 )
		{
		}		

		[Constructable]
		public RunicSpinedLeather( int uses ) : base( CraftResource.SpinedLeather )
		{
                  Name = "Spined Leather Runic Sewing Kit";
                  Hue = 2220;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicSpinedLeather( Serial serial ) : base( serial )
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