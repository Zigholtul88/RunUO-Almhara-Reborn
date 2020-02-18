using System;
using Server;

namespace Server.Items
{
	public class KitsuneClaw : Item
	{
		[Constructable]
		public KitsuneClaw() : this( 1 )
		{
		}

		[Constructable]
		public KitsuneClaw( int amount ) : base( 0x2DB8 )
		{
                        Name = "Kitsune Claw";
			Stackable = true;
			Amount = amount;

			Weight = 1.0;
                        Hue = 1810;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a kitsune claw that can be sold to butchers." );
			m.PlaySound( 0x4DE );
		}

		public KitsuneClaw( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}