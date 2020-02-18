using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class MegaLightningPotion : BaseLightningPotion
	{
		public override int MinDamage { get { return 125; } }
		public override int MaxDamage { get { return 150; } }

		private int m_RequiredLevel = 70;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[Constructable]
		public MegaLightningPotion() : base( PotionEffect.ExplosionGreater )
		{
                       Name = "Mega Magenta Potion";
                       Hue = 23;
		}

		public MegaLightningPotion( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version

			writer.Write( m_RequiredLevel );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			m_RequiredLevel = reader.ReadInt();
		}
	}
}