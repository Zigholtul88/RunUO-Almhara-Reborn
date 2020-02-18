using System;
using Server;

namespace Server.Items
{
	public class BrilliantSilverNecklace : BaseNecklace
	{
		[Constructable]
		public BrilliantSilverNecklace() : base( 0x1085 )
		{
                        Name = "Brilliant Silver Necklace";
                        Hue = 2407; 
			Weight = 0.1;

			SkillBonuses.SetValues( 0, SkillName.Anatomy, 15.0 );
		}

		public BrilliantSilverNecklace( Serial serial ) : base( serial )
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