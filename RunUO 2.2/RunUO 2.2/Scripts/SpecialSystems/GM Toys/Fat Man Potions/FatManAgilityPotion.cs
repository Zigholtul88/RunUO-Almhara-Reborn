using System;
using Server;

namespace Server.Items
{
	public class FatManAgilityPotion : BaseAgilityPotion
	{
		public override int DexOffset{ get{ return 50; } }
		public override TimeSpan Duration{ get{ return TimeSpan.FromMinutes( 10.0 ); } }

		[Constructable]
		public FatManAgilityPotion() : base( PotionEffect.AgilityGreater )
		{
                Name = "Fat Man Blue Potion";
		}

		public FatManAgilityPotion( Serial serial ) : base( serial )
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