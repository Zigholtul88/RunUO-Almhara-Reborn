using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class MaximumLightningPotion : BaseLightningPotion
	{
		public override int MinDamage { get { return 150; } }
		public override int MaxDamage { get { return 200; } }

		private int m_RequiredLevel = 90;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[Constructable]
		public MaximumLightningPotion() : base( PotionEffect.ExplosionGreater )
		{
                       Name = "Maximum Magenta Potion";
                       Hue = 23;
		}

		public MaximumLightningPotion( Serial serial ) : base( serial )
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