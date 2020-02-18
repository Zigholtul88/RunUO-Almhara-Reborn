using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicHornedLeather : RunicSewingKit
	{

		[Constructable]
		public RunicHornedLeather() : this( 10 )
		{
		}		

		[Constructable]
		public RunicHornedLeather( int uses ) : base( CraftResource.HornedLeather )
		{
                  Name = "Horned Leather Runic Sewing Kit";
                  Hue = 2117;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicHornedLeather( Serial serial ) : base( serial )
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