using System;
using Server.Network;

namespace Server.Items
{
	public class FruitBowl : Food
	{
		[Constructable]
		public FruitBowl() : base( 1, 0x2D4F )
		{
			Weight = 1.0;
			FillFactor = 4;
			Stackable = false;
		}

		public FruitBowl( Serial serial ) : base( serial )
		{
		}

		public override bool Eat( Mobile from )
		{
			if ( !base.Eat( from ) )
				return false;

			from.AddToBackpack( new Basket() );
			return true;
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