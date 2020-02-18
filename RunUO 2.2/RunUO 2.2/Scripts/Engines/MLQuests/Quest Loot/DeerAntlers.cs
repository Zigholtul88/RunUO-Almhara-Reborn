using System;
using Server;

namespace Server.Items
{
	public class DeerAntlers : Item
	{
		[Constructable]
		public DeerAntlers() : this( 1 )
		{
		}

		[Constructable]
		public DeerAntlers( int amount ) : base( 0xF86 )
		{
                        Name = "Deer Antlers";
			Stackable = true;
			Amount = amount;

			Weight = 1.0;
                        Hue = 1810;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "deer antlers that can be sold to butchers or used for various quests." );
			m.PlaySound( 0x82 );
		}

		public DeerAntlers( Serial serial ) : base( serial )
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