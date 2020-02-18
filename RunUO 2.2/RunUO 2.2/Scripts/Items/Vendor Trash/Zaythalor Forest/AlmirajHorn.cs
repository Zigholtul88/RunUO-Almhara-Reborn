using System;
using Server;

namespace Server.Items
{
	public class AlmirajHorn : Item
	{
		[Constructable]
		public AlmirajHorn() : this( 1 )
		{
		}

		[Constructable]
		public AlmirajHorn( int amount ) : base( 12636 )
		{
			Name = "Almiraj Horn";
			Stackable = true;
			Amount = amount;

			Weight = 1.0;
                        Hue = 1769;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "horn of an almiraj that can be sold to butchers." );
			m.PlaySound( 0xC9 );
		}

		public AlmirajHorn( Serial serial ) : base( serial )
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