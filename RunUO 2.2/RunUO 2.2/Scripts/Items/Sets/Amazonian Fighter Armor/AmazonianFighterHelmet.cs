using System;
using Server;

namespace Server.Items
{
	public class AmazonianFighterHelmet : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 6; } }
		public override int BaseColdResistance{ get{ return 4; } }
		public override int BasePoisonResistance{ get{ return 2; } }
		public override int BaseEnergyResistance{ get{ return 1; } }

		public override int InitMinHits{ get{ return 45; } }
		public override int InitMaxHits{ get{ return 60; } }

		public override int AosStrReq{ get{ return 35; } }
		public override int AosDexBonus{ get{ return -1; } }

		public override bool AllowMaleWearer{ get{ return false; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public AmazonianFighterHelmet() : base( 0x2689 )
		{
                        Name = "Amazonian Fighter Helmet";
                        Hue = 138;
			Weight = 5.0;
			Attributes.BonusHits = 5;
			SkillBonuses.SetValues( 0, SkillName.Fencing, 1.0 );
		}

		public AmazonianFighterHelmet( Serial serial ) : base( serial )
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
