using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1c0a, 0x1c0b )]
	public class AmazonianFighterBustier : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 12; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 8; } }
		public override int BasePoisonResistance{ get{ return 4; } }
		public override int BaseEnergyResistance{ get{ return 1; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int AosStrReq{ get{ return 35; } }
		public override int AosDexBonus{ get{ return -5; } }

		public override bool AllowMaleWearer{ get{ return false; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public AmazonianFighterBustier() : base( 0x1C0A )
		{
                        Name = "Amazonian Fighter Bustier";
                        Hue = 138;
			Weight = 4.0;
			Attributes.BonusHits = 10;
			SkillBonuses.SetValues( 0, SkillName.Fencing, 1.0 );
		}

		public AmazonianFighterBustier( Serial serial ) : base( serial )
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
