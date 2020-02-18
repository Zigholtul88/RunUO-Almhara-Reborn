using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicCopper : RunicHammer
	{

		[Constructable]
		public RunicCopper() : this( 10 )
		{
		}		

		[Constructable]
		public RunicCopper( int uses ) : base( CraftResource.Copper )
		{
                  Name = "Copper Runic Hammer";
                  Hue = 2413;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicCopper( Serial serial ) : base( serial )
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