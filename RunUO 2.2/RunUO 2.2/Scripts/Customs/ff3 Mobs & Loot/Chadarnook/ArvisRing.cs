//Customized By Mrs Death
using System;
using Server;

namespace Server.Items
{
	public class ArvisRing : GoldRing
	{
		public override int ArtifactRarity{ get{ return 6; } }

		[Constructable]
		public ArvisRing()
		{
			Name = "[FF6] Returner's Ring";
			SkillBonuses.SetValues( 0, SkillName.Peacemaking, 5.0 );
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.BonusDex = 5;
			Attributes.BonusStr = 15;
			Attributes.BonusInt = 10;
                        Attributes.RegenHits = 1;
                        Attributes.RegenMana = 1;
                        Attributes.RegenStam = 1;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 30;
                        Attributes.WeaponSpeed = 10;
                        Attributes.WeaponDamage = 5;
		}

		public ArvisRing( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}