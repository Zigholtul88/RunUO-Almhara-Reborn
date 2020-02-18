//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class BanonShirt : Shirt
  {
public override int ArtifactRarity{ get{ return 6; } }


      
      [Constructable]
		public BanonShirt()
		{
          Name = "[FF6] Banon's Shirt";
          Hue = 1368;
      Attributes.AttackChance = 10;
      Attributes.BonusHits = 10;
      Attributes.CastRecovery = 2;
      Attributes.CastSpeed = 2;
      Attributes.DefendChance = 10;
      Attributes.LowerManaCost = 10;
      Attributes.LowerRegCost = 10;
      Attributes.Luck = 500;
      Attributes.NightSight = 1;
      Attributes.ReflectPhysical = 10;
      Attributes.RegenHits = 1;
      Attributes.RegenMana = 1;
      Attributes.RegenStam = 1;
      Attributes.SpellDamage = 10;
		}

		public BanonShirt( Serial serial ) : base( serial )
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
