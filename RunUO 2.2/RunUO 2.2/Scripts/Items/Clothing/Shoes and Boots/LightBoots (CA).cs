using System;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 15867, 15868 )]
	public class LightBoots : BaseShoes
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 33; } }

		[Constructable]
		public LightBoots() : this( 0 )
		{
		}

		[Constructable]
		public LightBoots( int hue ) : base( 15867, hue )
		{
                  	Name = "Light Boots";
			Weight = 6.0;
		}

		public LightBoots( Serial serial ) : base( serial )
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