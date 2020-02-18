using System;
using Server;

namespace Server.Items
{
	public class SandCrabMandible : Item
	{
		[Constructable]
		public SandCrabMandible() : this( 1 )
		{
		}

		[Constructable]
		public SandCrabMandible( int amount ) : base( 0x5747 )
		{
                        Name = "Sand Crab Mandible";
			Weight = 0.1;
                        Hue = 1864;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the mandible from a sand crab used for the Crab Catchers quest." );
			m.PlaySound( 1561 );
		}

		public SandCrabMandible( Serial serial ) : base( serial )
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