using System;
using Server;

namespace Server.Items
{
	public class TurquoiseCustom : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public TurquoiseCustom() : this( 1 )
		{
		}

		[Constructable]
		public TurquoiseCustom( int amount ) : base( 0xF15 )
		{
			Name = "Turquoise";
			Stackable = true;
			Amount = amount;
			Hue = 1286;
		}

		public TurquoiseCustom( Serial serial ) : base( serial )
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