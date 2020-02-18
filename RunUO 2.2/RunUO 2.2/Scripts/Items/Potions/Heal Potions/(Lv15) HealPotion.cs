using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class HealPotion : BaseHealPotion
	{
		public override int MinHeal { get { return 35; } }
		public override int MaxHeal { get { return 50; } }
		public override double Delay{ get{ return 10.0; } }

		private int m_RequiredLevel = 15;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[Constructable]
		public HealPotion() : base( PotionEffect.Heal )
		{
                	Name = "Yellow Potion";
		}

		public HealPotion( Serial serial ) : base( serial )
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