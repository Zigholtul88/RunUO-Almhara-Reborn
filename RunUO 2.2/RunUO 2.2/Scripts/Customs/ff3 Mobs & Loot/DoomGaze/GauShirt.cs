//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class GauShirt : Shirt
  {
public override int ArtifactRarity{ get{ return 6; } }


      
      [Constructable]
		public GauShirt()
		{
          Name = "[FF6] Gau's Shirt";
          Hue = 353;
      Attributes.AttackChance = 20;
      Attributes.BonusHits = 15;
      Attributes.CastRecovery = 2;
      Attributes.CastSpeed = 2;
      Attributes.DefendChance = 20;
      Attributes.LowerManaCost = 15;
      Attributes.LowerRegCost = 40;
      Attributes.Luck = 100;
      Attributes.NightSight = 1;
      Attributes.ReflectPhysical = 10;
      Attributes.RegenHits = 1;
      Attributes.RegenMana = 1;
      Attributes.RegenStam = 1;
      Attributes.SpellDamage = 15;
		}

		public GauShirt( Serial serial ) : base( serial )
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
