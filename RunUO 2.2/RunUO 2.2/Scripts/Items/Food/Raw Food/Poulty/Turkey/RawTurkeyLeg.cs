using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class RawTurkeyLeg : Food
	{
		[Constructable]
		public RawTurkeyLeg() : this( 1 )
		{
		}

		[Constructable]
		public RawTurkeyLeg( int amount ) : base( amount, 0x1607 )
		{
			this.Name = "Raw Turkey Leg";
                        this.Stackable = true;
                        this.Amount = amount;

			this.Weight = 1.0;
			this.FillFactor = 1;
                        this.Poison = Poison.Lesser;
		}

		public RawTurkeyLeg( Serial serial ) : base( serial )
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