using System;
using System.Collections;
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class PumpkinMuffins : Food
	{
		[Constructable]
		public PumpkinMuffins() : this( 1 )
		{
		}

		[Constructable]
		public PumpkinMuffins( int amount ) : base( amount, 0x9EB )
		{
                        Name = "Pumpkin Muffins";
			this.Weight = 1.0;
                        this.Hue = 0x1C0;
			this.FillFactor = 3;
		}

		public PumpkinMuffins( Serial serial ) : base( serial )
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