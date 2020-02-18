using System;
using Server;

namespace Server.Items
{
	public class BlackBandana : Bandana
	{
		[Constructable]
		public BlackBandana()
		{
                        Name = "Black Bandana";
                        Hue = 2405;

			SkillBonuses.SetValues( 0, SkillName.Stealing, 10.0 );
		}

		public BlackBandana( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
