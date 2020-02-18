using System;
using Server;

namespace Server.Items
{
	public class RedbarkPoisonGland : Item
	{
		[Constructable]
		public RedbarkPoisonGland() : this( 1 )
		{
		}

		[Constructable]
		public RedbarkPoisonGland( int amount ) : base( 0x21FE )
		{
			Name = "Redbark Poison Gland";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 163;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "poison gland of a redbark scorpion that can be sold to butchers." );
			m.PlaySound( 397 );
		}

		public RedbarkPoisonGland( Serial serial ) : base( serial )
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