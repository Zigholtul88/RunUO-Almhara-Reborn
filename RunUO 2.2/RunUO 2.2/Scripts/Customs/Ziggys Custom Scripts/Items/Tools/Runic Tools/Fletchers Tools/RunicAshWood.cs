using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicAshWood : RunicFletchersTools
	{

		[Constructable]
		public RunicAshWood() : this( 10 )
		{
		}		

		[Constructable]
		public RunicAshWood( int uses ) : base( CraftResource.AshWood )
		{
                  Name = "Ash Wood Runic Fletchers Tools";
                  Hue = 1191;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicAshWood( Serial serial ) : base( serial )
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