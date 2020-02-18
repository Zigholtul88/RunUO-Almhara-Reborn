using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class PhoenixRingmailTunic : RingmailChest
	{
		public override int BaseFireResistance{ get{ return 18; } }
		public override int BasePoisonResistance{ get{ return 12; } }
		public override int BaseEnergyResistance{ get{ return 12; } }

		[Constructable]
		public PhoenixRingmailTunic() 
		{
			Name = "Phoenix Ringmail Tunic";
			Hue = 43;
		}

		public PhoenixRingmailTunic( Serial serial ) : base( serial )
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
