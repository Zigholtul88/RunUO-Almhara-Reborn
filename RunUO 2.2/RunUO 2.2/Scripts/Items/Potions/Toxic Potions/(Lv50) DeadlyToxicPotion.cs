using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class DeadlyToxicPotion : BaseToxicPotion
	{
		public override Poison Poison{ get{ return Poison.Deadly; } }

		public override int MinDamage { get { return 5; } }
		public override int MaxDamage { get { return 8; } }

		private int m_RequiredLevel = 50;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[Constructable]
		public DeadlyToxicPotion() : base( PotionEffect.PoisonDeadly )
		{
                        Name = "Deadly Toxic Potion";
			Hue = 64;
		}

		public DeadlyToxicPotion( Serial serial ) : base( serial )
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