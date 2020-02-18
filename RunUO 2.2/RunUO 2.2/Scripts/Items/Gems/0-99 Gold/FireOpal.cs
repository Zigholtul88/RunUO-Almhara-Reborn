using System;
using Server;

namespace Server.Items
{
	public class FireOpal : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public FireOpal() : this( 1 )
		{
		}

		[Constructable]
		public FireOpal( int amount ) : base( 0xF15 )
		{
			Name = "Fire Opal";
			Stackable = true;
			Amount = amount;
			Hue = 1357;
		}

		public FireOpal( Serial serial ) : base( serial )
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