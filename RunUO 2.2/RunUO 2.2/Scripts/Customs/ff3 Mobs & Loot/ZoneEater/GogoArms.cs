//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class GogoArms : PlateArms
  {
public override int ArtifactRarity{ get{ return 6; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int BaseColdResistance{ get{ return 15; } } 
		public override int BaseEnergyResistance{ get{ return 15; } } 
		public override int BasePhysicalResistance{ get{ return 15; } } 
		public override int BasePoisonResistance{ get{ return 15; } } 
		public override int BaseFireResistance{ get{ return 15; } } 
      
      [Constructable]
		public GogoArms()
		{
          Name = "[FF6] Gogo's Arms";
	Hue = 50;
      Attributes.AttackChance = 12;
      Attributes.BonusDex = 9;
      Attributes.BonusHits = 12;
      Attributes.BonusInt = 6;
      Attributes.BonusMana = 12;
      Attributes.BonusStam = 8;
      Attributes.DefendChance = 10;
      Attributes.LowerManaCost = 20;
      Attributes.LowerRegCost = 15;
      Attributes.Luck = 300;
      Attributes.ReflectPhysical = 10;
      Attributes.RegenHits = 2;
      Attributes.RegenMana = 1;
      Attributes.RegenStam = 3;
      Attributes.SpellDamage = 8;
      Attributes.WeaponDamage = 5;
      Attributes.WeaponSpeed = 5;
      Attributes.BonusMana = 7;
		}

		public GogoArms( Serial serial ) : base( serial )
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
