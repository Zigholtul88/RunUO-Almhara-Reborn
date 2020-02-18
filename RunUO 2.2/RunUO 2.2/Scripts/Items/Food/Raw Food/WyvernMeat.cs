using System;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class WyvernMeat : Food
	{
		[Constructable]
		public WyvernMeat() : this( 1 )
		{
		}

		[Constructable]
                public WyvernMeat( int amount ) : base( amount, 0x9F1 )
		{
			this.Name = "Wyvern Meat";
			this.Hue = 2405;
                        this.Stackable = true;
                        this.Amount = amount;

			this.Weight = 1.0;
			this.FillFactor = 2;
                        this.Poison = Poison.Lesser;
		}

		public WyvernMeat( Serial serial ) : base( serial )
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