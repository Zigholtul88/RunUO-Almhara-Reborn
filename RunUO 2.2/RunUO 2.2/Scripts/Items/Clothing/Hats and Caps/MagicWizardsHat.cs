using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class MagicWizardsHat : BaseHat
	{
		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 23; } }

		public override void OnAdded( object parent )
		{
			base.OnAdded( parent );

			if ( parent is Mobile )
				((Mobile)parent).VirtualArmorMod += 3;
		}

		public override void OnRemoved(object parent)
		{
			base.OnRemoved( parent );

			if ( parent is Mobile )
				((Mobile)parent).VirtualArmorMod -= 3;
		}

		public override int BaseStrBonus{ get{ return -5; } }
		public override int BaseDexBonus{ get{ return -5; } }
		public override int BaseIntBonus{ get{ return +5; } }

		[Constructable]
		public MagicWizardsHat() : this( 0 )
		{
		}

		[Constructable]
		public MagicWizardsHat( int hue ) : base( 0x1718, hue )
		{
			Weight = 1.0;
		}

		public MagicWizardsHat( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Parent is Mobile )
				((Mobile)Parent).VirtualArmorMod += 3;
		}
	}
}

