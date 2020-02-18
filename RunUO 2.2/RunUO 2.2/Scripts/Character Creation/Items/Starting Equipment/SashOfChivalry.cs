using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x1541, 0x1542 )] 
	public class SashOfChivalry : BodySash
	{
		[Constructable]
		public SashOfChivalry() : base( 0x1541 )
		{
                        Name = "Sash of Chivalry";
			Hue = 1151;
			LootType = LootType.Blessed;

                        Attributes.BonusStr = 1;
                        Attributes.RegenMana = 1;		
                        SkillBonuses.SetValues(0, SkillName.Chivalry, 5.0);
		}

		public SashOfChivalry( Serial serial ) : base( serial )
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