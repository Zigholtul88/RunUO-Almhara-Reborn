using System;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class GreySquirrelMeat : Food
	{
		[Constructable]
		public GreySquirrelMeat() : this( 1 )
		{
		}

		[Constructable]
                public GreySquirrelMeat( int amount ) : base( amount, 0x9F1 )
		{
			this.Name = "Grey Squirrel Meat";
			this.Hue = 934;
                        this.Stackable = true;
                        this.Amount = amount;

			this.Weight = 0.1;
			this.FillFactor = 1;
                        this.Poison = Poison.Lesser;
		}

		public GreySquirrelMeat( Serial serial ) : base( serial )
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