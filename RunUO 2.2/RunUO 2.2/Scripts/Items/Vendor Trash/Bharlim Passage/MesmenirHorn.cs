using System;
using Server;

namespace Server.Items
{
	public class MesmenirHorn : Item
	{
		[Constructable]
		public MesmenirHorn() : this( 1 )
		{
		}

		[Constructable]
		public MesmenirHorn( int amount ) : base( 12636 )
		{
			Name = "Mesmenir Horn";
			Stackable = true;
			Amount = amount;

			Weight = 1.0;
                  Hue = 2583;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "horn of a mesmenir that can be sold to butchers." );
			m.PlaySound( 0xA8 );
		}

		public MesmenirHorn( Serial serial ) : base( serial )
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