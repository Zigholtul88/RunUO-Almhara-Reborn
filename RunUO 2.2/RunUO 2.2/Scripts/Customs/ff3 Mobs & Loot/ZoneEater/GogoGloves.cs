//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class GogoGloves : BoneGloves
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
		public GogoGloves()
		{
          Name = "[FF6] Gogo's Gloves";
	Hue = 34;
      Attributes.AttackChance = 10;
      Attributes.BonusDex = 15;
      Attributes.BonusHits = 7;
      Attributes.BonusInt = 5;
      Attributes.BonusMana = 12;
      Attributes.BonusStam = 6;
      Attributes.DefendChance = 25;
      Attributes.LowerManaCost = 25;
      Attributes.LowerRegCost = 15;
      Attributes.Luck = 300;
      Attributes.ReflectPhysical = 25;
      Attributes.RegenHits = 3;
      Attributes.RegenMana = 2;
      Attributes.RegenStam = 1;
      Attributes.SpellDamage = 20;
      Attributes.WeaponDamage = 12;
      Attributes.WeaponSpeed = 12;
      Attributes.BonusMana = 10;
		}

		public GogoGloves( Serial serial ) : base( serial )
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
