using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class LethalToxicPotion : BaseToxicPotion
	{
		public override Poison Poison{ get{ return Poison.Lethal; } }

		public override int MinDamage { get { return 6; } }
		public override int MaxDamage { get { return 9; } }

		private int m_RequiredLevel = 70;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[Constructable]
		public LethalToxicPotion() : base( PotionEffect.PoisonDeadly )
		{
                        Name = "Lethal Toxic Potion";
			Hue = 64;
		}

		public LethalToxicPotion( Serial serial ) : base( serial )
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