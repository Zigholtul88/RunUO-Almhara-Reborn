using System;
using System.Collections;
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class Donuts : Food
	{
		[Constructable]
		public Donuts() : this( 1 )
		{
		}

		[Constructable]
		public Donuts( int amount ) : base( amount, 0x1AD3 )
		{
			this.Weight = 1.0;
			this.FillFactor = 3;
		}

		public Donuts( Serial serial ) : base( serial )
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