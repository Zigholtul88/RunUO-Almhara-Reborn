using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x1541, 0x1542 )] 
	public class SashOfMight : BodySash
	{
		[Constructable]
		public SashOfMight() : base( 0x1541 )
		{
                        Name = "Sash of Might";
			Hue = 0x481;

                        Attributes.BonusStr = 5;
                        Attributes.RegenHits = 1;		
                        SkillBonuses.SetValues(0, SkillName.Focus, 20.0);
		}

		public SashOfMight( Serial serial ) : base( serial )
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