using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class PhoenixNorseHelm : NorseHelm
	{
		public override int BaseFireResistance{ get{ return 6; } }
		public override int BasePoisonResistance{ get{ return 4; } }
		public override int BaseEnergyResistance{ get{ return 4; } }

		[Constructable]
		public PhoenixNorseHelm() 
		{
			Name = "Phoenix Norse Helm";
			Hue = 43;
		}

		public PhoenixNorseHelm( Serial serial ) : base( serial )
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
