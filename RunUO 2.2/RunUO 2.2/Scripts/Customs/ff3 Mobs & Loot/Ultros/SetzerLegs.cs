//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class SetzerLegs : LongPants
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
		public SetzerLegs()
		{
          Name = "[FF6] Setzer's Legs";
	Hue = 1175;
      Attributes.AttackChance = 25;
      Attributes.BonusDex = 15;
      Attributes.BonusHits = 20;
      Attributes.BonusInt = 12;
      Attributes.BonusMana = 12;
      Attributes.BonusStam = 9;
      Attributes.DefendChance = 25;
      Attributes.LowerManaCost = 30;
      Attributes.LowerRegCost = 20;
      Attributes.Luck = 1500;
      Attributes.ReflectPhysical = 25;
      Attributes.RegenHits = 2;
      Attributes.RegenMana = 1;
      Attributes.RegenStam = 3;
      Attributes.SpellDamage = 12;
      Attributes.WeaponDamage = 15;
      Attributes.WeaponSpeed = 5;
      Attributes.BonusMana = 15;
		}

		public SetzerLegs( Serial serial ) : base( serial )
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
