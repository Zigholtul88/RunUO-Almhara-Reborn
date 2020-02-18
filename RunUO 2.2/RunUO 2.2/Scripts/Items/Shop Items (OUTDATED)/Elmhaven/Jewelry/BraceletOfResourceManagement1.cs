using System;
using Server;

namespace Server.Items
{
	public class BraceletOfResourceManagement1 : BaseBracelet
	{
		[Constructable]
		public BraceletOfResourceManagement1() : base( 0x1086 )
		{
                        Name = "Bracelet Of Resource Management +1";
                        Hue = 1173;
			Weight = 0.1;

			Attributes.LowerManaCost = 15;
			Attributes.LowerRegCost = 10;
		}

		public BraceletOfResourceManagement1( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}