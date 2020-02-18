using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicShadowIron : RunicHammer
	{

		[Constructable]
		public RunicShadowIron() : this( 10 )
		{
		}		

		[Constructable]
		public RunicShadowIron( int uses ) : base( CraftResource.ShadowIron )
		{
                  Name = "Shadow Iron Runic Hammer";
                  Hue = 2406;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicShadowIron( Serial serial ) : base( serial )
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