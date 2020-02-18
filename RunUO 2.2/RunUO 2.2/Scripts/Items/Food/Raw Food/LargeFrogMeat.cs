using System;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class LargeFrogMeat : Food
	{
		[Constructable]
		public LargeFrogMeat() : this( 1 )
		{
		}

		[Constructable]
                public LargeFrogMeat( int amount ) : base( amount, 0x9F1 )
		{
			this.Name = "Large Frog Meat";
			this.Hue = 663;
                        this.Stackable = true;
                        this.Amount = amount;

			this.Weight = 1.0;
			this.FillFactor = 1;
                        this.Poison = Poison.Lesser;
		}

		public LargeFrogMeat( Serial serial ) : base( serial )
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