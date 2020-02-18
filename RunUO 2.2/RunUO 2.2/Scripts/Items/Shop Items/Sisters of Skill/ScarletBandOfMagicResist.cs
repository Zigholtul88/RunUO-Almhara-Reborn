using System;
using Server;

namespace Server.Items
{
	public class ScarletBandOfMagicResist : BaseBracelet
	{
		[Constructable]
		public ScarletBandOfMagicResist() : base( 0x1F06 )
		{
                        Name = "Scarlet Band Of Magic Resist";
                        Hue = 1608;
			Weight = 0.1;

			SkillBonuses.SetValues( 0, SkillName.MagicResist, 5.0 );
		}

		public ScarletBandOfMagicResist( Serial serial ) : base( serial )
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