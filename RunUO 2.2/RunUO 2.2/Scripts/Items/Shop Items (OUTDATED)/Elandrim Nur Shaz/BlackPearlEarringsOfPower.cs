using System;
using Server;

namespace Server.Items
{
	public class BlackPearlEarringsOfPower : BaseEarrings
	{
		[Constructable]
		public BlackPearlEarringsOfPower() : base( 0x1087 )
		{
                        Name = "Black Pearl Earrings of Power";
			Weight = 0.1;
                        Hue = 212;

			SkillBonuses.SetValues( 0, SkillName.Magery, 15.0 );
		}

		public BlackPearlEarringsOfPower( Serial serial ) : base( serial )
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