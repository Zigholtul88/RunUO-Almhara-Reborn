using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class PhoenixRingmailSleeves : RingmailArms
	{
		public override int BaseFireResistance{ get{ return 12; } }
		public override int BasePoisonResistance{ get{ return 5; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		[Constructable]
		public PhoenixRingmailSleeves() 
		{
			Name = "Phoenix Ringmail Sleeves";
			Hue = 43;
		}

		public PhoenixRingmailSleeves( Serial serial ) : base( serial )
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
