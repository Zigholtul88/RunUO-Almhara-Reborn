using System;
using System.Collections;
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class CornBread : Food
	{
		[Constructable]
		public CornBread() : this( 1 )
		{
		}

		[Constructable]
		public CornBread( int amount ) : base( amount, 0x103C )
		{
                        Name = "Corn Bread";
			this.Weight = 1.0;
                        this.Hue = 0x1C7;
			this.FillFactor = 3;
		}

		public CornBread( Serial serial ) : base( serial )
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