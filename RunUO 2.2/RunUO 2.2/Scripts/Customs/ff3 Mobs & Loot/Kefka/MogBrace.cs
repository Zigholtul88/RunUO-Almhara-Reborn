//Customized By Mrs Death

using System;
using Server;

namespace Server.Items
{
	public class MogBrace : GoldBracelet
	{
		public override int ArtifactRarity{ get{ return 6; } }

		[Constructable]
		public MogBrace()
		{
			Name = "[FF6] Mog's Bracelet";
			Hue = 1150;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.BonusDex = 25;
			Attributes.BonusStr = 25;
			Attributes.BonusInt = 25;
                        Attributes.RegenHits = 1;
                        Attributes.RegenMana = 1;
                        Attributes.RegenStam = 1;
			Attributes.LowerManaCost = 20;
			Attributes.LowerRegCost = 20;
                        Attributes.WeaponSpeed = 15;
                        Attributes.WeaponDamage = 10;
		}

		public MogBrace( Serial serial ) : base( serial )
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