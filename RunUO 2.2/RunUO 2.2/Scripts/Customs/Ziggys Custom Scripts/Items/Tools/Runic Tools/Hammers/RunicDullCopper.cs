using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicDullCopper : RunicHammer
	{
	
		[Constructable]
		public RunicDullCopper() : this( 10 )
		{
		}		

		[Constructable]
		public RunicDullCopper( int uses ) : base( CraftResource.DullCopper )
		{
                  Name = "Dull Copper Runic Hammer";
                  Hue = 2419;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicDullCopper( Serial serial ) : base( serial )
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