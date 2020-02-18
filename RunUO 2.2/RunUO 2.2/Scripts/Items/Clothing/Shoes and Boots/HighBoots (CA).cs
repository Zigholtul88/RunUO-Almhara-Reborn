using System;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 15865, 15866 )]
	public class HighBoots : BaseShoes
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 33; } }

		[Constructable]
		public HighBoots() : this( 0 )
		{
		}

		[Constructable]
		public HighBoots( int hue ) : base( 15865, hue )
		{
                  	Name = "High Boots";
			Weight = 6.0;
		}

		public HighBoots( Serial serial ) : base( serial )
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