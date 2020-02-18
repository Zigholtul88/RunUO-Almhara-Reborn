using System;
using Server;

namespace Server.Items
{
	public class SahaginScale : Item
	{
		[Constructable]
		public SahaginScale() : this( 1 )
		{
		}

		[Constructable]
		public SahaginScale( int amount ) : base( 0x26B4 )
		{
			Name = "Sahagin Scale";
			Stackable = true;
			Amount = amount;
                        Hue = 1266;

			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the scale of a sahagin that can be sold to butchers." );
			m.PlaySound( 0x275 );
		}

		public SahaginScale( Serial serial ) : base( serial )
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