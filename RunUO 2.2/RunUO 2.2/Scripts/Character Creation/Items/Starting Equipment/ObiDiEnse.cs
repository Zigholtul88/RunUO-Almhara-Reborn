using System;
using Server;

namespace Server.Items
{
        [FlipableAttribute(0x1515, 0x1530)] 
	public class ObiDiEnse : Obi
	{
		[Constructable]
		public ObiDiEnse() : base(0x27A0)
		{
                        Name = "Obi Di Ense";
                        Hue = 0;
			LootType = LootType.Blessed;
                        Attributes.NightSight = 1;
			Attributes.WeaponSpeed = 15;

                        SkillBonuses.SetValues(0, SkillName.Ninjitsu, 10.0);
		}

		public ObiDiEnse( Serial serial ) : base( serial )
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