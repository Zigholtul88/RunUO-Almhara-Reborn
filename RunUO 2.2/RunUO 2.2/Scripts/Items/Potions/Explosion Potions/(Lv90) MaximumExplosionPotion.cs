using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class MaximumExplosionPotion  : BaseExplosionPotion
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
		public MaximumExplosionPotion () : base( PotionEffect.ExplosionGreater )
		{
		}

		public MaximumExplosionPotion ( Serial serial ) : base( serial )
		{
                	Name = "Maximum Purple Potion";
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