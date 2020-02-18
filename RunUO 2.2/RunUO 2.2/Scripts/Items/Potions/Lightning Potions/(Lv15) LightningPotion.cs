using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class LightningPotion : BaseLightningPotion
	{
		public override int MinDamage { get { return 75; } }
		public override int MaxDamage { get { return 80; } }

		private int m_RequiredLevel = 15;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[Constructable]
		public LightningPotion() : base( PotionEffect.Explosion )
		{
                       Name = "Magenta Potion";
                       Hue = 23;
		}

		public LightningPotion( Serial serial ) : base( serial )
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