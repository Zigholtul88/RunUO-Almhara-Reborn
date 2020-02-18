using System;
using Server.Network;

namespace Server.Items
{
	public class MMQSpores : Item
	{
		[Constructable]
		public MMQSpores() : base( 0x1036 )
		{
			Name = "Magical Mushroom Spores";
			Weight = 1.0;
			Hue = 62;
		}

		public MMQSpores( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a unique spore required to complete the Mantango Mischief mini quest." );
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