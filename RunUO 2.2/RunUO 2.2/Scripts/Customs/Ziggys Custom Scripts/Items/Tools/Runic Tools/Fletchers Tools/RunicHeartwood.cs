using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicHeartwood : RunicFletchersTools
	{

		[Constructable]
		public RunicHeartwood() : this( 10 )
		{
		}		

		[Constructable]
		public RunicHeartwood( int uses ) : base( CraftResource.Heartwood )
		{
                  Name = "Heartwood Runic Fletchers Tools";
                  Hue = 1193;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicHeartwood( Serial serial ) : base( serial )
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