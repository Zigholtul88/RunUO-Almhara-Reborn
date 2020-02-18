using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class SuperExplosionPotion : BaseExplosionPotion
	{
		public override int MinDamage { get { return 110; } }
		public override int MaxDamage { get { return 125; } }

		private int m_RequiredLevel = 50;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[Constructable]
		public SuperExplosionPotion() : base( PotionEffect.ExplosionGreater )
		{
		}

		public SuperExplosionPotion( Serial serial ) : base( serial )
		{
                	Name = "Super Purple Potion";
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