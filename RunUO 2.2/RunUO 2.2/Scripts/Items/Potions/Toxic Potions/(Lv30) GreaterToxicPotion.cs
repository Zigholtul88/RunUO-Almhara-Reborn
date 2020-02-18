using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class GreaterToxicPotion : BaseToxicPotion
	{
		public override Poison Poison{ get{ return Poison.Greater; } }

		public override int MinDamage { get { return 4; } }
		public override int MaxDamage { get { return 7; } }

		private int m_RequiredLevel = 30;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[Constructable]
		public GreaterToxicPotion() : base( PotionEffect.PoisonGreater )
		{
                        Name = "Greater Toxic Potion";
			Hue = 64;
		}

		public GreaterToxicPotion( Serial serial ) : base( serial )
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