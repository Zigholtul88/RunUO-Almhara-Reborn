using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class WaterLizardMeat : Food
	{
		[Constructable]
		public WaterLizardMeat() : this( 1 )
		{
		}

		[Constructable]
		public WaterLizardMeat( int amount ) : base( amount, 0x4005 )
		{
			this.Name = "Water Lizard Meat";
			this.Hue = 491;
                        this.Stackable = true;
                        this.Amount = amount;

			this.Weight = 1.0;
			this.FillFactor = 1;
                        this.Poison = Poison.Lesser;
		}

		public WaterLizardMeat( Serial serial ) : base( serial )
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