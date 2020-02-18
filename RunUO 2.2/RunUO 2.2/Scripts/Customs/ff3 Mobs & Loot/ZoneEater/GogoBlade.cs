//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class GogoBlade : Katana
  {
	public override int ArtifactRarity{ get{ return 6; } }


      [Constructable]
		public GogoBlade()
		{
          Name = "[FF6] Gogo's Blade";
	  Hue = 50;
      WeaponAttributes.HitLightning = 100;
      WeaponAttributes.HitLeechHits = 65;
      WeaponAttributes.HitLeechMana = 80;
      WeaponAttributes.HitLeechStam = 65;
      WeaponAttributes.UseBestSkill = 1;
      Attributes.AttackChance = 50;
      Attributes.BonusDex = 12;
      Attributes.BonusInt = 12;
      Attributes.DefendChance = 15;
      Attributes.WeaponDamage = 45;
      Attributes.WeaponSpeed = 25;
		}

		public GogoBlade( Serial serial ) : base( serial )
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
