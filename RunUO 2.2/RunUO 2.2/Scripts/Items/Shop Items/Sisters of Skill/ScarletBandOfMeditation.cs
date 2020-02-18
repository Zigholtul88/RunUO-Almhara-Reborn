using System;
using Server;

namespace Server.Items
{
	public class ScarletBandOfMeditation : BaseBracelet
	{
		[Constructable]
		public ScarletBandOfMeditation() : base( 0x1F06 )
		{
                        Name = "Scarlet Band Of Meditation";
                        Hue = 1608;
			Weight = 0.1;

			SkillBonuses.SetValues( 0, SkillName.Meditation, 5.0 );
		}

		public ScarletBandOfMeditation( Serial serial ) : base( serial )
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