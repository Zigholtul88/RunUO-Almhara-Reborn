//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class MogApron : HalfApron
  {
public override int ArtifactRarity{ get{ return 6; } }


      
      [Constructable]
		public MogApron()
		{
          Name = "[FF6] Mog's Apron";
          Hue = 1150;
      Attributes.AttackChance = 20;
      Attributes.BonusHits = 15;
      Attributes.CastRecovery = 2;
      Attributes.CastSpeed = 2;
      Attributes.LowerManaCost = 15;
      Attributes.LowerRegCost = 40;
      Attributes.Luck = 500;
      Attributes.NightSight = 1;
      Attributes.RegenHits = 2;
      Attributes.SpellDamage = 15;
		}

		public MogApron( Serial serial ) : base( serial )
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
