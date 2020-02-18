using System;
using Server;

namespace Server.Items
{
	public class GiantHarpyEgg : Item
	{
		public override string DefaultName
		{
			get { return "a harpy egg"; }
		}

		[Constructable]
                public GiantHarpyEgg() : base( 0x366D )
                {
			Movable = false;
			Hue = 288;
                }
        
		public GiantHarpyEgg( Serial serial ) : base( serial )
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