using System;
using Server.Network;

namespace Server.Items
{
	public class LightEnhancingCrystal : Item
	{
		[Constructable]
		public LightEnhancingCrystal() : base( 0x1F1C )
		{
			Name = "Light Enhancing Crystal";
			Weight = 1.0;
			Hue = 1153;

		        LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a unique crystal required to complete the Bright Club quest." );
		}

		public LightEnhancingCrystal( Serial serial ) : base( serial )
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