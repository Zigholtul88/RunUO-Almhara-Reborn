//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class GogoChest : BoneChest
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
		public GogoChest()
		{
          Name = "[FF6] Gogo's Chest";
	Hue = 50;
      Attributes.AttackChance = 15;
      Attributes.BonusDex = 8;
      Attributes.BonusHits = 15;
      Attributes.BonusInt = 7;
      Attributes.BonusMana = 14;
      Attributes.BonusStam = 10;
      Attributes.DefendChance = 15;
      Attributes.LowerManaCost = 15;
      Attributes.LowerRegCost = 12;
      Attributes.Luck = 300;
      Attributes.ReflectPhysical = 5;
      Attributes.RegenHits = 1;
      Attributes.RegenMana = 3;
      Attributes.RegenStam = 2;
      Attributes.SpellDamage = 8;
      Attributes.WeaponDamage = 12;
      Attributes.WeaponSpeed = 5;
      Attributes.BonusMana = 9;
		}

		public GogoChest( Serial serial ) : base( serial )
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
