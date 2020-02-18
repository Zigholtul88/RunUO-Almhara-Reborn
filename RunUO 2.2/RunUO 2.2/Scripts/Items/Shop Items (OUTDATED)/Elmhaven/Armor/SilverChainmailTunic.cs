using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13bf, 0x13c4 )]
	public class SilverChainmailTunic : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 35; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 45; } }
		public override int InitMaxHits{ get{ return 60; } }

		public override int AosStrReq{ get{ return 15; } }
		public override int AosDexBonus{ get{ return -1; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Chainmail; } }

		[Constructable]
		public SilverChainmailTunic() : base( 0x13BF )
		{
			Name = "Silver Chainmail Tunic";
                        Hue = 2498;
			Weight = 4.0;

			Attributes.BonusHits = 50;
		}

		public SilverChainmailTunic( Serial serial ) : base( serial )
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