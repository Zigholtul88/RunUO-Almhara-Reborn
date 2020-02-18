using System;

namespace Server.Items
{
	public class AndorasBook : Item
	{
		[Constructable]
		public AndorasBook() : base( 0xFF2 )
		{
                        Name = "Andora's Book";
		        Weight = 1.0;

			LootType = LootType.Blessed;
                }

		public AndorasBook( Serial serial ) : base( serial )
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