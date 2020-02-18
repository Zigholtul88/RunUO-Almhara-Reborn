using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class GreaterLightningPotion : BaseLightningPotion
	{
		public override int MinDamage { get { return 95; } }
		public override int MaxDamage { get { return 100; } }

		private int m_RequiredLevel = 30;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[Constructable]
		public GreaterLightningPotion() : base( PotionEffect.ExplosionGreater )
		{
                       Name = "Greater Magenta Potion";
                       Hue = 23;
		}

		public GreaterLightningPotion( Serial serial ) : base( serial )
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