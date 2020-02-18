using System;
using Server;

namespace Server.Items
{
	public class FatManStrengthPotion : BaseStrengthPotion
	{
		public override int StrOffset{ get{ return 50; } }
		public override TimeSpan Duration{ get{ return TimeSpan.FromMinutes( 10.0 ); } }

		[Constructable]
		public FatManStrengthPotion() : base( PotionEffect.StrengthGreater )
		{
                       Name = "Fat Man White Potion";
		}

		public FatManStrengthPotion( Serial serial ) : base( serial )
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