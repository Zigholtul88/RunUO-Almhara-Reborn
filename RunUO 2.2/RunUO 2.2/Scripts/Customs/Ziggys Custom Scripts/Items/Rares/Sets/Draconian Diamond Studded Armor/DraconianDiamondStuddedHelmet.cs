using System;
using Server.Items;

namespace Server.Items
{
	public class DraconianDiamondStuddedHelmet : Helmet
	{
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 7; } }
		public override int BaseEnergyResistance{ get{ return 6; } }

		[Constructable]
		public DraconianDiamondStuddedHelmet()
		{
			Name = "Draconian Diamond Studded Helmet";
                  Hue = 2119;
		}

		public DraconianDiamondStuddedHelmet( Serial serial ) : base( serial )
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