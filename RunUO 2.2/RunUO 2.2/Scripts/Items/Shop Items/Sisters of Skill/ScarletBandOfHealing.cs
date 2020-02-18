using System;
using Server;

namespace Server.Items
{
	public class ScarletBandOfHealing : BaseBracelet
	{
		[Constructable]
		public ScarletBandOfHealing() : base( 0x1F06 )
		{
                        Name = "Scarlet Band Of Healing";
                        Hue = 1608;
			Weight = 0.1;

			SkillBonuses.SetValues( 0, SkillName.Healing, 5.0 );
		}

		public ScarletBandOfHealing( Serial serial ) : base( serial )
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