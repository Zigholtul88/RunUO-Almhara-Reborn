using System;
using Server;

namespace Server.Items
{
	public class StudentsNecklaceOfHarmony : BaseNecklace
	{
		[Constructable]
		public StudentsNecklaceOfHarmony() : base( 0x1085 )
		{
                        Name = "Students Necklace Of Harmony";
			Weight = 0.1;
                        Hue = 2127;

			SkillBonuses.SetValues( 0, SkillName.Peacemaking, 15.0 );
			SkillBonuses.SetValues( 0, SkillName.Provocation, 15.0 );
		}

		public StudentsNecklaceOfHarmony( Serial serial ) : base( serial )
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