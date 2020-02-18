using System;
using Server;

namespace Server.Items
{
	public class WaterLizardEyeBall : Item
	{
		[Constructable]
		public WaterLizardEyeBall() : this( 1 )
		{
		}

		[Constructable]
		public WaterLizardEyeBall( int amount ) : base( 0x5749 )
		{
			Name = "Water Lizard Eye Ball";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 491;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "eyeball of a water lizard that can be sold to butchers." );
			m.PlaySound( 0x5A );
		}

		public WaterLizardEyeBall( Serial serial ) : base( serial )
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