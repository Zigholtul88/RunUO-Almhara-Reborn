using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class OboruSpiderSilk : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public OboruSpiderSilk() : this( 1 )
		{
		}

		[Constructable]
		public OboruSpiderSilk( int amount ) : base( 0xF8D )
		{
			Name = "Oboru Spider Silk - Quest Item";
                        Hue = 1752;
			Stackable = true;
			Amount = amount;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "an item needed for the Spiderwick Chronicles quest" );
		}

		public OboruSpiderSilk( Serial serial ) : base( serial )
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


