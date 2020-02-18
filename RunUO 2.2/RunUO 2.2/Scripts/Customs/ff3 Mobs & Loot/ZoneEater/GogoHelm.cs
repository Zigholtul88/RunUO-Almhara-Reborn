//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class GogoHelm : SkullCap
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
		public GogoHelm()
		{
          Name = "[FF6] Gogo's Helm";
	Hue = 34;
      Attributes.AttackChance = 12;
      Attributes.BonusDex = 9;
      Attributes.BonusHits = 15;
      Attributes.BonusInt = 9;
      Attributes.BonusMana = 12;
      Attributes.BonusStam = 15;
      Attributes.DefendChance = 7;
      Attributes.LowerManaCost = 30;
      Attributes.LowerRegCost = 25;
      Attributes.Luck = 300;
      Attributes.ReflectPhysical = 15;
      Attributes.RegenHits = 1;
      Attributes.RegenMana = 3;
      Attributes.RegenStam = 2;
      Attributes.SpellDamage = 15;
      Attributes.WeaponDamage = 25;
      Attributes.WeaponSpeed = 25;
      Attributes.BonusMana = 7;
		}

		public GogoHelm( Serial serial ) : base( serial )
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
