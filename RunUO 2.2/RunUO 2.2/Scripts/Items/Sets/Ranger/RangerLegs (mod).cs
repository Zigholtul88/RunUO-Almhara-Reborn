using System;
using Server.Items;

namespace Server.Items
{
	public class RangerLegs : StuddedLegs
	{
		[Constructable]
		public RangerLegs() 
		{
                  Name = "Ranger's Studded Legs";
			Hue = 0x59C;

			SkillBonuses.SetValues( 0, SkillName.Archery, 1.0 );
		}

		public RangerLegs( Serial serial ) : base( serial )
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