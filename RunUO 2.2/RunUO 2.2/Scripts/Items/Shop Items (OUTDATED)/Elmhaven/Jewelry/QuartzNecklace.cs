using System;
using Server;

namespace Server.Items
{
	public class QuartzNecklace : BaseNecklace
	{
		[Constructable]
		public QuartzNecklace() : base( 0x1085 )
		{
                        Name = "Quartz Necklace";
                        Hue = 1284;
			Weight = 0.1;

			SkillBonuses.SetValues( 0, SkillName.Meditation, 15.0 );
		}

		public QuartzNecklace( Serial serial ) : base( serial )
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