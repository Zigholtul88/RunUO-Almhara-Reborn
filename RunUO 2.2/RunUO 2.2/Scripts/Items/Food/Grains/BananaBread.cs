using System;
using System.Collections;
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class BananaBread : Food
	{
		[Constructable]
		public BananaBread() : this( 1 )
		{
		}

		[Constructable]
		public BananaBread( int amount ) : base( amount, 0x103B )
		{
                        Name = "Banana Bread";
			this.Weight = 1.0;
			this.FillFactor = 3;
		}

		public BananaBread( Serial serial ) : base( serial )
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