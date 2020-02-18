using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class PhoenixStuddedLeatherGorget : StuddedGorget
	{
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 6; } }
		public override int BaseEnergyResistance{ get{ return 6; } }

		[Constructable]
		public PhoenixStuddedLeatherGorget() 
		{
			Name = "Phoenix Studded Leather Gorget";
			Hue = 43;
		}

		public PhoenixStuddedLeatherGorget( Serial serial ) : base( serial )
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
