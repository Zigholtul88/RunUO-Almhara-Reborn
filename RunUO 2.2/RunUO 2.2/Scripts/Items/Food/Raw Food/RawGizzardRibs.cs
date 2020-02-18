using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class RawGizzardRibs : Food
	{
		[Constructable]
		public RawGizzardRibs() : this( 1 )
		{
		}

		[Constructable]
		public RawGizzardRibs( int amount ) : base( amount, 0x9F1 )
		{
			this.Name = "Raw Gizzard Ribs";
			this.Hue = 1151;
                        this.Stackable = true;
                        this.Amount = amount;

			this.Weight = 1.0;
			this.FillFactor = 1;
                        this.Poison = Poison.Lesser;
		}

		public RawGizzardRibs( Serial serial ) : base( serial )
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