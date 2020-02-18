using System;
using Server;

namespace Server.Items
{
	public class OphidianEye : Item
	{
		[Constructable]
		public OphidianEye() : this( 1 )
		{
		}

		[Constructable]
		public OphidianEye( int amount ) : base( 0x5749 )
		{
			Name = "Ophidian Eye";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the eye of an ophidian that can be sold to butchers." );
			m.PlaySound( 634 );
		}

		public OphidianEye( Serial serial ) : base( serial )
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