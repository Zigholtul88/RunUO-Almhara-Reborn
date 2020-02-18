using System;
using Server;

namespace Server.Items
{
	public class BulwarkLeggings : RingmailLegs
	{
		public override int LabelNumber{ get{ return 1077727; } } // Bulwark Leggings

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 8; } }
		public override int BaseColdResistance{ get{ return 8; } }
		public override int BasePoisonResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		[Constructable]
		public BulwarkLeggings()
		{
			Attributes.BonusStr = 5;

			SkillBonuses.SetValues( 0, SkillName.Anatomy, 5.0 );
		}

		public BulwarkLeggings( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
