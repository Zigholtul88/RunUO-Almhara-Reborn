using System;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 15869, 15870 )]
	public class ShortBoots : BaseShoes
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 33; } }

		[Constructable]
		public ShortBoots() : this( 0 )
		{
		}

		[Constructable]
		public ShortBoots( int hue ) : base( 15869, hue )
		{
                  	Name = "Short Boots";
			Weight = 6.0;
		}

		public ShortBoots( Serial serial ) : base( serial )
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