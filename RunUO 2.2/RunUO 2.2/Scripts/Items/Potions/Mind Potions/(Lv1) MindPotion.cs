using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class MindPotion  : BaseMindPotion
	{
		public override int IntOffset{ get{ return 10; } }
		public override TimeSpan Duration{ get{ return TimeSpan.FromMinutes( 5.0 ); } }

		private int m_RequiredLevel = 1;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[Constructable]
		public MindPotion () : base( PotionEffect.Agility )
		{
                	Name = "Teal Potion";
                	ItemID = 0xF04;
                	Hue = 1173;
		}

		public MindPotion ( Serial serial ) : base( serial )
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