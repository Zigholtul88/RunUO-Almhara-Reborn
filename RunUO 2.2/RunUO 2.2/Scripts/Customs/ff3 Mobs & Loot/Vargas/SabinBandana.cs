// Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class SabinBandana : Bandana
  {

		public override int ArtifactRarity{ get{ return 6; } }
		public override int BaseColdResistance{ get{ return 15; } } 
		public override int BaseEnergyResistance{ get{ return 15; } } 
		public override int BasePhysicalResistance{ get{ return 15; } } 
		public override int BasePoisonResistance{ get{ return 15; } } 
		public override int BaseFireResistance{ get{ return 15; } } 
      
      [Constructable]
		public SabinBandana()
		{
          Name = "[FF6] Sabin's Bandana";
          Hue = 1169;
      Attributes.AttackChance = 20;
      Attributes.BonusDex = 15;
      Attributes.BonusInt = 15;
      Attributes.BonusStr = 15;
      Attributes.BonusHits = 10;
      Attributes.BonusStam = 10;
      Attributes.BonusMana = 10;
      Attributes.CastRecovery = 2;
      Attributes.CastSpeed = 2;
      Attributes.DefendChance = 20;
      Attributes.LowerManaCost = 15;
      Attributes.LowerRegCost = 15;
      Attributes.Luck = 500;
      Attributes.ReflectPhysical = 20;
      Attributes.SpellDamage = 20;
      Attributes.WeaponDamage = 20;
		}

		public SabinBandana( Serial serial ) : base( serial )
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
