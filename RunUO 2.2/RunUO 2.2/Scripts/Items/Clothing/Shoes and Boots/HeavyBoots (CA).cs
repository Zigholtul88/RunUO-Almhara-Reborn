using System;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 15863, 15864 )]
	public class HeavyBoots : BaseShoes
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 33; } }

		[Constructable]
		public HeavyBoots() : this( 0 )
		{
		}

		[Constructable]
		public HeavyBoots( int hue ) : base( 15863, hue )
		{
                        Name = "Heavy Boots";
			Weight = 6.0;
		}

		public HeavyBoots( Serial serial ) : base( serial )
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