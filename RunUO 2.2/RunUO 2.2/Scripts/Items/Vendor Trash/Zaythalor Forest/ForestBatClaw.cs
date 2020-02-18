using System;
using Server;

namespace Server.Items
{
	public class ForestBatClaw : Item
	{
		[Constructable]
		public ForestBatClaw() : this( 1 )
		{
		}

		[Constructable]
		public ForestBatClaw( int amount ) : base( 0x2DB8 )
		{
                        Name = "Forest Bat Claw";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 1237;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a bat claw that can be sold to butchers." );
			m.PlaySound( 0x270 );
		}

		public ForestBatClaw( Serial serial ) : base( serial )
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