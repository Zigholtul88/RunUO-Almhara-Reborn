using System;
using Server.Items;

namespace Server.Items
{
	public class AmazonianFighterGloves : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseFireResistance{ get{ return 5; } }
		public override int BaseColdResistance{ get{ return 2; } }
		public override int BasePoisonResistance{ get{ return 2; } }
		public override int BaseEnergyResistance{ get{ return 1; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int AosStrReq{ get{ return 30; } }
		public override int AosDexBonus{ get{ return -2; } }

		public override bool AllowMaleWearer{ get{ return false; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.None; } }

		[Constructable]
		public AmazonianFighterGloves() : base( 0x13C6 )
		{ 
                        Name = "Amazonian Fighter Gloves";
                        Hue = 138;
			Weight = 1.0;
			Attributes.BonusHits = 5;
			SkillBonuses.SetValues( 0, SkillName.Fencing, 1.0 );
		}

		public AmazonianFighterGloves( Serial serial ) : base( serial )
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

