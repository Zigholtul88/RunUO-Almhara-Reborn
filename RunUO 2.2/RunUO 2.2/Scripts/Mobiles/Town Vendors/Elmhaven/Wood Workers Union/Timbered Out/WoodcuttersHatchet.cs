using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class WoodcuttersHatchet : Hatchet
	{
		[Constructable]
		public WoodcuttersHatchet() 
		{
                  Name = "Woodcutters Hatchet";

                  SkillBonuses.SetValues( 0, SkillName.Lumberjacking, 5.0 );
		}

		public WoodcuttersHatchet( Serial serial ) : base( serial )
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