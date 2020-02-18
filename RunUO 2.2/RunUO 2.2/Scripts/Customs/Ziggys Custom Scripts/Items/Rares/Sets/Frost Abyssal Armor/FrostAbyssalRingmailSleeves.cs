using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class FrostAbyssalRingmailSleeves : RingmailArms
	{
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		[Constructable]
		public FrostAbyssalRingmailSleeves() 
		{
			Name = "Frost Abyssal Ringmail Sleeves";
			Hue = 1152;
		}

		public FrostAbyssalRingmailSleeves( Serial serial ) : base( serial )
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
