using System;
using Server;

namespace Server.Items
{
	public class HagCauldron : Item
	{
		public override string DefaultName
		{
			get { return "a cauldron"; }
		}

		[Constructable]
                public HagCauldron() : base( 0x0974 )
                {
                }
        
		public HagCauldron( Serial serial ) : base( serial )
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