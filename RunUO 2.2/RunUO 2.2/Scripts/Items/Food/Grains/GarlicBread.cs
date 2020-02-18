using System;
using System.Collections;
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class GarlicBread : Food
	{
		[Constructable]
		public GarlicBread() : this( 1 )
		{
		}

		[Constructable]
		public GarlicBread( int amount ) : base( amount, 0x98C )
		{
                        Name = "Garlic Bread";
			this.Weight = 1.0;
                        this.Hue = 0x1C8;
			this.FillFactor = 3;
		}

		public GarlicBread( Serial serial ) : base( serial )
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