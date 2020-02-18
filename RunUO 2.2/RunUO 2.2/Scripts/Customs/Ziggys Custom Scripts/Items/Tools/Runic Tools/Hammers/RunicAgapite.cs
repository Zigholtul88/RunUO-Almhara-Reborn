using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicAgapite : RunicHammer
	{

		[Constructable]
		public RunicAgapite() : this( 10 )
		{
		}		

		[Constructable]
		public RunicAgapite( int uses ) : base( CraftResource.Agapite )
		{
                  Name = "Agapite Runic Hammer";
                  Hue = 2425;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicAgapite( Serial serial ) : base( serial )
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