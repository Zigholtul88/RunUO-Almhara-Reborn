using System;

namespace Server.Items
{
	public class ValkyrieWings : BaseCloak
	{
		public override int InitMinHits{ get{ return 11; } }
		public override int InitMaxHits{ get{ return 40; } }

		[Constructable]
		public ValkyrieWings() : this( 0 )
		{
		}

		[Constructable]
		public ValkyrieWings( int hue ) : base( 15301, hue )
		{ 
                        Name = "Valkyrie Wings";
			Weight = 5.0;
		}

		public ValkyrieWings( Serial serial ) : base( serial )
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