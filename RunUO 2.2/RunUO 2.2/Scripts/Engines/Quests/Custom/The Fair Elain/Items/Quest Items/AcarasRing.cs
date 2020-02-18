using System;

namespace Server.Items
{
	public class AcarasRing : Item
	{
		[Constructable]
		public AcarasRing() : base( 0x1F09 )
		{
                        Name = "Acara's Ring";
		        Weight = 1.0;

			LootType = LootType.Blessed;
                }

		public AcarasRing( Serial serial ) : base( serial )
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