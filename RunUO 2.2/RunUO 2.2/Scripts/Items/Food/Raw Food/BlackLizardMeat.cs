using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class BlackLizardMeat : Food
	{
		[Constructable]
		public BlackLizardMeat() : this( 1 )
		{
		}

		[Constructable]
		public BlackLizardMeat( int amount ) : base( amount, 0x4005 )
		{
			this.Name = "Black Lizard Meat";
			this.Hue = 2406;
                        this.Stackable = true;
                        this.Amount = amount;

			this.Weight = 1.0;
			this.FillFactor = 2;
                        this.Poison = Poison.Lesser;
		}

		public BlackLizardMeat( Serial serial ) : base( serial )
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