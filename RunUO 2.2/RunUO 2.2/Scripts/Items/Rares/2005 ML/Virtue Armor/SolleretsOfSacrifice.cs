using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2B12, 0x2B13 )]
	public class SolleretsOfSacrifice : Shoes
	{
		[Constructable]
		public SolleretsOfSacrifice() : base( 0x2B13 )
		{
                  Name = "Sollerets Of Sacrifice";
			Weight = 10.0;
		}

		public SolleretsOfSacrifice( Serial serial ) : base( serial )
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








