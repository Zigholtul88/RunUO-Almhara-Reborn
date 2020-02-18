using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class MaximumAgilityPotion : BaseAgilityPotion
	{
		public override int DexOffset{ get{ return 50; } }
		public override TimeSpan Duration{ get{ return TimeSpan.FromMinutes( 5.0 ); } }

		private int m_RequiredLevel = 70;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[Constructable]
		public MaximumAgilityPotion() : base( PotionEffect.AgilityGreater )
		{
                	Name = "Maximum Blue Potion";
		}

		public MaximumAgilityPotion( Serial serial ) : base( serial )
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