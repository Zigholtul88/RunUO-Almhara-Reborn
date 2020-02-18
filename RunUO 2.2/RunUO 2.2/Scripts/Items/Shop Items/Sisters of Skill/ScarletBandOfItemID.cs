using System;
using Server;

namespace Server.Items
{
	public class ScarletBandOfItemID : BaseBracelet
	{
		[Constructable]
		public ScarletBandOfItemID() : base( 0x1F06 )
		{
                        Name = "Scarlet Band Of Item ID";
                        Hue = 1608;
			Weight = 0.1;

			SkillBonuses.SetValues( 0, SkillName.ItemID, 5.0 );
		}

		public ScarletBandOfItemID( Serial serial ) : base( serial )
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