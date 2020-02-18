using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class MushroomOnionPizza : Food
	{
		[Constructable]
		public MushroomOnionPizza() : this( 1 )
		{
		}

		[Constructable]
		public MushroomOnionPizza( int amount ) : base( amount, 0x1040 )
		{
			this.Weight = 1.0;
			this.FillFactor = 3;
                        this.Name = "Mushroom and Onion Pizza";
		}

		public MushroomOnionPizza( Serial serial ) : base( serial )
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