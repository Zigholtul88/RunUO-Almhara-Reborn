using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicBronze : RunicHammer
	{

		[Constructable]
		public RunicBronze() : this( 10 )
		{
		}		

		[Constructable]
		public RunicBronze( int uses ) : base( CraftResource.Bronze )
		{
                  Name = "Bronze Runic Hammer";
                  Hue = 2418;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicBronze( Serial serial ) : base( serial )
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