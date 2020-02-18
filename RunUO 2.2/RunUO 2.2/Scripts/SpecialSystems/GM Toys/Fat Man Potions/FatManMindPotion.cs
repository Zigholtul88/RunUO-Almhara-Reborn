using System;
using Server;

namespace Server.Items
{
	public class FatManMindPotion : BaseMindPotion
	{
		public override int IntOffset{ get{ return 50; } }
		public override TimeSpan Duration{ get{ return TimeSpan.FromMinutes( 10.0 ); } }

		[Constructable]
		public FatManMindPotion() : base( PotionEffect.Agility )
		{
                     Name = "Maximum Teal Potion";
                     ItemID = 0xF04;
                     Hue = 1173;
		}

		public FatManMindPotion( Serial serial ) : base( serial )
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