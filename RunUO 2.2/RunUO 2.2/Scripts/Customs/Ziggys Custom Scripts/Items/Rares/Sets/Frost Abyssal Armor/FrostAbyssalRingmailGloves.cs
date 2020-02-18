using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class FrostAbyssalRingmailGloves : RingmailGloves
	{
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		[Constructable]
		public FrostAbyssalRingmailGloves() 
		{
			Name = "Frost Abyssal Ringmail Gloves";
			Hue = 1152;
		}

		public FrostAbyssalRingmailGloves( Serial serial ) : base( serial )
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
