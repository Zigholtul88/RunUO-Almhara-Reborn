using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class ToxicPotion : BaseToxicPotion
	{
		public override Poison Poison{ get{ return Poison.Regular; } }

		public override int MinDamage { get { return 3; } }
		public override int MaxDamage { get { return 6; } }

		private int m_RequiredLevel = 15;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[Constructable]
		public ToxicPotion() : base( PotionEffect.Poison )
		{
                        Name = "Toxic Potion";
			Hue = 64;
		}

		public ToxicPotion( Serial serial ) : base( serial )
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