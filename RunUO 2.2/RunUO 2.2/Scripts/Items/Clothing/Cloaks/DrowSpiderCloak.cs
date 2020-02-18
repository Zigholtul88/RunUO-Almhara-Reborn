using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2B04, 0x2B05 )]
	public class DrowSpiderCloak : BaseCloak
	{
		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseFireResistance{ get{ return 5; } }
		public override int BaseColdResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 5; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		[Constructable]
		public DrowSpiderCloak() : base( 0x2B05 )
		{
                      Name = "Spider Cloak";
                      Hue = 619;
		}

		public DrowSpiderCloak( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}








