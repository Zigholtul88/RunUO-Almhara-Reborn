using System;
using Server;

namespace Server.Items
{
	public class RingOfAlchemy : BaseRing
	{
		[Constructable]
		public RingOfAlchemy() : base( 0x108a )
		{
                        Name = "Ring Of Alchemy";
			Weight = 0.1;
                        Hue = 2119;

			SkillBonuses.SetValues( 0, SkillName.Alchemy, 15.0 );
		}

		public RingOfAlchemy( Serial serial ) : base( serial )
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