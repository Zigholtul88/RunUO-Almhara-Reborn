using System;
using Server.Items;

namespace Server.Items
{
	public class RangerChest : StuddedChest
	{
		[Constructable]
		public RangerChest() 
		{
                  Name = "Ranger's Studded Chest";
			Hue = 0x59C;

			SkillBonuses.SetValues( 0, SkillName.Archery, 1.0 );
		}

		public RangerChest( Serial serial ) : base( serial )
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