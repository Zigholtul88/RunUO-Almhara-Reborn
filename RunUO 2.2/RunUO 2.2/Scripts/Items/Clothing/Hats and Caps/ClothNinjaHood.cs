using System;
using Server.Engines.Craft;

namespace Server.Items
{
	[Flipable( 0x278F, 0x27DA )]
	public class ClothNinjaHood : BaseHat
	{
		public override int BasePhysicalResistance{ get{ return 3; } }
		public override int BaseFireResistance{ get{ return 3; } }
		public override int BaseColdResistance{ get{ return 6; } }
		public override int BasePoisonResistance{ get{ return 9; } }
		public override int BaseEnergyResistance{ get{ return 9; } }

		public override int InitMinHits{ get{ return 20; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public ClothNinjaHood() : this( 0 )
		{
		}

		[Constructable]
		public ClothNinjaHood( int hue ) : base( 0x278F, hue )
		{
			Weight = 2.0;
		}

		public ClothNinjaHood( Serial serial ) : base( serial )
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