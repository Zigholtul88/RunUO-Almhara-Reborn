using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class PhoenixRingmailLeggings : RingmailLegs
	{
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		[Constructable]
		public PhoenixRingmailLeggings() 
		{
			Name = "Phoenix Ringmail Leggings";
			Hue = 43;
		}

		public PhoenixRingmailLeggings( Serial serial ) : base( serial )
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
