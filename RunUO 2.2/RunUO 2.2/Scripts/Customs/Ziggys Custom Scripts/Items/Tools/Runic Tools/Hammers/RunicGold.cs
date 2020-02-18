using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicGold : RunicHammer
	{

		[Constructable]
		public RunicGold() : this( 10 )
		{
		}		

		[Constructable]
		public RunicGold( int uses ) : base( CraftResource.Gold )
		{
                  Name = "Golden Runic Hammer";
                  Hue = 2213;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicGold( Serial serial ) : base( serial )
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