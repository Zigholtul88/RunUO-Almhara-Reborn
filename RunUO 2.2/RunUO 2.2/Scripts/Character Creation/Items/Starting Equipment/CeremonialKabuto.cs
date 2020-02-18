using System;
using Server.Items;

namespace Server.Items
{
	public class CeremonialKabuto : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 3; } }
		public override int BaseColdResistance{ get{ return 7; } }
		public override int BasePoisonResistance{ get{ return 3; } }
		public override int BaseEnergyResistance{ get{ return 3; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 55; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public CeremonialKabuto() : base( 0x236D )
		{
			Name = "Ceremonial Kabuto";
			Weight = 5.0;
			LootType = LootType.Blessed;
                        Attributes.RegenHits = 1;
			Attributes.WeaponDamage = 15;

                        SkillBonuses.SetValues(0, SkillName.Bushido, 10.0);
		}

		public CeremonialKabuto( Serial serial ) : base( serial )
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

			if ( Weight == 1.0 )
				Weight = 5.0;
		}
	}
}