//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class ArvisShirt : Shirt
  {
public override int ArtifactRarity{ get{ return 6; } }


      
      [Constructable]
		public ArvisShirt()
		{
          Name = "[FF6] Arvis' Shirt";
          Hue = 305;
      Attributes.AttackChance = 10;
      Attributes.BonusHits = 5;
      Attributes.CastRecovery = 2;
      Attributes.CastSpeed = 2;
      Attributes.DefendChance = 25;
      Attributes.LowerManaCost = 5;
      Attributes.LowerRegCost = 40;
      Attributes.Luck = 700;
      Attributes.NightSight = 1;
      Attributes.ReflectPhysical = 5;
      Attributes.RegenHits = 1;
      Attributes.RegenMana = 1;
      Attributes.RegenStam = 1;
      Attributes.SpellDamage = 15;
		}

		public ArvisShirt( Serial serial ) : base( serial )
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
