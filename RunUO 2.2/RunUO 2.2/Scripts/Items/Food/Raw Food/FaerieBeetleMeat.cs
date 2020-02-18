using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class FaerieBeetleMeat : Food
	{
		[Constructable]
		public FaerieBeetleMeat() : this( 1 )
		{
		}

		[Constructable]
		public FaerieBeetleMeat( int amount ) : base( amount, 0x4005 )
		{
			this.Name = "Faerie Beetle Meat";
			this.Hue = 181;
                        this.Stackable = true;
                        this.Amount = amount;

			this.Weight = 2.0;
			this.FillFactor = 1;
                        this.Poison = Poison.Lesser;
		}

		public FaerieBeetleMeat( Serial serial ) : base( serial )
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