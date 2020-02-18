using System;
using Server;

namespace Server.Items
{
	public class ForestHartShard : Item
	{
		[Constructable]
		public ForestHartShard() : base( 0x3678 )
		{
                        Name = "Forest Hart Shard";
			Weight = 2.0;
                        Hue = 86;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the shard from an alytharr forest hart that can be sold to butchers. Can also be given to them instead of sold for a specialized variant which allows entry to Murekmere Dwelling." );
			m.PlaySound( 0x82 );
		}

		public ForestHartShard( Serial serial ) : base( serial )
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