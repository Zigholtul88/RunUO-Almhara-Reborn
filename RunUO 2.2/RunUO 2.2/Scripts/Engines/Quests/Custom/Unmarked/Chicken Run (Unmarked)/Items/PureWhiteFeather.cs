using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class PureWhiteFeather : Item
	{
		[Constructable]
		public PureWhiteFeather() : this( 1 )
		{
		}

		[Constructable]
		public PureWhiteFeather( int amount ) : base( 0x1BD1 )
		{
			Stackable = true;
			Weight = 0.1;
		        Hue = 1153;
			Amount = amount;
			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "feathers required to complete the Chicken Run mini quest." );
		}

		public PureWhiteFeather( Serial serial ) : base( serial )
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
