using System;
using System.Collections;
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class PumpkinBread : Food
	{
		[Constructable]
		public PumpkinBread() : this( 1 )
		{
		}

		[Constructable]
		public PumpkinBread( int amount ) : base( amount, 0x103B )
		{
                        Name = "Pumpkin Bread";
			this.Weight = 1.0;
                        this.Hue = 0x1C1;
			this.FillFactor = 3;
		}

		public PumpkinBread( Serial serial ) : base( serial )
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