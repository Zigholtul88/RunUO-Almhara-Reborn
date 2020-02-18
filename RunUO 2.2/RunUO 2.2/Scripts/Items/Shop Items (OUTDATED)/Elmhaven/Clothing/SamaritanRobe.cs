using System;
using Server;

namespace Server.Items
{
	public class SamaritanRobe : FancyRobe
	{
		public override int LabelNumber{ get{ return 1094926; } } // Good Samaritan of Britannia [Replica]

		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 20; } }
		public override int BasePoisonResistance{ get{ return 5; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 50; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public SamaritanRobe()
		{
			Hue = 0x2a3;

			Attributes.BonusMana = 25;
		}

		public SamaritanRobe( Serial serial ) : base( serial )
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
