using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class RawDireWolfLeg : Food
	{
		[Constructable]
		public RawDireWolfLeg() : this( 1 )
		{
		}

		[Constructable]
		public RawDireWolfLeg( int amount ) : base( amount, 0x160a )
		{
			this.Name = "Raw Dire Wolf Leg";
			this.Hue = 2405;
                        this.Stackable = true;
                        this.Amount = amount;

			this.Weight = 1.0;
			this.FillFactor = 1;
                        this.Poison = Poison.Lesser;
		}

		public RawDireWolfLeg( Serial serial ) : base( serial )
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