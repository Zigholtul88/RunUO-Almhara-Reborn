using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2B04, 0x2B05 )]
	public class CloakOfHumility : BaseCloak
	{
		[Constructable]
		public CloakOfHumility() : base( 0x2B05 )
		{
                  Name = "Cloak of Humility";
			Weight = 10.0;
		}

		public CloakOfHumility( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( Weight == 1.0 )
				Weight = 4.0;
		}
	}
}








