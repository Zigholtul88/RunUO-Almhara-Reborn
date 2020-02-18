using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class FrostAbyssalRingmailTunic : RingmailChest
	{
		public override int BaseColdResistance{ get{ return 25; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		[Constructable]
		public FrostAbyssalRingmailTunic() 
		{
			Name = "Frost Abyssal Ringmail Tunic";
			Hue = 1152;
		}

		public FrostAbyssalRingmailTunic( Serial serial ) : base( serial )
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
