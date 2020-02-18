using System;
using Server;

namespace Server.Items
{
	public class SpecializedForestHartShard : Item
	{
		[Constructable]
		public SpecializedForestHartShard() : base( 0x3678 )
		{
                        Name = "Specialized Forest Hart Shard";
			Weight = 2.0;
                        Hue = 86;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a modified forest hart shard that allows access to Murkmere Dwelling." );
			m.PlaySound( 0x82 );
		}

		public SpecializedForestHartShard( Serial serial ) : base( serial )
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