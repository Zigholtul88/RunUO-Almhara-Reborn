using System;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 15307, 15308 )]
	public class RoyalBoots : BaseShoes
	{
		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 33; } }

		[Constructable]
		public RoyalBoots() : this( 0 )
		{
		}

		[Constructable]
		public RoyalBoots( int hue ) : base( 15307, hue )
		{
                        Name = "Royal Boots";
			Weight = 6.0;
		}

		public RoyalBoots( Serial serial ) : base( serial )
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