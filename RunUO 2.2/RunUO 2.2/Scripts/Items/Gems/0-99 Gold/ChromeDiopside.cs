using System;
using Server;

namespace Server.Items
{
	public class ChromeDiopside : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public ChromeDiopside() : this( 1 )
		{
		}

		[Constructable]
		public ChromeDiopside( int amount ) : base( 0xF1C )
		{
			Name = "Chrome Diopside";
			Stackable = true;
			Amount = amount;
			Hue = 1902;
		}

		public ChromeDiopside( Serial serial ) : base( serial )
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