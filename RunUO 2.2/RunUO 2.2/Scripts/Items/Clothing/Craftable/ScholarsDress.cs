using System;
using Server.Items;

namespace Server.Items
{
	public class ScholarsDress : BaroqueDress
	{
		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		[Constructable]
		public ScholarsDress()
		{
                        Name = "Scholar's Dress";
			Hue = 181;

			SkillBonuses.SetValues( 0, SkillName.Meditation, 10.0 );

			Attributes.BonusInt = 2;
			Attributes.SpellDamage = 10;
			Attributes.LowerManaCost = 10;
		}

		public ScholarsDress( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}