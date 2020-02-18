using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class PhoenixRingmailGloves : RingmailGloves
	{
		public override int BaseFireResistance{ get{ return 9; } }
		public override int BasePoisonResistance{ get{ return 3; } }
		public override int BaseEnergyResistance{ get{ return 3; } }

		[Constructable]
		public PhoenixRingmailGloves() 
		{
			Name = "Phoenix Ringmail Gloves";
			Hue = 43;
		}

		public PhoenixRingmailGloves( Serial serial ) : base( serial )
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
