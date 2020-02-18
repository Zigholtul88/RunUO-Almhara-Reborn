using System;
using Server;

namespace Server.Items
{
	public class BlackLizardEyeBall : Item
	{
		[Constructable]
		public BlackLizardEyeBall() : this( 1 )
		{
		}

		[Constructable]
		public BlackLizardEyeBall( int amount ) : base( 0x5749 )
		{
			Name = "Black Lizard Eye Ball";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 2406;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "eyeball of a black lizard that can be sold to butchers." );
			m.PlaySound( 0x5A );
		}

		public BlackLizardEyeBall( Serial serial ) : base( serial )
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