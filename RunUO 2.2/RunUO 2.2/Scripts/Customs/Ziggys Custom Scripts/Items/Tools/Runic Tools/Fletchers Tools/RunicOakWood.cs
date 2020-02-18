using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicOakWood : RunicFletchersTools
	{

		[Constructable]
		public RunicOakWood() : this( 10 )
		{
		}		

		[Constructable]
		public RunicOakWood( int uses ) : base( CraftResource.OakWood )
		{
                  Name = "Oak Wood Runic Fletchers Tools";
                  Hue = 2010;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicOakWood( Serial serial ) : base( serial )
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