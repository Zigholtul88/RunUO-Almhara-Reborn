using System;
using Server;

namespace Server.Items
{
	public class LesserAntlionCarapace : Item
	{
		[Constructable]
		public LesserAntlionCarapace() : this( 1 )
		{
		}

		[Constructable]
		public LesserAntlionCarapace( int amount ) : base( 0x5720 )
		{
			Name = "Lesser Antlion Carapace";
			Stackable = true;
			Amount = amount;

			Weight = 4.0;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the carapace of an antlion that can be sold to butchers." );
			m.PlaySound( 1006 );
		}

		public LesserAntlionCarapace( Serial serial ) : base( serial )
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