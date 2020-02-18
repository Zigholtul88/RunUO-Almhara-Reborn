using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicValorite : RunicHammer
	{

		[Constructable]
		public RunicValorite() : this( 10 )
		{
		}		

		[Constructable]
		public RunicValorite( int uses ) : base( CraftResource.Valorite )
		{
                  Name = "Valorite Runic Hammer";
                  Hue = 2219;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicValorite( Serial serial ) : base( serial )
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