using System;
using System.IO;
using System.Collections;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
	public class CocoaBean : Food
	{
		[Constructable]
		public CocoaBean() : this( 1 )
		{
		}

		[Constructable]
		public CocoaBean( int amount ) : base( amount, 0x172A )
		{
			this.Weight = 0.5;
			this.FillFactor = 1;
                        this.Hue = 0x47A;
                        this.Name = "Cocoa Bean";
		}

		public CocoaBean( Serial serial ) : base( serial )
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