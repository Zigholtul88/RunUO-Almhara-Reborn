using System;
using System.Collections;
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class BlueberryMuffins : Food
	{
		[Constructable]
		public BlueberryMuffins() : this( 1 )
		{
		}

		[Constructable]
		public BlueberryMuffins( int amount ) : base( amount, 0x9EB )
		{
                        Name = "Blueberry Muffins";
			this.Weight = 1.0;
                        this.Hue = 0x1FC;
			this.FillFactor = 3;
		}

		public BlueberryMuffins( Serial serial ) : base( serial )
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