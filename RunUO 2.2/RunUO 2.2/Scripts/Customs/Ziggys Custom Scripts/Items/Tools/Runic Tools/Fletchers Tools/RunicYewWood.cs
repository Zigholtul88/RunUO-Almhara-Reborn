using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicYewWood : RunicFletchersTools
	{

		[Constructable]
		public RunicYewWood() : this( 10 )
		{
		}		

		[Constructable]
		public RunicYewWood( int uses ) : base( CraftResource.YewWood )
		{
                  Name = "Yew Wood Runic Fletchers Tools";
                  Hue = 1192;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicYewWood( Serial serial ) : base( serial )
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