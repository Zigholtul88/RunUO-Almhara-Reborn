using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class RawHarpyRibs : Food
	{
		[Constructable]
		public RawHarpyRibs() : this( 1 )
		{
		}

		[Constructable]
		public RawHarpyRibs( int amount ) : base( amount, 0x9F1 )
		{
			this.Name = "Raw Harpy Ribs";
			this.Hue = 1810;
                        this.Stackable = true;
                        this.Amount = amount;

			this.Weight = 1.0;
			this.FillFactor = 2;
                        this.Poison = Poison.Lesser;
		}

		public RawHarpyRibs( Serial serial ) : base( serial )
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