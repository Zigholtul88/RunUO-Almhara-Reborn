using System;
using Server;

namespace Server.Items
{
	public class MoonstoneCustom : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public MoonstoneCustom() : this( 1 )
		{
		}

		[Constructable]
		public MoonstoneCustom( int amount ) : base( 0xF1B )
		{
			Name = "Moonstone";
			Stackable = true;
			Amount = amount;
			Hue = 1846;
		}

		public MoonstoneCustom( Serial serial ) : base( serial )
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