using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class LargeFrogBoneShards : Item
	{
		[Constructable]
		public LargeFrogBoneShards() : base( 0x1B1A )
		{
			Name = "Large Frog Bone Shards";
			Weight = 0.01;
                  Hue = 661;
                  Stackable = false;
		}

		public LargeFrogBoneShards( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "bones from a large frog" );
		}
	}
}


