using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicBloodwood : RunicFletchersTools
	{

		[Constructable]
		public RunicBloodwood() : this( 10 )
		{
		}		

		[Constructable]
		public RunicBloodwood( int uses ) : base( CraftResource.Bloodwood )
		{
                  Name = "Bloodwood Runic Fletchers Tools";
                  Hue = 1194;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicBloodwood( Serial serial ) : base( serial )
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