using System;
using Server;

namespace Server.Items
{
	public class AnnihilationBeetleCarapace : Item
	{
		[Constructable]
		public AnnihilationBeetleCarapace() : this( 1 )
		{
		}

		[Constructable]
		public AnnihilationBeetleCarapace( int amount ) : base( 0x5720 )
		{
			Name = "Annihilation Beetle Carapace";
			Stackable = true;
			Amount = amount;

			Weight = 10.0;
			Hue = 556;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a beetle carapace that can be sold to butchers." );
			m.PlaySound( 0x4F1 );
                }

		public AnnihilationBeetleCarapace( Serial serial ) : base( serial )
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