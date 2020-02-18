using System;
using Server.Items;

namespace Server.Items
{
	public class RangerGorget : StuddedGorget
	{
		[Constructable]
		public RangerGorget() 
		{
                  Name = "Ranger's Studded Gorget";
			Hue = 0x59C;

			SkillBonuses.SetValues( 0, SkillName.Archery, 1.0 );
		}

		public RangerGorget( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}